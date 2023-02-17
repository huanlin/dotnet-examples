VERSION 5.00
Object = "{48E59290-9880-11CF-9754-00AA00C00908}#1.0#0"; "MSINET.OCX"
Begin VB.Form Form1 
   Caption         =   "Form1"
   ClientHeight    =   4785
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   5520
   LinkTopic       =   "Form1"
   ScaleHeight     =   4785
   ScaleWidth      =   5520
   StartUpPosition =   3  '系統預設值
   Begin InetCtlsObjects.Inet Inet1 
      Left            =   3720
      Top             =   360
      _ExtentX        =   1005
      _ExtentY        =   1005
      _Version        =   393216
   End
   Begin VB.CommandButton Command2 
      Caption         =   "結束"
      Height          =   495
      Left            =   3360
      TabIndex        =   5
      Top             =   3840
      Width           =   1695
   End
   Begin VB.CommandButton Command1 
      Caption         =   "傳送"
      Height          =   495
      Left            =   1320
      TabIndex        =   4
      Top             =   3840
      Width           =   1695
   End
   Begin VB.TextBox message 
      Height          =   1695
      Left            =   1320
      TabIndex        =   3
      Top             =   2040
      Width           =   3735
   End
   Begin VB.TextBox num 
      Alignment       =   2  '置中對齊
      BeginProperty Font 
         Name            =   "新細明體"
         Size            =   14.25
         Charset         =   136
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   1320
      TabIndex        =   2
      Top             =   1560
      Width           =   2055
   End
   Begin VB.TextBox password 
      Alignment       =   2  '置中對齊
      BeginProperty Font 
         Name            =   "新細明體"
         Size            =   14.25
         Charset         =   136
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   1320
      TabIndex        =   1
      Top             =   960
      Width           =   2055
   End
   Begin VB.TextBox user 
      Alignment       =   2  '置中對齊
      BeginProperty Font 
         Name            =   "新細明體"
         Size            =   14.25
         Charset         =   136
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   405
      Left            =   1320
      TabIndex        =   0
      Top             =   360
      Width           =   2055
   End
   Begin VB.Frame Frame1 
      Caption         =   "VB發送"
      Height          =   4575
      Left            =   120
      TabIndex        =   6
      Top             =   120
      Width           =   5295
      Begin VB.Label Label4 
         Caption         =   "內      容:"
         BeginProperty Font 
            Name            =   "新細明體"
            Size            =   12
            Charset         =   136
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   120
         TabIndex        =   10
         Top             =   2040
         Width           =   1095
      End
      Begin VB.Label Label3 
         Caption         =   "手      機:"
         BeginProperty Font 
            Name            =   "新細明體"
            Size            =   12
            Charset         =   136
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   120
         TabIndex        =   9
         Top             =   1440
         Width           =   975
      End
      Begin VB.Label Label2 
         Caption         =   "密      碼:"
         BeginProperty Font 
            Name            =   "新細明體"
            Size            =   12
            Charset         =   136
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   120
         TabIndex        =   8
         Top             =   840
         Width           =   975
      End
      Begin VB.Label Label1 
         Caption         =   "帳      號:"
         BeginProperty Font 
            Name            =   "新細明體"
            Size            =   12
            Charset         =   136
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   120
         TabIndex        =   7
         Top             =   360
         Width           =   975
      End
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub Command1_Click()
Inet1.Execute "http://api.twsms.com/smsSend.php?username=" & user.Text & "&password=" & password.Text & "&mobile=" & num.Text & "&message=" & message.Text, "GET"
MsgBox "完成發送!"
End Sub

Private Sub Command2_Click()
End
End Sub
