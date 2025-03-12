using System;

internal class Programa
{
    static void Main()
    {
        NaveEstelar naveBasica = new NaveEstelar();
        naveBasica.Activar();
        naveBasica.EjecutarMision();
        naveBasica.Desactivar();

        Console.WriteLine();

        NaveCombate naveCombate = new NaveCombate();
        naveCombate.Activar();
        naveCombate.Atacar();
        naveCombate.Desactivar();

        Console.WriteLine();

        NaveCarga naveCarga = new NaveCarga(2500); 
        naveCarga.Activar();
        naveCarga.Atacar();
        naveCarga.EjecutarDefensaEspecial();
        naveCarga.MostrarCarga();
        naveCarga.Desactivar();
    }
}
class NaveEstelar
{
    public virtual void Activar()
    {
        Console.WriteLine("La nave estelar básica ha activado sus sistemas.");
    }

    public virtual void EjecutarMision()
    {
        Console.WriteLine("La nave estelar básica está realizando una misión de exploración.");
    }

    public virtual void Desactivar()
    {
        Console.WriteLine("La nave estelar básica ha apagado sus sistemas.");
    }
}
class NaveCombate : NaveEstelar
{
    public int PotenciaFuego { get; set; } = 7;

    public NaveCombate() : base() 
    {
    }

    public override void Activar()
    {
        Console.WriteLine("La nave de combate ha activado sus sistemas de combate.");
    }

    public virtual void Atacar()
    {
        Console.WriteLine($"La nave de combate está atacando con potencia de fuego nivel {PotenciaFuego}.");
    }

    public override void Desactivar()
    {
        Console.WriteLine("La nave de combate ha apagado sus sistemas.");
    }
}
class NaveCarga : NaveCombate
{
    public int Carga { get; set; }

    public NaveCarga(int carga) :base()
    {
        Carga = carga;
        PotenciaFuego = 10; 
    }

    public override void Atacar()
    {
        Console.WriteLine($"La nave de carga especializada está atacando con potencia de fuego nivel {PotenciaFuego}.");
    }

    public void EjecutarDefensaEspecial()
    {
        Console.WriteLine("La nave de carga especializada está defendiendo el espacio alrededor del planeta X.");
    }

    public void MostrarCarga()
    {
        Console.WriteLine($"La nave de carga lleva una cantidad de carga de {Carga} Kg.");
    }

    public override void Desactivar()
    {
        Console.WriteLine("La nave de carga especializada ha apagado sus sistemas.");
    }
}
