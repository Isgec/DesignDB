Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TA
  <DataObject()> _
  Partial Public Class taWebUsers
    Private Shared _RecordCount As Integer
    Private _LoginID As String = ""
    Private _UserName As String = ""
    Private _UserFullName As String = ""
    Private _C_CompanyID As String = ""
    Private _C_DivisionID As String = ""
    Private _C_OfficeID As String = ""
    Private _C_DepartmentID As String = ""
    Private _C_DesignationID As String = ""
    Private _ActiveState As String = ""
    Private _MobileNo As String = ""
    Private _ExtnNo As String = ""
    Private _Contractual As Boolean = False
    Private _EMailID As String = ""
    Private _HRM_Companies2_Description As String = ""
    Private _HRM_Departments3_Description As String = ""
    Private _HRM_Designations4_Description As String = ""
    Private _HRM_Divisions5_Description As String = ""
    Private _HRM_Offices6_Description As String = ""
    Private _FK_USR_Company As SIS.QCM.qcmCompanies = Nothing
    Private _FK_USR_Department As SIS.TA.taDepartments = Nothing
    Private _FK_USR_Designation As SIS.QCM.qcmDesignations = Nothing
    Private _FK_USR_Division As SIS.TA.taDivisions = Nothing
    Private _FK_USR_OfficeID As SIS.QCM.qcmOffices = Nothing
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
    Public Property LoginID() As String
      Get
        Return _LoginID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _LoginID = ""
         Else
           _LoginID = value
         End If
      End Set
    End Property
    Public Property UserName() As String
      Get
        Return _UserName
      End Get
      Set(ByVal value As String)
        _UserName = value
      End Set
    End Property
    Public Property UserFullName() As String
      Get
        Return _UserFullName
      End Get
      Set(ByVal value As String)
        _UserFullName = value
      End Set
    End Property
    Public Property C_CompanyID() As String
      Get
        Return _C_CompanyID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _C_CompanyID = ""
         Else
           _C_CompanyID = value
         End If
      End Set
    End Property
    Public Property C_DivisionID() As String
      Get
        Return _C_DivisionID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _C_DivisionID = ""
         Else
           _C_DivisionID = value
         End If
      End Set
    End Property
    Public Property C_OfficeID() As String
      Get
        Return _C_OfficeID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _C_OfficeID = ""
         Else
           _C_OfficeID = value
         End If
      End Set
    End Property
    Public Property C_DepartmentID() As String
      Get
        Return _C_DepartmentID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _C_DepartmentID = ""
         Else
           _C_DepartmentID = value
         End If
      End Set
    End Property
    Public Property C_DesignationID() As String
      Get
        Return _C_DesignationID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _C_DesignationID = ""
         Else
           _C_DesignationID = value
         End If
      End Set
    End Property
    Public Property ActiveState() As String
      Get
        Return _ActiveState
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ActiveState = ""
         Else
           _ActiveState = value
         End If
      End Set
    End Property
    Public Property MobileNo() As String
      Get
        Return _MobileNo
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _MobileNo = ""
         Else
           _MobileNo = value
         End If
      End Set
    End Property
    Public Property ExtnNo() As String
      Get
        Return _ExtnNo
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ExtnNo = ""
         Else
           _ExtnNo = value
         End If
      End Set
    End Property
    Public Property Contractual() As Boolean
      Get
        Return _Contractual
      End Get
      Set(ByVal value As Boolean)
        _Contractual = value
      End Set
    End Property
    Public Property EMailID() As String
      Get
        Return _EMailID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _EMailID = ""
         Else
           _EMailID = value
         End If
      End Set
    End Property
    Public Property HRM_Companies2_Description() As String
      Get
        Return _HRM_Companies2_Description
      End Get
      Set(ByVal value As String)
        _HRM_Companies2_Description = value
      End Set
    End Property
    Public Property HRM_Departments3_Description() As String
      Get
        Return _HRM_Departments3_Description
      End Get
      Set(ByVal value As String)
        _HRM_Departments3_Description = value
      End Set
    End Property
    Public Property HRM_Designations4_Description() As String
      Get
        Return _HRM_Designations4_Description
      End Get
      Set(ByVal value As String)
        _HRM_Designations4_Description = value
      End Set
    End Property
    Public Property HRM_Divisions5_Description() As String
      Get
        Return _HRM_Divisions5_Description
      End Get
      Set(ByVal value As String)
        _HRM_Divisions5_Description = value
      End Set
    End Property
    Public Property HRM_Offices6_Description() As String
      Get
        Return _HRM_Offices6_Description
      End Get
      Set(ByVal value As String)
        _HRM_Offices6_Description = value
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _UserFullName.ToString.PadRight(50, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _LoginID
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
    Public Class PKtaWebUsers
      Private _LoginID As String = ""
      Public Property LoginID() As String
        Get
          Return _LoginID
        End Get
        Set(ByVal value As String)
          _LoginID = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_USR_Company() As SIS.QCM.qcmCompanies
      Get
        If _FK_USR_Company Is Nothing Then
          _FK_USR_Company = SIS.QCM.qcmCompanies.qcmCompaniesGetByID(_C_CompanyID)
        End If
        Return _FK_USR_Company
      End Get
    End Property
    Public ReadOnly Property FK_USR_Department() As SIS.TA.taDepartments
      Get
        If _FK_USR_Department Is Nothing Then
          _FK_USR_Department = SIS.TA.taDepartments.taDepartmentsGetByID(_C_DepartmentID)
        End If
        Return _FK_USR_Department
      End Get
    End Property
    Public ReadOnly Property FK_USR_Designation() As SIS.QCM.qcmDesignations
      Get
        If _FK_USR_Designation Is Nothing Then
          _FK_USR_Designation = SIS.QCM.qcmDesignations.qcmDesignationsGetByID(_C_DesignationID)
        End If
        Return _FK_USR_Designation
      End Get
    End Property
    Public ReadOnly Property FK_USR_Division() As SIS.TA.taDivisions
      Get
        If _FK_USR_Division Is Nothing Then
          _FK_USR_Division = SIS.TA.taDivisions.taDivisionsGetByID(_C_DivisionID)
        End If
        Return _FK_USR_Division
      End Get
    End Property
    Public ReadOnly Property FK_USR_OfficeID() As SIS.QCM.qcmOffices
      Get
        If _FK_USR_OfficeID Is Nothing Then
          _FK_USR_OfficeID = SIS.QCM.qcmOffices.qcmOfficesGetByID(_C_OfficeID)
        End If
        Return _FK_USR_OfficeID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taWebUsersSelectList(ByVal OrderBy As String) As List(Of SIS.TA.taWebUsers)
      Dim Results As List(Of SIS.TA.taWebUsers) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaWebUsersSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TA.taWebUsers)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taWebUsers(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taWebUsersGetNewRecord() As SIS.TA.taWebUsers
      Return New SIS.TA.taWebUsers()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taWebUsersGetByID(ByVal LoginID As String) As SIS.TA.taWebUsers
      Dim Results As SIS.TA.taWebUsers = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaWebUsersSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID",SqlDbType.NVarChar,LoginID.ToString.Length, LoginID)
          'SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.TA.taWebUsers(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taWebUsersSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.TA.taWebUsers)
      Dim Results As List(Of SIS.TA.taWebUsers) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sptaWebUsersSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sptaWebUsersSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TA.taWebUsers)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taWebUsers(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function taWebUsersSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
'    Autocomplete Method
    Public Shared Function SelecttaWebUsersAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaWebUsersAutoCompleteList"
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
            Dim Tmp As SIS.TA.taWebUsers = New SIS.TA.taWebUsers(Reader)
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(Tmp.DisplayField, Tmp.PrimaryKey))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results.ToArray
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      On Error Resume Next
      If Convert.IsDBNull(Reader("LoginID")) Then
        _LoginID = String.Empty
      Else
        _LoginID = Ctype(Reader("LoginID"), String)
      End If
      _UserName = Ctype(Reader("UserName"),String)
      _UserFullName = Ctype(Reader("UserFullName"),String)
      If Convert.IsDBNull(Reader("C_CompanyID")) Then
        _C_CompanyID = String.Empty
      Else
        _C_CompanyID = Ctype(Reader("C_CompanyID"), String)
      End If
      If Convert.IsDBNull(Reader("C_DivisionID")) Then
        _C_DivisionID = String.Empty
      Else
        _C_DivisionID = Ctype(Reader("C_DivisionID"), String)
      End If
      If Convert.IsDBNull(Reader("C_OfficeID")) Then
        _C_OfficeID = String.Empty
      Else
        _C_OfficeID = Ctype(Reader("C_OfficeID"), String)
      End If
      If Convert.IsDBNull(Reader("C_DepartmentID")) Then
        _C_DepartmentID = String.Empty
      Else
        _C_DepartmentID = Ctype(Reader("C_DepartmentID"), String)
      End If
      If Convert.IsDBNull(Reader("C_DesignationID")) Then
        _C_DesignationID = String.Empty
      Else
        _C_DesignationID = Ctype(Reader("C_DesignationID"), String)
      End If
      If Convert.IsDBNull(Reader("ActiveState")) Then
        _ActiveState = String.Empty
      Else
        _ActiveState = Ctype(Reader("ActiveState"), String)
      End If
      If Convert.IsDBNull(Reader("MobileNo")) Then
        _MobileNo = String.Empty
      Else
        _MobileNo = Ctype(Reader("MobileNo"), String)
      End If
      If Convert.IsDBNull(Reader("ExtnNo")) Then
        _ExtnNo = String.Empty
      Else
        _ExtnNo = Ctype(Reader("ExtnNo"), String)
      End If
      _Contractual = Ctype(Reader("Contractual"),Boolean)
      If Convert.IsDBNull(Reader("EMailID")) Then
        _EMailID = String.Empty
      Else
        _EMailID = Ctype(Reader("EMailID"), String)
      End If
      _HRM_Companies2_Description = Ctype(Reader("HRM_Companies2_Description"),String)
      _HRM_Departments3_Description = Ctype(Reader("HRM_Departments3_Description"),String)
      _HRM_Designations4_Description = Ctype(Reader("HRM_Designations4_Description"),String)
      _HRM_Divisions5_Description = Ctype(Reader("HRM_Divisions5_Description"),String)
      _HRM_Offices6_Description = Ctype(Reader("HRM_Offices6_Description"),String)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
