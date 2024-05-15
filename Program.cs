namespace trabajo;

class Program
{
    static void Main(string[] args)
    {
        int opcion;
        string confirmacion;
        List<string> estadisticas = new List<string>();
        do
        {
            Console.Clear();
            Funciones.Menu();
            opcion = Ingreso.IngresarInt("Ingresa la opcion");
            Console.Clear();
            switch (opcion){
                case 1:
                    int DNI, tipo, cantidad;
                    string apellido, nombre;
                    do
                    {
                        do
                        {
                            DNI = Ingreso.IngresarInt("Ingresa el DNI");
                        } while (DNI < 1 || DNI > 60000000);
                        apellido = Ingreso.IngresarString("Ingresa el apellido");
                        nombre = Ingreso.IngresarString("Ingrese el nombre");
                        tipo = Ingreso.IngresarInt("Ingrese uno de las siguientes opciones:\n  Opción 1(Día 1 / $45000)\n  Opción 2(Día 2 / $60000)\n  Opción 3(Día 3 / $30000)\n  Opción Full Pass(Todos los Días/ $100000)");
                        cantidad = Ingreso.IngresarInt("Ingresa la cantidad de entradas que queres comprar");
                        confirmacion = Ingreso.IngresarString("¿Es lo ingresado correcto? Ingrese 's' para continuar").ToLower();
                    } while (confirmacion != "s");
                    Cliente temp = new Cliente(DNI, apellido, nombre, tipo, cantidad);
                    Console.WriteLine($"Tu ID es {Ticketera.AgregarCliente(temp)}");
                    Funciones.Continue();
                    break;
                case 2:
                    estadisticas = Ticketera.EstadisticaTicketera();
                    if(estadisticas == null){
                        Console.WriteLine("Aun no se anoto nadie");
                    }
                    else{
                        foreach (string txt in estadisticas)
                        {
                            Console.WriteLine(txt);
                        }
                        Funciones.Continue();
                    }
                    break;
                case 3:
                    int ID = Ingreso.IngresarInt("Ingrese el ID del cliente");
                    Cliente temp1 = Ticketera.BuscarCliente(ID);
                    if(temp1 == null)
                    {
                        Console.WriteLine("El ID no esta registrado en la base de datos");
                    }
                    else
                    {
                        Console.WriteLine("");
                    }
                    Funciones.Continue();
                    break;
                case 4:
                    
                    Funciones.Continue();
                    break;
                case 5:
                    Console.WriteLine("Cerrando el Programa de InfoPalooza :)");
                    break;
            }
        } while (opcion != 5);
    }
}
