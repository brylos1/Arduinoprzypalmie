using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace OdczytDanych.entities
{
    public class Temperatury
    {
        public Int64 ID { get; set; }
        [Column(TypeName = "timestamp without time zone")]
        public DateTime DataPomiaru { get; set; }
        public float TemperaturaGleby { get; set; }
        public float TemperaturaPowietrza { get; set; }
        public bool CzyGrzanieZalaczone { get; set; }
    }
}

