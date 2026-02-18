using Dapper;
using MedisoftCore.Entities;
using MedisoftCore.QueryFilters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedisoftCore.Services
{
    public class AddispmedService
    {

        private string _connectionString;

        public AddispmedService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Addispmed> GetAddispmed()
        {
            List<Addispmed> lstAddispmed = new List<Addispmed>();
            try
            {
                using (OleDbConnection connection = new OleDbConnection(_connectionString))
                {
                    string sql = @"SELECT * FROM Addispmed ORDER BY 1";
                    // Usa Dapper para ejecutar una consulta y obtener los resultados
                    var results = connection.Query<Addispmed>(sql);
                    lstAddispmed = results.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al conectarse a la base de datos de FoxPro: " + ex.Message);
                throw;

            }
            return lstAddispmed;
        }

        public bool UpdateAddispmed(Addispmed obj_Addispmed)
        {
            bool update = false;
            using (IDbConnection dbConnection = new OleDbConnection(_connectionString))
            {
                dbConnection.Open();
                // Query SQL para actualizar el registro
                string updateQuery = "UPDATE Addispmed SET addispcita = .T. " +
                    "WHERE addispplan = .T. AND addispcita = .F. and alltrim(Addispcons) = '" + obj_Addispmed.Addispcons + "'  ";
                // Ejecutar la consulta utilizando Dapper
                int rowsAffected = dbConnection.Execute(updateQuery);
                if (rowsAffected > 0)
                {
                    update = true;
                }
                dbConnection.Close();
            }
            return update;
        }

        public List<Addispmed> GetAddispmedFilter(AddispmedQueryFilter filters)
        {
            List<Addispmed> lstAddispmed = new List<Addispmed>();
            try
            {
                using (OleDbConnection connection = new OleDbConnection(_connectionString))
                {
                    string sql = @"SELECT * FROM Addispmed ORDER BY 1 desc where addispplan = .T. AND addispcita = .F. ";
                    if (!string.IsNullOrEmpty(filters.Addispcons))
                    {
                        sql = sql + " and alltrim(Addispcons) = '" + filters.Addispcons + "' ";
                    }
                    if (!string.IsNullOrEmpty(filters.Geespecodi))
                    {
                        sql = sql + " and alltrim(Geespecodi) = '" + filters.Geespecodi + "' ";
                    }
                    if (!string.IsNullOrEmpty(filters.Gemedicodi))
                    {
                        sql = sql + " and alltrim(Gemedicodi) = '" + filters.Gemedicodi + "' ";
                    }
                    if (filters.FechaInicio != null)
                    {
                        DateTime dtFechaInicio = (DateTime)filters.FechaInicio;
                        sql = sql + " and Addispfech >= CTOD('" + dtFechaInicio.ToString("MM/dd/yyyy") + "') ";
                    }
                    if (filters.FechaFin != null)
                    {
                        DateTime dtFechaFin = (DateTime)filters.FechaFin;
                        sql = sql + " and Addispfech <= CTOD('" + dtFechaFin.ToString("MM/dd/yyyy") + "') ";
                    }
                    // Usa Dapper para ejecutar una consulta y obtener los resultados
                    var results = connection.Query<Addispmed>(sql);
                    lstAddispmed = results.ToList();
                    //lstAddispmed = lstAddispmed.Take(5).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al conectarse a la base de datos de FoxPro: " + ex.Message);
                throw;

            }
            return lstAddispmed;
        }
    }
}
