using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Play_investe.DTO;
using Play_investe.Entity;
using Play_investe.Enums;
using Play_investe.Interface;
using UserTemplate.Services;

namespace Play_investe.Controllers
{
    [ApiController]
    [Route("bound")]
    public class BoundController :ControllerBase
    {
        private IUserRepository _userRepository;
        private IAccountRepository _accontRepository;
        
        private readonly PasswordHasherService _passwordHasher;
        private IAddressRepository _addressRepository;

        private IBoundRepository _boundRepository;
        private readonly ILogger<BoundController> _logger;

        public BoundController(
            IBoundRepository boundRepository,
            IUserRepository userRepository,
            ILogger<BoundController> logger,
            PasswordHasherService passwordHasher,
            IAccountRepository accontRepository,
             IAddressRepository addressRepository
            )
        {
            _boundRepository = boundRepository;
            _accontRepository = accontRepository;
            _userRepository = userRepository;
            _logger = logger;
            _passwordHasher = passwordHasher;
            _addressRepository = addressRepository;
        }


        /// <summary>
        /// Cria um novo titulo.
        /// </summary>
        /// <param name="SaveAccountDTO"></param>
        /// <returns></returns>     

        [HttpPost("saveBound")]
        public IActionResult SaveBound(SaveBoundDTO saveBoundDTO)
        {
                        
           _boundRepository.Save(new Bound(saveBoundDTO.LiquidityType, saveBoundDTO.Index, saveBoundDTO.Percent));
                    
            var message = $"Titulo criado com sucesso !";
            _logger.LogWarning(message);
            return Ok(message);
        }



        /// <summary>
        /// Obtém todos os titulos, o método necessita de autenticação
        /// </summary>
        /// <returns></returns>
        /// <response code="200"> Retonar Sucesso</response>
        /// <response code="401"> Não Autenticado</response>
        /// <response code="403"> Ñão Autorizado</response>
        [Authorize]       
        [HttpGet("getAllBound")]
        public IActionResult GetAllBound()
        {
            return Ok(_boundRepository.GetAll());
        }

        /// <summary>
        /// Obtém todos os titulos do tipo Fixo, o método necessita de autenticação
        /// </summary>
        /// <returns></returns>
        /// <response code="200"> Retonar Sucesso</response>
        /// <response code="401"> Não Autenticado</response>
        /// <response code="403"> Ñão Autorizado</response>
        [Authorize]
        [HttpGet("getAllBoundFixed")]
        public IActionResult GetAllBoundFixed()
        {
            return Ok(_boundRepository.GetFixedBound());
        }

        /// <summary>
        /// Obtém todos os titulos do tipo Indexados ao Selic, o método necessita de autenticação
        /// </summary>
        /// <returns></returns>
        /// <response code="200"> Retonar Sucesso</response>
        /// <response code="401"> Não Autenticado</response>
        /// <response code="403"> Ñão Autorizado</response>
        [Authorize]
        [HttpGet("getAllBoundIndexed")]
        public IActionResult GetAllBoundIndexed()
        {
            return Ok(_boundRepository.GetIndexedBound());
        }

        /// <summary>
        ///  Obtém titulo por ID metodo necessita de autenticação
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200"> Retonar Sucesso</response>
        /// <response code="401"> Não Autenticado</response>
        /// <response code="403"> Ñão Autorizado</response>
        /// <response code="404"> Usuário não encontrado</response>
        [Authorize]
       // [Authorize(Roles = Permitions.Admin)]
        [HttpGet("getBoundById/{id}")]
        public IActionResult GetBoundById(int id)
        {
            var bound = _boundRepository.GetById(id);

            if (bound == null)
                return NotFound("Titulo não encontrado!");

            return Ok(bound);
        }

        /// <summary>
        /// Deleta usuário, o método necessita de permissão de Administrador.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200"> Retonar Sucesso</response>
        /// <response code="401"> Não Autenticado</response>
        /// <response code="403"> Ñão Autorizado</response>
        /// <response code="404"> Usuário não encontrado</response>
        [Authorize]
        [Authorize(Roles = Permitions.Admin)]
        [HttpDelete("deleteBound/{id}")]
        public IActionResult DeleteBound(int id)
        {

            var bound = _boundRepository.GetById(id);

            if (bound == null)
            {
                return NotFound("Titulo não encontrado!");
            }
            else
            {
                _boundRepository.Delete(id);
                return Ok("Titulo deletado com sucesso");
            }
        }

    }
}
