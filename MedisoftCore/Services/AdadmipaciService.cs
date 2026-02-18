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
    public class AdadmipaciService
    {

        private string _connectionString;

        public AdadmipaciService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Adadmipaci> GetAdadmipaci(AdadmipaciQueryFilter filters)
        {
            List<Adadmipaci> lstAdadmipaci = new List<Adadmipaci>();
            try
            {
                using (OleDbConnection connection = new OleDbConnection(_connectionString))
                {

                    string sql = @"SELECT * FROM Adadmipaci ORDER BY 1 WHERE 1=1 ";
                    // Usa Dapper para ejecutar una consulta y obtener los resultados
                    var results = connection.Query<Adadmipaci>(sql);
                    lstAdadmipaci = results.ToList();
                    if (!string.IsNullOrEmpty(filters.Adadpacons))
                    {
                        lstAdadmipaci = lstAdadmipaci.Where(x => x.Adadpacons.Trim() == filters.Adadpacons).ToList();
                    }
                    if (!string.IsNullOrEmpty(filters.Adpaciiden))
                    {
                        lstAdadmipaci = lstAdadmipaci.Where(x => x.Adpaciiden.Trim() == filters.Adpaciiden).ToList();
                    }
                    if (!string.IsNullOrEmpty(filters.Ctadmicodi))
                    {
                        lstAdadmipaci = lstAdadmipaci.Where(x => x.Ctadmicodi.Trim() == filters.Ctadmicodi).ToList();
                    }
                    if (!string.IsNullOrEmpty(filters.Ctcontcodi))
                    {
                        lstAdadmipaci = lstAdadmipaci.Where(x => x.Ctcontcodi.Trim() == filters.Ctcontcodi).ToList();
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al conectarse a la base de datos de FoxPro: " + ex.Message);
                throw;

            }
            return lstAdadmipaci;
        }
    }
}
