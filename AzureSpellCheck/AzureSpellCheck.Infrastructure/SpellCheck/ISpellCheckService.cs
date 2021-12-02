using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AzureSpellCheck.Infrastructure.SpellCheck
{
    public interface ISpellCheckService
    {
        Task<SpellCheckModel> Execute(string text);
    }
}
