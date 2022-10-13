using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace TemperaturyAPI.Models
{
    [Keyless]
    public class SrednieTemperaturyModel
    {
        public DateOnly DataPomiaru { get; set; }
        public double SredniaGleby { get; set; }
        public double SredniaPowietrza { get; set; }
    }
    
}

