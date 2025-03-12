//1

using System;
using System.Collections.Generic;

public class Empleado
{
    public string Nombre { get; set; }
    public string Cargo { get; set; }
    public decimal Salario { get; set; }

    public Empleado(string nombre, string cargo, decimal salario)
    {
        Nombre = nombre;
        Cargo = cargo;
        Salario = salario;
    }
}

public class Tarea
{
    public string Nombre { get; set; }
    public string Estado { get; set; } 
    public string Descripcion { get; set; }

    public Tarea(string nombre, string estado, string descripcion)
    {
        Nombre = nombre;
        Estado = estado;
        Descripcion = descripcion;
    }
}

public class Proyecto
{
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public int DiasRestantes { get; set; }
    public List<Empleado> EmpleadosAsignados { get; set; }
    public List<Tarea> Tareas { get; set; }
    public decimal CostoPorDia { get; set; }
    public string EstadoActual { get; set; } 

    public Proyecto(string nombre, string descripcion, int diasRestantes, decimal costoPorDia)
    {
        Nombre = nombre;
        Descripcion = descripcion;
        DiasRestantes = diasRestantes;
        CostoPorDia = costoPorDia;
        EmpleadosAsignados = new List<Empleado>();
        Tareas = new List<Tarea>();
        EstadoActual = "En progreso";
    }

    public decimal CostoEstimado()
    {
        return DiasRestantes * CostoPorDia;
    }
}



//2


public class Persona
{
    public string Nombre { get; set; }
    public string DNI { get; set; }

    public Persona(string nombre, string dni)
    {
        Nombre = nombre;
        DNI = dni;
    }
}

