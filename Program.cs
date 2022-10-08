using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

using NAudio;
using NAudio.Utils;
using NAudio.Wave;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Mp3FileReader reader2 = new Mp3FileReader("/Users/Neskol/MaiAnalysis/Sound/music000834.mp3");
Console.WriteLine(reader2.TotalTime);
List<double> dbs = new List<double>();

WaveStream stream = reader2 as WaveStream;
Console.WriteLine(stream.WaveFormat);
using (Mp3FileReader reader = new Mp3FileReader("/Users/Neskol/MaiAnalysis/Sound/music000834.mp3"))
{
    byte[] buffer = new byte[4096];
    int bytesRead;
    int total = 0;
    int index = 0;
    int count = 0;
    int interval = 50;
    do
    {
        bytesRead = reader.Read(buffer, 0, buffer.Length);
        short sample32Bit = BitConverter.ToInt16(buffer, index);
        double volume = Math.Abs(sample32Bit / 32768.0);
        double decibels = 20 * Math.Log10(volume);
        if (count % interval ==0)
        {
            dbs.Add(Math.Abs(decibels));
        }
        total += bytesRead;
        count++;
    } while (bytesRead > 0);
    //Debug.WriteLine(String.Format("Read {0} bytes", total));
}

StreamWriter sw = new StreamWriter("../../../data/analyse.txt",false,System.Text.Encoding.Unicode);
foreach (double x in dbs)
{
    Console.WriteLine(x);
    sw.WriteLine(x);

}
sw.Close();
