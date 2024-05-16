public class Funciones{
    public static void Menu(){
    Console.WriteLine("1. Nueva Inscripción");
    Console.WriteLine("2. Obtener Estadísticas del Evento");
    Console.WriteLine("3. Buscar Cliente");
    Console.WriteLine("4. Cambiar entrada de un Cliente");
    Console.WriteLine("5. Listado de clientes");
    Console.WriteLine("6. Salir");
    }
    public static void Continue(){
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.CursorVisible = false;
        Console.Write("Toque cualquier tecla para continuar");
        Console.ReadKey();
        Console.CursorVisible = true;
    }
    public static void ImprimirListado(Dictionary<int,Cliente> DicClientes){
        foreach (KeyValuePair<int,Cliente> persona in DicClientes)
        {
            Console.WriteLine($"ID: {persona.Key}");
            Console.WriteLine($"DNI: {persona.Value.DNI}");
            Console.WriteLine($"Nombre: {persona.Value.Nombre}");
            Console.WriteLine($"Apellido: {persona.Value.Apellido}");
            Console.WriteLine($"Fecha de inscripcion: {persona.Value.FechaInscripcion}");
            Console.WriteLine($"Tipo de entrada: {persona.Value.TipoEntrada}");
            Console.WriteLine($"Cantidad de entradas: {persona.Value.Cantidad}");
            Console.WriteLine();
        }
    }
}
