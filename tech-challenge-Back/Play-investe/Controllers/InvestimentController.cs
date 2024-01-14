using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Play_investe.DTO;
using Play_investe.Entity;
using Play_investe.Enums;
using Play_investe.Interface;
using Play_investe.Repository;
using System.Diagnostics.CodeAnalysis;
using System.Security.Claims;

namespace Play_investe.Controllers;

[ExcludeFromCodeCoverage]
[ApiController]
[Route("investiment")]
public class InvestimentController : ControllerBase
{ 
    
   
    private IInvestimentRepository _investimentRepository;
    private IUserRepository _userRepository;
    private IBoundRepository _boundRepository;
    private IAccountRepository _accountRepository;
    private ITransactionsBankRepository _transactionsBank;
    private readonly ILogger<InvestimentController> _logger;

    public InvestimentController(
        IInvestimentRepository investimentRepository,
        ILogger<InvestimentController> logger,
       IBoundRepository boundRepository,
        IUserRepository userRepository,
       IAccountRepository acccountRepository,
        ITransactionsBankRepository transactionbank)
    {
        _investimentRepository = investimentRepository;
        _logger = logger;
        _boundRepository = boundRepository;
        _userRepository = userRepository;
        _accountRepository = acccountRepository;
        _transactionsBank = transactionbank;

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

        var transation = new TransactionsBank(DateTime.Now, investmentDTO.Value, "Transação interna Investimento", account.Id, account.Id);
          _transactionsBank.Save(transation);

        if(transation.Id > 0)
        {
            account.Balance = account.Balance - transation.Amount;
        }

        var bound = _boundRepository.GetById(investmentDTO.IdBound);        
         
        var dueDate = bound.GetDueDate(bound.LiquidityType);

        var investiment = new Investment(dueDate, investmentDTO.Value, bound, account);
         _investimentRepository.Save(investiment);

        var message = $"Valor investido com sucesso, disponivel para saque no dia {dueDate}" ;

        return Ok(investiment);
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

        List<Bound> bounds = new List<Bound>();

        investments.ForEach(investimento =>
        {
            Bound bound = _boundRepository.GetById(investimento.IdBound);

            bound.Investments = null;
            if (bound != null)
            {
                bounds.Add(bound);
            }
        });


        investments.ForEach(investment => investment.Account = null);

        for (int i = 0; i < investments.Count; i++)
        {
            investments[i].Bound = bounds.ElementAtOrDefault(i);
        }

        return Ok(  investments  );
    }

}


