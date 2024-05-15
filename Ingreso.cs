class Ingreso{
    /* Crtl C + Crtl V:
    Ingreso.IngresarInt("");
    Ingreso.IngresarDouble("");
    Ingreso.IngresarString("");
    Ingreso.IngresarChar("");
    */
    public static int IngresarInt(string txt){
        string In;
        int num;
        do
        {
            Console.WriteLine(txt);
            In = Console.ReadLine();
        } while (!int.TryParse(In, out num));
        return num;
    }
    public static double IngresarDouble(string txt){
        string In;
        double num;
        do
        {
            Console.WriteLine(txt);
            In = Console.ReadLine();
        } while (!double.TryParse(In, out num));
        return num;
    }
    public static string IngresarString(string txt){
        string cadena;
        do
        {
            Console.WriteLine(txt);
            cadena = Console.ReadLine();
        } while (cadena == null);
        return cadena;
    }
    public static double IngresarChar(string txt){
        string In;
        char caracter;
        do
        {
            Console.WriteLine(txt);
            In = Console.ReadLine();
        } while (!char.TryParse(In, out caracter));
        return caracter;
    }
}