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
    public class FaprogpypService
    {

        private string _connectionString;

        public FaprogpypService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Faprogpyp> GetFaprogpyp()
        {
            List<Faprogpyp> lstFaprogpyp = new List<Faprogpyp>();
            try
            {
                using (OleDbConnection connection = new OleDbConnection(_connectionString))
                {
                    string sql = @"SELECT * FROM Faprogpyp ORDER BY 1";
                    // Usa Dapper para ejecutar una consulta y obtener los resultados
                    var results = connection.Query<Faprogpyp>(sql);
                    lstFaprogpyp = results.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al conectarse a la base de datos de FoxPro: " + ex.Message);
                //throw;

            }
            return lstFaprogpyp;
        }
    }
}
