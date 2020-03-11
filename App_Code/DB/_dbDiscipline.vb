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

    Public Property IDMSP_Total_Count As Integer = 0
    Public Property IDMSP_Submitted As Integer = 0
    Public Property IDMSP_Document_linked As Integer = 0
    Public Property IDMSP_Under_Evaluation As Integer = 0
    Public Property IDMSP_Comments_Submitted As Integer = 0
    Public Property IDMSP_Technically_Cleared As Integer = 0
    Public Property IDMSP_Transmittal_Issued As Integer = 0
    Public Property IDMSP_Superceded As Integer = 0
    Public Property IDMSP_Closed As Integer = 0

    Public Property All_IDMSP_Total_Count As Integer = 0
    Public Property All_IDMSP_Submitted As Integer = 0
    Public Property All_IDMSP_Document_linked As Integer = 0
    Public Property All_IDMSP_Under_Evaluation As Integer = 0
    Public Property All_IDMSP_Comments_Submitted As Integer = 0
    Public Property All_IDMSP_Technically_Cleared As Integer = 0
    Public Property All_IDMSP_Transmittal_Issued As Integer = 0
    Public Property All_IDMSP_Superceded As Integer = 0
    Public Property All_IDMSP_Closed As Integer = 0

    Public Property IDMSPO_Total_Count As Integer = 0
    Public Property IDMSPO_Submitted As Integer = 0
    Public Property IDMSPO_Document_linked As Integer = 0
    Public Property IDMSPO_Under_Evaluation As Integer = 0
    Public Property IDMSPO_Comments_Submitted As Integer = 0
    Public Property IDMSPO_Technically_Cleared As Integer = 0
    Public Property IDMSPO_Transmittal_Issued As Integer = 0
    Public Property IDMSPO_Superceded As Integer = 0
    Public Property IDMSPO_Closed As Integer = 0

    Public Property All_IDMSPO_Total_Count As Integer = 0
    Public Property All_IDMSPo_Submitted As Integer = 0
    Public Property All_IDMSPo_Document_linked As Integer = 0
    Public Property All_IDMSPo_Under_Evaluation As Integer = 0
    Public Property All_IDMSPo_Comments_Submitted As Integer = 0
    Public Property All_IDMSPo_Technically_Cleared As Integer = 0
    Public Property All_IDMSPo_Transmittal_Issued As Integer = 0
    Public Property All_IDMSPo_Superceded As Integer = 0
    Public Property All_IDMSPo_Closed As Integer = 0

    Public Property ReceiptID As String = ""
    Public Property ReceiptDate As String = ""
    Public Property SentDate As String = ""
    Public Property Rageindays As String = ""
    Public Property Owner_Dept As String = ""
    Public Property Relement As String = ""
    Public Property PType As String = ""
    Public Property Project_Name As String = ""
    Public Property PO_Number As String = ""
    Public Property PO_Status As String = ""
    Public Property PR_Status As String = ""

    Public Property Rrev As String = ""
    Public Property RProject As String = ""

    Public Property ItemDescription As String = ""
    Public Property RStatus As String = ""
    Public Property Mechanical As String = ""
    Public Property Structure_ As String = ""
    Public Property Piping As String = ""
    Public Property Process As String = ""
    Public Property CandI As String = ""
    Public Property Electrical As String = ""
    Public Property Quality As String = ""

    Public Shared Function GetDPMDLDB(ByVal DivisionID As String, ByVal DisciplineID As String, ByVal MonthId As Integer, ByVal YearId As String) As DBDiscipline
      If DivisionID = "" Then Return Nothing
      If DisciplineID = "CI" Then DisciplineID = "C&I"

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
        If (MonthId = 12) Then
          Sql = " Select count(*) from tdmisg140200 where t_resp in ('" & DisciplineID & "') AND t_pcod IN ('" & DivisionID & "') and t_acdt ='1970-01-01 00:00:00.000' and t_orgn='ISG' and (dateadd(n,330,t_bsfd)) <' " & YearId + 1 & "-" & 1 & "-01 00:00:00.000' and t_docn not like '%VEN%'"



        Else
        Sql = " Select count(*) from tdmisg140200 where t_resp in ('" & DisciplineID & "') AND t_pcod IN ('" & DivisionID & "') and t_acdt ='1970-01-01 00:00:00.000' and t_orgn='ISG' and (dateadd(n,330,t_bsfd)) <' " & YearId & "-" & MonthId + 1 & "-01 00:00:00.000' and t_docn not like '%VEN%'"

        End If
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
      If DisciplineID = "CI" Then DisciplineID = "C&I"
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

      If DisciplineID = "CI" Then DisciplineID = "C&I"

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


    Public Shared Function GetDIDMSPREDB(ByVal DivisionID As String, ByVal DisciplineID As String, ByVal MonthId As Integer, ByVal YearId As String) As DBDiscipline
      Dim PrjID As String = ""
      If DivisionID = "" Then Return Nothing
      If DisciplineID = "CI" Then DisciplineID = "C&I"
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




      Dim tdate As Date = Today
      Dim sdate As String = tdate
      sdate = sdate.Substring(6, 4) & "-" & sdate.Substring(3, 2) & "-" & sdate.Substring(0, 2)

      Dim Sql As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()

        Sql = "  select count(*)   "
        Sql &= "  from ( "
        Sql &= "Select rec.t_rcno As ReceiptID, "
        Sql &= "  (Case rec.t_stat "
        Sql &= " when 1 then 'Submitted' "
        Sql &= " when 2 then 'Document linked' "
        Sql &= " when 3 then 'Under Evaluation' "
        Sql &= " when 4 then 'Comments Submitted' "
        Sql &= " when 5 then 'Technically Cleared' "
        Sql &= " when 6 then 'Transmittal Issued' "
        Sql &= " when 7 then 'Superceded' "
        Sql &= " when 8 then 'Closed' end)as RStatus, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
        Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
        Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
				Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
        Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
        Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
        Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
        Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
        Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
        Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

        Sql &= " From tdmisg134200 As rec "

        Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
        Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
        Sql &= " Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
        Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
        Sql &= " And year(rec.t_date) in (" & YearId & ") And month(rec.t_date) in (" & MonthId & ") "
        Sql &= "  ) as tmp  "


        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.IDMSP_Total_Count = Cmd.ExecuteScalar
        End Using


        Sql = "  select count(*)   "
        Sql &= "  from ( "
        Sql &= "Select rec.t_rcno As ReceiptID, "
        Sql &= "  (Case rec.t_stat "
        Sql &= " when 1 then 'Submitted' "
        Sql &= " when 2 then 'Document linked' "
        Sql &= " when 3 then 'Under Evaluation' "
        Sql &= " when 4 then 'Comments Submitted' "
        Sql &= " when 5 then 'Technically Cleared' "
        Sql &= " when 6 then 'Transmittal Issued' "
        Sql &= " when 7 then 'Superceded' "
        Sql &= " when 8 then 'Closed' end)as RStatus, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
        Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
        Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
        Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
        Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
        Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
        Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
        Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
        Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
        Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

        Sql &= " From tdmisg134200 As rec "

        Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
        Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
        Sql &= " Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
        Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
        Sql &= " And year(rec.t_date) in (" & YearId & ") And month(rec.t_date) in (" & MonthId & ")  and rec.t_stat=1"
        Sql &= "  ) as tmp  "


        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.IDMSP_Submitted = Cmd.ExecuteScalar
        End Using

        Sql = "  select count(*)   "
        Sql &= "  from ( "
        Sql &= "Select rec.t_rcno As ReceiptID, "
        Sql &= "  (Case rec.t_stat "
        Sql &= " when 1 then 'Submitted' "
        Sql &= " when 2 then 'Document linked' "
        Sql &= " when 3 then 'Under Evaluation' "
        Sql &= " when 4 then 'Comments Submitted' "
        Sql &= " when 5 then 'Technically Cleared' "
        Sql &= " when 6 then 'Transmittal Issued' "
        Sql &= " when 7 then 'Superceded' "
        Sql &= " when 8 then 'Closed' end)as RStatus, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
        Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
        Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
        Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
        Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
        Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
        Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
        Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
        Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
        Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

        Sql &= " From tdmisg134200 As rec "

        Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
        Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
        Sql &= " Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
        Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
        Sql &= " And year(rec.t_date) in (" & YearId & ") And month(rec.t_date) in (" & MonthId & ")  and rec.t_stat=2"
        Sql &= "  ) as tmp  "


        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.IDMSP_Document_linked = Cmd.ExecuteScalar
        End Using


        Sql = "  select count(*)   "
        Sql &= "  from ( "
        Sql &= "Select rec.t_rcno As ReceiptID, "
        Sql &= "  (Case rec.t_stat "
        Sql &= " when 1 then 'Submitted' "
        Sql &= " when 2 then 'Document linked' "
        Sql &= " when 3 then 'Under Evaluation' "
        Sql &= " when 4 then 'Comments Submitted' "
        Sql &= " when 5 then 'Technically Cleared' "
        Sql &= " when 6 then 'Transmittal Issued' "
        Sql &= " when 7 then 'Superceded' "
        Sql &= " when 8 then 'Closed' end)as RStatus, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
        Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
        Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
        Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
        Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
        Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
        Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
        Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
        Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
        Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

        Sql &= " From tdmisg134200 As rec "

        Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
        Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
        Sql &= " Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
        Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
        Sql &= " And year(rec.t_date) in (" & YearId & ") And month(rec.t_date) in (" & MonthId & ")  and rec.t_stat=3"
        Sql &= "  ) as tmp  "


        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.IDMSP_Under_Evaluation = Cmd.ExecuteScalar
        End Using

        Sql = "  select count(*)   "
        Sql &= "  from ( "
        Sql &= "Select rec.t_rcno As ReceiptID, "
        Sql &= "  (Case rec.t_stat "
        Sql &= " when 1 then 'Submitted' "
        Sql &= " when 2 then 'Document linked' "
        Sql &= " when 3 then 'Under Evaluation' "
        Sql &= " when 4 then 'Comments Submitted' "
        Sql &= " when 5 then 'Technically Cleared' "
        Sql &= " when 6 then 'Transmittal Issued' "
        Sql &= " when 7 then 'Superceded' "
        Sql &= " when 8 then 'Closed' end)as RStatus, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
        Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
        Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
        Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
        Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
        Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
        Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
        Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
        Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
        Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

        Sql &= " From tdmisg134200 As rec "

        Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
        Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
        Sql &= " Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
        Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
        Sql &= " And year(rec.t_date) in (" & YearId & ") And month(rec.t_date) in (" & MonthId & ")  and rec.t_stat=4"
        Sql &= "  ) as tmp  "


        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.IDMSP_Comments_Submitted = Cmd.ExecuteScalar
        End Using

        Sql = "  select count(*)   "
        Sql &= "  from ( "
        Sql &= "Select rec.t_rcno As ReceiptID, "
        Sql &= "  (Case rec.t_stat "
        Sql &= " when 1 then 'Submitted' "
        Sql &= " when 2 then 'Document linked' "
        Sql &= " when 3 then 'Under Evaluation' "
        Sql &= " when 4 then 'Comments Submitted' "
        Sql &= " when 5 then 'Technically Cleared' "
        Sql &= " when 6 then 'Transmittal Issued' "
        Sql &= " when 7 then 'Superceded' "
        Sql &= " when 8 then 'Closed' end)as RStatus, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
        Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
        Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
        Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
        Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
        Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
        Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
        Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
        Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
        Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

        Sql &= " From tdmisg134200 As rec "

        Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
        Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
        Sql &= " Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
        Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
        Sql &= " And year(rec.t_date) in (" & YearId & ") And month(rec.t_date) in (" & MonthId & ")  and rec.t_stat=5"
        Sql &= "  ) as tmp  "


        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.IDMSP_Technically_Cleared = Cmd.ExecuteScalar
        End Using


        Sql = "  select count(*)   "
        Sql &= "  from ( "
        Sql &= "Select rec.t_rcno As ReceiptID, "
        Sql &= "  (Case rec.t_stat "
        Sql &= " when 1 then 'Submitted' "
        Sql &= " when 2 then 'Document linked' "
        Sql &= " when 3 then 'Under Evaluation' "
        Sql &= " when 4 then 'Comments Submitted' "
        Sql &= " when 5 then 'Technically Cleared' "
        Sql &= " when 6 then 'Transmittal Issued' "
        Sql &= " when 7 then 'Superceded' "
        Sql &= " when 8 then 'Closed' end)as RStatus, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
        Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
        Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
        Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
        Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
        Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
        Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
        Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
        Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
        Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

        Sql &= " From tdmisg134200 As rec "

        Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
        Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
        Sql &= " Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
        Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
        Sql &= " And year(rec.t_date) in (" & YearId & ") And month(rec.t_date) in (" & MonthId & ")  and rec.t_stat=5"
        Sql &= "  ) as tmp  "


        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.IDMSP_Technically_Cleared = Cmd.ExecuteScalar
        End Using

        Sql = "  select count(*)   "
        Sql &= "  from ( "
        Sql &= "Select rec.t_rcno As ReceiptID, "
        Sql &= "  (Case rec.t_stat "
        Sql &= " when 1 then 'Submitted' "
        Sql &= " when 2 then 'Document linked' "
        Sql &= " when 3 then 'Under Evaluation' "
        Sql &= " when 4 then 'Comments Submitted' "
        Sql &= " when 5 then 'Technically Cleared' "
        Sql &= " when 6 then 'Transmittal Issued' "
        Sql &= " when 7 then 'Superceded' "
        Sql &= " when 8 then 'Closed' end)as RStatus, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
        Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
        Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
        Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
        Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
        Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
        Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
        Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
        Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
        Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

        Sql &= " From tdmisg134200 As rec "

        Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
        Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
        Sql &= " Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
        Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
        Sql &= " And year(rec.t_date) in (" & YearId & ") And month(rec.t_date) in (" & MonthId & ")  and rec.t_stat=6"
        Sql &= "  ) as tmp  "


        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.IDMSP_Transmittal_Issued = Cmd.ExecuteScalar
        End Using

        Sql = "  select count(*)   "
        Sql &= "  from ( "
        Sql &= "Select rec.t_rcno As ReceiptID, "
        Sql &= "  (Case rec.t_stat "
        Sql &= " when 1 then 'Submitted' "
        Sql &= " when 2 then 'Document linked' "
        Sql &= " when 3 then 'Under Evaluation' "
        Sql &= " when 4 then 'Comments Submitted' "
        Sql &= " when 5 then 'Technically Cleared' "
        Sql &= " when 6 then 'Transmittal Issued' "
        Sql &= " when 7 then 'Superceded' "
        Sql &= " when 8 then 'Closed' end)as RStatus, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
        Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
        Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
        Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
        Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
        Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
        Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
        Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
        Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
        Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

        Sql &= " From tdmisg134200 As rec "

        Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
        Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
        Sql &= " Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
        Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
        Sql &= " And year(rec.t_date) in (" & YearId & ") And month(rec.t_date) in (" & MonthId & ")  and rec.t_stat=7"
        Sql &= "  ) as tmp  "


        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.IDMSP_Superceded = Cmd.ExecuteScalar
        End Using

        Sql = "  select count(*)   "
        Sql &= "  from ( "
        Sql &= "Select rec.t_rcno As ReceiptID, "
        Sql &= "  (Case rec.t_stat "
        Sql &= " when 1 then 'Submitted' "
        Sql &= " when 2 then 'Document linked' "
        Sql &= " when 3 then 'Under Evaluation' "
        Sql &= " when 4 then 'Comments Submitted' "
        Sql &= " when 5 then 'Technically Cleared' "
        Sql &= " when 6 then 'Transmittal Issued' "
        Sql &= " when 7 then 'Superceded' "
        Sql &= " when 8 then 'Closed' end)as RStatus, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
        Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
        Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
        Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
        Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
        Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
        Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
        Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
        Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
        Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

        Sql &= " From tdmisg134200 As rec "

        Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
        Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
        Sql &= " Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
        Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
        Sql &= " And year(rec.t_date) in (" & YearId & ") And month(rec.t_date) in (" & MonthId & ")  and rec.t_stat=8"
        Sql &= "  ) as tmp  "


        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.IDMSP_Closed = Cmd.ExecuteScalar
        End Using
        '--------------------------------

        Sql = "  select count(*)   "
        Sql &= "  from ( "
        Sql &= "Select rec.t_rcno As ReceiptID, "
        Sql &= "  (Case rec.t_stat "
        Sql &= " when 1 then 'Submitted' "
        Sql &= " when 2 then 'Document linked' "
        Sql &= " when 3 then 'Under Evaluation' "
        Sql &= " when 4 then 'Comments Submitted' "
        Sql &= " when 5 then 'Technically Cleared' "
        Sql &= " when 6 then 'Transmittal Issued' "
        Sql &= " when 7 then 'Superceded' "
        Sql &= " when 8 then 'Closed' end)as RStatus, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
        Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
        Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
        Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
        Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
        Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
        Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
        Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
        Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
        Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

        Sql &= " From tdmisg134200 As rec "

        Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
        Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
        Sql &= " Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
        Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "

        Sql &= "  ) as tmp  "


        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.All_IDMSP_Total_Count = Cmd.ExecuteScalar
        End Using


        Sql = "  select count(*)   "
        Sql &= "  from ( "
        Sql &= "Select rec.t_rcno As ReceiptID, "
        Sql &= "  (Case rec.t_stat "
        Sql &= " when 1 then 'Submitted' "
        Sql &= " when 2 then 'Document linked' "
        Sql &= " when 3 then 'Under Evaluation' "
        Sql &= " when 4 then 'Comments Submitted' "
        Sql &= " when 5 then 'Technically Cleared' "
        Sql &= " when 6 then 'Transmittal Issued' "
        Sql &= " when 7 then 'Superceded' "
        Sql &= " when 8 then 'Closed' end)as RStatus, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
        Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
        Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
        Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
        Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
        Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
        Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
        Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
        Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
        Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

        Sql &= " From tdmisg134200 As rec "

        Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
        Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
        Sql &= " Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
        Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
        Sql &= " and rec.t_stat=1"
        Sql &= "  ) as tmp  "


        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.All_IDMSP_Submitted = Cmd.ExecuteScalar
        End Using

        Sql = "  select count(*)   "
        Sql &= "  from ( "
        Sql &= "Select rec.t_rcno As ReceiptID, "
        Sql &= "  (Case rec.t_stat "
        Sql &= " when 1 then 'Submitted' "
        Sql &= " when 2 then 'Document linked' "
        Sql &= " when 3 then 'Under Evaluation' "
        Sql &= " when 4 then 'Comments Submitted' "
        Sql &= " when 5 then 'Technically Cleared' "
        Sql &= " when 6 then 'Transmittal Issued' "
        Sql &= " when 7 then 'Superceded' "
        Sql &= " when 8 then 'Closed' end)as RStatus, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
        Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
        Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
        Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
        Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
        Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
        Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
        Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
        Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
        Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

        Sql &= " From tdmisg134200 As rec "

        Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
        Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
        Sql &= " Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
        Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
        Sql &= " and rec.t_stat=2"
        Sql &= "  ) as tmp  "


        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.All_IDMSP_Document_linked = Cmd.ExecuteScalar
        End Using


        Sql = "  select count(*)   "
        Sql &= "  from ( "
        Sql &= "Select rec.t_rcno As ReceiptID, "
        Sql &= "  (Case rec.t_stat "
        Sql &= " when 1 then 'Submitted' "
        Sql &= " when 2 then 'Document linked' "
        Sql &= " when 3 then 'Under Evaluation' "
        Sql &= " when 4 then 'Comments Submitted' "
        Sql &= " when 5 then 'Technically Cleared' "
        Sql &= " when 6 then 'Transmittal Issued' "
        Sql &= " when 7 then 'Superceded' "
        Sql &= " when 8 then 'Closed' end)as RStatus, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
        Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
        Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
        Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
        Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
        Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
        Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
        Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
        Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
        Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

        Sql &= " From tdmisg134200 As rec "

        Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
        Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
        Sql &= " Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
        Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
        Sql &= " and rec.t_stat=3"
        Sql &= "  ) as tmp  "


        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.All_IDMSP_Under_Evaluation = Cmd.ExecuteScalar
        End Using

        Sql = "  select count(*)   "
        Sql &= "  from ( "
        Sql &= "Select rec.t_rcno As ReceiptID, "
        Sql &= "  (Case rec.t_stat "
        Sql &= " when 1 then 'Submitted' "
        Sql &= " when 2 then 'Document linked' "
        Sql &= " when 3 then 'Under Evaluation' "
        Sql &= " when 4 then 'Comments Submitted' "
        Sql &= " when 5 then 'Technically Cleared' "
        Sql &= " when 6 then 'Transmittal Issued' "
        Sql &= " when 7 then 'Superceded' "
        Sql &= " when 8 then 'Closed' end)as RStatus, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
        Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
        Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
        Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
        Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
        Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
        Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
        Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
        Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
        Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

        Sql &= " From tdmisg134200 As rec "

        Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
        Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
        Sql &= " Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
        Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
        Sql &= " and rec.t_stat=4"
        Sql &= "  ) as tmp  "


        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.All_IDMSP_Comments_Submitted = Cmd.ExecuteScalar
        End Using

        Sql = "  select count(*)   "
        Sql &= "  from ( "
        Sql &= "Select rec.t_rcno As ReceiptID, "
        Sql &= "  (Case rec.t_stat "
        Sql &= " when 1 then 'Submitted' "
        Sql &= " when 2 then 'Document linked' "
        Sql &= " when 3 then 'Under Evaluation' "
        Sql &= " when 4 then 'Comments Submitted' "
        Sql &= " when 5 then 'Technically Cleared' "
        Sql &= " when 6 then 'Transmittal Issued' "
        Sql &= " when 7 then 'Superceded' "
        Sql &= " when 8 then 'Closed' end)as RStatus, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
        Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
        Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
        Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
        Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
        Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
        Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
        Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
        Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
        Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

        Sql &= " From tdmisg134200 As rec "

        Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
        Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
        Sql &= " Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
        Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
        Sql &= " and rec.t_stat=5"
        Sql &= "  ) as tmp  "


        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.All_IDMSP_Technically_Cleared = Cmd.ExecuteScalar
        End Using


        Sql = "  select count(*)   "
        Sql &= "  from ( "
        Sql &= "Select rec.t_rcno As ReceiptID, "
        Sql &= "  (Case rec.t_stat "
        Sql &= " when 1 then 'Submitted' "
        Sql &= " when 2 then 'Document linked' "
        Sql &= " when 3 then 'Under Evaluation' "
        Sql &= " when 4 then 'Comments Submitted' "
        Sql &= " when 5 then 'Technically Cleared' "
        Sql &= " when 6 then 'Transmittal Issued' "
        Sql &= " when 7 then 'Superceded' "
        Sql &= " when 8 then 'Closed' end)as RStatus, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
        Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
        Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
        Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
        Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
        Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
        Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
        Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
        Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
        Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

        Sql &= " From tdmisg134200 As rec "

        Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
        Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
        Sql &= " Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
        Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
        Sql &= " and rec.t_stat=5"
        Sql &= "  ) as tmp  "


        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.All_IDMSP_Technically_Cleared = Cmd.ExecuteScalar
        End Using

        Sql = "  select count(*)   "
        Sql &= "  from ( "
        Sql &= "Select rec.t_rcno As ReceiptID, "
        Sql &= "  (Case rec.t_stat "
        Sql &= " when 1 then 'Submitted' "
        Sql &= " when 2 then 'Document linked' "
        Sql &= " when 3 then 'Under Evaluation' "
        Sql &= " when 4 then 'Comments Submitted' "
        Sql &= " when 5 then 'Technically Cleared' "
        Sql &= " when 6 then 'Transmittal Issued' "
        Sql &= " when 7 then 'Superceded' "
        Sql &= " when 8 then 'Closed' end)as RStatus, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
        Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
        Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
        Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
        Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
        Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
        Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
        Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
        Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
        Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

        Sql &= " From tdmisg134200 As rec "

        Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
        Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
        Sql &= " Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
        Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
        Sql &= " and rec.t_stat=6"
        Sql &= "  ) as tmp  "


        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.All_IDMSP_Transmittal_Issued = Cmd.ExecuteScalar
        End Using

        Sql = "  select count(*)   "
        Sql &= "  from ( "
        Sql &= "Select rec.t_rcno As ReceiptID, "
        Sql &= "  (Case rec.t_stat "
        Sql &= " when 1 then 'Submitted' "
        Sql &= " when 2 then 'Document linked' "
        Sql &= " when 3 then 'Under Evaluation' "
        Sql &= " when 4 then 'Comments Submitted' "
        Sql &= " when 5 then 'Technically Cleared' "
        Sql &= " when 6 then 'Transmittal Issued' "
        Sql &= " when 7 then 'Superceded' "
        Sql &= " when 8 then 'Closed' end)as RStatus, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
        Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
        Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
        Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
        Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
        Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
        Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
        Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
        Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
        Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

        Sql &= " From tdmisg134200 As rec "

        Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
        Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
        Sql &= " Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
        Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
        Sql &= "  and rec.t_stat=7"
        Sql &= "  ) as tmp  "


        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.All_IDMSP_Superceded = Cmd.ExecuteScalar
        End Using

        Sql = "  select count(*)   "
        Sql &= "  from ( "
        Sql &= "Select rec.t_rcno As ReceiptID, "
        Sql &= "  (Case rec.t_stat "
        Sql &= " when 1 then 'Submitted' "
        Sql &= " when 2 then 'Document linked' "
        Sql &= " when 3 then 'Under Evaluation' "
        Sql &= " when 4 then 'Comments Submitted' "
        Sql &= " when 5 then 'Technically Cleared' "
        Sql &= " when 6 then 'Transmittal Issued' "
        Sql &= " when 7 then 'Superceded' "
        Sql &= " when 8 then 'Closed' end)as RStatus, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
        Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
        Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
        Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
        Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
        Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
        Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
        Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
        Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
        Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

        Sql &= " From tdmisg134200 As rec "

        Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
        Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
        Sql &= " Where rec.t_rcno Like ('REC%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
        Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
        Sql &= " and rec.t_stat=8"
        Sql &= "  ) as tmp  "


        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.All_IDMSP_Closed = Cmd.ExecuteScalar
        End Using

      End Using

      Return mRet
    End Function

    Public Shared Function GetDIDMSPOSTDB(ByVal DivisionID As String, ByVal DisciplineID As String, ByVal MonthId As Integer, ByVal YearId As String) As DBDiscipline
      Dim PrjID As String = ""
      If DivisionID = "" Then Return Nothing
      If DisciplineID = "CI" Then DisciplineID = "C&I"
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




      Dim tdate As Date = Today
      Dim sdate As String = tdate
      sdate = sdate.Substring(6, 4) & "-" & sdate.Substring(3, 2) & "-" & sdate.Substring(0, 2)

      Dim Sql As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()

        Sql = "  select count(*)   "
        Sql &= "  from ( "
        Sql &= "Select rec.t_rcno As ReceiptID, "
        Sql &= "  (Case rec.t_stat "
        Sql &= " when 1 then 'Submitted' "
        Sql &= " when 2 then 'Document linked' "
        Sql &= " when 3 then 'Under Evaluation' "
        Sql &= " when 4 then 'Comments Submitted' "
        Sql &= " when 5 then 'Technically Cleared' "
        Sql &= " when 6 then 'Transmittal Issued' "
        Sql &= " when 7 then 'Superceded' "
        Sql &= " when 8 then 'Closed' end)as RStatus, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
        Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
        Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
        Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
        Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
        Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
        Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
        Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
        Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
        Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

        Sql &= " From tdmisg134200 As rec "

        Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
        Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
        Sql &= " Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
        Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
        Sql &= " And year(rec.t_date) in (" & YearId & ") And month(rec.t_date) in (" & MonthId & ") "
        Sql &= "  ) as tmp  "


        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.IDMSPO_Total_Count = Cmd.ExecuteScalar
        End Using


        Sql = "  select count(*)   "
        Sql &= "  from ( "
        Sql &= "Select rec.t_rcno As ReceiptID, "
        Sql &= "  (Case rec.t_stat "
        Sql &= " when 1 then 'Submitted' "
        Sql &= " when 2 then 'Document linked' "
        Sql &= " when 3 then 'Under Evaluation' "
        Sql &= " when 4 then 'Comments Submitted' "
        Sql &= " when 5 then 'Technically Cleared' "
        Sql &= " when 6 then 'Transmittal Issued' "
        Sql &= " when 7 then 'Superceded' "
        Sql &= " when 8 then 'Closed' end)as RStatus, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
        Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
        Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
        Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
        Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
        Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
        Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
        Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
        Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
        Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

        Sql &= " From tdmisg134200 As rec "

        Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
        Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
        Sql &= " Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
        Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
        Sql &= " And year(rec.t_date) in (" & YearId & ") And month(rec.t_date) in (" & MonthId & ")  and rec.t_stat=1"
        Sql &= "  ) as tmp  "


        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.IDMSPO_Submitted = Cmd.ExecuteScalar
        End Using

        Sql = "  select count(*)   "
        Sql &= "  from ( "
        Sql &= "Select rec.t_rcno As ReceiptID, "
        Sql &= "  (Case rec.t_stat "
        Sql &= " when 1 then 'Submitted' "
        Sql &= " when 2 then 'Document linked' "
        Sql &= " when 3 then 'Under Evaluation' "
        Sql &= " when 4 then 'Comments Submitted' "
        Sql &= " when 5 then 'Technically Cleared' "
        Sql &= " when 6 then 'Transmittal Issued' "
        Sql &= " when 7 then 'Superceded' "
        Sql &= " when 8 then 'Closed' end)as RStatus, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
        Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
        Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
        Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
        Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
        Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
        Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
        Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
        Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
        Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

        Sql &= " From tdmisg134200 As rec "

        Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
        Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
        Sql &= " Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
        Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
        Sql &= " And year(rec.t_date) in (" & YearId & ") And month(rec.t_date) in (" & MonthId & ")  and rec.t_stat=2"
        Sql &= "  ) as tmp  "


        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.IDMSPO_Document_linked = Cmd.ExecuteScalar
        End Using


        Sql = "  select count(*)   "
        Sql &= "  from ( "
        Sql &= "Select rec.t_rcno As ReceiptID, "
        Sql &= "  (Case rec.t_stat "
        Sql &= " when 1 then 'Submitted' "
        Sql &= " when 2 then 'Document linked' "
        Sql &= " when 3 then 'Under Evaluation' "
        Sql &= " when 4 then 'Comments Submitted' "
        Sql &= " when 5 then 'Technically Cleared' "
        Sql &= " when 6 then 'Transmittal Issued' "
        Sql &= " when 7 then 'Superceded' "
        Sql &= " when 8 then 'Closed' end)as RStatus, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
        Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
        Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
        Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
        Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
        Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
        Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
        Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
        Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
        Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

        Sql &= " From tdmisg134200 As rec "

        Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
        Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
        Sql &= " Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
        Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
        Sql &= " And year(rec.t_date) in (" & YearId & ") And month(rec.t_date) in (" & MonthId & ")  and rec.t_stat=3"
        Sql &= "  ) as tmp  "


        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.IDMSPO_Under_Evaluation = Cmd.ExecuteScalar
        End Using

        Sql = "  select count(*)   "
        Sql &= "  from ( "
        Sql &= "Select rec.t_rcno As ReceiptID, "
        Sql &= "  (Case rec.t_stat "
        Sql &= " when 1 then 'Submitted' "
        Sql &= " when 2 then 'Document linked' "
        Sql &= " when 3 then 'Under Evaluation' "
        Sql &= " when 4 then 'Comments Submitted' "
        Sql &= " when 5 then 'Technically Cleared' "
        Sql &= " when 6 then 'Transmittal Issued' "
        Sql &= " when 7 then 'Superceded' "
        Sql &= " when 8 then 'Closed' end)as RStatus, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
        Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
        Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
        Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
        Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
        Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
        Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
        Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
        Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
        Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

        Sql &= " From tdmisg134200 As rec "

        Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
        Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
        Sql &= " Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
        Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
        Sql &= " And year(rec.t_date) in (" & YearId & ") And month(rec.t_date) in (" & MonthId & ")  and rec.t_stat=4"
        Sql &= "  ) as tmp  "


        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.IDMSPO_Comments_Submitted = Cmd.ExecuteScalar
        End Using

        Sql = "  select count(*)   "
        Sql &= "  from ( "
        Sql &= "Select rec.t_rcno As ReceiptID, "
        Sql &= "  (Case rec.t_stat "
        Sql &= " when 1 then 'Submitted' "
        Sql &= " when 2 then 'Document linked' "
        Sql &= " when 3 then 'Under Evaluation' "
        Sql &= " when 4 then 'Comments Submitted' "
        Sql &= " when 5 then 'Technically Cleared' "
        Sql &= " when 6 then 'Transmittal Issued' "
        Sql &= " when 7 then 'Superceded' "
        Sql &= " when 8 then 'Closed' end)as RStatus, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
        Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
        Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
        Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
        Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
        Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
        Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
        Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
        Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
        Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

        Sql &= " From tdmisg134200 As rec "

        Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
        Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
        Sql &= " Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
        Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
        Sql &= " And year(rec.t_date) in (" & YearId & ") And month(rec.t_date) in (" & MonthId & ")  and rec.t_stat=5"
        Sql &= "  ) as tmp  "


        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.IDMSPO_Technically_Cleared = Cmd.ExecuteScalar
        End Using


        Sql = "  select count(*)   "
        Sql &= "  from ( "
        Sql &= "Select rec.t_rcno As ReceiptID, "
        Sql &= "  (Case rec.t_stat "
        Sql &= " when 1 then 'Submitted' "
        Sql &= " when 2 then 'Document linked' "
        Sql &= " when 3 then 'Under Evaluation' "
        Sql &= " when 4 then 'Comments Submitted' "
        Sql &= " when 5 then 'Technically Cleared' "
        Sql &= " when 6 then 'Transmittal Issued' "
        Sql &= " when 7 then 'Superceded' "
        Sql &= " when 8 then 'Closed' end)as RStatus, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
        Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
        Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
        Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
        Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
        Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
        Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
        Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
        Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
        Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

        Sql &= " From tdmisg134200 As rec "

        Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
        Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
        Sql &= " Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
        Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
        Sql &= " And year(rec.t_date) in (" & YearId & ") And month(rec.t_date) in (" & MonthId & ")  and rec.t_stat=5"
        Sql &= "  ) as tmp  "


        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.IDMSPO_Technically_Cleared = Cmd.ExecuteScalar
        End Using

        Sql = "  select count(*)   "
        Sql &= "  from ( "
        Sql &= "Select rec.t_rcno As ReceiptID, "
        Sql &= "  (Case rec.t_stat "
        Sql &= " when 1 then 'Submitted' "
        Sql &= " when 2 then 'Document linked' "
        Sql &= " when 3 then 'Under Evaluation' "
        Sql &= " when 4 then 'Comments Submitted' "
        Sql &= " when 5 then 'Technically Cleared' "
        Sql &= " when 6 then 'Transmittal Issued' "
        Sql &= " when 7 then 'Superceded' "
        Sql &= " when 8 then 'Closed' end)as RStatus, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
        Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
        Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
        Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
        Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
        Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
        Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
        Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
        Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
        Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

        Sql &= " From tdmisg134200 As rec "

        Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
        Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
        Sql &= " Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
        Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
        Sql &= " And year(rec.t_date) in (" & YearId & ") And month(rec.t_date) in (" & MonthId & ")  and rec.t_stat=6"
        Sql &= "  ) as tmp  "


        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.IDMSPO_Transmittal_Issued = Cmd.ExecuteScalar
        End Using

        Sql = "  select count(*)   "
        Sql &= "  from ( "
        Sql &= "Select rec.t_rcno As ReceiptID, "
        Sql &= "  (Case rec.t_stat "
        Sql &= " when 1 then 'Submitted' "
        Sql &= " when 2 then 'Document linked' "
        Sql &= " when 3 then 'Under Evaluation' "
        Sql &= " when 4 then 'Comments Submitted' "
        Sql &= " when 5 then 'Technically Cleared' "
        Sql &= " when 6 then 'Transmittal Issued' "
        Sql &= " when 7 then 'Superceded' "
        Sql &= " when 8 then 'Closed' end)as RStatus, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
        Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
        Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
        Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
        Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
        Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
        Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
        Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
        Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
        Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

        Sql &= " From tdmisg134200 As rec "

        Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
        Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
        Sql &= " Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
        Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
        Sql &= " And year(rec.t_date) in (" & YearId & ") And month(rec.t_date) in (" & MonthId & ")  and rec.t_stat=7"
        Sql &= "  ) as tmp  "


        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.IDMSPO_Superceded = Cmd.ExecuteScalar
        End Using

        Sql = "  select count(*)   "
        Sql &= "  from ( "
        Sql &= "Select rec.t_rcno As ReceiptID, "
        Sql &= "  (Case rec.t_stat "
        Sql &= " when 1 then 'Submitted' "
        Sql &= " when 2 then 'Document linked' "
        Sql &= " when 3 then 'Under Evaluation' "
        Sql &= " when 4 then 'Comments Submitted' "
        Sql &= " when 5 then 'Technically Cleared' "
        Sql &= " when 6 then 'Transmittal Issued' "
        Sql &= " when 7 then 'Superceded' "
        Sql &= " when 8 then 'Closed' end)as RStatus, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
        Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
        Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
        Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
        Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
        Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
        Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
        Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
        Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
        Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

        Sql &= " From tdmisg134200 As rec "

        Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
        Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
        Sql &= " Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
        Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
        Sql &= " And year(rec.t_date) in (" & YearId & ") And month(rec.t_date) in (" & MonthId & ")  and rec.t_stat=8"
        Sql &= "  ) as tmp  "


        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.IDMSPO_Closed = Cmd.ExecuteScalar
        End Using
        '--------------------------------

        Sql = "  select count(*)   "
        Sql &= "  from ( "
        Sql &= "Select rec.t_rcno As ReceiptID, "
        Sql &= "  (Case rec.t_stat "
        Sql &= " when 1 then 'Submitted' "
        Sql &= " when 2 then 'Document linked' "
        Sql &= " when 3 then 'Under Evaluation' "
        Sql &= " when 4 then 'Comments Submitted' "
        Sql &= " when 5 then 'Technically Cleared' "
        Sql &= " when 6 then 'Transmittal Issued' "
        Sql &= " when 7 then 'Superceded' "
        Sql &= " when 8 then 'Closed' end)as RStatus, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
        Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
        Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
        Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
        Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
        Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
        Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
        Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
        Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
        Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

        Sql &= " From tdmisg134200 As rec "

        Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
        Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
        Sql &= " Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
        Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "

        Sql &= "  ) as tmp  "


        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.All_IDMSPO_Total_Count = Cmd.ExecuteScalar
        End Using


        Sql = "  select count(*)   "
        Sql &= "  from ( "
        Sql &= "Select rec.t_rcno As ReceiptID, "
        Sql &= "  (Case rec.t_stat "
        Sql &= " when 1 then 'Submitted' "
        Sql &= " when 2 then 'Document linked' "
        Sql &= " when 3 then 'Under Evaluation' "
        Sql &= " when 4 then 'Comments Submitted' "
        Sql &= " when 5 then 'Technically Cleared' "
        Sql &= " when 6 then 'Transmittal Issued' "
        Sql &= " when 7 then 'Superceded' "
        Sql &= " when 8 then 'Closed' end)as RStatus, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
        Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
        Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
        Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
        Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
        Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
        Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
        Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
        Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
        Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

        Sql &= " From tdmisg134200 As rec "

        Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
        Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
        Sql &= " Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
        Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
        Sql &= " and rec.t_stat=1"
        Sql &= "  ) as tmp  "


        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.All_IDMSPo_Submitted = Cmd.ExecuteScalar
        End Using

        Sql = "  select count(*)   "
        Sql &= "  from ( "
        Sql &= "Select rec.t_rcno As ReceiptID, "
        Sql &= "  (Case rec.t_stat "
        Sql &= " when 1 then 'Submitted' "
        Sql &= " when 2 then 'Document linked' "
        Sql &= " when 3 then 'Under Evaluation' "
        Sql &= " when 4 then 'Comments Submitted' "
        Sql &= " when 5 then 'Technically Cleared' "
        Sql &= " when 6 then 'Transmittal Issued' "
        Sql &= " when 7 then 'Superceded' "
        Sql &= " when 8 then 'Closed' end)as RStatus, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
        Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
        Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
        Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
        Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
        Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
        Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
        Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
        Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
        Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

        Sql &= " From tdmisg134200 As rec "

        Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
        Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
        Sql &= " Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
        Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
        Sql &= " and rec.t_stat=2"
        Sql &= "  ) as tmp  "


        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.All_IDMSPo_Document_linked = Cmd.ExecuteScalar
        End Using


        Sql = "  select count(*)   "
        Sql &= "  from ( "
        Sql &= "Select rec.t_rcno As ReceiptID, "
        Sql &= "  (Case rec.t_stat "
        Sql &= " when 1 then 'Submitted' "
        Sql &= " when 2 then 'Document linked' "
        Sql &= " when 3 then 'Under Evaluation' "
        Sql &= " when 4 then 'Comments Submitted' "
        Sql &= " when 5 then 'Technically Cleared' "
        Sql &= " when 6 then 'Transmittal Issued' "
        Sql &= " when 7 then 'Superceded' "
        Sql &= " when 8 then 'Closed' end)as RStatus, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
        Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
        Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
        Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
        Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
        Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
        Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
        Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
        Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
        Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

        Sql &= " From tdmisg134200 As rec "

        Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
        Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
        Sql &= " Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
        Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
        Sql &= " and rec.t_stat=3"
        Sql &= "  ) as tmp  "


        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.All_IDMSPo_Under_Evaluation = Cmd.ExecuteScalar
        End Using

        Sql = "  select count(*)   "
        Sql &= "  from ( "
        Sql &= "Select rec.t_rcno As ReceiptID, "
        Sql &= "  (Case rec.t_stat "
        Sql &= " when 1 then 'Submitted' "
        Sql &= " when 2 then 'Document linked' "
        Sql &= " when 3 then 'Under Evaluation' "
        Sql &= " when 4 then 'Comments Submitted' "
        Sql &= " when 5 then 'Technically Cleared' "
        Sql &= " when 6 then 'Transmittal Issued' "
        Sql &= " when 7 then 'Superceded' "
        Sql &= " when 8 then 'Closed' end)as RStatus, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
        Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
        Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
        Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
        Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
        Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
        Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
        Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
        Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
        Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

        Sql &= " From tdmisg134200 As rec "

        Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
        Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
        Sql &= " Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
        Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
        Sql &= " and rec.t_stat=4"
        Sql &= "  ) as tmp  "


        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.All_IDMSPo_Comments_Submitted = Cmd.ExecuteScalar
        End Using

        Sql = "  select count(*)   "
        Sql &= "  from ( "
        Sql &= "Select rec.t_rcno As ReceiptID, "
        Sql &= "  (Case rec.t_stat "
        Sql &= " when 1 then 'Submitted' "
        Sql &= " when 2 then 'Document linked' "
        Sql &= " when 3 then 'Under Evaluation' "
        Sql &= " when 4 then 'Comments Submitted' "
        Sql &= " when 5 then 'Technically Cleared' "
        Sql &= " when 6 then 'Transmittal Issued' "
        Sql &= " when 7 then 'Superceded' "
        Sql &= " when 8 then 'Closed' end)as RStatus, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
        Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
        Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
        Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
        Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
        Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
        Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
        Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
        Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
        Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

        Sql &= " From tdmisg134200 As rec "

        Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
        Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
        Sql &= " Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
        Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
        Sql &= " and rec.t_stat=5"
        Sql &= "  ) as tmp  "


        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.All_IDMSPo_Technically_Cleared = Cmd.ExecuteScalar
        End Using


        Sql = "  select count(*)   "
        Sql &= "  from ( "
        Sql &= "Select rec.t_rcno As ReceiptID, "
        Sql &= "  (Case rec.t_stat "
        Sql &= " when 1 then 'Submitted' "
        Sql &= " when 2 then 'Document linked' "
        Sql &= " when 3 then 'Under Evaluation' "
        Sql &= " when 4 then 'Comments Submitted' "
        Sql &= " when 5 then 'Technically Cleared' "
        Sql &= " when 6 then 'Transmittal Issued' "
        Sql &= " when 7 then 'Superceded' "
        Sql &= " when 8 then 'Closed' end)as RStatus, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
        Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
        Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
        Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
        Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
        Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
        Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
        Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
        Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
        Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

        Sql &= " From tdmisg134200 As rec "

        Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
        Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
        Sql &= " Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
        Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
        Sql &= " and rec.t_stat=5"
        Sql &= "  ) as tmp  "


        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.All_IDMSPo_Technically_Cleared = Cmd.ExecuteScalar
        End Using

        Sql = "  select count(*)   "
        Sql &= "  from ( "
        Sql &= "Select rec.t_rcno As ReceiptID, "
        Sql &= "  (Case rec.t_stat "
        Sql &= " when 1 then 'Submitted' "
        Sql &= " when 2 then 'Document linked' "
        Sql &= " when 3 then 'Under Evaluation' "
        Sql &= " when 4 then 'Comments Submitted' "
        Sql &= " when 5 then 'Technically Cleared' "
        Sql &= " when 6 then 'Transmittal Issued' "
        Sql &= " when 7 then 'Superceded' "
        Sql &= " when 8 then 'Closed' end)as RStatus, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
        Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
        Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
        Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
        Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
        Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
        Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
        Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
        Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
        Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

        Sql &= " From tdmisg134200 As rec "

        Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
        Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
        Sql &= " Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
        Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
        Sql &= " and rec.t_stat=6"
        Sql &= "  ) as tmp  "


        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.All_IDMSPo_Transmittal_Issued = Cmd.ExecuteScalar
        End Using

        Sql = "  select count(*)   "
        Sql &= "  from ( "
        Sql &= "Select rec.t_rcno As ReceiptID, "
        Sql &= "  (Case rec.t_stat "
        Sql &= " when 1 then 'Submitted' "
        Sql &= " when 2 then 'Document linked' "
        Sql &= " when 3 then 'Under Evaluation' "
        Sql &= " when 4 then 'Comments Submitted' "
        Sql &= " when 5 then 'Technically Cleared' "
        Sql &= " when 6 then 'Transmittal Issued' "
        Sql &= " when 7 then 'Superceded' "
        Sql &= " when 8 then 'Closed' end)as RStatus, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
        Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
        Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
        Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
        Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
        Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
        Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
        Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
        Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
        Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

        Sql &= " From tdmisg134200 As rec "

        Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
        Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
        Sql &= " Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
        Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
        Sql &= "  and rec.t_stat=7"
        Sql &= "  ) as tmp  "


        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.All_IDMSPo_Superceded = Cmd.ExecuteScalar
        End Using

        Sql = "  select count(*)   "
        Sql &= "  from ( "
        Sql &= "Select rec.t_rcno As ReceiptID, "
        Sql &= "  (Case rec.t_stat "
        Sql &= " when 1 then 'Submitted' "
        Sql &= " when 2 then 'Document linked' "
        Sql &= " when 3 then 'Under Evaluation' "
        Sql &= " when 4 then 'Comments Submitted' "
        Sql &= " when 5 then 'Technically Cleared' "
        Sql &= " when 6 then 'Transmittal Issued' "
        Sql &= " when 7 then 'Superceded' "
        Sql &= " when 8 then 'Closed' end)as RStatus, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_date), 103) As ReceiptDate, "
        Sql &= " Convert(nvarchar(10), DateAdd(n, 330, rec.t_sdat), 103) As SentDate, "
        Sql &= " DateDiff(DD, DateAdd(n, 330, DateAdd(n, 330, rec.t_sdat)), getdate()) As Rageindays,rec.t_revn As Rrev, rec.t_cprj As RProject, "
        Sql &= " Left(LTrim(rec.t_item), 8) As Relement,ttcibd001200.t_dsca As ItemDescription, "
        Sql &= " (case rec.t_sent_1   when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=1) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=1)end)  when 2 then '-'   end ) as Mechanical, "
        Sql &= " (case rec.t_sent_2  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=2) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=2)end) when 2 then '-'   end ) as Structure, "
        Sql &= " (case rec.t_sent_3  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=3) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=3)end) when 2 then '-'   end ) as Piping, "
        Sql &= " (case rec.t_sent_4  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=4) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=4)end) when 2 then '-'   end ) as Process, "
        Sql &= " (case rec.t_sent_5  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=5) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=5)end) when 2 then '-'   end ) as CandI, "
        Sql &= " (case rec.t_sent_6  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=6) When '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=6)end) when 2 then '-'   end ) as Electrical, "
        Sql &= " (case rec.t_sent_7  when 1 then (case (select t_sudt from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno And rec.t_revn=rep.t_revn And rep.t_engi=7) when '1970-01-01 00:00:00.000' then 'Pending' else (select convert(nvarchar(10),t_sudt,103)  from tdmisg136200 as rep where rec.t_rcno=rep.t_rcno and rec.t_revn=rep.t_revn and rep.t_engi=7)end) when 2 then '-'   end ) as Quality "

        Sql &= " From tdmisg134200 As rec "

        Sql &= " Left Join ttppdm090200 on ttppdm090200.t_cspa= LEFT(Ltrim(rec.t_item),8) "
        Sql &= " Left Join ttcibd001200  On ttcibd001200.t_item = rec.t_item "
        Sql &= " Where rec.t_rcno Like ('REP%') and ttppdm090200.t_sort In ('" & DisciplineID & "') "
        Sql &= " And substring(rec.t_cprj, 1, 2) in ('" & PrjID & "') "
        Sql &= " and rec.t_stat=8"
        Sql &= "  ) as tmp  "


        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          mRet.All_IDMSPo_Closed = Cmd.ExecuteScalar
        End Using

      End Using

      Return mRet
    End Function


  End Class
End Namespace
