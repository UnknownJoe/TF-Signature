using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using SignatureGenerator.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SignatureGenerator.Controllers
{
    [Route("[controller]")]
    public class SignatureController : Controller
    {

        public async Task<ContentResult> Get(string viewName)
        {
            return await FillView(viewName, null);
        }

        [HttpPost]
        public async Task<ContentResult> Post(Models.Signature signature)
        {
            return await FillView("TestView", signature);
        }

        private async Task<ContentResult> FillView(string viewName, object data)
        {
            using (var writer = new StringWriter())
            {

                Signature s = new Signature();
                s.TextBlocks.Add("Header", "Hallo");
                s.Person = new Person();
                s.Person.FirstName = "Kai";
                s.Person.LastName = "Specht";
                s.Person.ContactData.Add(new ContactData { Description = "Email", Value = "k.specht@reiling.de" });
                s.Person.ContactData.Add(new ContactData { Description = "Telefon", Value = "05247/980359" });




                data = s;


                if (viewName == null) { viewName = "TestView"; };

                IViewEngine viewEngine = HttpContext.RequestServices.GetService(typeof(ICompositeViewEngine)) as ICompositeViewEngine;

                ViewEngineResult result = viewEngine.FindView(ControllerContext, viewName, false);




                if (result.Success == false)
                {
                    return new ContentResult() { Content = $"A view with the name {viewName} could not be found!" };
                }
                else
                {
                    ViewData.Model = data;
                    ViewContext context = new ViewContext(ControllerContext, result.View, ViewData, TempData, writer, new HtmlHelperOptions());
                    await result.View.RenderAsync(context);
                    return new ContentResult()
                    {
                        Content = writer.GetStringBuilder().ToString(),
                        ContentType = "text/html"
                    };                    
                }
            }
        }
    }
}
