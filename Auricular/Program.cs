using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Pipes;
using Biblio;
using System.Windows;

namespace Auricular
{
    class Program
    {
        
        
        static void Main(string[] args)
        {
            String mensaje;
            //Conexion pipe entre padre y Auricular
            NamedPipeServerStream serverStream = new NamedPipeServerStream("pipe", PipeDirection.Out);
            StreamWriter sw = new StreamWriter(serverStream);
            serverStream.WaitForConnection();

            //Conexion pipe entre mi auricular y microfono de Kevin
            NamedPipeClientStream clientStream = new NamedPipeClientStream("192.168.37.171", "microfono_auricular", PipeDirection.In);
            StreamReader sr = new StreamReader(clientStream);
            clientStream.Connect();
            mensaje = sr.ReadLine();
            while (mensaje.ToLower().CompareTo("fin") != 0)
            {
                Console.WriteLine(mensaje);
                sw.WriteLine(mensaje);
                sr.ReadLine();
                
            }
        }
        
    }
}
