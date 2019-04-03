Partial Class RP_dmisg140
  Inherits System.Web.UI.Page
  Private _InfoUrl As String = "~/DMISG_Main/App_Display/DF_dmisg140.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?t_cprj=" & aVal(0) & "&t_docn=" & aVal(1)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim aVal() As String = Request.QueryString("pk").Split("|".ToCharArray)
    Dim t_cprj As String = CType(aVal(0),String)
    Dim t_docn As String = CType(aVal(1),String)
    'Dim oVar As SIS.DMISG.dmisg140 = SIS.DMISG.dmisg140.dmisg140GetByID(t_cprj,t_docn)
    Dim oTbldmisg140 As New Table
    oTbldmisg140.Width = 1000
    oTbldmisg140.GridLines = GridLines.Both
    oTbldmisg140.Style.Add("margin-top", "15px")
    oTbldmisg140.Style.Add("margin-left", "10px")
    Dim oColdmisg140 As TableCell = Nothing
    Dim oRowdmisg140 As TableRow = Nothing
    'oRowdmisg140 = New TableRow
    'oColdmisg140 = New TableCell
    'oColdmisg140.Text = "Project"
    'oColdmisg140.Font.Bold = True
    'oRowdmisg140.Cells.Add(oColdmisg140)
    'oColdmisg140 = New TableCell
    'oColdmisg140.Text = oVar.t_cprj
    '  oColdmisg140.Style.Add("text-align","left")
    'oColdmisg140.ColumnSpan = "5"
    'oRowdmisg140.Cells.Add(oColdmisg140)
    'oTbldmisg140.Rows.Add(oRowdmisg140)
    'oRowdmisg140 = New TableRow
    'oColdmisg140 = New TableCell
    'oColdmisg140.Text = "Document"
    'oColdmisg140.Font.Bold = True
    'oRowdmisg140.Cells.Add(oColdmisg140)
    'oColdmisg140 = New TableCell
    'oColdmisg140.Text = oVar.t_docn
    '  oColdmisg140.Style.Add("text-align","left")
    'oColdmisg140.ColumnSpan = "2"
    'oRowdmisg140.Cells.Add(oColdmisg140)
    'oColdmisg140 = New TableCell
    'oColdmisg140.Text = "REV"
    'oColdmisg140.Font.Bold = True
    'oRowdmisg140.Cells.Add(oColdmisg140)
    'oColdmisg140 = New TableCell
    'oColdmisg140.Text = oVar.t_revn
    '  oColdmisg140.Style.Add("text-align","left")
    'oColdmisg140.ColumnSpan = "2"
    'oRowdmisg140.Cells.Add(oColdmisg140)
    'oTbldmisg140.Rows.Add(oRowdmisg140)
    'oRowdmisg140 = New TableRow
    'oColdmisg140 = New TableCell
    'oColdmisg140.Text = "Title"
    'oColdmisg140.Font.Bold = True
    'oRowdmisg140.Cells.Add(oColdmisg140)
    'oColdmisg140 = New TableCell
    'oColdmisg140.Text = oVar.t_dsca
    '  oColdmisg140.Style.Add("text-align","left")
    'oColdmisg140.ColumnSpan = "5"
    'oRowdmisg140.Cells.Add(oColdmisg140)
    'oTbldmisg140.Rows.Add(oRowdmisg140)
    'oRowdmisg140 = New TableRow
    'oColdmisg140 = New TableCell
    'oColdmisg140.Text = "Element"
    'oColdmisg140.Font.Bold = True
    'oRowdmisg140.Cells.Add(oColdmisg140)
    'oColdmisg140 = New TableCell
    'oColdmisg140.Text = oVar.t_cspa
    '  oColdmisg140.Style.Add("text-align","left")
    'oColdmisg140.ColumnSpan = "2"
    'oRowdmisg140.Cells.Add(oColdmisg140)
    'oColdmisg140 = New TableCell
    'oColdmisg140.Text = "Department"
    'oColdmisg140.Font.Bold = True
    'oRowdmisg140.Cells.Add(oColdmisg140)
    'oColdmisg140 = New TableCell
    'oColdmisg140.Text = oVar.t_resp
    '  oColdmisg140.Style.Add("text-align","left")
    'oColdmisg140.ColumnSpan = "2"
    'oRowdmisg140.Cells.Add(oColdmisg140)
    'oTbldmisg140.Rows.Add(oRowdmisg140)
    'oRowdmisg140 = New TableRow
    'oColdmisg140 = New TableCell
    'oColdmisg140.Text = "Released On"
    'oColdmisg140.Font.Bold = True
    'oRowdmisg140.Cells.Add(oColdmisg140)
    'oColdmisg140 = New TableCell
    'oColdmisg140.Text = oVar.t_lrrd
    '  oColdmisg140.Style.Add("text-align","center")
    'oColdmisg140.ColumnSpan = "5"
    'oRowdmisg140.Cells.Add(oColdmisg140)
    'oTbldmisg140.Rows.Add(oRowdmisg140)
    form1.Controls.Add(oTbldmisg140)
      Dim oTbldwgHoldList As Table = Nothing
      Dim oRowdwgHoldList As TableRow = Nothing
      Dim oColdwgHoldList As TableCell = Nothing
    Dim odwgHoldLists As List(Of SIS.DMISG.dwgHoldList) = SIS.DMISG.dwgHoldList.UZ_dwgHoldListSelectList(0, 999, "", False, "", t_docn, t_cprj)
    If odwgHoldLists.Count > 0 Then
      Dim oTblhdwgHoldList As Table = New Table
      oTblhdwgHoldList.Width = 1000
      oTblhdwgHoldList.Style.Add("margin-top", "15px")
      oTblhdwgHoldList.Style.Add("margin-left", "10px")
      oTblhdwgHoldList.Style.Add("margin-right", "10px")
      Dim oRowhdwgHoldList As TableRow = New TableRow
      Dim oColhdwgHoldList As TableCell = New TableCell
      oColhdwgHoldList.Font.Bold = True
      oColhdwgHoldList.Font.UnderLine = True
      oColhdwgHoldList.Font.Size = 10
      oColhdwgHoldList.CssClass = "grpHD"
      oColhdwgHoldList.Text = "Hold Drawing List"
      oRowhdwgHoldList.Cells.Add(oColhdwgHoldList)
      oTblhdwgHoldList.Rows.Add(oRowhdwgHoldList)
      form1.Controls.Add(oTblhdwgHoldList)
      oTbldwgHoldList = New Table
      oTbldwgHoldList.Width = 1000
      oTbldwgHoldList.GridLines = GridLines.Both
      oTbldwgHoldList.Style.Add("margin-left", "10px")
      oTbldwgHoldList.Style.Add("margin-right", "10px")
      oRowdwgHoldList = New TableRow
      oColdwgHoldList = New TableCell
      oColdwgHoldList.Text = "S.N."
      oColdwgHoldList.Font.Bold = True
      oColdwgHoldList.CssClass = "colHD"
      oColdwgHoldList.Style.Add("text-align","right")
      oRowdwgHoldList.Cells.Add(oColdwgHoldList)
      oColdwgHoldList = New TableCell
      oColdwgHoldList.Text = "Document"
      oColdwgHoldList.Font.Bold = True
      oColdwgHoldList.CssClass = "colHD"
      oColdwgHoldList.Style.Add("text-align","left")
      oRowdwgHoldList.Cells.Add(oColdwgHoldList)
      oColdwgHoldList = New TableCell
      oColdwgHoldList.Text = "Revision At Hold"
      oColdwgHoldList.Font.Bold = True
      oColdwgHoldList.CssClass = "colHD"
      oColdwgHoldList.Style.Add("text-align","left")
      oRowdwgHoldList.Cells.Add(oColdwgHoldList)
      oColdwgHoldList = New TableCell
      oColdwgHoldList.Text = "Title"
      oColdwgHoldList.Font.Bold = True
      oColdwgHoldList.CssClass = "colHD"
      oColdwgHoldList.Style.Add("text-align","left")
      oRowdwgHoldList.Cells.Add(oColdwgHoldList)
      oColdwgHoldList = New TableCell
      oColdwgHoldList.Text = "Element"
      oColdwgHoldList.Font.Bold = True
      oColdwgHoldList.CssClass = "colHD"
      oColdwgHoldList.Style.Add("text-align","left")
      oRowdwgHoldList.Cells.Add(oColdwgHoldList)
      oColdwgHoldList = New TableCell
      oColdwgHoldList.Text = "Responsible Dept"
      oColdwgHoldList.Font.Bold = True
      oColdwgHoldList.CssClass = "colHD"
      oColdwgHoldList.Style.Add("text-align","left")
      oRowdwgHoldList.Cells.Add(oColdwgHoldList)
      oColdwgHoldList = New TableCell
      oColdwgHoldList.Text = "Date Of Issue"
      oColdwgHoldList.Font.Bold = True
      oColdwgHoldList.CssClass = "colHD"
      oColdwgHoldList.Style.Add("text-align","center")
      oRowdwgHoldList.Cells.Add(oColdwgHoldList)
      oColdwgHoldList = New TableCell
      oColdwgHoldList.Text = "Input Received On"
      oColdwgHoldList.Font.Bold = True
      oColdwgHoldList.CssClass = "colHD"
      oColdwgHoldList.Style.Add("text-align","center")
      oRowdwgHoldList.Cells.Add(oColdwgHoldList)
      oColdwgHoldList = New TableCell
      oColdwgHoldList.Text = "Part Under Hold"
      oColdwgHoldList.Font.Bold = True
      oColdwgHoldList.CssClass = "colHD"
      oColdwgHoldList.Style.Add("text-align","left")
      oRowdwgHoldList.Cells.Add(oColdwgHoldList)
      oColdwgHoldList = New TableCell
      oColdwgHoldList.Text = "Reason For Hold"
      oColdwgHoldList.Font.Bold = True
      oColdwgHoldList.CssClass = "colHD"
      oColdwgHoldList.Style.Add("text-align","left")
      oRowdwgHoldList.Cells.Add(oColdwgHoldList)
      oColdwgHoldList = New TableCell
      oColdwgHoldList.Text = "Hold Removed Issued"
      oColdwgHoldList.Font.Bold = True
      oColdwgHoldList.CssClass = "colHD"
      oColdwgHoldList.Style.Add("text-align","center")
      oRowdwgHoldList.Cells.Add(oColdwgHoldList)
      oColdwgHoldList = New TableCell
      oColdwgHoldList.Text = "Revision At Unhold"
      oColdwgHoldList.Font.Bold = True
      oColdwgHoldList.CssClass = "colHD"
      oColdwgHoldList.Style.Add("text-align","left")
      oRowdwgHoldList.Cells.Add(oColdwgHoldList)
      oColdwgHoldList = New TableCell
      oColdwgHoldList.Text = "Hold Status"
      oColdwgHoldList.Font.Bold = True
      oColdwgHoldList.CssClass = "colHD"
      oColdwgHoldList.Style.Add("text-align","center")
      oRowdwgHoldList.Cells.Add(oColdwgHoldList)
      oColdwgHoldList = New TableCell
      oColdwgHoldList.Text = "Created By"
      oColdwgHoldList.Font.Bold = True
      oColdwgHoldList.CssClass = "colHD"
      oColdwgHoldList.Style.Add("text-align","left")
      oRowdwgHoldList.Cells.Add(oColdwgHoldList)
      oColdwgHoldList = New TableCell
      oColdwgHoldList.Text = "Created On"
      oColdwgHoldList.Font.Bold = True
      oColdwgHoldList.CssClass = "colHD"
      oColdwgHoldList.Style.Add("text-align","center")
      oRowdwgHoldList.Cells.Add(oColdwgHoldList)
      oTbldwgHoldList.Rows.Add(oRowdwgHoldList)
      For Each odwgHoldList As SIS.DMISG.dwgHoldList In odwgHoldLists
        oRowdwgHoldList = New TableRow
        oColdwgHoldList = New TableCell
        oColdwgHoldList.CssClass = "rowHD"
        oColdwgHoldList.Text = odwgHoldList.SerialNo
      oColdwgHoldList.Style.Add("text-align","right")
        oRowdwgHoldList.Cells.Add(oColdwgHoldList)
        oColdwgHoldList = New TableCell
        oColdwgHoldList.CssClass = "rowHD"
        oColdwgHoldList.Text = odwgHoldList.DocumentID
      oColdwgHoldList.Style.Add("text-align","left")
        oRowdwgHoldList.Cells.Add(oColdwgHoldList)
        oColdwgHoldList = New TableCell
        oColdwgHoldList.CssClass = "rowHD"
        oColdwgHoldList.Text = odwgHoldList.RevisionAtHold
      oColdwgHoldList.Style.Add("text-align","left")
        oRowdwgHoldList.Cells.Add(oColdwgHoldList)
        oColdwgHoldList = New TableCell
        oColdwgHoldList.CssClass = "rowHD"
        oColdwgHoldList.Text = odwgHoldList.Description
      oColdwgHoldList.Style.Add("text-align","left")
        oRowdwgHoldList.Cells.Add(oColdwgHoldList)
        oColdwgHoldList = New TableCell
        oColdwgHoldList.CssClass = "rowHD"
        oColdwgHoldList.Text = odwgHoldList.Element
      oColdwgHoldList.Style.Add("text-align","left")
        oRowdwgHoldList.Cells.Add(oColdwgHoldList)
        oColdwgHoldList = New TableCell
        oColdwgHoldList.CssClass = "rowHD"
        oColdwgHoldList.Text = odwgHoldList.ResponsibleDept
      oColdwgHoldList.Style.Add("text-align","left")
        oRowdwgHoldList.Cells.Add(oColdwgHoldList)
        oColdwgHoldList = New TableCell
        oColdwgHoldList.CssClass = "rowHD"
        oColdwgHoldList.Text = odwgHoldList.DateOfIssue
      oColdwgHoldList.Style.Add("text-align","center")
        oRowdwgHoldList.Cells.Add(oColdwgHoldList)
        oColdwgHoldList = New TableCell
        oColdwgHoldList.CssClass = "rowHD"
        oColdwgHoldList.Text = odwgHoldList.InputReceivedOn
      oColdwgHoldList.Style.Add("text-align","center")
        oRowdwgHoldList.Cells.Add(oColdwgHoldList)
        oColdwgHoldList = New TableCell
        oColdwgHoldList.CssClass = "rowHD"
        oColdwgHoldList.Text = odwgHoldList.PartUnderHold
      oColdwgHoldList.Style.Add("text-align","left")
        oRowdwgHoldList.Cells.Add(oColdwgHoldList)
        oColdwgHoldList = New TableCell
        oColdwgHoldList.CssClass = "rowHD"
        oColdwgHoldList.Text = odwgHoldList.ReasonForHold
      oColdwgHoldList.Style.Add("text-align","left")
        oRowdwgHoldList.Cells.Add(oColdwgHoldList)
        oColdwgHoldList = New TableCell
        oColdwgHoldList.CssClass = "rowHD"
        oColdwgHoldList.Text = odwgHoldList.HoldRemovedIssued
      oColdwgHoldList.Style.Add("text-align","center")
        oRowdwgHoldList.Cells.Add(oColdwgHoldList)
        oColdwgHoldList = New TableCell
        oColdwgHoldList.CssClass = "rowHD"
        oColdwgHoldList.Text = odwgHoldList.RevisionAtUnhold
      oColdwgHoldList.Style.Add("text-align","left")
        oRowdwgHoldList.Cells.Add(oColdwgHoldList)
        oColdwgHoldList = New TableCell
        oColdwgHoldList.CssClass = "rowHD"
        oColdwgHoldList.Text = IIf(odwgHoldList.HoldStatus, "YES", "NO")
      oColdwgHoldList.Style.Add("text-align","center")
        oRowdwgHoldList.Cells.Add(oColdwgHoldList)
        oColdwgHoldList = New TableCell
        oColdwgHoldList.Text = odwgHoldList.aspnet_users1_UserFullName
        oColdwgHoldList.CssClass = "rowHD"
      oColdwgHoldList.Style.Add("text-align","left")
        oRowdwgHoldList.Cells.Add(oColdwgHoldList)
        oColdwgHoldList = New TableCell
        oColdwgHoldList.CssClass = "rowHD"
        oColdwgHoldList.Text = odwgHoldList.CreatedOn
      oColdwgHoldList.Style.Add("text-align","center")
        oRowdwgHoldList.Cells.Add(oColdwgHoldList)
        oTbldwgHoldList.Rows.Add(oRowdwgHoldList)
      Next
      form1.Controls.Add(oTbldwgHoldList)
    End If
  End Sub
End Class
