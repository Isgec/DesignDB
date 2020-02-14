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

    Public Property Project_Name As String = ""

    'KJK


    Public Property prjID As String = ""


    Public Property t_bsfd As String = ""
    Public Property t_acdt As String = ""
    Public Property t_rsfd As String = ""
    Public Property t_lrrd As String = ""
    Public Property t_dttl As String = ""
    Public Property t_resp As String = ""
    Public Property t_appb As String = ""
    Public Property t_chkb As String = ""
    Public Property t_drwb As String = ""
    Public Property t_stat As String = ""
    Public Property t_wfst As String = ""
    Public Property t_soft As String = ""

    Public Property ProjectID As String = ""

    Public Property element As String = ""

    Public Property t_dcrn As String = ""
    Public Property t_cspa As String = ""
    Public Property t_reqs As String = ""
    Public Property t_comp As String = ""
    Public Property t_crea As String = ""
    Public Property t_user As String = ""



    Public Property t_tran As String = ""
    Public Property t_type As String = ""
    Public Property t_logn As String = ""
    Public Property t_subj As String = ""
    Public Property t_apsu As String = ""
    Public Property t_issu As String = ""
    Public Property t_retn As String = ""
    Public Property t_isby As String = ""
    Public Property t_isdt As String = ""

    Public Property t_sarn As String = ""
    Public Property t_draw As String = ""
    Public Property t_prep As String = ""
    Public Property t_rper As String = ""
    Public Property t_apby As String = ""

    Public Property t_rcno As String = ""
    Public Property t_item As String = ""
    Public Property IMechanical As String = ""
    Public Property IStructure As String = ""
    Public Property IPiping As String = ""
    Public Property IProcess As String = ""
    Public Property IC_I As String = ""
    Public Property IElectrical As String = ""
    Public Property IQuality As String = ""

    Public Property TT_CSPA As String = ""
    Public Property TT_ENGS As String = ""
    Public Property TT_TITTLE As String = ""
    Public Property TT_DEPT As String = ""

    Public Property Owner_Dept As String = ""
    Public Property t_dprj As String = ""

    Public Property DocumentID As String = ""
    Public Property SerialNo As String = ""
    Public Property Description As String = ""
    Public Property ResponsibleDept As String = ""
    Public Property PartUnderHold As String = ""
    Public Property RevisionAtHold As String = ""
    Public Property RevisionAtUnhold As String = ""
    Public Property reasonforHold As String = ""
    Public Property CreatedBy As String = ""
    Public Property CreatedOn As String = ""
    Public Property HoldStatus As String = ""

    Public Property Project As String = ""
    Public Property UID As String = ""
    Public Property Revision As String = ""

    Public Property Document_ID As String = ""

    Public Property Tittle As String = ""


    Public Property Owner_department As String = ""
    Public Property Actual_Release_Date As String = ""
    'LLL



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
            Sql = " select t_docn,t_revn,t_dsca,dateadd(n,330,t_bsfd) As t_bsfd, dateadd(n,330,t_rsfd) As t_rsfd,dateadd(n,330,t_acdt) As t_acdt,t_lrrd from tdmisg140200 where  t_resp in ('" & DisciplineID & "') AND t_pcod IN ('" & DivisionID & "') and year(t_bsfd) in (" & YearID & ") and month(t_bsfd) in (" & MonthID & ") and t_orgn='ISG'"

          Case "DueforRelease_PreviousM_B"
            Sql = " select t_docn,t_revn,t_dsca,dateadd(n,330,t_bsfd) As t_bsfd, dateadd(n,330,t_rsfd) As t_rsfd,dateadd(n,330,t_acdt) As t_acdt,t_lrrd from tdmisg140200 where t_resp in ('" & DisciplineID & "') AND t_pcod IN ('" & DivisionID & "')  and year(t_bsfd) <= " & YearID & " and t_acdt ='1970-01-01 00:00:00.000' and t_orgn='ISG' and t_bsfd <=' " & YearID & "-" & MonthID & "-01 00:00:00.000'"

          Case "DueforRelease_BothM_C"
            Sql = " "


          Case "AllDueTillToday_Release"
            Sql = "select t_docn,t_revn,t_dsca,dateadd(n,330,t_bsfd) As t_bsfd, dateadd(n,330,t_rsfd) As t_rsfd,dateadd(n,330,t_acdt) As t_acdt,t_lrrd From tdmisg140200 Where  t_resp In ('" & DisciplineID & "') AND t_pcod IN ('" & DivisionID & "') And t_acdt = convert(datetime,'01/01/1970',103) And  convert(date,dateadd(n,330,t_bsfd)) <= convert(date,getdate()) "

          Case "DueOnlyToday_Release"
            Sql = "Select t_docn,t_revn,t_dsca,dateadd(n,330,t_bsfd) As t_bsfd, dateadd(n,330,t_rsfd) As t_rsfd,dateadd(n,330,t_acdt) As t_acdt,t_lrrd From tdmisg140200 Where  t_resp in ('" & DisciplineID & "') AND t_pcod IN ('" & DivisionID & "') And t_acdt = convert(datetime,'01/01/1970',103) And  convert(date,dateadd(n,330,t_bsfd)) = convert(date,getdate()) "

          Case "Ontime_Release_CurrentM"
            Sql = "		select t_docn,t_revn,t_dsca,dateadd(n,330,t_bsfd) As t_bsfd, dateadd(n,330,t_rsfd) As t_rsfd,dateadd(n,330,t_acdt) As t_acdt,t_lrrd		"
            Sql &= "		from tdmisg140200		 "
            Sql &= "		where		 "
            Sql &= "		t_resp in ('" & DisciplineID & "') AND t_pcod IN ('" & DivisionID & "')   and year(t_bsfd) in (" & YearID & ")and month(t_bsfd) in (" & MonthID & ") And t_acdt <>'1970-01-01 00:00:00.000'"

            Sql &= "  And 1 =   case when t_acdt <  dateadd(d,1,t_bsfd) "
            Sql &= "	then 1 else 0 end "

          Case "Backlog_Release_CurrentM"
            Sql = "		select t_docn,t_revn,t_dsca,dateadd(n,330,t_bsfd) As t_bsfd, dateadd(n,330,t_rsfd) As t_rsfd,dateadd(n,330,t_acdt) As t_acdt,t_lrrd		"
            Sql &= "	from tdmisg140200		 "
            Sql &= "	where		 "
            Sql &= "	t_resp in ('" & DisciplineID & "') AND t_pcod IN ('" & DivisionID & "')   and year(t_acdt) in (" & YearID & ")and month(t_acdt) in (" & MonthID & ")"
            Sql &= "  and t_acdt <> convert(datetime,'01/01/1970',103)	and t_bsfd <=' " & YearID & "-" & MonthID & "-01 00:00:00.000'"
            Sql &= "  And 1 =   case when t_acdt < dateadd(d,1,t_bsfd)  "
            Sql &= "	then 0 else 1 end  "







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


            Sql = "             Select t_cprj,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name,t_sarn, t_draw,(case ttppdm090200.t_sort "
            Sql &= "            when 'MECH-SUGAR' then 'MECHANICAL' "
            Sql &= "            when 'ELECTRICAL' then 'ELECTRICAL' "
            Sql &= "            when 'MECHANICAL' then 'MECHANICAL' "
            Sql &= "            WHEN 'PROCESS-STOKER' Then 'MECHANICAL' "
            Sql &= "            when 'OTHERS' then 'OTHERS' "
            Sql &= "            WHEN 'PROCESS' then 'PROCESS' "
            Sql &= "            WHEN 'STRUCTURE' THEN 'STRUCTURE' "
            Sql &= "            WHEN 'PIPING' THEN 'PIPING' "
            Sql &= "            WHEN 'C & I' THEN 'C&I' "
            Sql &= "            WHEN 'INSTRUMENTATION' THEN 'C&I' "
            Sql &= "            WHEN 'EPC' THEN 'EPC' "
            Sql &= "            WHEN 'C&I' THEN 'C&I' "
            Sql &= "            WHEN 'ELE' THEN 'ELECTRICAL' "
            Sql &= "            WHEN 'SERVICE' THEN 'OTHERS' "
            Sql &= "            else 'OTHERS' "
            Sql &= "            end) as Owner_Dept,"
            Sql &= "            (Case t_stat "
            Sql &= "           When 1 Then 'Created' "
            Sql &= "          when 2 then 'Under Review' "
            Sql &= "         When 3 Then 'Under Approval' "
            Sql &= "           when 4 then 'Approved' "
            Sql &= "          When 5 Then 'Not Applicable' "
            Sql &= "           End) As t_stat,rec.t_cspa as element, t_prep,t_rper,t_apby  "
            Sql &= "          from ttpisg074200 As rec LEFT JOIN ttppdm090200 On ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort In ('" & DisciplineID & "') AND  substring(t_cprj,1,2) in ('" & PrjID & "') and year(t_cdat) in (" & YearID & ") and month(t_cdat) in (" & MonthID & ")"
            Sql &= "            Order by t_cprj"

          Case "SAR_UnderCreation"

            Sql = "Select t_cprj,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name,t_sarn, t_draw,(case ttppdm090200.t_sort "
            Sql &= "            when 'MECH-SUGAR' then 'MECHANICAL' "
            Sql &= "            when 'ELECTRICAL' then 'ELECTRICAL' "
            Sql &= "            when 'MECHANICAL' then 'MECHANICAL' "
            Sql &= "            WHEN 'PROCESS-STOKER' Then 'MECHANICAL' "
            Sql &= "            when 'OTHERS' then 'OTHERS' "
            Sql &= "            WHEN 'PROCESS' then 'PROCESS' "
            Sql &= "            WHEN 'STRUCTURE' THEN 'STRUCTURE' "
            Sql &= "            WHEN 'PIPING' THEN 'PIPING' "
            Sql &= "            WHEN 'C & I' THEN 'C&I' "
            Sql &= "            WHEN 'INSTRUMENTATION' THEN 'C&I' "
            Sql &= "            WHEN 'EPC' THEN 'EPC' "
            Sql &= "            WHEN 'C&I' THEN 'C&I' "
            Sql &= "            WHEN 'ELE' THEN 'ELECTRICAL' "
            Sql &= "            WHEN 'SERVICE' THEN 'OTHERS' "
            Sql &= "            else 'OTHERS' "
            Sql &= "            end) as Owner_Dept,"
            Sql &= "            (Case t_stat "
            Sql &= "           When 1 Then 'Created' "
            Sql &= "          when 2 then 'Under Review' "
            Sql &= "         When 3 Then 'Under Approval' "
            Sql &= "           when 4 then 'Approved' "
            Sql &= "          When 5 Then 'Not Applicable' "
            Sql &= "           End) As t_stat,rec.t_cspa as element, t_prep,t_rper,t_apby  "
            Sql &= " from ttpisg074200 As rec LEFT JOIN ttppdm090200 On ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort In ('" & DisciplineID & "') AND  substring(t_cprj,1,2) in ('" & PrjID & "') AND rec.t_stat =1 and year(t_cdat) in (" & YearID & ") and month(t_cdat) in (" & MonthID & ")"
            Sql &= "            Order by t_cprj"
          Case "SAR_UnderReview"
            Sql = "             Select t_cprj,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name,t_sarn, t_draw,(case ttppdm090200.t_sort "
            Sql &= "            when 'MECH-SUGAR' then 'MECHANICAL' "
            Sql &= "            when 'ELECTRICAL' then 'ELECTRICAL' "
            Sql &= "            when 'MECHANICAL' then 'MECHANICAL' "
            Sql &= "            WHEN 'PROCESS-STOKER' Then 'MECHANICAL' "
            Sql &= "            when 'OTHERS' then 'OTHERS' "
            Sql &= "            WHEN 'PROCESS' then 'PROCESS' "
            Sql &= "            WHEN 'STRUCTURE' THEN 'STRUCTURE' "
            Sql &= "            WHEN 'PIPING' THEN 'PIPING' "
            Sql &= "            WHEN 'C & I' THEN 'C&I' "
            Sql &= "            WHEN 'INSTRUMENTATION' THEN 'C&I' "
            Sql &= "            WHEN 'EPC' THEN 'EPC' "
            Sql &= "            WHEN 'C&I' THEN 'C&I' "
            Sql &= "            WHEN 'ELE' THEN 'ELECTRICAL' "
            Sql &= "            WHEN 'SERVICE' THEN 'OTHERS' "
            Sql &= "            else 'OTHERS' "
            Sql &= "            end) as Owner_Dept,"
            Sql &= "            (Case t_stat "
            Sql &= "           When 1 Then 'Created' "
            Sql &= "          when 2 then 'Under Review' "
            Sql &= "         When 3 Then 'Under Approval' "
            Sql &= "           when 4 then 'Approved' "
            Sql &= "          When 5 Then 'Not Applicable' "
            Sql &= "           End) As t_stat,rec.t_cspa as element, t_prep,t_rper,t_apby  "
            Sql &= "          from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort in ('" & DisciplineID & "') AND substring(t_cprj,1,2) in ('" & PrjID & "') AND rec.t_stat =2 and year(t_cdat) in (" & YearID & ") and month(t_cdat) in (" & MonthID & ")"
            Sql &= "            Order by t_cprj"
          Case "SAR_UnderApproval"
            Sql = "           Select t_cprj,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name,t_sarn, t_draw,(case ttppdm090200.t_sort "
            Sql &= "            when 'MECH-SUGAR' then 'MECHANICAL' "
            Sql &= "            when 'ELECTRICAL' then 'ELECTRICAL' "
            Sql &= "            when 'MECHANICAL' then 'MECHANICAL' "
            Sql &= "            WHEN 'PROCESS-STOKER' Then 'MECHANICAL' "
            Sql &= "            when 'OTHERS' then 'OTHERS' "
            Sql &= "            WHEN 'PROCESS' then 'PROCESS' "
            Sql &= "            WHEN 'STRUCTURE' THEN 'STRUCTURE' "
            Sql &= "            WHEN 'PIPING' THEN 'PIPING' "
            Sql &= "            WHEN 'C & I' THEN 'C&I' "
            Sql &= "            WHEN 'INSTRUMENTATION' THEN 'C&I' "
            Sql &= "            WHEN 'EPC' THEN 'EPC' "
            Sql &= "            WHEN 'C&I' THEN 'C&I' "
            Sql &= "            WHEN 'ELE' THEN 'ELECTRICAL' "
            Sql &= "            WHEN 'SERVICE' THEN 'OTHERS' "
            Sql &= "            else 'OTHERS' "
            Sql &= "            end) as Owner_Dept,"
            Sql &= "            (Case t_stat "
            Sql &= "           When 1 Then 'Created' "
            Sql &= "          when 2 then 'Under Review' "
            Sql &= "         When 3 Then 'Under Approval' "
            Sql &= "           when 4 then 'Approved' "
            Sql &= "          When 5 Then 'Not Applicable' "
            Sql &= "           End) As t_stat,rec.t_cspa as element, t_prep,t_rper,t_apby  "


            Sql &= "          from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort in ('" & DisciplineID & "') AND  substring(t_cprj,1,2) in ('" & PrjID & "') AND rec.t_stat =3 and year(t_cdat) in (" & YearID & ") and month(t_cdat) in (" & MonthID & ")"
            Sql &= "            Order by t_cprj"
          Case "SAR_Pending"
            Sql = "           Select t_cprj,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name,t_sarn, t_draw,(case ttppdm090200.t_sort "
            Sql &= "            when 'MECH-SUGAR' then 'MECHANICAL' "
            Sql &= "            when 'ELECTRICAL' then 'ELECTRICAL' "
            Sql &= "            when 'MECHANICAL' then 'MECHANICAL' "
            Sql &= "            WHEN 'PROCESS-STOKER' Then 'MECHANICAL' "
            Sql &= "            when 'OTHERS' then 'OTHERS' "
            Sql &= "            WHEN 'PROCESS' then 'PROCESS' "
            Sql &= "            WHEN 'STRUCTURE' THEN 'STRUCTURE' "
            Sql &= "            WHEN 'PIPING' THEN 'PIPING' "
            Sql &= "            WHEN 'C & I' THEN 'C&I' "
            Sql &= "            WHEN 'INSTRUMENTATION' THEN 'C&I' "
            Sql &= "            WHEN 'EPC' THEN 'EPC' "
            Sql &= "            WHEN 'C&I' THEN 'C&I' "
            Sql &= "            WHEN 'ELE' THEN 'ELECTRICAL' "
            Sql &= "            WHEN 'SERVICE' THEN 'OTHERS' "
            Sql &= "            else 'OTHERS' "
            Sql &= "            end) as Owner_Dept,"
            Sql &= "            (Case t_stat "
            Sql &= "           When 1 Then 'Created' "
            Sql &= "          when 2 then 'Under Review' "
            Sql &= "         When 3 Then 'Under Approval' "
            Sql &= "           when 4 then 'Approved' "
            Sql &= "          When 5 Then 'Not Applicable' "
            Sql &= "           End) As t_stat,rec.t_cspa as element, t_prep,t_rper,t_apby  "

            Sql &= "          from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort in ('" & DisciplineID & "') AND  substring(t_cprj,1,2) in ('" & PrjID & "') AND rec.t_stat in (2,3) and year(t_cdat) in (" & YearID & ") and month(t_cdat) in (" & MonthID & ")"
            Sql &= "            Order by t_cprj"
          Case "SAR_Approved"

            Sql = "           Select t_cprj,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name,t_sarn, t_draw,(case ttppdm090200.t_sort "
            Sql &= "            when 'MECH-SUGAR' then 'MECHANICAL' "
            Sql &= "            when 'ELECTRICAL' then 'ELECTRICAL' "
            Sql &= "            when 'MECHANICAL' then 'MECHANICAL' "
            Sql &= "            WHEN 'PROCESS-STOKER' Then 'MECHANICAL' "
            Sql &= "            when 'OTHERS' then 'OTHERS' "
            Sql &= "            WHEN 'PROCESS' then 'PROCESS' "
            Sql &= "            WHEN 'STRUCTURE' THEN 'STRUCTURE' "
            Sql &= "            WHEN 'PIPING' THEN 'PIPING' "
            Sql &= "            WHEN 'C & I' THEN 'C&I' "
            Sql &= "            WHEN 'INSTRUMENTATION' THEN 'C&I' "
            Sql &= "            WHEN 'EPC' THEN 'EPC' "
            Sql &= "            WHEN 'C&I' THEN 'C&I' "
            Sql &= "            WHEN 'ELE' THEN 'ELECTRICAL' "
            Sql &= "            WHEN 'SERVICE' THEN 'OTHERS' "
            Sql &= "            else 'OTHERS' "
            Sql &= "            end) as Owner_Dept,"
            Sql &= "            (Case t_stat "
            Sql &= "           When 1 Then 'Created' "
            Sql &= "          when 2 then 'Under Review' "
            Sql &= "         When 3 Then 'Under Approval' "
            Sql &= "           when 4 then 'Approved' "
            Sql &= "          When 5 Then 'Not Applicable' "
            Sql &= "           End) As t_stat,rec.t_cspa as element, t_prep,t_rper,t_apby  "
            Sql &= "          from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort in ('" & DisciplineID & "') AND  substring(t_cprj,1,2) in ('" & PrjID & "') AND rec.t_stat =4 and year(t_cdat) in (" & YearID & ") and month(t_cdat) in (" & MonthID & ")"
            Sql &= "            Order by t_cprj"

          Case "SAR_NotApplicable"

            Sql = "           Select t_cprj,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name,t_sarn, t_draw,(case ttppdm090200.t_sort "
            Sql &= "            when 'MECH-SUGAR' then 'MECHANICAL' "
            Sql &= "            when 'ELECTRICAL' then 'ELECTRICAL' "
            Sql &= "            when 'MECHANICAL' then 'MECHANICAL' "
            Sql &= "            WHEN 'PROCESS-STOKER' Then 'MECHANICAL' "
            Sql &= "            when 'OTHERS' then 'OTHERS' "
            Sql &= "            WHEN 'PROCESS' then 'PROCESS' "
            Sql &= "            WHEN 'STRUCTURE' THEN 'STRUCTURE' "
            Sql &= "            WHEN 'PIPING' THEN 'PIPING' "
            Sql &= "            WHEN 'C & I' THEN 'C&I' "
            Sql &= "            WHEN 'INSTRUMENTATION' THEN 'C&I' "
            Sql &= "            WHEN 'EPC' THEN 'EPC' "
            Sql &= "            WHEN 'C&I' THEN 'C&I' "
            Sql &= "            WHEN 'ELE' THEN 'ELECTRICAL' "
            Sql &= "            WHEN 'SERVICE' THEN 'OTHERS' "
            Sql &= "            else 'OTHERS' "
            Sql &= "            end) as Owner_Dept,"
            Sql &= "            (Case t_stat "
            Sql &= "           When 1 Then 'Created' "
            Sql &= "          when 2 then 'Under Review' "
            Sql &= "         When 3 Then 'Under Approval' "
            Sql &= "           when 4 then 'Approved' "
            Sql &= "          When 5 Then 'Not Applicable' "
            Sql &= "           End) As t_stat,rec.t_cspa as element, t_prep,t_rper,t_apby  "
            Sql &= "          from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort in ('" & DisciplineID & "') AND  substring(t_cprj,1,2) in ('" & PrjID & "') AND rec.t_stat =5 and year(t_cdat) in (" & YearID & ") and month(t_cdat) in (" & MonthID & ")"
            Sql &= "            Order by t_cprj"
          Case "SAR_TotalCountA"

            Sql = "           Select t_cprj,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name,t_sarn, t_draw,(case ttppdm090200.t_sort "
            Sql &= "            when 'MECH-SUGAR' then 'MECHANICAL' "
            Sql &= "            when 'ELECTRICAL' then 'ELECTRICAL' "
            Sql &= "            when 'MECHANICAL' then 'MECHANICAL' "
            Sql &= "            WHEN 'PROCESS-STOKER' Then 'MECHANICAL' "
            Sql &= "            when 'OTHERS' then 'OTHERS' "
            Sql &= "            WHEN 'PROCESS' then 'PROCESS' "
            Sql &= "            WHEN 'STRUCTURE' THEN 'STRUCTURE' "
            Sql &= "            WHEN 'PIPING' THEN 'PIPING' "
            Sql &= "            WHEN 'C & I' THEN 'C&I' "
            Sql &= "            WHEN 'INSTRUMENTATION' THEN 'C&I' "
            Sql &= "            WHEN 'EPC' THEN 'EPC' "
            Sql &= "            WHEN 'C&I' THEN 'C&I' "
            Sql &= "            WHEN 'ELE' THEN 'ELECTRICAL' "
            Sql &= "            WHEN 'SERVICE' THEN 'OTHERS' "
            Sql &= "            else 'OTHERS' "
            Sql &= "            end) as Owner_Dept,"
            Sql &= "            (Case t_stat "
            Sql &= "           When 1 Then 'Created' "
            Sql &= "          when 2 then 'Under Review' "
            Sql &= "         When 3 Then 'Under Approval' "
            Sql &= "           when 4 then 'Approved' "
            Sql &= "          When 5 Then 'Not Applicable' "
            Sql &= "           End) As t_stat,rec.t_cspa as element, t_prep,t_rper,t_apby  "
            Sql &= "          from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort in ('" & DisciplineID & "') AND  substring(t_cprj,1,2) in ('" & PrjID & "')  "
            Sql &= "            Order by t_cprj"
          Case "SAR_UnderCreationA"

            Sql = "           Select t_cprj,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name,t_sarn, t_draw,(case ttppdm090200.t_sort "
            Sql &= "            when 'MECH-SUGAR' then 'MECHANICAL' "
            Sql &= "            when 'ELECTRICAL' then 'ELECTRICAL' "
            Sql &= "            when 'MECHANICAL' then 'MECHANICAL' "
            Sql &= "            WHEN 'PROCESS-STOKER' Then 'MECHANICAL' "
            Sql &= "            when 'OTHERS' then 'OTHERS' "
            Sql &= "            WHEN 'PROCESS' then 'PROCESS' "
            Sql &= "            WHEN 'STRUCTURE' THEN 'STRUCTURE' "
            Sql &= "            WHEN 'PIPING' THEN 'PIPING' "
            Sql &= "            WHEN 'C & I' THEN 'C&I' "
            Sql &= "            WHEN 'INSTRUMENTATION' THEN 'C&I' "
            Sql &= "            WHEN 'EPC' THEN 'EPC' "
            Sql &= "            WHEN 'C&I' THEN 'C&I' "
            Sql &= "            WHEN 'ELE' THEN 'ELECTRICAL' "
            Sql &= "            WHEN 'SERVICE' THEN 'OTHERS' "
            Sql &= "            else 'OTHERS' "
            Sql &= "            end) as Owner_Dept,"
            Sql &= "            (Case t_stat "
            Sql &= "           When 1 Then 'Created' "
            Sql &= "          when 2 then 'Under Review' "
            Sql &= "         When 3 Then 'Under Approval' "
            Sql &= "           when 4 then 'Approved' "
            Sql &= "          When 5 Then 'Not Applicable' "
            Sql &= "           End) As t_stat,rec.t_cspa as element, t_prep,t_rper,t_apby  "
            Sql &= "          from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort in ('" & DisciplineID & "') AND  substring(t_cprj,1,2) in ('" & PrjID & "') AND rec.t_stat =1  "
            Sql &= "            Order by t_cprj"
          Case "SAR_UnderReviewA"
            Sql = "           Select t_cprj,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name,t_sarn, t_draw,(case ttppdm090200.t_sort "
            Sql &= "            when 'MECH-SUGAR' then 'MECHANICAL' "
            Sql &= "            when 'ELECTRICAL' then 'ELECTRICAL' "
            Sql &= "            when 'MECHANICAL' then 'MECHANICAL' "
            Sql &= "            WHEN 'PROCESS-STOKER' Then 'MECHANICAL' "
            Sql &= "            when 'OTHERS' then 'OTHERS' "
            Sql &= "            WHEN 'PROCESS' then 'PROCESS' "
            Sql &= "            WHEN 'STRUCTURE' THEN 'STRUCTURE' "
            Sql &= "            WHEN 'PIPING' THEN 'PIPING' "
            Sql &= "            WHEN 'C & I' THEN 'C&I' "
            Sql &= "            WHEN 'INSTRUMENTATION' THEN 'C&I' "
            Sql &= "            WHEN 'EPC' THEN 'EPC' "
            Sql &= "            WHEN 'C&I' THEN 'C&I' "
            Sql &= "            WHEN 'ELE' THEN 'ELECTRICAL' "
            Sql &= "            WHEN 'SERVICE' THEN 'OTHERS' "
            Sql &= "            else 'OTHERS' "
            Sql &= "            end) as Owner_Dept,"
            Sql &= "            (Case t_stat "
            Sql &= "           When 1 Then 'Created' "
            Sql &= "          when 2 then 'Under Review' "
            Sql &= "         When 3 Then 'Under Approval' "
            Sql &= "           when 4 then 'Approved' "
            Sql &= "          When 5 Then 'Not Applicable' "
            Sql &= "           End) As t_stat,rec.t_cspa as element, t_prep,t_rper,t_apby  "

            Sql &= "          from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort in ('" & DisciplineID & "') AND substring(t_cprj,1,2) in ('" & PrjID & "') AND rec.t_stat =2  "
            Sql &= "            Order by t_cprj"
          Case "SAR_UnderApprovalA"

            Sql = "Select t_cprj,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name,t_sarn, t_draw,(case ttppdm090200.t_sort "
            Sql &= "            when 'MECH-SUGAR' then 'MECHANICAL' "
            Sql &= "            when 'ELECTRICAL' then 'ELECTRICAL' "
            Sql &= "            when 'MECHANICAL' then 'MECHANICAL' "
            Sql &= "            WHEN 'PROCESS-STOKER' Then 'MECHANICAL' "
            Sql &= "            when 'OTHERS' then 'OTHERS' "
            Sql &= "            WHEN 'PROCESS' then 'PROCESS' "
            Sql &= "            WHEN 'STRUCTURE' THEN 'STRUCTURE' "
            Sql &= "            WHEN 'PIPING' THEN 'PIPING' "
            Sql &= "            WHEN 'C & I' THEN 'C&I' "
            Sql &= "            WHEN 'INSTRUMENTATION' THEN 'C&I' "
            Sql &= "            WHEN 'EPC' THEN 'EPC' "
            Sql &= "            WHEN 'C&I' THEN 'C&I' "
            Sql &= "            WHEN 'ELE' THEN 'ELECTRICAL' "
            Sql &= "            WHEN 'SERVICE' THEN 'OTHERS' "
            Sql &= "            else 'OTHERS' "
            Sql &= "            end) as Owner_Dept,"
            Sql &= "            (Case t_stat "
            Sql &= "           When 1 Then 'Created' "
            Sql &= "          when 2 then 'Under Review' "
            Sql &= "         When 3 Then 'Under Approval' "
            Sql &= "           when 4 then 'Approved' "
            Sql &= "          When 5 Then 'Not Applicable' "
            Sql &= "           End) As t_stat,rec.t_cspa as element, t_prep,t_rper,t_apby  "
            Sql &= "        from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort in ('" & DisciplineID & "') AND  substring(t_cprj,1,2) in ('" & PrjID & "') AND rec.t_stat =3  "
            Sql &= "            Order by t_cprj"
          Case "SAR_PendingA"

            Sql = "Select t_cprj,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name,t_sarn, t_draw,(case ttppdm090200.t_sort "
            Sql &= "            when 'MECH-SUGAR' then 'MECHANICAL' "
            Sql &= "            when 'ELECTRICAL' then 'ELECTRICAL' "
            Sql &= "            when 'MECHANICAL' then 'MECHANICAL' "
            Sql &= "            WHEN 'PROCESS-STOKER' Then 'MECHANICAL' "
            Sql &= "            when 'OTHERS' then 'OTHERS' "
            Sql &= "            WHEN 'PROCESS' then 'PROCESS' "
            Sql &= "            WHEN 'STRUCTURE' THEN 'STRUCTURE' "
            Sql &= "            WHEN 'PIPING' THEN 'PIPING' "
            Sql &= "            WHEN 'C & I' THEN 'C&I' "
            Sql &= "            WHEN 'INSTRUMENTATION' THEN 'C&I' "
            Sql &= "            WHEN 'EPC' THEN 'EPC' "
            Sql &= "            WHEN 'C&I' THEN 'C&I' "
            Sql &= "            WHEN 'ELE' THEN 'ELECTRICAL' "
            Sql &= "            WHEN 'SERVICE' THEN 'OTHERS' "
            Sql &= "            else 'OTHERS' "
            Sql &= "            end) as Owner_Dept,"
            Sql &= "            (Case t_stat "
            Sql &= "           When 1 Then 'Created' "
            Sql &= "          when 2 then 'Under Review' "
            Sql &= "         When 3 Then 'Under Approval' "
            Sql &= "           when 4 then 'Approved' "
            Sql &= "          When 5 Then 'Not Applicable' "
            Sql &= "           End) As t_stat,rec.t_cspa as element, t_prep,t_rper,t_apby  "
            Sql &= "        from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort in ('" & DisciplineID & "') AND  substring(t_cprj,1,2) in ('" & PrjID & "') AND rec.t_stat in (2,3)  "
            Sql &= "            Order by t_cprj"
          Case "SAR_ApprovedA"

            Sql = "Select t_cprj,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name,t_sarn, t_draw,(case ttppdm090200.t_sort "
            Sql &= "            when 'MECH-SUGAR' then 'MECHANICAL' "
            Sql &= "            when 'ELECTRICAL' then 'ELECTRICAL' "
            Sql &= "            when 'MECHANICAL' then 'MECHANICAL' "
            Sql &= "            WHEN 'PROCESS-STOKER' Then 'MECHANICAL' "
            Sql &= "            when 'OTHERS' then 'OTHERS' "
            Sql &= "            WHEN 'PROCESS' then 'PROCESS' "
            Sql &= "            WHEN 'STRUCTURE' THEN 'STRUCTURE' "
            Sql &= "            WHEN 'PIPING' THEN 'PIPING' "
            Sql &= "            WHEN 'C & I' THEN 'C&I' "
            Sql &= "            WHEN 'INSTRUMENTATION' THEN 'C&I' "
            Sql &= "            WHEN 'EPC' THEN 'EPC' "
            Sql &= "            WHEN 'C&I' THEN 'C&I' "
            Sql &= "            WHEN 'ELE' THEN 'ELECTRICAL' "
            Sql &= "            WHEN 'SERVICE' THEN 'OTHERS' "
            Sql &= "            else 'OTHERS' "
            Sql &= "            end) as Owner_Dept,"
            Sql &= "            (Case t_stat "
            Sql &= "           When 1 Then 'Created' "
            Sql &= "          when 2 then 'Under Review' "
            Sql &= "         When 3 Then 'Under Approval' "
            Sql &= "           when 4 then 'Approved' "
            Sql &= "          When 5 Then 'Not Applicable' "
            Sql &= "           End) As t_stat,rec.t_cspa as element, t_prep,t_rper,t_apby  "
            Sql &= "            from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort in ('" & DisciplineID & "') AND  substring(t_cprj,1,2) in ('" & PrjID & "') AND rec.t_stat =4  "

            Sql &= "            Order by t_cprj"
          Case "SAR_NotApplicableA"

            Sql = "Select t_cprj,(select t_dsca from ttcmcs052200 where ttcmcs052200.t_cprj=rec.t_cprj) as Project_Name,t_sarn, t_draw,(case ttppdm090200.t_sort "
            Sql &= "            when 'MECH-SUGAR' then 'MECHANICAL' "
            Sql &= "            when 'ELECTRICAL' then 'ELECTRICAL' "
            Sql &= "            when 'MECHANICAL' then 'MECHANICAL' "
            Sql &= "            WHEN 'PROCESS-STOKER' Then 'MECHANICAL' "
            Sql &= "            when 'OTHERS' then 'OTHERS' "
            Sql &= "            WHEN 'PROCESS' then 'PROCESS' "
            Sql &= "            WHEN 'STRUCTURE' THEN 'STRUCTURE' "
            Sql &= "            WHEN 'PIPING' THEN 'PIPING' "
            Sql &= "            WHEN 'C & I' THEN 'C&I' "
            Sql &= "            WHEN 'INSTRUMENTATION' THEN 'C&I' "
            Sql &= "            WHEN 'EPC' THEN 'EPC' "
            Sql &= "            WHEN 'C&I' THEN 'C&I' "
            Sql &= "            WHEN 'ELE' THEN 'ELECTRICAL' "
            Sql &= "            WHEN 'SERVICE' THEN 'OTHERS' "
            Sql &= "            else 'OTHERS' "
            Sql &= "            end) as Owner_Dept,"
            Sql &= "            (Case t_stat "
            Sql &= "           When 1 Then 'Created' "
            Sql &= "          when 2 then 'Under Review' "
            Sql &= "         When 3 Then 'Under Approval' "
            Sql &= "           when 4 then 'Approved' "
            Sql &= "          When 5 Then 'Not Applicable' "
            Sql &= "           End) As t_stat,rec.t_cspa as element, t_prep,t_rper,t_apby  "
            Sql &= "          from ttpisg074200 as rec LEFT JOIN ttppdm090200 on ttppdm090200.t_cspa = rec.t_cspa Where ttppdm090200.t_sort in ('" & DisciplineID & "') AND  substring(t_cprj,1,2) in ('" & PrjID & "') AND rec.t_stat =5  "
            Sql &= "            Order by t_cprj"


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
