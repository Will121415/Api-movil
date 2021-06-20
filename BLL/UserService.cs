using System.Linq;
using DAl;
using Entidad;

namespace BLL
{
    public class UserService
    {
        private readonly PulpFreshContext _context;
        public UserService(PulpFreshContext context)=> _context = context;
        public Response<User> Validate(string userName, string password) 
        {
            return new Response<User>(_context.Users.FirstOrDefault(t => t.UserName == userName && t.Password == password && t.Status == "Active"));
        }
    }
}