namespace ROsTorvApp.Model.Center
{
    internal class Center
    {
        public string CenterName { get; set; }
        public string OpeningHoursStart { get; set; }
        public string OpeningHoursEnd { get; set; }

        public Center(string centerName, string openingHoursStart, string openingHoursEnd)
        {
            CenterName = centerName;
            OpeningHoursStart = openingHoursStart;
            OpeningHoursEnd = openingHoursEnd;
        }

        public override string ToString()
        {
            return $"{CenterName} Har åbent fra {OpeningHoursStart} til {OpeningHoursEnd}.";
        }
    }
}