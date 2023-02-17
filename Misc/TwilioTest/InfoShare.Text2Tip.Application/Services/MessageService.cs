using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using InfoShare.Text2Tip.Core.Model;
using InfoShare.Text2Tip.Core.Utility;

namespace InfoShare.Text2Tip.Application.Services
{
    public class MessageService : Text2TipServiceBase
    {
        
        public int LogIncomingMessage(HttpRequest request)
        {
            var msg = new lead_message();
            msg.account_sid = request["AccountSid"];
            msg.message_sid = request["MessageSid"];
            msg.sms_message_sid = request["SmsMessageSid"];
            msg.sms_sid = request["SmsSid"];
            msg.sms_status = request["SmsStatus"];
            msg.from_phone = request["From"];
            msg.from_country = request["FromCountry"];
            msg.from_state = request["FromState"];
            msg.from_city = request["FromCity"];
            msg.from_zip = request["FromZip"];
            msg.to_phone = request["To"];
            msg.to_country = request["ToCountry"];
            msg.to_state = request["ToState"];
            msg.to_city = request["ToCity"];
            msg.to_zip = request["ToZip"];
            msg.body = request["Body"];
            msg.num_media = ConvertHelper.ToInt32(request["NumMedia"], 0);
            msg.num_segments = ConvertHelper.ToInt32(request["NumSegments"], 1);
            msg.api_version = request["ApiVersion"];
            msg.flag_delete = 0;

            _db.lead_message.Add(msg);
            return _db.SaveChanges();
        }
    }
}
