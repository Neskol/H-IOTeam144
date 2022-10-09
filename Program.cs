using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

using AudioCorrelation;

using NAudio;
using NAudio.Utils;
using NAudio.Wave;

AudioFile test = new AudioFile(@"C:\Users\Neskol\Music\Brandenburg Concerto II in F major, BWV1047 For Woodwinds.mp3", 44100);
Console.WriteLine(test.Length);
Console.WriteLine(test.Interval);
Console.WriteLine(test.Sensitivity);
Console.WriteLine(test.ControlPoints.Count);
