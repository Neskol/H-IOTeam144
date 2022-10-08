using System;
using NAudio;
using NAudio.Wave;

namespace AudioCorrelation
{
    public class AudioFile : IAudioFile
    {
        private TimeSpan length; //Time span is a system structure used to store time*
        private int samples;
        private double[]? dbs;
        private Mp3FileReader audioFile;

        public AudioFile(string location,int samples)
        {
            audioFile = new Mp3FileReader(location);
            length = audioFile.TotalTime;
            this.Update();
        }

        public double CalculateDbs(string segments)
        {
            throw new NotImplementedException();
        }

        public Dictionary<double, double> GetTimeStamp()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}