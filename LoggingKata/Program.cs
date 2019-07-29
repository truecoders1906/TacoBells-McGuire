using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            logger.LogInfo("Log initialized");

            var lines = File.ReadAllLines(csvPath);

            logger.LogInfo($"Lines: {lines[0]}");

            var parser = new TacoParser();

            var locations = lines.Select(parser.Parse).ToArray();

            ITrackable TacoBell1 = null;
            ITrackable TacoBell2 = null;
            double distanceOfTwoFarthest = 0;

            foreach (ITrackable store in locations)
            {
                GeoCoordinate LocA = new GeoCoordinate(store.Location.Latitude, store.Location.Longitude);

                foreach (ITrackable store2 in locations)
                {
                    GeoCoordinate LocB = new GeoCoordinate(store.Location.Latitude, store.Location.Longitude);
                    double distanceBetweenCurrentStores = LocA.GetDistanceTo(LocB);
                    if (distanceBetweenCurrentStores > distanceOfTwoFarthest)
                    {
                        distanceOfTwoFarthest = distanceBetweenCurrentStores;
                        TacoBell1 = store;
                        TacoBell2 = store2;
                    }

                }
            }
        }
    }
}