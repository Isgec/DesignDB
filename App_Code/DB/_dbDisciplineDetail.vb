Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.DD
  <DataObject()>
  Partial Public Class DisciplineDetail

    'PLM
    Public Property t_docn As String = ""
    Public Property t_revn As String = ""
    Public Property t_dsca As String = ""
    Public Property t_cprj As String = ""




    Public Shared Function GetDPLMData(ByVal det As String, ByVal DivisionID As String, ByVal DisciplineID As String, ByVal YearID As String, ByVal MonthID As String) As List(Of DisciplineDetail)
      Dim userG As String = ""

      Dim UserID As String = HttpContext.Current.Session("LoginID")
      Dim UserIDT As Integer = 0
      Try
        UserIDT = Convert.ToInt32(UserID)
      Catch ex As Exception

      End Try

      If DivisionID = "" Then Return Nothing
      If DisciplineID = "" Then Return Nothing
      If YearID = "" Then Return Nothing
      If MonthID = "" Then Return Nothing

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

      Dim mRet As New List(Of SIS.DD.DisciplineDetail)

      Dim Sql As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString() & ";Connection Timeout=50000")
        Con.Open()




        Select Case det

          Case "DueforRelease_CurrentM_A"
            Sql = " select t_cprj,t_docn,t_revn,t_dsca from tdmisg140200 where  t_resp in ('" & DisciplineID & "') AND t_pcod IN ('" & DivisionID & "') and year(t_bsfd) in (" & YearID & ") and month(t_bsfd) in (" & MonthID & ") and t_orgn='ISG'"

          Case "DueforRelease_PreviousM_B"
            Sql = " select t_cprj,t_docn,t_revn,t_dsca from tdmisg140200 where t_resp in ('" & DisciplineID & "') AND t_pcod IN ('" & DivisionID & "')  and year(t_bsfd) <= " & YearID & " and t_acdt ='1970-01-01 00:00:00.000' and t_orgn='ISG' and t_bsfd <=' " & YearID & "-" & MonthID & "-01 00:00:00.000'"

          Case "DueforRelease_BothM_C"
            Sql = " "


          Case "AllDueTillToday_Release"
            Sql = "select t_cprj,t_docn,t_revn,t_dsca From tdmisg140200 Where  t_resp In ('" & DisciplineID & "') AND t_pcod IN ('" & DivisionID & "') And t_acdt = convert(datetime,'01/01/1970',103) And  convert(date,dateadd(n,330,t_bsfd)) <= convert(date,getdate()) "

          Case "DueOnlyToday_Release"
            Sql = "Select t_cprj,t_docn,t_revn,t_dsca From tdmisg140200 Where  t_resp in ('" & DisciplineID & "') AND t_pcod IN ('" & DivisionID & "') And t_acdt = convert(datetime,'01/01/1970',103) And  convert(date,dateadd(n,330,t_bsfd)) = convert(date,getdate()) "

          Case "Ontime_Release_CurrentM"
            Sql = "		select t_cprj,t_docn,t_revn,t_dsca		"
            Sql &= "		from tdmisg140200		 "
            Sql &= "		where		 "
            Sql &= "		t_resp in ('" & DisciplineID & "') AND t_pcod IN ('" & DivisionID & "')   and year(t_bsfd) in (" & YearID & ")and month(t_bsfd) in (" & MonthID & ") And t_acdt <>'1970-01-01 00:00:00.000'"

            Sql &= "  And 1 =   case when t_acdt <  dateadd(d,1,t_bsfd) "
            Sql &= "	then 1 else 0 end "

          Case "Backlog_Release_CurrentM"
            Sql = "		select t_cprj,t_docn,t_revn,t_dsca		"
            Sql &= "	from tdmisg140200		 "
            Sql &= "	where		 "
            Sql &= "	t_resp in ('" & DisciplineID & "') AND t_pcod IN ('" & DivisionID & "')   and year(t_acdt) in (" & YearID & ")and month(t_acdt) in (" & MonthID & ")"
            Sql &= "  and t_acdt <> convert(datetime,'01/01/1970',103)	and t_bsfd <=' " & YearID & "-" & MonthID & "-01 00:00:00.000'"
            Sql &= "  And 1 =   case when t_acdt < dateadd(d,1,t_bsfd)  "
            Sql &= "	then 0 else 1 end  "





          Case "DueforRelease_CurrentM_A"
            Sql = " select t_cprj,t_docn,t_revn,t_dsca from tdmisg140200 where  t_resp in ('" & DisciplineID & "') AND t_pcod IN ('" & DivisionID & "') and year(t_bsfd) in (" & YearID & ") and month(t_bsfd) in (" & MonthID & ") and t_orgn='ISG'"


        End Select

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Cmd.CommandTimeout = 3000
          Dim rd As SqlDataReader = Cmd.ExecuteReader
          While (rd.Read)
            mRet.Add(New DisciplineDetail(rd))
          End While
        End Using
      End Using
      Return mRet
    End Function

    Public Shared Function GetDSARData(ByVal det As String, ByVal DivisionID As String, ByVal DisciplineID As String, ByVal YearID As String, ByVal MonthID As String) As List(Of DisciplineDetail)
      Dim userG As String = ""
      Dim PrjID As String = ""
      Dim UserID As String = HttpContext.Current.Session("LoginID")
      Dim UserIDT As Integer = 0
      Try
        UserIDT = Convert.ToInt32(UserID)
      Catch ex As Exception

      End Try

      If DivisionID = "" Then Return Nothing
      If DisciplineID = "" Then Return Nothing
      If YearID = "" Then Return Nothing
      If MonthID = "" Then Return Nothing

      Select Case DivisionID
        Case "BOILER"
          'DivisionID = "AFBC','BLR_SPR','CFBC','HRSG','OILGAS','TG','WHRB','IPAC"
          PrjID = "CA', 'IP', 'JA', 'JB', 'JE', 'JG', 'PS', 'BS', 'DS"
        Case "SMD"
          'DivisionID = "SPDR"
          PrjID = "JS', 'SE', 'SG', 'SS', 'XP"
        Case "EPC"
          'DivisionID = "EPC01"
          PrjID = "EC', 'EE', 'EF','EG', 'EM', 'ES', 'JP"
        Case "APC"
          ' DivisionID = "ESP"
          PrjID = "AG', 'AS"
      End Select

      Select Case DisciplineID

        Case "PRC"
          DisciplineID = "PROCESS','MECHANICAL/PROCE','PROCESS-STOKER"
        Case "MEC"
          DisciplineID = "MECHANICAL/PROCE','MECHANICAL','MECH-SUGAR"
        Case "STR"
          DisciplineID = "STRUCTURE"
        Case "PIP"
          DisciplineID = "PIPING"
        Case "ELE"
          DisciplineID = "ELECTRICAL"
        Case "C&I"
          DisciplineID = "C & I','C&I','INSTRUMENTATION"
        Case "CIV"
          DisciplineID = "CIVIL"
        Case "MHE"
          DisciplineID = "MHE"
        Case "PRJ"
          DisciplineID = "OTHERS','SERVICE"
        Case "WWS"
          DisciplineID = "WWS"

      End Select

      Dim mRet As New List(Of SIS.DD.DisciplineDetail)

      Dim Sql As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString() & ";Connection Timeout=50000")
        Con.Open()




        Select Case det

          Case "SAR_TotalCount"
            Sql = " select t_cprj,t_docn,t_revn,t_dsca from tdmisg140200 where  t_resp in ('" & DisciplineID & "') AND t_pcod IN ('" & DivisionID & "') and year(t_bsfd) in (" & YearID & ") and month(t_bsfd) in (" & MonthID & ") and t_orgn='ISG'"

          Case "DueforRelease_PreviousM_B"
            Sql = " select t_cprj,t_docn,t_revn,t_dsca from tdmisg140200 where t_resp in ('" & DisciplineID & "') AND t_pcod IN ('" & DivisionID & "')  and year(t_bsfd) <= " & YearID & " and t_acdt ='1970-01-01 00:00:00.000' and t_orgn='ISG' and t_bsfd <=' " & YearID & "-" & MonthID & "-01 00:00:00.000'"

          Case "DueforRelease_BothM_C"
            Sql = " "


          Case "AllDueTillToday_Release"
            Sql = "select t_cprj,t_docn,t_revn,t_dsca From tdmisg140200 Where  t_resp In ('" & DisciplineID & "') AND t_pcod IN ('" & DivisionID & "') And t_acdt = convert(datetime,'01/01/1970',103) And  convert(date,dateadd(n,330,t_bsfd)) <= convert(date,getdate()) "

          Case "DueOnlyToday_Release"
            Sql = "Select t_cprj,t_docn,t_revn,t_dsca From tdmisg140200 Where  t_resp in ('" & DisciplineID & "') AND t_pcod IN ('" & DivisionID & "') And t_acdt = convert(datetime,'01/01/1970',103) And  convert(date,dateadd(n,330,t_bsfd)) = convert(date,getdate()) "

          Case "Ontime_Release_CurrentM"
            Sql = "		select t_cprj,t_docn,t_revn,t_dsca		"
            Sql &= "		from tdmisg140200		 "
            Sql &= "		where		 "
            Sql &= "		t_resp in ('" & DisciplineID & "') AND t_pcod IN ('" & DivisionID & "')   and year(t_bsfd) in (" & YearID & ")and month(t_bsfd) in (" & MonthID & ") And t_acdt <>'1970-01-01 00:00:00.000'"

            Sql &= "  And 1 =   case when t_acdt <  dateadd(d,1,t_bsfd) "
            Sql &= "	then 1 else 0 end "

          Case "Backlog_Release_CurrentM"
            Sql = "		select t_cprj,t_docn,t_revn,t_dsca		"
            Sql &= "	from tdmisg140200		 "
            Sql &= "	where		 "
            Sql &= "	t_resp in ('" & DisciplineID & "') AND t_pcod IN ('" & DivisionID & "')   and year(t_acdt) in (" & YearID & ")and month(t_acdt) in (" & MonthID & ")"
            Sql &= "  and t_acdt <> convert(datetime,'01/01/1970',103)	and t_bsfd <=' " & YearID & "-" & MonthID & "-01 00:00:00.000'"
            Sql &= "  And 1 =   case when t_acdt < dateadd(d,1,t_bsfd)  "
            Sql &= "	then 0 else 1 end  "





          Case "DueforRelease_CurrentM_A"
            Sql = " select t_cprj,t_docn,t_revn,t_dsca from tdmisg140200 where  t_resp in ('" & DisciplineID & "') AND t_pcod IN ('" & DivisionID & "') and year(t_bsfd) in (" & YearID & ") and month(t_bsfd) in (" & MonthID & ") and t_orgn='ISG'"


        End Select

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Cmd.CommandTimeout = 3000
          Dim rd As SqlDataReader = Cmd.ExecuteReader
          While (rd.Read)
            mRet.Add(New DisciplineDetail(rd))
          End While
        End Using
      End Using
      Return mRet
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
