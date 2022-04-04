using Decoder;
using Microsoft.AspNetCore.Mvc;

namespace Morse.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TranslateController : ControllerBase
    {
        private readonly ILogger<TranslateController> _logger;

        public TranslateController(ILogger<TranslateController> logger)
        {
            _logger = logger;
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpPost, ActionName("ToText")]
        public IActionResult ToText(string inMorse)
        {
            try
            {
                string outHuman = Decode.Morse2Human(inMorse);
                if (outHuman.Contains('#') ) { return BadRequest(outHuman); }
                return Ok(outHuman);
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
            
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpPost, ActionName("ToMorse")]
        public IActionResult ToMorse(string inHuman)
        {
            try
            {
                string outMorse = Decode.Human2Morse(inHuman);
                if (outMorse.Contains('#')) { return BadRequest(outMorse); }
                return Ok(outMorse);
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
           
        }
    }
}