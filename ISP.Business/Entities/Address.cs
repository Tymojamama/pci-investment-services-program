using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace ISP.Business.Entities
{
    public struct Address
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }
}
