using System;
namespace TemperaturyAPI.Models
{
    public class DaneZPalmyModel
    {
        public Int64 ID { get; set; }
        public DateTime DataPomiaru { get; set; }
        public float TemperaturaGleby { get; set; }
        public float TemperaturaPowietrza { get; set; }
        public bool CzyGrzanieZalaczone { get; set; }
    }
}

