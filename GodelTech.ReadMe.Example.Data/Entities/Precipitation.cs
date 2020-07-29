using System;

namespace GodelTech.ReadMe.Example.Data.Entities
{
    public class Precipitation
    {
        public int Id { get; set; }

        public string Town { get; set; }

        public DateTime DateTime { get; set; }

        public int Temperature { get; set; }

        public string Summary { get; set; }

        public int PrecipitationTypeId { get; set; }

        public PrecipitationType PrecipitationType { get; set; }
    }
}