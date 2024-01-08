using Microsoft.AspNetCore.Mvc;
using Play_investe.DTO;
using Play_investe.Interface;
using Play_investe.Services;
using UserTemplate.Services;

namespace Play_investe.Controllers
{
    [ApiController]
    [Route("login")]
    public class LoginController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService  _tokenService;
        private readonly PasswordHasherService _passwordHasher;

        public LoginController(IUserRepository userRepository, ITokenService tokenService, PasswordHasherService passwordHasher)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _passwordHasher = passwordHasher;
        }

        /// <summary>
        /// Rota de autenticação de Usuário
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost("login")]      
        public IActionResult Authenticate([FromBody ] LoginDTO login)
        {
            var user = _userRepository.ValidatedCredential(login.Email, login.Password);          

            if (user == null)
                return NotFound(new { message = "Email or Password invalid" });

            var token = _tokenService.GetToken(user);

            user.Password = null;

            return Ok(new
            {
                User = user,
                Token = token
            });

        }
    }
}
