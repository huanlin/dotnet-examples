object Form1: TForm1
  Left = 325
  Top = 185
  BorderIcons = [biSystemMenu]
  BorderStyle = bsSingle
  Caption = 'HTTP '#25163#27231#31777#35338
  ClientHeight = 263
  ClientWidth = 440
  Color = clBtnFace
  Font.Charset = ANSI_CHARSET
  Font.Color = clWindowText
  Font.Height = -13
  Font.Name = #26032#32048#26126#39636
  Font.Style = []
  OldCreateOrder = False
  Position = poScreenCenter
  Scaled = False
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 13
  object Label5: TLabel
    Left = 222
    Top = 6
    Width = 97
    Height = 13
    Caption = #30332#36865#21040#25163#27231#34399#30908' :'
    Font.Charset = ANSI_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = #26032#32048#26126#39636
    Font.Style = []
    ParentFont = False
  end
  object Label6: TLabel
    Left = 222
    Top = 72
    Width = 58
    Height = 13
    Caption = #30332#36865#31777#35338' :'
    Font.Charset = ANSI_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = #26032#32048#26126#39636
    Font.Style = []
    ParentFont = False
  end
  object Label4: TLabel
    Left = 12
    Top = 201
    Width = 55
    Height = 13
    Caption = 'Event Log :'
    Visible = False
  end
  object Memo1: TMemo
    Left = 183
    Top = 204
    Width = 185
    Height = 89
    Lines.Strings = (
      'Memo1')
    TabOrder = 8
    Visible = False
  end
  object LogList: TListBox
    Left = 0
    Top = 161
    Width = 440
    Height = 75
    Color = cl3DLight
    ItemHeight = 13
    TabOrder = 6
    Visible = False
  end
  object Panel1: TPanel
    Left = 0
    Top = 203
    Width = 440
    Height = 41
    Align = alBottom
    BevelOuter = bvNone
    TabOrder = 0
    object Label1: TLabel
      Left = 18
      Top = 15
      Width = 123
      Height = 13
      Caption = #30003#35531#20351#29992#21488#28771#31777#35338#32178' :'
      Font.Charset = CHINESEBIG5_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = #26032#32048#26126#39636
      Font.Style = []
      ParentFont = False
    end
    object Label2: TLabel
      Left = 144
      Top = 15
      Width = 110
      Height = 13
      Caption = 'http://www.twsms.com'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clBlue
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsUnderline]
      ParentFont = False
      OnClick = Label2Click
    end
    object BitBtn1: TBitBtn
      Left = 270
      Top = 9
      Width = 75
      Height = 25
      Caption = '&S '#36865#20986
      TabOrder = 0
      OnClick = BitBtn1Click
      Kind = bkOK
    end
    object BitBtn2: TBitBtn
      Left = 351
      Top = 9
      Width = 75
      Height = 25
      Caption = '&X '#36864#38626
      TabOrder = 1
      Kind = bkClose
    end
  end
  object StatusBar1: TStatusBar
    Left = 0
    Top = 244
    Width = 440
    Height = 19
    Panels = <>
    SimplePanel = False
  end
  object SendToNo: TMemo
    Left = 222
    Top = 24
    Width = 211
    Height = 43
    ScrollBars = ssVertical
    TabOrder = 1
  end
  object SendMsg: TMemo
    Left = 222
    Top = 90
    Width = 211
    Height = 112
    Lines.Strings = (
      #28204#35430#34249#30001#21488#28771#31777#35338#32178'HTTP'
      #30332#25163#27231#31777#35338)
    ScrollBars = ssBoth
    TabOrder = 2
  end
  object SMSUser: TLabeledEdit
    Left = 12
    Top = 21
    Width = 199
    Height = 21
    EditLabel.Width = 136
    EditLabel.Height = 13
    EditLabel.Caption = #21488#28771#31777#35338#32178#20351#29992#32773#21517#31281' :'
    EditLabel.Font.Charset = ANSI_CHARSET
    EditLabel.Font.Color = clWindowText
    EditLabel.Font.Height = -13
    EditLabel.Font.Name = #26032#32048#26126#39636
    EditLabel.Font.Style = []
    EditLabel.ParentFont = False
    LabelPosition = lpAbove
    LabelSpacing = 3
    TabOrder = 3
  end
  object SMSPwd: TLabeledEdit
    Left = 12
    Top = 66
    Width = 199
    Height = 21
    EditLabel.Width = 136
    EditLabel.Height = 13
    EditLabel.Caption = #21488#28771#31777#35338#32178#20351#29992#32773#23494#30908' :'
    LabelPosition = lpAbove
    LabelSpacing = 3
    PasswordChar = '*'
    TabOrder = 4
  end
  object GroupBox1: TGroupBox
    Left = 9
    Top = 96
    Width = 205
    Height = 106
    Caption = 'Proxy '#35373#23450' :'
    TabOrder = 5
    object Label3: TLabel
      Left = 18
      Top = 57
      Width = 26
      Height = 13
      Caption = 'Port :'
    end
    object ProxyHost: TLabeledEdit
      Left = 18
      Top = 33
      Width = 88
      Height = 21
      EditLabel.Width = 32
      EditLabel.Height = 13
      EditLabel.Caption = #20027#27231' :'
      LabelPosition = lpAbove
      LabelSpacing = 3
      TabOrder = 0
    end
    object ProxyPort: TSpinEdit
      Left = 18
      Top = 72
      Width = 88
      Height = 22
      MaxValue = 0
      MinValue = 0
      TabOrder = 1
      Value = 8080
    end
    object ProxyUser: TLabeledEdit
      Left = 111
      Top = 33
      Width = 85
      Height = 21
      EditLabel.Width = 52
      EditLabel.Height = 13
      EditLabel.Caption = 'UserName'
      LabelPosition = lpAbove
      LabelSpacing = 3
      TabOrder = 2
    end
    object ProxyPwd: TLabeledEdit
      Left = 111
      Top = 72
      Width = 85
      Height = 21
      EditLabel.Width = 47
      EditLabel.Height = 13
      EditLabel.Caption = 'Password'
      LabelPosition = lpAbove
      LabelSpacing = 3
      PasswordChar = '*'
      TabOrder = 3
    end
  end
  object IdHTTP1: TIdHTTP
    MaxLineAction = maException
    ReadTimeout = 30000
    RecvBufferSize = 2048
    SendBufferSize = 2048
    AllowCookies = True
    ProxyParams.BasicAuthentication = False
    ProxyParams.ProxyPort = 0
    Request.ContentLength = -1
    Request.ContentRangeEnd = 0
    Request.ContentRangeStart = 0
    Request.ContentType = 'application/x-www-form-urlencoded'
    Request.Accept = 'text/html, */*'
    Request.BasicAuthentication = False
    Request.UserAgent = 'Mozilla/3.0 (compatible; Indy Library)'
    HTTPOptions = [hoKeepOrigProtocol]
    Left = 81
    Top = 213
  end
  object IdLogEvent1: TIdLogEvent
    Active = True
    OnReceived = IdLogEvent1Received
    OnSent = IdLogEvent1Sent
    OnStatus = IdLogEvent1Status
    Left = 117
    Top = 213
  end
  object IdAntiFreeze1: TIdAntiFreeze
    Left = 45
    Top = 213
  end
end
