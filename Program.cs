using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

using AudioCorrelation;

using NAudio;
using NAudio.Utils;
using NAudio.Wave;

Console.WriteLine("Input the source file you will be referencing on");
string input1 = "";
input1 = Console.ReadLine();
Console.WriteLine("Input the test file you will be testing on");
string input2 = "";
input2 = Console.ReadLine();


AudioFile test = new AudioFile(input1, 44100);
StreamWriter sw = new StreamWriter("../../../analyse.txt", false,System.Text.Encoding.Unicode);

AudioFile test2 = new AudioFile(input2, 44100);
StreamWriter sw2= new StreamWriter("../../../analyse2.txt", false, System.Text.Encoding.Unicode);

string intro = "Control point generated for Source File (in seconds):";

string header1 = "File Name (Source): "+input1+"\n"+"Has duration of "+test.Length+"\n"+intro;
Console.WriteLine(header1);
sw.WriteLine(header1);
int count = 0;
foreach (double x in test.ControlPoints)
{
    sw.WriteLine(count + "\t" +x);
    Console.WriteLine(count + "\t" + x);
    count++;
}

count = 0;
string header2 = "File Name (Source): " + input2 + "\n" + "Has duration of " + test.Length + "\n" + intro;
Console.WriteLine(header2);
sw2.WriteLine(header2); foreach (double x in test2.ControlPoints)
{
    sw2.WriteLine(count + "\t" + x);
    Console.WriteLine(count + "\t" + x);
    count++;
}

Console.WriteLine("And the test result is generated into the project file directory");
sw.Close();
sw2.Close();