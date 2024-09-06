﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using TableDependency.SqlClient;
//using TableDependency.SqlClient.Base.EventArgs;

using Dapper;
using System.Data;
using ProjectBlazorTurnos.Shared;

namespace Repositorio
{
    public class ListaRepositorio : IListasRepositorio
    {
        private readonly IDbConnection _dbconnection;

        public ListaRepositorio(IDbConnection dbconnection)
        {
            _dbconnection = dbconnection;

        }


        public async Task<IEnumerable<ModelsTipoPersona>> GetAllTipoPersona()
        {
            var sql = @"select STRCODIGO,STRTIPOPERSONA from Table_Tipo_Persona ORDER BY STRTIPOPERSONA";

            return await _dbconnection.QueryAsync<ModelsTipoPersona>(sql, new { });
        }

        public async Task<IEnumerable<ModelsTipoDocumento>> GetAllTipoDocumento()
        {
            var sql = @"select STRCODIGO,strtipodocumento from Table_Tipo_Documento order by strtipodocumento";

            return await _dbconnection.QueryAsync<ModelsTipoDocumento>(sql, new { });
        }

        public async Task<IEnumerable<ModelsLugarAtencion>> GetAllLugarAtencion()
        {
            var sql = @"select STRCODIGO,STRLUGARATENCION from TABLE_LUGAR_ATENCION WHERE STRESTADO=1 order by STRLUGARATENCION";

            return await _dbconnection.QueryAsync<ModelsLugarAtencion>(sql, new { });
        }

        public async Task<IEnumerable<MODELS_ASESOR_LUGAR>> GetAllLAsesorLugar(string? strcodigolugar)
        {
            var sql = @"SELECT T1.STRCODIGOASESOR,T2.strnombreasesor FROM TABLE_ASESOR_LUGAR T1
                        INNER JOIN TABLE_ASESOR T2 ON t1.strcodigoasesor=t2.strcodigoasesor
                        WHERE T2.STRESTADO=1 AND t1.STRCODIGOASERLUGAR='" + strcodigolugar + "'";

            return await _dbconnection.QueryAsync<MODELS_ASESOR_LUGAR>(sql, new { });
        }


        public async Task<IEnumerable<Models_Ocupacion>> GetAllLOCUPACION(Models_Parametros objparametros)
        {
            var sql = @"SELECT s.*  FROM Table_Horarios s  WHERE NOT EXISTS (SELECT * FROM table_asesor_horario a 
                      WHERE s.strcodigohorario = a.strcodigohorario and a.strcodigoasesor='" + objparametros.strcodigoasesor + "' AND a.STRESTADOATENCION<>2 and a.STRESTADOATENCION<>3 and a.STRESTADOATENCION<>4 and a.strfechareserva='" + objparametros.strfechareserva + "') order by s.ORDEN";

            return await _dbconnection.QueryAsync<Models_Ocupacion>(sql, new { });
        }

        public async Task<IEnumerable<ModelsCancelaciones>> GetAllConsultaHorariosReservados(Models_Parametros objparametros)
        {
            var sql = @"SELECT t1.strfechareserva,T3.ORDEN,t3.strhorario,t1.strcodigoreserva,t4.STRNOMBREASESOR as STRASESOR,T5.STRLUGARATENCION STRSEDE
                        FROM table_asesor_horario T1 LEFT JOIN table_CLIENTES_TURNOS T2 ON T1.strcedulacliente=t2.strcedula 
                        AND t2.stremail= '" + objparametros.stremail + "' INNER JOIN TABLE_HORARIOS T3 ON t3.strcodigohorario=t1.strcodigohorario INNER JOIN table_asesor T4 ON t4.strcodigoasesor=t1.strcodigoasesor INNER JOIN table_lugar_atencion T5 ON t5.strcodigo=t1.strcodigolugaratencion WHERE t1.STRESTADOATENCION=1 and t1.strcedulacliente= '" + objparametros.strcodigoasesor + "' and t1.strfechareserva >= '" + objparametros.strfechareserva + "' ORDER BY t1.strfechareserva,T3.ORDEN";

            return await _dbconnection.QueryAsync<ModelsCancelaciones>(sql, new { });
        }

        public async Task<IEnumerable<ModelsCancelaciones>> GetAllConsultaServicioCliente()
        {
            var sql = @"SELECT t1.strfechareserva,T3.ORDEN,t3.strhorario,t1.strcodigoreserva,t4.STRNOMBREASESOR as STRASESOR,T5.STRLUGARATENCION STRSEDE
                         FROM table_asesor_horario T1 LEFT JOIN table_CLIENTES_TURNOS T2 ON T1.strcedulacliente=t2.strcedula 
                         INNER JOIN TABLE_HORARIOS T3 ON t3.strcodigohorario=t1.strcodigohorario 
                         INNER JOIN table_asesor T4 ON t4.strcodigoasesor=t1.strcodigoasesor 
                         INNER JOIN table_lugar_atencion T5 ON t5.strcodigo=t1.strcodigolugaratencion
                         WHERE t1.STRESTADOATENCION=1  ORDER BY t1.strfechareserva,T3.ORDEN";

            return await _dbconnection.QueryAsync<ModelsCancelaciones>(sql);
        }

        public async Task<IEnumerable<ModelsValidacionCliente>> GetUser(Models_Parametros objparametros)
        {
            var sql = @"select COUNT(*) AS STRCODIGORESERVA  from table_asesor WHERE strcedula='" + objparametros.strcodigoasesor + "' AND UPPER(stremail)=UPPER('" + objparametros.stremail + "')";

            return await _dbconnection.QueryAsync<ModelsValidacionCliente>(sql, new { });
        }

    }
}
