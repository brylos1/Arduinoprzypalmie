using System;
using Microsoft.EntityFrameworkCore;

namespace TemperaturyAPI.Models
{
    [Keyless]
    public class MinMaxModel
    {
        public DateOnly DataPomiaru { get; set; }
        public double MinimalnaTemperaturaGleby { get; set; }
        public double MaksymalnaTemperaturaGleby { get; set; }
        public double MinimalnaTemperaturaPowietrza { get; set; }
        public double MaksymalnaTemperaturaPowietrza { get; set; }
    }
}

