using System.Collections.Generic;
using System.Linq;
using api_movil.Models;
using BLL;
using DAl;
using Entidad;
using Microsoft.AspNetCore.Mvc;

namespace api_movil.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController: ControllerBase
    {
        private readonly ClientService clientService;

        public ClientController(PulpFreshContext pulpFreshContext)
        {
            this.clientService = new ClientService(pulpFreshContext);
        }

        [HttpPost]
        public ActionResult<ClientViewModel> Post(ClientInputModel clientInput)
        {
            Client client = MapClient(clientInput);
            var response = clientService.Save(client);

            if (response.Error) return BadRequest(response.Menssage);

            return Ok(new ClientViewModel(response.Object));

        }
        [HttpGet("{clientId}")]
        public ActionResult<ClientViewModel> SearchById(string clientId)
        {
            var response =  clientService.SearchById(clientId);

            if(response.Object == null) return NotFound("Cliente no encontrado!");
            var client = new ClientViewModel(response.Object);
            return Ok(client);
        }

        private Client MapClient(ClientInputModel clientInput)
        {
            Client client = new Client();

            client.ClientId = clientInput.ClientId;
            client.Name = clientInput.Name;
            client.LastName = clientInput.LastName;
            client.Phone = clientInput.Phone;
            client.Address = clientInput.Address;
            client.Neighborhood = clientInput.Neighborhood;
            client.City = clientInput.City;
            client.Department = clientInput.Department;
            client.User =  MapUser(clientInput.User);

            return client;
        }
        private User MapUser(UserInputModel userInput)
        {
            User user = new User();
            user.UserName = userInput.UserName;
            user.Password = userInput.Password;
            user.Status = userInput.Status;
            user.Role = userInput.Role;

            return user;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ClientViewModel>> GetResult()
        {
            var response = clientService.GetConsult();

            if (response.List == null) return BadRequest(response.Menssage);

            var clients = response.List.Select(c => new ClientViewModel(c));

            return Ok(clients);

        }

        [HttpPut("change-status/{clientId}")]
        public ActionResult<ClientViewModel> ChangeStatus(string clientId)
        {
            var response =  clientService.ChangeStatus(clientId);

            if (response.Object == null) return BadRequest(response.Menssage);

            return Ok(new ClientViewModel(response.Object));
        }

        [HttpPut] 
        public ActionResult<ClientViewModel> Modify(ClientInputModel clientInput)
        {
            Client client = MapClient(clientInput);
            var response =  clientService.Modify(client);

            if (response.Error) return BadRequest(response.Menssage);

            return Ok(new ClientViewModel(response.Object));
        }
    }
}