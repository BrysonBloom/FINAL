namespace FINAL.Controllers
{
    [Route("api/[controller]")]
    public class VaultsController : Controller
    {
        private readonly VaultsService _VaultsService;
        private readonly Auth0Provider _auth;

        public VaultsController(VaultsService vaultsService, Auth0Provider auth)
        {
            _VaultsService = vaultsService;
            _auth = auth;
        }

        [HttpGet]
        public async Task<ActionResult<List<Vault>>> getVaults(){
            try 
            {
                Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
                List<Vault> vaults = _VaultsService.getVaults(userInfo.Id);
                return Ok(vaults);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Vault>> createVault([FromBody] Vault vaultData)
        {
            try 
            {
                Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
                vaultData.CreatorId = userInfo.Id;
                Vault vault = _VaultsService.createVault(vaultData, userInfo);
                return Ok(vault);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Vault>> getVaultsById(int id)
        {
            try 
            {
                Account useriInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);

              Vault vault = _VaultsService.getVaultById(id, useriInfo?.Id);
              return Ok(vault);
            }
            catch (Exception e)
            {
              return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<Vault>> editVault([FromBody] Vault updateData, int id)
        {
            try 
            {
                Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
                updateData.CreatorId = userInfo.Id;
                updateData.Id = id;
                Vault vault = _VaultsService.updateVault(id, updateData);
                return Ok(vault);
            }
            catch (Exception e)
            {
              return BadRequest(e.Message);
            }
        }


        [HttpDelete("{id}")]
        [Authorize]

        public async Task<ActionResult<Vault>> DeleteVault(int id)
        {
            try 
            {
                Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
                Vault Vault = _VaultsService.deleteVault(id, userInfo.Id);
                return Ok(Vault);
            }
            catch (Exception e)
            {
              return BadRequest(e.Message);
            }
        }
    }
}