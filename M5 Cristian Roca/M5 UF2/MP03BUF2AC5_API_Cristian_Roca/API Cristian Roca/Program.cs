using System;
using System.Collections.Generic;
using System.Linq;

public class Api<T>
{
    private List<T> elementos;
    
    public Api()
    {
        elementos = new List<T>();
    }
    
    public void AgregarElemento(T elemento)
    {
        elementos.Add(elemento);
    }
    
    public void EliminarElemento(int indice)
    {
        if (indice >= 0 && indice < elementos.Count)
        {
            elementos.RemoveAt(indice);
        }
        else
        {
            Console.WriteLine("Índice fuera de rango");
        }
    }
    
    public T ObtenerElemento(int indice)
    {
        if (indice >= 0 && indice < elementos.Count)
        {
            return elementos[indice];
        }
        else
        {
            Console.WriteLine("Índice fuera de rango");
            return default(T);
        }
    }
    
    public void ActualizarElemento(int indice, T nuevoElemento)
    {
        if (indice >= 0 && indice < elementos.Count)
        {
            elementos[indice] = nuevoElemento;
        }
        else
        {
            Console.WriteLine("Índice fuera de rango");
        }
    }
    
    public List<T> BuscarElementos(Func<T, bool> criterio)
    {
        return elementos.Where(criterio).ToList();
    }
    
    public void MostrarElementos()
    {
        foreach (var elemento in elementos)
        {
            Console.WriteLine(elemento.ToString());
        }
    }
}

public class Persona
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public Persona(int id, string name)
    {
        Id = id;
        Name = name;
    }
    
    public override string ToString()
    {
        return $"ID: {Id}, Nombre: {Name}";
    }
}

public class Producto : Persona
{
    public double Precio { get; set; }
    
    public Producto(int id, string name, double precio) : base(id, name)
    {
        Precio = precio;
    }
    
    public override string ToString()
    {
        return base.ToString() + $", Precio: {Precio}";
    }
}

public class Cliente : Persona
{
    public string Email { get; set; }
    
    public Cliente(int id, string name, string email) : base(id, name)
    {
        Email = email;
    }
    
    public override string ToString()
    {
        return base.ToString() + $", Email: {Email}";
    }
}

public class Empleado : Persona
{
    public string Puesto { get; set; }
    
    public Empleado(int id, string name, string puesto) : base(id, name)
    {
        Puesto = puesto;
    }
    
    public override string ToString()
    {
        return base.ToString() + $", Puesto: {Puesto}";
    }
}

class Program
{
    static void Main()
    {
        Api<Producto> apiProductos = new Api<Producto>();
        apiProductos.AgregarElemento(new Producto(1, "Laptop", 1000));
        apiProductos.AgregarElemento(new Producto(2, "Mouse", 25));
        apiProductos.MostrarElementos();
        
        Api<Cliente> apiClientes = new Api<Cliente>();
        apiClientes.AgregarElemento(new Cliente(1, "Cristian Roca", "cristian.roc30@gmail.com"));
        apiClientes.MostrarElementos();
        
        Api<Empleado> apiEmpleados = new Api<Empleado>();
        apiEmpleados.AgregarElemento(new Empleado(1, "aaron", "empleado"));
        apiEmpleados.MostrarElementos();
    }
}
