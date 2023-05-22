using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WatchParty.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThemeController : ControllerBase
    {

        [HttpPost("SwitchTheme")]
        public IActionResult SwitchTheme(string theme)
        {
            return Ok($"{{\"theme\" : \"{theme}\"}}");
        }
    }
}
