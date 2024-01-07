using Microsoft.AspNetCore.Mvc;
using Play_investe.DTO;
using Play_investe.Entity;
using Play_investe.Interface;
using StoreFIAP.DTO;
using StoreFIAP.Entity;
using StoreFIAP.Interface;
using UserTemplate.Services;

namespace Play_investe.Controllers
{
    [ApiController]
    [Route("account")]
    public class AccountController : ControllerBase
    {

        private IAccountRepository _accontRepository;
        private readonly ILogger<AccountController> _logger;

        public AccountController(IAccountRepository accontRepository, ILogger<AccountController> logger )
        {
            _accontRepository = accontRepository;
            _logger = logger;
           
        }

        /// <summary>
        /// Cria um novo usuário.
        /// </summary>
        /// <param name="SaveAccountDTO"></param>
        /// <returns></returns>     

        [HttpPost("saveAccount")]
        public IActionResult SaveAccount(SaveAccountDTO accountDTO)
        {
            _accontRepository.Save(new Account());

            var message = $"User {accountDTO.AccountNumber} created with sucess!";
            _logger.LogWarning(message);
            return Ok(message);
        }
    }
}
