using Dapper;
using MedisoftCore.Entities;
using MedisoftCore.QueryFilters;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedisoftCore.Services
{
    public class AdpacienteService
    {

        private string _connectionString;

        public AdpacienteService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Adpaciente> GetAdpaciente(AdpacienteQueryFilter filters)
        {
            List<Adpaciente> lstAdpaciente = new List<Adpaciente>();
            try
            {
                using (OleDbConnection connection = new OleDbConnection(_connectionString))
                {

                    string sql = @"SELECT * FROM Adpaciente ORDER BY 1 where 1=1 ";
                    if (!string.IsNullOrEmpty(filters.Adpaciiden))
                    {
                        sql = sql + " and alltrim(Adpaciiden) = '"+ filters.Adpaciiden+"' ";
                    }
                    if (!string.IsNullOrEmpty(filters.Adtiidcodi))
                    {
                        sql = sql + " and alltrim(Adtiidcodi) = '" + filters.Adtiidcodi + "'";
                    }
                    // Usa Dapper para ejecutar una consulta y obtener los resultados
                    var results = connection.Query<Adpaciente>(sql);
                    lstAdpaciente = results.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al conectarse a la base de datos de FoxPro: " + ex.Message);
                throw;

            }
            return lstAdpaciente;
        }
    }
}
