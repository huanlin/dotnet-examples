using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using PushSharp;
using PushSharp.Core;
using PushSharp.Apple;
using PushSharp.Android;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;
using System.Net;
using NLog;
using System.Reflection;

namespace PushSharpDemo
{
    public class AppPushDemo
    {
        private Logger logger;
        private PushBroker push;
        private PushSharp.Apple.ApplePushChannelSettings applePushChannelSettings;
        private PushSharp.Android.GcmPushChannelSettings androidPushChannelSettings;
        private BlackBerryPushSettings blackBerryPushSettings;

        private bool needApplePush;
        private bool needAndroidPush;
        private bool needBlackBerryPush;

        private string appleTargetDeviceToken;
        private string androidTargetDeviceToken;

        public AppPushDemo()
        {
            logger = LogManager.GetCurrentClassLogger();

            push = new PushBroker();

            push.OnDeviceSubscriptionExpired += DeviceSubscriptionExpired;
            push.OnDeviceSubscriptionChanged += DeviceSubscriptionChanged;
            push.OnNotificationSent += NotificationSent;
            push.OnChannelException += ChannelException;
            push.OnNotificationFailed += NotificationFailed;
            push.OnChannelCreated += ChannelCreated;
            push.OnChannelDestroyed += ChannelDestroyed;

            //needSms = Convert.ToBoolean(ConfigurationManager.AppSettings["SMSEnabled"]);
            needApplePush = true;
            needAndroidPush = true;
            needBlackBerryPush = true;

            string pushEnabled = ConfigurationManager.AppSettings["ApplePushEnabled"];
            if (pushEnabled != null)
            {
                Boolean.TryParse(pushEnabled, out needApplePush);
            }

            pushEnabled = ConfigurationManager.AppSettings["AndroidPushEnabled"];
            if (pushEnabled != null)
            {
                Boolean.TryParse(pushEnabled, out needAndroidPush);
            }

            pushEnabled = ConfigurationManager.AppSettings["BlackBerryPushEnabled"];
            if (pushEnabled != null)
            {
                Boolean.TryParse(pushEnabled, out needBlackBerryPush);
            }

            appleTargetDeviceToken = ConfigurationManager.AppSettings["AppleTargetDeviceToken"];
            if (String.IsNullOrEmpty(appleTargetDeviceToken))
            {
                needApplePush = false;
                Console.WriteLine("Apple Push is disabled because AppleTargetDeviceToken is not set in app config!");
            }

            androidTargetDeviceToken = ConfigurationManager.AppSettings["AndroidTargetDeviceToken"];
            if (String.IsNullOrEmpty(androidTargetDeviceToken))
            {
                needAndroidPush = false;
                Console.WriteLine("Android Push is disabled because AndroidTargetDeviceToken is not set in app config!");
            }
              

            CreateApplePushSettings();
            CreateAndroidPushSettings();
            CreateBlackBerryPushSettings();
        }

        private void CreateApplePushSettings()
        {
            if (needApplePush == false)
            {
                return;
            }
            // Check config file first, then database.
            string fname = ConfigurationManager.AppSettings["ApplePushKeyFileName"];

            string filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fname.Trim());
            if (File.Exists(filename) == false)
            {
                filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data\" + fname.Trim());
                if (File.Exists(filename) == false)
                    throw new Exception("File not found: " + filename);
            }
            Console.WriteLine("Using Apple Push Key File: {0}", filename);
            string applePushKeyFilePwd = ConfigurationManager.AppSettings["ApplePushKeyFilePassword"];

            var certBuf = File.ReadAllBytes(filename);
            var cert = new X509Certificate2(certBuf, applePushKeyFilePwd, X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.Exportable);

            bool isProduction = Convert.ToBoolean(ConfigurationManager.AppSettings["ApplePushIsProduction"]);
            Console.WriteLine("Apple Push is production: {0}", isProduction);
            applePushChannelSettings = new PushSharp.Apple.ApplePushChannelSettings(isProduction, cert);

            push.RegisterAppleService(applePushChannelSettings);
        }

        private void CreateAndroidPushSettings()
        {
            if (needAndroidPush == false)
            {
                return;
            }
            // Start service.
            string senderId = ConfigurationManager.AppSettings["AndroidAppPushSenderID"];    // 82654747314
            string apiKey = ConfigurationManager.AppSettings["AndroidAppPushApiKey"];        // "AIzaSyCnmCx9MISzmx8G_XcnWI8DwsuIX7wjzac"
            string pkgName = ConfigurationManager.AppSettings["AndroidAppPushPkgName"];      // "com.google.android.gcm.demo.app"
            androidPushChannelSettings = new PushSharp.Android.GcmPushChannelSettings(senderId, apiKey, pkgName);

            push.RegisterGcmService(androidPushChannelSettings);
        }

