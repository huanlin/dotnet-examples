//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "Unit1.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TForm1 *Form1;
TMemoryStream *SMSms=new TMemoryStream;
TStringList *SMSsl= new TStringList;
//---------------------------------------------------------------------------
__fastcall TForm1::TForm1(TComponent* Owner)
    : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall TForm1::Image1Click(TObject *Sender)
{
    ShellExecute(Handle,NULL,"http://www.twsms.com/",NULL,NULL,SW_SHOWNORMAL);
}
//---------------------------------------------------------------------------
void __fastcall TForm1::Memo1Change(TObject *Sender)
{
    Label9->Caption=140-Memo1->Lines->Text.Length();
}
//---------------------------------------------------------------------------
void __fastcall TForm1::SpeedButton2Click(TObject *Sender)
{
    Close();
}
//---------------------------------------------------------------------------
void __fastcall TForm1::Label11Click(TObject *Sender)
{
    ShellExecute(Handle,NULL,"http://www.goalsoft.net/",NULL,NULL,SW_SHOWNORMAL);
}
//---------------------------------------------------------------------------
void __fastcall TForm1::SpeedButton1Click(TObject *Sender)
{
    if(Edit1->Text.Trim().Length()==0)
    {
        ShowMessage("請輸入帳號");
        return;
    }
    else if(Edit2->Text.Trim().Length()==0)
    {
        ShowMessage("請輸入密碼");
        return;
    }
    else if(Edit3->Text.Trim().Length()==0)
    {
        ShowMessage("請輸入對方手機門號");
        return;
    }
    else if(Memo1->Text.Trim().Length()==0)
    {
        ShowMessage("請輸入簡訊內容");
        return;
    }
    SMSsl->Clear();
    SMSms->Clear();
    AnsiString CharBuffer="username=";
    CharBuffer=CharBuffer+Edit1->Text.Trim();   // 加入 ID
    CharBuffer=CharBuffer+"&password=";
    CharBuffer=CharBuffer+Edit2->Text.Trim();   // 加入 Password
    CharBuffer=CharBuffer+"&mobile=";
    CharBuffer=CharBuffer+Edit3->Text.Trim();   // 加入 手機號碼
    CharBuffer=CharBuffer+"&message=";
    CharBuffer=CharBuffer+Memo1->Text.Trim();   // 加入簡訊
    SMSsl->Add(CharBuffer);
    HTTP1->Post("http://api.twsms.com/smsSend.php",SMSsl,SMSms);
    char *Mo=new char[SMSms->Size+1];
    SMSms->Position=0;
    SMSms->Read(Mo,SMSms->Size);
    if(Mo[0]=='0'&&Mo[1]=='0')
    {
        MessageBox(Handle,"傳送成功！\r\n\r\n感謝您的使用。","傳送成功",MB_OK|MB_ICONINFORMATION|MB_TOPMOST);
    }
    else
    {
        CharBuffer="傳送失敗！\r\n\r\n台灣簡訊伺服器回傳碼=";
        CharBuffer=Mo[0]+Mo[1];
        MessageBox(Handle,CharBuffer.c_str(),"傳送失敗",MB_OK|MB_ICONERROR|MB_TOPMOST);
    }
    delete[] Mo;
}
//---------------------------------------------------------------------------
