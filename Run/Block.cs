using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Run
{
    internal class Block
    {
        public int index { get; set; }
        public string pre_hash { get; set; }
        public int timestamp { get; set; }
        public List<Transaction> transactions { get; set; }
        public string secret_info { get; set; }
        public int nonce { get; set; }
        public string hash { get; set; }
    }

   

   
}
