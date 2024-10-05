//using System.Net.Http;
//using Microsoft.AspNetCore.Http;

using Dapper;
using ProjectBlazorTurnos.Shared;
using System.Data;


namespace Repositorio
{
    public class GrabarClientes:IGrabarClientes
    {
        private readonly IDbConnection _dbconnection;
        public GrabarClientes(IDbConnection dbconnection)
        {
            _dbconnection = dbconnection;
        }

        public async Task<bool> InsertClientes(Models_Clientes_Turnos ClientesTurnos)
        {
            try
            {
                //LOS ARROBAS SOLO SIRVEN EN SQL SERVER
                //EJEMPLO:
                ///var sql = @"Insert into contactos (ID,FIRTSNAME,LASTNAME,PHONE,ADDRESS) values 
                //(@ID,@FIRTSNAME,@LASTNAME,@PHONE,@ADDRESS)"

                //string sql = @"delete from TABLE_CLIENTES_TURNOS where STRCEDULA='" + ClientesTurnos.STRCEDULA + "'";
                _dbconnection.Open();          

                string sql = @"Insert into TABLE_CLIENTES_TURNOS (STRCEDULA,STRCODIGOTIPOPERSONA,STRCODIGOTIPODOCUMENTO,STRNOMBRES,STRAPELLIDOS,STRTELEFONOFIJO,STRTELEFONOCELULAR,STREMAIL)
                          values 
                          ('" + ClientesTurnos.STRCEDULA + "','" + ClientesTurnos.STRCODIGOTIPOPERSONA + "','" + ClientesTurnos.STRCODIGOTIPODOCUMENTO + "','" + ClientesTurnos.STRNOMBRES + "','" + ClientesTurnos.STRAPELLIDOS + "','" + ClientesTurnos.STRTELEFONOFIJO + "','" + ClientesTurnos.STRTELEFONOCELULAR + "','" + ClientesTurnos.STREMAIL + "')";

                //await _dbconnection.ExecuteAsync(sql, new { ClientesTurnos.STRCEDULA });

                var resulttado = await _dbconnection.ExecuteAsync(sql, new
                {
                    ClientesTurnos.STRCEDULA,
                    ClientesTurnos.STRCODIGOTIPOPERSONA,
                    ClientesTurnos.STRCODIGOTIPODOCUMENTO,
                    ClientesTurnos.STRNOMBRES,
                    ClientesTurnos.STRAPELLIDOS,
                    ClientesTurnos.STRTELEFONOFIJO,
                    ClientesTurnos.STRTELEFONOCELULAR,
                    ClientesTurnos.STREMAIL
                });

                return resulttado > 0;
            }
            catch (Exception e)
            {

                throw e;
            }
            finally 
            {
                _dbconnection.Close(); 
            }
        }


        public async Task<bool> GrabarCita(Models_Clientes_Citas Models_Clientes_Citasx)
        {
            
            //var yearsystem = DateTime.Today.Year;
            //var monthsystem = DateTime.Today.Month;
            //var daysystem = DateTime.Today.Day;

            //string fechasistema = yearsystem + "/" + monthsystem.ToString().PadLeft(2, '0') + "/" + daysystem.ToString().PadLeft(2, '0');

            string horasystem = DateTime.Now.ToString("h:mm:ss tt").ToString();
            Models_Clientes_Citasx.STRFECHAREALATENCION = horasystem;

            try
            {

               string sql = @"Insert into TABLE_ASESOR_HORARIO (STRCODIGOASESOR,STRCODIGOHORARIO,STRFECHARESERVA,STRCEDULACLIENTE,STRCODIGOLUGARATENCION,STRESTADOATENCION,STRCODIGORESERVA,STRHORARESERVA)
                          values 
                          ('" + Models_Clientes_Citasx.STRCODIGOASESORASIGNADO + "','" + Models_Clientes_Citasx.STRHORARESERVA + "','" + Models_Clientes_Citasx.STRFECHARESERVA + "','" + Models_Clientes_Citasx.STRCEDULA + "','" + Models_Clientes_Citasx.STRCODIGOLUGARATENCION + "',1" + ",'" + Models_Clientes_Citasx.STRCODIGORESERVA + "','" + Models_Clientes_Citasx.STRFECHAREALATENCION + "')";


                var resulttado = await _dbconnection.ExecuteAsync(sql, new
                {
                    Models_Clientes_Citasx.STRCODIGOASESORASIGNADO,
                    Models_Clientes_Citasx.STRHORARESERVA,
                    Models_Clientes_Citasx.STRFECHARESERVA,
                    Models_Clientes_Citasx.STRCEDULA,
                    Models_Clientes_Citasx.STRCODIGOLUGARATENCION,
                    Models_Clientes_Citasx.STRCODIGORESERVA,
                    Models_Clientes_Citasx.STRFECHAREALATENCION
                });

                return resulttado > 0;
            }
            catch (Exception e)
            {

                throw e;
            }
            finally { _dbconnection.Close(); }
        }


        public async Task DeleteReserva(string strcodigoreserva)
        {
            var yearsystem = DateTime.Today.Year;
            var monthsystem = DateTime.Today.Month;
            var daysystem = DateTime.Today.Day;

            string fechasistema = yearsystem + "/" + monthsystem.ToString().PadLeft(2, '0') + "/" + daysystem.ToString().PadLeft(2, '0');

            string horasystem = DateTime.Now.ToString("h:mm:ss tt").ToString();

            var sql = @"update table_asesor_horario set STRESTADOATENCION='2',STROBSERVACION='Anulado por el usuario cliente',STRFECHAATENCION='" + fechasistema + "', DTRHORSATECION='" + horasystem + "' WHERE trim(strcodigoreserva)=trim('" + strcodigoreserva + "')";

            //var sql = @"delete from table_asesor_horario where rtrim(ltrim(strcodigoreserva))=rtrim(ltrim('" + strcodigoreserva + "'))";

            try
            {
                await _dbconnection.ExecuteAsync(sql, new
                {
                    strcodigoreserva
                });
            }
            catch (Exception E)
            {

                throw;
            }
           
        }


        public async Task ActualizacionAtencionCliente(string strcodigoreserva,string estado, string mensaje)
        {
            var yearsystem = DateTime.Today.Year;
            var monthsystem = DateTime.Today.Month;
            var daysystem = DateTime.Today.Day;

            string fechasistema = yearsystem + "/" + monthsystem.ToString().PadLeft(2, '0') + "/" + daysystem.ToString().PadLeft(2, '0');

            string horasystem = DateTime.Now.ToString("h:mm:ss tt").ToString();

            var sql = @"update table_asesor_horario set STRESTADOATENCION='" + estado + "',STROBSERVACION='" + mensaje + "',STRFECHAATENCION='" + fechasistema + "', DTRHORSATECION='" + horasystem + "' WHERE trim(strcodigoreserva)=trim('" + strcodigoreserva + "')";

            //var sql = @"delete from table_asesor_horario where rtrim(ltrim(strcodigoreserva))=rtrim(ltrim('" + strcodigoreserva + "'))";

            await _dbconnection.ExecuteAsync(sql, new
            {
                strcodigoreserva
            });
        }

    }
}
