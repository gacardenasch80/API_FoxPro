using System;
using System.Collections.Generic;
using System.Linq;
using MedisoftCore;
using MedisoftCore.Services;
using MedisoftCore.Entities;
using MedisoftCore.QueryFilters;

namespace MedisoftFE
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            string connectionStringFac = @"Provider=VFPOLEDB;Data Source=C:\Medisoft\DATOS\facturacion.dbc;Collating Sequence=MACHINE;Exclusive=No;";
            string connectionStringGen = @"Provider=VFPOLEDB;Data Source=C:\Medisoft\DATOS\generales.dbc;Collating Sequence=MACHINE;Exclusive=No;";
            string connectionStringCit = @"Provider=VFPOLEDB;Data Source=C:\Medisoft\DATOS\citas.dbc;Collating Sequence=MACHINE;Exclusive=No;";
            string connectionStringCon = @"Provider=VFPOLEDB;Data Source=C:\Medisoft\DATOS\contratacion.dbc;Collating Sequence=MACHINE;Exclusive=No;";
            string connectionStringAdm = @"Provider=VFPOLEDB;Data Source=C:\Medisoft\DATOS\admision.dbc;Collating Sequence=MACHINE;Exclusive=No;";


            List<Faprogpyp> listFaprogpyp = new List<Faprogpyp>();
            var obj_Faprogpyp = new FaprogpypService(connectionStringFac);
            listFaprogpyp = obj_Faprogpyp.GetFaprogpyp();

            List<Fafactura> listFafactura = new List<Fafactura>();
            var obj_Fafactura = new FafacturaService(connectionStringFac);
            listFafactura = obj_Fafactura.GetFacturas();

            List<Faservicio> listFaservicio = new List<Faservicio>();
            var obj_Faservicio = new FaservicioService(connectionStringFac);
            listFaservicio = obj_Faservicio.GetFaservicio();

            List<Geespecial> listGeespecial = new List<Geespecial>();
            var obj_Geespecial = new GeespecialService(connectionStringGen);
            listGeespecial = obj_Geespecial.GetGeespecial();

            List<Gemedicos> listGemedicos = new List<Gemedicos>();
            var obj_Gemedicos = new GemedicosService(connectionStringGen);
            listGemedicos = obj_Gemedicos.GetGemedicos();

            //List<Addispmed> listAddispmed = new List<Addispmed>();
            //var obj_Addispmed = new AddispmedService(connectionStringCit);
            //listAddispmed = obj_Addispmed.GetAddispmed();

            //List<Adcitas> listAdcitas = new List<Adcitas>();
            //var obj_Adcitas = new AdcitasService(connectionStringCit);
            //listAdcitas = obj_Adcitas.GetAdcitas();

            //List<Ctadminist> listCtadminist = new List<Ctadminist>();
            //var obj_Ctadminist = new CtadministService(connectionStringCon);
            //listCtadminist = obj_Ctadminist.GetCtadminist();

            //List<Consecutivos> listConsecutivos = new List<Consecutivos>();
            //var obj_Consecutivos = new ConsecutivosService(connectionStringAdm);
            //listConsecutivos = obj_Consecutivos.GetConsecutivos();


            //List<Addispmed> listAddispmed_Query = new List<Addispmed>();
            //var obj_Addispmed_Query = new AddispmedService(connectionStringCit);
            //var obj_filter = new AddispmedQueryFilter();
            //obj_filter.Geespecodi = "02";
            //obj_filter.Gemedicodi = "LAJB";
            //obj_filter.FechaInicio = DateTime.Now;//DateTime.Now.AddMonths(-5);
            //obj_filter.FechaFin = DateTime.Now;
            //listAddispmed_Query = obj_Addispmed_Query.GetAddispmedFilter(obj_filter);

            //var obj_AdadmipaciFilter = new AdadmipaciQueryFilter();
            //obj_AdadmipaciFilter.Adpaciiden = "1005183548";
            //obj_AdadmipaciFilter.Ctadmicodi = "308";
            //List<Adadmipaci> listAdadmipaci = new List<Adadmipaci>();
            //var obj_Adadmipaci = new AdadmipaciService(connectionStringAdm);
            //listAdadmipaci = obj_Adadmipaci.GetAdadmipaci(obj_AdadmipaciFilter);

            //var obj_Filter = new AdpacienteQueryFilter();
            //obj_Filter.Adpaciiden = "1005183548";
            //List<Adpaciente> listAdpaciente = new List<Adpaciente>();
            //var obj_Adpaciente = new AdpacienteService(connectionStringAdm);
            //listAdpaciente = obj_Adpaciente.GetAdpaciente(obj_Filter);

            //List<Consecutivos> listConsecutivos = new List<Consecutivos>();
            //var obj_Consecutivos = new ConsecutivosService(connectionStringCit);
            //var listConsecutivos = obj_Consecutivos.ActualizarConsecutivo("fafactura");

            //var obj_Consecutivos = new ConsecutivosService(connectionStringAdm);
            //string Adcitacons = obj_Consecutivos.f_consecutivo("adcitas");

            //var obj_FilterCitas = new AdcitasQueryFilter();            
            //obj_FilterCitas.ConnectionStringAdm = connectionStringAdm;
            //obj_FilterCitas.Tabla = "adcitas";
            //obj_FilterCitas.Adpaciiden = "1005183548";            
            //obj_FilterCitas.Addispcons = "01605659";
            //obj_FilterCitas.Adadpacons = "00554316";
            //obj_FilterCitas.Faprogcodi = "0";
            //var obj_Adcitas = new AdcitasService(connectionStringCit);
            //var listAdcitas = obj_Adcitas.CreateAdcitas(obj_FilterCitas);

        }

    }
}
