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
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("InfoPalooza Menu\n");
            Console.BackgroundColor = ConsoleColor.Black;
            Funciones.Menu();
            opcion = Ingreso.IngresarInt("Ingresa la opción");
            Console.Clear();
            switch (opcion){
                case 1:
                    int DNI, tipo, cantidad, ID;
                    string apellido, nombre;
                    do
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.WriteLine("Nueva Inscripción\n");
                        Console.BackgroundColor = ConsoleColor.Black;
                        do DNI = Ingreso.IngresarInt("Ingresa el DNI"); while (DNI < 1 || DNI > 60000000);
                        apellido = Ingreso.IngresarString("Ingresa el apellido");
                        nombre = Ingreso.IngresarString("Ingrese el nombre");
                        tipo = Ingreso.IngresarInt("Ingrese uno de las siguientes opciones:\n  Opción 1 (Día 1 / $45000)\n  Opción 2 (Día 2 / $60000)\n  Opción 3 (Día 3 / $30000)\n  Opción Full Pass[4] (Todos los Días/ $100000)");
                        do cantidad = Ingreso.IngresarInt("Ingresa la cantidad de entradas que querés comprar"); while (cantidad <= 0);
                        confirmacion = Ingreso.IngresarString("¿Es lo ingresado correcto? Ingrese 's' para continuar").ToLower();
                    } while (confirmacion != "s");
                    Cliente temp = new Cliente(DNI, apellido, nombre, tipo, cantidad);
                    Console.WriteLine($"Tu ID es {Ticketera.AgregarCliente(temp)}");
                    Funciones.Continue();
                    break;
                case 2:
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine("Estadísticas\n");
                    Console.BackgroundColor = ConsoleColor.Black;
                    estadisticas = Ticketera.EstadisticaTicketera();
                    if(estadisticas == null){
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Aun no se anotó nadie");
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
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine("Busqueda de cliente\n");
                    Console.BackgroundColor = ConsoleColor.Black;
                    ID = Ingreso.IngresarInt("Ingrese el ID del cliente");
                    Cliente temp1 = Ticketera.BuscarCliente(ID);
                    if(temp1 == null){
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("El ID no esta registrado en la base de datos");
                    } 
                    else
                    {
                        Console.WriteLine($"El DNI del cliente es: {temp1.DNI}");
                        Console.WriteLine($"El nombre completo del cliente es: {temp1.Apellido} {temp1.Nombre}");
                        Console.WriteLine($"Su fecha de inscripción fue el {temp1.FechaInscripcion}");
                        if (temp1.TipoEntrada != 4)
                        {
                            Console.WriteLine($"Compró {temp1.Cantidad} entrada/s para el dia {temp1.TipoEntrada}");
                        }
                        else
                        {
                            Console.WriteLine($"Compró {temp1.Cantidad} entrada/s para el Full Pass");
                        }
                    }
                    Funciones.Continue();
                    break;
                case 4:
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine("Cambio de entrada\n");
                    Console.BackgroundColor = ConsoleColor.Black;
                    ID = Ingreso.IngresarInt("Ingrese el ID del cliente");
                    temp1 = Ticketera.BuscarCliente(ID);
                    if(temp1 == null){
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("El ID no esta registrado en la base de datos");
                    } 
                    else
                    {
                        tipo = Ingreso.IngresarInt("Ingrese uno de las siguientes opciones:\n  Opción 1 (Día 1 / $45000)\n  Opción 2 (Día 2 / $60000)\n  Opción 3 (Día 3 / $30000)\n  Opción Full Pass[4] (Todos los Días/ $100000)");
                        cantidad = Ingreso.IngresarInt("Ingresa la cantidad de entradas que queres comprar");
                        if (Ticketera.CambiarEntrada(ID, tipo, cantidad))
                        {
                            Console.WriteLine("El cambio ha sido exitoso");
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine("El cambio no pudo ser realizado; el aporte debe ser mayor a tu aporte anterior");
                        }
                    }
                    Funciones.Continue();
                    break;
                case 5:
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine("Listado\n");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Funciones.ImprimirListado(Ticketera.DevolverDic());
                    Funciones.Continue();
                    break;
                case 6:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Se cerró el Programa de InfoPalooza :)");
                    break;
            }
        } while (opcion != 6);
    }
}
