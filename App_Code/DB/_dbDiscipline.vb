Imports System
Imports System.Drawing
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Web.UI.DataVisualization.Charting
Namespace SIS.DD
  <DataObject()>
  Public Class DBDiscipline
    Private Class dbDisciplineData

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

    Public Property DivisionID As String = ""
    Public Property DisciplineID As String = ""
    Public Property MonthID As Integer = 0
    Public Property YearID As Integer = 0
    Public Property ProjectDesc As String = ""

    Public Property DueforRelease_CurrentM_A As Integer = 0
    Public Property DueforRelease_PreviousM_B As Integer = 0
    Public Property DueforRelease_BothM_C As Integer = 0
    Public Property AllDueTillToday_Release As Integer = 0
    Public Property DueOnlyToday_Release As Integer = 0
    Public Property Ontime_Release_CurrentM As Integer = 0
    Public Property Backlog_Release_CurrentM As Integer = 0

    Public Shared Function GetDPMDLDB(ByVal DivisionID As String, ByVal DisciplineID As String, ByVal MonthId As Integer, ByVal YearId As String) As DBDiscipline
      If DivisionID = "" Then Return Nothing


      Select Case DivisionID
        Case "BOILER"
          DivisionID = "AFBC','BLR_SPR','CFBC','HRSG','OILGAS','TG','WHRB','IPAC"
        Case "SMD"
          DivisionID = "SPDR"
        Case "EPC"
          DivisionID = "EPC01"
        Case "APC"
          DivisionID = "ESP"
      End Select



      Dim mRet As New DBDiscipline
      mRet.DivisionID = DivisionID
      mRet.DisciplineID = DisciplineID
      mRet.MonthID = MonthId
      mRet.YearID = YearId


      Dim Sql As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()


        't_acdt = convert(datetime,'01/01/1970',103) and


        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from tdmisg140200 where  t_resp in ('" & DisciplineID & "') AND t_pcod IN ('" & DivisionID & "') and year(t_bsfd) in (" & YearId & ") and month(t_bsfd) in (" & MonthId & ") and t_orgn='ISG'"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.DueforRelease_CurrentM_A = Cmd.ExecuteScalar
        End Using

        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from tdmisg140200 where t_resp in ('" & DisciplineID & "') AND t_pcod IN ('" & DivisionID & "')  and year(t_bsfd) <= " & YearId & " and t_acdt ='1970-01-01 00:00:00.000' and t_orgn='ISG' and t_bsfd <=' " & YearId & "-" & MonthId & "-01 00:00:00.000'"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.DueforRelease_PreviousM_B = Cmd.ExecuteScalar
        End Using

        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        'Sql = " Select count(*) from tdmisg140200 where t_resp in ('" & DisciplineID & "') AND t_pcod IN ('" & DivisionID & "') and year(t_bsfd) in (" & YearId & ") and month(t_bsfd) in (" & MonthId - 1 & "," & MonthId & ")"
        'Using Cmd As SqlCommand = Con.CreateCommand()
        '  Cmd.CommandType = CommandType.Text
        '  Cmd.CommandText = Sql
        '  mRet.DueforRelease_BothM_C = Cmd.ExecuteScalar
        'End Using


        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = " Select count(*) From tdmisg140200 Where  t_resp in ('" & DisciplineID & "') AND t_pcod IN ('" & DivisionID & "') And t_acdt = convert(datetime,'01/01/1970',103) And  convert(date,dateadd(n,330,t_bsfd)) <= convert(date,getdate())"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.AllDueTillToday_Release = Cmd.ExecuteScalar
        End Using

        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = " Select count(*) From tdmisg140200 Where  t_resp in ('" & DisciplineID & "') AND t_pcod IN ('" & DivisionID & "') And t_acdt = convert(datetime,'01/01/1970',103) And  convert(date,dateadd(n,330,t_bsfd)) = convert(date,getdate())"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.DueOnlyToday_Release = Cmd.ExecuteScalar
        End Using


        Sql = "		select count(*)		"
        Sql &= "		from tdmisg140200		 "
        Sql &= "		where		 "
        Sql &= "		t_resp in ('" & DisciplineID & "') AND t_pcod IN ('" & DivisionID & "')   and year(t_bsfd) in (" & YearId & ")and month(t_bsfd) in (" & MonthId & ") And t_acdt <>'1970-01-01 00:00:00.000'"

        Sql &= "  And 1 =   case when t_acdt <  dateadd(d,1,t_bsfd) "
        Sql &= "	then 1 else 0 end "

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Ontime_Release_CurrentM = Cmd.ExecuteScalar
        End Using


        Sql = "		select count(*)		"
        Sql &= "	from tdmisg140200		 "
        Sql &= "	where		 "
        Sql &= "	t_resp in ('" & DisciplineID & "') AND t_pcod IN ('" & DivisionID & "')   and year(t_acdt) in (" & YearId & ")and month(t_acdt) in (" & MonthId & ")"
        Sql &= "  and t_acdt <> convert(datetime,'01/01/1970',103)	and t_bsfd <=' " & YearId & "-" & MonthId & "-01 00:00:00.000'"
        Sql &= "  And 1 =   case when t_acdt < dateadd(d,1,t_bsfd)  "
        Sql &= "	then 0 else 1 end  "

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Backlog_Release_CurrentM = Cmd.ExecuteScalar
        End Using



      End Using
      Return mRet
    End Function



  End Class
End Namespace
