using System;
using NAudio;
using NAudio.Wave;

namespace AudioCorrelation
{
    public class AudioFile : IAudioFile
    {
        private double length;
        private int sampleRates;
        private double interval = 50;
        private double sensitivity = 1;
        private List<double> samplePoints;
        private List<double> controlPoints;
        private Mp3FileReader audioFile;

        /// <summary>
        /// Access the total length of the music file in seconds
        /// </summary>
        /// <returns>Total seconds of the music</returns>
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
        
        /// <summary>
        /// Access to the sample points we resampled from the music
        /// </summary>
        public List<double> SamplePoints
        {
            get { return this.samplePoints; }
            set
            {
                this.samplePoints = value;
            }
        }

        /// <summary>
        /// Access to the final control points we will output later
        /// </summary>
        public List <double> ControlPoints
        {
            get { return this.controlPoints; }
            set
            {
                this.controlPoints = value;
            }
        }

        public AudioFile(string location,int sampleRates)
        {
            audioFile = new Mp3FileReader(location);
            length = audioFile.TotalTime.TotalSeconds;
            this.sampleRates = sampleRates;
            this.samplePoints = new List<double>();
            this.controlPoints = new List<double>();
            this.Update();
        }

        public double CalculateDbs(byte[] buffer)
        {
            const int START_INDEX = 0;
            const double TWO_POW_16 = 32768.0;
            short bitNum = BitConverter.ToInt16(buffer, START_INDEX);
            double volume = Math.Abs(bitNum / TWO_POW_16);
            double decibels = 20 * Math.Log10(volume);
            return decibels;
        }

        public List<double> GetTimeStampList()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            this.GetTimeStampList();
        }
    }
}