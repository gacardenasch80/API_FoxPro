using Dapper;
using MedisoftCore.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedisoftCore.Services
{
    public class ConsecutivosService
    {

        private string _connectionString;

        public ConsecutivosService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Consecutivos> GetConsecutivos()
        {
            List<Consecutivos> lstConsecutivos = new List<Consecutivos>();
            try
            {
                using (OleDbConnection connection = new OleDbConnection(_connectionString))
                {
                    string sql = @"SELECT * FROM Consecutivos ORDER BY 1";
                    // Usa Dapper para ejecutar una consulta y obtener los resultados
                    var results = connection.Query<Consecutivos>(sql);
                    lstConsecutivos = results.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al conectarse a la base de datos de FoxPro: " + ex.Message);
                throw;

            }
            return lstConsecutivos;
        }

        public List<Consecutivos> GetConsecutivosTabla(string tabla)
        {
            List<Consecutivos> lstConsecutivos = new List<Consecutivos>();
            try
            {
                using (OleDbConnection connection = new OleDbConnection(_connectionString))
                {
                    string sql = @"SELECT * FROM Consecutivos where tabla = '"+ tabla + "' ORDER BY 1";
                    // Usa Dapper para ejecutar una consulta y obtener los resultados
                    var results = connection.Query<Consecutivos>(sql);
                    lstConsecutivos = results.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al conectarse a la base de datos de FoxPro: " + ex.Message);
                throw;

            }
            return lstConsecutivos;
        }

        public bool ActualizarConsecutivo(string tabla) {
            bool actualizar = false;
            Consecutivos consecutivosCon = GetConsecutivosTabla(tabla).FirstOrDefault();

            using (IDbConnection dbConnection = new OleDbConnection(_connectionString))
            {
                dbConnection.Open();
                int numero = (int)(consecutivosCon.Numero + 1);
                // Crear un nuevo objeto Adcitas con los datos actualizados
                var updatedConsecutivos = new Consecutivos
                {
                    Tabla = consecutivosCon.Tabla.Trim(), 
                    Numero = consecutivosCon.Numero+1
                };

                // Query SQL para actualizar el registro
                string updateQuery = "UPDATE Consecutivos SET Numero = "+ updatedConsecutivos.Numero.ToString() + " WHERE tabla = '"+ tabla+"'";

                // Ejecutar la consulta utilizando Dapper
                int rowsAffected = dbConnection.Execute(updateQuery);

                if (rowsAffected > 0)
                {
                    //Console.WriteLine("Registro actualizado correctamente.");
                }
                else
                {
                    //Console.WriteLine("No se encontró el registro para actualizar.");
                }
            }

            return actualizar;
        }


        public string f_consecutivo(string tabla)
        {
            Consecutivos consecutivosCon = GetConsecutivosTabla(tabla).FirstOrDefault();
            string consecutivo = string.Empty;
            using (IDbConnection dbConnection = new OleDbConnection(_connectionString))
            {
                dbConnection.Open();
                int numero = (int)(consecutivosCon.Numero + 1);
                // Crear un nuevo objeto Adcitas con los datos actualizados
                var updatedConsecutivos = new Consecutivos
                {
                    Tabla = consecutivosCon.Tabla.Trim(),
                    Numero = consecutivosCon.Numero + 1
                };

                // Query SQL para actualizar el registro
                string updateQuery = "UPDATE Consecutivos SET Numero = " + updatedConsecutivos.Numero.ToString() + " WHERE tabla = '" + tabla + "'";

                // Ejecutar la consulta utilizando Dapper
                int rowsAffected = dbConnection.Execute(updateQuery);

                if (rowsAffected > 0)
                {
                    consecutivo= consecutivosCon.Numero.ToString();
                }
                dbConnection.Close();
            }
            return consecutivo;
        }


    }
}

