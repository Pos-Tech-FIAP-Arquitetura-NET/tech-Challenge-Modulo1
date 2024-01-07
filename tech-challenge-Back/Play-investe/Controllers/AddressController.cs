using Microsoft.AspNetCore.Mvc;
using Play_investe.DTO;
using Play_investe.Entity;
using Play_investe.Interface;

namespace Play_investe.Controllers
{
    public class AddressController : ControllerBase
    {
        private IAddressRepository _addressRepository;
        private readonly ILogger<AddressController> _logger;

        public AddressController(IAddressRepository addressRepository, ILogger<AddressController> logger)
        {
            _addressRepository = addressRepository;
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
            _addressRepository.Save(new Address());

            var message = $"User {accountDTO.AccountNumber} created with sucess!";
            _logger.LogWarning(message);
            return Ok(message);
        }
    }
}
