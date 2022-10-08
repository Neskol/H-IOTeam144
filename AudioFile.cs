using System;
using NAudio;
using NAudio.Wave;

namespace AudioCorrelation
{
    public class AudioFile : IAudioFile
    {
        private double length; //Time span is a system structure used to store time*
        private int sampleRates;
        private double interval = 50;
        private double sensitivity = 1;
        private double[]? dbs;
        private Mp3FileReader audioFile;

        /// <summary>
        /// Access the total length of the music file
        /// </summary>
        /// <returns></returns>
        public double Length
        {
            get
            {
                return this.Length;
            }
        }

        /// <summary>
        /// Access the sample rates of the music, normally 44100
        /// </summary>
        public int SampleRates
        {
            get
            {
                return this.sampleRates;
            }
        }

        /// <summary>
        /// Access the interval for us to evaluate otherwise 2ms will be too small.
        /// </summary>
        /// <return>Actual interval/Sample interval</return>
        public double Interval
        {
            get
            {
                return this.interval;
            }
            set
            {
                this.interval = value;
            }
        }

        /// <summary>
        /// The sensitivy for us to record maximum changes. Records in seconds
        /// </summary>
        public double Sensitivity
        {
            get
            {
                return this.sensitivity;
            }
            set
            {
                this.sensitivity = value;
            }
        }

        public AudioFile(string location,int sampleRates)
        {
            audioFile = new Mp3FileReader(location);
            length = audioFile.TotalTime.TotalSeconds;
            this.sampleRates = sampleRates;

            this.Update();
        }

        public double CalculateDbs(string segments)
        {
            throw new NotImplementedException();
        }

        public List<double> GetTimeStampList()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}