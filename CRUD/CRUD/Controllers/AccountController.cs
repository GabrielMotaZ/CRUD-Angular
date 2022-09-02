using CRUD.Dominio.models;
using CRUD.Service.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers;

[System.Web.Http.Route("CRUD")]
public class AccountController : ControllerApi
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost("Register")]
    public IActionResult Register(Account account)
    {
        Account loggedAccount = _accountService.Register(account);

        if (loggedAccount.ID == null)
        {
            return BadRequest();
        }
        else
        {
            return Ok(loggedAccount);
        }
    }
    
    [HttpPost("Login")]
    public IActionResult Login(Account account)
    {
        Account loggedAccount = _accountService.Login(account);

        if (loggedAccount.ID == null)
        {
            return NotFound();
        }
        else
        {
            return Ok(loggedAccount);
        }
    }

    [HttpGet("getLogins")]
    public IActionResult GetLogins()
    {
        Account account = new Account();

        IEnumerable<Account> accounts = _accountService.GetLogins(account);

        if (accounts.Count() == 0 || accounts == null)
        {
            return NotFound();
        }
        else
        {
            return Ok(accounts);
        }
    }
}
