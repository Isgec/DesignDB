Partial Class GF_DisciplineDBDetails
  Inherits System.Web.UI.Page

  Private Sub ShowDPLMData(ByVal a As String, ByVal b As String, ByVal c As String, ByVal d As String, ByVal e As String)
    Dim Data As List(Of SIS.DD.DisciplineDetail) = SIS.DD.DisciplineDetail.GetDPLMData(a, b, c, d, e)
    Dim tbl As New Table


    With tbl

      .GridLines = GridLines.Both
      .BorderWidth = 2
      .CellSpacing = 2
      .Width = Unit.Percentage(100)
      .CssClass = "table-light table-bordered"


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
    td.Text = "PROJECT"
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




    tbl.Rows.Add(tr)

    Dim I As Integer = 0
    '================
    For Each tmp As SIS.DD.DisciplineDetail In Data
      I += 1
      tr = New TableRow

      td = New TableCell
      td.Text = I
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.t_cprj
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




      tbl.Rows.Add(tr)


    Next
    '================
    ppnlDetails.Controls.Add(tbl)

  End Sub

  Private Sub ShowDSARData(ByVal a As String, ByVal b As String, ByVal c As String, ByVal d As String, ByVal e As String)
    Dim Data As List(Of SIS.DD.DisciplineDetail) = SIS.DD.DisciplineDetail.GetDSARData(a, b, c, d, e)
    Dim tbl As New Table


    With tbl

      .GridLines = GridLines.Both
      .BorderWidth = 2
      .CellSpacing = 2
      .Width = Unit.Percentage(100)
      .CssClass = "table-light table-bordered"


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
    td.Text = "PROJECT"
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




    tbl.Rows.Add(tr)

    Dim I As Integer = 0
    '================
    For Each tmp As SIS.DD.DisciplineDetail In Data
      I += 1
      tr = New TableRow

      td = New TableCell
      td.Text = I
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.t_cprj
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




      tbl.Rows.Add(tr)


    Next
    '================
    ppnlDetails.Controls.Add(tbl)

  End Sub

  Private Sub GF_DisciplineDBDetails_Load(sender As Object, e As EventArgs) Handles Me.Load
    Dim Det As String = Request.QueryString("detail")
    Dim DivisionID As String = Request.QueryString("DivisionID")
    Dim DisciplineID As String = Request.QueryString("DisciplineID")
    Dim MonthID As String = Request.QueryString("MonthID")
    Dim YearID As String = Request.QueryString("YearID")


    If (Det = "DueforRelease_CurrentM_A") Then
      PPSheading.Text = "Total drawings and documents due for release in " & MonthID & "/" & YearID & " for " & DivisionID & " / " & DisciplineID
      ShowDPLMData(Det, DivisionID, DisciplineID, YearID, MonthID)
    End If
    If (Det = "DueforRelease_PreviousM_B") Then
      PPSheading.Text = "Total drawings and documents list due for release in " & MonthID - 1 & "/" & YearID & " for " & DivisionID & " / " & DisciplineID
      ShowDPLMData(Det, DivisionID, DisciplineID, YearID, MonthID)
    End If
    If (Det = "DueforRelease_BothM_C") Then
      PPSheading.Text = "Total drawings and documents list due for release in " & MonthID - 1 & "/" & YearID & " and " & MonthID & "/" & YearID & " for " & DivisionID & " / " & DisciplineID
      ShowDPLMData(Det, DivisionID, DisciplineID, YearID, MonthID)
    End If
    If (Det = "AllDueTillToday_Release") Then
      PPSheading.Text = "Total drawings and documents list due for release till today for " & DivisionID & " / " & DisciplineID
      ShowDPLMData(Det, DivisionID, DisciplineID, YearID, MonthID)
    End If
    If (Det = "DueOnlyToday_Release") Then
      PPSheading.Text = "Total drawings and documents list due for Only today for " & DivisionID & " / " & DisciplineID
      ShowDPLMData(Det, DivisionID, DisciplineID, YearID, MonthID)
    End If
    If (Det = "Ontime_Release_CurrentM") Then
      PPSheading.Text = "Total drawings and documents released Ontime in " & MonthID & "/" & YearID & " for " & DivisionID & " / " & DisciplineID
      ShowDPLMData(Det, DivisionID, DisciplineID, YearID, MonthID)
    End If
    If (Det = "Backlog_Release_CurrentM") Then

      PPSheading.Text = "Total drawings and documents backlog released in " & MonthID & "/" & YearID & " for " & DivisionID & " / " & DisciplineID
      ShowDPLMData(Det, DivisionID, DisciplineID, YearID, MonthID)
    End If




  End Sub
End Class
