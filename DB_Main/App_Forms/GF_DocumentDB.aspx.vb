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




  End Sub



  Private Sub GF_DocumentDB_Load(sender As Object, e As EventArgs) Handles Me.Load

    'Dim x As SIS.DB.dbDocumentDB = SIS.DB.dbDocumentDB.GetDocumentDB(DocumentID)


    'btn_documentname.Text = x.Tittle

    'If DocumentID = "" Then Exit Sub

  End Sub



End Class
