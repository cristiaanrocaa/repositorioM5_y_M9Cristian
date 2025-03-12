using System;
using System.Linq;

public class Persona
{
    public string Nombre { get; set; }
    public int Edad { get; set; }

    public Persona(string nombre, int edad)
    {
        Nombre = nombre;
        Edad = edad;
    }
}

class Program
{
    static void Main()
    {
        List<Persona> personas = new List<Persona> 
        { 
            new Persona("Juan", 30), 
            new Persona("Pedro", 31), 
            new Persona("Miguel", 25), 
            new Persona("Luís", 36), 
            new Persona("José", 25), 
        };



        // Sin Expresiones Lambda

        var personaMasJoven = (from persona in personas
                               orderby persona.Edad
                               select persona.Nombre).First();




        var edadPromedio = (from persona in personas
                            select persona.Edad).Average();




        var mayoresDe25 = (from persona in personas
                           where persona.Edad > 25
                           orderby persona.Nombre
                           select persona).ToList();




        var nombresM = (from persona in personas
                        where persona.Nombre.StartsWith("M")
                        orderby persona.Edad descending
                        select persona).ToList();




        var todasSonMayoresDe18 = personas.All(p => p.Edad > 18);



        var personaMasJovenConA = (from persona in personas
                                   where persona.Nombre.Contains("a")
                                   orderby persona.Edad
                                   select persona).First();




        var agrupadasPorLetra = from persona in personas
                                group persona by persona.Nombre[0] into g
                                select new { Letra = g.Key, Cantidad = g.Count() };




        // Con Expresiones Lambda


        var personaMasJovenEdadImpar = personas.Where(p => p.Edad % 2 != 0)
                                                .OrderBy(p => p.Edad)
                                                .FirstOrDefault()?.Nombre;





        personas.RemoveAll(p => p.Edad % 5 == 0);




        var diferenciaEdad = personas.Max(p => p.Edad) - personas.Min(p => p.Edad);






        // Mostrar resultados
        Console.WriteLine($"Persona más joven: {personaMasJoven}");
        Console.WriteLine($"Edad promedio: {edadPromedio}");
        Console.WriteLine($"Personas mayores de 25 años:");
        
        foreach (var p in mayoresDe25)
        {
            Console.WriteLine(p.Nombre);
        }
        Console.WriteLine($"Personas que empiezan por 'M' ordenadas por edad descendente:");

        foreach (var p in nombresM)
        {
            Console.WriteLine(p.Nombre);
        }
        Console.WriteLine($"¿Todas las personas son mayores de 18? {todasSonMayoresDe18}");
        Console.WriteLine($"Persona más joven que contiene 'a' en su nombre: {personaMasJovenConA.Nombre}");
        Console.WriteLine($"Agrupadas por letra inicial:");

        foreach (var group in agrupadasPorLetra)
        {
            Console.WriteLine($"{group.Letra}: {group.Cantidad}");
        }
        Console.WriteLine($"Persona más joven con edad impar: {personaMasJovenEdadImpar}");
        Console.WriteLine($"Diferencia de edad: {diferenciaEdad}");
    }
}
