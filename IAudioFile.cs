using System;
namespace AudioCorrelation
{
    /// <summary>
    /// This is the interface of Audio file which provides necessary methods
    /// </summary>
    interface IAudioFile
    {
        /// <summary>
        /// Returns the dictionary of the time stamps of control points
        /// </summary>
        /// <returns>A dictionary of <Time,Dbs> which time is in seconds, dbs is the volume in dbs</returns>
        Dictionary<double, double> GetTimeStamp();

        /// <summary>
        /// Updates the Audio file and build up entities for compiling
        /// </summary>
        void Update();

        /// <summary>
        /// Calculates the volume of given segment of audio file
        /// </summary>
        /// <param name="segments">The segment of the music to calculate on</param>
        /// <returns>The volume of corresponding music segment in db</returns>
        double CalculateDbs(string segments);
    }
}