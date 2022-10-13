using System;
using OdczytDanych.entities;

namespace OdczytDanych
{
    public class Odczytzpliku
    {
        public static void odczytajZPliku(string path)
        {
           using(var db = new PgsqlDbContext())
            {
                string[] fileLines = File.ReadAllLines(path);
                MyDatabaseOperation databaseOperation = new MyDatabaseOperation(db);
                foreach(string line in fileLines)
                {
                    databaseOperation.zapiszdobazy(ConwertTableToTemperatura.konwertuj(line.Split(';')));

                }
            }
            
        }
    }
}

