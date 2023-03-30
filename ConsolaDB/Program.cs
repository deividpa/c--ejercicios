using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ConsolaDB
{
    class Program
    {
        static void Main(string[] args)
        { //esta es la cadena de conexion
            SqlConnection objConectar = new SqlConnection("Data Source=localhost;Initial"+
            " Catalog = Productos; Integrated Security = SSPI; ");
            try
            {
                objConectar.Open();
                Console.WriteLine("Se realizo la conexion...");
                SqlCommand objComando = new SqlCommand("select * from Articulos", objConectar);
                SqlDataReader objTabla = objComando.ExecuteReader();
                try {
                    Console.WriteLine("Código\tNombre\tValor\tCantidad");
                    while (objTabla.Read())
                    {
                        Console.WriteLine("" + objTabla[0] + "\t" + objTabla["nombre"]
                            + "\t" + objTabla[2] + "\t" + objTabla[3]);
                    }
                    objTabla.Close();
                } catch (SqlException e)
            {
                Console.WriteLine("Falló la apertura: " + e.Message);
            }
        }
        catch (Exception ex) {
            Console.WriteLine("Error en el query: " + ex.ToString());
        }
        Console.ReadKey();
    }
}
}