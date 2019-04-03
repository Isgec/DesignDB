Partial Class GF_ProjectDBDetails
  Inherits System.Web.UI.Page

  Private Sub ShowPPLMData(ByVal x As String, ByVal y As String)
    Dim Data As List(Of SIS.DB.ProDoc) = SIS.DB.ProDoc.GetProData(x, y)
    Dim tbl As New Table


    With tbl

      .GridLines = GridLines.Both
      .BorderWidth = 2
      .CellSpacing = 2
      .Width = Unit.Percentage(100)
      If (x Like "Process_Delayed") Then
        .CssClass = "table-danger table-bordered thead-primary table-hover"
      End If
      If (x Like "Mechanical_Delayed") Then
        .CssClass = "table-danger table-bordered thead-primary table-hover"
      End If
      If (x Like "Structure_Delayed") Then
        .CssClass = "table-danger table-bordered thead-primary table-hover"
      End If
      If (x Like "CI_Delayed") Then
        .CssClass = "table-danger table-bordered thead-primary table-hover"
      End If
      If (x Like "Electrical_Delayed") Then
        .CssClass = "table-danger table-bordered thead-primary table-hover"
      End If
      If (x Like "Piping_Delayed") Then
        .CssClass = "table-danger table-bordered thead-primary table-hover"
      End If
      If (x Like "Total_Delayed") Then
        .CssClass = "table-danger table-bordered thead-primary table-hover"
      End If


      If (x Like "Process_Ontime") Then
        .CssClass = "table-success table-bordered thead-primary table-hover"
      End If
      If (x Like "Mechanical_Ontime") Then
        .CssClass = "table-success table-bordered thead-primary table-hover"
      End If
      If (x Like "Structure_Ontime") Then
        .CssClass = "table-success table-bordered thead-primary table-hover"
      End If
      If (x Like "CI_Ontime") Then
        .CssClass = "table-success table-bordered thead-primary table-hover"
      End If
      If (x Like "Electrical_Ontime") Then
        .CssClass = "table-success table-bordered thead-primary table-hover"
      End If
      If (x Like "Piping_Ontime") Then
        .CssClass = "table-success table-bordered thead-primary table-hover"
      End If
      If (x Like "Total_Ontime") Then
        .CssClass = "table-success table-bordered thead-primary table-hover"
      End If

      If (x Like "Process_Due") Then
        .CssClass = "table-warning table-bordered thead-primary table-hover"
      End If
      If (x Like "Mechanical_Due") Then
        .CssClass = "table-warning table-bordered thead-primary table-hover"
      End If
      If (x Like "Structure_Due") Then
        .CssClass = "table-warning table-bordered thead-primary table-hover"
      End If
      If (x Like "CI_Due") Then
        .CssClass = "table-warning table-bordered thead-primary table-hover"
      End If
      If (x Like "Electrical_Due") Then
        .CssClass = "table-warning table-bordered thead-primary table-hover"
      End If
      If (x Like "Piping_Due") Then
        .CssClass = "table-warning table-bordered thead-primary table-hover"
      End If
      If (x Like "Total_Due") Then
        .CssClass = "table-warning table-bordered thead-primary table-hover"
      End If

      'If (x = "Mechanical_Total") Then
      '  .CssClass = "table-warning"
      'End If
      '  .CssClass = "table-danger table-bordered thead-primary table-hover"

    End With

    Dim tr As TableRow = Nothing
    Dim td As TableCell = Nothing



    'Header
    tr = New TableRow

    td = New TableCell
    td.Text = "S.NO."
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    td.Text = "DOCUMENT NUMBER"
    tr.Cells.Add(td)


    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    td.Text = "REV."
    tr.Cells.Add(td)


    td = New TableCell
      With td
        .Font.Bold = True
        .Font.Size = FontUnit.Point(8)
      End With
      td.Text = "TITTLE"
      tr.Cells.Add(td)

      td = New TableCell
      With td
        .Font.Bold = True
        .Font.Size = FontUnit.Point(8)
      End With
      td.Text = "BASELINE"
      tr.Cells.Add(td)

      td = New TableCell
      With td
        .Font.Bold = True
        .Font.Size = FontUnit.Point(8)
      End With
      td.Text = "LATEST SCHEDULE"
      tr.Cells.Add(td)

      td = New TableCell
      With td
        .Font.Bold = True
        .Font.Size = FontUnit.Point(8)
      End With
      td.Text = "ACTUAL RELEASE"
      tr.Cells.Add(td)


    tbl.Rows.Add(tr)

    Dim I As Integer = 0
    '================
    For Each tmp As SIS.DB.ProDoc In Data
      I += 1
      tr = New TableRow

      td = New TableCell
      td.Text = I
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.t_docn
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.t_revn
      tr.Cells.Add(td)


      td = New TableCell
        td.Text = tmp.t_dsca
        tr.Cells.Add(td)

        td = New TableCell
        If (tmp.t_bsfd = "01/01/1970") Then tmp.t_bsfd = ""
        td.Text = tmp.t_bsfd
        tr.Cells.Add(td)

        td = New TableCell
        If (tmp.t_rsfd = "01/01/1970") Then tmp.t_rsfd = ""
        td.Text = tmp.t_rsfd
        tr.Cells.Add(td)


        td = New TableCell
        If (tmp.t_acdt = "01/01/1970") Then tmp.t_acdt = ""
        ' Dim t As Date = DateAdd(DateInterval.Minute, 330, tmp.t_acdt)
        td.Text = tmp.t_acdt
        tr.Cells.Add(td)


      tbl.Rows.Add(tr)


    Next
    '================
    ppnlDetails.Controls.Add(tbl)

  End Sub

  Private Sub ShowPLMData(ByVal x As String, ByVal y As String)
    Dim Data As List(Of SIS.DB.ProDoc) = SIS.DB.ProDoc.GetProData(x, y)
    Dim tbl As New Table

    With tbl

      .GridLines = GridLines.Both
      .BorderWidth = 2
      .CellSpacing = 2
      .Width = Unit.Percentage(100)

    End With

    Dim tr As TableRow = Nothing
    Dim td As TableCell = Nothing

    'Header
    tr = New TableRow

    td = New TableCell
    td.Text = "S.NO."
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    td.Text = "DOCUMENT NUMBER"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    td.Text = "REV."
    tr.Cells.Add(td)

    td = New TableCell
      With td
        .Font.Bold = True
        .Font.Size = FontUnit.Point(8)
      End With
      td.Text = "TITTLE"
      tr.Cells.Add(td)

      td = New TableCell
      With td
        .Font.Bold = True
        .Font.Size = FontUnit.Point(8)
      End With
      td.Text = "RESPONSIBLE"
      tr.Cells.Add(td)

      td = New TableCell
      With td
        .Font.Bold = True
        .Font.Size = FontUnit.Point(8)
      End With
      td.Text = "APPROVER"
      tr.Cells.Add(td)

      td = New TableCell
      With td
        .Font.Bold = True
        .Font.Size = FontUnit.Point(8)
      End With
      td.Text = "CHECKER"
      tr.Cells.Add(td)

      td = New TableCell
      With td
        .Font.Bold = True
        .Font.Size = FontUnit.Point(8)
      End With
      td.Text = "DESIGNER"
      tr.Cells.Add(td)

      td = New TableCell
      With td
        .Font.Bold = True
        .Font.Size = FontUnit.Point(8)
      End With
      td.Text = "STATE"
      tr.Cells.Add(td)

      td = New TableCell
      With td
        .Font.Bold = True
        .Font.Size = FontUnit.Point(8)
      End With
      td.Text = "WORKFLOW"
      tr.Cells.Add(td)

      td = New TableCell
      With td
        .Font.Bold = True
        .Font.Size = FontUnit.Point(8)
      End With
      td.Text = "SOFTWARE"
      tr.Cells.Add(td)

    tbl.Rows.Add(tr)

    Dim I As Integer = 0
    '================
    For Each tmp As SIS.DB.ProDoc In Data
      I += 1
      tr = New TableRow

      td = New TableCell
      td.Text = I
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.t_docn
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.t_revn
      tr.Cells.Add(td)

      td = New TableCell
        td.Text = tmp.t_dttl
        tr.Cells.Add(td)

        td = New TableCell
        td.Text = tmp.t_resp
        tr.Cells.Add(td)

        td = New TableCell
        td.Text = tmp.t_appb
        tr.Cells.Add(td)

        td = New TableCell
        td.Text = tmp.t_chkb
        tr.Cells.Add(td)

        td = New TableCell
        td.Text = tmp.t_drwb
        tr.Cells.Add(td)

        td = New TableCell
        td.Text = tmp.t_stat
        tr.Cells.Add(td)

        td = New TableCell
        td.Text = tmp.t_wfst
        tr.Cells.Add(td)

        td = New TableCell
        td.Text = tmp.t_soft
        tr.Cells.Add(td)

      tbl.Rows.Add(tr)

    Next
    '================
    ppnlDetails.Controls.Add(tbl)

  End Sub

  Private Sub ShowDCRData(ByVal x As String, ByVal y As String)
    Dim Data As List(Of SIS.DB.ProDoc) = SIS.DB.ProDoc.GetProData(x, y)
    Dim tbl As New Table

    With tbl

      .GridLines = GridLines.Both
      .BorderWidth = 2
      .CellSpacing = 2
      .Width = Unit.Percentage(100)

    End With

    Dim tr As TableRow = Nothing
    Dim td As TableCell = Nothing

    'Header
    tr = New TableRow

    td = New TableCell
    td.Text = "S.NO."
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    td.Text = "DCR NUMBER"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    td.Text = "DESCRIPTION"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    td.Text = "ELEMENT"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    td.Text = "STATUS"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    td.Text = "REQUEST PRIORITY"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    td.Text = "COMPONENT STASUS"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    td.Text = "CREATED BY"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    td.Text = "APPROVER"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    td.Text = "Owner Department"
    tr.Cells.Add(td)


    tbl.Rows.Add(tr)

    Dim I As Integer = 0
    '================
    For Each tmp As SIS.DB.ProDoc In Data
      I += 1
      tr = New TableRow

      td = New TableCell
      td.Text = I
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.t_dcrn
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.t_dsca
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.element
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.t_stat
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.t_reqs
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.t_comp
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.t_crea
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.t_user
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.Owner_Dept
      tr.Cells.Add(td)

      tbl.Rows.Add(tr)

    Next
    '================
    ppnlDetails.Controls.Add(tbl)

  End Sub

  Private Sub ShowIDMSData(ByVal x As String, ByVal y As String)
    Dim Data As List(Of SIS.DB.ProDoc) = SIS.DB.ProDoc.GetProData(x, y)
    Dim tbl As New Table

    With tbl

      .GridLines = GridLines.Both
      .BorderWidth = 2
      .CellSpacing = 2
      .Width = Unit.Percentage(100)

    End With

    Dim tr As TableRow = Nothing
    Dim td As TableCell = Nothing

    'Header
    tr = New TableRow

    td = New TableCell
    td.Text = "S.NO."
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    td.Text = "TRANSMITTAL ID"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    td.Text = "TRANSMITTAL TYPE"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    td.Text = "TITTLE"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    td.Text = "STATE"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    td.Text = "CREATED BY"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    td.Text = "APPROVED BY"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    td.Text = "ISSUED VIA"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    td.Text = "ISSUED BY"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    td.Text = "ISSUE DATE"
    tr.Cells.Add(td)


    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    td.Text = "OWNER_DEPARTMENT"
    tr.Cells.Add(td)



    tbl.Rows.Add(tr)

    Dim I As Integer = 0
    '================
    For Each tmp As SIS.DB.ProDoc In Data
      I += 1
      tr = New TableRow

      td = New TableCell
      td.Text = I
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.t_tran
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.t_type
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.t_subj
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.t_stat
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.t_user
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.t_apsu
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.t_issu
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.t_isby
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.t_isdt
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.Owner_Dept
      tr.Cells.Add(td)

      tbl.Rows.Add(tr)

    Next
    '================
    ppnlDetails.Controls.Add(tbl)

  End Sub

  Private Sub ShowSARData(ByVal x As String, ByVal y As String)
    Dim Data As List(Of SIS.DB.ProDoc) = SIS.DB.ProDoc.GetProData(x, y)
    Dim tbl As New Table

    With tbl

      .GridLines = GridLines.Both
      .BorderWidth = 2
      .CellSpacing = 2
      .Width = Unit.Percentage(100)

    End With

    Dim tr As TableRow = Nothing
    Dim td As TableCell = Nothing

    'Header
    tr = New TableRow

    td = New TableCell
    td.Text = "S.NO."
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    td.Text = "SAR NUMBER"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    td.Text = "DESCRIPTION"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    td.Text = "ELEMENT"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    td.Text = "STATUS"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    td.Text = "Created by"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    td.Text = "Reviewed by"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    td.Text = "Approved BY"
    tr.Cells.Add(td)


    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    td.Text = "OWNER_DEPARTMENT"
    tr.Cells.Add(td)




    tbl.Rows.Add(tr)

    Dim I As Integer = 0
    '================
    For Each tmp As SIS.DB.ProDoc In Data
      I += 1
      tr = New TableRow

      td = New TableCell
      td.Text = I
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.t_sarn
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.t_draw
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.element
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.t_stat
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.t_prep
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.t_rper
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.t_apby
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.Owner_Dept
      tr.Cells.Add(td)



      tbl.Rows.Add(tr)

    Next
    '================
    ppnlDetails.Controls.Add(tbl)

  End Sub

  Private Sub ShowPOData(ByVal x As String, ByVal y As String)
    Dim Data As List(Of SIS.DB.ProDoc) = SIS.DB.ProDoc.GetProData(x, y)
    Dim tbl As New Table

    With tbl

      .GridLines = GridLines.Both
      .BorderWidth = 2
      .CellSpacing = 2
      .Width = Unit.Percentage(100)

    End With

    Dim tr As TableRow = Nothing
    Dim td As TableCell = Nothing

    'Header
    tr = New TableRow

    td = New TableCell
    td.Text = "S.NO."
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    td.Text = "RECEIPT NUMBER"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    td.Text = "REVISION"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    td.Text = "ITEM"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    td.Text = "MECH"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    td.Text = "STR"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    td.Text = "PIP"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    td.Text = "PRC"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    td.Text = "C&I"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    td.Text = "ELECTRICAL"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    td.Text = "QUALITY"
    tr.Cells.Add(td)


    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    td.Text = "STATUS"
    tr.Cells.Add(td)


    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    td.Text = "OWNER_DEPARTMENT"
    tr.Cells.Add(td)

    tbl.Rows.Add(tr)

    Dim I As Integer = 0
    '================
    For Each tmp As SIS.DB.ProDoc In Data
      I += 1
      tr = New TableRow

      td = New TableCell
      td.Text = I
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.t_rcno
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.t_revn
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.t_item
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.IMechanical
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.IStructure
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.IPiping
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.IProcess
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.IC_I
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.IElectrical
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.IQuality
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.t_stat
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.Owner_Dept
      tr.Cells.Add(td)

      tbl.Rows.Add(tr)

    Next
    '================
    ppnlDetails.Controls.Add(tbl)

  End Sub

  Private Sub ShowelementData(ByVal x As String, ByVal y As String)
    Dim Data As List(Of SIS.DB.ProDoc) = SIS.DB.ProDoc.GetProData(x, y)
    Dim tbl As New Table

    With tbl

      .GridLines = GridLines.Both
      .BorderWidth = 2
      .CellSpacing = 2
      .Width = Unit.Percentage(100)

    End With

    Dim tr As TableRow = Nothing
    Dim td As TableCell = Nothing

    'Header
    tr = New TableRow

    td = New TableCell
    td.Text = "S.NO."
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    td.Text = "ELEMENT"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    td.Text = "STATUS"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    td.Text = "DESCRIPTION"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    td.Text = "OWNER_DEPARTMENT"
    tr.Cells.Add(td)


    tbl.Rows.Add(tr)

    Dim I As Integer = 0
    '================
    For Each tmp As SIS.DB.ProDoc In Data
      I += 1
      tr = New TableRow

      td = New TableCell
      td.Text = I
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.TT_CSPA
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.TT_ENGS
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.TT_TITTLE
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.TT_DEPT
      tr.Cells.Add(td)




      tbl.Rows.Add(tr)

    Next
    '================
    ppnlDetails.Controls.Add(tbl)

  End Sub

  Private Sub GF_ProjectDBDetails_Load(sender As Object, e As EventArgs) Handles Me.Load
    Dim Det As String = Request.QueryString("detail")
    Dim PrjID As String = Request.QueryString("PrjID")
    If (Det = "Process_Total") Then
      PPSheading.Text = "PROCESS : TOTAL DWGS/DOCS LIST FROM PMDL"


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "Mechanical_Total") Then
      PPSheading.Text = "MECHANICAL : TOTAL DWGS/DOCS LIST FROM PMDL"


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "Structure_Total") Then
      PPSheading.Text = "STRUCTURE : TOTAL DWGS/DOCS LIST FROM PMDL"


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "Piping_Total") Then
      PPSheading.Text = "PIPING : TOTAL DWGS/DOCS LIST FROM PMDL"


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "Electrical_Total") Then
      PPSheading.Text = "ELECTRICAL : TOTAL DWGS/DOCS LIST FROM PMDL"


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "CI_Total") Then
      PPSheading.Text = "MECHANICAL : TOTAL DWGS/DOCS LIST FROM PMDL"


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "Total_Total") Then
      PPSheading.Text = "All DIVISION : TOTAL DWGS/DOCS LIST FROM PMDL"


      ShowPPLMData(Det, PrjID)
    End If

    '---------

    If (Det = "Process_Released") Then
      PPSheading.Text = "PROCESS : TOTAL RELEASED DWGS/DOCS LIST FROM PMDL"


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "Mechanical_Released") Then
      PPSheading.Text = "MECHANICAL : TOTAL RELEASED DWGS/DOCS LIST FROM PMDL"


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "Structure_Released") Then
      PPSheading.Text = "STRUCTURE : TOTAL RELEASED DWGS/DOCS LIST FROM PMDL"


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "Piping_Released") Then
      PPSheading.Text = "PIPING : TOTAL RELEASED DWGS/DOCS LIST FROM PMDL"


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "Electrical_Released") Then
      PPSheading.Text = "ELECTRICAL : TOTAL RELEASED DWGS/DOCS LIST FROM PMDL"


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "CI_Released") Then
      PPSheading.Text = "MECHANICAL : TOTAL RELEASED DWGS/DOCS LIST FROM PMDL"


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "Total_Released") Then
      PPSheading.Text = "All DIVISION : TOTAL RELEASED DWGS/DOCS LIST FROM PMDL"


      ShowPPLMData(Det, PrjID)
    End If

    '---

    If (Det = "Process_Pending") Then
      PPSheading.Text = "PROCESS : TOTAL PENDING DWGS/DOCS LIST FROM PMDL"


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "Mechanical_Pending") Then
      PPSheading.Text = "MECHANICAL : TOTAL PENDING DWGS/DOCS LIST FROM PMDL"


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "Structure_Pending") Then
      PPSheading.Text = "STRUCTURE : TOTAL PENDING DWGS/DOCS LIST FROM PMDL"


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "Piping_Pending") Then
      PPSheading.Text = "PIPING : TOTAL PENDING DWGS/DOCS LIST FROM PMDL"


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "Electrical_Pending") Then
      PPSheading.Text = "ELECTRICAL : TOTAL PENDING DWGS/DOCS LIST FROM PMDL"


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "CI_Pending") Then
      PPSheading.Text = "MECHANICAL : TOTAL PENDING DWGS/DOCS LIST FROM PMDL"


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "Total_Pending") Then
      PPSheading.Text = "All DIVISION : TOTAL PENDING DWGS/DOCS LIST FROM PMDL"


      ShowPPLMData(Det, PrjID)
    End If


    If (Det = "Process_Ontime") Then
      PPSheading.Text = "PROCESS : TOTAL Ontime DWGS/DOCS LIST FROM PMDL"


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "Mechanical_Ontime") Then
      PPSheading.Text = "MECHANICAL : TOTAL Ontime DWGS/DOCS LIST FROM PMDL"


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "Structure_Ontime") Then
      PPSheading.Text = "STRUCTURE : TOTAL Ontime DWGS/DOCS LIST FROM PMDL"


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "Piping_Ontime") Then
      PPSheading.Text = "PIPING : TOTAL Ontime DWGS/DOCS LIST FROM PMDL"


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "Electrical_Ontime") Then
      PPSheading.Text = "ELECTRICAL : TOTAL Ontime DWGS/DOCS LIST FROM PMDL"


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "CI_Ontime") Then
      PPSheading.Text = "MECHANICAL : TOTAL Ontime DWGS/DOCS LIST FROM PMDL"


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "Total_Ontime") Then
      PPSheading.Text = "All DIVISION : TOTAL Ontime DWGS/DOCS LIST FROM PMDL"


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "Process_Delayed") Then
      PPSheading.Text = "PROCESS : TOTAL Delayed DWGS/DOCS LIST FROM PMDL"


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "Mechanical_Delayed") Then
      PPSheading.Text = "MECHANICAL : TOTAL Delayed DWGS/DOCS LIST FROM PMDL"


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "Structure_Delayed") Then
      PPSheading.Text = "STRUCTURE : TOTAL Delayed DWGS/DOCS LIST FROM PMDL"


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "Piping_Delayed") Then
      PPSheading.Text = "PIPING : TOTAL Delayed DWGS/DOCS LIST FROM PMDL"


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "Electrical_Delayed") Then
      PPSheading.Text = "ELECTRICAL : TOTAL Delayed DWGS/DOCS LIST FROM PMDL"


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "CI_Delayed") Then
      PPSheading.Text = "MECHANICAL : TOTAL Delayed DWGS/DOCS LIST FROM PMDL"


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "Total_Delayed") Then
      PPSheading.Text = "All DIVISION : TOTAL Delayed DWGS/DOCS LIST FROM PMDL"


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "Process_Due") Then
      PPSheading.Text = "PROCESS : TOTAL DUE ON TODAY FOR RELEASE DWGS/DOCS LIST FROM PMDL"


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "Mechanical_Due") Then
      PPSheading.Text = "MECHANICAL : TOTAL DUE ON TODAY FOR RELEASE DWGS/DOCS LIST FROM PMDL"


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "Structure_Due") Then
      PPSheading.Text = "STRUCTURE : TOTAL DUE ON TODAY FOR RELEASE DWGS/DOCS LIST FROM PMDL"


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "Piping_Due") Then
      PPSheading.Text = "PIPING : TOTAL DUE ON TODAY FOR RELEASE DWGS/DOCS LIST FROM PMDL"


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "Electrical_Due") Then
      PPSheading.Text = "ELECTRICAL : TOTAL DUE ON TODAY FOR RELEASE DWGS/DOCS LIST FROM PMDL"
      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "CI_Due") Then
      PPSheading.Text = "MECHANICAL : TOTAL DUE ON TODAY FOR RELEASE DWGS/DOCS LIST FROM PMDL"
      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "Total_Due") Then
      PPSheading.Text = "All DIVISION : TOTAL DUE ON TODAY FOR RELEASE DWGS/DOCS LIST FROM PMDL"
      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "PLM_CHART") Then
      PPSheading.Text = "Drawing Document Release Status -Details"
      ShowPLMData(Det, PrjID)
    End If



    If (Det = "DCR_CHART") Then
      PPSheading.Text = "DCR Status -Details"
      ShowDCRData(Det, PrjID)
    End If


    If (Det = "IDMS_CHART") Then
      PPSheading.Text = "IDMS Status -Details"
      ShowIDMSData(Det, PrjID)
    End If

    If (Det = "IDMSC_CHART") Then
      PPSheading.Text = "IDMS Status -Details"
      ShowIDMSData(Det, PrjID)
    End If
    If (Det = "IDMSI_CHART") Then
      PPSheading.Text = "IDMS Status -Details"
      ShowIDMSData(Det, PrjID)
    End If
    If (Det = "IDMSS_CHART") Then
      PPSheading.Text = "IDMS Status -Details"
      ShowIDMSData(Det, PrjID)
    End If
    If (Det = "IDMSV_CHART") Then
      PPSheading.Text = "IDMS Status -Details"
      ShowIDMSData(Det, PrjID)
    End If

    If (Det = "IDMSII_CHART") Then
      PPSheading.Text = "IDMS Status -Details"
      ShowIDMSData(Det, PrjID)
    End If


    If (Det = "SAR_CHART") Then
      PPSheading.Text = "SAR Status -Details"
      ShowSARData(Det, PrjID)
    End If

    If (Det = "IDMSP_CHART") Then
      PPSheading.Text = "IDMS Pre Order Status -Details"
      ShowPOData(Det, PrjID)
    End If

    If (Det = "IDMSO_CHART") Then
      PPSheading.Text = "IDMS Post Order Status -Details"
      ShowPOData(Det, PrjID)
    End If

    If (Det = "ELEMENT_CHART") Then
      PPSheading.Text = "Element Completion Status -Details"
      ShowelementData(Det, PrjID)
    End If



  End Sub
End Class
