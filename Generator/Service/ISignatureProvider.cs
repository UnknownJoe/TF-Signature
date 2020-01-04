using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Generator.Service
{
    public interface ISignatureProvider
    {
        bool ProvidesSignature(string signatureName);
        string GetSignature(string signatureName);
    }
}
