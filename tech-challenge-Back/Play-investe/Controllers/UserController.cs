using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Play_investe.Entity;
using Play_investe.Interface;
using Play_investe.DTO;
using Play_investe.Entity;
using Play_investe.Enums;
using Play_investe.Interface;
using System.Diagnostics.Metrics;
using System.IO;
using System.Reflection.Emit;
using System.Security.Claims;
using UserTemplate.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

[ApiController]
[Route("user")]
public class UserController : ControllerBase
{
    private IUserRepository _userRepository;
    private IAccountRepository _accontRepository;
    private readonly ILogger<UserController> _logger;
    private readonly PasswordHasherService _passwordHasher;
    private IAddressRepository _addressRepository;

    public UserController(
        IUserRepository userRepository,
        ILogger<UserController> logger,
        PasswordHasherService passwordHasher,
        IAccountRepository accontRepository,
         IAddressRepository addressRepository
        )
    {
        _accontRepository = accontRepository;
        _userRepository = userRepository;
        _logger = logger;
        _passwordHasher = passwordHasher;
        _addressRepository = addressRepository;
    }

    

    /// <summary>
    /// Cria um novo usuário.
    /// </summary>
    /// <param name="userDTO"></param>
    /// <returns></returns>     

    [HttpPost("saveUser")]
    public IActionResult SaveUser(SaveUserDTO userDTO)
    {

        if (_userRepository.IsEmailAlreadyRegistered(userDTO.Email))
        {
            var errorMessage = $"Error: Email {userDTO.Email} já esta cadastrado.";
            _logger.LogError(errorMessage);
            return BadRequest(errorMessage);
        }

        var newUser = new User(userDTO, _passwordHasher);
        _userRepository.Save(newUser);

        var newAccount = new Account(newUser.Id);
        _accontRepository.Save(newAccount);

        var newAddress = new Address(
                                userDTO.Street, 
                                userDTO.Number,
                                userDTO.ZipCode,
                                userDTO.City,
                                userDTO.State,
                                userDTO.Country,
                                newUser.Id);

        _addressRepository.Save(newAddress);
        var message = @$"Parabéns {userDTO.Name} você agora é cliente Play Investe !
                         Número da conta 
        {newAccount.AccountNumber}, Agencia {newAccount.Agency}";

        _logger.LogWarning(message);
        return Ok(newUser);
    }

    /// <summary>
    /// Obtém todos os usuários, o método necessita de autenticação e permissão de Administrador
    /// </summary>
    /// <returns></returns>
    /// <response code="200"> Retonar Sucesso</response>
    /// <response code="401"> Não Autenticado</response>
    /// <response code="403"> Ñão Autorizado</response>
    [Authorize]
    [Authorize(Roles = Permitions.Admin)]
    [HttpGet("getAllUser")]
    public IActionResult GetAllUser()
    {
        return Ok(_userRepository.GetAll());
    }

     


    /// <summary>
    ///  Obtém usuario por id, o método necessita de autenticação
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <response code="200"> Retonar Sucesso</response>
    /// <response code="401"> Não Autenticado</response>
    /// <response code="403"> Ñão Autorizado</response>
    /// <response code="404"> Usuário não encontrado</response>
    [Authorize]   
    [HttpGet("getUserById/{id}")]
    public IActionResult GetUserById(int id)
    {
        var user = _userRepository.GetById(id);

        if(user == null) 
            return NotFound("Usuário não encontrado!");

        return Ok(user);
    }
        

    /// <summary>
    /// Modifica email do usuário, método necessita de autenticação.
    /// </summary>
    /// <param name="id"></param>
    /// <response code="200"> Retonar Sucesso</response>
    /// <response code="401"> Não Autenticado</response> 
    /// <response code="404"> Usuário não encontrado</response>
    [Authorize]
    [HttpPatch("changeUserEmail")]
    public IActionResult ChangeUserEmail(string newEmail)
    {
        var userEmail = HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;

        var user = _userRepository.GetUserByEmail(userEmail);

        if (user == null)
        {
            return NotFound("Usuário não encontrado!");
        }
        else
        {                        
            user.Email = newEmail;
            user.UpdatedDate = DateTime.Now;
            _userRepository.Put(user);

            return Ok("Usuario alterado com sucesso");
        }               

      
    }

    /// <summary>
    /// Modifica a senha do usuário, método necessita de autenticação.
    /// </summary>
    /// <param name="id"></param>
    /// <response code="200"> Retonar Sucesso</response>
    /// <response code="401"> Não Autenticado</response> 
    /// <response code="404"> Usuário não encontrado</response>
    [Authorize]
    [HttpPatch("changePassword")]
    public IActionResult ChangePassword(string newPassword)
    {
        var userEmail = HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;

        var user = _userRepository.GetUserByEmail(userEmail);

        if (user == null)
        {
            return NotFound("Usuário não encontrado!");
        }
        else
        {
            var password = user.ChangeUserPassword(newPassword, _passwordHasher);
            user.Password = password;
            _userRepository.Put(user);

            return Ok("Senha alterada com sucesso");
        }
    }

    /// <summary>
    /// Obtem usuario logado.
    /// </summary>
    /// <param name="id"></param>
    /// <response code="200"> Retonar Sucesso</response>
    /// <response code="401"> Não Autenticado</response> 
    /// <response code="404"> Usuário não encontrado</response>
    [Authorize]
    [HttpGet("retrieveUser")]
    public IActionResult RetrieveUser()
    {
        var userEmail = HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;

        var user = _userRepository.GetUserByEmail(userEmail);        

        return Ok(user);
         
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
    [HttpDelete("deleteUser/{id}")]
    public IActionResult DeleteUser(int id)
    {        

        var user = _userRepository.GetById(id);

        if (user == null)
        {
            return NotFound("Usuário não encontrado!");
        }           
        else
        {
            _userRepository.Delete(id);
            return Ok("Usuario deletado com sucesso");
        }       
    }

    /// <summary>
    /// Desativa usuário, o método necessita de autenticação.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <response code="200"> Retonar Sucesso</response>
    /// <response code="401"> Não Autenticado</response>
    /// <response code="404"> Usuário não encontrado</response>
    [Authorize]    
    [HttpDelete("desactiveUser")]
    public IActionResult DesactiveUser()
    {
        var userEmail = HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;

        var user = _userRepository.GetUserByEmail(userEmail);

        if (user == null)
        {
            return NotFound("Usuário não encontrado ou desativado!");
        }
        else
        {
            user.DesactiveUser(user.Id);
            return Ok("Usuario deletado com sucesso");
        }

    }




}
