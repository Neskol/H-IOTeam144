using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

using AudioCorrelation;

using NAudio;
using NAudio.Utils;
using NAudio.Wave;

AudioFile test = new AudioFile(@"C:\Users\Neskol\Documents\BWV1047_02.mp3", 48000);
StreamWriter sw = new StreamWriter("../../../analyse.txt", false,System.Text.Encoding.Unicode);

AudioFile test2 = new AudioFile(@"C:\Users\Neskol\Documents\BWV1047_01.mp3", 48000);
StreamWriter sw2= new StreamWriter("../../../analyse2.txt", false, System.Text.Encoding.Unicode);


foreach (double x in test.ControlPoints)
{
    sw.WriteLine(x);
    
}

foreach (double x in test2.ControlPoints)
{
    sw2.WriteLine(x);

}
sw.Close();
sw2.Close();