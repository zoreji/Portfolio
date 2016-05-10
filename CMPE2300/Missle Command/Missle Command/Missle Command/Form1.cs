/**********************************************************************************
*       Author:       Ervin Hernandez
*       Class:        CMPE 2300
*       Programme:    Missle Command
*       File:         MissleCommand.cs
*       Assignment:   Lab02
*       Date:         2015/11/16
**********************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GDIDrawer;
namespace Missle_Command
{
    public partial class Form1 : Form
    {
        CDrawer Canvas;
        List<Missle> Enemy;
        List<Missle> User;
        int lives = 5;
        bool pause = false;
        int score = 0;
        int incoming = 0;
        int outcoming = 0;
        int kills = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // load the combo box with difficulty
            CB_difficulty.Items.Add("-Choose Difficulty-");
            CB_difficulty.Items.Add("Easy");
            CB_difficulty.Items.Add("Normal");
            CB_difficulty.Items.Add("Hard");
            CB_difficulty.Items.Add("Nuclear Fallout");
            bt_pause.Enabled = false;
            bt_reset.Enabled = false;
        }
        private void bt_Start_Click(object sender, EventArgs e)
        {
            //  the combo box to select the difficulty level of the game 
            //  and adjusting the number of missle user and foe launches
            switch(CB_difficulty.SelectedIndex)
            {
                case 1:
                    //easy              12 user missle      12 enemy missle
                    incoming = 12;
                    outcoming = 12;
                    lives = 10;
                    start();
                    break;
                case 2:
                    //normal            6 user missle       14 enemy missle
                    incoming = 14;
                    outcoming = 6;
                    lives = 5;
                    start();
                    break;
                case 3:
                    //hard              2 user missle       16 enemy missle
                    incoming = 16;
                    outcoming = 2;
                    lives = 3;
                    start();
                    break;
                case 4:
                    //Nuclear Fallout    1 user missle       18 enemy missle
                    incoming = 18;
                    outcoming = 1;
                    lives = 1;
                    start();
                    break;
            }
        }
        /// <summary>
        /// Method:     void bt_pause_Click(object sender, EventArgs e)
        /// Summary:    pause the game and the timer without reseting any of the main variables
        ///             and add a text on the game saying it pause
        /// </summary>
        private void bt_pause_Click(object sender, EventArgs e)
        {
            if (pause)
            {
                pause = false;
                timer.Enabled = true;
            }
            else
            {
                pause = true;
                timer.Enabled = false;
                Canvas.AddText("PAUSE", 24, Color.White);
                Canvas.Render();
            }
        }
        /// <summary>
        /// Method:     void timer_Tick(object sender, EventArgs e)
        /// Summary:    the timer to genrate and produce the game in the canvas
        ///             then excute all the action in the canvas where both the user
        ///             and the game interact
        /// </summary>
        private void timer_Tick(object sender, EventArgs e)
        {
            Point p = new Point();
            // check if pause
            if (!pause)
            {
                // check game over
                if (lives > 0)
                {
                    Canvas.Clear();
                    if (Enemy.Count < incoming)
                        Enemy.Add(new Missle());
                    if (Canvas.GetLastMouseLeftClick(out p) && User.Count < outcoming)
                        User.Add(new Missle(p));

                    /********************************************************************************** 
                    *   Lanbda - set and find the bottom of border
                    *   Enemy.RemoveAll--> remove all objects
                    *   Predicate --> (obj => { bool check = obj.Where().Y > Canvas.ScaledHeight; if (check) lives--; obj.Move(); obj.Render(); return check; })
                    *           check if any foe missle that hit the bottom of the canvas will reduce the life by one and remove any missle
                    ***********************************************************************************/
                    Enemy.RemoveAll(obj => { bool check = obj.Where().Y > Canvas.ScaledHeight; if (check) lives--; obj.Move(); obj.Render(); return check; });

                    /********************************************************************************** 
                    *   Lanbda - set and find border
                    *   Enemy.RemoveAll--> remove all objects
                    *   Predicate --> (obj => { return (obj.Where().X <= 0 || obj.Where().X > Canvas.ScaledWidth); })
                    *           check if any foe missle that pass the or hit the border of the screen
                    ***********************************************************************************/
                    Enemy.RemoveAll(obj => { return (obj.Where().X <= 0 || obj.Where().X > Canvas.ScaledWidth); });

                    /********************************************************************************** 
                    *   Lanbda - check collision
                    *   Enemy.FindAll --> Find all the object
                    *   Predicate --> (y => { bool check = u.Equals(y); if (check) { u.Move(); } return check; }).ForEach(x => { Enemy.Remove(x); score += 100; kills++; })
                    *           uses the User Missle equal to check if they collide or collide with the foe missle
                    *   ForEach --> chaining the method to remove the objects
                    *   Predicate --> (x => { Enemy.Remove(x); score += 100; kills++; })
                    *           removes, if the previous predicate was true, the object and increment the score and kills 
                    ***********************************************************************************/
                    foreach (Missle u in User)
                    {
                        //Enemy.FindAll(y => u.Equals(y)).ForEach(x => { Enemy.Remove(x); score += 100; kills++; });
                        Enemy.FindAll(y => { bool check = u.Equals(y); if (check) { u.Move(); } return check; }).ForEach(x => { Enemy.Remove(x); score += 100; kills++; });
                        u.Move();
                        u.Render();
                    }

                    /**********************************************************************************
                    *   Lanbda - clear all explosion
                    *   User.RemoveAll --> remove all object
                    *   Predicate --> (i => { return i.alpha <= 20; })
                    *           check if the alpha of the User missle is below 20
                    ***********************************************************************************/
                    User.RemoveAll(i => { return i.alpha <= 20; });
                    // Render all of the user missles
                    //foreach (Missle u in User)
                    //{
                    //    u.Move();
                    //    u.Render();
                    //}
                    // display the values to the form or canvas
                    lb_lives.Text = "Lives : " + lives;
                    Canvas.AddText("Lives : " + lives, 12, 10, 10, 100, 100, Color.White);
                    lb_score.Text = "Score : " + score;
                    lb_kills.Text = "Kills : " + kills;
                    lb_incoming.Text = "Incoming : " + Enemy.Count;
                    lb_outcoming.Text = "Outcoming : " + User.Count;
                    Canvas.Render();
                }
                else
                {
                    Canvas.AddText("GAME OVER", 24, Color.White);
                    Canvas.Render();
                    pause = true;
                    bt_Start.Enabled = true;
                    timer.Enabled = false;
                }
            }
        }
        /// <summary>
        /// Method:     void start()
        /// Summary:    set and reset all of the game values and clear the canvas 
        ///             for a new game
        /// </summary>
        private void start()
        {
            //check if there is an open canvas
             if (Canvas != null)
                Canvas.Close();
            //create canvas
            Canvas = new CDrawer();
            //save the canvas to the class missle
            Missle.Setcanvas = Canvas;
            //clear the lists
            User = new List<Missle>();
            Enemy = new List<Missle>();
            bt_Start.Enabled = false;
            timer.Enabled = true;
            //clear the score
            score = 0;
            pause = false;
            bt_pause.Enabled = true;
            bt_reset.Enabled = true;
        }
    }
}
