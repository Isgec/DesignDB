Partial Class GF_DocumentDB
  Inherits System.Web.UI.Page


  Public Property DocumentID As String
    Get
      If ViewState("DocumentID") IsNot Nothing Then
        Return ViewState("DocumentID")
      End If
      Return ""
    End Get
    Set(value As String)

      ViewState.Add("DocumentID", value)
    End Set
  End Property

  Private Sub cmdSubmit_Click(sender As Object, e As EventArgs) Handles cmdSubmit.Click
    Dim DocumentID As String = ""
    DocumentID = F_t_docn.Text.ToUpper()
    F_t_docn.Text = DocumentID

    If DocumentID = "" Then Exit Sub


    DivDescription2.Visible = True
    DivDescription1.Visible = True
    DivRevision1.Visible = True
    DivRevision2.Visible = True
    DivFilename.Visible = True
    DivStatus.Visible = True
    DivWorkflow.Visible = True
    DivResponsible.Visible = True
    DivDate.Visible = True
    Divweight.Visible = True
    Divscale.Visible = True
    Divsize.Visible = True
    DivElement.Visible = True
    DivDrawnBy.Visible = True
    DivCheckedBy.Visible = True
    DivApprovedBy.Visible = True
    DivDocumenttype.Visible = True
    DivDivision.Visible = True
    DivSubmittedTime1.Visible = True
    DivSubmittedTime2.Visible = True
    DivEUserName1.Visible = True
    DivEUserName2.Visible = True
    DivEReviewedBy1.Visible = True
    DivEReviewedBy2.Visible = True
    DivEApprovedBy1.Visible = True
    DivEApprovedBy2.Visible = True
    DivISGECDataSource1.Visible = True
    DivISGECDataSource2.Visible = True
    DivErection.Visible = True
    Divinformation.Visible = True
    DivProduction.Visible = True
    DivApproval.Visible = True
    DivSoftwareused.Visible = True
    DivMachineName.Visible = True
    DivProjectID.Visible = True
    DivProjectClient.Visible = True
    DivProjectConsultant.Visible = True
    DivProjectYear.Visible = True
    DivProjectIWT.Visible = True
    DivProject_Service.Visible = True
    DivIndentNumber.Visible = True
    DivindentDate.Visible = True
    DivIndentRequester.Visible = True
    DivPONumber.Visible = True
    DivPODate.Visible = True
    DivTransmittalid.Visible = True

    DivPOSupplier.Visible = True
    DivPOSuppliername.Visible = True
    DivPOBuyer.Visible = True
    di.Visible = True
    pi.Visible = True
    poi.Visible = True
    pmdli.Visible = False
    ii.Visible = True
    ti.Visible = True

    Dim x As SIS.DB.dbDocumentDB = SIS.DB.dbDocumentDB.GetDocumentDB(DocumentID)


    btn_documentname.Text = x.Tittle_001
    btn_documentrev.Text = x.Document_Rev
    btn_documentfilename.Text = x.Drawing_File_Name_001
    btn_documentStatus.Text = x.Drawing_State_001
    btn_documentWorkflow.Text = x.Workflow_Status_001
    btn_documentResponsible.Text = x.Responsible_001
    btn_documentDate.Text = x.Document_Date_001
    btn_documentWeight.Text = x.Drawing_Weight_001
    btn_documentScale.Text = x.Drawing_Scale_001
    btn_documentSize.Text = x.Sheet_Size_001
    btn_documentElement.Text = x.Element_001
    btn_documentDrawnby.Text = x.Drawn_By_001
    btn_documentCheckedBy.Text = x.Checked_By_001
    btn_documentApprovedBy.Text = x.Approved_By_001
    btn_documentType.Text = x.Document_Type
    btn_documentDivision.Text = x.Division
    btn_documentSubmittedTime.Text = x.Submitted_Time
    btn_EUserName.Text = x.User_Name
    btn_EReviewedBy.Text = x.Review_By
    Btn_EApprovedBy.Text = x.EApproved_BY
    Btn_IsgecDataSource.Text = x.ISGEC_DATA_Source
    Btn_Erection.Text = x.For_Erection
    Btn_Information.Text = x.For_Information
    Btn_Production.Text = x.For_Production
    Btn_Approval.Text = x.For_Approval
    Btn_Softwareused.Text = x.SoftwareUsed
    Btn_MachineName.Text = x.MachineName
    btn_ProjectID.Text = x.ProjectID
    btn_ProjectClient.Text = x.Client
    btn_ProjectConsultant.Text = x.Consultant
    btn_ProjectYear.Text = x.Year
    btn_ProjectIWT.Text = x.IWT
    Btn_Project_Service.Text = x.Project_Service
    btn_IndentNumber.Text = x.IndentNumber
    btn_IndentDate.Text = x.IndentDate
    btn_IndentRequester.Text = x.IndentRequester
    btn_PONumber.Text = x.PONumber
    btn_PODate.Text = x.PODate
    btn_POSupplier.Text = x.POsupplier
    btn_POSuppliername.Text = x.POsuppliername
    btn_POBuyer.Text = x.POBuyer
    btn_transmittalid.Text = x.Transmittalid




  End Sub



  Private Sub GF_DocumentDB_Load(sender As Object, e As EventArgs) Handles Me.Load

    'Dim x As SIS.DB.dbDocumentDB = SIS.DB.dbDocumentDB.GetDocumentDB(DocumentID)


    'btn_documentname.Text = x.Tittle

    'If DocumentID = "" Then Exit Sub

  End Sub



End Class
