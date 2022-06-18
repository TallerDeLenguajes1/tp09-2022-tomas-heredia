using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using tp9;
using quisco;


public class Program
{
    
  /* public static void Main(String[] args){
       Console.WriteLine("Ingrese la direccion de la carpeta");
       String? direccion = Console.ReadLine();
       direccion = @""+ direccion;
        

       string NombreArchivo = direccion + "\\index.csv";
       string NombreArchivoJson = direccion + "\\index.json";
        List<archivo> archivos = new List<archivo>();

       if(!File.Exists(NombreArchivo)){
           File.Create(NombreArchivo);
       }if(!File.Exists(NombreArchivoJson)){
           File.Create(NombreArchivoJson);
       }
       string json;
       FileStream filestream = new FileStream(NombreArchivo, FileMode.Open);
        StreamWriter streamWriter = new StreamWriter(filestream);

        FileStream filestreamJson = new FileStream(NombreArchivoJson, FileMode.Open);
        StreamWriter streamWriterJson = new StreamWriter(filestreamJson);

        List<string> ListadoCarpetas = Directory.GetDirectories(direccion).ToList();
        List<string> ListadoElementos = Directory.GetFiles(direccion).ToList();
        int contador = 1;

        archivo archivoJson = new archivo();

        foreach (string Carpeta in ListadoCarpetas)
        {
            
            foreach (string elemento in Directory.GetFiles(Carpeta))
            {
                Console.WriteLine(elemento);
                
                
                string[] nombre = nombreYextencion(elemento); 
                streamWriter.WriteLine(contador +", "+ nombre[0] + ", "+nombre[1]+", ");
                contador ++;
                archivoJson.nombre = nombre[0];
                archivoJson.contador = contador;
                archivoJson.extencion = nombre[1];
                archivos.Add(archivoJson);
                Console.WriteLine(archivoJson);
                
            }
            json =  JsonSerializer.Serialize(archivos);
            streamWriterJson.WriteLine(json);
            foreach (string elementos in ListadoElementos)
            {
                Console.WriteLine(elementos);
                
                string[] nombre = nombreYextencion(elementos); 
                streamWriter.WriteLine(contador +", "+ nombre[0] + ", "+nombre[1]+", ");
                contador ++;
                archivoJson.nombre = nombre[0];
                archivoJson.contador = contador;
                archivoJson.extencion = nombre[1];
                archivos.Add(archivoJson);
                
                Console.WriteLine(json);
                
                
            }
            json =  JsonSerializer.Serialize(archivos);
            streamWriterJson.WriteLine(json);
        }

        streamWriterJson.Close();
        filestreamJson.Close();
        streamWriter.Close();
        filestream.Close();
        
    }


    public static string[] nombreYextencion(string ruta){
        string[] subs = ruta.Split(@"\");
        int total = subs.Count();
        string[] nombre = subs[total-1].Split('.'); 
        return nombre;
    }


    }*/

 
 //el anteriror puede tener errores, usar este jeje
    public static string[] cosas = {"papas","chicles","bebes","negrs"};
    public static string[] tamanio = {"pequenio","mediano","grande"};
    public static void Main(String[] args){
        int N = 9;
        List<Producto> ListadoProducto = new List<Producto>();
        string NombreArchivoJson = @"C:\Users\usuario\Documents\1er2022\taller1\ganadores\index.json";

        if (!File.Exists(NombreArchivoJson))
        {
            
            File.Create(NombreArchivoJson);
            
        }
        string json;
        

        FileStream filestreamJson = new FileStream(NombreArchivoJson, FileMode.Open);
        StreamWriter streamWriterJson = new StreamWriter(filestreamJson);

        Producto producto = new Producto();
        Random rand = new Random();
        for (int i = 0; i < N; i++)
        {
            producto.nombre = cosas[rand.Next(cosas.Length)];
            producto.tamanio = tamanio[rand.Next(tamanio.Length)];
            producto.precio = rand.Next(1000,5000);
            DateTime fecha = new DateTime(rand.Next(2022,2033),rand.Next(1,13),rand.Next(1,28));
            producto.fechavencimiento = fecha;
            ListadoProducto.Add(producto);
        }
        json =  JsonSerializer.Serialize(ListadoProducto);
            
        streamWriterJson.WriteLine(json);

        streamWriterJson.Close();
        filestreamJson.Close();

            StreamReader sr = new StreamReader(@"C:\Users\usuario\Documents\1er2022\taller1\ganadores\index.json");
            string datoJson = sr.ReadLine();
            
            var elementos = JsonSerializer.Deserialize<List<Producto>>(datoJson);

            foreach (var item in elementos)
            {
                item.mostrar();
            }


            sr.Close();







    }
}

