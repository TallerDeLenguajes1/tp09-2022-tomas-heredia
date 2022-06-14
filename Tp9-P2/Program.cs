using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using quisco;

public class program
{
    public int N = 9;
    public static string[] cosas = {"papas","chicles","bebes","negrs"};
    public static string[] tamanio = {"pequenio","mediano","grande"};
    public static void Main(String[] args){
        string NombreArchivoJson = @"C:\Users\Alumno\Documents\prueva\index.json";

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
            DateTimeCompare fecha = new DateTime(rand.Next(2022,2033),rand.Next(1,13),rand.Next(1,28));
            json =  JsonSerializer.Serialize(archivoJson);
            Console.WriteLine(json);
            streamWriterJson.WriteLine(json);
        }


        streamWriterJson.Close();
        filestreamJson.Close();










    }


}
