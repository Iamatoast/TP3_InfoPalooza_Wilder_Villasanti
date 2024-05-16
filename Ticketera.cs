static class Ticketera{
    static private Dictionary<int,Cliente> DicClientes = new Dictionary<int, Cliente>();
    static private int UltimoIDEntrada = 0;
    static private int[] TicketOpc = new int[]{45000, 60000, 30000, 100000};
    
    static public Dictionary<int,Cliente> DevolverDic(){
        return DicClientes;
    }
    static public int DevolverUltimoID(){
        return UltimoIDEntrada;
    }
    static public int AgregarCliente(Cliente persona){
        UltimoIDEntrada++;
        DicClientes.Add(UltimoIDEntrada,persona);
        return UltimoIDEntrada;
    }
    static public Cliente BuscarCliente(int ID){
        if(DicClientes.ContainsKey(ID)) return DicClientes[ID];
        else return null;
    }
    static public bool CambiarEntrada(int ID, int tipo, int cantidad){
        int viejoImporte = TicketOpc[DicClientes[ID].TipoEntrada - 1] * DicClientes[ID].Cantidad;
        if(TicketOpc[tipo - 1] * cantidad > viejoImporte){
            DicClientes[ID].TipoEntrada = tipo;
            DicClientes[ID].Cantidad = cantidad;
            return true;
        }
        else return false;
    }
    static public List<string> EstadisticaTicketera(){
        List<string> info = new List<string>();
        double[] CantTickets = new double[4];
        int[] RecaudacionTickets = new int[4];
        int plataTotal = 0, cantTicketsMax = 0;
        for (int opcion = 0; opcion < CantTickets.Length; opcion++)
        {
            foreach (Cliente tipoTicket in DicClientes.Values)
            {
                if (tipoTicket.TipoEntrada == opcion + 1)
                {
                    CantTickets[opcion] += tipoTicket.Cantidad;
                    cantTicketsMax += tipoTicket.Cantidad;
                    RecaudacionTickets[opcion] += TicketOpc[opcion] * tipoTicket.Cantidad;
                }
            }
        }
        info.Add("Cantidad de clientes: " + DicClientes.Count);
        for (int i = 0; i < CantTickets.Length - 1; i++) info.Add($"Cantidad de entradas Opción {i + 1}: {CantTickets[i]}");
        info.Add($"Cantidad de entradas Opción Full: {CantTickets[3]}");
        for (int i = 0; i < CantTickets.Length - 1; i++)
        {
            if (CantTickets[i] != 0) info.Add($"Porcentaje Opción {i + 1}: {CantTickets[i] / cantTicketsMax * 100}%");
            else info.Add($"Ninguna persona compró entradas de la opción {i + 1}");
        }
        if (CantTickets[3] != 0) info.Add($"Porcentaje Opción Full: {CantTickets[3] / cantTicketsMax * 100}%");
        else info.Add($"Ninguna persona compro entradas de la opción Full Pass");
        for (int i = 0; i < RecaudacionTickets.Length - 1; i++) info.Add($"Recaudacion Opción {i + 1}: {RecaudacionTickets[i]}");
        info.Add($"Recaudacion Opción Full: {RecaudacionTickets[3]}");
        foreach (int plata in RecaudacionTickets) plataTotal += plata;
        info.Add($"Recaudación total: {plataTotal}");
        return info;
    }
}