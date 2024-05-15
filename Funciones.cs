public class Funciones{
    public static void Menu(){
    Console.WriteLine("1. Nueva Inscripción");
    Console.WriteLine("2. Obtener Estadísticas del Evento");
    Console.WriteLine("3. Buscar Cliente");
    Console.WriteLine("4. Cambiar entrada de un Cliente");
    Console.WriteLine("5. Salir");
    }
    public static void Continue(){
        Console.CursorVisible = false;
        Console.Write("Toque cualquier tecla para continuar");
        Console.ReadKey();
        Console.CursorVisible = true;
    }
}
