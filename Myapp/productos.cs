namespace quisco;

public class Producto{
    public  Producto(){}
    public string nombre{get; set;}
    public DateTime fechavencimiento{get; set;}
    public float precio{get; set;} //entre 1000 y 5000;
    public string tamanio{get; set;}
    
    public void mostrar(){
        Console.WriteLine("Nombre: "+ this.nombre);
        Console.WriteLine("Fecha de vencimiento: "+ this.fechavencimiento);
        Console.WriteLine("Precio: "+ this.precio + "$");
        Console.WriteLine("Tamanio: "+ this.tamanio);
    }
    }