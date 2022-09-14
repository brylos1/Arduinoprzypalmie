using System;
using System.Globalization;
using OdczytDanych.entities;

namespace OdczytDanych
{
    public class ConwertTableToTemperatura
    {
      public static Temperatury konwertuj(string[] danedokonwersji)
        {
            Temperatury temperatury = new Temperatury();
            temperatury.DataPomiaru = DateTime.Parse(danedokonwersji[0]);
            string glebastr = danedokonwersji[1];
            if (Single.TryParse(glebastr, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out float gleba))
                temperatury.TemperaturaGleby = gleba;
            else
                Console.WriteLine("Unable to parse '{0}'.", danedokonwersji[1]);
            if (Single.TryParse(danedokonwersji[2], NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out float powietrze))
                temperatury.TemperaturaPowietrza = powietrze;
            else
                Console.WriteLine("Unable to parse '{0}'.", danedokonwersji[2]);
            temperatury.CzyGrzanieZalaczone = Convert.ToBoolean(int.Parse(danedokonwersji[3]));
            return temperatury;
        }
    }
}

