namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();

        public ITrackable Parse(string line)
        {
            var cells = line.Split(',');
            if (cells.Length < 3) return null;

            string latitude = cells[0];
            string longitude = cells[1];
            string name = cells[2];

            double latitudeAsADouble = double.Parse(latitude);
            double longitudeAsADouble = double.Parse(longitude);

            return null; // TODO Implement
        }
    }
    public class TacoBell : ITrackable
    {
        public string Name { get; set; }
        public Point Location { get; set; }
    }
}