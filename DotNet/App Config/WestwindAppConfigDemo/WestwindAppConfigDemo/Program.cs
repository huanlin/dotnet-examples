using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestwindAppConfigDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // 取得參數值.
            Console.WriteLine("SendEmailDelay = {0}", App.Config.SendEmailDelay);
            Console.WriteLine("EncryptionEnabled = {0}", App.Config.EncryptionEnabled);
            Console.WriteLine("EncryptionMethod = {0}", App.Config.EncryptionMethod);

            // 修改參數值並寫回組態檔.
            App.Config.EncryptionMethod = "3DES";
            App.Config.Write();

            // Note: 寫回組態檔時，若 AppConfig 類別中沒有定義對應至某些組態項目的屬性，該組態項目仍會存在，不會消失。所以不用擔心加入這個類別之後破壞應用程式既有的行為.
        }
    }
}
