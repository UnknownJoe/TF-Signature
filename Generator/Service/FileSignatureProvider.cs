using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace Generator.Service
{
    public class FileSignatureProvider : ISignatureProvider
    {
        private string _Folder;

        public FileSignatureProvider()
        {
            _Folder = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "Signatures/");
        }

        public FileSignatureProvider WithLookupFolder(string folder)
        {
            _Folder = folder;
            return this;
        }

        public string GetSignature(string signatureName)
        {
            string fileName = GetFileName(signatureName);
            if (File.Exists(fileName))
            {
                return File.ReadAllText(fileName);
            }
            else
            {
                return $"Error : {this.GetType().Name} do not provide signature {signatureName}.cshtml";
            }
        }

        public bool ProvidesSignature(string signatureName)
        {
            return File.Exists(GetFileName(signatureName));
        }

        private string GetFileName(string signatureName)
        {
            return _Folder + $"{signatureName}.cshtml";
        }
    }
}
