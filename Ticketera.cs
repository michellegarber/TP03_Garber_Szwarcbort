public static class Ticketera{
    private static Dictionary <int, Clientes> DicClientes = new Dictionary<int, Clientes>();
    private static int  UltimoIDEntrada = 0;

    public static int  DevolverUltimoId(){

        return ++UltimoIDEntrada;
    }

    public static int AgregarCliente (Clientes cliente)
    {
        DicClientes.Add(UltimoIDEntrada, cliente);
        return UltimoIDEntrada;
    }
    

    public static Clientes BuscarClientes (int IDIngresado)
    {
        Clientes clienteBuscado;
        clienteBuscado = DicClientes[IDIngresado];
        return clienteBuscado;      
    }

    public static bool CambiarEntrada (int IDIngresado, int tipoEntrada, int cantidad)
    {
        VerificarId(IDIngresado);
        bool seRealizoElCambio = false;

        int tipoViejo = DicClientes[IDIngresado].TipoEntrada;
        int cantidadViejo = DicClientes[IDIngresado].Cantidad;
        int importeViejo = CalcularImporte(tipoViejo, cantidadViejo);

        int importe = CalcularImporte(tipoEntrada, cantidad);
        
        if(importeViejo < importe){
            seRealizoElCambio = true;
        }
        return seRealizoElCambio;

    }
    public static bool VerificarId(int IDIngresado){
        bool existe = false;
        existe = DicClientes.ContainsKey(IDIngresado);
        if(existe == false){
            Console.WriteLine("ERROR: ingrese un ID valido");
        }
        return existe;
        
    }
    public static int CalcularImporte(int tipoEntrada, int cantidad)
    {
        const int DIA1 = 45000, DIA2 = 60000, DIA3 = 30000, FULLPASS = 100000;
        int importe = 0;
        switch(tipoEntrada){
            case 1:
            importe = DIA1 * cantidad;
            break;
            case 2:
            importe = DIA2 * cantidad;
            break;
            case 3:
            importe = DIA3 * cantidad;
            break;
            case 4:
            importe = FULLPASS * cantidad;
            break;
        }
        return importe;     

    }
    public static List<string> estadisticasTicketera(){
        List<string> listaEstadisticas = new List<string>();

        int clientes1 = 0, clientes2 = 0, clientes3 = 0, clientes4 = 0;
        int importe1 = 0, importe2 = 0, importe3 = 0, importe4 = 0;
        double porcentaje1 = 0, porcentaje2 = 0, porcentaje3 = 0, porcentaje4 = 0;

        int cantClientes = DicClientes.Count;
        listaEstadisticas.Add($"Cantidad de clientes registrados: {cantClientes}");

        foreach(int clave in DicClientes.Keys){
            if(DicClientes[clave].TipoEntrada == 1){
                clientes1++;
                importe1 += 45000 * DicClientes[clave].Cantidad;
                
            }else if(DicClientes[clave].TipoEntrada == 2){
                clientes2++;
                importe2 += 60000 * DicClientes[clave].Cantidad;
            }else if(DicClientes[clave].TipoEntrada == 3){
                clientes3++;
                importe3 += 30000 * DicClientes[clave].Cantidad;
            }else{
                clientes4++;
                importe4 += 100000 * DicClientes[clave].Cantidad;
            }
            listaEstadisticas.Add($"Cantidad clientes dia 1: {clientes1}");
            listaEstadisticas.Add($"Cantidad clientes dia 2: {clientes2}");
            listaEstadisticas.Add($"Cantidad clientes dia 3: {clientes3}");
            listaEstadisticas.Add($"Cantidad clientes full pass: {clientes4}");
        }

        
        porcentaje1 = cantClientes * clientes1 / 100;
        porcentaje2 = cantClientes * clientes2 / 100;
        porcentaje3 = cantClientes * clientes3 / 100;
        porcentaje4 = cantClientes * clientes4 / 100;

        listaEstadisticas.Add($"porcentaje total de clientes dia 1: {porcentaje1}");
        listaEstadisticas.Add($"porcentaje total de clientes dia 2: {porcentaje2}");
        listaEstadisticas.Add($"porcentaje total de clientes dia 3: {porcentaje3}");
        listaEstadisticas.Add($"porcentaje total de clientes full pass: {porcentaje4}");

        listaEstadisticas.Add($"Cantidad recaudada dia 1: {importe1}");
        listaEstadisticas.Add($"Cantidad recaudada dia 2: {importe2}");
        listaEstadisticas.Add($"Cantidad recaudada dia 3: {importe3}");
        listaEstadisticas.Add($"Cantidad recaudada full pass: {importe4}");

        int recaudoTotal = importe1 + importe2 + importe3 + importe4;

        listaEstadisticas.Add($"Cantidad recaudada total: {recaudoTotal}");
        return listaEstadisticas;

    }


}