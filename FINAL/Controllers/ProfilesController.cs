namespace FINAL.Controllers
{
    [Route("api/[controller]")]
    public class ProfilesController : Controller
    {
        
        private readonly ProfilesService _profilesService;
        private readonly KeepsService _keepsService;
        private readonly VaultsService _vaultsService;
        private readonly Auth0Provider _auth;

        public ProfilesController(ProfilesService profilesService, KeepsService keepsService, VaultsService vaultsService, Auth0Provider auth)
        {
            _profilesService = profilesService;
            _keepsService = keepsService;
            _vaultsService = vaultsService;
            _auth = auth;
        }

        [HttpGet("{id}")]
        public ActionResult<Profile> getProfile(string id)
        {
            try 
            {
              Profile profile = _profilesService.getProfile(id);
              return Ok(profile);
            }
            catch (Exception e)
            {
              return BadRequest(e.Message);
            }
        }
        [HttpGet("{id}/keeps")]
        public async Task<ActionResult<Profile>> getProfileKeeps(string id)
        {
            try 
            {
                Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
                List<Keep> keeps = _keepsService.getProfileKeeps(id);
                return Ok(keeps);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}/vaults")]
        public async Task<ActionResult<Profile>> getProfileVaults(string id)
        {
            try 
            {
                Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
                List<Vault> Vaults = _vaultsService.getProfileVaults(id, userInfo.Id);
                return Ok(Vaults);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}