using Dapper;
using ProjectBlazorTurnos.Server.Context;
using ProjectBlazorTurnos.Shared;
using Radzen;

namespace ProjectBlazorTurnos.Server.Repositories
{
    public class ServicioCliente : IServicioCliente
    {
        private readonly DapperContext _context;
        public ServicioCliente(DapperContext context) => _context = context;
        public async Task<IEnumerable<ModelsCancelaciones>> GetAllConsultaServicioCliente()
        {
            var sql = @"SELECT t1.strfechareserva,T3.ORDEN,t3.strhorario,t1.strcodigoreserva,t4.STRNOMBREASESOR as STRASESOR,T5.STRLUGARATENCION STRSEDE,T6.STRNOMBRES + ' ' + T6.STRAPELLIDOS AS STRNOMBRECLIENTE
                         FROM table_asesor_horario T1 LEFT JOIN table_CLIENTES_TURNOS T2 ON T1.strcedulacliente=t2.strcedula 
                         INNER JOIN TABLE_HORARIOS T3 ON t3.strcodigohorario=t1.strcodigohorario 
                         INNER JOIN table_asesor T4 ON t4.strcodigoasesor=t1.strcodigoasesor 
                         INNER JOIN table_lugar_atencion T5 ON t5.strcodigo=t1.strcodigolugaratencion
                         INNER JOIN TABLE_CLIENTES_TURNOS T6 ON T6.STRCEDULA=T1.STRCEDULACLIENTE
                         WHERE t1.STRESTADOATENCION=1  ORDER BY t1.strfechareserva,T3.ORDEN";

            using (var connection = _context.CreateConnection())
            {
                var companies = await connection.QueryAsync<ModelsCancelaciones>(sql);

                return companies.ToList();
            }
        }
    }
}
