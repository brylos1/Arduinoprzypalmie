using System;
using Microsoft.EntityFrameworkCore;

namespace TemperaturyAPI.Models
{
    [Keyless]
    public class MinMaxModel
    {
        public DateOnly DataPomiaru { get; set; }
        public float MinimalnaTemperaturaGleby { get; set; }
        public float MaksymalnaTemperaturaGleby { get; set; }
        public float MinimalnaTemperaturaPowietrza { get; set; }
        public float MaksymalnaTemperaturaPowietrza { get; set; }
    }
}

