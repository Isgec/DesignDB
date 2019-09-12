Partial Class GF_ProjectDB
  Inherits System.Web.UI.Page
  Public Property ProjectID As String
    Get
      If ViewState("ProjectID") IsNot Nothing Then
        Return ViewState("ProjectID")
      End If
      Return ""
    End Get
    Set(value As String)

      ViewState.Add("ProjectID", value)
    End Set
  End Property


  Private Sub GF_UserDB_Load(sender As Object, e As EventArgs) Handles Me.Load
    '  Dim y As SIS.CT.CTChart = SIS.CT.CTChart.GetProjectDB(ProjectID, ProjectDesc)


    ProjectID = F_t_cprj.Text.ToUpper()
    F_t_cprj.Text = ProjectID



    '  pd.Text = y.ProjectDesc


    If ProjectID = "" Then Exit Sub

  End Sub
#Region "  Chart Render "
  Private Sub Chart1_PreRender(sender As Object, e As EventArgs) Handles Chart1.PreRender

    If ProjectID = "" Then Exit Sub


    Dim Dt As SIS.CT.CTChart = SIS.CT.CTChart.GetCTChart(ProjectID)

    If Dt.PlannedX.Length >= 1 Then
      Chart1 = SIS.CT.CTChart.RenderChart(Chart1, Dt)
      DPLMDATA.Visible = False
    Else
      Chart1.Visible = False
      DPLMDATA.Text = "No Data Available for -" & ProjectID
      DPLMDATA.Visible = True
    End If



    Dim x As SIS.CT.CTChart = SIS.CT.CTChart.GetPMDLDB(ProjectID)

    If (x.ProjectDesc = "") Then
      x.ProjectDesc = "IS IT REALLY A VALID PROJECT ID. Please Check Carefully !!!"
      btn_projectname.Text = x.ProjectDesc
      btn_projectname.BackColor = Drawing.Color.Red
    Else
      btn_projectname.Text = x.ProjectID & " - " & x.ProjectDesc
      btn_projectname.BackColor = Drawing.Color.Orange
    End If


    btn_Process_Total_Count.Text = x.Process_Total_Count
    btn_Mechanical_Total_Count.Text = x.Mechanical_Total_Count
    btn_Structure_Total_Count.Text = x.Structure_Total_Count
    btn_Piping_Total_Count.Text = x.Piping_Total_Count
    btn_Electrical_Total_Count.Text = x.Electrical_Total_Count
    btn_CI_Total_Count.Text = x.CI_Total_Count
    btn_Total_Total_Count.Text = x.Total_Total_Count

    btn_Process_Release_Count.Text = x.Process_Release_Count
    btn_Mechanical_Release_Count.Text = x.Mechanical_Release_Count
    btn_Structure_Release_Count.Text = x.Structure_Release_Count
    btn_Piping_Release_Count.Text = x.Piping_Release_Count
    btn_Electrical_Release_Count.Text = x.Electrical_Release_Count
    btn_CI_Release_Count.Text = x.CI_Release_Count
    btn_Total_Release_Count.Text = x.Total_Release_Count


    btn_Process_Pending_Count.Text = x.Process_Pending_Count
    btn_Mechanical_Pending_Count.Text = x.Mechanical_Pending_Count
    btn_Structure_Pending_Count.Text = x.Structure_Pending_Count
    btn_Piping_Pending_Count.Text = x.Piping_Pending_Count
    btn_Electrical_Pending_Count.Text = x.Electrical_Pending_Count
    btn_CI_Pending_Count.Text = x.CI_Pending_Count
    btn_Total_Pending_Count.Text = x.Total_Pending_Count

    btn_Process_Due_Count.Text = x.Process_Due_Count
    btn_Mechanical_Due_Count.Text = x.Mechanical_Due_Count
    btn_Structure_Due_Count.Text = x.Structure_Due_Count
    btn_Piping_Due_Count.Text = x.Piping_Due_Count
    btn_Electrical_Due_Count.Text = x.Electrical_Due_Count
    btn_CI_Due_Count.Text = x.CI_Due_Count
    btn_Total_Due_Count.Text = x.Total_Due_Count

    btn_Process_Ontime_Count.Text = x.Process_OnTime_Count
    btn_Mechanical_Ontime_Count.Text = x.Mechanical_OnTime_Count
    btn_Structure_Ontime_Count.Text = x.Structure_OnTime_Count
    btn_Piping_Ontime_Count.Text = x.Piping_OnTime_Count
    btn_Electrical_Ontime_Count.Text = x.Electrical_OnTime_Count
    btn_CI_Ontime_Count.Text = x.CI_OnTime_Count
    btn_Total_Ontime_Count.Text = x.Total_OnTime_Count

    '----

    btn_Process_Delayed_Count.Text = x.Process_Delayed_Count
    btn_Mechanical_Delayed_Count.Text = x.Mechanical_Delayed_Count
    btn_Structure_Delayed_Count.Text = x.Structure_Delayed_Count
    btn_piping_Delayed_Count.Text = x.Piping_Delayed_Count
    btn_Electrical_Delayed_Count.Text = x.Electrical_Delayed_Count
    btn_CI_Delayed_Count.Text = x.CI_Delayed_Count
    btn_Total_Delayed_Count.Text = x.Total_Delayed_Count

    'DCR
    Dim x1 As SIS.CT.CTChart = SIS.CT.CTChart.GetDCRDB(ProjectID)
    btn_Process_DCR_Total_Count.Text = x1.Process_DCR_Total_Count
    btn_Process_DCR_Under_Creation.Text = x1.Process_DCR_Under_Creation
    btn_Process_DCR_Under_Approval.Text = x1.Process_DCR_Under_Approval
    btn_Process_DCR_Approved.Text = x1.Process_DCR_Approved

    btn_Mechanical_DCR_Total_Count.Text = x1.Mechanical_DCR_Total_Count
    btn_Mechanical_DCR_Under_Creation.Text = x1.Mechanical_DCR_Under_Creation
    btn_Mechanical_DCR_Under_Approval.Text = x1.Mechanical_DCR_Under_Approval
    btn_Mechanical_DCR_Approved.Text = x1.Mechanical_DCR_Approved

    btn_Structure_DCR_Total_Count.Text = x1.Structure_DCR_Total_Count
    btn_Structure_DCR_Under_Creation.Text = x1.Structure_DCR_Under_Creation
    btn_Structure_DCR_Under_Approval.Text = x1.Structure_DCR_Under_Approval
    btn_Structure_DCR_Approved.Text = x1.Structure_DCR_Approved

    btn_Piping_DCR_Total_Count.Text = x1.Piping_DCR_Total_Count
    btn_Piping_DCR_Under_Creation.Text = x1.Piping_DCR_Under_Creation
    btn_Piping_DCR_Under_Approval.Text = x1.Piping_DCR_Under_Approval
    btn_Piping_DCR_Approved.Text = x1.Piping_DCR_Approved

    btn_Electrical_DCR_Total_Count.Text = x1.Electrical_DCR_Total_Count
    btn_Electrical_DCR_Under_Creation.Text = x1.Electrical_DCR_Under_Creation
    btn_Electrical_DCR_Under_Approval.Text = x1.Electrical_DCR_Under_Approval
    btn_Electrical_DCR_Approved.Text = x1.Electrical_DCR_Approved

    btn_CI_DCR_Total_Count.Text = x1.CI_DCR_Total_Count
    btn_CI_DCR_Under_Creation.Text = x1.CI_DCR_Under_Creation
    btn_CI_DCR_Under_Approval.Text = x1.CI_DCR_Under_Approval
    btn_CI_DCR_Approved.Text = x1.CI_DCR_Approved

    btn_Others_DCR_Total_Count.Text = x1.Others_DCR_Total_Count
    btn_Others_DCR_Under_Creation.Text = x1.Others_DCR_Under_Creation
    btn_Others_DCR_Under_Approval.Text = x1.Others_DCR_Under_Approval
    btn_Others_DCR_Approved.Text = x1.Others_DCR_Approved

    btn_Total_DCR_Total_Count.Text = x1.Total_DCR_Total_Count
    btn_Total_DCR_Under_Creation.Text = x1.Total_DCR_Under_Creation
    btn_Total_DCR_Under_Approval.Text = x1.Total_DCR_Under_Approval
    btn_Total_DCR_Approved.Text = x1.Total_DCR_Approved

    'transmittal
    Dim x2 As SIS.CT.CTChart = SIS.CT.CTChart.GetTRANSMITTALDB(ProjectID)

    btn_Process_Transmittal_Total_Count.Text = x2.Process_Transmittal_Total_Count
    btn_Process_Transmittal_Free.Text = x2.Process_Transmittal_Free
    btn_Process_Transmittal_Under_Approval.Text = x2.Process_Transmittal_Under_Approval
    btn_Process_Transmittal_Under_Issue.Text = x2.Process_Transmittal_Under_Issue
    btn_Process_Transmittal_Issued.Text = x2.Process_Transmittal_Issued
    btn_Process_Transmittal_Partial_Received.Text = x2.Process_Transmittal_Partial_Received
    btn_Process_Transmittal_Received.Text = x2.Process_Transmittal_Received
    btn_Process_Transmittal_Closed.Text = x2.Process_Transmittal_Closed
    btn_Process_Transmittal_Returned.Text = x2.Process_Transmittal_Returned

    btn_Mechanical_Transmittal_Total_Count.Text = x2.Mechanical_Transmittal_Total_Count
    btn_Mechanical_Transmittal_Free.Text = x2.Mechanical_Transmittal_Free
    btn_Mechanical_Transmittal_Under_Approval.Text = x2.Mechanical_Transmittal_Under_Approval
    btn_Mechanical_Transmittal_Under_Issue.Text = x2.Mechanical_Transmittal_Under_Issue
    btn_Mechanical_Transmittal_Issued.Text = x2.Mechanical_Transmittal_Issued
    btn_Mechanical_Transmittal_Partial_Received.Text = x2.Mechanical_Transmittal_Partial_Received
    btn_Mechanical_Transmittal_Received.Text = x2.Mechanical_Transmittal_Received
    btn_Mechanical_Transmittal_Closed.Text = x2.Mechanical_Transmittal_Closed
    btn_Mechanical_Transmittal_Returned.Text = x2.Mechanical_Transmittal_Returned

    btn_Structure_Transmittal_Total_Count.Text = x2.Structure_Transmittal_Total_Count
    btn_Structure_Transmittal_Free.Text = x2.Structure_Transmittal_Free
    btn_Structure_Transmittal_Under_Approval.Text = x2.Structure_Transmittal_Under_Approval
    btn_Structure_Transmittal_Under_Issue.Text = x2.Structure_Transmittal_Under_Issue
    btn_Structure_Transmittal_Issued.Text = x2.Structure_Transmittal_Issued
    btn_Structure_Transmittal_Partial_Received.Text = x2.Structure_Transmittal_Partial_Received
    btn_Structure_Transmittal_Recieved.Text = x2.Structure_Transmittal_Received
    btn_Structure_Transmittal_Closed.Text = x2.Structure_Transmittal_Closed
    btn_Structure_Transmittal_Returned.Text = x2.Structure_Transmittal_Returned

    btn_Piping_Transmittal_Total_Count.Text = x2.Piping_Transmittal_Total_Count
    btn_Piping_Transmittal_Free.Text = x2.Piping_Transmittal_Free
    btn_Piping_Transmittal_Under_Approval.Text = x2.Piping_Transmittal_Under_Approval
    btn_Piping_Transmittal_Under_Issue.Text = x2.Piping_Transmittal_Under_Issue
    btn_Piping_Transmittal_Issued.Text = x2.Piping_Transmittal_Issued
    btn_Piping_Transmittal_Partial_Received.Text = x2.Piping_Transmittal_Partial_Received
    btn_Piping_Transmittal_Received.Text = x2.Piping_Transmittal_Received
    btn_Piping_Transmittal_Closed.Text = x2.Piping_Transmittal_Closed
    btn_Piping_Transmittal_Returned.Text = x2.Piping_Transmittal_Returned

    btn_Electrical_Transmittal_Total_Count.Text = x2.Electrical_Transmittal_Total_Count
    btn_Electrical_Transmittal_Free.Text = x2.Electrical_Transmittal_Free
    btn_Electrical_Transmittal_Under_Approval.Text = x2.Electrical_Transmittal_Under_Approval
    btn_Electrical_Transmittal_Under_Issue.Text = x2.Electrical_Transmittal_Under_Issue
    btn_Electrical_Transmittal_Issued.Text = x2.Electrical_Transmittal_Issued
    btn_Electrical_Transmittal_Partial_Received.Text = x2.Electrical_Transmittal_Partial_Received
    btn_Electrical_Transmittal_Received.Text = x2.Electrical_Transmittal_Received
    btn_Electrical_Transmittal_Closed.Text = x2.Electrical_Transmittal_Closed
    btn_Electrical_Transmittal_Returned.Text = x2.Electrical_Transmittal_Returned

    btn_CI_Transmittal_Total_Count.Text = x2.CI_Transmittal_Total_Count
    btn_CI_Transmittal_Free.Text = x2.CI_Transmittal_Free
    btn_CI_Transmittal_Under_Approval.Text = x2.CI_Transmittal_Under_Approval
    btn_CI_Transmittal_Under_Issue.Text = x2.CI_Transmittal_Under_Issue
    btn_CI_Transmittal_Issued.Text = x2.CI_Transmittal_Issued
    btn_CI_Transmittal_Partial_Received.Text = x2.CI_Transmittal_Partial_Received
    btn_CI_Transmittal_Received.Text = x2.CI_Transmittal_Received
    btn_CI_Transmittal_Closed.Text = x2.CI_Transmittal_Closed
    btn_CI_Transmittal_Returned.Text = x2.CI_Transmittal_Returned

    btn_Others_Transmittal_Total_Count.Text = x2.Others_Transmittal_Total_Count
    btn_Others_Transmittal_Free.Text = x2.Others_Transmittal_Free
    btn_Others_Transmittal_Under_Approval.Text = x2.Others_Transmittal_Under_Approval
    btn_Others_Transmittal_Under_Issue.Text = x2.Others_Transmittal_Under_Issue
    btn_Others_Transmittal_Issued.Text = x2.Others_Transmittal_Issued
    btn_Others_Transmittal_Partial_Received.Text = x2.Others_Transmittal_Partial_Received
    btn_Others_Transmittal_Received.Text = x2.Others_Transmittal_Received
    btn_Others_Transmittal_Closed.Text = x2.Others_Transmittal_Closed
    btn_Others_Transmittal_Returned.Text = x2.Others_Transmittal_Returned

    btn_Total_Transmittal_Total_Count.Text = x2.Total_Transmittal_Total_Count
    btn_Total_Transmittal_Free.Text = x2.Total_Transmittal_Free
    btn_Total_Transmittal_Under_Approval.Text = x2.Total_Transmittal_Under_Approval
    btn_Total_Transmittal_Under_Issue.Text = x2.Total_Transmittal_Under_Issue
    btn_Total_Transmittal_Issued.Text = x2.Total_Transmittal_Issued
    btn_Total_Transmittal_Partial_Received.Text = x2.Total_Transmittal_Partial_Received
    btn_Total_Transmittal_Received.Text = x2.Total_Transmittal_Received
    btn_Total_Transmittal_Closed.Text = x2.Total_Transmittal_Closed
    btn_Total_Transmittal_Returned.Text = x2.Total_Transmittal_Returned

    Dim x3 As SIS.CT.CTChart = SIS.CT.CTChart.GetSARDB(ProjectID)
    btn_Process_SAR_Total_Count.Text = x3.Process_SAR_Total_Count
    btn_Process_SAR_Under_Creation.Text = x3.Process_SAR_Under_Creation
    btn_Process_SAR_Under_Review.Text = x3.Process_SAR_Under_Review
    btn_Process_SAR_Under_Approval.Text = x3.Process_SAR_Under_Approval
    btn_Process_SAR_Approved.Text = x3.Process_SAR_Approved
    btn_Process_SAR_Not_Applicable.Text = x3.Process_SAR_Not_Applicable

    btn_Mechanical_SAR_Total_Count.Text = x3.Mechanical_SAR_Total_Count
    btn_Mechanical_SAR_Under_Creation.Text = x3.Mechanical_SAR_Under_Creation
    btn_Mechanical_SAR_Under_Review.Text = x3.Mechanical_SAR_Under_Review
    btn_Mechanical_SAR_Under_Approval.Text = x3.Mechanical_SAR_Under_Approval
    btn_Mechanical_SAR_Approved.Text = x3.Mechanical_SAR_Approved
    btn_Mechanical_SAR_Not_Applicable.Text = x3.Mechanical_SAR_Not_Applicable

    btn_Structure_SAR_Total_Count.Text = x3.Structure_SAR_Total_Count
    btn_Structure_SAR_Under_Creation.Text = x3.Structure_SAR_Under_Creation
    btn_Structure_SAR_Under_Review.Text = x3.Structure_SAR_Under_Review
    btn_Structure_SAR_Under_Approval.Text = x3.Structure_SAR_Under_Approval
    btn_Structure_SAR_Approved.Text = x3.Structure_SAR_Approved
    btn_Structure_SAR_Not_Applicable.Text = x3.Structure_SAR_Not_Applicable

    btn_Piping_SAR_Total_Count.Text = x3.Piping_SAR_Total_Count
    btn_Piping_SAR_Under_Creation.Text = x3.Piping_SAR_Under_Creation
    btn_Piping_SAR_Under_Review.Text = x3.Piping_SAR_Under_Review
    btn_Piping_SAR_Under_Approval.Text = x3.Piping_SAR_Under_Approval
    btn_Piping_SAR_Approved.Text = x3.Piping_SAR_Approved
    btn_Piping_SAR_Not_Applicable.Text = x3.Piping_SAR_Not_Applicable

    btn_Electrical_SAR_Total_Count.Text = x3.Electrical_SAR_Total_Count
    btn_Electrical_SAR_Under_Creation.Text = x3.Electrical_SAR_Under_Creation
    btn_Electrical_SAR_Under_Review.Text = x3.Electrical_SAR_Under_Review
    btn_Electrical_SAR_Under_Approval.Text = x3.Electrical_SAR_Under_Approval
    btn_Electrical_SAR_Approved.Text = x3.Electrical_SAR_Approved
    btn_Electrical_SAR_Not_Applicable.Text = x3.Electrical_SAR_Not_Applicable

    btn_CI_SAR_Total_Count.Text = x3.CI_SAR_Total_Count
    btn_CI_SAR_Under_Creation.Text = x3.CI_SAR_Under_Creation
    btn_CI_SAR_Under_Review.Text = x3.CI_SAR_Under_Review
    btn_CI_SAR_Under_Approval.Text = x3.CI_SAR_Under_Approval
    btn_CI_SAR_Approved.Text = x3.CI_SAR_Approved
    btn_CI_SAR_Not_Applicable.Text = x3.CI_SAR_Not_Applicable

    btn_Others_SAR_Total_Count.Text = x3.Others_SAR_Total_Count
    btn_Others_SAR_Under_Creation.Text = x3.Others_SAR_Under_Creation
    btn_Others_SAR_Under_Review.Text = x3.Others_SAR_Under_Review
    btn_Others_SAR_Under_Approval.Text = x3.Others_SAR_Under_Approval
    btn_Others_SAR_Approved.Text = x3.Others_SAR_Approved
    btn_Others_SAR_Not_Applicable.Text = x3.Others_SAR_Not_Applicable

    btn_Total_SAR_Total_Count.Text = x3.Total_SAR_Total_Count
    btn_Total_SAR_Under_Creation.Text = x3.Total_SAR_Under_Creation
    btn_Total_SAR_Under_Review.Text = x3.Total_SAR_Under_Review
    btn_Total_SAR_Under_Approval.Text = x3.Total_SAR_Under_Approval
    btn_Total_SAR_Approved.Text = x3.Total_SAR_Approved
    btn_Total_SAR_Not_Applicable.Text = x3.Total_SAR_Not_Applicable

    Dim x4 As SIS.CT.CTChart = SIS.CT.CTChart.GetIDMSPDB(ProjectID)

    btn_Process_IDMSP_Total_Count.Text = x4.Process_IDMSP_Total_Count
    btn_Process_IDMSP_Submitted.Text = x4.Process_IDMSP_Submitted
    btn_Process_IDMSP_Document_linked.Text = x4.Process_IDMSP_Document_linked
    btn_Process_IDMSP_Under_Evaluation.Text = x4.Process_IDMSP_Under_Evaluation
    btn_Process_IDMSP_Comments_Submitted.Text = x4.Process_IDMSP_Comments_Submitted
    btn_Process_IDMSP_Technically_Cleared.Text = x4.Process_IDMSP_Technically_Cleared
    btn_Process_IDMSP_Transmittal_Issued.Text = x4.Process_IDMSP_Transmittal_Issued
    btn_Process_IDMSP_Superceded.Text = x4.Process_IDMSP_Superceded
    btn_Process_IDMSP_Closed.Text = x4.Process_IDMSP_Closed

    btn_Mechanical_IDMSP_Total_Count.Text = x4.Mechanical_IDMSP_Total_Count
    btn_Mechanical_IDMSP_Submitted.Text = x4.Mechanical_IDMSP_Submitted
    btn_Mechanical_IDMSP_Document_linked.Text = x4.Mechanical_IDMSP_Document_linked
    btn_Mechanical_IDMSP_Under_Evaluation.Text = x4.Mechanical_IDMSP_Under_Evaluation
    btn_Mechanical_IDMSP_Comments_Submitted.Text = x4.Mechanical_IDMSP_Comments_Submitted
    btn_Mechanical_IDMSP_Technically_Cleared.Text = x4.Mechanical_IDMSP_Technically_Cleared
    btn_Mechanical_IDMSP_Transmittal_Issued.Text = x4.Mechanical_IDMSP_Transmittal_Issued
    btn_Mechanical_IDMSP_Superceded.Text = x4.Mechanical_IDMSP_Superceded
    btn_Mechanical_IDMSP_Closed.Text = x4.Mechanical_IDMSP_Closed

    btn_Structure_IDMSP_Total_Count.Text = x4.Structure_IDMSP_Total_Count
    btn_Structure_IDMSP_Submitted.Text = x4.Structure_IDMSP_Submitted
    btn_Structure_IDMSP_Document_linked.Text = x4.Structure_IDMSP_Document_linked
    btn_Structure_IDMSP_Under_Evaluation.Text = x4.Structure_IDMSP_Under_Evaluation
    btn_Structure_IDMSP_Comments_Submitted.Text = x4.Structure_IDMSP_Comments_Submitted
    btn_Structure_IDMSP_Technically_Cleared.Text = x4.Structure_IDMSP_Technically_Cleared
    btn_Structure_IDMSP_Transmittal_Issued.Text = x4.Structure_IDMSP_Transmittal_Issued
    btn_Structure_IDMSP_Superceded.Text = x4.Structure_IDMSP_Superceded
    btn_Structure_IDMSP_Closed.Text = x4.Structure_IDMSP_Closed

    btn_Electrical_IDMSP_Total_Count.Text = x4.Electrical_IDMSP_Total_Count
    btn_Electrical_IDMSP_Submitted.Text = x4.Electrical_IDMSP_Submitted
    btn_Electrical_IDMSP_Document_linked.Text = x4.Electrical_IDMSP_Document_linked
    btn_Electrical_IDMSP_Under_Evaluation.Text = x4.Electrical_IDMSP_Under_Evaluation
    btn_Electrical_IDMSP_Comments_Submitted.Text = x4.Electrical_IDMSP_Comments_Submitted
    btn_Electrical_IDMSP_Technically_Cleared.Text = x4.Electrical_IDMSP_Technically_Cleared
    btn_Electrical_IDMSP_Transmittal_Issued.Text = x4.Electrical_IDMSP_Transmittal_Issued
    btn_Electrical_IDMSP_Superceded.Text = x4.Electrical_IDMSP_Superceded
    btn_Electrical_IDMSP_Closed.Text = x4.Electrical_IDMSP_Closed

    btn_Piping_IDMSP_Total_Count.Text = x4.Piping_IDMSP_Total_Count
    btn_Piping_IDMSP_Submitted.Text = x4.Piping_IDMSP_Submitted
    btn_Piping_IDMSP_Document_linked.Text = x4.Piping_IDMSP_Document_linked
    btn_Piping_IDMSP_Under_Evaluation.Text = x4.Piping_IDMSP_Under_Evaluation
    btn_Piping_IDMSP_Comments_Submitted.Text = x4.Piping_IDMSP_Comments_Submitted
    btn_Piping_IDMSP_Technically_Cleared.Text = x4.Piping_IDMSP_Technically_Cleared
    btn_Piping_IDMSP_Transmittal_Issued.Text = x4.Piping_IDMSP_Transmittal_Issued
    btn_Piping_IDMSP_Superceded.Text = x4.Piping_IDMSP_Superceded
    btn_Piping_IDMSP_Closed.Text = x4.Piping_IDMSP_Closed

    btn_Others_IDMSP_Total_Count.Text = x4.Others_IDMSP_Total_Count
    btn_Others_IDMSP_Submitted.Text = x4.Others_IDMSP_Submitted
    btn_Others_IDMSP_Document_linked.Text = x4.Others_IDMSP_Document_linked
    btn_Others_IDMSP_Under_Evaluation.Text = x4.Others_IDMSP_Under_Evaluation
    btn_Others_IDMSP_Comments_Submitted.Text = x4.Others_IDMSP_Comments_Submitted
    btn_Others_IDMSP_Technically_Cleared.Text = x4.Others_IDMSP_Technically_Cleared
    btn_Others_IDMSP_Transmittal_Issued.Text = x4.Others_IDMSP_Transmittal_Issued
    btn_Others_IDMSP_Superceded.Text = x4.Others_IDMSP_Superceded
    btn_Others_IDMSP_Closed.Text = x4.Others_IDMSP_Closed

    btn_CI_IDMSP_Total_Count.Text = x4.CI_IDMSP_Total_Count
    btn_CI_IDMSP_Submitted.Text = x4.CI_IDMSP_Submitted
    btn_CI_IDMSP_Document_linked.Text = x4.CI_IDMSP_Document_linked
    btn_CI_IDMSP_Under_Evaluation.Text = x4.CI_IDMSP_Under_Evaluation
    btn_CI_IDMSP_Comments_Submitted.Text = x4.CI_IDMSP_Comments_Submitted
    btn_CI_IDMSP_Technically_Cleared.Text = x4.CI_IDMSP_Technically_Cleared
    btn_CI_IDMSP_Transmittal_Issued.Text = x4.CI_IDMSP_Transmittal_Issued
    btn_CI_IDMSP_Superceded.Text = x4.CI_IDMSP_Superceded
    btn_CI_IDMSP_Closed.Text = x4.CI_IDMSP_Closed

    btn_Total_IDMSP_Total_Count.Text = x4.Total_IDMSP_Total_Count
    btn_Total_IDMSP_Submitted.Text = x4.Total_IDMSP_Submitted
    btn_Total_IDMSP_Document_linked.Text = x4.Total_IDMSP_Document_linked
    btn_Total_IDMSP_Under_Evaluation.Text = x4.Total_IDMSP_Under_Evaluation
    btn_Total_IDMSP_Comments_Submitted.Text = x4.Total_IDMSP_Comments_Submitted
    btn_Total_IDMSP_Technically_Cleared.Text = x4.Total_IDMSP_Technically_Cleared
    btn_Total_IDMSP_Transmittal_Issued.Text = x4.Total_IDMSP_Transmittal_Issued
    btn_Total_IDMSP_Superceded.Text = x4.Total_IDMSP_Superceded
    btn_Total_IDMSP_Closed.Text = x4.Total_IDMSP_Closed

    Dim x5 As SIS.CT.CTChart = SIS.CT.CTChart.GetIDMSODB(ProjectID)

    btn_Process_IDMSO_Total_Count.Text = x5.Process_IDMSO_Total_Count
    btn_Process_IDMSO_Submitted.Text = x5.Process_IDMSO_Submitted
    btn_Process_IDMSO_Document_linked.Text = x5.Process_IDMSO_Document_linked
    btn_Process_IDMSO_Under_Evaluation.Text = x5.Process_IDMSO_Under_Evaluation
    btn_Process_IDMSO_Comments_Submitted.Text = x5.Process_IDMSO_Comments_Submitted
    btn_Process_IDMSO_Technically_Cleared.Text = x5.Process_IDMSO_Technically_Cleared
    btn_Process_IDMSO_Transmittal_Issued.Text = x5.Process_IDMSO_Transmittal_Issued
    btn_Process_IDMSO_Superceded.Text = x5.Process_IDMSO_Superceded
    btn_Process_IDMSO_Closed.Text = x5.Process_IDMSO_Closed

    btn_Mechanical_IDMSO_Total_Count.Text = x5.Mechanical_IDMSO_Total_Count
    btn_Mechanical_IDMSO_Submitted.Text = x5.Mechanical_IDMSO_Submitted
    btn_Mechanical_IDMSO_Document_linked.Text = x5.Mechanical_IDMSO_Document_linked
    btn_Mechanical_IDMSO_Under_Evaluation.Text = x5.Mechanical_IDMSO_Under_Evaluation
    btn_Mechanical_IDMSO_Comments_Submitted.Text = x5.Mechanical_IDMSO_Comments_Submitted
    btn_Mechanical_IDMSO_Technically_Cleared.Text = x5.Mechanical_IDMSO_Technically_Cleared
    btn_Mechanical_IDMSO_Transmittal_Issued.Text = x5.Mechanical_IDMSO_Transmittal_Issued
    btn_Mechanical_IDMSO_Superceded.Text = x5.Mechanical_IDMSO_Superceded
    btn_Mechanical_IDMSO_Closed.Text = x5.Mechanical_IDMSO_Closed

    btn_Structure_IDMSO_Total_Count.Text = x5.Structure_IDMSO_Total_Count
    btn_Structure_IDMSO_Submitted.Text = x5.Structure_IDMSO_Submitted
    btn_Structure_IDMSO_Document_linked.Text = x5.Structure_IDMSO_Document_linked
    btn_Structure_IDMSO_Under_Evaluation.Text = x5.Structure_IDMSO_Under_Evaluation
    btn_Structure_IDMSO_Comments_Submitted.Text = x5.Structure_IDMSO_Comments_Submitted
    btn_Structure_IDMSO_Technically_Cleared.Text = x5.Structure_IDMSO_Technically_Cleared
    btn_Structure_IDMSO_Transmittal_Issued.Text = x5.Structure_IDMSO_Transmittal_Issued
    btn_Structure_IDMSO_Superceded.Text = x5.Structure_IDMSO_Superceded
    btn_Structure_IDMSO_Closed.Text = x5.Structure_IDMSO_Closed

    btn_Electrical_IDMSO_Total_Count.Text = x5.Electrical_IDMSO_Total_Count
    btn_Electrical_IDMSO_Submitted.Text = x5.Electrical_IDMSO_Submitted
    btn_Electrical_IDMSO_Document_linked.Text = x5.Electrical_IDMSO_Document_linked
    btn_Electrical_IDMSO_Under_Evaluation.Text = x5.Electrical_IDMSO_Under_Evaluation
    btn_Electrical_IDMSO_Comments_Submitted.Text = x5.Electrical_IDMSO_Comments_Submitted
    btn_Electrical_IDMSO_Technically_Cleared.Text = x5.Electrical_IDMSO_Technically_Cleared
    btn_Electrical_IDMSO_Transmittal_Issued.Text = x5.Electrical_IDMSO_Transmittal_Issued
    btn_Electrical_IDMSO_Superceded.Text = x5.Electrical_IDMSO_Superceded
    btn_Electrical_IDMSO_Closed.Text = x5.Electrical_IDMSO_Closed

    btn_Piping_IDMSO_Total_Count.Text = x5.Piping_IDMSO_Total_Count
    btn_Piping_IDMSO_Submitted.Text = x5.Piping_IDMSO_Submitted
    btn_Piping_IDMSO_Document_linked.Text = x5.Piping_IDMSO_Document_linked
    btn_Piping_IDMSO_Under_Evaluation.Text = x5.Piping_IDMSO_Under_Evaluation
    btn_Piping_IDMSO_Comments_Submitted.Text = x5.Piping_IDMSO_Comments_Submitted
    btn_Piping_IDMSO_Technically_Cleared.Text = x5.Piping_IDMSO_Technically_Cleared
    btn_Piping_IDMSO_Transmittal_Issued.Text = x5.Piping_IDMSO_Transmittal_Issued
    btn_Piping_IDMSO_Superceded.Text = x5.Piping_IDMSO_Superceded
    btn_Piping_IDMSO_Closed.Text = x5.Piping_IDMSO_Closed

    btn_Others_IDMSO_Total_Count.Text = x5.Others_IDMSO_Total_Count
    btn_Others_IDMSO_Submitted.Text = x5.Others_IDMSO_Submitted
    btn_Others_IDMSO_Document_linked.Text = x5.Others_IDMSO_Document_linked
    btn_Others_IDMSO_Under_Evaluation.Text = x5.Others_IDMSO_Under_Evaluation
    btn_Others_IDMSO_Comments_Submitted.Text = x5.Others_IDMSO_Comments_Submitted
    btn_Others_IDMSO_Technically_Cleared.Text = x5.Others_IDMSO_Technically_Cleared
    btn_Others_IDMSO_Transmittal_Issued.Text = x5.Others_IDMSO_Transmittal_Issued
    btn_Others_IDMSO_Superceded.Text = x5.Others_IDMSO_Superceded
    btn_Others_IDMSO_Closed.Text = x5.Others_IDMSO_Closed

    btn_CI_IDMSO_Total_Count.Text = x5.CI_IDMSO_Total_Count
    btn_CI_IDMSO_Submitted.Text = x5.CI_IDMSO_Submitted
    btn_CI_IDMSO_Document_linked.Text = x5.CI_IDMSO_Document_linked
    btn_CI_IDMSO_Under_Evaluation.Text = x5.CI_IDMSO_Under_Evaluation
    btn_CI_IDMSO_Comments_Submitted.Text = x5.CI_IDMSO_Comments_Submitted
    btn_CI_IDMSO_Technically_Cleared.Text = x5.CI_IDMSO_Technically_Cleared
    btn_CI_IDMSO_Transmittal_Issued.Text = x5.CI_IDMSO_Transmittal_Issued
    btn_CI_IDMSO_Superceded.Text = x5.CI_IDMSO_Superceded
    btn_CI_IDMSO_Closed.Text = x5.CI_IDMSO_Closed

    btn_Total_IDMSO_Total_Count.Text = x5.Total_IDMSO_Total_Count
    btn_Total_IDMSO_Submitted.Text = x5.Total_IDMSO_Submitted
    btn_Total_IDMSO_Document_linked.Text = x5.Total_IDMSO_Document_linked
    btn_Total_IDMSO_Under_Evaluation.Text = x5.Total_IDMSO_Under_Evaluation
    btn_Total_IDMSO_Comments_Submitted.Text = x5.Total_IDMSO_Comments_Submitted
    btn_Total_IDMSO_Technically_Cleared.Text = x5.Total_IDMSO_Technically_Cleared
    btn_Total_IDMSO_Transmittal_Issued.Text = x5.Total_IDMSO_Transmittal_Issued
    btn_Total_IDMSO_Superceded.Text = x5.Total_IDMSO_Superceded
    btn_Total_IDMSO_Closed.Text = x5.Total_IDMSO_Closed

    'element
    Dim x6 As SIS.CT.CTChart = SIS.CT.CTChart.GetELEMENTDB(ProjectID)

    btn_Process_Element_Total_Active_Element_Count.Text = x6.Process_Element_Total_Active_Element_Count
    btn_Process_Element_Free.Text = x6.Process_Element_Free
    btn_Process_Element_Partial.Text = x6.Process_Element_Partial
    btn_Process_Element_Completed.Text = x6.Process_Element_Completed

    btn_Mechanical_Element_Total_Active_Element_Count.Text = x6.Mechanical_Element_Total_Active_Element_Count
    btn_Mechanical_Element_Free.Text = x6.Mechanical_Element_Free
    btn_Mechanical_Element_Partial.Text = x6.Mechanical_Element_Partial
    btn_Mechanical_Element_Completed.Text = x6.Mechanical_Element_Completed

    btn_Piping_Element_Total_Active_Element_Count.Text = x6.Piping_Element_Total_Active_Element_Count
    btn_Piping_Element_Free.Text = x6.Piping_Element_Free
    btn_Piping_Element_Partial.Text = x6.Piping_Element_Partial
    btn_Piping_Element_Completed.Text = x6.Piping_Element_Completed

    btn_Structure_Element_Total_Active_Element_Count.Text = x6.Structure_Element_Total_Active_Element_Count
    btn_Structure_Element_Free.Text = x6.Structure_Element_Free
    btn_Structure_Element_Partial.Text = x6.Structure_Element_Partial
    btn_Structure_Element_Completed.Text = x6.Structure_Element_Completed


    btn_CI_Element_Total_Active_Element_Count.Text = x6.CI_Element_Total_Active_Element_Count
    btn_CI_Element_Free.Text = x6.CI_Element_Free
    btn_CI_Element_Partial.Text = x6.CI_Element_Partial
    btn_CI_Element_Completed.Text = x6.CI_Element_Completed

    btn_Others_Element_Total_Active_Element_Count.Text = x6.Others_Element_Total_Active_Element_Count
    btn_Others_Element_Free.Text = x6.Others_Element_Free
    btn_Others_Element_Partial.Text = x6.Others_Element_Partial
    btn_Others_Element_Completed.Text = x6.Others_Element_Completed

    btn_Total_Element_Total_Active_Element_Count.Text = x6.Total_Element_Total_Active_Element_Count
    btn_Total_Element_Free.Text = x6.Total_Element_Free
    btn_Total_Element_Partial.Text = x6.Total_Element_Partial
    btn_Total_Element_Completed.Text = x6.Total_Element_Completed

    btn_Electrical_Element_Total_Active_Element_Count.Text = x6.Electrical_Element_Total_Active_Element_Count
    btn_Electrical_Element_Free.Text = x6.Electrical_Element_Free
    btn_Electrical_Element_Partial.Text = x6.Electrical_Element_Partial
    btn_Electrical_Element_Completed.Text = x6.Electrical_Element_Completed

    Dim x7 As SIS.CT.CTChart = SIS.CT.CTChart.GetPSTRANSMITTALDB(ProjectID)

    btn_Process_PSTransmittal_Total_Drawing_Count.Text = x7.Process_PSTransmittal_Total_Count
    btn_Mechanical_PSTransmittal_Total_Drawing_Count.Text = x7.Mechanical_PSTransmittal_Total_Count
    btn_Piping_PSTransmittal_Total_Drawing_Count.Text = x7.Piping_PSTransmittal_Total_Count
    btn_Structure_PSTransmittal_Total_Drawing_Count.Text = x7.Structure_PSTransmittal_Total_Count
    btn_Electrical_PSTransmittal_Total_Drawing_Count.Text = x7.Electrical_PSTransmittal_Total_Count
    btn_CI_PSTransmittal_Total_Drawing_Count.Text = x7.CI_PSTransmittal_Total_Count
    btn_Others_PSTransmittal_Total_Drawing_Count.Text = x7.Others_PSTransmittal_Total_Count
    btn_Total_PSTransmittal_Total_Drawing_Count.Text = x7.Total_PSTransmittal_Total_Count

    btn_Process_PSTransmittal_Pending_Drawing_Count.Text = x7.Process_PSTransmittal_Pending_Count
    btn_Mechanical_PSTransmittal_Pending_Drawing_Count.Text = x7.Mechanical_PSTransmittal_Pending_Count
    btn_Piping_PSTransmittal_Pending_Drawing_Count.Text = x7.Piping_PSTransmittal_Pending_Count
    btn_Structure_PSTransmittal_Pending_Drawing_Count.Text = x7.Structure_PSTransmittal_Pending_Count
    btn_Electrical_PSTransmittal_Pending_Drawing_Count.Text = x7.Electrical_PSTransmittal_Pending_Count
    btn_CI_PSTransmittal_Pending_Drawing_Count.Text = x7.CI_PSTransmittal_Pending_Count
    btn_Others_PSTransmittal_Pending_Drawing_Count.Text = x7.Others_PSTransmittal_Pending_Count
    btn_Total_PSTransmittal_Pending_Drawing_Count.Text = x7.Total_PSTransmittal_Pending_Count

    If (x.Total_Total_Count > 0) Then
      PMDLTABLE.Visible = True
      PMDLTABLE1.Visible = True
      'PMDLDATAD.Visible = True
      PMDLDATAI.Visible = False
    Else
      PMDLTABLE.Visible = True
      PMDLDATAI.Visible = True
      'PMDLDATAD.Visible = False
      PMDLTABLE1.Visible = False
      PMDLDATAI.Text = "No Data Available for -" & ProjectID
    End If
    Try
      'OverallDataTable.InnerHtml = Dt.GetDataTable
    Catch ex As Exception
    End Try
  End Sub

  Private Sub Chart2_PreRender(sender As Object, e As EventArgs) Handles Chart2.PreRender
    If ProjectID = "" Then Exit Sub
    Dim Dt As SIS.CT.CTChart = SIS.CT.CTChart.GetDCTChart(ProjectID)
    If Dt.PlannedX.Length >= 1 Then
      Chart2 = SIS.CT.CTChart.RenderChart2(Chart2, Dt)
      DCRDATA.Visible = False
      DCRTABLE.Visible = True
      DCRDATAI.Visible = False
      DCRTABLE1.Visible = True
    Else
      Chart2.Visible = False
      DCRDATA.Text = "No Data Available for -" & ProjectID
      DCRDATA.Visible = True
      DCRTABLE.Visible = False
      DCRTABLE1.Visible = False
    End If
    Try
      'OverallDataTable.InnerHtml = Dt.GetDataTable
    Catch ex As Exception
    End Try
  End Sub

  Private Sub Chart3_PreRender(sender As Object, e As EventArgs) Handles Chart3.PreRender
    If ProjectID = "" Then Exit Sub
    Dim Dt As SIS.CT.CTChart = SIS.CT.CTChart.GetTCTChart(ProjectID)
    If Dt.PlannedX.Length >= 1 Then
      Chart3 = SIS.CT.CTChart.RenderChart3(Chart3, Dt)
      DTRANMITTALDATA.Visible = False
      TRANSMITTALTABLE.Visible = True
      TRANSMITTALDATAI.Visible = False
      TRANSMITTALTABLE1.Visible = True
      PSTRANSMITTALTABLE.Visible = True
      PSTRANSMITTALDATAI.Visible = False
      PSTRANSMITTALTABLE1.Visible = True


    Else
      Chart3.Visible = False
      DTRANMITTALDATA.Text = "No Data Available for -" & ProjectID
      DTRANMITTALDATA.Visible = True
      TRANSMITTALTABLE.Visible = False

      TRANSMITTALTABLE1.Visible = False
    End If
    Try
      'OverallDataTable.InnerHtml = Dt.GetDataTable
    Catch ex As Exception
    End Try
  End Sub

  Private Sub Chart31_PreRender(sender As Object, e As EventArgs) Handles Chart31.PreRender
    If ProjectID = "" Then Exit Sub
    Dim Dt As SIS.CT.CTChart = SIS.CT.CTChart.GetT1Chart(ProjectID)
    If Dt.PlannedX.Length >= 1 Then
      Chart31 = SIS.CT.CTChart.RenderChart31(Chart31, Dt)
      CUSTOMERTRANSMITTALDATA.Visible = False
    Else
      Chart31.Visible = False
      CUSTOMERTRANSMITTALDATA.Text = "No Data Available for -" & ProjectID
      CUSTOMERTRANSMITTALDATA.Visible = True
    End If
    Try
      'OverallDataTable.InnerHtml = Dt.GetDataTable
    Catch ex As Exception
    End Try
  End Sub
  Private Sub Chart32_PreRender(sender As Object, e As EventArgs) Handles Chart32.PreRender
    If ProjectID = "" Then Exit Sub
    Dim Dt As SIS.CT.CTChart = SIS.CT.CTChart.GetT2Chart(ProjectID)
    If Dt.PlannedX.Length >= 1 Then
      Chart32 = SIS.CT.CTChart.RenderChart32(Chart32, Dt)
      INTERNALTRANSMITTALDATA.Visible = False
    Else
      Chart32.Visible = False
      INTERNALTRANSMITTALDATA.Text = "No Data Available for -" & ProjectID
      INTERNALTRANSMITTALDATA.Visible = True
    End If
    Try
      'OverallDataTable.InnerHtml = Dt.GetDataTable
    Catch ex As Exception
    End Try
  End Sub
  Private Sub Chart33_PreRender(sender As Object, e As EventArgs) Handles Chart33.PreRender
    If ProjectID = "" Then Exit Sub
    Dim Dt As SIS.CT.CTChart = SIS.CT.CTChart.GetT3Chart(ProjectID)
    If Dt.PlannedX.Length >= 1 Then
      Chart33 = SIS.CT.CTChart.RenderChart33(Chart33, Dt)
      SITETRANSMITTALDATA.Visible = False
    Else
      Chart33.Visible = False
      SITETRANSMITTALDATA.Text = "No Data Available for -" & ProjectID
      SITETRANSMITTALDATA.Visible = True
    End If
    Try
      'OverallDataTable.InnerHtml = Dt.GetDataTable
    Catch ex As Exception
    End Try
  End Sub
  Private Sub Chart34_PreRender(sender As Object, e As EventArgs) Handles Chart34.PreRender
    If ProjectID = "" Then Exit Sub
    Dim Dt As SIS.CT.CTChart = SIS.CT.CTChart.GetT4Chart(ProjectID)
    If Dt.PlannedX.Length >= 1 Then
      Chart34 = SIS.CT.CTChart.RenderChart34(Chart34, Dt)
      VENDORTRANSMITTALDATA.Visible = False
    Else
      Chart34.Visible = False
      VENDORTRANSMITTALDATA.Text = "No Data Available for -" & ProjectID
      VENDORTRANSMITTALDATA.Visible = True
    End If
    Try
      'OverallDataTable.InnerHtml = Dt.GetDataTable
    Catch ex As Exception
    End Try
  End Sub

  Private Sub Chart4_PreRender(sender As Object, e As EventArgs) Handles Chart4.PreRender
    If ProjectID = "" Then Exit Sub
    Dim Dt As SIS.CT.CTChart = SIS.CT.CTChart.GetSCTChart(ProjectID)
    If Dt.PlannedX.Length >= 1 Then
      Chart4 = SIS.CT.CTChart.RenderChart4(Chart4, Dt)
      SARDATA.Visible = False
      SARDATAI.Visible = False
      SARTABLE.Visible = True
      SARTABLE1.Visible = True
    Else
      Chart4.Visible = False
      sardata.Text = "No Data Available for -" & ProjectID
      SARDATA.Visible = True
      SARTABLE.Visible = False
      SARTABLE1.Visible = False
    End If

    Try
      'OverallDataTable.InnerHtml = Dt.GetDataTable
    Catch ex As Exception
    End Try
  End Sub


  Private Sub Chart5_PreRender(sender As Object, e As EventArgs) Handles Chart5.PreRender
    If ProjectID = "" Then Exit Sub
    Dim Dt As SIS.CT.CTChart = SIS.CT.CTChart.GetPCTChart(ProjectID)


    If Dt.PlannedX.Length >= 1 Then
      Chart5 = SIS.CT.CTChart.RenderChart5(Chart5, Dt)
      IDMSP.Visible = False
      IDMSPTABLE.Visible = True
      IDMSPDATAI.Visible = False
      IDMSPTABLE1.Visible = True
    Else
      Chart5.Visible = False
      IDMSP.Text = "No Data Available for -" & ProjectID
      IDMSP.Visible = True
      IDMSPTABLE.Visible = False

      IDMSPTABLE1.Visible = False
    End If


    '  Chart5.Visible = False
    Try
      'OverallDataTable.InnerHtml = Dt.GetDataTable
    Catch ex As Exception
    End Try
  End Sub



  Private Sub Chart6_PreRender(sender As Object, e As EventArgs) Handles Chart6.PreRender
    If ProjectID = "" Then Exit Sub
    Dim Dt As SIS.CT.CTChart = SIS.CT.CTChart.GetOCTChart(ProjectID)
    If Dt.PlannedX.Length >= 1 Then
      Chart6 = SIS.CT.CTChart.RenderChart6(Chart6, Dt)
      IDMSO.Visible = False
      IDMSOTABLE.Visible = True
      IDMSODATAI.Visible = False
      IDMSOTABLE1.Visible = True
    Else
      Chart6.Visible = False
      IDMSO.Text = "No Data Available for -" & ProjectID
      IDMSO.Visible = True
      IDMSOTABLE.Visible = False
      IDMSOTABLE1.Visible = False
    End If
    Try
      'OverallDataTable.InnerHtml = Dt.GetDataTable
    Catch ex As Exception
    End Try
  End Sub



  Private Sub Chart7_PreRender(sender As Object, e As EventArgs) Handles Chart7.PreRender
    If ProjectID = "" Then Exit Sub
    Dim Dt As SIS.CT.CTChart = SIS.CT.CTChart.GetECTChart(ProjectID)
    If Dt.PlannedX.Length >= 1 Then
      Chart7 = SIS.CT.CTChart.RenderChart7(Chart7, Dt)
      ELEMENTDATA.Visible = False
      ELEMENTTABLE.Visible = True
      ELEMENTDATAI.Visible = False
      ELEMENTTABLE1.Visible = True
    Else
      Chart7.Visible = False
      ELEMENTDATA.Text = "No Data Available for -" & ProjectID
      ELEMENTDATA.Visible = True
      ELEMENTTABLE.Visible = False
      ELEMENTTABLE1.Visible = False
    End If
    Try
      'OverallDataTable.InnerHtml = Dt.GetDataTable
    Catch ex As Exception
    End Try
  End Sub

  Private Sub Chart8_PreRender(sender As Object, e As EventArgs) Handles Chart8.PreRender
    If ProjectID = "" Then Exit Sub
    Dim Dt As SIS.CT.CTChart = SIS.CT.CTChart.GetTTTChart(ProjectID)
    If Dt.PlannedX.Length >= 1 Then
      Chart8 = SIS.CT.CTChart.RenderChart8(Chart8, Dt)
      ITRANSMITTALDATA.Visible = False
    Else
      Chart8.Visible = False
      ITRANSMITTALDATA.Text = "No Data Available for -" & ProjectID
      ITRANSMITTALDATA.Visible = True
    End If
    Try
      'OverallDataTable.InnerHtml = Dt.GetDataTable
    Catch ex As Exception
    End Try
  End Sub

  Private Sub Chart34_Click(sender As Object, e As ImageMapEventArgs) Handles Chart34.Click
    MsgBox("hello")
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Process_Total&PrjID=" & F_t_cprj.Text)
  End Sub


  Private Sub Chart10_PreRender(sender As Object, e As EventArgs) Handles Chart10.PreRender
    If ProjectID = "" Then Exit Sub
    Dim Dt As SIS.CT.CTChart = SIS.CT.CTChart.GetHCTChart(ProjectID)
    If Dt.PlannedX.Length >= 1 Then
      Chart10 = SIS.CT.CTChart.RenderChart10(Chart10, Dt)
      HOLDDATA.Visible = False
      'HOLDTABLE.Visible = True
      'HOLDDATAI.Visible = False
      ' ELEMENTTABLE1.Visible = True
    Else
      Chart10.Visible = False
      HOLDDATA.Text = "No Data Available for -" & ProjectID
      HOLDDATA.Visible = True
      ' HOLDTABLE.Visible = False
      ' HOLDTABLE1.Visible = False
    End If
    Try
      'OverallDataTable.InnerHtml = Dt.GetDataTable
    Catch ex As Exception
    End Try
  End Sub

  Private Sub Chart11_PreRender(sender As Object, e As EventArgs) Handles Chart11.PreRender
    If ProjectID = "" Then Exit Sub
    Dim Dt As SIS.CT.CTChart = SIS.CT.CTChart.GetHCTChart1(ProjectID)
    If Dt.PlannedX.Length >= 1 Then
      Chart11 = SIS.CT.CTChart.RenderChart11(Chart11, Dt)
      HOLD1DATA.Visible = False
      'HOLDTABLE.Visible = True
      'HOLDDATAI.Visible = False
      ' ELEMENTTABLE1.Visible = True
    Else
      Chart11.Visible = False
      HOLD1DATA.Text = "No Data Available for -" & ProjectID
      HOLD1DATA.Visible = True
      ' HOLDTABLE.Visible = False
      ' HOLDTABLE1.Visible = False
    End If
    Try
      'OverallDataTable.InnerHtml = Dt.GetDataTable
    Catch ex As Exception
    End Try
  End Sub
  Private Sub cmdSubmit_Click(sender As Object, e As EventArgs) Handles cmdSubmit.Click
    image1.Visible = False
    image2.Visible = False
    imagetext.Visible = False
    imageline1.Visible = False
    imageline2.Visible = False
    PDetails.Visible = True
    ' PMDLTABLE.Visible = True
    C1.Visible = True
    C2.Visible = True
    C3.Visible = True
    C4.Visible = True
    C5.Visible = True
    C6.Visible = True
    C7.Visible = True
    C8.Visible = True
    C9.Visible = True
    C10.Visible = True
    C11.Visible = True
    ' C12.Visible = True
    line1.Visible = True
    line2.Visible = True
    line3.Visible = True
    line4.Visible = True
    line5.Visible = True
    line6.Visible = True
    line7.Visible = True
    line8.Visible = True
    line9.Visible = True
    line10.Visible = True
    line11.Visible = True
    line12.Visible = True
    line13.Visible = True
    line14.Visible = True
    line15.Visible = True




  End Sub

  Private Sub btn_Process_Total_Count_Click(sender As Object, e As EventArgs) Handles btn_Process_Total_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Process_Total&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Mechanical_Total_Count_Click(sender As Object, e As EventArgs) Handles btn_Mechanical_Total_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Mechanical_Total&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Structure_Total_Count_Click(sender As Object, e As EventArgs) Handles btn_Structure_Total_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Structure_Total&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Piping_Total_Count_Click(sender As Object, e As EventArgs) Handles btn_Piping_Total_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Piping_Total&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Electrical_Total_Count_Click(sender As Object, e As EventArgs) Handles btn_Electrical_Total_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Electrical_Total&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_CI_Total_Count_Click(sender As Object, e As EventArgs) Handles btn_CI_Total_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=CI_Total&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Total_Total_Count_Click(sender As Object, e As EventArgs) Handles btn_Total_Total_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Total_Total&PrjID=" & F_t_cprj.Text)
  End Sub


  Private Sub btn_Process_Released_Count_Click(sender As Object, e As EventArgs) Handles btn_Process_Release_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Process_Released&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Mechanical_Released_Count_Click(sender As Object, e As EventArgs) Handles btn_Mechanical_Release_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Mechanical_Released&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Structure_Released_Count_Click(sender As Object, e As EventArgs) Handles btn_Structure_Release_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Structure_Released&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Piping_Released_Count_Click(sender As Object, e As EventArgs) Handles btn_Piping_Release_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Piping_Released&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Electrical_Released_Count_Click(sender As Object, e As EventArgs) Handles btn_Electrical_Release_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Electrical_Released&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_CI_Released_Count_Click(sender As Object, e As EventArgs) Handles btn_CI_Release_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=CI_Released&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Total_Released_Count_Click(sender As Object, e As EventArgs) Handles btn_Total_Release_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Total_Released&PrjID=" & F_t_cprj.Text)
  End Sub


  Private Sub btn_Process_Pending_Count_Click(sender As Object, e As EventArgs) Handles btn_Process_Pending_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Process_Pending&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Mechanical_Pending_Count_Click(sender As Object, e As EventArgs) Handles btn_Mechanical_Pending_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Mechanical_Pending&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Structure_Pending_Count_Click(sender As Object, e As EventArgs) Handles btn_Structure_Pending_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Structure_Pending&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Piping_Pending_Count_Click(sender As Object, e As EventArgs) Handles btn_Piping_Pending_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Piping_Pending&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Electrical_Pending_Count_Click(sender As Object, e As EventArgs) Handles btn_Electrical_Pending_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Electrical_Pending&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_CI_Pending_Count_Click(sender As Object, e As EventArgs) Handles btn_CI_Pending_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=CI_Pending&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Total_Pending_Count_Click(sender As Object, e As EventArgs) Handles btn_Total_Pending_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Total_Pending&PrjID=" & F_t_cprj.Text)
  End Sub


  Private Sub btn_Process_Ontime_Count_Click(sender As Object, e As EventArgs) Handles btn_Process_Ontime_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Process_Ontime&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Mechanical_Ontime_Count_Click(sender As Object, e As EventArgs) Handles btn_Mechanical_Ontime_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Mechanical_Ontime&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Structure_Ontime_Count_Click(sender As Object, e As EventArgs) Handles btn_Structure_Ontime_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Structure_Ontime&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Piping_Ontime_Count_Click(sender As Object, e As EventArgs) Handles btn_Piping_Ontime_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Piping_Ontime&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Electrical_Ontime_Count_Click(sender As Object, e As EventArgs) Handles btn_Electrical_Ontime_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Electrical_Ontime&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_CI_Ontime_Count_Click(sender As Object, e As EventArgs) Handles btn_CI_Ontime_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=CI_Ontime&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Total_Ontime_Count_Click(sender As Object, e As EventArgs) Handles btn_Total_Ontime_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Total_Ontime&PrjID=" & F_t_cprj.Text)
  End Sub


  Private Sub btn_Process_Delayed_Count_Click(sender As Object, e As EventArgs) Handles btn_Process_Delayed_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Process_Delayed&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Mechanical_Delayed_Count_Click(sender As Object, e As EventArgs) Handles btn_Mechanical_Delayed_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Mechanical_Delayed&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Structure_Delayed_Count_Click(sender As Object, e As EventArgs) Handles btn_Structure_Delayed_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Structure_Delayed&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Piping_Delayed_Count_Click(sender As Object, e As EventArgs) Handles btn_piping_Delayed_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Piping_Delayed&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Electrical_Delayed_Count_Click(sender As Object, e As EventArgs) Handles btn_Electrical_Delayed_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Electrical_Delayed&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_CI_Delayed_Count_Click(sender As Object, e As EventArgs) Handles btn_CI_Delayed_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=CI_Delayed&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Total_Delayed_Count_Click(sender As Object, e As EventArgs) Handles btn_Total_Delayed_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Total_Delayed&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Process_Due_Count_Click(sender As Object, e As EventArgs) Handles btn_Process_Due_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Process_Due&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Mechanical_Due_Count_Click(sender As Object, e As EventArgs) Handles btn_Mechanical_Due_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Mechanical_Due&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Structure_Due_Count_Click(sender As Object, e As EventArgs) Handles btn_Structure_Due_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Structure_Due&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Piping_Due_Count_Click(sender As Object, e As EventArgs) Handles btn_Piping_Due_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Piping_Due&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Electrical_Due_Count_Click(sender As Object, e As EventArgs) Handles btn_Electrical_Due_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Electrical_Due&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_CI_Due_Count_Click(sender As Object, e As EventArgs) Handles btn_CI_Due_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=CI_Due&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Total_Due_Count_Click(sender As Object, e As EventArgs) Handles btn_Total_Due_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Total_Due&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub PLMCHART_Load(sender As Object, e As EventArgs) Handles PLMCHART.Load
    PLMCHART.HRef = "GF_ProjectDBDetails.aspx?detail=PLM_CHART&PrjID=" & F_t_cprj.Text
  End Sub

  Private Sub DCRCHART_Load(sender As Object, e As EventArgs) Handles DCRCHART.Load
    DCRCHART.HRef = "GF_ProjectDBDetails.aspx?detail=DCR_CHART&PrjID=" & F_t_cprj.Text
  End Sub

  Private Sub IDMSCHART_Load(sender As Object, e As EventArgs) Handles IDMSCHART.Load
    IDMSCHART.HRef = "GF_ProjectDBDetails.aspx?detail=IDMS_CHART&PrjID=" & F_t_cprj.Text
  End Sub

  Private Sub IDMSCCHART_Load(sender As Object, e As EventArgs) Handles IDMSCCHART.Load
    IDMSCCHART.HRef = "GF_ProjectDBDetails.aspx?detail=IDMSC_CHART&PrjID=" & F_t_cprj.Text
  End Sub

  Private Sub IDMSICHART_Load(sender As Object, e As EventArgs) Handles IDMSICHART.Load
    IDMSICHART.HRef = "GF_ProjectDBDetails.aspx?detail=IDMSI_CHART&PrjID=" & F_t_cprj.Text
  End Sub

  Private Sub IDMSSCHART_Load(sender As Object, e As EventArgs) Handles IDMSSCHART.Load
    IDMSSCHART.HRef = "GF_ProjectDBDetails.aspx?detail=IDMSS_CHART&PrjID=" & F_t_cprj.Text
  End Sub

  Private Sub IDMSVCHART_Load(sender As Object, e As EventArgs) Handles IDMSVCHART.Load
     IDMSVCHART.HRef = "GF_ProjectDBDetails.aspx?detail=IDMSV_CHART&PrjID=" & F_t_cprj.Text
  End Sub

  Private Sub SARCHART_Load(sender As Object, e As EventArgs) Handles SARCHART.Load
    SARCHART.HRef = "GF_ProjectDBDetails.aspx?detail=SAR_CHART&PrjID=" & F_t_cprj.Text
  End Sub

  Private Sub IDMSPCHART_Load(sender As Object, e As EventArgs) Handles IDMSPCHART.Load
    IDMSPCHART.HRef = "GF_ProjectDBDetails.aspx?detail=IDMSP_CHART&PrjID=" & F_t_cprj.Text
  End Sub

  Private Sub IDMSOCHART_Load(sender As Object, e As EventArgs) Handles IDMSOCHART.Load
    IDMSOCHART.HRef = "GF_ProjectDBDetails.aspx?detail=IDMSO_CHART&PrjID=" & F_t_cprj.Text
  End Sub

  Private Sub ELEMENTCHART_Load(sender As Object, e As EventArgs) Handles ELEMENTCHART.Load
    ELEMENTCHART.HRef = "GF_ProjectDBDetails.aspx?detail=ELEMENT_CHART&PrjID=" & F_t_cprj.Text
  End Sub

  Private Sub HOLDCHART_Load(sender As Object, e As EventArgs) Handles HOLDCHART.Load
    HOLDCHART.HRef = "GF_ProjectDBDetails.aspx?detail=HOLD_CHART&PrjID=" & F_t_cprj.Text
  End Sub

  Private Sub HOLDCHART1_Load(sender As Object, e As EventArgs) Handles HOLDCHART1.Load
    HOLDCHART1.HRef = "GF_ProjectDBDetails.aspx?detail=HOLD_CHART1&PrjID=" & F_t_cprj.Text
  End Sub



  Private Sub IDMSIICHART_Load(sender As Object, e As EventArgs) Handles IDMSIICHART.Load
    IDMSIICHART.HRef = "GF_ProjectDBDetails.aspx?detail=IDMSII_CHART&PrjID=" & F_t_cprj.Text
  End Sub

  Private Sub btn_Process_DCR_Total_Count_Click(sender As Object, e As EventArgs) Handles btn_Process_DCR_Total_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Process_DCR_Total_Count&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Mechanical_DCR_Total_Count_Click(sender As Object, e As EventArgs) Handles btn_Mechanical_DCR_Total_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Mechanical_DCR_Total_Count&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Structure_DCR_Total_Count_Click(sender As Object, e As EventArgs) Handles btn_Structure_DCR_Total_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Structure_DCR_Total_Count&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Piping_DCR_Total_Count_Click(sender As Object, e As EventArgs) Handles btn_Piping_DCR_Total_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Piping_DCR_Total_Count&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_CI_DCR_Total_Count_Click(sender As Object, e As EventArgs) Handles btn_CI_DCR_Total_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=CI_DCR_Total_Count&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Others_DCR_Total_Count_Click(sender As Object, e As EventArgs) Handles btn_Others_DCR_Total_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Others_DCR_Total_Count&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Total_DCR_Total_Count_Click(sender As Object, e As EventArgs) Handles btn_Total_DCR_Total_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Total_DCR_Total_Count&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Process_DCR_Under_Creation_Click(sender As Object, e As EventArgs) Handles btn_Process_DCR_Under_Creation.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Process_DCR_Under_Creation&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Mechanical_DCR_Under_Creation_Click(sender As Object, e As EventArgs) Handles btn_Mechanical_DCR_Under_Creation.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Mechanical_DCR_Under_Creation&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Structure_DCR_Under_Creation_Click(sender As Object, e As EventArgs) Handles btn_Structure_DCR_Under_Creation.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Structure_DCR_Under_Creation&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Piping_DCR_Under_Creation_Click(sender As Object, e As EventArgs) Handles btn_Piping_DCR_Under_Creation.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Piping_DCR_Under_Creation&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_CI_DCR_Under_Creation_Click(sender As Object, e As EventArgs) Handles btn_CI_DCR_Under_Creation.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=CI_DCR_Under_Creation&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Others_DCR_Under_Creation_Click(sender As Object, e As EventArgs) Handles btn_Others_DCR_Under_Creation.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Others_DCR_Under_Creation&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Total_DCR_Under_Creation_Click(sender As Object, e As EventArgs) Handles btn_Total_DCR_Under_Creation.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Total_DCR_Under_Creation&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Process_DCR_Under_Approval_Click(sender As Object, e As EventArgs) Handles btn_Process_DCR_Under_Approval.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Process_DCR_Under_Approval&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Mechanical_DCR_Under_Approval_Click(sender As Object, e As EventArgs) Handles btn_Mechanical_DCR_Under_Approval.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Mechanical_DCR_Under_Approval&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Structure_DCR_Under_Approval_Click(sender As Object, e As EventArgs) Handles btn_Structure_DCR_Under_Approval.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Structure_DCR_Under_Approval&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Piping_DCR_Under_Approval_Click(sender As Object, e As EventArgs) Handles btn_Piping_DCR_Under_Approval.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Piping_DCR_Under_Approval&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_CI_DCR_Under_Approval_Click(sender As Object, e As EventArgs) Handles btn_CI_DCR_Under_Approval.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=CI_DCR_Under_Approval&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Others_DCR_Under_Approval_Click(sender As Object, e As EventArgs) Handles btn_Others_DCR_Under_Approval.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Others_DCR_Under_Approval&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Total_DCR_Under_Approval_Click(sender As Object, e As EventArgs) Handles btn_Total_DCR_Under_Approval.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Total_DCR_Under_Approval&PrjID=" & F_t_cprj.Text)
  End Sub


  Private Sub btn_Process_DCR_Approved_Click(sender As Object, e As EventArgs) Handles btn_Process_DCR_Approved.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Process_DCR_Approved&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Mechanical_DCR_Approved_Click(sender As Object, e As EventArgs) Handles btn_Mechanical_DCR_Approved.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Mechanical_DCR_Approved&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Structure_DCR_Approved_Click(sender As Object, e As EventArgs) Handles btn_Structure_DCR_Approved.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Structure_DCR_Approved&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Piping_DCR_Approved_Click(sender As Object, e As EventArgs) Handles btn_Piping_DCR_Approved.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Piping_DCR_Approved&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_CI_DCR_Approved_Click(sender As Object, e As EventArgs) Handles btn_CI_DCR_Approved.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=CI_DCR_Approved&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Others_DCR_Approved_Click(sender As Object, e As EventArgs) Handles btn_Others_DCR_Approved.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Others_DCR_Approved&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Total_DCR_Approved_Click(sender As Object, e As EventArgs) Handles btn_Total_DCR_Approved.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Total_DCR_Approved&PrjID=" & F_t_cprj.Text)
  End Sub



  Private Sub btn_Process_Transmittal_Total_Count_Click(sender As Object, e As EventArgs) Handles btn_Process_Transmittal_Total_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Process_Transmittal_Total_Count&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Mechanical_Transmittal_Total_Count_Click(sender As Object, e As EventArgs) Handles btn_Mechanical_Transmittal_Total_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Mechanical_Transmittal_Total_Count&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Structure_Transmittal_Total_Count_Click(sender As Object, e As EventArgs) Handles btn_Structure_Transmittal_Total_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Structure_Transmittal_Total_Count&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Piping_Transmittal_Total_Count_Click(sender As Object, e As EventArgs) Handles btn_Piping_Transmittal_Total_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Piping_Transmittal_Total_Count&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Electrical_Transmittal_Total_Count_Click(sender As Object, e As EventArgs) Handles btn_Electrical_Transmittal_Total_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Electrical_Transmittal_Total_Count&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_CI_Transmittal_Total_Count_Click(sender As Object, e As EventArgs) Handles btn_CI_Transmittal_Total_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=CI_Transmittal_Total_Count&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Others_Transmittal_Total_Count_Click(sender As Object, e As EventArgs) Handles btn_Others_Transmittal_Total_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Others_Transmittal_Total_Count&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Total_Transmittal_Total_Count_Click(sender As Object, e As EventArgs) Handles btn_Total_Transmittal_Total_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Total_Transmittal_Total_Count&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Process_Transmittal_Free_Click(sender As Object, e As EventArgs) Handles btn_Process_Transmittal_Free.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Process_Transmittal_Free&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Mechanical_Transmittal_Free_Click(sender As Object, e As EventArgs) Handles btn_Mechanical_Transmittal_Free.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Mechanical_Transmittal_Free&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Structure_Transmittal_Free_Click(sender As Object, e As EventArgs) Handles btn_Structure_Transmittal_Free.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Structure_Transmittal_Free&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Piping_Transmittal_Free_Click(sender As Object, e As EventArgs) Handles btn_Piping_Transmittal_Free.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Piping_Transmittal_Free&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Electrical_Transmittal_Free_Click(sender As Object, e As EventArgs) Handles btn_Electrical_Transmittal_Free.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Electrical_Transmittal_Free&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_CI_Transmittal_Free_Click(sender As Object, e As EventArgs) Handles btn_CI_Transmittal_Free.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=CI_Transmittal_Free&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Others_Transmittal_Free_Click(sender As Object, e As EventArgs) Handles btn_Others_Transmittal_Free.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Others_Transmittal_Free&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Total_Transmittal_Free_Click(sender As Object, e As EventArgs) Handles btn_Total_Transmittal_Free.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Total_Transmittal_Free&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Process_Transmittal_Under_Approval_Click(sender As Object, e As EventArgs) Handles btn_Process_Transmittal_Under_Approval.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Process_Transmittal_Under_Approval&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Mechanical_Transmittal_Under_Approval_Click(sender As Object, e As EventArgs) Handles btn_Mechanical_Transmittal_Under_Approval.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Mechanical_Transmittal_Under_Approval&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Structure_Transmittal_Under_Approval_Click(sender As Object, e As EventArgs) Handles btn_Structure_Transmittal_Under_Approval.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Structure_Transmittal_Under_Approval&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Piping_Transmittal_Under_Approval_Click(sender As Object, e As EventArgs) Handles btn_Piping_Transmittal_Under_Approval.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Piping_Transmittal_Under_Approval&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Electrical_Transmittal_Under_Approval_Click(sender As Object, e As EventArgs) Handles btn_Electrical_Transmittal_Under_Approval.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Electrical_Transmittal_Under_Approval&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_CI_Transmittal_Under_Approval_Click(sender As Object, e As EventArgs) Handles btn_CI_Transmittal_Under_Approval.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=CI_Transmittal_Under_Approval&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Others_Transmittal_Under_Approval_Click(sender As Object, e As EventArgs) Handles btn_Others_Transmittal_Under_Approval.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Others_Transmittal_Under_Approval&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Total_Transmittal_Under_Approval_Click(sender As Object, e As EventArgs) Handles btn_Total_Transmittal_Under_Approval.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Total_Transmittal_Under_Approval&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Process_Transmittal_Under_Issue_Click(sender As Object, e As EventArgs) Handles btn_Process_Transmittal_Under_Issue.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Process_Transmittal_Under_Issue&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Mechanical_Transmittal_Under_Issue_Click(sender As Object, e As EventArgs) Handles btn_Mechanical_Transmittal_Under_Issue.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Mechanical_Transmittal_Under_Issue&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Structure_Transmittal_Under_Issue_Click(sender As Object, e As EventArgs) Handles btn_Structure_Transmittal_Under_Issue.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Structure_Transmittal_Under_Issue&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Piping_Transmittal_Under_Issue_Click(sender As Object, e As EventArgs) Handles btn_Piping_Transmittal_Under_Issue.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Piping_Transmittal_Under_Issue&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Electrical_Transmittal_Under_Issue_Click(sender As Object, e As EventArgs) Handles btn_Electrical_Transmittal_Under_Issue.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Electrical_Transmittal_Under_Issue&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_CI_Transmittal_Under_Issue_Click(sender As Object, e As EventArgs) Handles btn_CI_Transmittal_Under_Issue.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=CI_Transmittal_Under_Issue&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Others_Transmittal_Under_Issue_Click(sender As Object, e As EventArgs) Handles btn_Others_Transmittal_Under_Issue.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Others_Transmittal_Under_Issue&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Total_Transmittal_Under_Issue_Click(sender As Object, e As EventArgs) Handles btn_Total_Transmittal_Under_Issue.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Total_Transmittal_Under_Issue&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Process_Transmittal_Issued_Click(sender As Object, e As EventArgs) Handles btn_Process_Transmittal_Issued.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Process_Transmittal_Issued&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Mechanical_Transmittal_Issued_Click(sender As Object, e As EventArgs) Handles btn_Mechanical_Transmittal_Issued.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Mechanical_Transmittal_Issued&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Structure_Transmittal_Issued_Click(sender As Object, e As EventArgs) Handles btn_Structure_Transmittal_Issued.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Structure_Transmittal_Issued&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Piping_Transmittal_Issued_Click(sender As Object, e As EventArgs) Handles btn_Piping_Transmittal_Issued.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Piping_Transmittal_Issued&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Electrical_Transmittal_Issued_Click(sender As Object, e As EventArgs) Handles btn_Electrical_Transmittal_Issued.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Electrical_Transmittal_Issued&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_CI_Transmittal_Issued_Click(sender As Object, e As EventArgs) Handles btn_CI_Transmittal_Issued.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=CI_Transmittal_Issued&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Others_Transmittal_Issued_Click(sender As Object, e As EventArgs) Handles btn_Others_Transmittal_Issued.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Others_Transmittal_Issued&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Total_Transmittal_Issued_Click(sender As Object, e As EventArgs) Handles btn_Total_Transmittal_Issued.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Total_Transmittal_Issued&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Process_Transmittal_Partial_Received_Click(sender As Object, e As EventArgs) Handles btn_Process_Transmittal_Partial_Received.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Process_Transmittal_Partial_Received&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Mechanical_Transmittal_Partial_Received_Click(sender As Object, e As EventArgs) Handles btn_Mechanical_Transmittal_Partial_Received.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Mechanical_Transmittal_Partial_Received&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Structure_Transmittal_Partial_Received_Click(sender As Object, e As EventArgs) Handles btn_Structure_Transmittal_Partial_Received.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Structure_Transmittal_Partial_Received&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Piping_Transmittal_Partial_Received_Click(sender As Object, e As EventArgs) Handles btn_Piping_Transmittal_Partial_Received.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Piping_Transmittal_Partial_Received&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Electrical_Transmittal_Partial_Received_Click(sender As Object, e As EventArgs) Handles btn_Electrical_Transmittal_Partial_Received.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Electrical_Transmittal_Partial_Received&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_CI_Transmittal_Partial_Received_Click(sender As Object, e As EventArgs) Handles btn_CI_Transmittal_Partial_Received.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=CI_Transmittal_Partial_Received&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Others_Transmittal_Partial_Received_Click(sender As Object, e As EventArgs) Handles btn_Others_Transmittal_Partial_Received.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Others_Transmittal_Partial_Received&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Total_Transmittal_Partial_Received_Click(sender As Object, e As EventArgs) Handles btn_Total_Transmittal_Partial_Received.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Total_Transmittal_Partial_Received&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Process_Transmittal_Received_Click(sender As Object, e As EventArgs) Handles btn_Process_Transmittal_Received.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Process_Transmittal_Received&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Mechanical_Transmittal_Received_Click(sender As Object, e As EventArgs) Handles btn_Mechanical_Transmittal_Received.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Mechanical_Transmittal_Received&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Structure_Transmittal_Received_Click(sender As Object, e As EventArgs) Handles btn_Structure_Transmittal_Recieved.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Structure_Transmittal_Received&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Piping_Transmittal_Received_Click(sender As Object, e As EventArgs) Handles btn_Piping_Transmittal_Received.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Piping_Transmittal_Received&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Electrical_Transmittal_Received_Click(sender As Object, e As EventArgs) Handles btn_Electrical_Transmittal_Received.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Electrical_Transmittal_Received&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_CI_Transmittal_Received_Click(sender As Object, e As EventArgs) Handles btn_CI_Transmittal_Received.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=CI_Transmittal_Received&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Others_Transmittal_Received_Click(sender As Object, e As EventArgs) Handles btn_Others_Transmittal_Received.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Others_Transmittal_Received&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Total_Transmittal_Received_Click(sender As Object, e As EventArgs) Handles btn_Total_Transmittal_Received.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Total_Transmittal_Received&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Process_Transmittal_Close_Click(sender As Object, e As EventArgs) Handles btn_Process_Transmittal_Closed.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Process_Transmittal_Close&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Mechanical_Transmittal_Close_Click(sender As Object, e As EventArgs) Handles btn_Mechanical_Transmittal_Closed.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Mechanical_Transmittal_Close&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Structure_Transmittal_Close_Click(sender As Object, e As EventArgs) Handles btn_Structure_Transmittal_Closed.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Structure_Transmittal_Close&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Piping_Transmittal_Close_Click(sender As Object, e As EventArgs) Handles btn_Piping_Transmittal_Closed.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Piping_Transmittal_Close&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Electrical_Transmittal_Close_Click(sender As Object, e As EventArgs) Handles btn_Electrical_Transmittal_Closed.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Electrical_Transmittal_Close&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_CI_Transmittal_Close_Click(sender As Object, e As EventArgs) Handles btn_CI_Transmittal_Closed.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=CI_Transmittal_Close&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Others_Transmittal_Close_Click(sender As Object, e As EventArgs) Handles btn_Others_Transmittal_Closed.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Others_Transmittal_Close&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Total_Transmittal_Close_Click(sender As Object, e As EventArgs) Handles btn_Total_Transmittal_Closed.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Total_Transmittal_Close&PrjID=" & F_t_cprj.Text)
  End Sub





  Private Sub btn_Process_Transmittal_Returned_Click(sender As Object, e As EventArgs) Handles btn_Process_Transmittal_Returned.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Process_Transmittal_Returned&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Mechanical_Transmittal_Returned_Click(sender As Object, e As EventArgs) Handles btn_Mechanical_Transmittal_Returned.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Mechanical_Transmittal_Returned&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Structure_Transmittal_Returned_Click(sender As Object, e As EventArgs) Handles btn_Structure_Transmittal_Returned.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Structure_Transmittal_Returned&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Piping_Transmittal_Returned_Click(sender As Object, e As EventArgs) Handles btn_Piping_Transmittal_Returned.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Piping_Transmittal_Returned&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Electrical_Transmittal_Returned_Click(sender As Object, e As EventArgs) Handles btn_Electrical_Transmittal_Returned.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Electrical_Transmittal_Returned&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_CI_Transmittal_Returned_Click(sender As Object, e As EventArgs) Handles btn_CI_Transmittal_Returned.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=CI_Transmittal_Returned&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Others_Transmittal_Returned_Click(sender As Object, e As EventArgs) Handles btn_Others_Transmittal_Returned.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Others_Transmittal_Returned&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Total_Transmittal_Returned_Click(sender As Object, e As EventArgs) Handles btn_Total_Transmittal_Returned.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Total_Transmittal_Returned&PrjID=" & F_t_cprj.Text)
  End Sub



  Private Sub btn_Process_PSTransmittal_Total_Drawing_Count_Click(sender As Object, e As EventArgs) Handles btn_Process_PSTransmittal_Total_Drawing_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Process_PSTransmittal_Total_Count&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Mechanical_PSTransmittal_Total_Drawing_Count_Click(sender As Object, e As EventArgs) Handles btn_Mechanical_PSTransmittal_Total_Drawing_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Mechanical_PSTransmittal_Total_Count&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Structure_PSTransmittal_Total_Drawing_Count_Click(sender As Object, e As EventArgs) Handles btn_Structure_PSTransmittal_Total_Drawing_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Structure_PSTransmittal_Total_Count&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Electrical_PSTransmittal_Total_Drawing_Count_Click(sender As Object, e As EventArgs) Handles btn_Electrical_PSTransmittal_Total_Drawing_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Electrical_PSTransmittal_Total_Count&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_CI_PSTransmittal_Total_Drawing_Count_Click(sender As Object, e As EventArgs) Handles btn_CI_PSTransmittal_Total_Drawing_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=CI_PSTransmittal_Total_Count&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Others_PSTransmittal_Total_Drawing_Count_Click(sender As Object, e As EventArgs) Handles btn_Others_PSTransmittal_Total_Drawing_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Others_PSTransmittal_Total_Count&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Total_PSTransmittal_Total_Drawing_Count_Click(sender As Object, e As EventArgs) Handles btn_Total_PSTransmittal_Total_Drawing_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Total_PSTransmittal_Total_Count&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Process_PSTransmittal_Pending_Drawing_Count_Click(sender As Object, e As EventArgs) Handles btn_Process_PSTransmittal_Pending_Drawing_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Process_PSTransmittal_Pending_Count&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Mechanical_PSTransmittal_Pending_Drawing_Count_Click(sender As Object, e As EventArgs) Handles btn_Mechanical_PSTransmittal_Pending_Drawing_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Mechanical_PSTransmittal_Pending_Count&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Structure_PSTransmittal_Pending_Drawing_Count_Click(sender As Object, e As EventArgs) Handles btn_Structure_PSTransmittal_Pending_Drawing_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Structure_PSTransmittal_Pending_Count&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Electrical_PSTransmittal_Pending_Drawing_Count_Click(sender As Object, e As EventArgs) Handles btn_Electrical_PSTransmittal_Pending_Drawing_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Electrical_PSTransmittal_Pending_Count&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_CI_PSTransmittal_Pending_Drawing_Count_Click(sender As Object, e As EventArgs) Handles btn_CI_PSTransmittal_Pending_Drawing_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=CI_PSTransmittal_Pending_Count&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Others_PSTransmittal_Pending_Drawing_Count_Click(sender As Object, e As EventArgs) Handles btn_Others_PSTransmittal_Pending_Drawing_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Others_PSTransmittal_Pending_Count&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Total_PSTransmittal_Pending_Drawing_Count_Click(sender As Object, e As EventArgs) Handles btn_Total_PSTransmittal_Pending_Drawing_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Total_PSTransmittal_Pending_Count&PrjID=" & F_t_cprj.Text)
  End Sub







  Private Sub btn_Process_SAR_Total_Count_Click(sender As Object, e As EventArgs) Handles btn_Process_SAR_Total_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Process_SAR_Total_Count&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Process_SAR_Under_Creation_Click(sender As Object, e As EventArgs) Handles btn_Process_SAR_Under_Creation.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Process_SAR_Under_Creation&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Process_SAR_Under_Review_Click(sender As Object, e As EventArgs) Handles btn_Process_SAR_Under_Review.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Process_SAR_Under_Review&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Process_SAR_Under_Approval_Click(sender As Object, e As EventArgs) Handles btn_Process_SAR_Under_Approval.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Process_SAR_Under_Approval&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Process_SAR_Approved_Click(sender As Object, e As EventArgs) Handles btn_Process_SAR_Approved.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Process_SAR_Approved&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Process_SAR_Not_Applicable_Click(sender As Object, e As EventArgs) Handles btn_Process_SAR_Not_Applicable.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Process_SAR_Not_Applicable&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Mechanical_SAR_Total_Count_Click(sender As Object, e As EventArgs) Handles btn_Mechanical_SAR_Total_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Mechanical_SAR_Total_Count&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Mechanical_SAR_Under_Creation_Click(sender As Object, e As EventArgs) Handles btn_Mechanical_SAR_Under_Creation.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Mechanical_SAR_Under_Creation&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Mechanical_SAR_Under_Review_Click(sender As Object, e As EventArgs) Handles btn_Mechanical_SAR_Under_Review.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Mechanical_SAR_Under_Review&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Mechanical_SAR_Under_Approval_Click(sender As Object, e As EventArgs) Handles btn_Mechanical_SAR_Under_Approval.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Mechanical_SAR_Under_Approval&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Mechanical_SAR_Approved_Click(sender As Object, e As EventArgs) Handles btn_Mechanical_SAR_Approved.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Mechanical_SAR_Approved&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Mechanical_SAR_Not_Applicable_Click(sender As Object, e As EventArgs) Handles btn_Mechanical_SAR_Not_Applicable.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Mechanical_SAR_Not_Applicable&PrjID=" & F_t_cprj.Text)
  End Sub


  Private Sub btn_Structure_SAR_Total_Count_Click(sender As Object, e As EventArgs) Handles btn_Structure_SAR_Total_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Structure_SAR_Total_Count&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Structure_SAR_Under_Creation_Click(sender As Object, e As EventArgs) Handles btn_Structure_SAR_Under_Creation.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Structure_SAR_Under_Creation&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Structure_SAR_Under_Review_Click(sender As Object, e As EventArgs) Handles btn_Structure_SAR_Under_Review.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Structure_SAR_Under_Review&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Structure_SAR_Under_Approval_Click(sender As Object, e As EventArgs) Handles btn_Structure_SAR_Under_Approval.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Structure_SAR_Under_Approval&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Structure_SAR_Approved_Click(sender As Object, e As EventArgs) Handles btn_Structure_SAR_Approved.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Structure_SAR_Approved&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Structure_SAR_Not_Applicable_Click(sender As Object, e As EventArgs) Handles btn_Structure_SAR_Not_Applicable.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Structure_SAR_Not_Applicable&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Piping_SAR_Total_Count_Click(sender As Object, e As EventArgs) Handles btn_Piping_SAR_Total_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Piping_SAR_Total_Count&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Piping_SAR_Under_Creation_Click(sender As Object, e As EventArgs) Handles btn_Piping_SAR_Under_Creation.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Piping_SAR_Under_Creation&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Piping_SAR_Under_Review_Click(sender As Object, e As EventArgs) Handles btn_Piping_SAR_Under_Review.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Piping_SAR_Under_Review&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Piping_SAR_Under_Approval_Click(sender As Object, e As EventArgs) Handles btn_Piping_SAR_Under_Approval.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Piping_SAR_Under_Approval&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Piping_SAR_Approved_Click(sender As Object, e As EventArgs) Handles btn_Piping_SAR_Approved.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Piping_SAR_Approved&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Piping_SAR_Not_Applicable_Click(sender As Object, e As EventArgs) Handles btn_Piping_SAR_Not_Applicable.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Piping_SAR_Not_Applicable&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Electrical_SAR_Total_Count_Click(sender As Object, e As EventArgs) Handles btn_Electrical_SAR_Total_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Electrical_SAR_Total_Count&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Electrical_SAR_Under_Creation_Click(sender As Object, e As EventArgs) Handles btn_Electrical_SAR_Under_Creation.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Electrical_SAR_Under_Creation&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Electrical_SAR_Under_Review_Click(sender As Object, e As EventArgs) Handles btn_Electrical_SAR_Under_Review.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Electrical_SAR_Under_Review&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Electrical_SAR_Under_Approval_Click(sender As Object, e As EventArgs) Handles btn_Electrical_SAR_Under_Approval.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Electrical_SAR_Under_Approval&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Electrical_SAR_Approved_Click(sender As Object, e As EventArgs) Handles btn_Electrical_SAR_Approved.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Electrical_SAR_Approved&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Electrical_SAR_Not_Applicable_Click(sender As Object, e As EventArgs) Handles btn_Electrical_SAR_Not_Applicable.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Electrical_SAR_Not_Applicable&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_CI_SAR_Total_Count_Click(sender As Object, e As EventArgs) Handles btn_CI_SAR_Total_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=CI_SAR_Total_Count&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_CI_SAR_Under_Creation_Click(sender As Object, e As EventArgs) Handles btn_CI_SAR_Under_Creation.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=CI_SAR_Under_Creation&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_CI_SAR_Under_Review_Click(sender As Object, e As EventArgs) Handles btn_CI_SAR_Under_Review.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=CI_SAR_Under_Review&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_CI_SAR_Under_Approval_Click(sender As Object, e As EventArgs) Handles btn_CI_SAR_Under_Approval.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=CI_SAR_Under_Approval&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_CI_SAR_Approved_Click(sender As Object, e As EventArgs) Handles btn_CI_SAR_Approved.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=CI_SAR_Approved&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_CI_SAR_Not_Applicable_Click(sender As Object, e As EventArgs) Handles btn_CI_SAR_Not_Applicable.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=CI_SAR_Not_Applicable&PrjID=" & F_t_cprj.Text)
  End Sub


  Private Sub btn_Others_SAR_Total_Count_Click(sender As Object, e As EventArgs) Handles btn_Others_SAR_Total_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Others_SAR_Total_Count&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Others_SAR_Under_Creation_Click(sender As Object, e As EventArgs) Handles btn_Others_SAR_Under_Creation.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Others_SAR_Under_Creation&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Others_SAR_Under_Review_Click(sender As Object, e As EventArgs) Handles btn_Others_SAR_Under_Review.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Others_SAR_Under_Review&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Others_SAR_Under_Approval_Click(sender As Object, e As EventArgs) Handles btn_Others_SAR_Under_Approval.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Others_SAR_Under_Approval&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Others_SAR_Approved_Click(sender As Object, e As EventArgs) Handles btn_Others_SAR_Approved.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Others_SAR_Approved&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Others_SAR_Not_Applicable_Click(sender As Object, e As EventArgs) Handles btn_Others_SAR_Not_Applicable.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Others_SAR_Not_Applicable&PrjID=" & F_t_cprj.Text)
  End Sub


  Private Sub btn_Total_SAR_Total_Count_Click(sender As Object, e As EventArgs) Handles btn_Total_SAR_Total_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Total_SAR_Total_Count&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Total_SAR_Under_Creation_Click(sender As Object, e As EventArgs) Handles btn_Total_SAR_Under_Creation.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Total_SAR_Under_Creation&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Total_SAR_Under_Review_Click(sender As Object, e As EventArgs) Handles btn_Total_SAR_Under_Review.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Total_SAR_Under_Review&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Total_SAR_Under_Approval_Click(sender As Object, e As EventArgs) Handles btn_Total_SAR_Under_Approval.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Total_SAR_Under_Approval&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Total_SAR_Approved_Click(sender As Object, e As EventArgs) Handles btn_Total_SAR_Approved.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Total_SAR_Approved&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Total_SAR_Not_Applicable_Click(sender As Object, e As EventArgs) Handles btn_Total_SAR_Not_Applicable.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Total_SAR_Not_Applicable&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Process_IDMSP_Total_Count_Click(sender As Object, e As EventArgs) Handles btn_Process_IDMSP_Total_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Process_IDMSP_Total_Count&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Process_IDMSP_Submitted_Click(sender As Object, e As EventArgs) Handles btn_Process_IDMSP_Submitted.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Process_IDMSP_Submitted&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Process_IDMSP_Document_linked_Click(sender As Object, e As EventArgs) Handles btn_Process_IDMSP_Document_linked.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Process_IDMSP_Document_linked&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Process_IDMSP_Under_Evaluation_Click(sender As Object, e As EventArgs) Handles btn_Process_IDMSP_Under_Evaluation.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Process_IDMSP_Under_Evaluation&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Process_IDMSP_Comments_Submitted_Click(sender As Object, e As EventArgs) Handles btn_Process_IDMSP_Comments_Submitted.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Process_IDMSP_Comments_Submitted&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Process_IDMSP_Technically_Cleared_Click(sender As Object, e As EventArgs) Handles btn_Process_IDMSP_Technically_Cleared.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Process_IDMSP_Technically_Cleared&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Process_IDMSP_Transmittal_Issued_Click(sender As Object, e As EventArgs) Handles btn_Process_IDMSP_Transmittal_Issued.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Process_IDMSP_Transmittal_Issued&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Process_IDMSP_Superceded_Click(sender As Object, e As EventArgs) Handles btn_Process_IDMSP_Superceded.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Process_IDMSP_Superceded&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Process_IDMSP_Closed_Click(sender As Object, e As EventArgs) Handles btn_Process_IDMSP_Closed.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Process_IDMSP_Closed&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Mechanical_IDMSP_Total_Count_Click(sender As Object, e As EventArgs) Handles btn_Mechanical_IDMSP_Total_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Mechanical_IDMSP_Total_Count&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Mechanical_IDMSP_Submitted_Click(sender As Object, e As EventArgs) Handles btn_Mechanical_IDMSP_Submitted.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Mechanical_IDMSP_Submitted&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Mechanical_IDMSP_Document_linked_Click(sender As Object, e As EventArgs) Handles btn_Mechanical_IDMSP_Document_linked.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Mechanical_IDMSP_Document_linked&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Mechanical_IDMSP_Under_Evaluation_Click(sender As Object, e As EventArgs) Handles btn_Mechanical_IDMSP_Under_Evaluation.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Mechanical_IDMSP_Under_Evaluation&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Mechanical_IDMSP_Comments_Submitted_Click(sender As Object, e As EventArgs) Handles btn_Mechanical_IDMSP_Comments_Submitted.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Mechanical_IDMSP_Comments_Submitted&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Mechanical_IDMSP_Technically_Cleared_Click(sender As Object, e As EventArgs) Handles btn_Mechanical_IDMSP_Technically_Cleared.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Mechanical_IDMSP_Technically_Cleared&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Mechanical_IDMSP_Transmittal_Issued_Click(sender As Object, e As EventArgs) Handles btn_Mechanical_IDMSP_Transmittal_Issued.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Mechanical_IDMSP_Transmittal_Issued&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Mechanical_IDMSP_Superceded_Click(sender As Object, e As EventArgs) Handles btn_Mechanical_IDMSP_Superceded.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Mechanical_IDMSP_Superceded&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Mechanical_IDMSP_Closed_Click(sender As Object, e As EventArgs) Handles btn_Mechanical_IDMSP_Closed.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Mechanical_IDMSP_Closed&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Structure_IDMSP_Total_Count_Click(sender As Object, e As EventArgs) Handles btn_Structure_IDMSP_Total_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Structure_IDMSP_Total_Count&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Structure_IDMSP_Submitted_Click(sender As Object, e As EventArgs) Handles btn_Structure_IDMSP_Submitted.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Structure_IDMSP_Submitted&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Structure_IDMSP_Document_linked_Click(sender As Object, e As EventArgs) Handles btn_Structure_IDMSP_Document_linked.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Structure_IDMSP_Document_linked&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Structure_IDMSP_Under_Evaluation_Click(sender As Object, e As EventArgs) Handles btn_Structure_IDMSP_Under_Evaluation.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Structure_IDMSP_Under_Evaluation&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Structure_IDMSP_Comments_Submitted_Click(sender As Object, e As EventArgs) Handles btn_Structure_IDMSP_Comments_Submitted.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Structure_IDMSP_Comments_Submitted&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Structure_IDMSP_Technically_Cleared_Click(sender As Object, e As EventArgs) Handles btn_Structure_IDMSP_Technically_Cleared.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Structure_IDMSP_Technically_Cleared&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Structure_IDMSP_Transmittal_Issued_Click(sender As Object, e As EventArgs) Handles btn_Structure_IDMSP_Transmittal_Issued.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Structure_IDMSP_Transmittal_Issued&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Structure_IDMSP_Superceded_Click(sender As Object, e As EventArgs) Handles btn_Structure_IDMSP_Superceded.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Structure_IDMSP_Superceded&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Structure_IDMSP_Closed_Click(sender As Object, e As EventArgs) Handles btn_Structure_IDMSP_Closed.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Structure_IDMSP_Closed&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Piping_IDMSP_Total_Count_Click(sender As Object, e As EventArgs) Handles btn_Piping_IDMSP_Total_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Piping_IDMSP_Total_Count&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Piping_IDMSP_Submitted_Click(sender As Object, e As EventArgs) Handles btn_Piping_IDMSP_Submitted.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Piping_IDMSP_Submitted&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Piping_IDMSP_Document_linked_Click(sender As Object, e As EventArgs) Handles btn_Piping_IDMSP_Document_linked.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Piping_IDMSP_Document_linked&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Piping_IDMSP_Under_Evaluation_Click(sender As Object, e As EventArgs) Handles btn_Piping_IDMSP_Under_Evaluation.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Piping_IDMSP_Under_Evaluation&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Piping_IDMSP_Comments_Submitted_Click(sender As Object, e As EventArgs) Handles btn_Piping_IDMSP_Comments_Submitted.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Piping_IDMSP_Comments_Submitted&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Piping_IDMSP_Technically_Cleared_Click(sender As Object, e As EventArgs) Handles btn_Piping_IDMSP_Technically_Cleared.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Piping_IDMSP_Technically_Cleared&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Piping_IDMSP_Transmittal_Issued_Click(sender As Object, e As EventArgs) Handles btn_Piping_IDMSP_Transmittal_Issued.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Piping_IDMSP_Transmittal_Issued&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Piping_IDMSP_Superceded_Click(sender As Object, e As EventArgs) Handles btn_Piping_IDMSP_Superceded.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Piping_IDMSP_Superceded&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Piping_IDMSP_Closed_Click(sender As Object, e As EventArgs) Handles btn_Piping_IDMSP_Closed.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Piping_IDMSP_Closed&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Electrical_IDMSP_Total_Count_Click(sender As Object, e As EventArgs) Handles btn_Electrical_IDMSP_Total_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Electrical_IDMSP_Total_Count&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Electrical_IDMSP_Submitted_Click(sender As Object, e As EventArgs) Handles btn_Electrical_IDMSP_Submitted.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Electrical_IDMSP_Submitted&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Electrical_IDMSP_Document_linked_Click(sender As Object, e As EventArgs) Handles btn_Electrical_IDMSP_Document_linked.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Electrical_IDMSP_Document_linked&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Electrical_IDMSP_Under_Evaluation_Click(sender As Object, e As EventArgs) Handles btn_Electrical_IDMSP_Under_Evaluation.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Electrical_IDMSP_Under_Evaluation&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Electrical_IDMSP_Comments_Submitted_Click(sender As Object, e As EventArgs) Handles btn_Electrical_IDMSP_Comments_Submitted.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Electrical_IDMSP_Comments_Submitted&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Electrical_IDMSP_Technically_Cleared_Click(sender As Object, e As EventArgs) Handles btn_Electrical_IDMSP_Technically_Cleared.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Electrical_IDMSP_Technically_Cleared&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Electrical_IDMSP_Transmittal_Issued_Click(sender As Object, e As EventArgs) Handles btn_Electrical_IDMSP_Transmittal_Issued.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Electrical_IDMSP_Transmittal_Issued&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Electrical_IDMSP_Superceded_Click(sender As Object, e As EventArgs) Handles btn_Electrical_IDMSP_Superceded.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Electrical_IDMSP_Superceded&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Electrical_IDMSP_Closed_Click(sender As Object, e As EventArgs) Handles btn_Electrical_IDMSP_Closed.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Electrical_IDMSP_Closed&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_CI_IDMSP_Total_Count_Click(sender As Object, e As EventArgs) Handles btn_CI_IDMSP_Total_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=CI_IDMSP_Total_Count&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_CI_IDMSP_Submitted_Click(sender As Object, e As EventArgs) Handles btn_CI_IDMSP_Submitted.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=CI_IDMSP_Submitted&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_CI_IDMSP_Document_linked_Click(sender As Object, e As EventArgs) Handles btn_CI_IDMSP_Document_linked.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=CI_IDMSP_Document_linked&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_CI_IDMSP_Under_Evaluation_Click(sender As Object, e As EventArgs) Handles btn_CI_IDMSP_Under_Evaluation.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=CI_IDMSP_Under_Evaluation&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_CI_IDMSP_Comments_Submitted_Click(sender As Object, e As EventArgs) Handles btn_CI_IDMSP_Comments_Submitted.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=CI_IDMSP_Comments_Submitted&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_CI_IDMSP_Technically_Cleared_Click(sender As Object, e As EventArgs) Handles btn_CI_IDMSP_Technically_Cleared.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=CI_IDMSP_Technically_Cleared&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_CI_IDMSP_Transmittal_Issued_Click(sender As Object, e As EventArgs) Handles btn_CI_IDMSP_Transmittal_Issued.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=CI_IDMSP_Transmittal_Issued&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_CI_IDMSP_Superceded_Click(sender As Object, e As EventArgs) Handles btn_CI_IDMSP_Superceded.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=CI_IDMSP_Superceded&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_CI_IDMSP_Closed_Click(sender As Object, e As EventArgs) Handles btn_CI_IDMSP_Closed.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=CI_IDMSP_Closed&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Others_IDMSP_Total_Count_Click(sender As Object, e As EventArgs) Handles btn_Others_IDMSP_Total_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Others_IDMSP_Total_Count&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Others_IDMSP_Submitted_Click(sender As Object, e As EventArgs) Handles btn_Others_IDMSP_Submitted.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Others_IDMSP_Submitted&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Others_IDMSP_Document_linked_Click(sender As Object, e As EventArgs) Handles btn_Others_IDMSP_Document_linked.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Others_IDMSP_Document_linked&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Others_IDMSP_Under_Evaluation_Click(sender As Object, e As EventArgs) Handles btn_Others_IDMSP_Under_Evaluation.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Others_IDMSP_Under_Evaluation&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Others_IDMSP_Comments_Submitted_Click(sender As Object, e As EventArgs) Handles btn_Others_IDMSP_Comments_Submitted.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Others_IDMSP_Comments_Submitted&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Others_IDMSP_Technically_Cleared_Click(sender As Object, e As EventArgs) Handles btn_Others_IDMSP_Technically_Cleared.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Others_IDMSP_Technically_Cleared&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Others_IDMSP_Transmittal_Issued_Click(sender As Object, e As EventArgs) Handles btn_Others_IDMSP_Transmittal_Issued.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Others_IDMSP_Transmittal_Issued&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Others_IDMSP_Superceded_Click(sender As Object, e As EventArgs) Handles btn_Others_IDMSP_Superceded.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Others_IDMSP_Superceded&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Others_IDMSP_Closed_Click(sender As Object, e As EventArgs) Handles btn_Others_IDMSP_Closed.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Others_IDMSP_Closed&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Total_IDMSP_Total_Count_Click(sender As Object, e As EventArgs) Handles btn_Total_IDMSP_Total_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Total_IDMSP_Total_Count&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Total_IDMSP_Submitted_Click(sender As Object, e As EventArgs) Handles btn_Total_IDMSP_Submitted.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Total_IDMSP_Submitted&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Total_IDMSP_Document_linked_Click(sender As Object, e As EventArgs) Handles btn_Total_IDMSP_Document_linked.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Total_IDMSP_Document_linked&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Total_IDMSP_Under_Evaluation_Click(sender As Object, e As EventArgs) Handles btn_Total_IDMSP_Under_Evaluation.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Total_IDMSP_Under_Evaluation&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Total_IDMSP_Comments_Submitted_Click(sender As Object, e As EventArgs) Handles btn_Total_IDMSP_Comments_Submitted.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Total_IDMSP_Comments_Submitted&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Total_IDMSP_Technically_Cleared_Click(sender As Object, e As EventArgs) Handles btn_Total_IDMSP_Technically_Cleared.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Total_IDMSP_Technically_Cleared&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Total_IDMSP_Transmittal_Issued_Click(sender As Object, e As EventArgs) Handles btn_Total_IDMSP_Transmittal_Issued.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Total_IDMSP_Transmittal_Issued&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Total_IDMSP_Superceded_Click(sender As Object, e As EventArgs) Handles btn_Total_IDMSP_Superceded.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Total_IDMSP_Superceded&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Total_IDMSP_Closed_Click(sender As Object, e As EventArgs) Handles btn_Total_IDMSP_Closed.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Total_IDMSP_Closed&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Process_IDMSO_Total_Count_Click(sender As Object, e As EventArgs) Handles btn_Process_IDMSO_Total_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Process_IDMSO_Total_Count&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Process_IDMSO_Submitted_Click(sender As Object, e As EventArgs) Handles btn_Process_IDMSO_Submitted.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Process_IDMSO_Submitted&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Process_IDMSO_Document_linked_Click(sender As Object, e As EventArgs) Handles btn_Process_IDMSO_Document_linked.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Process_IDMSO_Document_linked&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Process_IDMSO_Under_Evaluation_Click(sender As Object, e As EventArgs) Handles btn_Process_IDMSO_Under_Evaluation.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Process_IDMSO_Under_Evaluation&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Process_IDMSO_Comments_Submitted_Click(sender As Object, e As EventArgs) Handles btn_Process_IDMSO_Comments_Submitted.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Process_IDMSO_Comments_Submitted&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Process_IDMSO_Technically_Cleared_Click(sender As Object, e As EventArgs) Handles btn_Process_IDMSO_Technically_Cleared.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Process_IDMSO_Technically_Cleared&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Process_IDMSO_Transmittal_Issued_Click(sender As Object, e As EventArgs) Handles btn_Process_IDMSO_Transmittal_Issued.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Process_IDMSO_Transmittal_Issued&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Process_IDMSO_Superceded_Click(sender As Object, e As EventArgs) Handles btn_Process_IDMSO_Superceded.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Process_IDMSO_Superceded&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Process_IDMSO_Closed_Click(sender As Object, e As EventArgs) Handles btn_Process_IDMSO_Closed.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Process_IDMSO_Closed&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Mechanical_IDMSO_Total_Count_Click(sender As Object, e As EventArgs) Handles btn_Mechanical_IDMSO_Total_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Mechanical_IDMSO_Total_Count&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Mechanical_IDMSO_Submitted_Click(sender As Object, e As EventArgs) Handles btn_Mechanical_IDMSO_Submitted.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Mechanical_IDMSO_Submitted&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Mechanical_IDMSO_Document_linked_Click(sender As Object, e As EventArgs) Handles btn_Mechanical_IDMSO_Document_linked.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Mechanical_IDMSO_Document_linked&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Mechanical_IDMSO_Under_Evaluation_Click(sender As Object, e As EventArgs) Handles btn_Mechanical_IDMSO_Under_Evaluation.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Mechanical_IDMSO_Under_Evaluation&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Mechanical_IDMSO_Comments_Submitted_Click(sender As Object, e As EventArgs) Handles btn_Mechanical_IDMSO_Comments_Submitted.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Mechanical_IDMSO_Comments_Submitted&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Mechanical_IDMSO_Technically_Cleared_Click(sender As Object, e As EventArgs) Handles btn_Mechanical_IDMSO_Technically_Cleared.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Mechanical_IDMSO_Technically_Cleared&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Mechanical_IDMSO_Transmittal_Issued_Click(sender As Object, e As EventArgs) Handles btn_Mechanical_IDMSO_Transmittal_Issued.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Mechanical_IDMSO_Transmittal_Issued&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Mechanical_IDMSO_Superceded_Click(sender As Object, e As EventArgs) Handles btn_Mechanical_IDMSO_Superceded.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Mechanical_IDMSO_Superceded&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Mechanical_IDMSO_Closed_Click(sender As Object, e As EventArgs) Handles btn_Mechanical_IDMSO_Closed.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Mechanical_IDMSO_Closed&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Structure_IDMSO_Total_Count_Click(sender As Object, e As EventArgs) Handles btn_Structure_IDMSO_Total_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Structure_IDMSO_Total_Count&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Structure_IDMSO_Submitted_Click(sender As Object, e As EventArgs) Handles btn_Structure_IDMSO_Submitted.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Structure_IDMSO_Submitted&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Structure_IDMSO_Document_linked_Click(sender As Object, e As EventArgs) Handles btn_Structure_IDMSO_Document_linked.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Structure_IDMSO_Document_linked&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Structure_IDMSO_Under_Evaluation_Click(sender As Object, e As EventArgs) Handles btn_Structure_IDMSO_Under_Evaluation.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Structure_IDMSO_Under_Evaluation&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Structure_IDMSO_Comments_Submitted_Click(sender As Object, e As EventArgs) Handles btn_Structure_IDMSO_Comments_Submitted.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Structure_IDMSO_Comments_Submitted&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Structure_IDMSO_Technically_Cleared_Click(sender As Object, e As EventArgs) Handles btn_Structure_IDMSO_Technically_Cleared.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Structure_IDMSO_Technically_Cleared&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Structure_IDMSO_Transmittal_Issued_Click(sender As Object, e As EventArgs) Handles btn_Structure_IDMSO_Transmittal_Issued.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Structure_IDMSO_Transmittal_Issued&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Structure_IDMSO_Superceded_Click(sender As Object, e As EventArgs) Handles btn_Structure_IDMSO_Superceded.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Structure_IDMSO_Superceded&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Structure_IDMSO_Closed_Click(sender As Object, e As EventArgs) Handles btn_Structure_IDMSO_Closed.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Structure_IDMSO_Closed&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Piping_IDMSO_Total_Count_Click(sender As Object, e As EventArgs) Handles btn_Piping_IDMSO_Total_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Piping_IDMSO_Total_Count&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Piping_IDMSO_Submitted_Click(sender As Object, e As EventArgs) Handles btn_Piping_IDMSO_Submitted.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Piping_IDMSO_Submitted&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Piping_IDMSO_Document_linked_Click(sender As Object, e As EventArgs) Handles btn_Piping_IDMSO_Document_linked.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Piping_IDMSO_Document_linked&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Piping_IDMSO_Under_Evaluation_Click(sender As Object, e As EventArgs) Handles btn_Piping_IDMSO_Under_Evaluation.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Piping_IDMSO_Under_Evaluation&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Piping_IDMSO_Comments_Submitted_Click(sender As Object, e As EventArgs) Handles btn_Piping_IDMSO_Comments_Submitted.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Piping_IDMSO_Comments_Submitted&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Piping_IDMSO_Technically_Cleared_Click(sender As Object, e As EventArgs) Handles btn_Piping_IDMSO_Technically_Cleared.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Piping_IDMSO_Technically_Cleared&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Piping_IDMSO_Transmittal_Issued_Click(sender As Object, e As EventArgs) Handles btn_Piping_IDMSO_Transmittal_Issued.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Piping_IDMSO_Transmittal_Issued&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Piping_IDMSO_Superceded_Click(sender As Object, e As EventArgs) Handles btn_Piping_IDMSO_Superceded.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Piping_IDMSO_Superceded&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Piping_IDMSO_Closed_Click(sender As Object, e As EventArgs) Handles btn_Piping_IDMSO_Closed.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Piping_IDMSO_Closed&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Electrical_IDMSO_Total_Count_Click(sender As Object, e As EventArgs) Handles btn_Electrical_IDMSO_Total_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Electrical_IDMSO_Total_Count&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Electrical_IDMSO_Submitted_Click(sender As Object, e As EventArgs) Handles btn_Electrical_IDMSO_Submitted.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Electrical_IDMSO_Submitted&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Electrical_IDMSO_Document_linked_Click(sender As Object, e As EventArgs) Handles btn_Electrical_IDMSO_Document_linked.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Electrical_IDMSO_Document_linked&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Electrical_IDMSO_Under_Evaluation_Click(sender As Object, e As EventArgs) Handles btn_Electrical_IDMSO_Under_Evaluation.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Electrical_IDMSO_Under_Evaluation&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Electrical_IDMSO_Comments_Submitted_Click(sender As Object, e As EventArgs) Handles btn_Electrical_IDMSO_Comments_Submitted.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Electrical_IDMSO_Comments_Submitted&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Electrical_IDMSO_Technically_Cleared_Click(sender As Object, e As EventArgs) Handles btn_Electrical_IDMSO_Technically_Cleared.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Electrical_IDMSO_Technically_Cleared&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Electrical_IDMSO_Transmittal_Issued_Click(sender As Object, e As EventArgs) Handles btn_Electrical_IDMSO_Transmittal_Issued.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Electrical_IDMSO_Transmittal_Issued&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Electrical_IDMSO_Superceded_Click(sender As Object, e As EventArgs) Handles btn_Electrical_IDMSO_Superceded.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Electrical_IDMSO_Superceded&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Electrical_IDMSO_Closed_Click(sender As Object, e As EventArgs) Handles btn_Electrical_IDMSO_Closed.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Electrical_IDMSO_Closed&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_CI_IDMSO_Total_Count_Click(sender As Object, e As EventArgs) Handles btn_CI_IDMSO_Total_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=CI_IDMSO_Total_Count&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_CI_IDMSO_Submitted_Click(sender As Object, e As EventArgs) Handles btn_CI_IDMSO_Submitted.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=CI_IDMSO_Submitted&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_CI_IDMSO_Document_linked_Click(sender As Object, e As EventArgs) Handles btn_CI_IDMSO_Document_linked.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=CI_IDMSO_Document_linked&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_CI_IDMSO_Under_Evaluation_Click(sender As Object, e As EventArgs) Handles btn_CI_IDMSO_Under_Evaluation.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=CI_IDMSO_Under_Evaluation&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_CI_IDMSO_Comments_Submitted_Click(sender As Object, e As EventArgs) Handles btn_CI_IDMSO_Comments_Submitted.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=CI_IDMSO_Comments_Submitted&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_CI_IDMSO_Technically_Cleared_Click(sender As Object, e As EventArgs) Handles btn_CI_IDMSO_Technically_Cleared.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=CI_IDMSO_Technically_Cleared&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_CI_IDMSO_Transmittal_Issued_Click(sender As Object, e As EventArgs) Handles btn_CI_IDMSO_Transmittal_Issued.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=CI_IDMSO_Transmittal_Issued&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_CI_IDMSO_Superceded_Click(sender As Object, e As EventArgs) Handles btn_CI_IDMSO_Superceded.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=CI_IDMSO_Superceded&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_CI_IDMSO_Closed_Click(sender As Object, e As EventArgs) Handles btn_CI_IDMSO_Closed.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=CI_IDMSO_Closed&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Others_IDMSO_Total_Count_Click(sender As Object, e As EventArgs) Handles btn_Others_IDMSO_Total_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Others_IDMSO_Total_Count&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Others_IDMSO_Submitted_Click(sender As Object, e As EventArgs) Handles btn_Others_IDMSO_Submitted.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Others_IDMSO_Submitted&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Others_IDMSO_Document_linked_Click(sender As Object, e As EventArgs) Handles btn_Others_IDMSO_Document_linked.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Others_IDMSO_Document_linked&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Others_IDMSO_Under_Evaluation_Click(sender As Object, e As EventArgs) Handles btn_Others_IDMSO_Under_Evaluation.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Others_IDMSO_Under_Evaluation&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Others_IDMSO_Comments_Submitted_Click(sender As Object, e As EventArgs) Handles btn_Others_IDMSO_Comments_Submitted.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Others_IDMSO_Comments_Submitted&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Others_IDMSO_Technically_Cleared_Click(sender As Object, e As EventArgs) Handles btn_Others_IDMSO_Technically_Cleared.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Others_IDMSO_Technically_Cleared&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Others_IDMSO_Transmittal_Issued_Click(sender As Object, e As EventArgs) Handles btn_Others_IDMSO_Transmittal_Issued.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Others_IDMSO_Transmittal_Issued&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Others_IDMSO_Superceded_Click(sender As Object, e As EventArgs) Handles btn_Others_IDMSO_Superceded.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Others_IDMSO_Superceded&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Others_IDMSO_Closed_Click(sender As Object, e As EventArgs) Handles btn_Others_IDMSO_Closed.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Others_IDMSO_Closed&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Total_IDMSO_Total_Count_Click(sender As Object, e As EventArgs) Handles btn_Total_IDMSO_Total_Count.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Total_IDMSO_Total_Count&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Total_IDMSO_Submitted_Click(sender As Object, e As EventArgs) Handles btn_Total_IDMSO_Submitted.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Total_IDMSO_Submitted&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Total_IDMSO_Document_linked_Click(sender As Object, e As EventArgs) Handles btn_Total_IDMSO_Document_linked.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Total_IDMSO_Document_linked&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Total_IDMSO_Under_Evaluation_Click(sender As Object, e As EventArgs) Handles btn_Total_IDMSO_Under_Evaluation.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Total_IDMSO_Under_Evaluation&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Total_IDMSO_Comments_Submitted_Click(sender As Object, e As EventArgs) Handles btn_Total_IDMSO_Comments_Submitted.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Total_IDMSO_Comments_Submitted&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Total_IDMSO_Technically_Cleared_Click(sender As Object, e As EventArgs) Handles btn_Total_IDMSO_Technically_Cleared.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Total_IDMSO_Technically_Cleared&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Total_IDMSO_Transmittal_Issued_Click(sender As Object, e As EventArgs) Handles btn_Total_IDMSO_Transmittal_Issued.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Total_IDMSO_Transmittal_Issued&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Total_IDMSO_Superceded_Click(sender As Object, e As EventArgs) Handles btn_Total_IDMSO_Superceded.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Total_IDMSO_Superceded&PrjID=" & F_t_cprj.Text)
  End Sub
  Private Sub btn_Total_IDMSO_Closed_Click(sender As Object, e As EventArgs) Handles btn_Total_IDMSO_Closed.Click
    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Total_IDMSO_Closed&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Process_Element_Total_Active_Element_Count_Click(sender As Object, e As EventArgs) Handles btn_Process_Element_Total_Active_Element_Count.Click

    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Process_Element_Total_Active_Element_Count&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Process_Element_Free_Click(sender As Object, e As EventArgs) Handles btn_Process_Element_Free.Click

    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Process_Element_Free&PrjID=" & F_t_cprj.Text)
  End Sub


  Private Sub btn_Process_Element_Partial_Click(sender As Object, e As EventArgs) Handles btn_Process_Element_Partial.Click

    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Process_Element_Partial&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Process_Element_Completed_Click(sender As Object, e As EventArgs) Handles btn_Process_Element_Completed.Click

    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Process_Element_Completed&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Mechanical_Element_Total_Active_Element_Count_Click(sender As Object, e As EventArgs) Handles btn_Mechanical_Element_Total_Active_Element_Count.Click

    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Mechanical_Element_Total_Active_Element_Count&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Mechanical_Element_Free_Click(sender As Object, e As EventArgs) Handles btn_Mechanical_Element_Free.Click

    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Mechanical_Element_Free&PrjID=" & F_t_cprj.Text)
  End Sub


  Private Sub btn_Mechanical_Element_Partial_Click(sender As Object, e As EventArgs) Handles btn_Mechanical_Element_Partial.Click

    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Mechanical_Element_Partial&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Mechanical_Element_Completed_Click(sender As Object, e As EventArgs) Handles btn_Mechanical_Element_Completed.Click

    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Mechanical_Element_Completed&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Structure_Element_Total_Active_Element_Count_Click(sender As Object, e As EventArgs) Handles btn_Structure_Element_Total_Active_Element_Count.Click

    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Structure_Element_Total_Active_Element_Count&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Structure_Element_Free_Click(sender As Object, e As EventArgs) Handles btn_Structure_Element_Free.Click

    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Structure_Element_Free&PrjID=" & F_t_cprj.Text)
  End Sub


  Private Sub btn_Structure_Element_Partial_Click(sender As Object, e As EventArgs) Handles btn_Structure_Element_Partial.Click

    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Structure_Element_Partial&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Structure_Element_Completed_Click(sender As Object, e As EventArgs) Handles btn_Structure_Element_Completed.Click

    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Structure_Element_Completed&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Piping_Element_Total_Active_Element_Count_Click(sender As Object, e As EventArgs) Handles btn_Piping_Element_Total_Active_Element_Count.Click

    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Piping_Element_Total_Active_Element_Count&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Piping_Element_Free_Click(sender As Object, e As EventArgs) Handles btn_Piping_Element_Free.Click

    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Piping_Element_Free&PrjID=" & F_t_cprj.Text)
  End Sub


  Private Sub btn_Piping_Element_Partial_Click(sender As Object, e As EventArgs) Handles btn_Piping_Element_Partial.Click

    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Piping_Element_Partial&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Piping_Element_Completed_Click(sender As Object, e As EventArgs) Handles btn_Piping_Element_Completed.Click

    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Piping_Element_Completed&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Electrical_Element_Total_Active_Element_Count_Click(sender As Object, e As EventArgs) Handles btn_Electrical_Element_Total_Active_Element_Count.Click

    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Electrical_Element_Total_Active_Element_Count&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Electrical_Element_Free_Click(sender As Object, e As EventArgs) Handles btn_Electrical_Element_Free.Click

    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Electrical_Element_Free&PrjID=" & F_t_cprj.Text)
  End Sub


  Private Sub btn_Electrical_Element_Partial_Click(sender As Object, e As EventArgs) Handles btn_Electrical_Element_Partial.Click

    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Electrical_Element_Partial&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Electrical_Element_Completed_Click(sender As Object, e As EventArgs) Handles btn_Electrical_Element_Completed.Click

    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Electrical_Element_Completed&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_CI_Element_Total_Active_Element_Count_Click(sender As Object, e As EventArgs) Handles btn_CI_Element_Total_Active_Element_Count.Click

    Response.Redirect("GF_ProjectDBDetails.aspx?detail=CI_Element_Total_Active_Element_Count&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_CI_Element_Free_Click(sender As Object, e As EventArgs) Handles btn_CI_Element_Free.Click

    Response.Redirect("GF_ProjectDBDetails.aspx?detail=CI_Element_Free&PrjID=" & F_t_cprj.Text)
  End Sub


  Private Sub btn_CI_Element_Partial_Click(sender As Object, e As EventArgs) Handles btn_CI_Element_Partial.Click

    Response.Redirect("GF_ProjectDBDetails.aspx?detail=CI_Element_Partial&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_CI_Element_Completed_Click(sender As Object, e As EventArgs) Handles btn_CI_Element_Completed.Click

    Response.Redirect("GF_ProjectDBDetails.aspx?detail=CI_Element_Completed&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Others_Element_Total_Active_Element_Count_Click(sender As Object, e As EventArgs) Handles btn_Others_Element_Total_Active_Element_Count.Click

    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Others_Element_Total_Active_Element_Count&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Others_Element_Free_Click(sender As Object, e As EventArgs) Handles btn_Others_Element_Free.Click

    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Others_Element_Free&PrjID=" & F_t_cprj.Text)
  End Sub


  Private Sub btn_Others_Element_Partial_Click(sender As Object, e As EventArgs) Handles btn_Others_Element_Partial.Click

    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Others_Element_Partial&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Others_Element_Completed_Click(sender As Object, e As EventArgs) Handles btn_Others_Element_Completed.Click

    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Others_Element_Completed&PrjID=" & F_t_cprj.Text)
  End Sub


  Private Sub btn_Total_Element_Total_Active_Element_Count_Click(sender As Object, e As EventArgs) Handles btn_Total_Element_Total_Active_Element_Count.Click

    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Total_Element_Total_Active_Element_Count&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Total_Element_Free_Click(sender As Object, e As EventArgs) Handles btn_Total_Element_Free.Click

    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Total_Element_Free&PrjID=" & F_t_cprj.Text)
  End Sub


  Private Sub btn_Total_Element_Partial_Click(sender As Object, e As EventArgs) Handles btn_Total_Element_Partial.Click

    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Total_Element_Partial&PrjID=" & F_t_cprj.Text)
  End Sub

  Private Sub btn_Total_Element_Completed_Click(sender As Object, e As EventArgs) Handles btn_Total_Element_Completed.Click

    Response.Redirect("GF_ProjectDBDetails.aspx?detail=Total_Element_Completed&PrjID=" & F_t_cprj.Text)
  End Sub
#End Region



End Class
