using System;
using System.Collections.Generic;
using System.Linq;
using DAl;
using Entidad;
using Microsoft.EntityFrameworkCore;

namespace BLL
{
    public class ClientService
    {
        private readonly PulpFreshContext context;

        public ClientService(PulpFreshContext pulpFreshContext)
        {
            context = pulpFreshContext;
        }

        public Response<Client> Save(Client client)
        {
            try {
                context.Add(client);
                context.SaveChanges();
                return new Response<Client>(client);
            } catch (Exception e) {

                return new Response<Client>($"Error del aplicacion: {e.Message}");
            }
        }
        public Response<Client> SearchById(string clientId)
        {
            try 
            {
                Client client = context.Clients.Include(u => u.User)
                                                .Where(c => c.ClientId == clientId).FirstOrDefault();
                return new Response<Client>(client);
            }
            catch (Exception e)
            {
                
                return new Response<Client>($"Error de la Aplicacion: {e.Message}");
            }
        }
        public Response<Client> SearchByUser(string userName)
        {
            try 
            {
                Client client = context.Clients.Include(u => u.User).Where(u => u.User.UserName == userName).FirstOrDefault();
                return new Response<Client>(client);
            }
            catch (Exception e)
            {
                
                return new Response<Client>($"Error de la Aplicacion: {e.Message}");
            }
        }

        public ResponseAll<Client> GetConsult()
        {
            try {
                IList<Client> clients = context.Clients.Include(u => u.User).ToList();
                return new ResponseAll<Client>(clients);
            } catch (Exception e) {
                return new ResponseAll<Client>($"Error del aplicacion: {e.Message}");
            }
        }

       public Response<Client> ChangeStatus(String clientId)
        {
            try{
                Client oldClient = context.Clients.Include(u => u.User)
                         .Where(c => c.ClientId == clientId).FirstOrDefault();
                if(oldClient != null)
                {
                    oldClient.User.Status = (oldClient.User.Status == "Active") ? "Inactive": "Active";
                    context.Users.Update(oldClient.User);
                    context.SaveChanges();
                }
                return new Response<Client>(oldClient);
            }
            catch (Exception e)
            {
                return new Response<Client>($"Error de la Aplicación: {e.Message}");
            }
        }

        public Response<Client> Modify(Client newClient)
        {
            try {
                var oldClient =  context.Clients.Include(c => c.User)
                            .Where(c => c.ClientId == newClient.ClientId).FirstOrDefault();

                if (oldClient != null)
                {
                    oldClient.ClientId =  newClient.ClientId;
                    oldClient.Name = newClient.Name;
                    oldClient.LastName = newClient.LastName;
                    oldClient.Phone =  newClient.Phone;
                    oldClient.Address = newClient.Address;
                    oldClient.Neighborhood = newClient.Neighborhood;
                    oldClient.City = newClient.City;
                    oldClient.Department =  newClient.Department;

                    var oldUser = oldClient.User;
                    oldUser.UserName = newClient.User.UserName;
                    oldUser.Password = newClient.User.Password;
                    oldUser.Role = newClient.User.Role;
                    oldUser.Status = newClient.User.Status;

                    oldClient.User = oldUser;

                    context.Clients.Update(oldClient);
                    context.Users.Update(oldUser);
                    context.SaveChanges();
                }
                

                return new Response<Client>(oldClient);
            } catch (Exception e ) {
                return new Response<Client>($"Error del aplicacion: {e.Message}");
            }
        }
    }
}