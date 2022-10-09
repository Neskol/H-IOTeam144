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
        /// <values>Each of the elements double in list is the time stamp of control points</values>
        /// <returns>A list <Dbs> which time is in seconds, dbs is the volume in dbs</returns>
        List<double> GetTimeStampList();

        /// <summary>
        /// Updates the Audio file and build up entities for compiling
        /// </summary>
        void Update();

        /// <summary>
        /// Calculates the volume of given segment of audio file
        /// </summary>
        /// <param name="buffer">The segment of the music to calculate on</param>
        /// <returns>The volume of corresponding music segment in db</returns>
        double CalculateDbs(byte[] buffer);
    }
}