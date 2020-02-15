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
    Public Property ToRelease_CurrentM As Integer = 0
    Public Property DueforRelease_CurrentM_A As Integer = 0
    Public Property DueforRelease_PreviousM_B As Integer = 0
    Public Property DueforRelease_BothM_C As Integer = 0
    Public Property AllDueTillToday_Release As Integer = 0
    Public Property DueOnlyToday_Release As Integer = 0
    Public Property Ontime_Release_CurrentM As Integer = 0
    Public Property Backlog_Release_CurrentM As Integer = 0

    Public Property SAR_TotalCount As Integer = 0
    Public Property SAR_UnderCreation As Integer = 0
    Public Property SAR_UnderReview As Integer = 0
    Public Property SAR_UnderApproval As Integer = 0
    Public Property SAR_Pending As Integer = 0
    Public Property SAR_Approved As Integer = 0
    Public Property SAR_NotApplicable As Integer = 0
    Public Property SAR_TotalCountA As Integer = 0
    Public Property SAR_UnderCreationA As Integer = 0
    Public Property SAR_UnderReviewA As Integer = 0
    Public Property SAR_UnderApprovalA As Integer = 0
    Public Property SAR_PendingA As Integer = 0
    Public Property SAR_ApprovedA As Integer = 0
    Public Property SAR_NotApplicableA As Integer = 0

    Public Property Total_Active_Element As Integer = 0
    Public Property Element_Completed As Integer = 0
    Public Property Element_Partial As Integer = 0
    Public Property Element_Free As Integer = 0

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
        Sql = "select count(*) from tdmisg140200 where  t_resp in ('" & DisciplineID & "') AND t_pcod IN ('" & DivisionID & "') and year(dateadd(n,330,t_bsfd)) in (" & YearId & ") and month(dateadd(n,330,t_bsfd)) in (" & MonthId & ") and t_orgn='ISG' and t_docn not like '%VEN%'"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.ToRelease_CurrentM = Cmd.ExecuteScalar
        End Using



        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from tdmisg140200 where  t_resp in ('" & DisciplineID & "') AND t_pcod IN ('" & DivisionID & "') and year(dateadd(n,330,t_bsfd)) in (" & YearId & ") and month(dateadd(n,330,t_bsfd)) in (" & MonthId & ") and t_orgn='ISG' and t_docn not like '%VEN%'  and t_acdt ='1970-01-01 00:00:00.000'"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.DueforRelease_CurrentM_A = Cmd.ExecuteScalar
        End Using

        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from tdmisg140200 where t_resp in ('" & DisciplineID & "') AND t_pcod IN ('" & DivisionID & "')  and t_acdt ='1970-01-01 00:00:00.000' and t_orgn='ISG' and (dateadd(n,330,t_bsfd)) <' " & YearId & "-" & MonthId & "-01 00:00:00.000' and t_docn not like '%VEN%'"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.DueforRelease_PreviousM_B = Cmd.ExecuteScalar
        End Using

        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = " Select count(*) from tdmisg140200 where t_resp in ('" & DisciplineID & "') AND t_pcod IN ('" & DivisionID & "') and t_acdt ='1970-01-01 00:00:00.000' and t_orgn='ISG' and (dateadd(n,330,t_bsfd)) <=' " & YearId & "-" & MonthId + 1 & "-01 00:00:00.000' and t_docn not like '%VEN%'"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.DueforRelease_BothM_C = Cmd.ExecuteScalar
        End Using


        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = " Select count(*) From tdmisg140200 Where  t_resp in ('" & DisciplineID & "') AND t_pcod IN ('" & DivisionID & "') And t_acdt = convert(datetime,'01/01/1970',103) And  convert(date,dateadd(n,330,t_bsfd)) <= convert(date,getdate())  and t_docn not like '%VEN%'"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.AllDueTillToday_Release = Cmd.ExecuteScalar
        End Using

        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = " Select count(*) From tdmisg140200 Where  t_resp in ('" & DisciplineID & "') AND t_pcod IN ('" & DivisionID & "') And t_acdt = convert(datetime,'01/01/1970',103) And  convert(date,dateadd(n,330,t_bsfd)) = convert(date,getdate()) and t_docn not like '%VEN%'"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.DueOnlyToday_Release = Cmd.ExecuteScalar
        End Using


        Sql = "		select count(*)		"
        Sql &= "		from tdmisg140200		 "
        Sql &= "		where		 "
        Sql &= "		t_resp in ('" & DisciplineID & "') AND t_pcod IN ('" & DivisionID & "')   and year(dateadd(n,330,t_bsfd)) in (" & YearId & ")and month(dateadd(n,330,t_bsfd)) in (" & MonthId & ") And t_acdt <>'1970-01-01 00:00:00.000' and t_docn not like '%VEN%'"

        Sql &= "  And 1 =   case when (dateadd(n,330,t_acdt)) <  dateadd(d,1,(dateadd(n,330,t_bsfd))) "
        Sql &= "	then 1 else 0 end "

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Ontime_Release_CurrentM = Cmd.ExecuteScalar
        End Using


        Sql = "		select count(*)		"
        Sql &= "	from tdmisg140200		 "
        Sql &= "	where		 "
        Sql &= "	t_resp in ('" & DisciplineID & "') AND t_pcod IN ('" & DivisionID & "')   and year(dateadd(n,330,t_acdt)) in (" & YearId & ")and month(dateadd(n,330,t_acdt)) in (" & MonthId & ")  and t_docn not like '%VEN%'"
        Sql &= "  and t_acdt <> convert(datetime,'01/01/1970',103)	and (dateadd(n,330,t_bsfd)) <=' " & YearId & "-" & MonthId & "-01 00:00:00.000'"
        Sql &= "  And 1 =   case when (dateadd(n,330,t_acdt)) < dateadd(d,1,(dateadd(n,330,t_bsfd)))  "
        Sql &= "	then 0 else 1 end  "

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Backlog_Release_CurrentM = Cmd.ExecuteScalar
        End Using



      End Using
      Return mRet
    End Function

    Public Shared Function GetDSARDB(ByVal DivisionID As String, ByVal DisciplineID As String, ByVal MonthId As Integer, ByVal YearId As String) As DBDiscipline
      Dim PrjID As String = ""
      If DivisionID = "" Then Return Nothing

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

      Dim mRet As New DBDiscipline
      mRet.DivisionID = DivisionID
      mRet.DisciplineID = DisciplineID
      mRet.MonthID = MonthId
      mRet.YearID = YearId


      Dim Sql As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()


        Sql = "select count(*) from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort in ('" & DisciplineID & "') AND  substring(t_cprj,1,2) in ('" & PrjID & "') and year(t_cdat) in (" & YearId & ") and month(t_cdat) in (" & MonthId & ")"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.SAR_TotalCount = Cmd.ExecuteScalar
        End Using

        Sql = "select count(*) from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort in ('" & DisciplineID & "') AND  substring(t_cprj,1,2) in ('" & PrjID & "') AND rec.t_stat =1 and year(t_cdat) in (" & YearId & ") and month(t_cdat) in (" & MonthId & ")"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.SAR_UnderCreation = Cmd.ExecuteScalar
        End Using


        Sql = " select count(*) from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort in ('" & DisciplineID & "') AND substring(t_cprj,1,2) in ('" & PrjID & "') AND rec.t_stat =2 and year(t_cdat) in (" & YearId & ") and month(t_cdat) in (" & MonthId & ")"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.SAR_UnderReview = Cmd.ExecuteScalar
        End Using

        Sql = " select count(*) from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort in ('" & DisciplineID & "') AND  substring(t_cprj,1,2) in ('" & PrjID & "') AND rec.t_stat =3 and year(t_cdat) in (" & YearId & ") and month(t_cdat) in (" & MonthId & ")"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.SAR_UnderApproval = Cmd.ExecuteScalar
        End Using

        Sql = " select count(*) from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort in ('" & DisciplineID & "') AND  substring(t_cprj,1,2) in ('" & PrjID & "') AND rec.t_stat in (2,3) and year(t_cdat) in (" & YearId & ") and month(t_cdat) in (" & MonthId & ")"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.SAR_Pending = Cmd.ExecuteScalar
        End Using

        Sql = " select count(*) from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort in ('" & DisciplineID & "') AND  substring(t_cprj,1,2) in ('" & PrjID & "') AND rec.t_stat =4 and year(t_cdat) in (" & YearId & ") and month(t_cdat) in (" & MonthId & ")"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.SAR_Approved = Cmd.ExecuteScalar
        End Using

        Sql = " select count(*) from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort in ('" & DisciplineID & "') AND  substring(t_cprj,1,2) in ('" & PrjID & "') AND rec.t_stat =5 and year(t_cdat) in (" & YearId & ") and month(t_cdat) in (" & MonthId & ")"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.SAR_NotApplicable = Cmd.ExecuteScalar
        End Using

        Sql = "select count(*) from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort in ('" & DisciplineID & "') AND  substring(t_cprj,1,2) in ('" & PrjID & "')"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.SAR_TotalCountA = Cmd.ExecuteScalar
        End Using

        Sql = "select count(*) from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort in ('" & DisciplineID & "') AND  substring(t_cprj,1,2) in ('" & PrjID & "') AND rec.t_stat =1"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.SAR_UnderCreationA = Cmd.ExecuteScalar
        End Using


        Sql = " select count(*) from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort in ('" & DisciplineID & "') AND substring(t_cprj,1,2) in ('" & PrjID & "') AND rec.t_stat =2"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.SAR_UnderReviewA = Cmd.ExecuteScalar
        End Using


        Sql = " select count(*) from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort in ('" & DisciplineID & "') AND substring(t_cprj,1,2) in ('" & PrjID & "') AND rec.t_stat  in (2,3)"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.SAR_PendingA = Cmd.ExecuteScalar
        End Using


        Sql = " select count(*) from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort in ('" & DisciplineID & "') AND  substring(t_cprj,1,2) in ('" & PrjID & "') AND rec.t_stat =3"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.SAR_UnderApprovalA = Cmd.ExecuteScalar
        End Using

        Sql = " select count(*) from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort in ('" & DisciplineID & "') AND  substring(t_cprj,1,2) in ('" & PrjID & "') AND rec.t_stat =4"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.SAR_ApprovedA = Cmd.ExecuteScalar
        End Using

        Sql = " select count(*) from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort in ('" & DisciplineID & "') AND  substring(t_cprj,1,2) in ('" & PrjID & "') AND rec.t_stat =5"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.SAR_NotApplicableA = Cmd.ExecuteScalar
        End Using

      End Using
      Return mRet
    End Function

    Public Shared Function GetDELEMENTDB(ByVal DivisionID As String, ByVal DisciplineID As String, ByVal MonthId As Integer, ByVal YearId As String) As DBDiscipline
      Dim PrjID As String = ""
      If DivisionID = "" Then Return Nothing

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

      Dim mRet As New DBDiscipline
      mRet.DivisionID = DivisionID
      mRet.DisciplineID = DisciplineID
      mRet.MonthID = MonthId
      mRet.YearID = YearId


      Dim Sql As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()


        't_acdt = convert(datetime,'01/01/1970',103) and


        ' Sql = "-"
        Sql = "select count(*) from ttpisg063200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort in ('" & DisciplineID & "') and substring(rec.t_cprj,1,2) in ('" & PrjID & "') and rec.t_appl=1 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Total_Active_Element = Cmd.ExecuteScalar
        End Using


        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from ttpisg063200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort in ('" & DisciplineID & "') and substring(rec.t_cprj,1,2) in ('" & PrjID & "') and rec.t_appl=1  and rec.t_engs=1 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Element_Free = Cmd.ExecuteScalar
        End Using



        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from ttpisg063200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort in ('" & DisciplineID & "') and substring(rec.t_cprj,1,2) in ('" & PrjID & "') and rec.t_appl=1  and rec.t_engs=2 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Element_Partial = Cmd.ExecuteScalar
        End Using


        ' Sql = "select count(*) from tdmisg001200 where t_stat =1 and t_wfst =3 and t_rusr='" & UserID & "'"
        Sql = "select count(*) from ttpisg063200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa where ttppdm090200.t_sort in ('" & DisciplineID & "') and substring(rec.t_cprj,1,2) in ('" & PrjID & "') and rec.t_appl=1  and rec.t_engs=3 "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.Element_Completed = Cmd.ExecuteScalar
        End Using



      End Using
      Return mRet
    End Function


  End Class
End Namespace
