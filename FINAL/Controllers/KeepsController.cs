namespace FINAL.Controllers
{
    [Route("api/[controller]")]
    public class KeepsController : Controller
    {
        private readonly KeepsService _keepsService;
        private readonly Auth0Provider _auth;

        public KeepsController(KeepsService keepsService, Auth0Provider auth)
        {
            _keepsService = keepsService;
            _auth = auth;
        }

        

        [HttpGet]
        public ActionResult<List<Keep>> getKeeps()
        {
            try 
            {
                List<Keep> keeps = _keepsService.getKeeps();
                return Ok(keeps);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Keep>> getKeepsById(int id)
        {
            try 
            {
                Account useriInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);

              Keep keep = _keepsService.getKeepById(id, useriInfo?.Id);
              return Ok(keep);
            }
            catch (Exception e)
            {
              return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Keep>> createKeep([FromBody] Keep keepData)
        {
            try 
            {
              Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
              keepData.CreatorId = userInfo.Id;
              Keep keep = _keepsService.createKeep(keepData, userInfo);
              return Ok(keep);
            }
            catch (Exception e)
            {
              return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<Keep>> editKeep([FromBody] Keep updateData, int id)
        {
            try 
            {
                Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
                updateData.CreatorId = userInfo.Id;
                updateData.Id = id;
                Keep keep = _keepsService.updateKeep(id, updateData);
                return Ok(keep);
            }
            catch (Exception e)
            {
              return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]

        public async Task<ActionResult<Keep>> DeleteKeep(int id)
        {
            try 
            {
                Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
                Keep keep = _keepsService.deleteKeep(id, userInfo.Id);
                return Ok(keep);
            }
            catch (Exception e)
            {
              return BadRequest(e.Message);
            }
        }
    }
}