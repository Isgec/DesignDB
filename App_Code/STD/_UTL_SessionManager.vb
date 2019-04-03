Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Net
Imports System.Net.Mail
Imports System.Net.Mail.SmtpClient
Imports System.Web
Imports System
Namespace SIS.SYS.Utilities
  <AttributeUsage(AttributeTargets.All, AllowMultiple:=False, Inherited:=True)>
  Public Class lgSkipAttribute
    Inherits Attribute
    Private _DoNotWrite As Boolean = True
    Public Property DoNotWrite() As Boolean
      Get
        Return _DoNotWrite
      End Get
      Set(ByVal value As Boolean)
        _DoNotWrite = value
      End Set
    End Property
  End Class
  Public Class SessionManager
    Public Shared ci As System.Globalization.CultureInfo = New System.Globalization.CultureInfo("en-GB", True)

    Public Shared Function GetComputerName(ByVal clientIP As String) As String
      Dim he As IPHostEntry = Nothing
      Try
        he = System.Net.Dns.GetHostEntry(clientIP)
        Return he.HostName
      Catch ex As Exception
      End Try
      Return ""
    End Function
    Public Shared Sub CreateSessionEnvironement()
      With HttpContext.Current
        .Session("ApplicationID") = 0
        .Session("ApplicationDefaultPage") = ""
        .Session("LoginID") = Nothing
        .Session("PageSizeProvider") = False
        .Session("PageNoProvider") = False
      End With
    End Sub
    Public Shared Sub InitializeEnvironment()
      HttpContext.Current.Session("LoginID") = System.Web.HttpContext.Current.User.Identity.Name
      CommonInitialize()
    End Sub
    Public Shared Sub InitializeEnvironment(ByVal UserID As String)
      HttpContext.Current.Session("LoginID") = UserID
      CommonInitialize()
    End Sub
    Private Shared Sub CommonInitialize()
      With HttpContext.Current
        Dim PageNoProvider As String = System.Configuration.ConfigurationManager.AppSettings("PageNoProvider")
        If Not PageNoProvider Is Nothing Then
          .Session("PageNoProvider") = Convert.ToBoolean(PageNoProvider)
        Else
          .Session("PageNoProvider") = True
        End If
        Dim PageSizeProvider As String = System.Configuration.ConfigurationManager.AppSettings("PageSizeProvider")
        If Not PageSizeProvider Is Nothing Then
          .Session("PageSizeProvider") = Convert.ToBoolean(PageSizeProvider)
        Else
          .Session("PageSizeProvider") = True
        End If
      End With
      '===========
      InitNavBar()
      '===========
      '==================
      'Application Spacific Initializations
      '========================
      SIS.SYS.Utilities.ApplicationSpacific.Initialize()
    End Sub
    Public Shared Sub DestroySessionEnvironement()
      With HttpContext.Current
        .Session.Clear()
        .Session.Abandon()
      End With
    End Sub
    Public Shared Sub InitNavBar()
      With HttpContext.Current
        Dim abc(,) As String
        ReDim abc(1, 0)
        abc(0, 0) = ""
        abc(1, 0) = ""
        .Session("NavBar") = abc
      End With
    End Sub
    Public Shared Sub PushNavBar(ByVal Page As String, ByVal url As String)
      If url.IndexOf("skip=1") > -1 Then Return
      With HttpContext.Current
        Dim abc(,) As String = .Session("NavBar")
        Dim curSize As Integer = abc.GetLength(1)
        Dim Found As Boolean = False
        For I As Integer = 0 To curSize - 1
          If abc(0, I) = Page Then
            Found = True
            ReDim Preserve abc(1, I)
            Exit For
          End If
        Next
        If Not Found Then
          Dim newSize As Integer = abc.GetLength(1)
          ReDim Preserve abc(1, newSize)
          abc(0, newSize) = Page
          abc(1, newSize) = url
        End If
        .Session("NavBar") = abc
      End With
    End Sub
    Public Shared Function PopNavBar() As String
      Dim mRet As String = HttpContext.Current.Session("ApplicationDefaultPage")
      With HttpContext.Current
        Dim abc(,) As String = .Session("NavBar")
        Dim curSize As Integer = abc.GetLength(1)
        If curSize > 1 Then
          mRet = abc(1, curSize - 1)
        End If
        .Session("NavBar") = abc
      End With
      Return mRet
    End Function
  End Class
  Public Class GlobalVariables
    Public Shared Function PageNo(ByVal PageName As String, ByVal LoginID As String) As Integer
      Dim _Result As Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Dim mSql As String = "SELECT TOP 1 [SYS_LGPageSize].[PageNo] FROM [SYS_LGPageSize] WHERE [SYS_LGPageSize].[PageName] = '" & PageName & "' AND [SYS_LGPageSize].[LoginID] = '" & LoginID & "' AND [SYS_LGPageSize].[ApplicationID] = '" & HttpContext.Current.Session("ApplicationID") & "'"
          Cmd.CommandType = System.Data.CommandType.Text
          Cmd.CommandText = mSql
          Con.Open()
          _Result = Cmd.ExecuteScalar()
          If _Result = 0 Then
            _Result = 0
          End If
        End Using
      End Using
      Return _Result
    End Function
    Public Shared Function PageNo(ByVal PageName As String, ByVal LoginID As String, ByVal Position As Integer) As Integer
      Dim _Result As Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spSYS_LG_SetPageNumber"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PageName", SqlDbType.NVarChar, 250, PageName)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 20, LoginID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PageNo", SqlDbType.Int, 10, Position)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplicationID", SqlDbType.Int, 10, Global.System.Web.HttpContext.Current.Session("ApplicationID"))
          Con.Open()
          Cmd.ExecuteNonQuery()
        End Using
      End Using
      Return _Result
    End Function
    Public Shared Function PageSize(ByVal PageName As String, ByVal LoginID As String) As Integer
      Dim _Result As Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Dim mSql As String = "SELECT TOP 1 [SYS_LGPageSize].[PageSize] FROM [SYS_LGPageSize] WHERE [SYS_LGPageSize].[PageName] = '" & PageName & "' AND [SYS_LGPageSize].[LoginID] = '" & LoginID & "' AND [SYS_LGPageSize].[ApplicationID] = " & HttpContext.Current.Session("ApplicationID")
          Cmd.CommandType = System.Data.CommandType.Text
          Cmd.CommandText = mSql
          Con.Open()
          _Result = Cmd.ExecuteScalar()
          If _Result = 0 Then
            _Result = 10
          End If
        End Using
      End Using
      Return _Result
    End Function
    Public Shared Function PageSize(ByVal PageName As String, ByVal LoginID As String, ByVal Size As Integer) As Integer
      Dim _Result As Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spSYS_LG_SetPageSize"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PageName", SqlDbType.NVarChar, 250, PageName)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 20, LoginID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PageSize", SqlDbType.Int, 10, Size)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplicationID", SqlDbType.Int, 10, Global.System.Web.HttpContext.Current.Session("ApplicationID"))
          Con.Open()
          Cmd.ExecuteNonQuery()
        End Using
      End Using
      Return _Result
    End Function
  End Class
  Public Class ValidateURL
    Public Shared Function Validate(ByVal PageUrl As String) As Boolean
      Dim aParts() As String = PageUrl.Split("/".ToCharArray)
      If aParts.Length <= 3 Then
        Return True
      End If
      Return ValidateURL(PageUrl)
    End Function
    Private Shared Function ValidateURL(ByVal PageUrl As String) As Boolean
      'Return True
      Dim _Result As Boolean = False
      Dim afile() As String = PageUrl.Split("/".ToCharArray)
      Dim FileName As String = afile(afile.GetUpperBound(0)).ToString
      Dim UserCase As String = FileName.Substring(0, 3)
      If FileName.StartsWith("RP_") Then Return True
      Select Case UserCase
        Case "AF_"
          FileName = FileName.Replace("AF_", "GF_")
        Case "EF_"
          FileName = FileName.Replace("EF_", "GF_")
        Case "DF_"
          FileName = FileName.Replace("DF_", "GD_")
      End Select
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spSYS_LG_VRSessionByUserFile"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FileName", SqlDbType.NVarChar, 251, FileName)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserName", SqlDbType.NVarChar, 20, HttpContext.Current.User.Identity.Name)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplicationID", SqlDbType.NVarChar, 50, Global.System.Web.HttpContext.Current.Session("ApplicationID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Select Case UserCase
              Case "AF_"
                If Reader("InsertForm") Then
                  _Result = True
                End If
              Case "EF_"
                If Reader("UpdateForm") Then
                  _Result = True
                End If
              Case "DF_"
                If Reader("DisplayForm") Then
                  _Result = True
                End If
              Case "GD_"
                If Reader("DisplayGrid") Then
                  _Result = True
                End If
              Case Else    '"GF_", "GT_", "GU_", "GP_"
                If Reader("MaintainGrid") Then
                  SYS.Utilities.SessionManager.InitNavBar()
                  _Result = True
                End If
            End Select
          End If
          Reader.Close()
        End Using
      End Using
      Return _Result
    End Function
  End Class
  Public Class rptxHandler
    Implements IHttpHandler
    Public ReadOnly Property IsReusable() As Boolean Implements System.Web.IHttpHandler.IsReusable
      Get
        Return True
      End Get
    End Property
    Public Sub ProcessRequest(ByVal context As System.Web.HttpContext) Implements System.Web.IHttpHandler.ProcessRequest
      SIS.SYS.Utilities.ApplicationSpacific.ApplicationReports(context)
    End Sub
  End Class
End Namespace
