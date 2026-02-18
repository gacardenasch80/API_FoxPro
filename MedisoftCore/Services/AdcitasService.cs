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
    public class AdcitasService
    {

        private string _connectionString;

        public AdcitasService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Adcitas> GetAdcitas()
        {
            List<Adcitas> lstAdcitas = new List<Adcitas>();
            try
            {
                using (OleDbConnection connection = new OleDbConnection(_connectionString))
                {
                    string sql = @"SELECT * FROM Adcitas ORDER BY 1";
                    // Usa Dapper para ejecutar una consulta y obtener los resultados
                    var results = connection.Query<Adcitas>(sql);
                    lstAdcitas = results.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al conectarse a la base de datos de FoxPro: " + ex.Message);
                throw;

            }
            return lstAdcitas;
        }

        public bool CreateAdcitas(AdcitasQueryFilter filters)
        {
            bool insertCita = false;
            Addispmed obj_Addispmed = new Addispmed();
            var obj_Addispmed_Query = new AddispmedService(_connectionString);
            var obj_filter = new AddispmedQueryFilter();
            obj_filter.Addispcons = filters.Addispcons;
            obj_Addispmed = obj_Addispmed_Query.GetAddispmedFilter(obj_filter).FirstOrDefault();


            var obj_AdadmipaciFilter = new AdadmipaciQueryFilter();
            obj_AdadmipaciFilter.Adadpacons = filters.Adadpacons;
            Adadmipaci listAdadmipaci = new Adadmipaci();
            var obj_Adadmipaci = new AdadmipaciService(filters.ConnectionStringAdm);
            listAdadmipaci = obj_Adadmipaci.GetAdadmipaci(obj_AdadmipaciFilter).FirstOrDefault();

            var obj_Consecutivos = new ConsecutivosService(filters.ConnectionStringAdm);
            string Adcitacons = obj_Consecutivos.f_consecutivo(filters.Tabla).PadLeft(8, '0');


            using (IDbConnection dbConnection = new OleDbConnection(_connectionString))
            {
                dbConnection.Open();
                // Crear un nuevo objeto Adcitas con los datos actualizados
                var insertAdcitas = new Adcitas
                {
                    Adcitacons = Adcitacons,
                    Geespecodi = obj_Addispmed.Geespecodi.Trim(),
                    Gemedicodi = obj_Addispmed.Gemedicodi.Trim(),
                    Faservcodi = obj_Addispmed.Faservcodi.Trim(),
                    Adpaciiden = filters.Adpaciiden.Trim(),
                    Adconscodi = obj_Addispmed.Adconscodi.Trim(),
                    Adfechcita = (DateTime)obj_Addispmed.Addispfech,
                    Adhorainic = obj_Addispmed.Adhoraini.Trim(),
                    Adhorafina = obj_Addispmed.Adhorafin.Trim(),
                    Adduraminu = 30,
                    Adconsdisp = obj_Addispmed.Addispcons.Trim(),
                    Adcitaest   = "A",
                    Adanulcodi = "0",
                    Ctadmicodi = listAdadmipaci.Ctadmicodi.Trim(),
                    Ctcontcodi = listAdadmipaci.Ctcontcodi.Trim(),
                    Fechasoli = (DateTime)obj_Addispmed.Addispfech,
                    Geusuacreo = "ADM1",
                    Adingrcons = "",
                    Faorsecons = "",
                    Coconscons = "",
                    Faprogcodi = filters.Faprogcodi.Trim(),
                    Adcodanula = "",
                    Fechprefpa = (DateTime)obj_Addispmed.Addispfech,
                    Adcitaande = "",
                    Geusuacoan = "",
                    Adciticodi = "0"
                };

                // Query SQL para actualizar el registro
                string insertQuery = "insert into adcitas (Adcitacons,Geespecodi,Gemedicodi,Faservcodi,Adpaciiden," +
                    "Adconscodi,Adfechcita,Adhorainic,Adhorafina,Adduraminu,Adconsdisp,Adcitaest,Adanulcodi," +
                    "Ctadmicodi,Ctcontcodi,Fechasoli,Geusuacreo,Adingrcons,Faorsecons,Coconscons,Faprogcodi," +
                    "Adcodanula,Fechprefpa,Adcitaande,Geusuacoan,Adciticodi, FECHALLEG, ADCITAFEAN ) " +
                    "values(" +
                    "'"+ insertAdcitas.Adcitacons + "','"+ insertAdcitas.Geespecodi + "', '"+ insertAdcitas.Gemedicodi+ "', '"+ insertAdcitas.Faservcodi + "', '"+ insertAdcitas.Adpaciiden+ "'," +
                    "'"+ insertAdcitas.Adconscodi + "', CTOD('" + insertAdcitas.Adfechcita.ToString("MM/dd/yyyy")+ "'), '" + insertAdcitas.Adhorainic + "', '" + insertAdcitas.Adhorafina + "', "+ insertAdcitas.Adduraminu.ToString() + ", '" + insertAdcitas.Adconsdisp + "', '" + insertAdcitas.Adcitaest + "','" + insertAdcitas.Adanulcodi + "', " +
                    "'" + insertAdcitas.Ctadmicodi + "', '" + insertAdcitas.Ctcontcodi + "',CTOD('" + insertAdcitas.Fechasoli.ToString("MM/dd/yyyy") + "'), '" + insertAdcitas.Geusuacreo + "', '" + insertAdcitas.Adingrcons + "', '" + insertAdcitas.Faorsecons + "', '" + insertAdcitas.Coconscons + "','" + insertAdcitas.Faprogcodi + "', " +
                    "'"+ insertAdcitas.Adcodanula+ "',CTOD('" + insertAdcitas.Fechprefpa.ToString("MM/dd/yyyy") + "'),'"+ insertAdcitas.Adcitaande + "', '" + insertAdcitas.Geusuacoan + "', '" + insertAdcitas.Adciticodi + "', {//}, {//} " +
                    ")";

                // Ejecutar la consulta utilizando Dapper
                int rowsAffected = dbConnection.Execute(insertQuery);

                if (rowsAffected > 0)
                {
                    insertCita = true;
                    obj_Addispmed_Query.UpdateAddispmed(obj_Addispmed);
                }
                dbConnection.Close();
            }

            return insertCita;
        }
    }
}
