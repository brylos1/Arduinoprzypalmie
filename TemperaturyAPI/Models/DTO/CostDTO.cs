using System;
using Microsoft.EntityFrameworkCore;

namespace TemperaturyAPI.Models.DTO
{
    [Keyless]
    public class CostDTO
    {
        public float costEnergy { get; set; }
        public float usedEnergy { set; get; }
        public int minuty { get; set; }
        public float godziny { get; set; }
    }
}

