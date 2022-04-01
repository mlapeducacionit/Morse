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

        [HttpPost, ActionName("ToText")]
        public string ToText(string inMorse)
        {
            return Decode.Morse2Human(inMorse);
        }

        [HttpPost, ActionName("ToMorse")]
        public string ToMorse(string inHuman)
        {
            return Decode.Human2Morse(inHuman);
        }
    }
}