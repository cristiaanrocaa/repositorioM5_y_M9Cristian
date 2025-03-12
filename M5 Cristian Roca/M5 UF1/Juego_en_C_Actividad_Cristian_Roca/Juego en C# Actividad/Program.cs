using System;
using System.Threading;

namespace Juego
{
    public class Personaje
    {
        public string Nombre { get; set; }
        public int Vida { get; set; }
        public int VidaMaxima { get; set; }
        public int Nivel { get; set; }
        public int PuntosDeHabilidad { get; set; }

        public Personaje(string nombre)
        {
            Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            VidaMaxima = 10;
            Vida = VidaMaxima;
            Nivel = 1;
            PuntosDeHabilidad = 0;
        }

        public virtual int TirarDados()
        {
            Random rand = new Random();
            return rand.Next(1, 7) + rand.Next(1, 7);  
        }

        public void RecibirDano(int dano)
        {
            Vida -= dano;
            if (Vida < 0)
                Vida = 0;
        }

        public void RecuperarVida(int cantidad)
        {
            Vida += cantidad;
            if (Vida > VidaMaxima)
                Vida = VidaMaxima;
            Console.WriteLine($"{Nombre} ha recuperado {cantidad} puntos de vida. Vida actual: {Vida}/{VidaMaxima}.");
        }

        public void SubirNivel()
        {
            Nivel++;
            VidaMaxima += 2;  // Incremento de la vida máxima al subir de nivel
            Console.WriteLine($"{Nombre} ha subido de nivel a {Nivel}. Vida máxima ahora es {VidaMaxima}.");
        }
    }

    public class Guerrero : Personaje
    {
        public Guerrero(string nombre) : base(nombre)
        {
            VidaMaxima = 12;
            Vida = VidaMaxima;
        }

        public override int TirarDados()
        {
            return base.TirarDados() + 2;  // El Guerrero tiene +2 puntos de ataque
        }

        public void Bloquear()
        {
            Console.WriteLine("¡El Guerrero ha bloqueado un ataque!");
        }
    }

    public class Mago : Personaje
    {
        public Mago(string nombre) : base(nombre)
        {
            VidaMaxima = 8;
            Vida = VidaMaxima;
        }

        public override int TirarDados()
        {
            return base.TirarDados() + 4;  // El Mago tiene +4 puntos de ataque
        }

        public void RegenerarVida()
        {
            Vida += 2;
            if (Vida > VidaMaxima)
                Vida = VidaMaxima;
            Console.WriteLine("¡El Mago ha recuperado 2 puntos de vida!");
        }
    }

    public class Arquero : Personaje
    {
        public Arquero(string nombre) : base(nombre)
        {
            VidaMaxima = 10;
            Vida = VidaMaxima;
        }

        public override int TirarDados()
        {
            return base.TirarDados() + 3;  // El Arquero tiene +3 puntos de ataque
        }

        public void DobleAtaque()
        {
            Console.WriteLine("¡El Arquero ha realizado un doble ataque!");
        }
    }

    public class Enemigo
    {
        public int Vida { get; set; }
        public int Nivel { get; set; }
        public int Resistencia { get; set; }
        public bool EsBoss { get; set; }

        public Enemigo(bool esBoss = false)
        {
            Random rand = new Random();
            EsBoss = esBoss;
            Vida = esBoss ? rand.Next(20, 50) : rand.Next(5, 13);  // Boss tiene más vida
            Nivel = esBoss ? 10 : rand.Next(0, 16);  // Boss es más fuerte
            Resistencia = esBoss ? 5 : rand.Next(0, 6);  // Boss tiene más resistencia
        }

        public int TirarDados()
        {
            Random rand = new Random();
            return rand.Next(1, 7) + rand.Next(1, 7);  
        }

        public void RecibirDano(int dano)
        {
            int danoFinal = Math.Max(dano - Resistencia, 0);  // Restar resistencia
            Vida -= danoFinal;
            if (Vida < 0)
                Vida = 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("¡Bienvenido al juego!");
            Thread.Sleep(1000);

            // Elección de personaje
            Console.WriteLine("Elige tu personaje:");
            Console.WriteLine("1. Guerrero");
            Console.WriteLine("2. Mago");
            Console.WriteLine("3. Arquero");
            int opcion = int.Parse(Console.ReadLine());

            Personaje jugador = null;
            switch (opcion)
            {
                case 1:
                    Console.WriteLine("Introduce el nombre del Guerrero:");
                    jugador = new Guerrero(Console.ReadLine());
                    break;
                case 2:
                    Console.WriteLine("Introduce el nombre del Mago:");
                    jugador = new Mago(Console.ReadLine());
                    break;
                case 3:
                    Console.WriteLine("Introduce el nombre del Arquero:");
                    jugador = new Arquero(Console.ReadLine());
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    return;
            }

            // Crear enemigo
            Enemigo enemigo = new Enemigo();
            Console.WriteLine($"¡Te enfrentas a un enemigo con {enemigo.Vida} puntos de vida y nivel {enemigo.Nivel}!");

            // Contador de rondas
            int ronda = 1;

            // Inicio del juego
            bool juegoActivo = true;
            while (juegoActivo)
            {
                Console.WriteLine($"\nRonda {ronda}");

                // Si es la ronda 10, aparecerá el boss
                if (ronda == 10)
                {
                    enemigo = new Enemigo(true);  // Crea un enemigo tipo boss
                    Console.WriteLine($"¡Te enfrentas a un Jefe con {enemigo.Vida} puntos de vida y nivel {enemigo.Nivel}!");
                }

                Console.WriteLine("\nEs tu turno:");
                Console.WriteLine("1. Atacar");
                Console.WriteLine("2. Tirar dados");
                Console.WriteLine("3. Salir");
                int accion = int.Parse(Console.ReadLine());

                switch (accion)
                {
                    case 1:
                        // Ataque del jugador
                        int danoJugador = jugador.TirarDados();
                        enemigo.RecibirDano(danoJugador);
                        Console.WriteLine($"¡Has causado {danoJugador} puntos de daño!");
                        Console.WriteLine($"El enemigo ahora tiene {enemigo.Vida} puntos de vida.");

                        // Ataque del enemigo
                        if (enemigo.Vida > 0)
                        {
                            int danoEnemigo = enemigo.TirarDados();
                            jugador.RecibirDano(danoEnemigo);
                            Console.WriteLine($"El enemigo te ha causado {danoEnemigo} puntos de daño.");
                            Console.WriteLine($"Tu vida ahora es {jugador.Vida}.");
                        }
                        break;

                    case 2:
                        Console.WriteLine($"Tiraste los dados y sacaste: {jugador.TirarDados()}.");
                        break;

                    case 3:
                        juegoActivo = false;
                        break;

                    default:
                        Console.WriteLine("Acción no válida.");
                        break;
                }

                if (enemigo.Vida <= 0)
                {
                    Console.WriteLine("¡Has derrotado al enemigo!");
                    jugador.RecuperarVida(5);  
                    jugador.SubirNivel();
                    enemigo = new Enemigo();  
                    Console.WriteLine($"Te enfrentas a un nuevo enemigo con {enemigo.Vida} puntos de vida.");
                }

                if (jugador.Vida <= 0)
                {
                    Console.WriteLine("¡Has sido derrotado!");
                    juegoActivo = false;
                }

                ronda++;  
                Thread.Sleep(1000);
            }

            Console.WriteLine("Juego terminado.");
        }
    }
}













