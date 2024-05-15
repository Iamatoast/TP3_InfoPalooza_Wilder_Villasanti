static class Ticketera{
    static private Dictionary<int,Cliente> DicClientes = new Dictionary<int, Cliente>();
    static private int UltimoIDEntrada = 0;
    static private int[] TicketOpc = new int[]{45000, 60000, 30000, 1000000};
    static private int[] CantTickets = new int[4];
    static public int DevolverUltimoID(){
        return UltimoIDEntrada;
    }
    static public int AgregarCliente(Cliente persona){
        Random rng = new Random();
        int idGenerado;
        do{
            idGenerado = rng.Next();
        } while(DicClientes.ContainsKey(idGenerado) == true); 
        DicClientes.Add(idGenerado,persona);
        UltimoIDEntrada = idGenerado;
        return idGenerado;
    }
    static public Cliente BuscarCliente(int ID){
        Cliente nulo = new Cliente();
        if(DicClientes.ContainsKey(ID)){
            return DicClientes(ID);
        } 
        else {
            return nulo;
        }
    }
    static public bool CambiarEntrada(int ID, int tipo, int cantidad){
        int nuevoImporte = 0;
        if(TicketOpc(tipo - 1) < nuevoImporte){
            DicClientes(ID).TipoEntrada = tipo;
            DicClientes(ID).Cantidad = cantidad;
            return true;
        }
        else{
            return false;
        }
    }
    static public List<string> EstadisticaTicketera(){
        List<string> info = new List<string>();
        info.Add("Cantidad de clientes: " + DicClientes.Count);
        for (int i = 0; i < CantTickets.Length - 1; i++)
        {
            info.Add($"Opcion {i + 1}: {CantTickets[i]}");
        }
        info.Add($"Opcion Full: {CantTickets[3]}");
        for (int i = 0; i < CantTickets.Length - 1; i++)
        {
            info.Add($"Porcentaje Opcion {i + 1}: {CantTickets.Length / CantTickets[i]}");
        }
        info.Add($"Porcentaje Opcion Full: {CantTickets.Length / CantTickets[3]}");
    }
}