using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace SignatureGenerator.Models
{
    [DataContract]
    public class Signature
    {
        [DataMember]
        public Dictionary<string, string> TextBlocks { get; } = new Dictionary<string, string>();
        
        [DataMember]
       public Person Person { get; set; }

        [DataMember]
        public string LegalInfo { get; set; }
    }

    [DataContract]
    public class Person
    {
        [DataMember]
        public string FirstName { get; set; }
        
        [DataMember]
        public string LastName { get; set; }
        
        [DataMember]
        public string PositionDescription { get; set; }
        
        [DataMember]
        public List<ContactData> ContactData { get; } = new List<ContactData>();
    }

    [DataContract]
    public class ContactData
    {
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Value { get; set; }
    }
}
