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
    public class FafacturaService
    {

        private string _connectionString;

        public FafacturaService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Fafactura> GetFacturas()
        {
            List<Fafactura> lstFactura = new List<Fafactura>();
            try
            {
                using (OleDbConnection connection = new OleDbConnection(_connectionString))
                {
                    string sql = @"SELECT * FROM fafactura ORDER BY 1";
                    // Usa Dapper para ejecutar una consulta y obtener los resultados
                    var results = connection.Query<Fafactura>(sql);
                    lstFactura = results.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al conectarse a la base de datos de FoxPro: " + ex.Message);
                //throw;

            }
            return lstFactura;
        }
    }
}
