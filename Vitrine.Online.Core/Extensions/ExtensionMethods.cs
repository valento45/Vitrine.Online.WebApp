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


        public static string ObterTextoSimplificado(this string value, int length = 0)
        {
            string end = string.Empty;

            if (length > 0 && length <= value.Length)
            {
                end = value.Substring(0, length);
            }
            else
            {
                if (value.Length > 50)
                {
                    end = value.Substring(0, 50);
                }

                else
                    return value;
            }

            return end;
        }

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
