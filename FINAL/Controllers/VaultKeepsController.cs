namespace FINAL.Controllers
{
    [Route("api/[controller]")]
    public class VaultKeepsController : Controller
    {
        private readonly VaultKeepsService _vaultKeepsService;
        private readonly Auth0Provider _auth;

        public VaultKeepsController(VaultKeepsService vaultKeepsService, Auth0Provider auth)
        {
            _vaultKeepsService = vaultKeepsService;
            _auth = auth;
        }
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<VaultKeep>> createVaultKeep([FromBody] VaultKeep newVaultKeep )
        {
            try 
            {
              Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
                newVaultKeep.CreatorId = userInfo.Id;
                VaultKeep vaultKeep = _vaultKeepsService.createVaultKeep(newVaultKeep); 
                return Ok(vaultKeep);
            }
            catch (Exception e)
            {
              return BadRequest(e.Message);
            }
        }
        [HttpDelete("{id}")]
        [Authorize]

        public async Task<ActionResult<VaultKeep>> DeleteVault(int id)
        {
            try 
            {
                Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
                VaultKeep VaultKeep = _vaultKeepsService.deleteVaultKeep(id, userInfo.Id);
                return Ok(VaultKeep);
            }
            catch (Exception e)
            {
              return BadRequest(e.Message);
            }
        }
    }
}