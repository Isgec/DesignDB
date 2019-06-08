Partial Class GF_Report
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
    Dim Textbx_Division As String = ""
    Dim Department As String = ""
    Dim SubGroups As String = ""
    Dim Report As String = ""

    DocumentID = F_t_docn.Text.ToUpper()
    F_t_docn.Text = DocumentID

    If DocumentID = "" Then Exit Sub




    Dim x As SIS.DB.dbDocumentDB = SIS.DB.dbDocumentDB.GetDocumentDB(DocumentID)







  End Sub



  Private Sub GF_DocumentDB_Load(sender As Object, e As EventArgs) Handles Me.Load

    'Dim x As SIS.DB.dbDocumentDB = SIS.DB.dbDocumentDB.GetDocumentDB(DocumentID)


    'btn_documentname.Text = x.Tittle

    'If DocumentID = "" Then Exit Sub

  End Sub



End Class