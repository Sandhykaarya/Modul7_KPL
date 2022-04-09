using System;

namespace modul7_1302204002
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankTransferConfig btc = new BankTransferConfig();

            dynamic config = GetConf(btc);
            string konfirmasi;
            int biaya;
            int x = 0;

            if (config.lang == "en")
            {
                Console.WriteLine(" Please insert the amount of money to transfer : ");
            }
            else if (config.lang == "id")
            {
                Console.WriteLine(" Masukkan jumlah uang yang akan di-transfer : ");
            }

            string TransferringMoney = Console.ReadLine();
            
            int MoneyinTransfer = int.Parse(TransferringMoney);
            if (MoneyinTransfer <= (int)config.transfer.threshold)
            {
                biaya = config.transfer.low_fee;
            }
            else
            {
                biaya = config.transfer.high_fee;
            }

            if (config.lang == "en")
            {
                Console.WriteLine("Transfer fee = " + biaya);
                Console.WriteLine("Total amount = " + (biaya + MoneyinTransfer));
                Console.WriteLine("Select transfer method");
            }
            else if (config.lang == "id")
            {
                Console.WriteLine("Biaya transfer = " + biaya);
                Console.WriteLine("Total biaya = " + (biaya + MoneyinTransfer));
                Console.WriteLine("Pilih metode transfer");
            }

            
            foreach (var mthd in config.methods)
            {
                x++;
                Console.WriteLine(x + ". " + mthd);
            }

            Console.WriteLine();

            if (config.lang == "en")
            {
                Console.WriteLine("Please type '" + config.confirmation.en + " ' to confirm the transaction:");

                konfirmasi = Console.ReadLine();

                if (konfirmasi == (string)config.confirmation.en)
                {
                    Console.WriteLine("The transfer is completed");
                }

                else
                {
                    Console.WriteLine("Transfer is cancelled");
                }
            }
            else if (config.lang == "id")
            {

                Console.WriteLine("Ketik '" + config.confirmation.id + "' untuk mengkonfirmasi transaksi:");

                konfirmasi = Console.ReadLine();

                if (konfirmasi == (string)config.confirmation.id)
                {
                    Console.WriteLine("Proses transfer berhasil");
                }
                else
                {
                    Console.WriteLine("Transfer dibatalkan");
                }
            }
        }

        private static dynamic GetConf(BankTransferConfig bankConfig)
        {
            return bankConfig.ReadJson();
        }
    }
}