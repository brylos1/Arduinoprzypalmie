using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using OdczytDanych;
using OdczytDanych.entities;
namespace MyApp 
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            Console.WriteLine("Wybierz tryb pracy: 1-plik 2-serial port");
            byte tryb = Byte.Parse( Console.ReadLine());
            switch (tryb)
            {
                case 1 :
                    Console.WriteLine("Podaj ścieszke do pliku");
                    string path = Console.ReadLine();
                    Odczytzpliku.odczytajZPliku(path);
                    break;

                case 2:
                    Console.WriteLine("Podaj nazwe portu szeregowego");
                    string port = Console.ReadLine();
                    Console.WriteLine("Podaj numer baund");
                    int baund = int.Parse(Console.ReadLine());
                    SerialPortConnector serialPortConnector = new SerialPortConnector(port, baund);
                    PgsqlDbContext context = new PgsqlDbContext();
                    if (context.Database.CanConnect())
                    {
                        Console.WriteLine("połączono z bazą danych");
                    }
                    else
                    {
                        Console.WriteLine("nie połączono z bazą danych");
                        break;
                    }
                    MyDatabaseOperation database = new MyDatabaseOperation(context);
                    while (true)
                    {
                        try
                        {
                            database.zapiszdobazy(ConwertTableToTemperatura.konwertuj(serialPortConnector.readtable()));
                        }
                        catch(Exception e)
                        {
                            Console.Write(e);
                            Thread.Sleep(1000);
                        }

                    }
                    break;

                default:
                    break;

            
            }

        }
    }
}