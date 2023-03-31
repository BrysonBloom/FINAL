using Microsoft.Extensions.Logging;

namespace FINAL.Controllers
{
    [Route("api/[controller]")]
    public class KeepsController : Controller
    {
        private readonly KeepsService _keepsService;

        public KeepsController(KeepsService keepsService)
        {
            _keepsService = keepsService;
        }

        private readonly ILogger<KeepsController> _logger;

        public KeepsController(ILogger<KeepsController> logger)
        {
            _logger = logger;
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
    }
}