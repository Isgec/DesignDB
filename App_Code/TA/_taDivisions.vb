Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TA
  <DataObject()> _
  Partial Public Class taDivisions
    Private Shared _RecordCount As Integer
    Private _DivisionID As String = ""
    Private _Description As String = ""
    Private _DivisionHead As String = ""
    Private _ERP_EU As String = ""
    Private _ERP_Div As String = ""
    Private _HRM_Employees1_EmployeeName As String = ""
    Private _FK_HRM_Divisions_DivisionHead As SIS.TA.taEmployees = Nothing
    Public ReadOnly Property ForeColor() As System.Drawing.Color
      Get
        Dim mRet As System.Drawing.Color = Drawing.Color.Blue
        Try
          mRet = GetColor()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Visible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Enable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Property DivisionID() As String
      Get
        Return _DivisionID
      End Get
      Set(ByVal value As String)
        _DivisionID = value
      End Set
    End Property
    Public Property Description() As String
      Get
        Return _Description
      End Get
      Set(ByVal value As String)
        _Description = value
      End Set
    End Property
    Public Property DivisionHead() As String
      Get
        Return _DivisionHead
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _DivisionHead = ""
         Else
           _DivisionHead = value
         End If
      End Set
    End Property
    Public Property ERP_EU() As String
      Get
        Return _ERP_EU
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ERP_EU = ""
         Else
           _ERP_EU = value
         End If
      End Set
    End Property
    Public Property ERP_Div() As String
      Get
        Return _ERP_Div
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ERP_Div = ""
         Else
           _ERP_Div = value
         End If
      End Set
    End Property
    Public Property HRM_Employees1_EmployeeName() As String
      Get
        Return _HRM_Employees1_EmployeeName
      End Get
      Set(ByVal value As String)
        _HRM_Employees1_EmployeeName = value
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _Description.ToString.PadRight(50, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _DivisionID
      End Get
    End Property
    Public Shared Property RecordCount() As Integer
      Get
        Return _RecordCount
      End Get
      Set(ByVal value As Integer)
        _RecordCount = value
      End Set
    End Property
    Public Class PKtaDivisions
      Private _DivisionID As String = ""
      Public Property DivisionID() As String
        Get
          Return _DivisionID
        End Get
        Set(ByVal value As String)
          _DivisionID = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_HRM_Divisions_DivisionHead() As SIS.TA.taEmployees
      Get
        If _FK_HRM_Divisions_DivisionHead Is Nothing Then
          _FK_HRM_Divisions_DivisionHead = SIS.TA.taEmployees.taEmployeesGetByID(_DivisionHead)
        End If
        Return _FK_HRM_Divisions_DivisionHead
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taDivisionsSelectList(ByVal OrderBy As String) As List(Of SIS.TA.taDivisions)
      Dim Results As List(Of SIS.TA.taDivisions) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaDivisionsSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TA.taDivisions)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taDivisions(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taDivisionsGetNewRecord() As SIS.TA.taDivisions
      Return New SIS.TA.taDivisions()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taDivisionsGetByID(ByVal DivisionID As String) As SIS.TA.taDivisions
      Dim Results As SIS.TA.taDivisions = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaDivisionsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DivisionID",SqlDbType.NVarChar,DivisionID.ToString.Length, DivisionID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.TA.taDivisions(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taDivisionsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.TA.taDivisions)
      Dim Results As List(Of SIS.TA.taDivisions) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sptaDivisionsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sptaDivisionsSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TA.taDivisions)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taDivisions(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function taDivisionsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function taDivisionsUpdate(ByVal Record As SIS.TA.taDivisions) As SIS.TA.taDivisions
      Dim _Rec As SIS.TA.taDivisions = SIS.TA.taDivisions.taDivisionsGetByID(Record.DivisionID)
      With _Rec
        .Description = Record.Description
        .DivisionHead = Record.DivisionHead
        .ERP_EU = Record.ERP_EU
        .ERP_Div = Record.ERP_Div
      End With
      Return SIS.TA.taDivisions.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.TA.taDivisions) As SIS.TA.taDivisions
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaDivisionsUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_DivisionID",SqlDbType.NVarChar,7, Record.DivisionID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DivisionID",SqlDbType.NVarChar,7, Record.DivisionID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,51, Record.Description)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DivisionHead",SqlDbType.NVarChar,9, Iif(Record.DivisionHead= "" ,Convert.DBNull, Record.DivisionHead))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ERP_EU",SqlDbType.NVarChar,11, Iif(Record.ERP_EU= "" ,Convert.DBNull, Record.ERP_EU))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ERP_Div",SqlDbType.NVarChar,11, Iif(Record.ERP_Div= "" ,Convert.DBNull, Record.ERP_Div))
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Con.Open()
          Cmd.ExecuteNonQuery()
          _RecordCount = Cmd.Parameters("@RowCount").Value
        End Using
      End Using
      Return Record
    End Function
'    Autocomplete Method
    Public Shared Function SelecttaDivisionsAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaDivisionsAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix),0,IIf(Prefix.ToLower=Prefix, 0, 1)))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(50, " "),""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.TA.taDivisions = New SIS.TA.taDivisions(Reader)
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(Tmp.DisplayField, Tmp.PrimaryKey))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results.ToArray
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      On Error Resume Next
      _DivisionID = Ctype(Reader("DivisionID"),String)
      _Description = Ctype(Reader("Description"),String)
      If Convert.IsDBNull(Reader("DivisionHead")) Then
        _DivisionHead = String.Empty
      Else
        _DivisionHead = Ctype(Reader("DivisionHead"), String)
      End If
      If Convert.IsDBNull(Reader("ERP_EU")) Then
        _ERP_EU = String.Empty
      Else
        _ERP_EU = Ctype(Reader("ERP_EU"), String)
      End If
      If Convert.IsDBNull(Reader("ERP_Div")) Then
        _ERP_Div = String.Empty
      Else
        _ERP_Div = Ctype(Reader("ERP_Div"), String)
      End If
      _HRM_Employees1_EmployeeName = Ctype(Reader("HRM_Employees1_EmployeeName"),String)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
