# Rename to TWSMSender
=begin
  == Information ==
  === Copyright: Apache 2.0
  === Author: CFC < zusocfc@gmail.com >
  === Library Name: TWSMS lib
  === Version: 0.2.1
  === Please read README file to get more information.
=end

%w|date uri cgi net/http|.each{|r| require r}
SEND_URL = "http://api.twsms.com/smsSend.php?"
QUERY_URL = "http://api.twsms.com/smsQuery.php?"

class TWSMS
  def initialize(username, password)
    @uname, @upwd = username, password
    # Before renamed, its name is: @send_options
    @send_options = {
      :type => "now",
      :popup => "",
      :mo => "Y".upcase,
      :vldtime => "86400",
      :modate => "",
      :dlvtime => "",
      :wapurl => "",
      :encoding => "big5"
    }
    
    @query_options = {
      :type => "now",
      :msgid => "",
      :monumber => "",
      :sdate => "",
      :edate => ""
    }
    
    # Before renamed, its name is: @@errors
    @@send_errors = {
      -1.to_s.to_sym => "Send failed",
      -2.to_s.to_sym => "Username or password is invalid",
      -3.to_s.to_sym => "Popup tag error",
      -4.to_s.to_sym => "Mo tag error",
      -5.to_s.to_sym => "Encoding tag error",
      -6.to_s.to_sym => "Mobile tag error",
      -7.to_s.to_sym => "Message tag error",
      -8.to_s.to_sym => "vldtime tag error",
      -9.to_s.to_sym => "dlvtime tag error",
      -10.to_s.to_sym => "You have no point",
      -11.to_s.to_sym => "Your account has been blocked",
      -12.to_s.to_sym => "Type tag error",
      -13.to_s.to_sym => "You can't send SMS message by dlvtime tag if you use wap push",
      -14.to_s.to_sym => "Source IP has no permission",
      -99.to_s.to_sym => "System error!! Please contact the administrator, thanks!!"
    }
    
    @@query_errors = {
      0.to_s.to_sym => "Message already been sent or reserving message has been deleted",
      -1.to_s.to_sym => "Could not find the message id or ",
      -2.to_s.to_sym => "Username or password is invalid",
      -3.to_s.to_sym => "The reserving message does send yet",
      -4.to_s.to_sym => "Type tag error",
      -5.to_s.to_sym => "The target mobile did not callback",
      -6.to_s.to_sym => "Failed on sent message to the operator",
      -7.to_s.to_sym => "No short code",
      -8.to_s.to_sym => "No return message",
      -9.to_s.to_sym => "sdate or edate setting error",
      -10.to_s.to_sym => "No record of ",
      -11.to_s.to_sym => "Your account has been blocked",
      -12.to_s.to_sym => "Your message maybe invalid",
    }
  end
  
  def sendSMS(mobile, message, opt={})
    args = []
    @send_options[:mobile], @send_options[:message] = mobile, message
    @send_options.merge!(opt).each{|k, v| args << k.to_s + "=" + CGI::escape(v.to_s)}
    url = SEND_URL + "username=" + @uname + "&password=" + @upwd + "&" + args.join("&")
    self.check_send_val
    (raise "dlvtime is invalid";exit) unless self.check_date("dlvtime")
    return self.check_send_resp(Net::HTTP.get(URI.parse(url)))
  end
  
  def querySMS()
    url ||= QUERY_URL + "username=" + @uname + "&password=" + @upwd
    url += "&type=" + @query_options[:type].to_s
    url += "&msgid=" + @query_options[:msgid].to_s
    url += "&monumber=" + @query_options[:monumber].to_s
    url += "&sdate=" + @query_options[:sdate].to_s
    url += "&edate=" + @query_options[:edate].to_s
    (raise "dlvtime is invalid";exit) unless self.check_date("sdate")
    (raise "dlvtime is invalid";exit) unless self.check_date("edate")
    return self.check_query_resp(Net::HTTP.get(URI.parse(url)))
  end

  def setMessageId(msgid)
    # @query_options[:msgid] = msgid unless msgid.nil?
    # (puts "You did not give me the message id!!!";exit) if msgid.nil?
    if msgid.nil?
      puts "You did not give me the message id!!!"
      exit
    else
      @query_options[:msgid] = msgid
    end
    return nil
  end
  
  def check_query_resp(resp)
    resp = resp.split("=")[1].split(",")[0]
=begin
    if resp.to_s == "0"
      puts "==========", "Query succeed! The result: " + @@query_errors[resp.to_s.to_sym]
    else
      puts "==========", "Error!! Message: ", @@query_errors[resp.to_s.to_sym]
    end
=end
    return @@query_errors[resp.to_s.to_sym]
  end
  
  def check_send_resp(resp)
    # Before rename, its name is chk_errors
    resp = resp.split("=")[1].split(",")[0]
    if @@send_errors.has_key?(resp.to_s.to_sym)
      # puts "==========", "Error!! Message: ", @@send_errors[resp.to_s.to_sym]
      return @@send_errors[resp.to_s.to_sym]
    else
      # puts "==========", "Message has been send! Your message id is: " + resp.to_s
      @query_options[:msgid] = resp.to_s
      return resp.to_s
    end
  end
  
  def check_send_val()
    @send_options[:type] = "now" unless @send_options[:type] == ("now" || "dlv") # 0.2.1 -- Make sure the type is valid
    @send_options[:dlvtime] = "" unless @send_options[:type] == "dlv"
    @send_options[:wapurl] = "" unless @send_options[:type] == ("push" && "upush")
    @send_options[:mo] = @send_options[:mo].upcase
    @send_options[:mobile].gsub(/-/, "") # 0.2.1 -- Check the mobile format
    return nil
  end
  
  def check_date(type="dlvtime")
    # For dlvtime, sdate, edate
    # 0.2.1 -- Make sure the date is valid
    case type
      when "dlvtime"
        d = DateTime.parse(@send_options[:dlvtime])
        vc = Date.valid_civil?(d.year, d.month, d.day)
        vt = Date.valid_time?(d.hour, d.min, d.sec)
        return true if vc == vt
      when "sdate"
        d = DateTime.parse(@query_options[:sdate])
        return true if Date.valid_civil?(d.year, d.month, d.day)
      when "edate"
        d = DateTime.parse(@query_options[:edate])
        return true if Date.valid_civil?(d.year, d.month, d.day)
    end
  end
  
  protected :check_send_val, :check_date, :check_send_resp, :check_query_resp
end
