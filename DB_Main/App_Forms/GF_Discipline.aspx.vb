Partial Class GF_Discipline

  Inherits System.Web.UI.Page

  Public Property DivisionID As String
    Get
      If ViewState("DivisionID") IsNot Nothing Then
        Return ViewState("DivisionID")
      End If
      Return ""
    End Get
    Set(value As String)

      ViewState.Add("DivisionID", value)
    End Set
  End Property

  Public Property DisciplineID As String
    Get
      If ViewState("DisciplineID") IsNot Nothing Then
        Return ViewState("DisciplineID")
      End If
      Return ""
    End Get
    Set(value As String)

      ViewState.Add("DisciplineID", value)
    End Set
  End Property

  Public Property YearID As Integer
    Get
      If ViewState("YearID") IsNot Nothing Then
        Return ViewState("YearID")
      End If
      Return YearID
    End Get
    Set(value As Integer)

      ViewState.Add("YearID", value)
    End Set
  End Property

  Public Property MonthID As Integer
    Get
      If ViewState("MonthID") IsNot Nothing Then
        Return ViewState("MonthID")
      End If
      Return MonthID
    End Get
    Set(value As Integer)

      ViewState.Add("MonthID", value)
    End Set
  End Property

  Private Sub GF_Discipline_Load(sender As Object, e As EventArgs) Handles Me.Load
    If Not Page.IsPostBack And Not Page.IsCallback Then
      F_MonthID.SelectedIndex = DateTime.Now.Month - 1

    End If

    DivisionID = Convert.ToString(F_DivisionID.SelectedItem.Text)
    DisciplineID = Convert.ToString(F_DisciplineID.SelectedItem.Text)

    F_DivisionID.Text = DivisionID
    F_DisciplineID.Text = DisciplineID

    Select Case DisciplineID

      Case "PROCESS"
        DisciplineID = "PRC"
      Case "MECHANICAL"
        DisciplineID = "MEC"
      Case "STRUCTURE"
        DisciplineID = "STR"
      Case "PIPING"
        DisciplineID = "PIP"
      Case "ELECTRICAL"
        DisciplineID = "ELE"
      Case "INSTRUMENTATION"
        DisciplineID = "CI"
      Case "CIVIL"
        DisciplineID = "CVL"
      Case "MATERIAL HANDLING"
        DisciplineID = "MHE"
      Case "PROJECT"
        DisciplineID = "PRJ"
      Case "WWS"
        DisciplineID = "WWS"

    End Select

    Btn_Discipline.Text = DivisionID + "-" + DisciplineID

    '  pd.Text = y.ProjectDesc


    If DivisionID = "" Then Exit Sub
    If DisciplineID = "" Then Exit Sub
  End Sub

  Private Sub cmdSubmit_Click(sender As Object, e As EventArgs) Handles cmdSubmit.Click


    MonthID = F_MonthID.SelectedIndex + 1
    YearID = Convert.ToInt32(F_YearID.SelectedItem.Text)

    DPMDLTABLE.Visible = True
    Btn_Discipline.Text = DivisionID + "-" + DisciplineID + "-" + F_YearID.SelectedItem.Text + "-" + F_MonthID.SelectedItem.Text
    Btn_Discipline.Font.Name = "Comic Sans MS"

    DSARTABLE.Visible = True
    Btn_Discipline1.Text = DivisionID + "-" + DisciplineID + "-" + F_YearID.SelectedItem.Text + "-" + F_MonthID.SelectedItem.Text
    Btn_Discipline1.Font.Name = "Comic Sans MS"

    DELEMENTTABLE.Visible = True
    Btn_Discipline2.Text = "Over All"
    Btn_Discipline2.Font.Name = "Comic Sans MS"

    DIDMSPRETABLE.Visible = True
    DIDMSPRETABLE1.Visible = True
    DIDMSPOSTTABLE.Visible = True
    DIDMSPOSTTABLE1.Visible = True

    Btn_Discipline3.Text = DivisionID + "-" + DisciplineID + "-" + F_YearID.SelectedItem.Text + "-" + F_MonthID.SelectedItem.Text
    Btn_Discipline3.Font.Name = "Comic Sans MS"

    Btn_Discipline4.Text = "Over All"
    Btn_Discipline4.Font.Name = "Comic Sans MS"

    Btn_Discipline5.Text = DivisionID + "-" + DisciplineID + "-" + F_YearID.SelectedItem.Text + "-" + F_MonthID.SelectedItem.Text
    Btn_Discipline5.Font.Name = "Comic Sans MS"

    Btn_Discipline6.Text = "Over All"
    Btn_Discipline6.Font.Name = "Comic Sans MS"

    'DIDMSPOSTTABLE.Visible = True
    'DIDMSPOSTTABLE1.Visible = True
    'PMDL

    Dim Dt As SIS.DD.DBDiscipline = SIS.DD.DBDiscipline.GetDPMDLDB(DivisionID, DisciplineID, MonthID, YearID)
    btn_ToRelease_CurrentM.Text = Dt.ToRelease_CurrentM
    btn_DueforRelease_CurrentM_A.Text = Dt.DueforRelease_CurrentM_A
    btn_DueforRelease_PreviousM_B.Text = Dt.DueforRelease_PreviousM_B
    btn_DueforRelease_BothM_C.Text = Dt.DueforRelease_BothM_C
    btn_AllDueTillToday_Release.Text = Dt.AllDueTillToday_Release
    btn_DueOnlyToday_Release.Text = Dt.DueOnlyToday_Release
    btn_Ontime_Release_CurrentM.Text = Dt.Ontime_Release_CurrentM
    btn_Backlog_Release_CurrentM.Text = Dt.Backlog_Release_CurrentM

    Dim Dt1 As SIS.DD.DBDiscipline = SIS.DD.DBDiscipline.GetDSARDB(DivisionID, DisciplineID, MonthID, YearID)

    btn_SAR_TotalCount.Text = Dt1.SAR_TotalCount
    btn_SAR_UnderCreation.Text = Dt1.SAR_UnderCreation
    btn_SAR_UnderReview.Text = Dt1.SAR_UnderReview
    btn_SAR_UnderApproval.Text = Dt1.SAR_UnderApproval
    btn_SAR_Pending.Text = Dt1.SAR_Pending
    btn_SAR_Approved.Text = Dt1.SAR_Approved
    btn_SAR_NotApplicable.Text = Dt1.SAR_NotApplicable

    btn_SAR_TotalCountA.Text = Dt1.SAR_TotalCountA
    btn_SAR_UnderCreationA.Text = Dt1.SAR_UnderCreationA
    btn_SAR_UnderReviewA.Text = Dt1.SAR_UnderReviewA
    btn_SAR_UnderApprovalA.Text = Dt1.SAR_UnderApprovalA
    btn_SAR_PendingA.Text = Dt1.SAR_PendingA
    btn_SAR_ApprovedA.Text = Dt1.SAR_ApprovedA
    btn_SAR_NotApplicableA.Text = Dt1.SAR_NotApplicableA

    Dim Dt2 As SIS.DD.DBDiscipline = SIS.DD.DBDiscipline.GetDELEMENTDB(DivisionID, DisciplineID, MonthID, YearID)
    btn_Total_Element.Text = Dt2.Total_Active_Element
    btn_Element_Free.Text = Dt2.Element_Free
    btn_Element_Partial.Text = Dt2.Element_Partial
    btn_Element_Completed.Text = Dt2.Element_Completed

    btn_ToRelease_CurrentM.ToolTip = "All Drawing & Document Count from PMDL where" & Environment.NewLine & "Division is " & F_DivisionID.SelectedItem.Text & "," & Environment.NewLine & "Discipline is " & F_DisciplineID.SelectedItem.Text & " ," & Environment.NewLine & "Month/Year of BaseLine Finishdate is " & F_MonthID.SelectedItem.Text & "/" & Convert.ToInt32(F_YearID.SelectedItem.Text) & "," & Environment.NewLine & "Document originator Is ISGEC." & Environment.NewLine & " Also VENDOR Documents ignored"
    btn_DueforRelease_CurrentM_A.ToolTip = "Unreleased Drawing & DocumentCount from PMDL where" & Environment.NewLine & "Division Is " & F_DivisionID.SelectedItem.Text & "," & Environment.NewLine & "Discipline Is " & F_DisciplineID.SelectedItem.Text & " ," & Environment.NewLine & "Month/Year Of BaseLine Finishdate is " & F_MonthID.SelectedItem.Text & "/" & Convert.ToInt32(F_YearID.SelectedItem.Text) & "," & Environment.NewLine & "Document originator is ISGEC." & Environment.NewLine & " Also VENDOR Documents ignored"
    btn_DueforRelease_PreviousM_B.ToolTip = "Unreleased Drawing & DocumentCount from PMDL where" & Environment.NewLine & "Division is " & F_DivisionID.SelectedItem.Text & "," & Environment.NewLine & "Discipline is " & F_DisciplineID.SelectedItem.Text & " ," & Environment.NewLine & "Month/Year of BaseLine Finishdate earlier than " & F_MonthID.SelectedItem.Text & "/" & Convert.ToInt32(F_YearID.SelectedItem.Text) & "," & Environment.NewLine & "Document originator is ISGEC." & Environment.NewLine & " Also VENDOR Documents ignored"
    btn_DueforRelease_BothM_C.ToolTip = "Unreleased Drawing & DocumentCount from PMDL where" & Environment.NewLine & "Division is " & F_DivisionID.SelectedItem.Text & "," & Environment.NewLine & "Discipline is " & F_DisciplineID.SelectedItem.Text & " ," & Environment.NewLine & "Month/Year of BaseLine Finishdate is " & F_MonthID.SelectedItem.Text & "/" & Convert.ToInt32(F_YearID.SelectedItem.Text) & " earlier also" & "," & Environment.NewLine & "Document originator is ISGEC." & Environment.NewLine & " Also VENDOR Documents ignored" & Environment.NewLine & "Current Month Due(" & Dt.DueforRelease_CurrentM_A & ") + Previous Month's Due (" & Dt.DueforRelease_PreviousM_B & ") = Total Due (" & Dt.DueforRelease_BothM_C & ")"
    btn_AllDueTillToday_Release.ToolTip = "Unreleased Drawing & DocumentCount from PMDL where" & Environment.NewLine & "Division is " & F_DivisionID.SelectedItem.Text & "," & Environment.NewLine & "Discipline is " & F_DisciplineID.SelectedItem.Text & " ," & Environment.NewLine & "BaseLine Finishdate lesser or equal to today ," & Environment.NewLine & "Document originator is ISGEC." & Environment.NewLine & " Also VENDOR Documents ignored"
    btn_DueOnlyToday_Release.ToolTip = "Unreleased Drawing & DocumentCount from PMDL where" & Environment.NewLine & "Division is " & F_DivisionID.SelectedItem.Text & "," & Environment.NewLine & "Discipline is " & F_DisciplineID.SelectedItem.Text & " ," & Environment.NewLine & "BaseLine Finishdate is for today ," & Environment.NewLine & "Document originator is ISGEC." & Environment.NewLine & " Also VENDOR Documents ignored"
    btn_Ontime_Release_CurrentM.ToolTip = "Released Drawing & DocumentCount from PMDL where" & Environment.NewLine & "Division is " & F_DivisionID.SelectedItem.Text & "," & Environment.NewLine & "Discipline is " & F_DisciplineID.SelectedItem.Text & " ," & Environment.NewLine & "BaseLine Finishdate is less than or equal to Actual release date, " & Environment.NewLine & "Document originator is ISGEC." & Environment.NewLine & " Also VENDOR Documents ignored"
    btn_Backlog_Release_CurrentM.ToolTip = "Released Drawing & Document Count in " & F_MonthID.SelectedItem.Text & "/" & Convert.ToInt32(F_YearID.SelectedItem.Text) & " from PMDL where" & Environment.NewLine & "Division is " & F_DivisionID.SelectedItem.Text & "," & Environment.NewLine & "Discipline is " & F_DisciplineID.SelectedItem.Text & " ," & Environment.NewLine & "Month/Year of BaseLine Finishdate earlier than " & F_MonthID.SelectedItem.Text & "/" & Convert.ToInt32(F_YearID.SelectedItem.Text) & Environment.NewLine & "Document originator is ISGEC." & Environment.NewLine & " Also VENDOR Documents ignored"
    btn_SAR_Pending.ToolTip = "Under Review (" & Dt1.SAR_UnderReview & ") + Under Approval (" & Dt1.SAR_UnderApproval & ") = Pending (" & Dt1.SAR_Pending & ")"
    btn_SAR_PendingA.ToolTip = "Under Review (" & Dt1.SAR_UnderReviewA & ") + Under Approval (" & Dt1.SAR_UnderApprovalA & ") = Pending (" & Dt1.SAR_PendingA & ")"

    Dim Dt3 As SIS.DD.DBDiscipline = SIS.DD.DBDiscipline.GetDIDMSPREDB(DivisionID, DisciplineID, MonthID, YearID)

    btn_IDMSPre_Total_Count.Text = Dt3.IDMSP_Total_Count
    btn_IDMSPre_Submitted.Text = Dt3.IDMSP_Submitted
    btn_IDMSPre_Document_linked.Text = Dt3.IDMSP_Document_linked
    btn_IDMSPre_Under_Evaluation.Text = Dt3.IDMSP_Under_Evaluation
    btn_IDMSPre_Comments_Submitted.Text = Dt3.IDMSP_Comments_Submitted
    btn_IDMSPre_Technically_Cleared.Text = Dt3.IDMSP_Technically_Cleared
    btn_IDMSPre_Transmittal_Issued.Text = Dt3.IDMSP_Transmittal_Issued
    btn_IDMSPre_Superceded.Text = Dt3.IDMSP_Superceded
    btn_IDMSPre_Closed.Text = Dt3.IDMSP_Closed

    btn_All_IDMSPre_Total_Count.Text = Dt3.All_IDMSP_Total_Count
    btn_All_IDMSPre_Submitted.Text = Dt3.All_IDMSP_Submitted
    btn_All_IDMSPre_Document_linked.Text = Dt3.All_IDMSP_Document_linked
    btn_All_IDMSPre_Under_Evaluation.Text = Dt3.All_IDMSP_Under_Evaluation
    btn_All_IDMSPre_Comments_Submitted.Text = Dt3.All_IDMSP_Comments_Submitted
    btn_All_IDMSPre_Technically_Cleared.Text = Dt3.All_IDMSP_Technically_Cleared
    btn_All_IDMSPre_Transmittal_Issued.Text = Dt3.All_IDMSP_Transmittal_Issued
    btn_All_IDMSPre_Superceded.Text = Dt3.All_IDMSP_Superceded
    btn_All_IDMSPre_Closed.Text = Dt3.All_IDMSP_Closed

    Dim Dt4 As SIS.DD.DBDiscipline = SIS.DD.DBDiscipline.GetDIDMSPOSTDB(DivisionID, DisciplineID, MonthID, YearID)

    btn_IDMSPost_Total_Count.Text = Dt4.IDMSPO_Total_Count
    btn_IDMSPost_Submitted.Text = Dt4.IDMSPO_Submitted
    btn_IDMSPost_Document_linked.Text = Dt4.IDMSPO_Document_linked
    btn_IDMSPost_Under_Evaluation.Text = Dt4.IDMSPO_Under_Evaluation
    btn_IDMSPost_Comments_Submitted.Text = Dt4.IDMSPO_Comments_Submitted
    btn_IDMSPost_Technically_Cleared.Text = Dt4.IDMSPO_Technically_Cleared
    btn_IDMSPost_Transmittal_Issued.Text = Dt4.IDMSPO_Transmittal_Issued
    btn_IDMSPost_Superceded.Text = Dt4.IDMSPO_Superceded
    btn_IDMSPost_Closed.Text = Dt4.IDMSPO_Closed

    btn_All_IDMSPost_Total_Count.Text = Dt4.All_IDMSPO_Total_Count
    btn_All_IDMSPost_Submitted.Text = Dt4.All_IDMSPo_Submitted
    btn_All_IDMSPost_Document_linked.Text = Dt4.All_IDMSPo_Document_linked
    btn_All_IDMSPost_Under_Evaluation.Text = Dt4.All_IDMSPo_Under_Evaluation
    btn_All_IDMSPost_Comments_Submitted.Text = Dt4.All_IDMSPo_Comments_Submitted
    btn_All_IDMSPost_Technically_Cleared.Text = Dt4.All_IDMSPo_Technically_Cleared
    btn_All_IDMSPost_Transmittal_Issued.Text = Dt4.All_IDMSPo_Transmittal_Issued
    btn_All_IDMSPost_Superceded.Text = Dt4.All_IDMSPo_Superceded
    btn_All_IDMSPost_Closed.Text = Dt4.All_IDMSPo_Closed


  End Sub

  'Protected Sub F_MonthID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles F_MonthID.SelectedIndexChanged
  '  Dim an As Integer = 0
  '  Dim selectedValue As String = F_MonthID.SelectedValue

  '  F_MonthID.SelectedIndex = an
  '  an = F_MonthID.SelectedIndex

  'End Sub

  'Private Sub btn_Discipline_Total_Count_Click(sender As Object, e As EventArgs) Handles btn_Discipline_Total_Count.Click
  '  Response.Redirect("GF_DisciplineDBDetails.aspx?detail=BOILER&DisciplineID=" & F_DisciplineID.Text)
  'End Sub




  Private Sub btn_ToRelease_CurrentM_Click(sender As Object, e As EventArgs) Handles btn_ToRelease_CurrentM.Click
    Response.Redirect("GF_DisciplineDBDetails.aspx?detail=ToRelease_CurrentM&DivisionID=" & DivisionID & "&DisciplineID=" & DisciplineID & "&YearID=" & YearID & "&MonthID=" & MonthID)
  End Sub
  Private Sub btn_DueforRelease_CurrentM_A_Click(sender As Object, e As EventArgs) Handles btn_DueforRelease_CurrentM_A.Click
    Response.Redirect("GF_DisciplineDBDetails.aspx?detail=DueforRelease_CurrentM_A&DivisionID=" & DivisionID & "&DisciplineID=" & DisciplineID & "&YearID=" & YearID & "&MonthID=" & MonthID)
  End Sub

  Private Sub btn_DueforRelease_BothM_C_Click(sender As Object, e As EventArgs) Handles btn_DueforRelease_BothM_C.Click
    Response.Redirect("GF_DisciplineDBDetails.aspx?detail=DueforRelease_BothM_C&DivisionID=" & DivisionID & "&DisciplineID=" & DisciplineID & "&YearID=" & YearID & "&MonthID=" & MonthID)
  End Sub

  Private Sub btn_DueforRelease_PreviousM_B_Click(sender As Object, e As EventArgs) Handles btn_DueforRelease_PreviousM_B.Click
    Response.Redirect("GF_DisciplineDBDetails.aspx?detail=DueforRelease_PreviousM_B&DivisionID=" & DivisionID & "&DisciplineID=" & DisciplineID & "&YearID=" & YearID & "&MonthID=" & MonthID)
  End Sub

  Private Sub btn_AllDueTillToday_Release_Click(sender As Object, e As EventArgs) Handles btn_AllDueTillToday_Release.Click
    Response.Redirect("GF_DisciplineDBDetails.aspx?detail=AllDueTillToday_Release&DivisionID=" & DivisionID & "&DisciplineID=" & DisciplineID & "&YearID=" & YearID & "&MonthID=" & MonthID)
  End Sub

  Private Sub btn_DueOnlyToday_Release_Click(sender As Object, e As EventArgs) Handles btn_DueOnlyToday_Release.Click
    Response.Redirect("GF_DisciplineDBDetails.aspx?detail=DueOnlyToday_Release&DivisionID=" & DivisionID & "&DisciplineID=" & DisciplineID & "&YearID=" & YearID & "&MonthID=" & MonthID)
  End Sub

  Private Sub btn_Ontime_Release_CurrentM_Click(sender As Object, e As EventArgs) Handles btn_Ontime_Release_CurrentM.Click
    Response.Redirect("GF_DisciplineDBDetails.aspx?detail=Ontime_Release_CurrentM&DivisionID=" & DivisionID & "&DisciplineID=" & DisciplineID & "&YearID=" & YearID & "&MonthID=" & MonthID)
  End Sub

  Private Sub btn_Backlog_Release_CurrentM_Click(sender As Object, e As EventArgs) Handles btn_Backlog_Release_CurrentM.Click
    Response.Redirect("GF_DisciplineDBDetails.aspx?detail=Backlog_Release_CurrentM&DivisionID=" & DivisionID & "&DisciplineID=" & DisciplineID & "&YearID=" & YearID & "&MonthID=" & MonthID)
  End Sub

  Private Sub btn_SAR_TotalCount_Click(sender As Object, e As EventArgs) Handles btn_SAR_TotalCount.Click
    Response.Redirect("GF_DisciplineDBDetails.aspx?detail=SAR_TotalCount&DivisionID=" & DivisionID & "&DisciplineID=" & DisciplineID & "&YearID=" & YearID & "&MonthID=" & MonthID)
  End Sub
  Private Sub btn_SAR_UnderCreation_Click(sender As Object, e As EventArgs) Handles btn_SAR_UnderCreation.Click
    Response.Redirect("GF_DisciplineDBDetails.aspx?detail=SAR_UnderCreation&DivisionID=" & DivisionID & "&DisciplineID=" & DisciplineID & "&YearID=" & YearID & "&MonthID=" & MonthID)
  End Sub
  Private Sub btn_SAR_UnderReview_Click(sender As Object, e As EventArgs) Handles btn_SAR_UnderReview.Click
    Response.Redirect("GF_DisciplineDBDetails.aspx?detail=SAR_UnderReview&DivisionID=" & DivisionID & "&DisciplineID=" & DisciplineID & "&YearID=" & YearID & "&MonthID=" & MonthID)
  End Sub
  Private Sub btn_SAR_UnderApproval_Click(sender As Object, e As EventArgs) Handles btn_SAR_UnderApproval.Click
    Response.Redirect("GF_DisciplineDBDetails.aspx?detail=SAR_UnderApproval&DivisionID=" & DivisionID & "&DisciplineID=" & DisciplineID & "&YearID=" & YearID & "&MonthID=" & MonthID)
  End Sub
  Private Sub btn_SAR_Pending_Click(sender As Object, e As EventArgs) Handles btn_SAR_Pending.Click
    Response.Redirect("GF_DisciplineDBDetails.aspx?detail=SAR_Pending&DivisionID=" & DivisionID & "&DisciplineID=" & DisciplineID & "&YearID=" & YearID & "&MonthID=" & MonthID)
  End Sub
  Private Sub btn_SAR_Approved_Click(sender As Object, e As EventArgs) Handles btn_SAR_Approved.Click
    Response.Redirect("GF_DisciplineDBDetails.aspx?detail=SAR_Approved&DivisionID=" & DivisionID & "&DisciplineID=" & DisciplineID & "&YearID=" & YearID & "&MonthID=" & MonthID)
  End Sub
  Private Sub btn_SAR_NotApplicable_Click(sender As Object, e As EventArgs) Handles btn_SAR_NotApplicable.Click
    Response.Redirect("GF_DisciplineDBDetails.aspx?detail=SAR_NotApplicable&DivisionID=" & DivisionID & "&DisciplineID=" & DisciplineID & "&YearID=" & YearID & "&MonthID=" & MonthID)
  End Sub


  Private Sub btn_SAR_TotalCountA_Click(sender As Object, e As EventArgs) Handles btn_SAR_TotalCountA.Click
    Response.Redirect("GF_DisciplineDBDetails.aspx?detail=SAR_TotalCountA&DivisionID=" & DivisionID & "&DisciplineID=" & DisciplineID & "&YearID=" & YearID & "&MonthID=" & MonthID)
  End Sub
  Private Sub btn_SAR_UnderCreationA_Click(sender As Object, e As EventArgs) Handles btn_SAR_UnderCreationA.Click
    Response.Redirect("GF_DisciplineDBDetails.aspx?detail=SAR_UnderCreationA&DivisionID=" & DivisionID & "&DisciplineID=" & DisciplineID & "&YearID=" & YearID & "&MonthID=" & MonthID)
  End Sub
  Private Sub btn_SAR_UnderReviewA_Click(sender As Object, e As EventArgs) Handles btn_SAR_UnderReviewA.Click
    Response.Redirect("GF_DisciplineDBDetails.aspx?detail=SAR_UnderReviewA&DivisionID=" & DivisionID & "&DisciplineID=" & DisciplineID & "&YearID=" & YearID & "&MonthID=" & MonthID)
  End Sub
  Private Sub btn_SAR_UnderApprovalA_Click(sender As Object, e As EventArgs) Handles btn_SAR_UnderApprovalA.Click
    Response.Redirect("GF_DisciplineDBDetails.aspx?detail=SAR_UnderApprovalA&DivisionID=" & DivisionID & "&DisciplineID=" & DisciplineID & "&YearID=" & YearID & "&MonthID=" & MonthID)
  End Sub
  Private Sub btn_SAR_PendingA_Click(sender As Object, e As EventArgs) Handles btn_SAR_PendingA.Click
    Response.Redirect("GF_DisciplineDBDetails.aspx?detail=SAR_PendingA&DivisionID=" & DivisionID & "&DisciplineID=" & DisciplineID & "&YearID=" & YearID & "&MonthID=" & MonthID)
  End Sub
  Private Sub btn_SAR_ApprovedA_Click(sender As Object, e As EventArgs) Handles btn_SAR_ApprovedA.Click
    Response.Redirect("GF_DisciplineDBDetails.aspx?detail=SAR_ApprovedA&DivisionID=" & DivisionID & "&DisciplineID=" & DisciplineID & "&YearID=" & YearID & "&MonthID=" & MonthID)
  End Sub
  Private Sub btn_SAR_NotApplicableA_Click(sender As Object, e As EventArgs) Handles btn_SAR_NotApplicableA.Click

    Response.Redirect("GF_DisciplineDBDetails.aspx?detail=SAR_NotApplicableA&DivisionID=" & DivisionID & "&DisciplineID=" & DisciplineID & "&YearID=" & YearID & "&MonthID=" & MonthID)
  End Sub

  Private Sub btn_Total_Element_Click(sender As Object, e As EventArgs) Handles btn_Total_Element.Click
    Response.Redirect("GF_DisciplineDBDetails.aspx?detail=Total_Element&DivisionID=" & DivisionID & "&DisciplineID=" & DisciplineID & "&YearID=" & YearID & "&MonthID=" & MonthID)

  End Sub

  Private Sub btn_Element_Free_Click(sender As Object, e As EventArgs) Handles btn_Element_Free.Click
    Response.Redirect("GF_DisciplineDBDetails.aspx?detail=Element_Free&DivisionID=" & DivisionID & "&DisciplineID=" & DisciplineID & "&YearID=" & YearID & "&MonthID=" & MonthID)

  End Sub

  Private Sub btn_Element_Partial_Click(sender As Object, e As EventArgs) Handles btn_Element_Partial.Click
    Response.Redirect("GF_DisciplineDBDetails.aspx?detail=Element_Partial&DivisionID=" & DivisionID & "&DisciplineID=" & DisciplineID & "&YearID=" & YearID & "&MonthID=" & MonthID)

  End Sub

  Private Sub btn_Element_Completed_Click(sender As Object, e As EventArgs) Handles btn_Element_Completed.Click
    Response.Redirect("GF_DisciplineDBDetails.aspx?detail=Element_Completed&DivisionID=" & DivisionID & "&DisciplineID=" & DisciplineID & "&YearID=" & YearID & "&MonthID=" & MonthID)

  End Sub

  Private Sub btn_IDMSPre_Total_Count_Click(sender As Object, e As EventArgs) Handles btn_IDMSPre_Total_Count.Click
    Response.Redirect("GF_DisciplineDBDetails.aspx?detail=IDMSPre_Total_Count&DivisionID=" & DivisionID & "&DisciplineID=" & DisciplineID & "&YearID=" & YearID & "&MonthID=" & MonthID)

  End Sub

  Private Sub btn_IDMSPre_Submitted_Click(sender As Object, e As EventArgs) Handles btn_IDMSPre_Submitted.Click
    Response.Redirect("GF_DisciplineDBDetails.aspx?detail=IDMSPre_Submitted&DivisionID=" & DivisionID & "&DisciplineID=" & DisciplineID & "&YearID=" & YearID & "&MonthID=" & MonthID)

  End Sub

  Private Sub btn_IDMSPre_Document_linked_Click(sender As Object, e As EventArgs) Handles btn_IDMSPre_Document_linked.Click
    Response.Redirect("GF_DisciplineDBDetails.aspx?detail=IDMSPre_Document_linked&DivisionID=" & DivisionID & "&DisciplineID=" & DisciplineID & "&YearID=" & YearID & "&MonthID=" & MonthID)

  End Sub

  Private Sub btn_IDMSPre_Under_Evaluation_Click(sender As Object, e As EventArgs) Handles btn_IDMSPre_Under_Evaluation.Click
    Response.Redirect("GF_DisciplineDBDetails.aspx?detail=IDMSPre_Under_Evaluation&DivisionID=" & DivisionID & "&DisciplineID=" & DisciplineID & "&YearID=" & YearID & "&MonthID=" & MonthID)

  End Sub

  Private Sub btn_IDMSPre_Comments_Submitted_Click(sender As Object, e As EventArgs) Handles btn_IDMSPre_Comments_Submitted.Click
    Response.Redirect("GF_DisciplineDBDetails.aspx?detail=IDMSPre_Comments_Submitted&DivisionID=" & DivisionID & "&DisciplineID=" & DisciplineID & "&YearID=" & YearID & "&MonthID=" & MonthID)

  End Sub

  Private Sub btn_IDMSPre_Technically_Cleared_Click(sender As Object, e As EventArgs) Handles btn_IDMSPre_Technically_Cleared.Click
    Response.Redirect("GF_DisciplineDBDetails.aspx?detail=IDMSPre_Technically_Cleared&DivisionID=" & DivisionID & "&DisciplineID=" & DisciplineID & "&YearID=" & YearID & "&MonthID=" & MonthID)

  End Sub

  Private Sub btn_IDMSPre_Transmittal_Issued_Click(sender As Object, e As EventArgs) Handles btn_IDMSPre_Transmittal_Issued.Click
    Response.Redirect("GF_DisciplineDBDetails.aspx?detail=IDMSPre_Transmittal_Issued&DivisionID=" & DivisionID & "&DisciplineID=" & DisciplineID & "&YearID=" & YearID & "&MonthID=" & MonthID)

  End Sub

  Private Sub btn_IDMSPre_Superceded_Click(sender As Object, e As EventArgs) Handles btn_IDMSPre_Superceded.Click

    Response.Redirect("GF_DisciplineDBDetails.aspx?detail=IDMSPre_Superceded&DivisionID=" & DivisionID & "&DisciplineID=" & DisciplineID & "&YearID=" & YearID & "&MonthID=" & MonthID)

  End Sub

  Private Sub btn_IDMSPre_Closed_Click(sender As Object, e As EventArgs) Handles btn_IDMSPre_Closed.Click
    Response.Redirect("GF_DisciplineDBDetails.aspx?detail=IDMSPre_Closed&DivisionID=" & DivisionID & "&DisciplineID=" & DisciplineID & "&YearID=" & YearID & "&MonthID=" & MonthID)

  End Sub

  Private Sub btn_IDMSPost_Total_Count_Click(sender As Object, e As EventArgs) Handles btn_IDMSPost_Total_Count.Click
    Response.Redirect("GF_DisciplineDBDetails.aspx?detail=IDMSPost_Total_Count&DivisionID=" & DivisionID & "&DisciplineID=" & DisciplineID & "&YearID=" & YearID & "&MonthID=" & MonthID)

  End Sub

  Private Sub btn_IDMSPost_Submitted_Click(sender As Object, e As EventArgs) Handles btn_IDMSPost_Submitted.Click
    Response.Redirect("GF_DisciplineDBDetails.aspx?detail=IDMSPost_Submitted&DivisionID=" & DivisionID & "&DisciplineID=" & DisciplineID & "&YearID=" & YearID & "&MonthID=" & MonthID)

  End Sub

  Private Sub btn_IDMSPost_Document_linked_Click(sender As Object, e As EventArgs) Handles btn_IDMSPost_Document_linked.Click
    Response.Redirect("GF_DisciplineDBDetails.aspx?detail=IDMSPost_Document_linked&DivisionID=" & DivisionID & "&DisciplineID=" & DisciplineID & "&YearID=" & YearID & "&MonthID=" & MonthID)

  End Sub

  Private Sub btn_IDMSPost_Under_Evaluation_Click(sender As Object, e As EventArgs) Handles btn_IDMSPost_Under_Evaluation.Click
    Response.Redirect("GF_DisciplineDBDetails.aspx?detail=IDMSPost_Under_Evaluation&DivisionID=" & DivisionID & "&DisciplineID=" & DisciplineID & "&YearID=" & YearID & "&MonthID=" & MonthID)

  End Sub

  Private Sub btn_IDMSPost_Comments_Submitted_Click(sender As Object, e As EventArgs) Handles btn_IDMSPost_Comments_Submitted.Click
    Response.Redirect("GF_DisciplineDBDetails.aspx?detail=IDMSPost_Comments_Submitted&DivisionID=" & DivisionID & "&DisciplineID=" & DisciplineID & "&YearID=" & YearID & "&MonthID=" & MonthID)

  End Sub

  Private Sub btn_IDMSPost_Technically_Cleared_Click(sender As Object, e As EventArgs) Handles btn_IDMSPost_Technically_Cleared.Click
    Response.Redirect("GF_DisciplineDBDetails.aspx?detail=IDMSPost_Technically_Cleared&DivisionID=" & DivisionID & "&DisciplineID=" & DisciplineID & "&YearID=" & YearID & "&MonthID=" & MonthID)

  End Sub

  Private Sub btn_IDMSPost_Transmittal_Issued_Click(sender As Object, e As EventArgs) Handles btn_IDMSPost_Transmittal_Issued.Click
    Response.Redirect("GF_DisciplineDBDetails.aspx?detail=IDMSPost_Transmittal_Issued&DivisionID=" & DivisionID & "&DisciplineID=" & DisciplineID & "&YearID=" & YearID & "&MonthID=" & MonthID)

  End Sub

  Private Sub btn_IDMSPost_Superceded_Click(sender As Object, e As EventArgs) Handles btn_IDMSPost_Superceded.Click

    Response.Redirect("GF_DisciplineDBDetails.aspx?detail=IDMSPost_Superceded&DivisionID=" & DivisionID & "&DisciplineID=" & DisciplineID & "&YearID=" & YearID & "&MonthID=" & MonthID)

  End Sub

  Private Sub btn_IDMSPost_Closed_Click(sender As Object, e As EventArgs) Handles btn_IDMSPost_Closed.Click
    Response.Redirect("GF_DisciplineDBDetails.aspx?detail=IDMSPost_Closed&DivisionID=" & DivisionID & "&DisciplineID=" & DisciplineID & "&YearID=" & YearID & "&MonthID=" & MonthID)

  End Sub

  Private Sub btn_All_IDMSPre_Total_Count_Click(sender As Object, e As EventArgs) Handles btn_All_IDMSPre_Total_Count.Click
    Response.Redirect("GF_DisciplineDBDetails.aspx?detail=All_IDMSPre_Total_Count&DivisionID=" & DivisionID & "&DisciplineID=" & DisciplineID & "&YearID=" & YearID & "&MonthID=" & MonthID)

  End Sub

  Private Sub btn_All_IDMSPre_Submitted_Click(sender As Object, e As EventArgs) Handles btn_All_IDMSPre_Submitted.Click
    Response.Redirect("GF_DisciplineDBDetails.aspx?detail=All_IDMSPre_Submitted&DivisionID=" & DivisionID & "&DisciplineID=" & DisciplineID & "&YearID=" & YearID & "&MonthID=" & MonthID)

  End Sub

  Private Sub btn_All_IDMSPre_Document_linked_Click(sender As Object, e As EventArgs) Handles btn_All_IDMSPre_Document_linked.Click
    Response.Redirect("GF_DisciplineDBDetails.aspx?detail=All_IDMSPre_Document_linked&DivisionID=" & DivisionID & "&DisciplineID=" & DisciplineID & "&YearID=" & YearID & "&MonthID=" & MonthID)

  End Sub

  Private Sub btn_All_IDMSPre_Under_Evaluation_Click(sender As Object, e As EventArgs) Handles btn_All_IDMSPre_Under_Evaluation.Click
    Response.Redirect("GF_DisciplineDBDetails.aspx?detail=All_IDMSPre_Under_Evaluation&DivisionID=" & DivisionID & "&DisciplineID=" & DisciplineID & "&YearID=" & YearID & "&MonthID=" & MonthID)

  End Sub

  Private Sub btn_All_IDMSPre_Comments_Submitted_Click(sender As Object, e As EventArgs) Handles btn_All_IDMSPre_Comments_Submitted.Click
    Response.Redirect("GF_DisciplineDBDetails.aspx?detail=All_IDMSPre_Comments_Submitted&DivisionID=" & DivisionID & "&DisciplineID=" & DisciplineID & "&YearID=" & YearID & "&MonthID=" & MonthID)

  End Sub

  Private Sub btn_All_IDMSPre_Technically_Cleared_Click(sender As Object, e As EventArgs) Handles btn_All_IDMSPre_Technically_Cleared.Click
    Response.Redirect("GF_DisciplineDBDetails.aspx?detail=All_IDMSPre_Technically_Cleared&DivisionID=" & DivisionID & "&DisciplineID=" & DisciplineID & "&YearID=" & YearID & "&MonthID=" & MonthID)

  End Sub

  Private Sub btn_All_IDMSPre_Transmittal_Issued_Click(sender As Object, e As EventArgs) Handles btn_All_IDMSPre_Transmittal_Issued.Click
    Response.Redirect("GF_DisciplineDBDetails.aspx?detail=All_IDMSPre_Transmittal_Issued&DivisionID=" & DivisionID & "&DisciplineID=" & DisciplineID & "&YearID=" & YearID & "&MonthID=" & MonthID)

  End Sub

  Private Sub btn_All_IDMSPre_Superceded_Click(sender As Object, e As EventArgs) Handles btn_All_IDMSPre_Superceded.Click

    Response.Redirect("GF_DisciplineDBDetails.aspx?detail=All_IDMSPre_Superceded&DivisionID=" & DivisionID & "&DisciplineID=" & DisciplineID & "&YearID=" & YearID & "&MonthID=" & MonthID)

  End Sub

  Private Sub btn_All_IDMSPre_Closed_Click(sender As Object, e As EventArgs) Handles btn_All_IDMSPre_Closed.Click
    Response.Redirect("GF_DisciplineDBDetails.aspx?detail=All_IDMSPre_Closed&DivisionID=" & DivisionID & "&DisciplineID=" & DisciplineID & "&YearID=" & YearID & "&MonthID=" & MonthID)

  End Sub

  Private Sub btn_All_IDMSPost_Total_Count_Click(sender As Object, e As EventArgs) Handles btn_All_IDMSPost_Total_Count.Click
    Response.Redirect("GF_DisciplineDBDetails.aspx?detail=All_IDMSPost_Total_Count&DivisionID=" & DivisionID & "&DisciplineID=" & DisciplineID & "&YearID=" & YearID & "&MonthID=" & MonthID)

  End Sub

  Private Sub btn_All_IDMSPost_Submitted_Click(sender As Object, e As EventArgs) Handles btn_All_IDMSPost_Submitted.Click
    Response.Redirect("GF_DisciplineDBDetails.aspx?detail=All_IDMSPost_Submitted&DivisionID=" & DivisionID & "&DisciplineID=" & DisciplineID & "&YearID=" & YearID & "&MonthID=" & MonthID)

  End Sub

  Private Sub btn_All_IDMSPost_Document_linked_Click(sender As Object, e As EventArgs) Handles btn_All_IDMSPost_Document_linked.Click
    Response.Redirect("GF_DisciplineDBDetails.aspx?detail=All_IDMSPost_Document_linked&DivisionID=" & DivisionID & "&DisciplineID=" & DisciplineID & "&YearID=" & YearID & "&MonthID=" & MonthID)

  End Sub

  Private Sub btn_All_IDMSPost_Under_Evaluation_Click(sender As Object, e As EventArgs) Handles btn_All_IDMSPost_Under_Evaluation.Click
    Response.Redirect("GF_DisciplineDBDetails.aspx?detail=All_IDMSPost_Under_Evaluation&DivisionID=" & DivisionID & "&DisciplineID=" & DisciplineID & "&YearID=" & YearID & "&MonthID=" & MonthID)

  End Sub

  Private Sub btn_All_IDMSPost_Comments_Submitted_Click(sender As Object, e As EventArgs) Handles btn_All_IDMSPost_Comments_Submitted.Click
    Response.Redirect("GF_DisciplineDBDetails.aspx?detail=All_IDMSPost_Comments_Submitted&DivisionID=" & DivisionID & "&DisciplineID=" & DisciplineID & "&YearID=" & YearID & "&MonthID=" & MonthID)

  End Sub

  Private Sub btn_All_IDMSPost_Technically_Cleared_Click(sender As Object, e As EventArgs) Handles btn_All_IDMSPost_Technically_Cleared.Click
    Response.Redirect("GF_DisciplineDBDetails.aspx?detail=All_IDMSPost_Technically_Cleared&DivisionID=" & DivisionID & "&DisciplineID=" & DisciplineID & "&YearID=" & YearID & "&MonthID=" & MonthID)

  End Sub

  Private Sub btn_All_IDMSPost_Transmittal_Issued_Click(sender As Object, e As EventArgs) Handles btn_All_IDMSPost_Transmittal_Issued.Click
    Response.Redirect("GF_DisciplineDBDetails.aspx?detail=All_IDMSPost_Transmittal_Issued&DivisionID=" & DivisionID & "&DisciplineID=" & DisciplineID & "&YearID=" & YearID & "&MonthID=" & MonthID)

  End Sub

  Private Sub btn_All_IDMSPost_Superceded_Click(sender As Object, e As EventArgs) Handles btn_All_IDMSPost_Superceded.Click

    Response.Redirect("GF_DisciplineDBDetails.aspx?detail=All_IDMSPost_Superceded&DivisionID=" & DivisionID & "&DisciplineID=" & DisciplineID & "&YearID=" & YearID & "&MonthID=" & MonthID)

  End Sub

  Private Sub btn_All_IDMSPost_Closed_Click(sender As Object, e As EventArgs) Handles btn_All_IDMSPost_Closed.Click
    Response.Redirect("GF_DisciplineDBDetails.aspx?detail=All_IDMSPost_Closed&DivisionID=" & DivisionID & "&DisciplineID=" & DisciplineID & "&YearID=" & YearID & "&MonthID=" & MonthID)

  End Sub

End Class