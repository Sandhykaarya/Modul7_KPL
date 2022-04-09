using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace modul7_1302204002
{
    internal class BankTransferConfig
    {
        public class Bank
        {
            public string lang { get; set; }
            public transferClass transfer { get; set; }
            public string methods { get; set; }
            public confirmationClass confirmation { get; set; }
        }

        public class transferClass
        {
            public string thresold { get; set; }
            public string low_fee { get; set; }
            public string high_fee { get; set; }
        }

        public class confirmationClass
        {
            public string en { get; set; }
            public string id { get; set; }
        }

        public dynamic ReadJson()
        {
            string file = "file.json";
            string data = File.ReadAllText(file);

            Bank bank = JsonSerializer.Deserialize<Bank>(data);

            return bank;
        }

    }
}
