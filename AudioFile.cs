using System;
using System.Reflection.PortableExecutable;

using NAudio;
using NAudio.Wave;

namespace AudioCorrelation
{
    public class AudioFile /*: IAudioFile*/
    {
        private double length;
        private int sampleRates;
        private int interval = 5;
        private double sensitivity = 10;
        public List<double> volumesList = new();
        private List<double> rawInputPoints;
        private Dictionary<double,double> samplePoints;
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
                return this.length;
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
        public int Interval
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
        public Dictionary<double,double> SamplePoints
        {
            get { return this.samplePoints; }
            set
            {
                this.samplePoints = value;
            }
        }

        /// <summary>
        /// Access to the raw sample points from the music
        /// </summary>
        public List<double> RawPoints
        {
            get { return this.rawInputPoints; }
            set
            {
                this.rawInputPoints = value;
            }
        }

        /// <summary>
        /// Access to the final control points we will output later
        /// </summary>
        public List<double> ControlPoints
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
            this.length = audioFile.TotalTime.TotalSeconds;
            this.sampleRates = sampleRates;
            this.rawInputPoints = new List<double>();
            this.samplePoints = new Dictionary<double,double>();
            this.volumesList = new();
            this.controlPoints = new List<double>();
            this.Update();
        }

        public double CalculateDbs(byte[] buffer)
        {
            int START_INDEX = 0;
            const double TWO_POW_16 = 32768.0;
            short bitNum = BitConverter.ToInt16(buffer, START_INDEX);
            double volume = Math.Abs(bitNum / TWO_POW_16);
            double decibels = 20 * Math.Log10(volume);
            if (double.IsInfinity(decibels))
            {
                decibels = double.MaxValue - 1;
            }
            return decibels;
        }

        public double CalculateVolumes(byte[] buffer)
        {
            int START_INDEX = 0;
            const double TWO_POW_16 = 32768.0;
            short bitNum = BitConverter.ToInt16(buffer, START_INDEX);
            double volume = Math.Abs(bitNum / TWO_POW_16);
            return volume;
        }

        public List<double> GetTimeStampList()
        {
            //for(int i = 0; i < SamplePoints.Count/Sensitivity; i++){
            //    double max = 0.0;
            //    double timeOfMax = 0.0;
            //    for(int j = 0; j < Sensitivity; j++){
            //        double val = (samplePoints[i + j + 1]) - samplePoints[i + j];
            //        double time = (10*i + j) * (1000.0 / sampleRates) * interval*sensitivity;
            //        double result =val/100;
            //        if(max <= result){
            //            max = result;
            //            timeOfMax = time;
            //        } 
            //    }
            //    controlPoints.Add(timeOfMax);
            //    max = 0.0;
            //    timeOfMax = 0.0;
            //}

            foreach(KeyValuePair<double,double>p in this.SamplePoints)
            {
                this.controlPoints.Add(p.Key);
            }
            return controlPoints;
        }

        public void Update()
        {
            byte[] buffer = new byte[4096];
            int bytesRead;
            int total = 0;
            int count = 0;
            int interval = this.Interval;
            this.SamplePoints = new();
            do
            {
                bytesRead = this.audioFile.Read(buffer, 0, buffer.Length);
                double calculatedDb = Math.Abs(CalculateDbs(buffer));
                this.rawInputPoints.Add(calculatedDb);
                this.volumesList.Add(CalculateVolumes(buffer));
                if (count % interval == 0)
                {
                    this.SamplePoints.Add(count*(1000.0/sampleRates),CalculateVolumes(buffer));
                }
                total += bytesRead;
                count++;
            } while (bytesRead > 0);
            //Debug.WriteLine(String.Format("Read {0} bytes", total));
            //Console.WriteLine("Total Raw Points: "+ this.rawInputPoints.Count);
            //Console.WriteLine("Total Sample Points: " + this.samplePoints.Count);
            this.GetTimeStampList();
        }
    }
}