unit SMS;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, ShellAPI, ComCtrls, ExtCtrls, StdCtrls, IdIntercept, IdLogBase,
  IdLogEvent, IdBaseComponent, IdComponent, IdTCPConnection, IdTCPClient,
  IdHTTP, Buttons, Spin, IdAntiFreezeBase, IdAntiFreeze;

const
  web : string = 'http://api.twsms.com/SendSMS.php';

type
  TForm1 = class(TForm)
    Panel1: TPanel;
    StatusBar1: TStatusBar;
    Label1: TLabel;
    Label2: TLabel;
    BitBtn1: TBitBtn;
    BitBtn2: TBitBtn;
    Label5: TLabel;
    SendToNo: TMemo;
    Label6: TLabel;
    SendMsg: TMemo;
    SMSUser: TLabeledEdit;
    SMSPwd: TLabeledEdit;
    IdHTTP1: TIdHTTP;
    IdLogEvent1: TIdLogEvent;
    GroupBox1: TGroupBox;
    ProxyHost: TLabeledEdit;
    ProxyPort: TSpinEdit;
    Label3: TLabel;
    ProxyUser: TLabeledEdit;
    ProxyPwd: TLabeledEdit;
    LogList: TListBox;
    Label4: TLabel;
    Memo1: TMemo;
    IdAntiFreeze1: TIdAntiFreeze;
    procedure Label2Click(Sender: TObject);
    procedure IdLogEvent1Received(ASender: TComponent; const AText,
      AData: String);
    procedure IdLogEvent1Sent(ASender: TComponent; const AText,
      AData: String);
    procedure BitBtn1Click(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure IdLogEvent1Status(ASender: TComponent; const AText: String);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation

{$R *.dfm}

procedure TForm1.Label2Click(Sender: TObject);
begin
  ShellExecute(Handle,'open','http://www.twsms.com',nil,nil,SW_SHOWNORMAL);
end;

procedure TForm1.IdLogEvent1Received(ASender: TComponent; const AText,
  AData: String);
begin
  LogList.Items.Add('Received :'+AText+';'+AData);
  LogList.ItemIndex := LogList.Count-1;
end;

procedure TForm1.IdLogEvent1Sent(ASender: TComponent; const AText,
  AData: String);
begin
  LogList.Items.Add('Sent :'+AText+';'+AData);
  LogList.ItemIndex := LogList.Count-1;
end;

procedure TForm1.BitBtn1Click(Sender: TObject);
var Content : Tstrings;
    Response,ResDesc : string;
    i : integer;
begin
  if Length(SMSUser.Text)* Length(SMSPwd.Text)*
     Length(SendToNo.Text)* Length(SendMsg.Text) = 0 then
    raise Exception.Create('資料輸入不完整 !');
  if ProxyHost.Text <> '' then begin
    IdHTTP1.ProxyParams.ProxyServer := ProxyHost.Text;
    IdHTTP1.ProxyParams.ProxyPort := ProxyPort.Value;
    IdHTTP1.ProxyParams.ProxyUsername := ProxyUser.Text;
    IdHTTP1.ProxyParams.ProxyPassword := ProxyPwd.Text;
  end;
  Content := TStringList.Create;
  try
    for i := 0 to SendToNo.Lines.Count - 1 do
    if Trim(SendToNo.Lines[i])<>'' then begin
      StatusBar1.SimpleText := '傳送給 : '+SendToNo.Lines[i]+' 中...';
      Content.Text := 'CID=' +SMSUser.Text+ '&CPW='+SMSPwd.Text+'&N='+SendToNo.Lines[i]+
                      '&M='+IdHTTP1.URL.ParamsEncode(SendMsg.Text);
      try
        Response := IdHTTP1.Post(web,Content);
      except
        on E: Exception do begin
          LogList.Items.Add(DateTimeToStr(now)+'; 錯誤發生 : '+E.Message);
          if IdHTTP1.Connected then IdHTTP1.Disconnect;
        end;
      end;
      if pos(':',Response)>0 then
        Response := Trim(Copy(Response,1,pos(':',Response)-1));
      ResDesc := Memo1.Lines.Values[Response];
      StatusBar1.SimpleText := ResDesc;
      LogList.Items.Add(DateTimeToStr(now)+'; 傳送給 : '+SendToNo.Lines[i]+ ' ; 結果 : '+ResDesc);
      Sleep(3000);
    end;
  finally
    if IdHTTP1.Connected then IdHTTP1.Disconnect;
    LogList.Items.SaveToFile('SMSLog.txt');
    if Content<>nil then Content.Free;
  end;
end;

procedure TForm1.FormCreate(Sender: TObject);
begin
  Memo1.Lines.LoadFromFile('ErrCode.txt');
end;

procedure TForm1.IdLogEvent1Status(ASender: TComponent;
  const AText: String);
begin
  LogList.Items.Add('Status :'+AText);
  LogList.ItemIndex := LogList.Count-1;
end;

end.
