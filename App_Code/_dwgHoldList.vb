Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.DMISG
  <DataObject()> _
  Partial Public Class dwgHoldList
    Private Shared _RecordCount As Integer
    Private _SerialNo As Int32 = 0
    Private _DocumentID As String = ""
    Private _RevisionAtHold As String = "" ' revision
    Private _Description As String = ""
    Private _Element As String = ""
    Private _ResponsibleDept As String = ""
    Private _DateOfIssue As String = ""
    Private _InputReceivedOn As String = ""
    Private _PartUnderHold As String = ""
    Private _ReasonForHold As String = ""
    Private _HoldRemovedIssued As String = ""
    Private _RevisionAtUnhold As String = ""
    Private _HoldStatus As String = ""
    Private _CreatedBy As String = ""
    Private _CreatedOn As String = ""
    Private _ProjectID As String = ""
    Private _aspnet_Users1_UserFullName As String = ""
    Private _IDM_Projects2_Description As String = ""
    Private _FK_DWG_HoldList_CreatedBy As SIS.QCM.qcmUsers = Nothing
    Private _FK_DWG_HoldList_ProjectID As SIS.QCM.qcmProjects = Nothing
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
    Public Property SerialNo() As Int32
      Get
        Return _SerialNo
      End Get
      Set(ByVal value As Int32)
        _SerialNo = value
      End Set
    End Property
    Public Property DocumentID() As String
      Get
        Return _DocumentID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _DocumentID = ""
         Else
           _DocumentID = value
         End If
      End Set
    End Property
    Public Property RevisionAtHold() As String
      Get
        Return _RevisionAtHold
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _RevisionAtHold = ""
         Else
           _RevisionAtHold = value
         End If
      End Set
    End Property
    Public Property Description() As String
      Get
        Return _Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Description = ""
         Else
           _Description = value
         End If
      End Set
    End Property
    Public Property Element() As String
      Get
        Return _Element
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Element = ""
         Else
           _Element = value
         End If
      End Set
    End Property
    Public Property ResponsibleDept() As String
      Get
        Return _ResponsibleDept
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ResponsibleDept = ""
         Else
           _ResponsibleDept = value
         End If
      End Set
    End Property
    Public Property DateOfIssue() As String
      Get
        If Not _DateOfIssue = String.Empty Then
          Return Convert.ToDateTime(_DateOfIssue).ToString("dd/MM/yyyy")
        End If
        Return _DateOfIssue
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _DateOfIssue = ""
         Else
           _DateOfIssue = value
         End If
      End Set
    End Property
    Public Property InputReceivedOn() As String
      Get
        If Not _InputReceivedOn = String.Empty Then
          Return Convert.ToDateTime(_InputReceivedOn).ToString("dd/MM/yyyy")
        End If
        Return _InputReceivedOn
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _InputReceivedOn = ""
         Else
           _InputReceivedOn = value
         End If
      End Set
    End Property
    Public Property PartUnderHold() As String
      Get
        Return _PartUnderHold
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PartUnderHold = ""
         Else
           _PartUnderHold = value
         End If
      End Set
    End Property
    Public Property ReasonForHold() As String
      Get
        Return _ReasonForHold
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ReasonForHold = ""
         Else
           _ReasonForHold = value
         End If
      End Set
    End Property
    Public Property HoldRemovedIssued() As String
      Get
        If Not _HoldRemovedIssued = String.Empty Then
          Return Convert.ToDateTime(_HoldRemovedIssued).ToString("dd/MM/yyyy")
        End If
        Return _HoldRemovedIssued
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _HoldRemovedIssued = ""
         Else
           _HoldRemovedIssued = value
         End If
      End Set
    End Property
    Public Property RevisionAtUnhold() As String
      Get
        Return _RevisionAtUnhold
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _RevisionAtUnhold = ""
         Else
           _RevisionAtUnhold = value
         End If
      End Set
    End Property
    Public Property HoldStatus() As String
      Get
        Return _HoldStatus
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _HoldStatus = ""
         Else
           _HoldStatus = value
         End If
      End Set
    End Property
    Public Property CreatedBy() As String
      Get
        Return _CreatedBy
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _CreatedBy = ""
         Else
           _CreatedBy = value
         End If
      End Set
    End Property
    Public Property CreatedOn() As String
      Get
        If Not _CreatedOn = String.Empty Then
          Return Convert.ToDateTime(_CreatedOn).ToString("dd/MM/yyyy")
        End If
        Return _CreatedOn
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _CreatedOn = ""
         Else
           _CreatedOn = value
         End If
      End Set
    End Property
    Public Property ProjectID() As String
      Get
        Return _ProjectID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ProjectID = ""
         Else
           _ProjectID = value
         End If
      End Set
    End Property
    Public Property aspnet_Users1_UserFullName() As String
      Get
        Return _aspnet_Users1_UserFullName
      End Get
      Set(ByVal value As String)
        _aspnet_Users1_UserFullName = value
      End Set
    End Property
    Public Property IDM_Projects2_Description() As String
      Get
        Return _IDM_Projects2_Description
      End Get
      Set(ByVal value As String)
        _IDM_Projects2_Description = value
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _ProjectID & "|" & _DocumentID & "|" & _SerialNo
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
    Public Class PKdwgHoldList
      Private _ProjectID As String = ""
      Private _DocumentID As String = ""
      Private _SerialNo As Int32 = 0
      Public Property ProjectID() As String
        Get
          Return _ProjectID
        End Get
        Set(ByVal value As String)
          _ProjectID = value
        End Set
      End Property
      Public Property DocumentID() As String
        Get
          Return _DocumentID
        End Get
        Set(ByVal value As String)
          _DocumentID = value
        End Set
      End Property
      Public Property SerialNo() As Int32
        Get
          Return _SerialNo
        End Get
        Set(ByVal value As Int32)
          _SerialNo = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_DWG_HoldList_CreatedBy() As SIS.QCM.qcmUsers
      Get
        If _FK_DWG_HoldList_CreatedBy Is Nothing Then
          _FK_DWG_HoldList_CreatedBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_CreatedBy)
        End If
        Return _FK_DWG_HoldList_CreatedBy
      End Get
    End Property
    Public ReadOnly Property FK_DWG_HoldList_ProjectID() As SIS.QCM.qcmProjects
      Get
        If _FK_DWG_HoldList_ProjectID Is Nothing Then
          _FK_DWG_HoldList_ProjectID = SIS.QCM.qcmProjects.qcmProjectsGetByID(_ProjectID)
        End If
        Return _FK_DWG_HoldList_ProjectID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function dwgHoldListGetNewRecord() As SIS.DMISG.dwgHoldList
      Return New SIS.DMISG.dwgHoldList()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function dwgHoldListGetByID(ByVal ProjectID As String, ByVal DocumentID As String, ByVal SerialNo As Int32) As SIS.DMISG.dwgHoldList
      Dim Results As SIS.DMISG.dwgHoldList = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spdwgHoldListSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,ProjectID.ToString.Length, ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocumentID",SqlDbType.NVarChar,DocumentID.ToString.Length, DocumentID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.DMISG.dwgHoldList(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function dwgHoldListSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal DocumentID As String, ByVal ProjectID As String) As List(Of SIS.DMISG.dwgHoldList)
      Dim Results As List(Of SIS.DMISG.dwgHoldList) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "SerialNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spdwgHoldListSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spdwgHoldListSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_DocumentID",SqlDbType.NVarChar,25, IIf(DocumentID Is Nothing, String.Empty,DocumentID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID",SqlDbType.NVarChar,6, IIf(ProjectID Is Nothing, String.Empty,ProjectID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.DMISG.dwgHoldList)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.DMISG.dwgHoldList(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function dwgHoldListSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal DocumentID As String, ByVal ProjectID As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function dwgHoldListGetByID(ByVal ProjectID As String, ByVal DocumentID As String, ByVal SerialNo As Int32, ByVal Filter_DocumentID As String, ByVal Filter_ProjectID As String) As SIS.DMISG.dwgHoldList
      Return dwgHoldListGetByID(ProjectID, DocumentID, SerialNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function dwgHoldListInsert(ByVal Record As SIS.DMISG.dwgHoldList) As SIS.DMISG.dwgHoldList
      Dim _Rec As SIS.DMISG.dwgHoldList = SIS.DMISG.dwgHoldList.dwgHoldListGetNewRecord()
      With _Rec
        .DocumentID = Record.DocumentID
        .RevisionAtHold = Record.RevisionAtHold
        .Description = Record.Description
        .Element = Record.Element
        .ResponsibleDept = Record.ResponsibleDept
        .DateOfIssue = Record.DateOfIssue
        .InputReceivedOn = Record.InputReceivedOn
        .PartUnderHold = Record.PartUnderHold
        .ReasonForHold = Record.ReasonForHold
        .HoldRemovedIssued = Record.HoldRemovedIssued
        .RevisionAtUnhold = Record.RevisionAtUnhold
        .HoldStatus = Record.HoldStatus
        .CreatedBy =  Global.System.Web.HttpContext.Current.Session("LoginID")
        .CreatedOn = Now
        .ProjectID = Record.ProjectID
      End With
      Return SIS.DMISG.dwgHoldList.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.DMISG.dwgHoldList) As SIS.DMISG.dwgHoldList
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spdwgHoldListInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocumentID",SqlDbType.NVarChar,26, Iif(Record.DocumentID= "" ,Convert.DBNull, Record.DocumentID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RevisionAtHold",SqlDbType.NVarChar,33, Iif(Record.RevisionAtHold= "" ,Convert.DBNull, Record.RevisionAtHold))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,101, Iif(Record.Description= "" ,Convert.DBNull, Record.Description))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Element",SqlDbType.NVarChar,9, Iif(Record.Element= "" ,Convert.DBNull, Record.Element))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ResponsibleDept",SqlDbType.NVarChar,4, Iif(Record.ResponsibleDept= "" ,Convert.DBNull, Record.ResponsibleDept))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DateOfIssue",SqlDbType.DateTime,21, Iif(Record.DateOfIssue= "" ,Convert.DBNull, Record.DateOfIssue))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InputReceivedOn",SqlDbType.DateTime,21, Iif(Record.InputReceivedOn= "" ,Convert.DBNull, Record.InputReceivedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PartUnderHold",SqlDbType.NVarChar,51, Iif(Record.PartUnderHold= "" ,Convert.DBNull, Record.PartUnderHold))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReasonForHold",SqlDbType.NVarChar,51, Iif(Record.ReasonForHold= "" ,Convert.DBNull, Record.ReasonForHold))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@HoldRemovedIssued",SqlDbType.DateTime,21, Iif(Record.HoldRemovedIssued= "" ,Convert.DBNull, Record.HoldRemovedIssued))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RevisionAtUnhold",SqlDbType.NVarChar,33, Iif(Record.RevisionAtUnhold= "" ,Convert.DBNull, Record.RevisionAtUnhold))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@HoldStatus",SqlDbType.Bit,3, Iif(Record.HoldStatus= "" ,Convert.DBNull, Record.HoldStatus))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy",SqlDbType.NVarChar,9, Iif(Record.CreatedBy= "" ,Convert.DBNull, Record.CreatedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedOn",SqlDbType.DateTime,21, Iif(Record.CreatedOn= "" ,Convert.DBNull, Record.CreatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Iif(Record.ProjectID= "" ,Convert.DBNull, Record.ProjectID))
          Cmd.Parameters.Add("@Return_ProjectID", SqlDbType.NVarChar, 7)
          Cmd.Parameters("@Return_ProjectID").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_DocumentID", SqlDbType.NVarChar, 26)
          Cmd.Parameters("@Return_DocumentID").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_SerialNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_SerialNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.ProjectID = Cmd.Parameters("@Return_ProjectID").Value
          Record.DocumentID = Cmd.Parameters("@Return_DocumentID").Value
          Record.SerialNo = Cmd.Parameters("@Return_SerialNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function dwgHoldListUpdate(ByVal Record As SIS.DMISG.dwgHoldList) As SIS.DMISG.dwgHoldList
      Dim _Rec As SIS.DMISG.dwgHoldList = SIS.DMISG.dwgHoldList.dwgHoldListGetByID(Record.ProjectID, Record.DocumentID, Record.SerialNo)
      With _Rec
        .RevisionAtHold = Record.RevisionAtHold
        .Description = Record.Description
        .Element = Record.Element
        .ResponsibleDept = Record.ResponsibleDept
        .DateOfIssue = Record.DateOfIssue
        .InputReceivedOn = Record.InputReceivedOn
        .PartUnderHold = Record.PartUnderHold
        .ReasonForHold = Record.ReasonForHold
        .HoldRemovedIssued = Record.HoldRemovedIssued
        .RevisionAtUnhold = Record.RevisionAtUnhold
        .HoldStatus = Record.HoldStatus
        .CreatedBy = Global.System.Web.HttpContext.Current.Session("LoginID")
        .CreatedOn = Now
      End With
      Return SIS.DMISG.dwgHoldList.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.DMISG.dwgHoldList) As SIS.DMISG.dwgHoldList
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spdwgHoldListUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_DocumentID",SqlDbType.NVarChar,26, Record.DocumentID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ProjectID",SqlDbType.NVarChar,7, Record.ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocumentID",SqlDbType.NVarChar,26, Iif(Record.DocumentID= "" ,Convert.DBNull, Record.DocumentID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RevisionAtHold",SqlDbType.NVarChar,33, Iif(Record.RevisionAtHold= "" ,Convert.DBNull, Record.RevisionAtHold))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,101, Iif(Record.Description= "" ,Convert.DBNull, Record.Description))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Element",SqlDbType.NVarChar,9, Iif(Record.Element= "" ,Convert.DBNull, Record.Element))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ResponsibleDept",SqlDbType.NVarChar,4, Iif(Record.ResponsibleDept= "" ,Convert.DBNull, Record.ResponsibleDept))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DateOfIssue",SqlDbType.DateTime,21, Iif(Record.DateOfIssue= "" ,Convert.DBNull, Record.DateOfIssue))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InputReceivedOn",SqlDbType.DateTime,21, Iif(Record.InputReceivedOn= "" ,Convert.DBNull, Record.InputReceivedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PartUnderHold",SqlDbType.NVarChar,51, Iif(Record.PartUnderHold= "" ,Convert.DBNull, Record.PartUnderHold))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReasonForHold",SqlDbType.NVarChar,51, Iif(Record.ReasonForHold= "" ,Convert.DBNull, Record.ReasonForHold))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@HoldRemovedIssued",SqlDbType.DateTime,21, Iif(Record.HoldRemovedIssued= "" ,Convert.DBNull, Record.HoldRemovedIssued))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RevisionAtUnhold",SqlDbType.NVarChar,33, Iif(Record.RevisionAtUnhold= "" ,Convert.DBNull, Record.RevisionAtUnhold))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@HoldStatus",SqlDbType.Bit,3, Iif(Record.HoldStatus= "" ,Convert.DBNull, Record.HoldStatus))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy",SqlDbType.NVarChar,9, Iif(Record.CreatedBy= "" ,Convert.DBNull, Record.CreatedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedOn",SqlDbType.DateTime,21, Iif(Record.CreatedOn= "" ,Convert.DBNull, Record.CreatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Iif(Record.ProjectID= "" ,Convert.DBNull, Record.ProjectID))
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
    <DataObjectMethod(DataObjectMethodType.Delete, True)> _
    Public Shared Function dwgHoldListDelete(ByVal Record As SIS.DMISG.dwgHoldList) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spdwgHoldListDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ProjectID",SqlDbType.NVarChar,Record.ProjectID.ToString.Length, Record.ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_DocumentID",SqlDbType.NVarChar,Record.DocumentID.ToString.Length, Record.DocumentID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,Record.SerialNo.ToString.Length, Record.SerialNo)
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Con.Open()
          Cmd.ExecuteNonQuery()
          _RecordCount = Cmd.Parameters("@RowCount").Value
        End Using
      End Using
      Return _RecordCount
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
