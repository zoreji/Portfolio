// cmpe2800 - Audio Playback Sample Form Application
// Use NAudio library to enable audio playback with automatic notification of volume samples
//  - these sample value callbacks are used to update the usercontrol meter.
// This application will playback audio, collecting audio sample data callbacks and currently
//   directs these to Trace output, your Meter will comfortably replace this
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace nAudioPlaybackStarter
{
    public partial class Form1 : Form
    {
        string fileName;      // current audio file 
        IWavePlayer _waveOut; // our audio player, many possible with NAudio IWavePlayer interface support
        AudioFileReader _audioFileReader; // our supplier of "real-time" audio signal information
        SampleChannel _sampleChannel = null;
        int _iAlarm = 0;
        // Use a delegate/action to bind to volume control of playback library
        //delegate void _delVoidFloat(float f);   //unused, Action<> generic type used as example replacement
        //_delVoidFloat setVolumeDelegate = null; // as above
        Action<float> setVolumeDelegate = null;   // our easy to use delegate replacement, accepts float 
        public Form1()
        {
            InitializeComponent();
            meter1.onAlarm += meter1_onAlarm;  // Example of Manual event wiring, normally done in property/event component
            Play();
        }

        // Sample event callback method generated from Alarm event that your Meter will notify us of
        private void meter1_onAlarm(object sender, EventArgs e)
        {
            Invoke((MethodInvoker)(() => { Text = "Alarms : " + ++_iAlarm; })); // Lambda version of Invoke(ing) callback
            //Invoke((MethodInvoker)delegate { Text = "Alarms : " + ++_iAlarm; }); // anonymous delegate version of Invoke(ing) callback
        }
        /// <summary>
        /// Close existing and re-initialize a new waveOutEvent ( bad name )
        /// but handles audio output device selection and management
        /// </summary>
        void CreateWaveOut()
        {
            CloseWaveOut();                   // Close existing WaveOuts, ie. stop them and dispose
            if (WaveOut.DeviceCount == 0)     // Should have at least the basic WaveOut default device, usually [0] of possible devices
                throw new Exception("CreateWaveOut::No Wave Devices Available, check playback settings..."); // Can't play, quit
            var waveOut = new WaveOutEvent(); // Make a WaveOut
            waveOut.DeviceNumber = 0;         // Hardcode for WaveOut Default device[0], should be here
            waveOut.DesiredLatency = 200;     // allow some slack, in ms. probably only used in trying to produce mixers of multiple sources
            _waveOut = waveOut;               // assign member
        }
        /// <summary>
        /// Stop any existing output, dispose of the audioFileReader, prepare to close or start another
        /// </summary>
        void CloseWaveOut()
        {
            if (_waveOut != null) _waveOut.Stop();  // if exists, might be playing, stop it before we kill it, 
            if (_audioFileReader != null)
            {
                setVolumeDelegate = null;             // Unwire our volume control
                _audioFileReader.Dispose();           // explicitly release resources
                _audioFileReader = null;
            }
            if (_waveOut != null)
            {
                _waveOut.Dispose();                  // explicitly release resources
                _waveOut = null;
            }
        }
        /// <summary>
        /// Create a new reader from the supplied (fullpath) audio file, 
        /// Assign the volume control delegate to control the playback volume control, then use it set full blast ( 1.0f )
        /// Create a MeteringSampleProvider, manually wire PostVolumeMeter_StreamVolume callback to get notified of audio samples 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private ISampleProvider CreateInputStream(string fileName)
        {
            _audioFileReader = new AudioFileReader(fileName);               // Open and load audio file

            _sampleChannel = new SampleChannel(_audioFileReader, true);     // Ask for sampling, bool = force stereo

            this.setVolumeDelegate = (vol) => _sampleChannel.Volume = vol;  // nice delegate capture, now invoking delegate will mod volume

            // _sampleChannel.Volume = 1.0f; // direct volume change OR
            setVolumeDelegate(1.0f);

            var meteringProvider = new MeteringSampleProvider(_sampleChannel); // Ask for periodic callbacks with sample data, usually 10/sec, 1 pair of samples

            _sampleChannel.PreVolumeMeter += PostVolumeMeter_StreamVolume;     // Wire our callback to PRE-volume source sampling
                                                                               // OR use POST volume control metering : above is line metering, below post-fader metering
                                                                               //meteringProvider.StreamVolume += PostVolumeMeter_StreamVolume;        // Wire our callback to POST-volume source sampling

            return meteringProvider;                                           // Supply provider to initialize our WaveOut object
        }
        /// <summary>
        /// Event callback method, this receives audio sample data, use this callback to update your Meter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PostVolumeMeter_StreamVolume(object sender, StreamVolumeEventArgs e)
        {
            if (InvokeRequired) // did this method get invoked by a different thread ? Not really relevant here, your VU can handle it
            {
                System.Diagnostics.Trace.WriteLine(e.MaxSampleValues[0] + " : " + e.MaxSampleValues[0]); // always test to see what you get..Left : Right volume data
                                                                                                         //vuMeter1.value = new PointF(e.MaxSampleValues[0], e.MaxSampleValues[1]); // Set VU Left and Right properties to our samples[0=Left][1=Right]
                meter1.Value = new PointF(e.MaxSampleValues[0], e.MaxSampleValues[1]);
                
            }
            else
                Text = e.MaxSampleValues[0] + " : " + e.MaxSampleValues[1]; // Not required, as this callback will always be X-thread from NAudio player
        }

        private void Stop()
        {
            if (_waveOut != null) _waveOut.Stop(); // Umm...
        }
        private void Play()
        {
            // Feel free to modify this handler, it has 2 parts, if valid and paused then play, if not valid then getfile, init and play
            // Notice the VU Play, Reset methods, they handle the stopwatch that tries to show elapsed play time
            if (_waveOut != null)
            {
                if (_waveOut.PlaybackState == PlaybackState.Paused)
                {
                    _waveOut.Play();
                }
            }
            else
            {
                if (String.IsNullOrEmpty(fileName) && !GetFile())
                    return; // nojoy
                CreateWaveOut();
                ISampleProvider sampleProvider = null;
                try
                {
                    sampleProvider = CreateInputStream(fileName);
                    _waveOut.Init(sampleProvider);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Loading File : " + ex.Message);
                    return;
                }
                _waveOut.Play();
            }
        }
        private void Pause()
        {
            if (_waveOut != null && _waveOut.PlaybackState == PlaybackState.Playing) // same umm...
            {
                _waveOut.Pause();
            }
        }
        private bool GetFile()
        { // Request a file from the user, most audio types supported and are default filtered
            var openFileDialog = new OpenFileDialog();
            string allExtensions = "*.wav;*.aiff;*.mp3;*.aac";
            openFileDialog.Filter = String.Format("All Supported Files|{0}|All Files (*.*)|*.*", allExtensions);
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog.FileName;
                return true;
            }
            return false;
        }
        /// <summary>
        /// Example MouseDown callback showing volume and meter type property setters for testing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && setVolumeDelegate != null) // if left button, Y location control playback volume
                setVolumeDelegate((1.0f * Height - e.Y) / Height);             //  depending on volume ( PRE/POST ) callback, the meter may not be affected

            if (e.Button == MouseButtons.Right) // Manually iterate through MeterResponse settings, Fast or Medium work best
            {                                   // Buffer sizes : Peak[1], Fast[3], Medium[8], Slow[12]
                                                //vuMeter1.meterResponse = BasicMeters.VUMeter.MeterResponse.Peak;
                if (meter1.Speed >= Meter_Control.Meter.Meter_type.Slow)
                {
                    meter1.Speed = Meter_Control.Meter.Meter_type.Peak;
                }
                else
                    meter1.Speed++;

            }
        }

        private void bt_alarm_Click(object sender, EventArgs e)
        {
            meter1.alert_Lvl = (float)ud_alarm.Value;
        }
    }
}
