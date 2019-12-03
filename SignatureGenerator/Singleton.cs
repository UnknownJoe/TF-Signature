using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignatureGenerator
{
    public class Singleton
    {

        public static IRazorViewEngine RazorViewEngine { get; set; }
    
    }
}
