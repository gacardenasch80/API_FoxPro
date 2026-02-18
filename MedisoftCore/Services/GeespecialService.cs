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
    public class GeespecialService
    {

        private string _connectionString;

        public GeespecialService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Geespecial> GetGeespecial()
        {
            List<Geespecial> lstGeespecial = new List<Geespecial>();
            try
            {
                using (OleDbConnection connection = new OleDbConnection(_connectionString))
                {
                    string sql = @"SELECT * FROM Geespecial ORDER BY 1";
                    // Usa Dapper para ejecutar una consulta y obtener los resultados
                    var results = connection.Query<Geespecial>(sql);
                    lstGeespecial = results.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al conectarse a la base de datos de FoxPro: " + ex.Message);
                //throw;

            }
            return lstGeespecial;
        }
    }
}
