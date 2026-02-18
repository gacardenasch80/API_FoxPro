using Dapper;
using MedisoftCore.Entities;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedisoftCore.Services
{
    public class GemedicosService
    {

        private string _connectionString;

        public GemedicosService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Gemedicos> GetGemedicos()
        {
            List<Gemedicos> lstGemedicos = new List<Gemedicos>();
            try
            {
                using (OleDbConnection connection = new OleDbConnection(_connectionString))
                {
                    string sql = @"SELECT * FROM Gemedicos ORDER BY 1";
                    // Usa Dapper para ejecutar una consulta y obtener los resultados
                    var results = connection.Query<Gemedicos>(sql);
                    lstGemedicos = results.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al conectarse a la base de datos de FoxPro: " + ex.Message);
                //throw;

            }
            return lstGemedicos;
        }
    }
}
