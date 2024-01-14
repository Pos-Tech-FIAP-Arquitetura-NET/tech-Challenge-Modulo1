using Microsoft.AspNetCore.Mvc;
using Play_investe.DTO;
using Play_investe.Entity;
using Play_investe.Interface;
using Play_investe.DTO;
using Play_investe.Entity;
using Play_investe.Interface;
using UserTemplate.Services;
using Play_investe.Repository;
using System.Security.Claims;
using Microsoft.Extensions.Configuration.UserSecrets;
using System.Diagnostics.CodeAnalysis;

namespace Play_investe.Controllers
{
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Route("account")]
    public class AccountController : ControllerBase
    {

        private IAccountRepository _accontRepository;
        private readonly ILogger<AccountController> _logger;
        private IUserRepository _userRepository;

        public AccountController(IAccountRepository accontRepository, ILogger<AccountController> logger , IUserRepository userRepository)
        {
            _accontRepository = accontRepository;
            _logger = logger;
            _userRepository = userRepository;


        }

        /// <summary>
        /// Cria um novo usuário.
        /// </summary>
        /// <param name="SaveAccountDTO"></param>
        /// <returns></returns>     

        [HttpPost("saveAccount")]
        public IActionResult SaveAccount(int userId)
        {
            var account = new Account(userId);
            _accontRepository.Save(account);

            var message = $"User {account.AccountNumber} created with sucess!";
            _logger.LogWarning(message);
            return Ok(message);
        }

        /// <summary>
        /// Recuperar informações da conta e do usuario
        /// </summary>
        /// <param name="SaveAccountDTO"></param>
        /// <returns></returns>     

        [HttpGet("getAccountInformation")]
        public IActionResult GetAccountInformation()
        {
            var userEmail = HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;

            var user = _userRepository.GetUserByEmail(userEmail);

            if (user == null)
            {
                var message = "Usuário não encontrado ou inválido";
                _logger.LogWarning(message);
                return NotFound(message);
            }

            var account = _accontRepository.GetUserFullAccountInformation(user.Id);

            if (account == null)
            {
                var message = "Conta não encontrada para o usuário";
                _logger.LogWarning(message);
                return NotFound(message);
            }

            user.Account = null;
            account.User = null;

            var result = new
            {
                user = user,
                account = account
            };

            return Ok(result);


 
        }
    }
}
