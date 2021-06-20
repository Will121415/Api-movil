using BLL;
using DAl;
using Microsoft.AspNetCore.Mvc;
using api_movil.Models;

namespace api_movil.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class LoginController: ControllerBase
    {
        private UserService _userService;

        public LoginController(PulpFreshContext freshContext)
        {
	        _userService = new UserService(freshContext);
        }

        [HttpPost]
        public IActionResult Login([FromBody]LoginInputModel model)
        {
            var response = _userService.Validate(model.UserName, model.Password);
            if (response.Object == null) return BadRequest("Username or password is incorrect");
            return Ok(new LoginViewModel(response.Object));
        }
    }
}