        private void CreateBlackBerryPushSettings() 
        {
            blackBerryPushSettings = new BlackBerryPushSettings();
            blackBerryPushSettings.AppId = ConfigurationManager.AppSettings["BlackBerryPushAppID"];
            blackBerryPushSettings.Password = ConfigurationManager.AppSettings["BlackBerryPushPassword"];
            blackBerryPushSettings.Url = ConfigurationManager.AppSettings["BlackBerryPushUrl"];
        }


        public void SetApplePushChannelSettings(bool isProduction, X509Certificate2 certificate)
        {
            this.applePushChannelSettings = new PushSharp.Apple.ApplePushChannelSettings(isProduction, certificate);
            push.RegisterAppleService(applePushChannelSettings);
        }

        public void SetAndroidPushChannelSettings(string senderId, string apiKey, string pkgName)
        {
            androidPushChannelSettings = new PushSharp.Android.GcmPushChannelSettings(senderId, apiKey, pkgName);
            push.RegisterGcmService(androidPushChannelSettings);
        }

        #region Push Events

        private void ChannelDestroyed(object sender)
        {
            logger.Info("Channel Destroyed for: " + sender);
        }

        private void ChannelCreated(object sender, IPushChannel pushChannel)
        {
            logger.Info("Channel Created for: " + sender);

        }

        private void DeviceSubscriptionChanged(object sender, string oldSubscriptionId, string newSubscriptionId, INotification notification)
        {
            //Currently this event will only ever happen for Android GCM
            logger.Info("App Push Device Registration Changed. Old: {0} , New: {1}", oldSubscriptionId, newSubscriptionId);
        }

        private void DeviceSubscriptionExpired(object sender, string expiredDeviceSubscriptionId, DateTime timestamp, INotification notification)
        {
            logger.Debug("App Push device subscription expired: {0} -> {1}", sender, expiredDeviceSubscriptionId);
        }

        private void NotificationFailed(object sender, INotification notification, Exception notificationFailureException)
        {
            logger.Debug("App Push send to {0} failed : {1} \r\n -> {2}",
                sender,
                notificationFailureException.ToString(),
                notification.ToString());
        }

        private void NotificationSent(object sender, INotification notification)
        {
            logger.Info("App Push notification sent to {0} OK : {1}", sender, notification);
        }

        private void ChannelException(object sender, IPushChannel channel, Exception exception)
        {
            logger.Debug("App Push channel exception from {0} : {1}", sender, exception.ToString());
        }

        #endregion

        public void SendApplePushMessage(string deviceToken, string msg, string customItemKey = null, params object[] customItemValues)
        {
            Console.WriteLine("Sending Apple Push Notification message: " + msg);
            Console.WriteLine("  to device token: {0}", deviceToken);
            /*
                            if (appleDeviceToken.Equals(
                                "20b6a421eb15ba4ad9556b4d74d8654c1da9529bb071236152660fb751fc0dad", 
                                StringComparison.CurrentCultureIgnoreCase))
                            {
                                System.Diagnostics.Debug.WriteLine("OKKKK");
                            }
            */
            if (String.IsNullOrWhiteSpace(customItemKey))
            {
                push.QueueNotification(new AppleNotification()
                    .ForDeviceToken(deviceToken)
                    .WithAlert(msg)
                    .WithSound("default")
                    .WithBadge(1)
                    );
            }
            else
            {
                push.QueueNotification(new AppleNotification()
                    .ForDeviceToken(deviceToken)
                    .WithAlert(msg)
                    .WithCustomItem(customItemKey, customItemValues)
                    .WithSound("default")
                    .WithBadge(1)
                    );
            }
        }

        public void SendAndroidPushMessage(string deviceToken, string jsonMsg)
        {
            if (String.IsNullOrWhiteSpace(jsonMsg))
                return;

            // Send message.
            //string androidRegId = "APA91bEcGtjKIg26hv9_HfNLS0qLaIJN69e-JdJVlthB2bR5bMpwpXN88SiSpIC-VSWUydvdbgfeseb7_rzNb0N27p1rp709_rv6VeT43okapIlPhXiGgXava3Z2AGV-Uum-6U3nvdeUt_khoLswpUV-ECsu3tCuuL2lfqzOvAipQX5irfNXzUg";                

            push.QueueNotification(new GcmNotification()
                .ForDeviceRegistrationId(deviceToken)
                .WithCollapseKey("LATEST")
                .WithJson(jsonMsg));
        }

