using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

using AudioCorrelation;

using NAudio;
using NAudio.Utils;
using NAudio.Wave;

AudioFile test = new AudioFile(@"C:\Users\Neskol\Documents\TestCases\044-リズと青い鳥 第三楽章「愛ゆえの決断」_01.mp3", 48000);
StreamWriter sw = new StreamWriter("../../../analyse.txt", false,System.Text.Encoding.Unicode);

AudioFile test2 = new AudioFile(@"C:\Users\Neskol\Documents\TestCases\Liz und ein BlauerVogel M3.mp3", 48000);
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