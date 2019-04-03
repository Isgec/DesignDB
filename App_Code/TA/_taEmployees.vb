Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TA
  <DataObject()> _
  Partial Public Class taEmployees
    Private Shared _RecordCount As Integer
    Private _CardNo As String = ""
    Private _EmployeeName As String = ""
    Private _C_OfficeID As String = ""
    Private _C_DepartmentID As String = ""
    Private _C_DesignationID As String = ""
    Private _C_CompanyID As String = ""
    Private _C_DivisionID As String = ""
    Private _ActiveState As Boolean = False
    Private _Contractual As Boolean = False
    Private _EMailID As String = ""
    Private _CategoryID As String = ""
    Private _NonTechnical As Boolean = False
    Private _TAVerifier As String = ""
    Private _TAApprover As String = ""
    Private _TASanctioningAuthority As String = ""
    Private _SiteAllowanceApprover As String = ""
    Private _TASelfApproval As Boolean = False
    Private _HRM_Companies4_Description As String = ""
    Private _HRM_Departments2_Description As String = ""
    Private _HRM_Designations3_Description As String = ""
    Private _HRM_Divisions5_Description As String = ""
    Private _HRM_Offices1_Description As String = ""
    Private _HRM_Employees6_EmployeeName As String = ""
    Private _HRM_Employees7_EmployeeName As String = ""
    Private _TA_Categories8_cmba As String = ""
    Private _HRM_Employees9_EmployeeName As String = ""
    Private _HRM_Employees10_EmployeeName As String = ""
    Private _FK_HRM_Employees_HRM_Companies As SIS.QCM.qcmCompanies = Nothing
    Private _FK_HRM_Employees_HRM_Departments As SIS.TA.taDepartments = Nothing
    Private _FK_HRM_Employees_HRM_Designations As SIS.QCM.qcmDesignations = Nothing
    Private _FK_HRM_Employees_HRM_Divisions As SIS.TA.taDivisions = Nothing
    Private _FK_HRM_Employees_HRM_Offices As SIS.QCM.qcmOffices = Nothing
    Private _FK_HRM_Employees_CategoryID As SIS.TA.taCategories = Nothing
    Private _FK_HRM_Employees_TAVerifier As SIS.TA.taEmployees = Nothing
    Private _FK_HRM_Employees_TAApprover As SIS.TA.taEmployees = Nothing
    Private _FK_HRM_Employees_TASanctioningAuthority As SIS.TA.taEmployees = Nothing
    Private _FK_HRM_Employees_SiteAllowanceApprover As SIS.TA.taEmployees = Nothing
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
    Public Property CardNo() As String
      Get
        Return _CardNo
      End Get
      Set(ByVal value As String)
        _CardNo = value
      End Set
    End Property
    Public Property EmployeeName() As String
      Get
        Return _EmployeeName
      End Get
      Set(ByVal value As String)
        _EmployeeName = value
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
    Public Property ActiveState() As Boolean
      Get
        Return _ActiveState
      End Get
      Set(ByVal value As Boolean)
        _ActiveState = value
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
    Public Property CategoryID() As String
      Get
        Return _CategoryID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _CategoryID = ""
         Else
           _CategoryID = value
         End If
      End Set
    End Property
    Public Property NonTechnical() As Boolean
      Get
        Return _NonTechnical
      End Get
      Set(ByVal value As Boolean)
        _NonTechnical = value
      End Set
    End Property
    Public Property TAVerifier() As String
      Get
        Return _TAVerifier
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _TAVerifier = ""
         Else
           _TAVerifier = value
         End If
      End Set
    End Property
    Public Property TAApprover() As String
      Get
        Return _TAApprover
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _TAApprover = ""
         Else
           _TAApprover = value
         End If
      End Set
    End Property
    Public Property TASanctioningAuthority() As String
      Get
        Return _TASanctioningAuthority
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _TASanctioningAuthority = ""
        Else
          _TASanctioningAuthority = value
        End If
      End Set
    End Property
    Public Property TASelfApproval() As Boolean
      Get
        Return _TASelfApproval
      End Get
      Set(ByVal value As Boolean)
        _TASelfApproval = value
      End Set
    End Property
    Public Property SiteAllowanceApprover() As String
      Get
        Return _SiteAllowanceApprover
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _SiteAllowanceApprover = ""
        Else
          _SiteAllowanceApprover = value
        End If
      End Set
    End Property
    Public Property HRM_Companies4_Description() As String
      Get
        Return _HRM_Companies4_Description
      End Get
      Set(ByVal value As String)
        _HRM_Companies4_Description = value
      End Set
    End Property
    Public Property HRM_Departments2_Description() As String
      Get
        Return _HRM_Departments2_Description
      End Get
      Set(ByVal value As String)
        _HRM_Departments2_Description = value
      End Set
    End Property
    Public Property HRM_Designations3_Description() As String
      Get
        Return _HRM_Designations3_Description
      End Get
      Set(ByVal value As String)
        _HRM_Designations3_Description = value
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
    Public Property HRM_Offices1_Description() As String
      Get
        Return _HRM_Offices1_Description
      End Get
      Set(ByVal value As String)
        _HRM_Offices1_Description = value
      End Set
    End Property
    Public Property TA_Categories8_cmba() As String
      Get
        Return _TA_Categories8_cmba
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _TA_Categories8_cmba = ""
         Else
           _TA_Categories8_cmba = value
         End If
      End Set
    End Property
    Public Property HRM_Employees6_EmployeeName() As String
      Get
        Return _HRM_Employees6_EmployeeName
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _HRM_Employees6_EmployeeName = ""
        Else
          _HRM_Employees6_EmployeeName = value
        End If
      End Set
    End Property
    Public Property HRM_Employees7_EmployeeName() As String
      Get
        Return _HRM_Employees7_EmployeeName
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _HRM_Employees7_EmployeeName = ""
        Else
          _HRM_Employees7_EmployeeName = value
        End If
      End Set
    End Property
    Public Property HRM_Employees9_EmployeeName() As String
      Get
        Return _HRM_Employees9_EmployeeName
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _HRM_Employees9_EmployeeName = ""
        Else
          _HRM_Employees9_EmployeeName = value
        End If
      End Set
    End Property
    Public Property HRM_Employees10_EmployeeName() As String
      Get
        Return _HRM_Employees10_EmployeeName
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _HRM_Employees10_EmployeeName = ""
        Else
          _HRM_Employees10_EmployeeName = value
        End If
      End Set
    End Property
    Public ReadOnly Property DisplayField() As String
      Get
        Return "" & _EmployeeName.ToString.PadRight(50, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _CardNo
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
    Public Class PKtaEmployees
      Private _CardNo As String = ""
      Public Property CardNo() As String
        Get
          Return _CardNo
        End Get
        Set(ByVal value As String)
          _CardNo = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_HRM_Employees_HRM_Companies() As SIS.QCM.qcmCompanies
      Get
        If _FK_HRM_Employees_HRM_Companies Is Nothing Then
          _FK_HRM_Employees_HRM_Companies = SIS.QCM.qcmCompanies.qcmCompaniesGetByID(_C_CompanyID)
        End If
        Return _FK_HRM_Employees_HRM_Companies
      End Get
    End Property
    Public ReadOnly Property FK_HRM_Employees_HRM_Departments() As SIS.TA.taDepartments
      Get
        If _FK_HRM_Employees_HRM_Departments Is Nothing Then
          _FK_HRM_Employees_HRM_Departments = SIS.TA.taDepartments.taDepartmentsGetByID(_C_DepartmentID)
        End If
        Return _FK_HRM_Employees_HRM_Departments
      End Get
    End Property
    Public ReadOnly Property FK_HRM_Employees_HRM_Designations() As SIS.QCM.qcmDesignations
      Get
        If _FK_HRM_Employees_HRM_Designations Is Nothing Then
          _FK_HRM_Employees_HRM_Designations = SIS.QCM.qcmDesignations.qcmDesignationsGetByID(_C_DesignationID)
        End If
        Return _FK_HRM_Employees_HRM_Designations
      End Get
    End Property
    Public ReadOnly Property FK_HRM_Employees_HRM_Divisions() As SIS.TA.taDivisions
      Get
        If _FK_HRM_Employees_HRM_Divisions Is Nothing Then
          _FK_HRM_Employees_HRM_Divisions = SIS.TA.taDivisions.taDivisionsGetByID(_C_DivisionID)
        End If
        Return _FK_HRM_Employees_HRM_Divisions
      End Get
    End Property
    Public ReadOnly Property FK_HRM_Employees_HRM_Offices() As SIS.QCM.qcmOffices
      Get
        If _FK_HRM_Employees_HRM_Offices Is Nothing Then
          _FK_HRM_Employees_HRM_Offices = SIS.QCM.qcmOffices.qcmOfficesGetByID(_C_OfficeID)
        End If
        Return _FK_HRM_Employees_HRM_Offices
      End Get
    End Property
    Public ReadOnly Property FK_HRM_Employees_CategoryID() As SIS.TA.taCategories
      Get
        If _FK_HRM_Employees_CategoryID Is Nothing Then
          _FK_HRM_Employees_CategoryID = SIS.TA.taCategories.taCategoriesGetByID(_CategoryID)
        End If
        Return _FK_HRM_Employees_CategoryID
      End Get
    End Property
    Public ReadOnly Property FK_HRM_Employees_TAVerifier() As SIS.TA.taEmployees
      Get
        If _FK_HRM_Employees_TAVerifier Is Nothing Then
          _FK_HRM_Employees_TAVerifier = SIS.TA.taEmployees.taEmployeesGetByID(TAVerifier)
        End If
        Return _FK_HRM_Employees_TAVerifier
      End Get
    End Property
    Public ReadOnly Property FK_HRM_Employees_TASanctioningAuthority() As SIS.TA.taEmployees
      Get
        If _FK_HRM_Employees_TASanctioningAuthority Is Nothing Then
          _FK_HRM_Employees_TASanctioningAuthority = SIS.TA.taEmployees.taEmployeesGetByID(TASanctioningAuthority)
        End If
        Return _FK_HRM_Employees_TASanctioningAuthority
      End Get
    End Property
    Public ReadOnly Property FK_HRM_Employees_TAApprover() As SIS.TA.taEmployees
      Get
        If _FK_HRM_Employees_TAApprover Is Nothing Then
          _FK_HRM_Employees_TAApprover = SIS.TA.taEmployees.taEmployeesGetByID(TAApprover)
        End If
        Return _FK_HRM_Employees_TAApprover
      End Get
    End Property
    Public ReadOnly Property FK_HRM_Employees_SiteAllowanceApprover() As SIS.TA.taEmployees
      Get
        If _FK_HRM_Employees_SiteAllowanceApprover Is Nothing Then
          _FK_HRM_Employees_SiteAllowanceApprover = SIS.TA.taEmployees.taEmployeesGetByID(SiteAllowanceApprover)
        End If
        Return _FK_HRM_Employees_SiteAllowanceApprover
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function taEmployeesSelectList(ByVal OrderBy As String) As List(Of SIS.TA.taEmployees)
      Dim Results As List(Of SIS.TA.taEmployees) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaEmployeesSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ActiveState", SqlDbType.Bit, 2, 1)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TA.taEmployees)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taEmployees(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taEmployeesGetNewRecord() As SIS.TA.taEmployees
      Return New SIS.TA.taEmployees()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taEmployeesGetByID(ByVal CardNo As String) As SIS.TA.taEmployees
      Dim Results As SIS.TA.taEmployees = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaEmployeesSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo",SqlDbType.NVarChar,CardNo.ToString.Length, CardNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.TA.taEmployees(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taEmployeesSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal C_OfficeID As Int32, ByVal C_DepartmentID As String, ByVal C_DesignationID As Int32, ByVal C_CompanyID As String, ByVal C_DivisionID As String, ByVal CategoryID As Int32) As List(Of SIS.TA.taEmployees)
      Dim Results As List(Of SIS.TA.taEmployees) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sptaEmployeesSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sptaEmployeesSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_C_OfficeID",SqlDbType.Int,10, IIf(C_OfficeID = Nothing, 0,C_OfficeID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_C_DepartmentID",SqlDbType.NVarChar,6, IIf(C_DepartmentID Is Nothing, String.Empty,C_DepartmentID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_C_DesignationID",SqlDbType.Int,10, IIf(C_DesignationID = Nothing, 0,C_DesignationID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_C_CompanyID",SqlDbType.NVarChar,6, IIf(C_CompanyID Is Nothing, String.Empty,C_CompanyID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_C_DivisionID",SqlDbType.NVarChar,6, IIf(C_DivisionID Is Nothing, String.Empty,C_DivisionID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CategoryID",SqlDbType.Int,10, IIf(CategoryID = Nothing, 0,CategoryID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ActiveState",SqlDbType.Bit,2, 1)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TA.taEmployees)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taEmployees(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function taEmployeesSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal C_OfficeID As Int32, ByVal C_DepartmentID As String, ByVal C_DesignationID As Int32, ByVal C_CompanyID As String, ByVal C_DivisionID As String, ByVal CategoryID As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taEmployeesGetByID(ByVal CardNo As String, ByVal Filter_C_OfficeID As Int32, ByVal Filter_C_DepartmentID As String, ByVal Filter_C_DesignationID As Int32, ByVal Filter_C_CompanyID As String, ByVal Filter_C_DivisionID As String, ByVal Filter_CategoryID As Int32) As SIS.TA.taEmployees
      Return taEmployeesGetByID(CardNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function taEmployeesUpdate(ByVal Record As SIS.TA.taEmployees) As SIS.TA.taEmployees
      Dim _Rec As SIS.TA.taEmployees = SIS.TA.taEmployees.taEmployeesGetByID(Record.CardNo)
      With _Rec
        .C_OfficeID = Record.C_OfficeID
        .C_DepartmentID = Record.C_DepartmentID
        .C_DesignationID = Record.C_DesignationID
        .C_CompanyID = Record.C_CompanyID
        .Contractual = Record.Contractual
        .EMailID = Record.EMailID
        .CategoryID = Record.CategoryID
        .NonTechnical = Record.NonTechnical
        .TAVerifier = Record.TAVerifier
        .TAApprover = Record.TAApprover
        .TASanctioningAuthority = Record.TASanctioningAuthority
        .TASelfApproval = Record.TASelfApproval
        .SiteAllowanceApprover = Record.SiteAllowanceApprover
      End With
      Return SIS.TA.taEmployees.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.TA.taEmployees) As SIS.TA.taEmployees
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaEmployeesUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_CardNo",SqlDbType.NVarChar,9, Record.CardNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo",SqlDbType.NVarChar,9, Record.CardNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeName",SqlDbType.NVarChar,51, Record.EmployeeName)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_OfficeID",SqlDbType.Int,11, Iif(Record.C_OfficeID= "" ,Convert.DBNull, Record.C_OfficeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_DepartmentID",SqlDbType.NVarChar,7, Iif(Record.C_DepartmentID= "" ,Convert.DBNull, Record.C_DepartmentID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_DesignationID",SqlDbType.Int,11, Iif(Record.C_DesignationID= "" ,Convert.DBNull, Record.C_DesignationID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_CompanyID",SqlDbType.NVarChar,7, Iif(Record.C_CompanyID= "" ,Convert.DBNull, Record.C_CompanyID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_DivisionID",SqlDbType.NVarChar,7, Iif(Record.C_DivisionID= "" ,Convert.DBNull, Record.C_DivisionID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ActiveState",SqlDbType.Bit,3, Record.ActiveState)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Contractual",SqlDbType.Bit,3, Record.Contractual)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EMailID",SqlDbType.NVarChar,51, Iif(Record.EMailID= "" ,Convert.DBNull, Record.EMailID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CategoryID",SqlDbType.Int,11, Iif(Record.CategoryID= "" ,Convert.DBNull, Record.CategoryID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NonTechnical",SqlDbType.Bit,3, Record.NonTechnical)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TAVerifier",SqlDbType.NVarChar,9, Iif(Record.TAVerifier= "" ,Convert.DBNull, Record.TAVerifier))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TAApprover",SqlDbType.NVarChar,9, Iif(Record.TAApprover= "" ,Convert.DBNull, Record.TAApprover))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TASanctioningAuthority",SqlDbType.NVarChar,9, Iif(Record.TASanctioningAuthority= "" ,Convert.DBNull, Record.TASanctioningAuthority))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TASelfApproval", SqlDbType.Bit, 3, Record.TASelfApproval)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SiteAllowanceApprover", SqlDbType.NVarChar, 9, IIf(Record.SiteAllowanceApprover = "", Convert.DBNull, Record.SiteAllowanceApprover))
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
    Public Shared Function SelecttaEmployeesAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaEmployeesAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ActiveState",SqlDbType.Bit,2, 1)
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
            Dim Tmp As SIS.TA.taEmployees = New SIS.TA.taEmployees(Reader)
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(Tmp.DisplayField, Tmp.PrimaryKey))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results.ToArray
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      Try
        For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
          If pi.MemberType = Reflection.MemberTypes.Property Then
            Try
              Dim Found As Boolean = False
              For I As Integer = 0 To Reader.FieldCount - 1
                If Reader.GetName(I).ToLower = pi.Name.ToLower Then
                  Found = True
                  Exit For
                End If
              Next
              If Found Then
                If Convert.IsDBNull(Reader(pi.Name)) Then
                  Select Case Reader.GetDataTypeName(Reader.GetOrdinal(pi.Name))
                    Case "decimal"
                      CallByName(Me, pi.Name, CallType.Let, "0.00")
                    Case "bit"
                      CallByName(Me, pi.Name, CallType.Let, Boolean.FalseString)
                    Case Else
                      CallByName(Me, pi.Name, CallType.Let, String.Empty)
                  End Select
                Else
                  CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
                End If
              End If
            Catch ex As Exception
            End Try
          End If
        Next
      Catch ex As Exception
      End Try
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
