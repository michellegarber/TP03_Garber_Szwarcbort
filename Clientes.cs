public class Clientes{
    //Atributos

     public int DNI {get; private set;}
    public string Nombre {get; private set;}
    public string Apellido {get; private set;}
    public DateTime FechaInscripcion {get; set;}
    public int TipoEntrada {get; set;}
    public int Cantidad {get; set;}
    

    //constructor 
public Clientes(string nombre, string apellido, int dni, DateTime fechaInscripcion, int cantidad, int tipoEntrada){

        Nombre = nombre;
        Apellido = apellido;
        DNI = dni;
        FechaInscripcion = fechaInscripcion;
        Cantidad = cantidad;
        TipoEntrada = tipoEntrada;
}
    //metodos
    
}

