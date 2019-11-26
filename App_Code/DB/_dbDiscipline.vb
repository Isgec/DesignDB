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
    Public Property ProjectDesc As String = ""

    Public Property Discipline_Total_Count As Integer = 0
    Public Property Discipline_Release_Count As Integer = 0
    Public Property Discipline_Pending_Count As Integer = 0
    Public Property Discipline_DueForToday_Count As Integer = 0
    Public Property Discipline_DueTillToday_Count As Integer = 0
    Public Property Discipline_OnTime_Count As Integer = 0
    Public Property Discipline_Delayed_Count As Integer = 0

    Public Shared Function GetDPMDLDB(ByVal DivisionID As String, ByVal DisciplineID As String) As DBDiscipline
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


      Dim Sql As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()





        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from tdmisg140200 where  t_resp in ('" & DisciplineID & "') AND t_pcod IN ('" & DivisionID & "')"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Discipline_Total_Count = Cmd.ExecuteScalar
        End Using

        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from tdmisg140200 where  t_resp in ('" & DisciplineID & "') AND t_pcod IN ('" & DivisionID & "') And t_acdt <>'1970-01-01 00:00:00.000'"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Discipline_Release_Count = Cmd.ExecuteScalar
        End Using

        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = " Select count(t_docn) from tdmisg140200 where  t_resp in ('" & DisciplineID & "') AND t_pcod IN ('" & DivisionID & "') and t_acdt ='1970-01-01 00:00:00.000'"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Discipline_Pending_Count = Cmd.ExecuteScalar
        End Using


        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = " Select count(t_docn) From tdmisg140200 Where  t_resp in ('" & DisciplineID & "') AND t_pcod IN ('" & DivisionID & "') And t_acdt = convert(datetime,'01/01/1970',103) And  convert(date,dateadd(n,330,t_rsfd)) = convert(date,getdate())"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Discipline_DueForToday_Count = Cmd.ExecuteScalar
        End Using

        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = " Select count(t_docn) From tdmisg140200 Where  t_resp in ('" & DisciplineID & "') AND t_pcod IN ('" & DivisionID & "') And t_acdt = convert(datetime,'01/01/1970',103) And  convert(date,dateadd(n,330,t_rsfd)) <= convert(date,getdate())"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Discipline_DueTillToday_Count = Cmd.ExecuteScalar
        End Using


        Sql = "		select count(t_docn)		"
        Sql &= "		from tdmisg140200		 "
        Sql &= "		where		 "
        Sql &= "		t_resp in ('" & DisciplineID & "') AND t_pcod IN ('" & DivisionID & "')  "
        Sql &= "   and t_acdt <> convert(datetime,'01/01/1970',103)	 "
        Sql &= "  And 1 =   case when t_acdt <  dateadd(d,1,t_rsfd) "
        Sql &= "	then 1 else 0 end "

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Discipline_OnTime_Count = Cmd.ExecuteScalar
        End Using


        Sql = "		select count(t_docn)		"
        Sql &= "	from tdmisg140200		 "
        Sql &= "	where		 "
        Sql &= "	t_resp in ('" & DisciplineID & "') AND t_pcod IN ('" & DivisionID & "')  "
        Sql &= "  and t_acdt <> convert(datetime,'01/01/1970',103)	"
        Sql &= "  And 1 =   case when t_acdt < dateadd(d,1,t_rsfd)  "
        Sql &= "	then 0 else 1 end  "

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Discipline_Delayed_Count = Cmd.ExecuteScalar
        End Using



      End Using
      Return mRet
    End Function



  End Class
End Namespace
