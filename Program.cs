namespace TP03_Szwarcbort_Garber;

class Program
{
    static void Main(string[] args)
    {
        string nombre = "", apellido = "";
        
        int cantidad= 0, tipoEntrada =0, dni = 0, importeAAbonar = 0;
        List<string> listaEstadisticas = new List<string>();

        Console.WriteLine("INGRESE: 1. Nueva Inscripción, 2. Obtener Estadísticas del Evento, 3. Buscar Cliente, 4. Cambiar entrada de un Cliente, 5. Salir");
        int ingresoMenu = int.Parse(Console.ReadLine());
        while(ingresoMenu <5 && ingresoMenu > 0){
          switch(ingresoMenu){
            case 1:
            Console.WriteLine("Nueva Inscripción");
            nombre = IngresoString("ingrese nombre");
            apellido = IngresoString("ingrese apellido");
            dni = ingresarDNI("ingrese DNI");
            tipoEntrada = ingresarEntrada("ingrese tipo de entrada (1 = dia 1, 2 = dia 2, 3 = dia 3, 4 = full pass)");
            cantidad = ingresarCantidad("ingrese cantidad de entradas");
            importeAAbonar = Ticketera.CalcularImporte(tipoEntrada, cantidad);
            DateTime fechaInscripcion = DateTime.Now;
            Clientes clienteNuevo = new Clientes(nombre, apellido, dni, fechaInscripcion, cantidad, tipoEntrada);
            Ticketera.AgregarCliente(clienteNuevo);

            break;
            case 2:
            Console.WriteLine("Obtener estadísticas del Evento");
            listaEstadisticas = Ticketera.estadisticasTicketera();
            foreach(string valor in listaEstadisticas){
               Console.WriteLine(valor);
            } 
            break;
            case 3:
            Clientes clienteBuscado;
            Console.WriteLine("Buscar Cliente");
            int id = ingresarCantidad("ingrese su ID de entrada");
            bool existe = Ticketera.VerificarId(id);
            if(existe){
                clienteBuscado = Ticketera.BuscarClientes(id);
            }
            break;
            case 4:
            Console.WriteLine("Cambiar entrada de un Cliente");
            int idCliente = ingresarCantidad("ingrese su ID");
            Ticketera.VerificarId(idCliente);
            int nuevaEntrada = ingresarEntrada("ingrese su nueva entrada");
            int nuevaCantidad = ingresarCantidad("ingresar nueva cantidad");

            Ticketera.CambiarEntrada (idCliente,  nuevaEntrada, nuevaCantidad);
            
            break;            
        }
         Console.WriteLine("INGRESE: 1. Nueva Inscripción, 2. Obtener Estadísticas del Evento, 3. Buscar Cliente, 4. Cambiar entrada de un Cliente, 5. Salir");
         ingresoMenu = int.Parse(Console.ReadLine());
  
        }

        
        
    }
    public static string IngresoString (string mensaje){
        string palabra = " ";
        do{
        Console.WriteLine(mensaje);
        palabra = Console.ReadLine();
        }while(palabra == string.Empty);
       
        return palabra;
    }
    public static int ingresarDNI(string msj){
            int num = -1;
            do{
                Console.WriteLine(msj);
            num = int.Parse(Console.ReadLine());
            }while(!(num <= 99999999 && num > 1));
            return num;
    }
    public static int ingresarEntrada(string msj){
            int num = -1;
            do{
                Console.WriteLine(msj);
            num = int.Parse(Console.ReadLine());
            }while(!(num <5 || num > 0));
            return num;
    }
    public static int ingresarCantidad(string msj){
            int num = -1;
            do{
                Console.WriteLine(msj);
            num = int.Parse(Console.ReadLine());
            }while( num < 0);
            return num;
    }
}
