using System;
using System.Collections.Generic;

class Droide
{
    public string Nombre { get; set; }
    public string TipoUnidad { get; set; }
    public int NivelBateria { get; set; }

    public Droide(string nombre, string tipoUnidad, int nivelBateria)
    {
        Nombre = nombre;
        TipoUnidad = tipoUnidad;
        NivelBateria = nivelBateria;
    }

    public virtual void MostrarInformacion()
    {
        Console.WriteLine($"Nombre: {Nombre}, Tipo: {TipoUnidad}, Bateria: {NivelBateria}%");
    }
}

class DroideProtocolo : Droide
{
    public DroideProtocolo(string nombre, int nivelBateria)
        : base(nombre, "Protocolo", nivelBateria) { }

    public override void MostrarInformacion()
    {
        base.MostrarInformacion();
    }
}

class DroideAstromecánico : Droide
{
    public DateTime UltimaReparacion { get; set; }

    public DroideAstromecánico(string nombre, int nivelBateria, DateTime ultimaReparacion)
        : base(nombre, "Astromecánico", nivelBateria)
    {
        UltimaReparacion = ultimaReparacion;
    }

    public int RepararNaves()
    {
        Random random = new Random();
        return random.Next(1, 10); 
    }

    public override void MostrarInformacion()
    {
        base.MostrarInformacion();
        Console.WriteLine($"Última reparació: {UltimaReparacion}");
        Console.WriteLine($"Naus reparades: {RepararNaves()}");
    }
}

class DroideCombate : Droide
{
    public int NivelPotenciaFuego { get; set; }

    public DroideCombate(string nombre, int nivelBateria, int nivelPotenciaFuego)
        : base(nombre, "Combate", nivelBateria)
    {
        NivelPotenciaFuego = nivelPotenciaFuego;
    }

    public int ParticiparCombate()
    {
        Random random = new Random();
        return random.Next(1, 20); 
    }

    public override void MostrarInformacion()
    {
        base.MostrarInformacion();
        Console.WriteLine($"Potència de foc: {NivelPotenciaFuego}");
        Console.WriteLine($"Combats participats: {ParticiparCombate()}");
    }
}

class Program
{
    static void Main()
    {
        List<Droide> droides = new List<Droide>();

        while (true)
        {
            Console.WriteLine("1. Afegir droide");
            Console.WriteLine("2. Mostrar droides");
            Console.WriteLine("3. Sortir");
            int opcio = int.Parse(Console.ReadLine());


            if (opcio == 1)
            {
                Console.WriteLine("Introdueix el tipus de droide (Protocolo/Astromecanico/Combate): ");
                string tipus = Console.ReadLine().ToLower();


                Console.WriteLine("Introdueix el nom: ");
                string nom = Console.ReadLine();


                Console.WriteLine("Introdueix el nivell de bateria: ");
                int nivellBateria = int.Parse(Console.ReadLine());


                if (tipus == "protocolo")
                {
                    droides.Add(new DroideProtocolo(nom, nivellBateria));
                }

                else if (tipus == "astromecanico")
                {
                    Console.WriteLine("Introdueix la data de la última reparació (dd/mm/yyyy): ");
                    DateTime ultimaReparacio = DateTime.Parse(Console.ReadLine());
                    droides.Add(new DroideAstromecánico(nom, nivellBateria, ultimaReparacio));
                }

                else if (tipus == "combate")
                {
                    Console.WriteLine("Introdueix el nivell de potència de foc: ");
                    int nivellPotenciaFoc = int.Parse(Console.ReadLine());
                    droides.Add(new DroideCombate(nom, nivellBateria, nivellPotenciaFoc));
                }

                else
                {
                    Console.WriteLine("Tipus de droide no vàlid.");
                }


            }
            else if (opcio == 2)
            {
                foreach (Droide droide in droides)
                {
                    droide.MostrarInformacion();
                }

            }
            else if (opcio == 3)
            {
                break;
            }

            else
            {
                Console.WriteLine("Opció no vàlida.");
            }
        }
    }
}
