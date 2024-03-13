using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions
{
    public interface IApiKeyService
    {
        string GenerateApiKey();
        string HashApiKey(string apiKey);
    }
}
