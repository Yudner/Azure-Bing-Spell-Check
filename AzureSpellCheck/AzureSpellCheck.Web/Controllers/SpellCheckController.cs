using AzureSpellCheck.Infrastructure.SpellCheck;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureSpellCheck.Web.Controllers
{
    [ApiController]
    [Route("api/spellcheck")]
    public class SpellCheckController: ControllerBase
    {
        private ISpellCheckService _spellCheckService;
        public SpellCheckController(ISpellCheckService spellCheckService)
        {
            _spellCheckService = spellCheckService;
        }

        [HttpGet()]
        public async Task<IActionResult> SpellCheck([FromQuery] string text)
        {
            var result = await _spellCheckService.Execute(text);
            var newText = await ReturnText(text, result);
            return Ok(newText);
        }

        private async Task<string> ReturnText(string text, SpellCheckModel result)
        {
            string newText = text;
            foreach (var item in result.flaggedTokens)
            {
                newText = newText.Replace(item.token, item.suggestions[0].suggestion);
            }
            return newText;
        }
    }
}
