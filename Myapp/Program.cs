using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using tp9;
public class program
{
   public static void Main(String[] args){
       Console.WriteLine("Ingrese la direccion de la carpeta");
       String? direccion = Console.ReadLine();
       direccion = @""+ direccion;

       string NombreArchivo = direccion + "\\index.csv";
       string NombreArchivoJson = direccion + "\\index.json";

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
                json =  JsonSerializer.Serialize(archivoJson);
                streamWriterJson.WriteLine(json);
            }
            foreach (string elementos in ListadoElementos)
            {
                Console.WriteLine(elementos);
                
                string[] nombre = nombreYextencion(elementos); 
                streamWriter.WriteLine(contador +", "+ nombre[0] + ", "+nombre[1]+", ");
                contador ++;
                archivoJson.nombre = nombre[0];
                archivoJson.contador = contador;
                archivoJson.extencion = nombre[1];
                json =  JsonSerializer.Serialize(archivoJson);                Console.WriteLine(json);
                streamWriterJson.WriteLine(json);
                
            }
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


    }


