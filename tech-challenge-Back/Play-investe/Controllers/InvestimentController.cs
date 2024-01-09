using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Play_investe.DTO;
using Play_investe.Entity;
using Play_investe.Enums;
using Play_investe.Interface;
using Play_investe.Repository;
using System.Security.Claims;

namespace Play_investe.Controllers;


[ApiController]
[Route("investiment")]
public class InvestimentController : ControllerBase
{ 
    
   
    private IInvestimentRepository _investimentRepository;
    private IUserRepository _userRepository;
    private IBoundRepository _boundRepository;
    private IAccountRepository _accountRepository;
    private readonly ILogger<InvestimentController> _logger;

    public InvestimentController(
        IInvestimentRepository investimentRepository,
        ILogger<InvestimentController> logger,
       IBoundRepository boundRepository,
        IUserRepository userRepository,
       IAccountRepository acccountRepository)
    {
        _investimentRepository = investimentRepository;
        _logger = logger;
        _boundRepository = boundRepository;
        _userRepository = userRepository;
        _accountRepository = acccountRepository;

    }


    [HttpPost("saveInvestiment")]
    [Authorize]
    public IActionResult SaveInvestiment(SaveInvestmentDTO investmentDTO)
    {
        var userEmail = HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;

        var user = _userRepository.GetUserByEmail(userEmail);

        var account = _accountRepository.GetUserFullAccountInformation(user.Id);

        if(user == null)
            return NotFound("Usuário não encontrado!");

        if (account == null)
            return NotFound("Conta não encontrada!");

        var bound = _boundRepository.GetById(investmentDTO.IdBound);        
         
        var dueDate = GetDueDate(bound.LiquidityType);

        _investimentRepository.Save(new Investment(dueDate, investmentDTO.Value, bound, account));

        var message = $"Valor investido com sucesso, disponivel para saque no dia {dueDate}" ;

        return Ok(message);
    }

    private DateTime GetDueDate(LiquidityType liquidityType)
    {
        var aquisitionDay = DateTime.Now;        
        int diasLiquidez = (int)liquidityType;
         
        var dueDate = aquisitionDay.AddDays(diasLiquidez);

        return dueDate;
    }

    [HttpGet("getInvestimentsInformation")]
    [Authorize]
    public IActionResult GetInvestimentsInformation()
    {
        var userEmail = HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;

        var user = _userRepository.GetUserByEmail(userEmail);

        if (user == null)
            return NotFound("Usuario não encontrado!");

        var account = _accountRepository.GetUserFullAccountInformation(user.Id);

        var investments = _investimentRepository.GetInvestment(account.Id);

        investments.ForEach(investment => investment.Account = null);

        return Ok(investments);
    }

}


