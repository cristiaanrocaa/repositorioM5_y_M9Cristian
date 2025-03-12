using System;
using System.Collections.Generic;

// Clase Videojuego
class Videojuego {
    public string Titulo { get; private set; }
    public int AnoLanzamiento { get; private set; }
    public string Tematica { get; private set; }
    public string Estudio { get; private set; }
    public int VecesAlquilado { get; private set; }

    public Videojuego(string titulo, int anoLanzamiento, string tematica, string estudio) {
        Titulo = titulo;
        AnoLanzamiento = anoLanzamiento;
        Tematica = tematica;
        Estudio = estudio;
        VecesAlquilado = 0;
    }

    public void IncrementarAlquiler() {
        VecesAlquilado++;
    }

    public override string ToString() {
        return $"{Titulo} ({AnoLanzamiento}) - {Tematica}, {Estudio}, Alquilado {VecesAlquilado} veces";
    }
}

// Clase Persona
class Persona {
    public string Nombre { get; private set; }
    public string Apellido { get; private set; }
    public int Edad { get; private set; }
    public string Direccion { get; private set; }
    public string Telefono { get; private set; }

    public Persona(string nombre, string apellido, int edad, string direccion, string telefono) {
        Nombre = nombre;
        Apellido = apellido;
        Edad = edad;
        Direccion = direccion;
        Telefono = telefono;
    }

    public override string ToString() {
        return $"{Nombre} {Apellido}, {Edad} años, {Direccion}, Tel: {Telefono}";
    }
}

// Clase Cliente
class Cliente : Persona {
    private List<Videojuego> juegosAlquilados;

    public Cliente(string nombre, string apellido, int edad, string direccion, string telefono)
        : base(nombre, apellido, edad, direccion, telefono) {
        juegosAlquilados = new List<Videojuego>();
    }

    public void AlquilarJuego(Videojuego juego) {
        juegosAlquilados.Add(juego);
        juego.IncrementarAlquiler();
    }

    public List<Videojuego> GetJuegosAlquilados() {
        return juegosAlquilados;
    }

    public override string ToString() {
        return base.ToString() + $", Juegos alquilados: {juegosAlquilados.Count}";
    }
}

// Clase Empleado
class Empleado : Persona {
    public string Categoria { get; private set; }
    public double Salario { get; private set; }

    public Empleado(string nombre, string apellido, int edad, string direccion, string telefono, string categoria, double salario)
        : base(nombre, apellido, edad, direccion, telefono) {
        Categoria = categoria;
        Salario = salario;
    }

    public override string ToString() {
        return base.ToString() + $", Categoría: {Categoria}, Salario: {Salario}";
    }
}

// Clase principal SistemaAlquiler
class SistemaAlquiler {
    private List<Videojuego> videojuegos;
    private List<Cliente> clientes;
    private List<Empleado> empleados;

    public SistemaAlquiler() {
        videojuegos = new List<Videojuego>();
        clientes = new List<Cliente>();
        empleados = new List<Empleado>();
    }

    public void AltaVideojuego(Videojuego videojuego) {
        videojuegos.Add(videojuego);
    }

    public void BajaVideojuego(string titulo) {
        videojuegos.RemoveAll(v => v.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));
    }

    public void ListarVideojuegosDisponibles() {
        Console.WriteLine("Videojuegos disponibles:");
        foreach (var v in videojuegos) {
            Console.WriteLine(v);
        }
    }

    public void AltaCliente(Cliente cliente) {
        clientes.Add(cliente);
    }

    public void BajaCliente(string nombre, string apellido) {
        clientes.RemoveAll(c => c.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase) && c.Apellido.Equals(apellido, StringComparison.OrdinalIgnoreCase));
    }

    public void ListarUsuariosConJuegosPrestados() {
        Console.WriteLine("Usuarios con juegos prestados:");
        foreach (var c in clientes) {
            if (c.GetJuegosAlquilados().Count > 0) {
                Console.WriteLine(c);
            }
        }
    }

    public void AltaEmpleado(Empleado empleado) {
        empleados.Add(empleado);
    }

    public void BajaEmpleado(string nombre, string apellido) {
        empleados.RemoveAll(e => e.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase) && e.Apellido.Equals(apellido, StringComparison.OrdinalIgnoreCase));
    }

    public static void Main(string[] args) {
        SistemaAlquiler sistema = new SistemaAlquiler();

        // Crear videojuegos
        Videojuego v1 = new Videojuego("The Last of Us", 2013, "Acción", "Naughty Dog");
        Videojuego v2 = new Videojuego("God of War", 2018, "Aventura", "Santa Monica Studio");

        // Alta de videojuegos
        sistema.AltaVideojuego(v1);
        sistema.AltaVideojuego(v2);

        // Crear cliente
        Cliente c1 = new Cliente("Juan", "Pérez", 30, "Calle Falsa 123", "123456789");

        // Alta de cliente
        sistema.AltaCliente(c1);

        // Alquilar videojuego
        c1.AlquilarJuego(v1);

        // Listar videojuegos disponibles
        sistema.ListarVideojuegosDisponibles();

        // Listar usuarios con juegos prestados
        sistema.ListarUsuariosConJuegosPrestados();

        // Crear empleado
        Empleado e1 = new Empleado("Ana", "Gómez", 28, "Calle Real 456", "987654321", "Gerente", 3000);

        // Alta de empleado
        sistema.AltaEmpleado(e1);
    }
}






























































