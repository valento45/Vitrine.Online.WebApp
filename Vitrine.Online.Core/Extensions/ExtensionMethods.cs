using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vitrine.Online.Core.Extensions
{
    public static class ExtensionMethods
    {


        public static async Task<string> GetBase64FromFile(this IFormFile formFile)
        {
            if (formFile != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    await formFile.CopyToAsync(ms);

                    return Convert.ToBase64String(ms.ToArray());
                }
            }
            else
                return string.Empty;
        }
    }
}
