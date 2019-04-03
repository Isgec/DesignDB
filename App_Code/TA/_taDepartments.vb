Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TA
  <DataObject()> _
  Partial Public Class taDepartments
    Private Shared _RecordCount As Integer
    Private _Description As String = ""
    Private _DepartmentHead As String = ""
    Private _BusinessHead As String = ""
    Private _DepartmentID As String = ""
    Private _HRM_Employees2_EmployeeName As String = ""
    Private _HRM_Employees1_EmployeeName As String = ""
    Private _FK_HRM_Departments_BusinessHead As SIS.TA.taEmployees = Nothing
    Private _FK_HRM_Departments_DepartmentHead As SIS.TA.taEmployees = Nothing
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
    Public Property Description() As String
      Get
        Return _Description
      End Get
      Set(ByVal value As String)
        _Description = value
      End Set
    End Property
    Public Property DepartmentHead() As String
      Get
        Return _DepartmentHead
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _DepartmentHead = ""
         Else
           _DepartmentHead = value
         End If
      End Set
    End Property
    Public Property BusinessHead() As String
      Get
        Return _BusinessHead
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _BusinessHead = ""
         Else
           _BusinessHead = value
         End If
      End Set
    End Property
    Public Property DepartmentID() As String
      Get
        Return _DepartmentID
      End Get
      Set(ByVal value As String)
        _DepartmentID = value
      End Set
    End Property
    Public Property HRM_Employees2_EmployeeName() As String
      Get
        Return _HRM_Employees2_EmployeeName
      End Get
      Set(ByVal value As String)
        _HRM_Employees2_EmployeeName = value
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
        Return "" & _Description.ToString.PadRight(30, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _DepartmentID
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
    Public Class PKtaDepartments
      Private _DepartmentID As String = ""
      Public Property DepartmentID() As String
        Get
          Return _DepartmentID
        End Get
        Set(ByVal value As String)
          _DepartmentID = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_HRM_Departments_BusinessHead() As SIS.TA.taEmployees
      Get
        If _FK_HRM_Departments_BusinessHead Is Nothing Then
          _FK_HRM_Departments_BusinessHead = SIS.TA.taEmployees.taEmployeesGetByID(_BusinessHead)
        End If
        Return _FK_HRM_Departments_BusinessHead
      End Get
    End Property
    Public ReadOnly Property FK_HRM_Departments_DepartmentHead() As SIS.TA.taEmployees
      Get
        If _FK_HRM_Departments_DepartmentHead Is Nothing Then
          _FK_HRM_Departments_DepartmentHead = SIS.TA.taEmployees.taEmployeesGetByID(_DepartmentHead)
        End If
        Return _FK_HRM_Departments_DepartmentHead
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taDepartmentsSelectList(ByVal OrderBy As String) As List(Of SIS.TA.taDepartments)
      Dim Results As List(Of SIS.TA.taDepartments) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaDepartmentsSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TA.taDepartments)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taDepartments(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taDepartmentsGetNewRecord() As SIS.TA.taDepartments
      Return New SIS.TA.taDepartments()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taDepartmentsGetByID(ByVal DepartmentID As String) As SIS.TA.taDepartments
      Dim Results As SIS.TA.taDepartments = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaDepartmentsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DepartmentID",SqlDbType.NVarChar,DepartmentID.ToString.Length, DepartmentID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.TA.taDepartments(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taDepartmentsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal DepartmentHead As String, ByVal BusinessHead As String) As List(Of SIS.TA.taDepartments)
      Dim Results As List(Of SIS.TA.taDepartments) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sptaDepartmentsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sptaDepartmentsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_DepartmentHead",SqlDbType.NVarChar,8, IIf(DepartmentHead Is Nothing, String.Empty,DepartmentHead))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_BusinessHead",SqlDbType.NVarChar,8, IIf(BusinessHead Is Nothing, String.Empty,BusinessHead))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TA.taDepartments)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taDepartments(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function taDepartmentsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal DepartmentHead As String, ByVal BusinessHead As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taDepartmentsGetByID(ByVal DepartmentID As String, ByVal Filter_DepartmentHead As String, ByVal Filter_BusinessHead As String) As SIS.TA.taDepartments
      Return taDepartmentsGetByID(DepartmentID)
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function taDepartmentsUpdate(ByVal Record As SIS.TA.taDepartments) As SIS.TA.taDepartments
      Dim _Rec As SIS.TA.taDepartments = SIS.TA.taDepartments.taDepartmentsGetByID(Record.DepartmentID)
      With _Rec
        .Description = Record.Description
        .DepartmentHead = Record.DepartmentHead
        .BusinessHead = Record.BusinessHead
      End With
      Return SIS.TA.taDepartments.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.TA.taDepartments) As SIS.TA.taDepartments
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaDepartmentsUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_DepartmentID",SqlDbType.NVarChar,7, Record.DepartmentID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,31, Record.Description)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DepartmentHead",SqlDbType.NVarChar,9, Iif(Record.DepartmentHead= "" ,Convert.DBNull, Record.DepartmentHead))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BusinessHead",SqlDbType.NVarChar,9, Iif(Record.BusinessHead= "" ,Convert.DBNull, Record.BusinessHead))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DepartmentID",SqlDbType.NVarChar,7, Record.DepartmentID)
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
    Public Shared Function SelecttaDepartmentsAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaDepartmentsAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix),0,IIf(Prefix.ToLower=Prefix, 0, 1)))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(30, " "),""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.TA.taDepartments = New SIS.TA.taDepartments(Reader)
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(Tmp.DisplayField, Tmp.PrimaryKey))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results.ToArray
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      On Error Resume Next
      _Description = Ctype(Reader("Description"),String)
      'If Convert.IsDBNull(Reader("DepartmentHead")) Then
      '  _DepartmentHead = String.Empty
      'Else
      '  _DepartmentHead = Ctype(Reader("DepartmentHead"), String)
      'End If
      'If Convert.IsDBNull(Reader("BusinessHead")) Then
      '  _BusinessHead = String.Empty
      'Else
      '  _BusinessHead = Ctype(Reader("BusinessHead"), String)
      'End If
      _DepartmentID = Ctype(Reader("DepartmentID"),String)
      '_HRM_Employees2_EmployeeName = Ctype(Reader("HRM_Employees2_EmployeeName"),String)
      '_HRM_Employees1_EmployeeName = Ctype(Reader("HRM_Employees1_EmployeeName"),String)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
