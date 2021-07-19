using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject.Models
{
    class PutRequestPayload
    {
        public String address { get; set; }
        public String place_id { get; set; }
        public String key { get; set; }

        public String toString()
        {
            return "{\n  \"place_id\": \""+place_id+"\",\n  \"address\": \""+address+"\",\n  \"key\": \""+key+"\"\n}";
        }
    }
}
