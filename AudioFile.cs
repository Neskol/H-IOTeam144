using System;
using NAudio;
using NAudio.Wave;

namespace AudioCorrelation
{
    public class AudioFile : IAudioFile
    {
        private double length;
        private int samples;
        private double[]? dbs;
        private AudioFileReader audioFile;

        public AudioFile(string location,int samples)
        {
            audioFile = new AudioFileReader(location);
            length = audioFile.Length;
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