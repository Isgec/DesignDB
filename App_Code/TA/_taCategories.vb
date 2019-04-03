Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TA
  <DataObject()> _
  Partial Public Class taCategories
    Private Shared _RecordCount As Integer
    Private _CategoryID As Int32 = 0
    Private _CategoryCode As String = ""
    Private _CategoryDescription As String = ""
    Private _CategorySequence As String = ""
    Private _cmba As String = ""
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
    Public Property CategoryID() As Int32
      Get
        Return _CategoryID
      End Get
      Set(ByVal value As Int32)
        _CategoryID = value
      End Set
    End Property
    Public Property CategoryCode() As String
      Get
        Return _CategoryCode
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _CategoryCode = ""
         Else
           _CategoryCode = value
         End If
      End Set
    End Property
    Public Property CategoryDescription() As String
      Get
        Return _CategoryDescription
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _CategoryDescription = ""
         Else
           _CategoryDescription = value
         End If
      End Set
    End Property
    Public Property CategorySequence() As String
      Get
        Return _CategorySequence
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _CategorySequence = ""
         Else
           _CategorySequence = value
         End If
      End Set
    End Property
    Public Property cmba() As String
      Get
        Return _cmba
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _cmba = ""
         Else
           _cmba = value
         End If
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _cmba.ToString.PadRight(111, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _CategoryID
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
    Public Class PKtaCategories
      Private _CategoryID As Int32 = 0
      Public Property CategoryID() As Int32
        Get
          Return _CategoryID
        End Get
        Set(ByVal value As Int32)
          _CategoryID = value
        End Set
      End Property
    End Class
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taCategoriesSelectList(ByVal OrderBy As String) As List(Of SIS.TA.taCategories)
      Dim Results As List(Of SIS.TA.taCategories) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "CategorySequence"
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaCategoriesSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TA.taCategories)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taCategories(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taCategoriesGetNewRecord() As SIS.TA.taCategories
      Return New SIS.TA.taCategories()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taCategoriesGetByID(ByVal CategoryID As Int32) As SIS.TA.taCategories
      Dim Results As SIS.TA.taCategories = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaCategoriesSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CategoryID",SqlDbType.Int,CategoryID.ToString.Length, CategoryID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.TA.taCategories(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taCategoriesSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.TA.taCategories)
      Dim Results As List(Of SIS.TA.taCategories) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "CategorySequence"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sptaCategoriesSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sptaCategoriesSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TA.taCategories)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taCategories(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function taCategoriesSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function taCategoriesInsert(ByVal Record As SIS.TA.taCategories) As SIS.TA.taCategories
      Dim _Rec As SIS.TA.taCategories = SIS.TA.taCategories.taCategoriesGetNewRecord()
      With _Rec
        .CategoryCode = Record.CategoryCode
        .CategoryDescription = Record.CategoryDescription
        .CategorySequence = Record.CategorySequence
      End With
      Return SIS.TA.taCategories.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.TA.taCategories) As SIS.TA.taCategories
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaCategoriesInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CategoryCode",SqlDbType.NVarChar,11, Iif(Record.CategoryCode= "" ,Convert.DBNull, Record.CategoryCode))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CategoryDescription",SqlDbType.NVarChar,101, Iif(Record.CategoryDescription= "" ,Convert.DBNull, Record.CategoryDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CategorySequence",SqlDbType.Int,11, Iif(Record.CategorySequence= "" ,Convert.DBNull, Record.CategorySequence))
          Cmd.Parameters.Add("@Return_CategoryID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_CategoryID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.CategoryID = Cmd.Parameters("@Return_CategoryID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function taCategoriesUpdate(ByVal Record As SIS.TA.taCategories) As SIS.TA.taCategories
      Dim _Rec As SIS.TA.taCategories = SIS.TA.taCategories.taCategoriesGetByID(Record.CategoryID)
      With _Rec
        .CategoryCode = Record.CategoryCode
        .CategoryDescription = Record.CategoryDescription
        .CategorySequence = Record.CategorySequence
      End With
      Return SIS.TA.taCategories.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.TA.taCategories) As SIS.TA.taCategories
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaCategoriesUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_CategoryID",SqlDbType.Int,11, Record.CategoryID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CategoryCode",SqlDbType.NVarChar,11, Iif(Record.CategoryCode= "" ,Convert.DBNull, Record.CategoryCode))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CategoryDescription",SqlDbType.NVarChar,101, Iif(Record.CategoryDescription= "" ,Convert.DBNull, Record.CategoryDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CategorySequence",SqlDbType.Int,11, Iif(Record.CategorySequence= "" ,Convert.DBNull, Record.CategorySequence))
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
    Public Shared Function taCategoriesDelete(ByVal Record As SIS.TA.taCategories) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaCategoriesDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_CategoryID",SqlDbType.Int,Record.CategoryID.ToString.Length, Record.CategoryID)
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
'    Autocomplete Method
    Public Shared Function SelecttaCategoriesAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaCategoriesAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, 1))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(111, " "),""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.TA.taCategories = New SIS.TA.taCategories(Reader)
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(Tmp.DisplayField, Tmp.PrimaryKey))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results.ToArray
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      On Error Resume Next
      _CategoryID = Ctype(Reader("CategoryID"),Int32)
      If Convert.IsDBNull(Reader("CategoryCode")) Then
        _CategoryCode = String.Empty
      Else
        _CategoryCode = Ctype(Reader("CategoryCode"), String)
      End If
      If Convert.IsDBNull(Reader("CategoryDescription")) Then
        _CategoryDescription = String.Empty
      Else
        _CategoryDescription = Ctype(Reader("CategoryDescription"), String)
      End If
      If Convert.IsDBNull(Reader("CategorySequence")) Then
        _CategorySequence = String.Empty
      Else
        _CategorySequence = Ctype(Reader("CategorySequence"), String)
      End If
      If Convert.IsDBNull(Reader("cmba")) Then
        _cmba = String.Empty
      Else
        _cmba = Ctype(Reader("cmba"), String)
      End If
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
