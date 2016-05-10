#include <MadgwickAHRS.h>
#include <Servo.h>
#include "SparkFunLSM6DS3.h"
#include "Wire.h"
#include "SPI.h"

LSM6DS3 minj(I2C_MODE,0x6B);
Madgwick filter;
Servo one;
Servo two;
Servo three;

float alpha,roll,pitch,yaw,oldyaw,absoluteChange;
float rollValues[16];
float pitchValues[16];
float aX,aY,aZ,a2X,a2Y,a2Z;
float gX,gY,gZ,g2X,g2Y,g2Z;
int arrayIndex;
void setup() {
  Serial.begin(9600);
  delay(1000); //relax...
  Serial.println("Program Reset. All good to go.\n");
  InitSensor();
  delay(100);
  one.attach(10);//yaw motor
  two.attach(9);//roll motor
  three.attach(8);//pitch motor
  delay(100);
  //initialize values
  roll = pitch = yaw = 0;
  oldyaw = 0;
  alpha = 0.99;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     ;
  absoluteChange = 0;
  arrayIndex = 0;
}
void loop()
{
  //Get all parameters
  a2X = minj.readFloatAccelX();
  a2Y = minj.readFloatAccelY();
  a2Z = minj.readFloatAccelZ();
  g2X = minj.readFloatGyroX();
  g2Y = minj.readFloatGyroY();
  g2Z = minj.readFloatGyroZ();

  //account for gyro offsets
  g2Z = g2Z + 1.58;
  g2X = g2X - 0.45;
  g2Y = g2Y + 1.54;

  FilterSignals();
  filter.updateIMU(gX, gY, gZ, aX,aY,aZ);
  roll = ToDegrees(atan2(-aY,aZ));
  pitch = ToDegrees(atan2(aX, sqrt(aY*aY + aZ*aZ)));
  //roll = GetAvg(rollValues, roll, arrayIndex);
  //pitch = GetAvg(pitchValues, pitch, arrayIndex);
  //pitch = ToDegrees(filter.getPitch());
  yaw = ToDegrees(filter.getYaw());
  if((yaw - oldyaw < 90 && yaw - oldyaw >= 0.5) || (yaw - oldyaw > -90 && yaw - oldyaw <= -0.5))
  {
    absoluteChange = absoluteChange + yaw - oldyaw;
    if(absoluteChange > 0 && absoluteChange < 180)
    {
      one.write(absoluteChange);
      Serial.print("Yaw: ");
      Serial.println(absoluteChange);
    }
  }
  two.write(roll + 90);
  three.write(pitch + 90);
  oldyaw = yaw;
  ++arrayIndex;
  Serial.print("Roll: ");
  Serial.println(roll);
   Serial.print("Pitch: ");
  Serial.println(pitch);
}
void FilterSignals()
{
  aX = alpha * a2X + (1-alpha) * aX;
  aY = alpha * a2Y + (1-alpha) * aY;
  aZ = alpha * a2Z + (1-alpha) * aZ;
  gX = alpha * g2X + (1-alpha) * gX;
  gY = alpha * g2Y + (1-alpha) * gY;
  gZ = alpha * g2Z + (1-alpha) * gZ;
}
float ToDegrees(float rads)
{
  return rads * 180 / PI;
}
float GetAvg(float arr[], float newVal, int counter)
{
  float avg = 0;
  if(counter >= 16)
  {
    counter = 0;
    ShuffleArr(arr);
    arr[sizeof(arr)] = newVal;
  }
  else
    arr[counter] = newVal;
  for(int i = 0; i < sizeof(arr); ++i)
    avg += arr[i];
  return avg / sizeof(arr);
}
void ShuffleArr(float arr[])
{
  for(int i = 0; i < sizeof(arr) - 1; ++i)
    arr[i] = arr[i+1];
}
void InitSensor()
{
  minj.begin();
  minj.settings.accelSampleRate = 13;
  minj.settings.accelBandWidth = 50;
  minj.settings.accelRange = 4;
  minj.settings.gyroSampleRate = 13;
  minj.settings.gyroBandWidth = 50;
  minj.settings.gyroRange = 1000;
  minj.settings.gyroFifoEnabled = 0;
  minj.settings.gyroFifoDecimation = 0;
}

