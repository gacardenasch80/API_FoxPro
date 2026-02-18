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
    public class FaservicioService
    {

        private string _connectionString;

        public FaservicioService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Faservicio> GetFaservicio()
        {
            List<Faservicio> lstFaservicio = new List<Faservicio>();
            try
            {
                using (OleDbConnection connection = new OleDbConnection(_connectionString)) {
                    string sql = @"
                    SELECT 
                        CTCLMACODI,
                        FACLSECODI,
                        FASUBCLCODI,
                        FASERVCODI,
                        FASERVNOMB,
                        CAST(FASERVPROG AS INT) AS FASERVPROG,
                        CAST(FASERVCONS AS INT) AS FASERVCONS,
                        CAST(FASERVPART AS INT) AS FASERVPART,
                        FAFISECODI,
                        CAST(FASERVTIPO AS INT) AS FASERVTIPO,
                        CAST(FASERVOBS AS INT) AS FASERVOBS,
                        CAST(FASERVPAQU AS INT) AS FASERVPAQU,
                        FAAGSECODI,
                        CAST(FASERVDUCI AS INT) AS FASERVDUCI,
                        FASERVADICI,
                        CAST(FASERVPRIV AS INT) AS FASERVPRIV,
                        FASERVINTE,
                        CAST(FASERVENFE AS INT) AS FASERVENFE,
                        CAST(FASERVFREC AS INT) AS FASERVFREC,
                        CAST(FASERVTRAN AS INT) AS FASERVTRAN,
                        CAST(FAESVAC AS INT) AS FAESVAC,
                        CAST(FASERVTRAP AS INT) AS FASERVTRAP,
                        CAST(FASERVTRAS AS INT) AS FASERVTRAS,
                        CAST(FASERVRX AS INT) AS FASERVRX,
                        CAST(FAESTERAPI AS INT) AS FAESTERAPI,
                        FASERVESTA,
                        CAST(FASERV2175 AS INT) AS FASERV2175,
                        CAST(FAINCAPCID AS INT) AS FAINCAPCID
                    FROM FASERVICIO
                ";
                    lstFaservicio = connection.Query<Faservicio>(sql).ToList(); 
                    return lstFaservicio; 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al conectarse a la base de datos de FoxPro: " + ex.Message);
                //throw;

            }
            return lstFaservicio;
        }
    }
}
