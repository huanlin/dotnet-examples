using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestwindAppConfigDemo
{
    public class AppConfig : Westwind.Utilities.Configuration.AppConfiguration
    {
        public int SendEmailDelay { get; set; }
        public DateTime StartTime { get; set; }
        public bool EncryptionEnabled { get; set; }
        public string EncryptionMethod { get; set; }
        public string Mail_SmtpHost { get; set; }

        public AppConfig()
        {
            // 如果組態檔中沒有定義這些參數，就會使用以下預設值.
            SendEmailDelay = 1000;
            StartTime = DateTime.Now;
            EncryptionEnabled = true;
            EncryptionMethod = "AES";
        }

        protected override void OnInitialize(Westwind.Utilities.Configuration.IConfigurationProvider provider, string sectionName, object configData)
        {
            sectionName = String.Empty;    // 預設的 sectionName 就是這個類別的名稱: 'AppConfig'，這裡改寫成空自串，表示要使用 appSettings 區段.
            base.OnInitialize(provider, sectionName, configData);
        }
    }

    public static class App
    {
        public static AppConfig Config { get; set; }

        static App()
        {
            Config = new AppConfig();
            Config.Initialize();    // 這行不可少!
        }
    }
}
