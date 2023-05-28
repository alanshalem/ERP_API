using ERP_API.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Collections.ObjectModel;

namespace ERP_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] //[controller] se traducira automaticamente a Customer
    public class ClientController : ControllerBase
    {
        [HttpGet]
        public Collection<ClientEntity> GetClient()
        {
            Collection<ClientEntity> clients = new Collection<ClientEntity>();
            using (var cnn = new SqlConnection(""))
            {
                using (var adaptador = new SqlDataAdapter("SELECT * FROM dbo.cliente;", cnn))
                {
                    var reader = adaptador.SelectCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        ClientEntity clientObject = new ClientEntity();
                        clientObject.id = reader.GetInt32(0);
                        clientObject.name = reader.GetString(1);
                        clients.Add(clientObject);
                    }
                }
            }
            return clients;

        }
    }
}
