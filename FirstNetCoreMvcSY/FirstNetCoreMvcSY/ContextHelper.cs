using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstNetCoreMvcSY
{
    public class ContextHelper
    {
        private IHttpContextAccessor _httpContextAccessor;

        public ContextHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

       
    }
}
