using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        // Validar dirección de correo electrónico
        string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        Console.WriteLine(Validate("usuario@dominio.com", emailPattern)); // true

        // Validar número de teléfono (formato 123-456-7890)
        string phonePattern = @"^\d{3}-\d{3}-\d{4}$";
        Console.WriteLine(Validate("123-456-7890", phonePattern)); // true

        // Validar fecha en formato día/mes/año (ej. 29/02/2024)
        string datePattern = @"^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/\d{4}$";
        Console.WriteLine(Validate("29/02/2024", datePattern)); // true

        // Validar dirección IP (IPv4, ej. 192.168.1.1)
        string ipPattern = @"^(\d{1,3}\.){3}\d{1,3}$";
        Console.WriteLine(Validate("192.168.1.1", ipPattern)); // true

        // Validar código postal (5 dígitos)
        string postalCodePattern = @"^\d{5}$";
        Console.WriteLine(Validate("12345", postalCodePattern)); // true

        // Validar palabra con solo letras
        string wordPattern = @"^[a-zA-Z]+$";
        Console.WriteLine(Validate("Hola", wordPattern)); // true

        // Validar número entero positivo
        string positiveIntPattern = @"^\d+$";
        Console.WriteLine(Validate("123", positiveIntPattern)); // true

        // Validar URL
        string urlPattern = @"^(http|https)://[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}(/.*)?$";
        Console.WriteLine(Validate("http://www.ejemplo.com/", urlPattern)); // true

        // Validar código hexadecimal de color
        string hexColorPattern = @"^#[A-Fa-f0-9]{6}$";
        Console.WriteLine(Validate("#A3C1D7", hexColorPattern)); // true

        // Validar número decimal con punto
        string decimalPattern = @"^\d+\.\d+$";
        Console.WriteLine(Validate("12.23", decimalPattern)); // true
    }

    static bool Validate(string input, string pattern)
    {
        return Regex.IsMatch(input, pattern);
    }
}
