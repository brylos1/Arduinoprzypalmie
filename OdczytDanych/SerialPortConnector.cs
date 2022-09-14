using System;
using System.IO.Ports;

namespace OdczytDanych
{
    public class SerialPortConnector
    {
        SerialPort serialPort;
        public SerialPortConnector(string portName, int baund)
        {
            serialPort = new SerialPort(portName, baund);
            try
            {
                serialPort.Open();
            }
            catch
            {
                Console.WriteLine("Nie udało się połączyć z arduino");
            }
        }
        public string readline()
        {
            return serialPort.ReadLine();
        }
        public string[] readtable()
        {
            string read = serialPort.ReadLine();
            Console.WriteLine(read);
            return read.Split(';');
        }

    }
}

