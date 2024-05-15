static class Ticketera{
    static private Dictionary<int,Cliente> DicClientes = new Dictionary<int, Cliente>();
    static private int UltimoIDEntrada = 0;
    static private int[] TicketOpc = new int[]{45000, 60000, 30000, 1000000};
    
    static public int DevolverUltimoID(){
        return UltimoIDEntrada;
    }
    static public int AgregarCliente(Cliente persona){
        UltimoIDEntrada++;
        DicClientes.Add(UltimoIDEntrada,persona);
        return UltimoIDEntrada;
    }
    static public Cliente BuscarCliente(int ID){
        if(DicClientes.ContainsKey(ID)){
            return DicClientes[ID];
        } 
        else {
            return null;
        }
    }
    static public bool CambiarEntrada(int ID, int tipo, int cantidad){
        int nuevoImporte = 0;
        if(TicketOpc[tipo - 1] < nuevoImporte){
            DicClientes[ID].TipoEntrada = tipo;
            DicClientes[ID].Cantidad = cantidad;
            return true;
        }
        else{
            return false;
        }
    }
    static public List<string> EstadisticaTicketera(){
        List<string> info = new List<string>();
        int[] CantTickets = new int[4];
        int[] RecaudacionTickets = new int[4];
        
        int plataTotal = 0;
        info.Add("Cantidad de clientes: " + DicClientes.Count);
        for (int i = 0; i < CantTickets.Length - 1; i++)
        {
            info.Add($"Cantidad de entradas Opcion {i + 1}: {CantTickets[i]}");
        }
        info.Add($"Cantidad de entradas Opcion Full: {CantTickets[3]}");
        for (int i = 0; i < CantTickets.Length - 1; i++)
        {
            info.Add($"Porcentaje Opcion {i + 1}: {CantTickets.Length / CantTickets[i]}");
        }
        info.Add($"Porcentaje Opcion Full: {CantTickets.Length / CantTickets[3]}");
        for (int i = 0; i < RecaudacionTickets.Length - 1; i++)
        {
            info.Add($"Recaudacion Opcion {i + 1}: {RecaudacionTickets[i]}");
        }
        info.Add($"Recaudacion Opcion Full: {RecaudacionTickets[3]}");
        foreach (int plata in RecaudacionTickets)
        {
            plataTotal += plata;
        }
        info.Add($"Recaudacion total: {plataTotal}");
        return info;
    }
}