        public void SendPushMessage(string msg, string customItemKey = null, params object[] customItemValues)
        {
            if (needApplePush)
            {
                string deviceToken = appleTargetDeviceToken;
                SendApplePushMessage(deviceToken, msg, customItemKey, customItemValues);
            }

            if (needAndroidPush)
            {
                var aMsg = new
                {
                    //    AlertID = alert.AlertID,
                    Message = msg
                };
                string androidRegId = "APA91bEcGtjKIg26hv9_HfNLS0qLaIJN69e-JdJVlthB2bR5bMpwpXN88SiSpIC-VSWUydvdbgfeseb7_rzNb0N27p1rp709_rv6VeT43okapIlPhXiGgXava3Z2AGV-Uum-6U3nvdeUt_khoLswpUV-ECsu3tCuuL2lfqzOvAipQX5irfNXzUg";
                SendAndroidPushMessage(androidRegId, JsonConvert.SerializeObject(aMsg));
            }

            if (needBlackBerryPush)
            {
                SendBlackBerryPushMessage();
            }

            Console.WriteLine("Waiting for Queue to Finish...");

            //Stop and wait for the queues to drains
            push.StopAllServices(true);
        }

        void SendBlackBerryPushMessage()
        {
            string pin = "push_all";
            string applicationID = blackBerryPushSettings.AppId;    // Application ID
            string boundary = "ASDFaslkdfjasfaSfdasfhpoiurwqrwm";
            string msg = "Hi Simon, the master of Blackberry " + DateTime.Now.ToString("HH:mm:ss"); // the message to send

            string userName = blackBerryPushSettings.AppId;     // your application ID
            string password = blackBerryPushSettings.Password;    // your password
            string url = blackBerryPushSettings.Url;            // https://pushapi.eval.blackberry.com/mss/PD_pushRequest

            StringBuilder dataToSend = new StringBuilder();

            string pushTemplateFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pap_push.template");

            dataToSend.Append(File.ReadAllText(pushTemplateFileName));
            dataToSend.Replace("$(boundary)", boundary);
            dataToSend.Replace("$(pushid)", DateTime.Now.ToFileTime().ToString());
            dataToSend.Replace("$(username)", applicationID);
            string deliverBefore = DateTime.UtcNow.AddMinutes(5).ToString("s", System.Globalization.CultureInfo.InvariantCulture) + "Z";
            dataToSend.Replace("$(deliverBefore)", deliverBefore);
            dataToSend.Replace("$(deliveryMethod)", "unconfirmed");
            dataToSend.Replace("$(addresses)", "<address address-value=\"" + pin + "\"/>");
            dataToSend.Replace("$(content)", msg);

            File.WriteAllText(@"C:\req.txt", dataToSend.ToString());

            HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(url);            

            //SetProxy(HttpWReq); //if proxy needed, use this

            webReq.Method = ("POST");
            webReq.Accept = "text/html, image/gif, image/jpeg, *; q=.2, */*; q=.2";
            webReq.KeepAlive = true;

            // Set authorization header.
            byte[] buf = Encoding.UTF8.GetBytes(String.Format("{0}:{1}", userName, password));
            string auth = Convert.ToBase64String(buf);
            webReq.Headers.Add("Authorization: Basic " + auth);

            webReq.ContentType = "multipart/related; boundary=" + boundary + "; type=application/xml";

            Stream requestStream = null;
            string pushResult = "";
            try
            {
                requestStream = webReq.GetRequestStream();
            }
            catch (Exception ex)
            {
                pushResult = "BlackBerry push failed: " + ex.ToString();
                Console.WriteLine(pushResult);
            }

            byte[] outStr = new UTF8Encoding().GetBytes(dataToSend.ToString());
            requestStream.Write(outStr, 0, outStr.Length);
            requestStream.Close();

            HttpWebResponse webResp = null;
            try
            {
                webResp = (HttpWebResponse)webReq.GetResponse();
            }
            catch (Exception ex)
            {
                //push failed
                Console.WriteLine("BlackBerry push failed: " + ex.Message);
            }

            if (webResp != null)
            {
                var stream = webResp.GetResponseStream();
                StreamReader rdr = new StreamReader(stream);
                string content = rdr.ReadToEnd();
                Console.WriteLine(content);
                rdr.Close();
                stream.Close();
                webResp.Close();
            }
        }

    }
}
