using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Generator.Model;
using RazorEngine;
using RazorEngine.Templating;

namespace Generator.Service
{
    public class SignatureService
    {

        private List<ISignatureProvider> _Provider = new List<ISignatureProvider>();
             

        public SignatureService WithProvider(IEnumerable<ISignatureProvider> providers)
        {
            _Provider.AddRange(providers);
            return this;
        }

        public string RenderSignature(string signatureName, string signatureTemplate, Signature model)
        {
            string templateKey = signatureTemplate.GetHashCode().ToString();
         if (!Engine.Razor.IsTemplateCached(templateKey,typeof(Signature)))
            {
                return Engine.Razor.RunCompile(signatureTemplate, templateKey, typeof(Signature), model);
            }
            else
            {
                return Engine.Razor.Run(templateKey, typeof(Signature), model);
            }
            
        }

        public string GetSignature(string signatureName, Signature model)
        {
            ISignatureProvider provider = _Provider.FirstOrDefault(x => x.ProvidesSignature(signatureName));
            if( provider != null)
            {
                return RenderSignature(signatureName, provider.GetSignature(signatureName), model);
            }
            return $"Error : No provider for {signatureName} found!";
        }     
    }
}
