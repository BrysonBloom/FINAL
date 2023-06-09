namespace FINAL.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    private readonly AccountService _accountService;
    private readonly Auth0Provider _auth0Provider;

    public AccountController(AccountService accountService, Auth0Provider auth0Provider)
    {
        _accountService = accountService;
        _auth0Provider = auth0Provider;
    }

    [HttpPut]
    [Authorize]

    public async Task<ActionResult<Account>> Edit([FromBody] Account updateData)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            Account account = _accountService.Edit(updateData, userInfo.Email);
            return Ok(account);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<Account>> Get()
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            return Ok(_accountService.GetOrCreateProfile(userInfo));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("vaults")]
    [Authorize]
    public async Task<ActionResult<List<Vault>>> getMyVaults()
    {
        Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
        List<Vault> vaults = _accountService.getVaultList(userInfo.Id);
        return Ok(vaults);
    }
}
