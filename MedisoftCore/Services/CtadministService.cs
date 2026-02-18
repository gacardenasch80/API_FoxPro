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
    public class CtadministService
    {

        private string _connectionString;

        public CtadministService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Ctadminist> GetCtadminist()
        {
            List<Ctadminist> lstCtadminist = new List<Ctadminist>();
            try
            {
                using (OleDbConnection connection = new OleDbConnection(_connectionString))
                {
                    string sql = @"SELECT * FROM Ctadminist ORDER BY 1";
                    // Usa Dapper para ejecutar una consulta y obtener los resultados
                    var results = connection.Query<Ctadminist>(sql);
                    lstCtadminist = results.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al conectarse a la base de datos de FoxPro: " + ex.Message);
                throw;

            }
            return lstCtadminist;
        }
    }
}
