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
    td.Text = "ID"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    td.Text = "TYPE"
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
    td.Text = "CREATED"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    td.Text = "APPROVED"
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
    td.Text = "ISSUED"
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
    td.Text = "RECEIPT"
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
    td.Text = "PROJECT"
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
    td.Text = "DESCRIPTION"
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
      td.Text = tmp.t_cprj
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.t_item
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.t_dsca
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.IMechanical
      If (td.Text = "Pending" And tmp.t_stat = "Under Evaluation") Then
        td.ForeColor = Drawing.Color.Red
        With td
          .Font.Bold = True

        End With
      End If
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.IStructure
      If (td.Text = "Pending" And tmp.t_stat = "Under Evaluation") Then
        td.ForeColor = Drawing.Color.Red
        With td
          .Font.Bold = True

        End With
      End If

      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.IPiping
      If (td.Text = "Pending" And tmp.t_stat = "Under Evaluation") Then
        td.ForeColor = Drawing.Color.Red
        With td
          .Font.Bold = True

        End With
      End If
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.IProcess
      If (td.Text = "Pending" And tmp.t_stat = "Under Evaluation") Then
        td.ForeColor = Drawing.Color.Red
        With td
          .Font.Bold = True

        End With
      End If
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.IC_I
      If (td.Text = "Pending" And tmp.t_stat = "Under Evaluation") Then
        td.ForeColor = Drawing.Color.Red
        With td
          .Font.Bold = True

        End With
      End If
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.IElectrical
      If (td.Text = "Pending" And tmp.t_stat = "Under Evaluation") Then
        td.ForeColor = Drawing.Color.Red
        With td
          .Font.Bold = True

        End With
      End If
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.IQuality
      If (td.Text = "Pending" And tmp.t_stat = "Under Evaluation") Then
        td.ForeColor = Drawing.Color.Red
        With td
          .Font.Bold = True

        End With
      End If
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

  Private Sub ShowHoldData(ByVal x As String, ByVal y As String)
    Dim Data As List(Of SIS.DB.ProDoc) = SIS.DB.ProDoc.GetProHOLDData(x, y)
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
    td.Text = "DOCUMENT ID"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    td.Text = "SERIAL NO"
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
    td.Text = "DEPT."
    tr.Cells.Add(td)


    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    td.Text = "PartUnderHold"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    td.Text = "ReasonforHold"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    td.Text = "Rev.@Hold"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    td.Text = "Rev.@Unhold"
    tr.Cells.Add(td)


    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    td.Text = "CreatedBy"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    td.Text = "CreatedOn"
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
      td.Text = tmp.DocumentID
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.SerialNo
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.Description
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.ResponsibleDept
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.PartUnderHold
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.reasonforHold
      tr.Cells.Add(td)


      td = New TableCell
      td.Text = tmp.RevisionAtHold
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.RevisionAtUnhold
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.CreatedBy
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.CreatedOn
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
      PPSheading.Text = "PROCESS : TOTAL DWGS/DOCS LIST FROM PMDL FOR PROJECT - " & PrjID


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "Mechanical_Total") Then
      PPSheading.Text = "MECHANICAL : TOTAL DWGS/DOCS LIST FROM PMDL FOR PROJECT - " & PrjID


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "Structure_Total") Then
      PPSheading.Text = "STRUCTURE : TOTAL DWGS/DOCS LIST FROM PMDL FOR PROJECT - " & PrjID


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "Piping_Total") Then
      PPSheading.Text = "PIPING : TOTAL DWGS/DOCS LIST FROM PMDL FOR PROJECT - " & PrjID


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "Electrical_Total") Then
      PPSheading.Text = "ELECTRICAL : TOTAL DWGS/DOCS LIST FROM PMDL FOR PROJECT - " & PrjID


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "CI_Total") Then
      PPSheading.Text = "MECHANICAL : TOTAL DWGS/DOCS LIST FROM PMDL FOR PROJECT - " & PrjID


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "Total_Total") Then
      PPSheading.Text = "All DIVISION : TOTAL DWGS/DOCS LIST FROM PMDL FOR PROJECT - " & PrjID


      ShowPPLMData(Det, PrjID)
    End If

    '---------

    If (Det = "Process_Released") Then
      PPSheading.Text = "PROCESS : TOTAL RELEASED DWGS/DOCS LIST FROM PMDL FOR PROJECT - " & PrjID


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "Mechanical_Released") Then
      PPSheading.Text = "MECHANICAL : TOTAL RELEASED DWGS/DOCS LIST FROM PMDL FOR PROJECT - " & PrjID


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "Structure_Released") Then
      PPSheading.Text = "STRUCTURE : TOTAL RELEASED DWGS/DOCS LIST FROM PMDL FOR PROJECT - " & PrjID


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "Piping_Released") Then
      PPSheading.Text = "PIPING : TOTAL RELEASED DWGS/DOCS LIST FROM PMDL FOR PROJECT - " & PrjID


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "Electrical_Released") Then
      PPSheading.Text = "ELECTRICAL : TOTAL RELEASED DWGS/DOCS LIST FROM PMDL FOR PROJECT - " & PrjID


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "CI_Released") Then
      PPSheading.Text = "MECHANICAL : TOTAL RELEASED DWGS/DOCS LIST FROM PMDL FOR PROJECT - " & PrjID


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "Total_Released") Then
      PPSheading.Text = "All DIVISION : TOTAL RELEASED DWGS/DOCS LIST FROM PMDL FOR PROJECT - " & PrjID


      ShowPPLMData(Det, PrjID)
    End If

    '---

    If (Det = "Process_Pending") Then
      PPSheading.Text = "PROCESS : TOTAL PENDING DWGS/DOCS LIST FROM PMDL FOR PROJECT - " & PrjID


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "Mechanical_Pending") Then
      PPSheading.Text = "MECHANICAL : TOTAL PENDING DWGS/DOCS LIST FROM PMDL FOR PROJECT - " & PrjID


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "Structure_Pending") Then
      PPSheading.Text = "STRUCTURE : TOTAL PENDING DWGS/DOCS LIST FROM PMDL FOR PROJECT - " & PrjID


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "Piping_Pending") Then
      PPSheading.Text = "PIPING : TOTAL PENDING DWGS/DOCS LIST FROM PMDL FOR PROJECT - " & PrjID


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "Electrical_Pending") Then
      PPSheading.Text = "ELECTRICAL : TOTAL PENDING DWGS/DOCS LIST FROM PMDL FOR PROJECT - " & PrjID


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "CI_Pending") Then
      PPSheading.Text = "MECHANICAL : TOTAL PENDING DWGS/DOCS LIST FROM PMDL FOR PROJECT - " & PrjID


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "Total_Pending") Then
      PPSheading.Text = "All DIVISION : TOTAL PENDING DWGS/DOCS LIST FROM PMDL FOR PROJECT - " & PrjID


      ShowPPLMData(Det, PrjID)
    End If


    If (Det = "Process_Ontime") Then
      PPSheading.Text = "PROCESS : TOTAL Ontime DWGS/DOCS LIST FROM PMDL FOR PROJECT - " & PrjID


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "Mechanical_Ontime") Then
      PPSheading.Text = "MECHANICAL : TOTAL Ontime DWGS/DOCS LIST FROM PMDL FOR PROJECT - " & PrjID


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "Structure_Ontime") Then
      PPSheading.Text = "STRUCTURE : TOTAL Ontime DWGS/DOCS LIST FROM PMDL FOR PROJECT - " & PrjID


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "Piping_Ontime") Then
      PPSheading.Text = "PIPING : TOTAL Ontime DWGS/DOCS LIST FROM PMDL FOR PROJECT - " & PrjID


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "Electrical_Ontime") Then
      PPSheading.Text = "ELECTRICAL : TOTAL Ontime DWGS/DOCS LIST FROM PMDL FOR PROJECT - " & PrjID


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "CI_Ontime") Then
      PPSheading.Text = "MECHANICAL : TOTAL Ontime DWGS/DOCS LIST FROM PMDL FOR PROJECT - " & PrjID


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "Total_Ontime") Then
      PPSheading.Text = "All DIVISION : TOTAL Ontime DWGS/DOCS LIST FROM PMDL FOR PROJECT - " & PrjID


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "Process_Delayed") Then
      PPSheading.Text = "PROCESS : TOTAL Delayed DWGS/DOCS LIST FROM PMDL FOR PROJECT - " & PrjID


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "Mechanical_Delayed") Then
      PPSheading.Text = "MECHANICAL : TOTAL Delayed DWGS/DOCS LIST FROM PMDL FOR PROJECT - " & PrjID


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "Structure_Delayed") Then
      PPSheading.Text = "STRUCTURE : TOTAL Delayed DWGS/DOCS LIST FROM PMDL FOR PROJECT - " & PrjID


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "Piping_Delayed") Then
      PPSheading.Text = "PIPING : TOTAL Delayed DWGS/DOCS LIST FROM PMDL FOR PROJECT - " & PrjID


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "Electrical_Delayed") Then
      PPSheading.Text = "ELECTRICAL : TOTAL Delayed DWGS/DOCS LIST FROM PMDL FOR PROJECT - " & PrjID


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "CI_Delayed") Then
      PPSheading.Text = "MECHANICAL : TOTAL Delayed DWGS/DOCS LIST FROM PMDL FOR PROJECT - " & PrjID


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "Total_Delayed") Then
      PPSheading.Text = "All DIVISION : TOTAL Delayed DWGS/DOCS LIST FROM PMDL FOR PROJECT - " & PrjID


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "Process_Due") Then
      PPSheading.Text = "PROCESS : TOTAL DUE ON TODAY FOR RELEASE DWGS/DOCS LIST FROM PMDL FOR PROJECT - " & PrjID


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "Mechanical_Due") Then
      PPSheading.Text = "MECHANICAL : TOTAL DUE ON TODAY FOR RELEASE DWGS/DOCS LIST FROM PMDL FOR PROJECT - " & PrjID


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "Structure_Due") Then
      PPSheading.Text = "STRUCTURE : TOTAL DUE ON TODAY FOR RELEASE DWGS/DOCS LIST FROM PMDL FOR PROJECT - " & PrjID


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "Piping_Due") Then
      PPSheading.Text = "PIPING : TOTAL DUE ON TODAY FOR RELEASE DWGS/DOCS LIST FROM PMDL FOR PROJECT - " & PrjID


      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "Electrical_Due") Then
      PPSheading.Text = "ELECTRICAL : TOTAL DUE ON TODAY FOR RELEASE DWGS/DOCS LIST FROM PMDL FOR PROJECT - " & PrjID
      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "CI_Due") Then
      PPSheading.Text = "MECHANICAL : TOTAL DUE ON TODAY FOR RELEASE DWGS/DOCS LIST FROM PMDL FOR PROJECT - " & PrjID
      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "Total_Due") Then
      PPSheading.Text = "All DIVISION : TOTAL DUE ON TODAY FOR RELEASE DWGS/DOCS LIST FROM PMDL FOR PROJECT - " & PrjID
      ShowPPLMData(Det, PrjID)
    End If

    If (Det = "Process_DCR_Total_Count") Then
      PPSheading.Text = "PROCESS : TOTAL DCR COUNT FOR -" & PrjID
      ShowDCRData(Det, PrjID)
    End If

    If (Det = "Mechanical_DCR_Total_Count") Then
      PPSheading.Text = "MECHANICAL : TOTAL DCR COUNT FOR -" & PrjID
      ShowDCRData(Det, PrjID)
    End If
    If (Det = "Piping_DCR_Total_Count") Then
      PPSheading.Text = "PIPING : TOTAL DCR COUNT FOR -" & PrjID
      ShowDCRData(Det, PrjID)
    End If
    If (Det = "Structure_DCR_Total_Count") Then
      PPSheading.Text = "STRUCTURE : TOTAL DCR COUNT FOR -" & PrjID
      ShowDCRData(Det, PrjID)
    End If
    If (Det = "Electrical_DCR_Total_Count") Then
      PPSheading.Text = "ELECTRICAL : TOTAL DCR COUNT FOR -" & PrjID
      ShowDCRData(Det, PrjID)
    End If
    If (Det = "CI_DCR_Total_Count") Then
      PPSheading.Text = "C & I : TOTAL DCR COUNT FOR -" & PrjID
      ShowDCRData(Det, PrjID)
    End If
    If (Det = "Others_DCR_Total_Count") Then
      PPSheading.Text = "OTHERS : TOTAL DCR COUNT FOR -" & PrjID
      ShowDCRData(Det, PrjID)
    End If

    If (Det = "Total_DCR_Total_Count") Then
      PPSheading.Text = "TOTAL : TOTAL DCR COUNT FOR -" & PrjID
      ShowDCRData(Det, PrjID)
    End If





    If (Det = "Process_DCR_Under_Creation") Then
      PPSheading.Text = "PROCESS : DCR - UNDER CREATION FOR PROJECT -" & PrjID
      ShowDCRData(Det, PrjID)
    End If

    If (Det = "Mechanical_DCR_Under_Creation") Then
      PPSheading.Text = "MECHANICAL : DCR - UNDER CREATION FOR PROJECT -" & PrjID
      ShowDCRData(Det, PrjID)
    End If
    If (Det = "Piping_DCR_Under_Creation") Then
      PPSheading.Text = "PIPING : DCR - UNDER CREATION FOR PROJECT -" & PrjID
      ShowDCRData(Det, PrjID)
    End If
    If (Det = "Structure_DCR_Under_Creation") Then
      PPSheading.Text = "STRUCTURE : DCR - UNDER CREATION " & PrjID
      ShowDCRData(Det, PrjID)
    End If
    If (Det = "Electrical_DCR_Under_Creation") Then
      PPSheading.Text = "ELECTRICAL : DCR - UNDER CREATION FOR PROJECT -" & PrjID
      ShowDCRData(Det, PrjID)
    End If
    If (Det = "CI_DCR_Under_Creation") Then
      PPSheading.Text = "C & I : DCR - UNDER CREATION FOR PROJECT -" & PrjID
      ShowDCRData(Det, PrjID)
    End If
    If (Det = "Others_DCR_Under_Creation") Then
      PPSheading.Text = "OTHERS : DCR - UNDER CREATION FOR PROJECT -" & PrjID
      ShowDCRData(Det, PrjID)
    End If

    If (Det = "Total_DCR_Under_Creation") Then
      PPSheading.Text = "TOTAL : DCR - UNDER CREATION FOR PROJECT -" & PrjID
      ShowDCRData(Det, PrjID)
    End If


    If (Det = "Process_DCR_Under_Approval") Then
      PPSheading.Text = "PROCESS : DCR - UNDER APPROVAL FOR PROJECT -" & PrjID
      ShowDCRData(Det, PrjID)
    End If


    If (Det = "Mechanical_DCR_Under_Approval") Then
      PPSheading.Text = "MECHANICAL : DCR - UNDER APPROVAL FOR PROJECT -" & PrjID
      ShowDCRData(Det, PrjID)
    End If
    If (Det = "Piping_DCR_Under_Approval") Then
      PPSheading.Text = "PIPING : DCR - UNDER APPROVAL FOR PROJECT -" & PrjID
      ShowDCRData(Det, PrjID)
    End If
    If (Det = "Structure_DCR_Under_Approval") Then
      PPSheading.Text = "STRUCTURE : DCR - UNDER APPROVAL FOR PROJECT -" & PrjID
      ShowDCRData(Det, PrjID)
    End If
    If (Det = "Electrical_DCR_Under_Approval") Then
      PPSheading.Text = "ELECTRICAL : DCR - UNDER APPROVAL FOR PROJECT -" & PrjID
      ShowDCRData(Det, PrjID)
    End If
    If (Det = "CI_DCR_Under_Approval") Then
      PPSheading.Text = "C & I : DCR - UNDER APPROVAL FOR PROJECT -" & PrjID
      ShowDCRData(Det, PrjID)
    End If
    If (Det = "Others_DCR_Under_Approval") Then
      PPSheading.Text = "OTHERS : DCR - UNDER APPROVAL FOR PROJECT -" & PrjID
      ShowDCRData(Det, PrjID)
    End If

    If (Det = "Total_DCR_Under_Approval") Then
      PPSheading.Text = "TOTAL : DCR - UNDER APPROVAL FOR PROJECT -" & PrjID
      ShowDCRData(Det, PrjID)
    End If

    If (Det = "Process_DCR_Approved") Then
      PPSheading.Text = "PROCESS : DCR - APPROVED FOR PROJECT -" & PrjID
      ShowDCRData(Det, PrjID)
    End If

    If (Det = "Mechanical_DCR_Approved") Then
      PPSheading.Text = "MECHANICAL : DCR - APPROVED FOR PROJECT -" & PrjID
      ShowDCRData(Det, PrjID)
    End If
    If (Det = "Piping_DCR_Approved") Then
      PPSheading.Text = "PIPING : DCR - APPROVED FOR PROJECT -" & PrjID
      ShowDCRData(Det, PrjID)
    End If
    If (Det = "Structure_DCR_Approved") Then
      PPSheading.Text = "STRUCTURE : DCR - APPROVED FOR PROJECT -" & PrjID
      ShowDCRData(Det, PrjID)
    End If
    If (Det = "Electrical_DCR_Approved") Then
      PPSheading.Text = "ELECTRICAL : DCR - APPROVED FOR PROJECT -" & PrjID
      ShowDCRData(Det, PrjID)
    End If
    If (Det = "CI_DCR_Approved") Then
      PPSheading.Text = "C & I : DCR - APPROVED FOR PROJECT -" & PrjID
      ShowDCRData(Det, PrjID)
    End If
    If (Det = "Others_DCR_Approved") Then
      PPSheading.Text = "OTHERS : DCR - APPROVED FOR PROJECT -" & PrjID
      ShowDCRData(Det, PrjID)
    End If

    If (Det = "Total_DCR_Approved") Then
      PPSheading.Text = "TOTAL : DCR - APPROVED FOR PROJECT -" & PrjID
      ShowDCRData(Det, PrjID)
    End If


    If (Det = "Process_Transmittal_Total_Count") Then
      PPSheading.Text = "PROCESS : TRANSMITTAL - TOTAL COUNT FOR PROJECT -" & PrjID
      ShowIDMSData(Det, PrjID)
    End If
    If (Det = "Process_Transmittal_Free") Then
      PPSheading.Text = "PROCESS : TRANSMITTAL -IN FREE STATE FOR PROJECT -" & PrjID
      ShowIDMSData(Det, PrjID)
    End If
    If (Det = "Process_Transmittal_Under_Approval") Then
      PPSheading.Text = "PROCESS : TRANSMITTAL - IN UNDER APPROVAL STATE FOR PROJECT -" & PrjID
      ShowIDMSData(Det, PrjID)
    End If
    If (Det = "Process_Transmittal_Under_Issue") Then
        PPSheading.Text = "PROCESS : TRANSMITTAL - IN UNDER ISSUE STATE FOR PROJECT -" & PrjID
      ShowIDMSData(Det, PrjID)
    End If
      If (Det = "Process_Transmittal_Issued") Then
        PPSheading.Text = "PROCESS : TRANSMITTAL - ISSUED FOR PROJECT -" & PrjID
      ShowIDMSData(Det, PrjID)
    End If
      If (Det = "Process_Transmittal_Partial_Received") Then
        PPSheading.Text = "PROCESS : TRANSMITTAL - IN PARTIAL RECEIVED STATE FOR PROJECT -" & PrjID
      ShowIDMSData(Det, PrjID)
    End If
      If (Det = "Process_Transmittal_Received") Then
        PPSheading.Text = "PROCESS : TRANSMITTAL - IN RECEIVED STATE FOR PROJECT -" & PrjID
      ShowIDMSData(Det, PrjID)
    End If
      If (Det = "Process_Transmittal_Closed") Then
        PPSheading.Text = "PROCESS : TRANSMITTAL - IN CLOSED STATE FOR PROJECT -" & PrjID
      ShowIDMSData(Det, PrjID)
    End If
      If (Det = "Process_Transmittal_Returned") Then
        PPSheading.Text = "PROCESS : TRANSMITTAL - RETURNED FOR PROJECT -" & PrjID
      ShowIDMSData(Det, PrjID)
    End If


    If (Det = "Mechanical_Transmittal_Total_Count") Then
      PPSheading.Text = "MECHANICAL : TRANSMITTAL - TOTAL COUNT FOR PROJECT -" & PrjID
      ShowIDMSData(Det, PrjID)
    End If
    If (Det = "Mechanical_Transmittal_Free") Then
      PPSheading.Text = "MECHANICAL : TRANSMITTAL -IN FREE STATE FOR PROJECT -" & PrjID
      ShowIDMSData(Det, PrjID)
    End If
    If (Det = "Mechanical_Transmittal_Under_Approval") Then
      PPSheading.Text = "MECHANICAL : TRANSMITTAL - IN UNDER APPROVAL STATE FOR PROJECT -" & PrjID
      ShowIDMSData(Det, PrjID)
    End If
    If (Det = "Mechanical_Transmittal_Under_Issue") Then
      PPSheading.Text = "MECHANICAL : TRANSMITTAL - IN UNDER ISSUE STATE FOR PROJECT -" & PrjID
      ShowIDMSData(Det, PrjID)
    End If
    If (Det = "Mechanical_Transmittal_Issued") Then
      PPSheading.Text = "MECHANICAL : TRANSMITTAL - ISSUED FOR PROJECT -" & PrjID
      ShowIDMSData(Det, PrjID)
    End If
    If (Det = "Mechanical_Transmittal_Partial_Received") Then
      PPSheading.Text = "MECHANICAL : TRANSMITTAL - IN PARTIAL RECEIVED STATE FOR PROJECT -" & PrjID
      ShowIDMSData(Det, PrjID)
    End If
    If (Det = "Mechanical_Transmittal_Received") Then
      PPSheading.Text = "MECHANICAL : TRANSMITTAL - IN RECEIVED STATE FOR PROJECT -" & PrjID
      ShowIDMSData(Det, PrjID)
    End If
    If (Det = "Mechanical_Transmittal_Closed") Then
      PPSheading.Text = "MECHANICAL : TRANSMITTAL - IN CLOSED STATE FOR PROJECT -" & PrjID
      ShowIDMSData(Det, PrjID)
    End If
    If (Det = "Mechanical_Transmittal_Returned") Then
      PPSheading.Text = "MECHANICAL : TRANSMITTAL - RETURNED FOR PROJECT -" & PrjID
      ShowIDMSData(Det, PrjID)
    End If

    If (Det = "Structure_Transmittal_Total_Count") Then
      PPSheading.Text = "STRUCTURE : TRANSMITTAL - TOTAL COUNT FOR PROJECT -" & PrjID
      ShowIDMSData(Det, PrjID)
    End If
    If (Det = "Structure_Transmittal_Free") Then
      PPSheading.Text = "STRUCTURE : TRANSMITTAL -IN FREE STATE FOR PROJECT -" & PrjID
      ShowIDMSData(Det, PrjID)
    End If
    If (Det = "Structure_Transmittal_Under_Approval") Then
      PPSheading.Text = "STRUCTURE : TRANSMITTAL - IN UNDER APPROVAL STATE FOR PROJECT -" & PrjID
      ShowIDMSData(Det, PrjID)
    End If
    If (Det = "Structure_Transmittal_Under_Issue") Then
      PPSheading.Text = "STRUCTURE : TRANSMITTAL - IN UNDER ISSUE STATE FOR PROJECT -" & PrjID
      ShowIDMSData(Det, PrjID)
    End If
    If (Det = "Structure_Transmittal_Issued") Then
      PPSheading.Text = "STRUCTURE : TRANSMITTAL - ISSUED FOR PROJECT -" & PrjID
      ShowIDMSData(Det, PrjID)
    End If
    If (Det = "Structure_Transmittal_Partial_Received") Then
      PPSheading.Text = "STRUCTURE : TRANSMITTAL - IN PARTIAL RECEIVED STATE FOR PROJECT -" & PrjID
      ShowIDMSData(Det, PrjID)
    End If
    If (Det = "Structure_Transmittal_Received") Then
      PPSheading.Text = "STRUCTURE : TRANSMITTAL - IN RECEIVED STATE FOR PROJECT -" & PrjID
      ShowIDMSData(Det, PrjID)
    End If
    If (Det = "Structure_Transmittal_Closed") Then
      PPSheading.Text = "STRUCTURE : TRANSMITTAL - IN CLOSED STATE FOR PROJECT -" & PrjID
      ShowIDMSData(Det, PrjID)
    End If
    If (Det = "Structure_Transmittal_Returned") Then
      PPSheading.Text = "STRUCTURE : TRANSMITTAL - RETURNED FOR PROJECT -" & PrjID
      ShowIDMSData(Det, PrjID)
    End If

    If (Det = "Piping_Transmittal_Total_Count") Then
      PPSheading.Text = "PIPING : TRANSMITTAL - TOTAL COUNT FOR PROJECT -" & PrjID
      ShowIDMSData(Det, PrjID)
    End If
    If (Det = "Piping_Transmittal_Free") Then
      PPSheading.Text = "PIPING : TRANSMITTAL -IN FREE STATE FOR PROJECT -" & PrjID
      ShowIDMSData(Det, PrjID)
    End If
    If (Det = "Piping_Transmittal_Under_Approval") Then
      PPSheading.Text = "PIPING : TRANSMITTAL - IN UNDER APPROVAL STATE FOR PROJECT -" & PrjID
      ShowIDMSData(Det, PrjID)
    End If
    If (Det = "Piping_Transmittal_Under_Issue") Then
      PPSheading.Text = "PIPING : TRANSMITTAL - IN UNDER ISSUE STATE FOR PROJECT -" & PrjID
      ShowIDMSData(Det, PrjID)
    End If
    If (Det = "Piping_Transmittal_Issued") Then
      PPSheading.Text = "PIPING : TRANSMITTAL - ISSUED FOR PROJECT -" & PrjID
      ShowIDMSData(Det, PrjID)
    End If
    If (Det = "Piping_Transmittal_Partial_Received") Then
      PPSheading.Text = "PIPING : TRANSMITTAL - IN PARTIAL RECEIVED STATE FOR PROJECT -" & PrjID
      ShowIDMSData(Det, PrjID)
    End If
    If (Det = "Piping_Transmittal_Received") Then
      PPSheading.Text = "PIPING : TRANSMITTAL - IN RECEIVED STATE FOR PROJECT -" & PrjID
      ShowIDMSData(Det, PrjID)
    End If
    If (Det = "Piping_Transmittal_Closed") Then
      PPSheading.Text = "PIPING : TRANSMITTAL - IN CLOSED STATE FOR PROJECT -" & PrjID
      ShowIDMSData(Det, PrjID)
    End If
    If (Det = "Piping_Transmittal_Returned") Then
      PPSheading.Text = "PIPING : TRANSMITTAL - RETURNED FOR PROJECT -" & PrjID
      ShowIDMSData(Det, PrjID)
    End If

    If (Det = "Others_Transmittal_Total_Count") Then
      PPSheading.Text = "OTHERS : TRANSMITTAL - TOTAL COUNT FOR PROJECT -" & PrjID
      ShowIDMSData(Det, PrjID)
    End If
    If (Det = "Others_Transmittal_Free") Then
      PPSheading.Text = "OTHERS : TRANSMITTAL -IN FREE STATE FOR PROJECT -" & PrjID
      ShowIDMSData(Det, PrjID)
    End If
    If (Det = "Others_Transmittal_Under_Approval") Then
      PPSheading.Text = "OTHERS : TRANSMITTAL - IN UNDER APPROVAL STATE FOR PROJECT -" & PrjID
      ShowIDMSData(Det, PrjID)
    End If
    If (Det = "Others_Transmittal_Under_Issue") Then
      PPSheading.Text = "OTHERS : TRANSMITTAL - IN UNDER ISSUE STATE FOR PROJECT -" & PrjID
      ShowIDMSData(Det, PrjID)
    End If
    If (Det = "Others_Transmittal_Issued") Then
      PPSheading.Text = "OTHERS : TRANSMITTAL - ISSUED FOR PROJECT -" & PrjID
      ShowIDMSData(Det, PrjID)
    End If
    If (Det = "Others_Transmittal_Partial_Received") Then
      PPSheading.Text = "OTHERS : TRANSMITTAL - IN PARTIAL RECEIVED STATE FOR PROJECT -" & PrjID
      ShowIDMSData(Det, PrjID)
    End If
    If (Det = "Others_Transmittal_Received") Then
      PPSheading.Text = "OTHERS : TRANSMITTAL - IN RECEIVED STATE FOR PROJECT -" & PrjID
      ShowIDMSData(Det, PrjID)
    End If
    If (Det = "Others_Transmittal_Closed") Then
      PPSheading.Text = "OTHERS : TRANSMITTAL - IN CLOSED STATE FOR PROJECT -" & PrjID
      ShowIDMSData(Det, PrjID)
    End If
    If (Det = "Others_Transmittal_Returned") Then
      PPSheading.Text = "OTHERS : TRANSMITTAL - RETURNED FOR PROJECT -" & PrjID
      ShowIDMSData(Det, PrjID)
    End If

    If (Det = "Total_Transmittal_Total_Count") Then
      PPSheading.Text = "TOTAL : TRANSMITTAL - TOTAL COUNT FOR PROJECT -" & PrjID
      ShowIDMSData(Det, PrjID)
    End If
    If (Det = "Total_Transmittal_Free") Then
      PPSheading.Text = "TOTAL : TRANSMITTAL -IN FREE STATE FOR PROJECT -" & PrjID
      ShowIDMSData(Det, PrjID)
    End If
    If (Det = "Total_Transmittal_Under_Approval") Then
      PPSheading.Text = "TOTAL : TRANSMITTAL - IN UNDER APPROVAL STATE FOR PROJECT -" & PrjID
      ShowIDMSData(Det, PrjID)
    End If
    If (Det = "Total_Transmittal_Under_Issue") Then
      PPSheading.Text = "TOTAL : TRANSMITTAL - IN UNDER ISSUE STATE FOR PROJECT -" & PrjID
      ShowIDMSData(Det, PrjID)
    End If
    If (Det = "Total_Transmittal_Issued") Then
      PPSheading.Text = "TOTAL : TRANSMITTAL - ISSUED FOR PROJECT -" & PrjID
      ShowIDMSData(Det, PrjID)
    End If
    If (Det = "Total_Transmittal_Partial_Received") Then
      PPSheading.Text = "TOTAL : TRANSMITTAL - IN PARTIAL RECEIVED STATE FOR PROJECT -" & PrjID
      ShowIDMSData(Det, PrjID)
    End If
    If (Det = "Total_Transmittal_Received") Then
      PPSheading.Text = "TOTAL : TRANSMITTAL - IN RECEIVED STATE FOR PROJECT -" & PrjID
      ShowIDMSData(Det, PrjID)
    End If
    If (Det = "Total_Transmittal_Closed") Then
      PPSheading.Text = "TOTAL : TRANSMITTAL - IN CLOSED STATE FOR PROJECT -" & PrjID
      ShowIDMSData(Det, PrjID)
    End If
    If (Det = "Total_Transmittal_Returned") Then
      PPSheading.Text = "TOTAL : TRANSMITTAL - RETURNED FOR PROJECT -" & PrjID
      ShowIDMSData(Det, PrjID)
    End If

    If (Det = "CI_Transmittal_Total_Count") Then
      PPSheading.Text = "CI : TRANSMITTAL - TOTAL COUNT FOR PROJECT -" & PrjID
      ShowIDMSData(Det, PrjID)
    End If
    If (Det = "CI_Transmittal_Free") Then
      PPSheading.Text = "CI : TRANSMITTAL -IN FREE STATE FOR PROJECT -" & PrjID
      ShowIDMSData(Det, PrjID)
    End If
    If (Det = "CI_Transmittal_Under_Approval") Then
      PPSheading.Text = "CI : TRANSMITTAL - IN UNDER APPROVAL STATE FOR PROJECT -" & PrjID
      ShowIDMSData(Det, PrjID)
    End If
    If (Det = "CI_Transmittal_Under_Issue") Then
      PPSheading.Text = "CI : TRANSMITTAL - IN UNDER ISSUE STATE FOR PROJECT -" & PrjID
      ShowIDMSData(Det, PrjID)
    End If
    If (Det = "CI_Transmittal_Issued") Then
      PPSheading.Text = "CI : TRANSMITTAL - ISSUED FOR PROJECT -" & PrjID
      ShowIDMSData(Det, PrjID)
    End If
    If (Det = "CI_Transmittal_Partial_Received") Then
      PPSheading.Text = "CI : TRANSMITTAL - IN PARTIAL RECEIVED STATE FOR PROJECT -" & PrjID
      ShowIDMSData(Det, PrjID)
    End If
    If (Det = "CI_Transmittal_Received") Then
      PPSheading.Text = "CI : TRANSMITTAL - IN RECEIVED STATE FOR PROJECT -" & PrjID
      ShowIDMSData(Det, PrjID)
    End If
    If (Det = "CI_Transmittal_Closed") Then
      PPSheading.Text = "CI : TRANSMITTAL - IN CLOSED STATE FOR PROJECT -" & PrjID
      ShowIDMSData(Det, PrjID)
    End If
    If (Det = "CI_Transmittal_Returned") Then
      PPSheading.Text = "CI : TRANSMITTAL - RETURNED FOR PROJECT -" & PrjID
      ShowIDMSData(Det, PrjID)
    End If

    If (Det = "Process_SAR_Total_Count") Then
      PPSheading.Text = "Process : SAR - Total Count For PROJECT -" & PrjID
      ShowSARData(Det, PrjID)
    End If

    If (Det = "Process_SAR_Under_Creation") Then
      PPSheading.Text = "Process : SAR  - In Under Creation State For PROJECT -" & PrjID
      ShowSARData(Det, PrjID)
    End If


    If (Det = "Process_SAR_Under_Review") Then
      PPSheading.Text = "Process : SAR  - In Under Review State For PROJECT -" & PrjID
      ShowSARData(Det, PrjID)
    End If


    If (Det = "Process_SAR_Under_Approval") Then
      PPSheading.Text = "Process : SAR  - In Under Approval State For PROJECT -" & PrjID
      ShowSARData(Det, PrjID)
    End If

    If (Det = "Process_SAR_Approved") Then
      PPSheading.Text = "Process : SAR  - In Approved State For PROJECT -" & PrjID
      ShowSARData(Det, PrjID)
    End If
    If (Det = "Process_SAR_Not_Applicable") Then
      PPSheading.Text = "Process : SAR NOT Applicable For PROJECT -" & PrjID
      ShowSARData(Det, PrjID)
    End If

    If (Det = "Mechanical_SAR_Total_Count") Then
      PPSheading.Text = "Mechanical : SAR - Total Count For PROJECT -" & PrjID
      ShowSARData(Det, PrjID)
    End If

    If (Det = "Mechanical_SAR_Under_Creation") Then
      PPSheading.Text = "Mechanical : SAR  - In Under Creation State For PROJECT -" & PrjID
      ShowSARData(Det, PrjID)
    End If


    If (Det = "Mechanical_SAR_Under_Review") Then
      PPSheading.Text = "Mechanical : SAR  - In Under Review State For PROJECT -" & PrjID
      ShowSARData(Det, PrjID)
    End If


    If (Det = "Mechanical_SAR_Under_Approval") Then
      PPSheading.Text = "Mechanical : SAR  - In Under Approval State For PROJECT -" & PrjID
      ShowSARData(Det, PrjID)
    End If

    If (Det = "Mechanical_SAR_Approved") Then
      PPSheading.Text = "Mechanical : SAR  - In Approved State For PROJECT -" & PrjID
      ShowSARData(Det, PrjID)
    End If
    If (Det = "Mechanical_SAR_Not_Applicable") Then
      PPSheading.Text = "Mechanical : SAR NOT Applicable For PROJECT -" & PrjID
      ShowSARData(Det, PrjID)
    End If

    If (Det = "Structure_SAR_Total_Count") Then
      PPSheading.Text = "Structure : SAR - Total Count For PROJECT -" & PrjID
      ShowSARData(Det, PrjID)
    End If

    If (Det = "Structure_SAR_Under_Creation") Then
      PPSheading.Text = "Structure : SAR  - In Under Creation State For PROJECT -" & PrjID
      ShowSARData(Det, PrjID)
    End If


    If (Det = "Structure_SAR_Under_Review") Then
      PPSheading.Text = "Structure : SAR  - In Under Review State For PROJECT -" & PrjID
      ShowSARData(Det, PrjID)
    End If


    If (Det = "Structure_SAR_Under_Approval") Then
      PPSheading.Text = "Structure : SAR  - In Under Approval State For PROJECT -" & PrjID
      ShowSARData(Det, PrjID)
    End If

    If (Det = "Structure_SAR_Approved") Then
      PPSheading.Text = "Structure : SAR  - In Approved State For PROJECT -" & PrjID
      ShowSARData(Det, PrjID)
    End If
    If (Det = "Structure_SAR_Not_Applicable") Then
      PPSheading.Text = "Structure : SAR NOT Applicable For PROJECT -" & PrjID
      ShowSARData(Det, PrjID)
    End If

    If (Det = "Electrical_SAR_Total_Count") Then
      PPSheading.Text = "Electrical : SAR - Total Count For PROJECT -" & PrjID
      ShowSARData(Det, PrjID)
    End If

    If (Det = "Electrical_SAR_Under_Creation") Then
      PPSheading.Text = "Electrical : SAR  - In Under Creation State For PROJECT -" & PrjID
      ShowSARData(Det, PrjID)
    End If


    If (Det = "Electrical_SAR_Under_Review") Then
      PPSheading.Text = "Electrical : SAR  - In Under Review State For PROJECT -" & PrjID
      ShowSARData(Det, PrjID)
    End If


    If (Det = "Electrical_SAR_Under_Approval") Then
      PPSheading.Text = "Electrical : SAR  - In Under Approval State For PROJECT -" & PrjID
      ShowSARData(Det, PrjID)
    End If

    If (Det = "Electrical_SAR_Approved") Then
      PPSheading.Text = "Electrical : SAR  - In Approved State For PROJECT -" & PrjID
      ShowSARData(Det, PrjID)
    End If
    If (Det = "Electrical_SAR_Not_Applicable") Then
      PPSheading.Text = "Electrical : SAR NOT Applicable For PROJECT -" & PrjID
      ShowSARData(Det, PrjID)
    End If

    If (Det = "Piping_SAR_Total_Count") Then
      PPSheading.Text = "Piping : SAR - Total Count For PROJECT -" & PrjID
      ShowSARData(Det, PrjID)
    End If

    If (Det = "Piping_SAR_Under_Creation") Then
      PPSheading.Text = "Piping : SAR  - In Under Creation State For PROJECT -" & PrjID
      ShowSARData(Det, PrjID)
    End If


    If (Det = "Piping_SAR_Under_Review") Then
      PPSheading.Text = "Piping : SAR  - In Under Review State For PROJECT -" & PrjID
      ShowSARData(Det, PrjID)
    End If


    If (Det = "Piping_SAR_Under_Approval") Then
      PPSheading.Text = "Piping : SAR  - In Under Approval State For PROJECT -" & PrjID
      ShowSARData(Det, PrjID)
    End If

    If (Det = "Piping_SAR_Approved") Then
      PPSheading.Text = "Piping : SAR  - In Approved State For PROJECT -" & PrjID
      ShowSARData(Det, PrjID)
    End If
    If (Det = "Piping_SAR_Not_Applicable") Then
      PPSheading.Text = "Piping : SAR NOT Applicable For PROJECT -" & PrjID
      ShowSARData(Det, PrjID)
    End If

    If (Det = "CI_SAR_Total_Count") Then
      PPSheading.Text = "CI : SAR - Total Count For PROJECT -" & PrjID
      ShowSARData(Det, PrjID)
    End If

    If (Det = "CI_SAR_Under_Creation") Then
      PPSheading.Text = "CI : SAR  - In Under Creation State For PROJECT -" & PrjID
      ShowSARData(Det, PrjID)
    End If


    If (Det = "CI_SAR_Under_Review") Then
      PPSheading.Text = "CI : SAR  - In Under Review State For PROJECT -" & PrjID
      ShowSARData(Det, PrjID)
    End If


    If (Det = "CI_SAR_Under_Approval") Then
      PPSheading.Text = "CI : SAR  - In Under Approval State For PROJECT -" & PrjID
      ShowSARData(Det, PrjID)
    End If

    If (Det = "CI_SAR_Approved") Then
      PPSheading.Text = "CI : SAR  - In Approved State For PROJECT -" & PrjID
      ShowSARData(Det, PrjID)
    End If
    If (Det = "CI_SAR_Not_Applicable") Then
      PPSheading.Text = "CI : SAR NOT Applicable For PROJECT -" & PrjID
      ShowSARData(Det, PrjID)
    End If

    If (Det = "Others_SAR_Total_Count") Then
      PPSheading.Text = "Others : SAR - Total Count For PROJECT -" & PrjID
      ShowSARData(Det, PrjID)
    End If

    If (Det = "Others_SAR_Under_Creation") Then
      PPSheading.Text = "Others : SAR  - In Under Creation State For PROJECT -" & PrjID
      ShowSARData(Det, PrjID)
    End If


    If (Det = "Others_SAR_Under_Review") Then
      PPSheading.Text = "Others : SAR  - In Under Review State For PROJECT -" & PrjID
      ShowSARData(Det, PrjID)
    End If


    If (Det = "Others_SAR_Under_Approval") Then
      PPSheading.Text = "Others : SAR  - In Under Approval State For PROJECT -" & PrjID
      ShowSARData(Det, PrjID)
    End If

    If (Det = "Others_SAR_Approved") Then
      PPSheading.Text = "Others : SAR  - In Approved State For PROJECT -" & PrjID
      ShowSARData(Det, PrjID)
    End If
    If (Det = "Others_SAR_Not_Applicable") Then
      PPSheading.Text = "Others : SAR NOT Applicable For PROJECT -" & PrjID
      ShowSARData(Det, PrjID)
    End If

    If (Det = "Total_SAR_Total_Count") Then
      PPSheading.Text = "Total : SAR - Total Count For PROJECT -" & PrjID
      ShowSARData(Det, PrjID)
    End If

    If (Det = "Total_SAR_Under_Creation") Then
      PPSheading.Text = "Total : SAR  - In Under Creation State For PROJECT -" & PrjID
      ShowSARData(Det, PrjID)
    End If


    If (Det = "Total_SAR_Under_Review") Then
      PPSheading.Text = "Total : SAR  - In Under Review State For PROJECT -" & PrjID
      ShowSARData(Det, PrjID)
    End If


    If (Det = "Total_SAR_Under_Approval") Then
      PPSheading.Text = "Total : SAR  - In Under Approval State For PROJECT -" & PrjID
      ShowSARData(Det, PrjID)
    End If

    If (Det = "Total_SAR_Approved") Then
      PPSheading.Text = "Total : SAR  - In Approved State For PROJECT -" & PrjID
      ShowSARData(Det, PrjID)
    End If
    If (Det = "Total_SAR_Not_Applicable") Then
      PPSheading.Text = "Total : SAR NOT Applicable For PROJECT -" & PrjID
      ShowSARData(Det, PrjID)
    End If

    If (Det = "Process_IDMSP_Total_Count") Then
      PPSheading.Text = "Process : Pre Order Receipt Count For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Process_IDMSP_Submitted") Then
      PPSheading.Text = "Process : Pre Order Receipt - In Submitted State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Process_IDMSP_Document_linked") Then
      PPSheading.Text = "Process : Pre Order Receipt - In Document linked State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Process_IDMSP_Under_Evaluation") Then
      PPSheading.Text = "Process : Pre Order Receipt - In Under Evaluation State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Process_IDMSP_Comments_Submitted") Then
      PPSheading.Text = "Process : Pre Order Receipt - In Comments_Submitted State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Process_IDMSP_Technically_Cleared") Then
      PPSheading.Text = "Process : Pre Order Receipt - In Technically_Cleared State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Process_IDMSP_Transmittal_Issued") Then
      PPSheading.Text = "Process : Pre Order Receipt - In Transmittal_Issued State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Process_IDMSP_Superceded") Then
      PPSheading.Text = "Process : Pre Order Receipt - In Superceded State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Process_IDMSP_Closed") Then
      PPSheading.Text = "Process : Pre Order Receipt - In Closed State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Mechanical_IDMSP_Total_Count") Then
      PPSheading.Text = "Mechanical : Pre Order Receipt Count For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Mechanical_IDMSP_Submitted") Then
      PPSheading.Text = "Mechanical : Pre Order Receipt - In Submitted State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Mechanical_IDMSP_Document_linked") Then
      PPSheading.Text = "Mechanical : Pre Order Receipt - In Document linked State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Mechanical_IDMSP_Under_Evaluation") Then
      PPSheading.Text = "Mechanical : Pre Order Receipt - In Under Evaluation State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Mechanical_IDMSP_Comments_Submitted") Then
      PPSheading.Text = "Mechanical : Pre Order Receipt - In Comments_Submitted State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Mechanical_IDMSP_Technically_Cleared") Then
      PPSheading.Text = "Mechanical : Pre Order Receipt - In Technically_Cleared State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Mechanical_IDMSP_Transmittal_Issued") Then
      PPSheading.Text = "Mechanical : Pre Order Receipt - In Transmittal_Issued State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Mechanical_IDMSP_Superceded") Then
      PPSheading.Text = "Mechanical : Pre Order Receipt - In Superceded State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Mechanical_IDMSP_Closed") Then
      PPSheading.Text = "Mechanical : Pre Order Receipt - In Closed State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Electrical_IDMSP_Total_Count") Then
      PPSheading.Text = "Electrical : Pre Order Receipt Count For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Electrical_IDMSP_Submitted") Then
      PPSheading.Text = "Electrical : Pre Order Receipt - In Submitted State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Electrical_IDMSP_Document_linked") Then
      PPSheading.Text = "Electrical : Pre Order Receipt - In Document linked State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Electrical_IDMSP_Under_Evaluation") Then
      PPSheading.Text = "Electrical : Pre Order Receipt - In Under Evaluation State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Electrical_IDMSP_Comments_Submitted") Then
      PPSheading.Text = "Electrical : Pre Order Receipt - In Comments_Submitted State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Electrical_IDMSP_Technically_Cleared") Then
      PPSheading.Text = "Electrical : Pre Order Receipt - In Technically_Cleared State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Electrical_IDMSP_Transmittal_Issued") Then
      PPSheading.Text = "Electrical : Pre Order Receipt - In Transmittal_Issued State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Electrical_IDMSP_Superceded") Then
      PPSheading.Text = "Electrical : Pre Order Receipt - In Superceded State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Electrical_IDMSP_Closed") Then
      PPSheading.Text = "Electrical : Pre Order Receipt - In Closed State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Structure_IDMSP_Total_Count") Then
      PPSheading.Text = "Structure : Pre Order Receipt Count For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Structure_IDMSP_Submitted") Then
      PPSheading.Text = "Structure : Pre Order Receipt - In Submitted State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Structure_IDMSP_Document_linked") Then
      PPSheading.Text = "Structure : Pre Order Receipt - In Document linked State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Structure_IDMSP_Under_Evaluation") Then
      PPSheading.Text = "Structure : Pre Order Receipt - In Under Evaluation State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Structure_IDMSP_Comments_Submitted") Then
      PPSheading.Text = "Structure : Pre Order Receipt - In Comments_Submitted State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Structure_IDMSP_Technically_Cleared") Then
      PPSheading.Text = "Structure : Pre Order Receipt - In Technically_Cleared State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Structure_IDMSP_Transmittal_Issued") Then
      PPSheading.Text = "Structure : Pre Order Receipt - In Transmittal_Issued State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Structure_IDMSP_Superceded") Then
      PPSheading.Text = "Structure : Pre Order Receipt - In Superceded State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Structure_IDMSP_Closed") Then
      PPSheading.Text = "Structure : Pre Order Receipt - In Closed State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Piping_IDMSP_Total_Count") Then
      PPSheading.Text = "Piping : Pre Order Receipt Count For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Piping_IDMSP_Submitted") Then
      PPSheading.Text = "Piping : Pre Order Receipt - In Submitted State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Piping_IDMSP_Document_linked") Then
      PPSheading.Text = "Piping : Pre Order Receipt - In Document linked State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Piping_IDMSP_Under_Evaluation") Then
      PPSheading.Text = "Piping : Pre Order Receipt - In Under Evaluation State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Piping_IDMSP_Comments_Submitted") Then
      PPSheading.Text = "Piping : Pre Order Receipt - In Comments_Submitted State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Piping_IDMSP_Technically_Cleared") Then
      PPSheading.Text = "Piping : Pre Order Receipt - In Technically_Cleared State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Piping_IDMSP_Transmittal_Issued") Then
      PPSheading.Text = "Piping : Pre Order Receipt - In Transmittal_Issued State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Piping_IDMSP_Superceded") Then
      PPSheading.Text = "Piping : Pre Order Receipt - In Superceded State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Piping_IDMSP_Closed") Then
      PPSheading.Text = "Piping : Pre Order Receipt - In Closed State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "CI_IDMSP_Total_Count") Then
      PPSheading.Text = "CI : Pre Order Receipt Count For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "CI_IDMSP_Submitted") Then
      PPSheading.Text = "CI : Pre Order Receipt - In Submitted State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "CI_IDMSP_Document_linked") Then
      PPSheading.Text = "CI : Pre Order Receipt - In Document linked State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "CI_IDMSP_Under_Evaluation") Then
      PPSheading.Text = "CI : Pre Order Receipt - In Under Evaluation State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "CI_IDMSP_Comments_Submitted") Then
      PPSheading.Text = "CI : Pre Order Receipt - In Comments_Submitted State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "CI_IDMSP_Technically_Cleared") Then
      PPSheading.Text = "CI : Pre Order Receipt - In Technically_Cleared State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "CI_IDMSP_Transmittal_Issued") Then
      PPSheading.Text = "CI : Pre Order Receipt - In Transmittal_Issued State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "CI_IDMSP_Superceded") Then
      PPSheading.Text = "CI : Pre Order Receipt - In Superceded State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "CI_IDMSP_Closed") Then
      PPSheading.Text = "CI : Pre Order Receipt - In Closed State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Others_IDMSP_Total_Count") Then
      PPSheading.Text = "Others : Pre Order Receipt Count For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Others_IDMSP_Submitted") Then
      PPSheading.Text = "Others : Pre Order Receipt - In Submitted State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Others_IDMSP_Document_linked") Then
      PPSheading.Text = "Others : Pre Order Receipt - In Document linked State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Others_IDMSP_Under_Evaluation") Then
      PPSheading.Text = "Others : Pre Order Receipt - In Under Evaluation State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Others_IDMSP_Comments_Submitted") Then
      PPSheading.Text = "Others : Pre Order Receipt - In Comments_Submitted State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Others_IDMSP_Technically_Cleared") Then
      PPSheading.Text = "Others : Pre Order Receipt - In Technically_Cleared State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Others_IDMSP_Transmittal_Issued") Then
      PPSheading.Text = "Others : Pre Order Receipt - In Transmittal_Issued State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Others_IDMSP_Superceded") Then
      PPSheading.Text = "Others : Pre Order Receipt - In Superceded State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Others_IDMSP_Closed") Then
      PPSheading.Text = "Others : Pre Order Receipt - In Closed State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Total_IDMSP_Total_Count") Then
      PPSheading.Text = "Total : Pre Order Receipt Count For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Total_IDMSP_Submitted") Then
      PPSheading.Text = "Total : Pre Order Receipt - In Submitted State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Total_IDMSP_Document_linked") Then
      PPSheading.Text = "Total : Pre Order Receipt - In Document linked State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Total_IDMSP_Under_Evaluation") Then
      PPSheading.Text = "Total : Pre Order Receipt - In Under Evaluation State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Total_IDMSP_Comments_Submitted") Then
      PPSheading.Text = "Total : Pre Order Receipt - In Comments_Submitted State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Total_IDMSP_Technically_Cleared") Then
      PPSheading.Text = "Total : Pre Order Receipt - In Technically_Cleared State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Total_IDMSP_Transmittal_Issued") Then
      PPSheading.Text = "Total : Pre Order Receipt - In Transmittal_Issued State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Total_IDMSP_Superceded") Then
      PPSheading.Text = "Total : Pre Order Receipt - In Superceded State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Total_IDMSP_Closed") Then
      PPSheading.Text = "Total : Pre Order Receipt - In Closed State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Process_IDMSO_Total_Count") Then
      PPSheading.Text = "Process : Post Order Receipt Count For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Process_IDMSO_Submitted") Then
      PPSheading.Text = "Process : Post Order Receipt - In Submitted State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Process_IDMSO_Document_linked") Then
      PPSheading.Text = "Process : Post Order Receipt - In Document linked State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Process_IDMSO_Under_Evaluation") Then
      PPSheading.Text = "Process : Post Order Receipt - In Under Evaluation State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Process_IDMSO_Comments_Submitted") Then
      PPSheading.Text = "Process : Post Order Receipt - In Comments_Submitted State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Process_IDMSO_Technically_Cleared") Then
      PPSheading.Text = "Process : Post Order Receipt - In Technically_Cleared State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Process_IDMSO_Transmittal_Issued") Then
      PPSheading.Text = "Process : Post Order Receipt - In Transmittal_Issued State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Process_IDMSO_Superceded") Then
      PPSheading.Text = "Process : Post Order Receipt - In Superceded State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Process_IDMSO_Closed") Then
      PPSheading.Text = "Process : Post Order Receipt - In Closed State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Mechanical_IDMSO_Total_Count") Then
      PPSheading.Text = "Mechanical : Post Order Receipt Count For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Mechanical_IDMSO_Submitted") Then
      PPSheading.Text = "Mechanical : Post Order Receipt - In Submitted State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Mechanical_IDMSO_Document_linked") Then
      PPSheading.Text = "Mechanical : Post Order Receipt - In Document linked State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Mechanical_IDMSO_Under_Evaluation") Then
      PPSheading.Text = "Mechanical : Post Order Receipt - In Under Evaluation State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Mechanical_IDMSO_Comments_Submitted") Then
      PPSheading.Text = "Mechanical : Post Order Receipt - In Comments_Submitted State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Mechanical_IDMSO_Technically_Cleared") Then
      PPSheading.Text = "Mechanical : Post Order Receipt - In Technically_Cleared State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Mechanical_IDMSO_Transmittal_Issued") Then
      PPSheading.Text = "Mechanical : Post Order Receipt - In Transmittal_Issued State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Mechanical_IDMSO_Superceded") Then
      PPSheading.Text = "Mechanical : Post Order Receipt - In Superceded State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Mechanical_IDMSO_Closed") Then
      PPSheading.Text = "Mechanical : Post Order Receipt - In Closed State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Electrical_IDMSO_Total_Count") Then
      PPSheading.Text = "Electrical : Post Order Receipt Count For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Electrical_IDMSO_Submitted") Then
      PPSheading.Text = "Electrical : Post Order Receipt - In Submitted State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Electrical_IDMSO_Document_linked") Then
      PPSheading.Text = "Electrical : Post Order Receipt - In Document linked State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Electrical_IDMSO_Under_Evaluation") Then
      PPSheading.Text = "Electrical : Post Order Receipt - In Under Evaluation State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Electrical_IDMSO_Comments_Submitted") Then
      PPSheading.Text = "Electrical : Post Order Receipt - In Comments_Submitted State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Electrical_IDMSO_Technically_Cleared") Then
      PPSheading.Text = "Electrical : Post Order Receipt - In Technically_Cleared State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Electrical_IDMSO_Transmittal_Issued") Then
      PPSheading.Text = "Electrical : Post Order Receipt - In Transmittal_Issued State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Electrical_IDMSO_Superceded") Then
      PPSheading.Text = "Electrical : Post Order Receipt - In Superceded State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Electrical_IDMSO_Closed") Then
      PPSheading.Text = "Electrical : Post Order Receipt - In Closed State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Structure_IDMSO_Total_Count") Then
      PPSheading.Text = "Structure : Post Order Receipt Count For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Structure_IDMSO_Submitted") Then
      PPSheading.Text = "Structure : Post Order Receipt - In Submitted State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Structure_IDMSO_Document_linked") Then
      PPSheading.Text = "Structure : Post Order Receipt - In Document linked State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Structure_IDMSO_Under_Evaluation") Then
      PPSheading.Text = "Structure : Post Order Receipt - In Under Evaluation State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Structure_IDMSO_Comments_Submitted") Then
      PPSheading.Text = "Structure : Post Order Receipt - In Comments_Submitted State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Structure_IDMSO_Technically_Cleared") Then
      PPSheading.Text = "Structure : Post Order Receipt - In Technically_Cleared State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Structure_IDMSO_Transmittal_Issued") Then
      PPSheading.Text = "Structure : Post Order Receipt - In Transmittal_Issued State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Structure_IDMSO_Superceded") Then
      PPSheading.Text = "Structure : Post Order Receipt - In Superceded State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Structure_IDMSO_Closed") Then
      PPSheading.Text = "Structure : Post Order Receipt - In Closed State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Piping_IDMSO_Total_Count") Then
      PPSheading.Text = "Piping : Post Order Receipt Count For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Piping_IDMSO_Submitted") Then
      PPSheading.Text = "Piping : Post Order Receipt - In Submitted State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Piping_IDMSO_Document_linked") Then
      PPSheading.Text = "Piping : Post Order Receipt - In Document linked State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Piping_IDMSO_Under_Evaluation") Then
      PPSheading.Text = "Piping : Post Order Receipt - In Under Evaluation State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Piping_IDMSO_Comments_Submitted") Then
      PPSheading.Text = "Piping : Post Order Receipt - In Comments_Submitted State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Piping_IDMSO_Technically_Cleared") Then
      PPSheading.Text = "Piping : Post Order Receipt - In Technically_Cleared State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Piping_IDMSO_Transmittal_Issued") Then
      PPSheading.Text = "Piping : Post Order Receipt - In Transmittal_Issued State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Piping_IDMSO_Superceded") Then
      PPSheading.Text = "Piping : Post Order Receipt - In Superceded State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Piping_IDMSO_Closed") Then
      PPSheading.Text = "Piping : Post Order Receipt - In Closed State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "CI_IDMSO_Total_Count") Then
      PPSheading.Text = "CI : Post Order Receipt Count For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "CI_IDMSO_Submitted") Then
      PPSheading.Text = "CI : Post Order Receipt - In Submitted State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "CI_IDMSO_Document_linked") Then
      PPSheading.Text = "CI : Post Order Receipt - In Document linked State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "CI_IDMSO_Under_Evaluation") Then
      PPSheading.Text = "CI : Post Order Receipt - In Under Evaluation State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "CI_IDMSO_Comments_Submitted") Then
      PPSheading.Text = "CI : Post Order Receipt - In Comments_Submitted State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "CI_IDMSO_Technically_Cleared") Then
      PPSheading.Text = "CI : Post Order Receipt - In Technically_Cleared State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "CI_IDMSO_Transmittal_Issued") Then
      PPSheading.Text = "CI : Post Order Receipt - In Transmittal_Issued State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "CI_IDMSO_Superceded") Then
      PPSheading.Text = "CI : Post Order Receipt - In Superceded State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "CI_IDMSO_Closed") Then
      PPSheading.Text = "CI : Post Order Receipt - In Closed State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Others_IDMSO_Total_Count") Then
      PPSheading.Text = "Others : Post Order Receipt Count For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Others_IDMSO_Submitted") Then
      PPSheading.Text = "Others : Post Order Receipt - In Submitted State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Others_IDMSO_Document_linked") Then
      PPSheading.Text = "Others : Post Order Receipt - In Document linked State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Others_IDMSO_Under_Evaluation") Then
      PPSheading.Text = "Others : Post Order Receipt - In Under Evaluation State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Others_IDMSO_Comments_Submitted") Then
      PPSheading.Text = "Others : Post Order Receipt - In Comments_Submitted State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Others_IDMSO_Technically_Cleared") Then
      PPSheading.Text = "Others : Post Order Receipt - In Technically_Cleared State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Others_IDMSO_Transmittal_Issued") Then
      PPSheading.Text = "Others : Post Order Receipt - In Transmittal_Issued State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Others_IDMSO_Superceded") Then
      PPSheading.Text = "Others : Post Order Receipt - In Superceded State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Others_IDMSO_Closed") Then
      PPSheading.Text = "Others : Post Order Receipt - In Closed State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Total_IDMSO_Total_Count") Then
      PPSheading.Text = "Total : Post Order Receipt Count For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Total_IDMSO_Submitted") Then
      PPSheading.Text = "Total : Post Order Receipt - In Submitted State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Total_IDMSO_Document_linked") Then
      PPSheading.Text = "Total : Post Order Receipt - In Document linked State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Total_IDMSO_Under_Evaluation") Then
      PPSheading.Text = "Total : Post Order Receipt - In Under Evaluation State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Total_IDMSO_Comments_Submitted") Then
      PPSheading.Text = "Total : Post Order Receipt - In Comments_Submitted State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Total_IDMSO_Technically_Cleared") Then
      PPSheading.Text = "Total : Post Order Receipt - In Technically_Cleared State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Total_IDMSO_Transmittal_Issued") Then
      PPSheading.Text = "Total : Post Order Receipt - In Transmittal_Issued State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Total_IDMSO_Superceded") Then
      PPSheading.Text = "Total : Post Order Receipt - In Superceded State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Total_IDMSO_Closed") Then
      PPSheading.Text = "Total : Post Order Receipt - In Closed State For PROJECT -" & PrjID
      ShowPOData(Det, PrjID)
    End If

    If (Det = "Process_Element_Total_Active_Element_Count") Then
      PPSheading.Text = "Process : Total Active Elements In PROJECT -" & PrjID
      ShowelementData(Det, PrjID)
    End If

    If (Det = "Process_Element_Free") Then
      PPSheading.Text = "Process : Free Elements In PROJECT -" & PrjID
      ShowelementData(Det, PrjID)
    End If

    If (Det = "Process_Element_Partial") Then
      PPSheading.Text = "Process : Partial Elements In PROJECT -" & PrjID
      ShowelementData(Det, PrjID)
    End If

    If (Det = "Process_Element_Completed") Then
      PPSheading.Text = "Process : Completed Elements In PROJECT -" & PrjID
      ShowelementData(Det, PrjID)
    End If

    If (Det = "Mechanical_Element_Total_Active_Element_Count") Then
      PPSheading.Text = "Mechanical : Total Active Elements In PROJECT -" & PrjID
      ShowelementData(Det, PrjID)
    End If

    If (Det = "Mechanical_Element_Free") Then
      PPSheading.Text = "Mechanical : Free Elements In PROJECT -" & PrjID
      ShowelementData(Det, PrjID)
    End If

    If (Det = "Mechanical_Element_Partial") Then
      PPSheading.Text = "Mechanical : Partial Elements In PROJECT -" & PrjID
      ShowelementData(Det, PrjID)
    End If

    If (Det = "Mechanical_Element_Completed") Then
      PPSheading.Text = "Mechanical : Completed Elements In PROJECT -" & PrjID
      ShowelementData(Det, PrjID)
    End If

    If (Det = "Structure_Element_Total_Active_Element_Count") Then
      PPSheading.Text = "Structure : Total Active Elements In PROJECT -" & PrjID
      ShowelementData(Det, PrjID)
    End If

    If (Det = "Structure_Element_Free") Then
      PPSheading.Text = "Structure : Free Elements In PROJECT -" & PrjID
      ShowelementData(Det, PrjID)
    End If

    If (Det = "Structure_Element_Partial") Then
      PPSheading.Text = "Structure : Partial Elements In PROJECT -" & PrjID
      ShowelementData(Det, PrjID)
    End If

    If (Det = "Structure_Element_Completed") Then
      PPSheading.Text = "Structure : Completed Elements In PROJECT -" & PrjID
      ShowelementData(Det, PrjID)
    End If

    If (Det = "Piping_Element_Total_Active_Element_Count") Then
      PPSheading.Text = "Piping : Total Active Elements In PROJECT -" & PrjID
      ShowelementData(Det, PrjID)
    End If

    If (Det = "Piping_Element_Free") Then
      PPSheading.Text = "Piping : Free Elements In PROJECT -" & PrjID
      ShowelementData(Det, PrjID)
    End If

    If (Det = "Piping_Element_Partial") Then
      PPSheading.Text = "Piping : Partial Elements In PROJECT -" & PrjID
      ShowelementData(Det, PrjID)
    End If

    If (Det = "Piping_Element_Completed") Then
      PPSheading.Text = "Piping : Completed Elements In PROJECT -" & PrjID
      ShowelementData(Det, PrjID)
    End If

    If (Det = "Electrical_Element_Total_Active_Element_Count") Then
      PPSheading.Text = "Electrical : Total Active Elements In PROJECT -" & PrjID
      ShowelementData(Det, PrjID)
    End If

    If (Det = "Electrical_Element_Free") Then
      PPSheading.Text = "Electrical : Free Elements In PROJECT -" & PrjID
      ShowelementData(Det, PrjID)
    End If

    If (Det = "Electrical_Element_Partial") Then
      PPSheading.Text = "Electrical : Partial Elements In PROJECT -" & PrjID
      ShowelementData(Det, PrjID)
    End If

    If (Det = "Electrical_Element_Completed") Then
      PPSheading.Text = "Electrical : Completed Elements In PROJECT -" & PrjID
      ShowelementData(Det, PrjID)
    End If

    If (Det = "CI_Element_Total_Active_Element_Count") Then
      PPSheading.Text = "CI : Total Active Elements In PROJECT -" & PrjID
      ShowelementData(Det, PrjID)
    End If

    If (Det = "CI_Element_Free") Then
      PPSheading.Text = "CI : Free Elements In PROJECT -" & PrjID
      ShowelementData(Det, PrjID)
    End If

    If (Det = "CI_Element_Partial") Then
      PPSheading.Text = "CI : Partial Elements In PROJECT -" & PrjID
      ShowelementData(Det, PrjID)
    End If

    If (Det = "CI_Element_Completed") Then
      PPSheading.Text = "CI : Completed Elements In PROJECT -" & PrjID
      ShowelementData(Det, PrjID)
    End If

    If (Det = "Others_Element_Total_Active_Element_Count") Then
      PPSheading.Text = "Others : Total Active Elements In PROJECT -" & PrjID
      ShowelementData(Det, PrjID)
    End If

    If (Det = "Others_Element_Free") Then
      PPSheading.Text = "Others : Free Elements In PROJECT -" & PrjID
      ShowelementData(Det, PrjID)
    End If

    If (Det = "Others_Element_Partial") Then
      PPSheading.Text = "Others : Partial Elements In PROJECT -" & PrjID
      ShowelementData(Det, PrjID)
    End If

    If (Det = "Others_Element_Completed") Then
      PPSheading.Text = "Others : Completed Elements In PROJECT -" & PrjID
      ShowelementData(Det, PrjID)
    End If

    If (Det = "Total_Element_Total_Active_Element_Count") Then
      PPSheading.Text = "Total : Total Active Elements In PROJECT -" & PrjID
      ShowelementData(Det, PrjID)
    End If

    If (Det = "Total_Element_Free") Then
      PPSheading.Text = "Total : Free Elements In PROJECT -" & PrjID
      ShowelementData(Det, PrjID)
    End If

    If (Det = "Total_Element_Partial") Then
      PPSheading.Text = "Total : Partial Elements In PROJECT -" & PrjID
      ShowelementData(Det, PrjID)
    End If

    If (Det = "Total_Element_Completed") Then
      PPSheading.Text = "Total : Completed Elements In PROJECT -" & PrjID
      ShowelementData(Det, PrjID)
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

    If (Det = "HOLD_CHART") Then
      PPSheading.Text = "hold Status -Details"
      ShowHoldData(Det, PrjID)
    End If


    If (Det = "HOLD_CHART1") Then
      PPSheading.Text = "hold-DEPARTMENT Status -Details"
      ShowHoldData(Det, PrjID)
    End If








  End Sub
End Class
