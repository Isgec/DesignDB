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
        DisciplineID = "C&I"
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
    Btn_Discipline.Text = DivisionID + "-" + DisciplineID + "-" + F_YearID.SelectedItem.Text + "-" + F_MonthID.SelectedItem.Text.Remove(3)
    DSARTABLE.Visible = True
    Btn_Discipline1.Text = DivisionID + "-" + DisciplineID + "-" + F_YearID.SelectedItem.Text + "-" + F_MonthID.SelectedItem.Text.Remove(3)
    DELEMENTTABLE.Visible = True
    Btn_Discipline2.Text = "Over All"
    'PMDL

    Dim Dt As SIS.DD.DBDiscipline = SIS.DD.DBDiscipline.GetDPMDLDB(DivisionID, DisciplineID, MonthID, YearID)

    btn_DueforRelease_CurrentM_A.Text = Dt.DueforRelease_CurrentM_A
    btn_DueforRelease_PreviousM_B.Text = Dt.DueforRelease_PreviousM_B
    btn_DueforRelease_BothM_C.Text = Dt.DueforRelease_PreviousM_B + Dt.DueforRelease_CurrentM_A
    btn_AllDueTillToday_Release.Text = Dt.AllDueTillToday_Release
    btn_DueOnlyToday_Release.Text = Dt.DueOnlyToday_Release
    btn_Ontime_Release_CurrentM.Text = Dt.Ontime_Release_CurrentM
    btn_Backlog_Release_CurrentM.Text = Dt.Backlog_Release_CurrentM

    Dim Dt1 As SIS.DD.DBDiscipline = SIS.DD.DBDiscipline.GetDSARDB(DivisionID, DisciplineID, MonthID, YearID)

    btn_SAR_TotalCount.Text = Dt1.SAR_TotalCount
    btn_SAR_UnderCreation.Text = Dt1.SAR_UnderCreation
    btn_SAR_UnderReview.Text = Dt1.SAR_UnderReview
    btn_SAR_UnderApproval.Text = Dt1.SAR_UnderApproval
    btn_SAR_Pending.Text = Dt1.SAR_UnderCreation + Dt1.SAR_UnderReview + Dt1.SAR_UnderApproval
    btn_SAR_Approved.Text = Dt1.SAR_Approved
    btn_SAR_NotApplicable.Text = Dt1.SAR_NotApplicable

    btn_SAR_TotalCountA.Text = Dt1.SAR_TotalCountA
    btn_SAR_UnderCreationA.Text = Dt1.SAR_UnderCreationA
    btn_SAR_UnderReviewA.Text = Dt1.SAR_UnderReviewA
    btn_SAR_UnderApprovalA.Text = Dt1.SAR_UnderApprovalA
    btn_SAR_PendingA.Text = Dt1.SAR_UnderCreationA + Dt1.SAR_UnderReviewA + Dt1.SAR_UnderApprovalA
    btn_SAR_ApprovedA.Text = Dt1.SAR_ApprovedA
    btn_SAR_NotApplicableA.Text = Dt1.SAR_NotApplicableA

    Dim Dt2 As SIS.DD.DBDiscipline = SIS.DD.DBDiscipline.GetDELEMENTDB(DivisionID, DisciplineID, MonthID, YearID)
    btn_Total_Element.Text = Dt2.Total_Active_Element
    btn_Element_Free.Text = Dt2.Element_Free
    btn_Element_Partial.Text = Dt2.Element_Partial
    btn_Element_Completed.Text = Dt2.Element_Completed

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


  Protected Sub F_MonthID_SelectedIndexChanged(sender As Object, e As EventArgs)


  End Sub
End Class








