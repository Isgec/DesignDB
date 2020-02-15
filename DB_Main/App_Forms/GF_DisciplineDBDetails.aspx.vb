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
    td.Text = "TYPE"
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    tr.Cells.Add(td)

    td = New TableCell
    td.Text = "PROJECT"
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
    td.Text = "PROJECT NAME"
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
    td.Text = "ACTUAL RELEASE"
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
      td.Text = tmp.t_pcod
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.t_cprj
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.Project_Name
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
      If (tmp.t_acdt = "01/01/1970") Then
        tmp.t_acdt = ""
        tr.BackColor = Drawing.Color.Yellow


      End If
      ' Dim t As Date = DateAdd(DateInterval.Minute, 330, tmp.t_acdt)
      td.Text = tmp.t_acdt

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
    td.Text = "PROJECT"
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
    td.Text = "PROJECT NAME"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    td.Text = "SAR No."
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
    td.Text = "SAR SEVERITY"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    td.Text = "NATURE OF PROBLEM"
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
    td.Text = "REVIEWED BY"
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
    td.Text = "OWNER"
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
      td.Text = tmp.Project_Name
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

      If tmp.t_stat.ToUpper = "UNDER REVIEW" Then
        td.ForeColor = Drawing.Color.Red
        tr.BackColor = Drawing.Color.Yellow
        With td
          .Font.Bold = True
        End With
      End If
      If tmp.t_stat.ToUpper = "UNDER APPROVAL" Then
        td.ForeColor = Drawing.Color.Red
        tr.BackColor = Drawing.Color.Yellow
        With td
          .Font.Bold = True
        End With
      End If
      If tmp.t_stat.ToUpper = "APPROVED" Then

        tr.BackColor = Drawing.Color.GreenYellow

      End If


      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.t_sars
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.t_natp
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

  Private Sub ShowDELEMENTData(ByVal a As String, ByVal b As String, ByVal c As String, ByVal d As String, ByVal e As String)
    Dim Data As List(Of SIS.DD.DisciplineDetail) = SIS.DD.DisciplineDetail.GetDELEMENTData(a, b, c, d, e)
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
    td.Text = "PROJECT"
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
    td.Text = "PROJECT NAME"
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
      td.Text = tmp.Project_Name
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

  'Private Sub ShowDPREORDERData(ByVal x As String, ByVal y As String)
  '  Dim Data As List(Of SIS.DB.engDoc) = SIS.DB.engDoc.GetData(x, y)

  '  Dim tbl As New Table
  '  With tbl
  '    .GridLines = GridLines.Both
  '    .BorderWidth = 2
  '    .CellSpacing = 2
  '    .Width = Unit.Percentage(100)
  '    .CssClass = "table-light table-bordered"
  '    '  .CssClass = "table-danger table-bordered thead-primary"
  '  End With
  '  Dim tr As TableRow = Nothing
  '  Dim td As TableCell = Nothing

  '  'Header
  '  tr = New TableRow

  '  td = New TableCell
  '  td.Text = "S.NO."
  '  With td
  '    .Font.Bold = True
  '    .Font.Size = FontUnit.Point(9)
  '  End With
  '  tr.Cells.Add(td)

  '  td = New TableCell
  '  With td
  '    .Font.Bold = True
  '    .Font.Size = FontUnit.Point(9)
  '  End With
  '  td.Text = "RECEIPT"
  '  tr.Cells.Add(td)

  '  td = New TableCell
  '  With td
  '    .Font.Bold = True
  '    .Font.Size = FontUnit.Point(9)
  '  End With
  '  td.Text = "REV"
  '  tr.Cells.Add(td)


  '  td = New TableCell
  '  With td
  '    .Font.Bold = True
  '    .Font.Size = FontUnit.Point(9)
  '  End With
  '  td.Text = "RECEIVED ON"
  '  tr.Cells.Add(td)

  '  td = New TableCell
  '  With td
  '    .Font.Bold = True
  '    .Font.Size = FontUnit.Point(9)
  '  End With
  '  td.Text = "PENDING (DAYS)"
  '  tr.Cells.Add(td)

  '  td = New TableCell
  '  With td
  '    .Font.Bold = True
  '    .Font.Size = FontUnit.Point(9)
  '  End With
  '  td.Text = "PROJECT TYPE"
  '  tr.Cells.Add(td)

  '  td = New TableCell
  '  With td
  '    .Font.Bold = True
  '    .Font.Size = FontUnit.Point(9)
  '  End With
  '  td.Text = "PROJECT ID"
  '  tr.Cells.Add(td)

  '  td = New TableCell
  '  With td
  '    .Font.Bold = True
  '    .Font.Size = FontUnit.Point(9)
  '  End With
  '  td.Text = "PROJECT NAME"
  '  tr.Cells.Add(td)

  '  td = New TableCell
  '  With td
  '    .Font.Bold = True
  '    .Font.Size = FontUnit.Point(9)
  '  End With
  '  td.Text = "ITEM DESCRIPTION"
  '  tr.Cells.Add(td)


  '  td = New TableCell
  '  With td
  '    .Font.Bold = True
  '    .Font.Size = FontUnit.Point(9)
  '  End With
  '  td.Text = "RECEIPT STATUS"
  '  tr.Cells.Add(td)

  '  td = New TableCell
  '  With td
  '    .Font.Bold = True
  '    .Font.Size = FontUnit.Point(9)
  '  End With
  '  td.Text = "MECH."
  '  tr.Cells.Add(td)

  '  td = New TableCell
  '  With td
  '    .Font.Bold = True
  '    .Font.Size = FontUnit.Point(9)
  '  End With
  '  td.Text = "STR."
  '  tr.Cells.Add(td)

  '  td = New TableCell
  '  With td
  '    .Font.Bold = True
  '    .Font.Size = FontUnit.Point(9)
  '  End With
  '  td.Text = "PIP."
  '  tr.Cells.Add(td)

  '  td = New TableCell
  '  With td
  '    .Font.Bold = True
  '    .Font.Size = FontUnit.Point(9)
  '  End With
  '  td.Text = "PRC."
  '  tr.Cells.Add(td)

  '  td = New TableCell
  '  With td
  '    .Font.Bold = True
  '    .Font.Size = FontUnit.Point(9)
  '  End With
  '  td.Text = "C&I"
  '  tr.Cells.Add(td)

  '  td = New TableCell
  '  With td
  '    .Font.Bold = True
  '    .Font.Size = FontUnit.Point(9)
  '  End With
  '  td.Text = "ELE."
  '  tr.Cells.Add(td)

  '  td = New TableCell
  '  With td
  '    .Font.Bold = True
  '    .Font.Size = FontUnit.Point(9)
  '  End With
  '  td.Text = "QLTY."
  '  tr.Cells.Add(td)

  '  td = New TableCell
  '  With td
  '    .Font.Bold = True
  '    .Font.Size = FontUnit.Point(9)
  '  End With
  '  td.Text = "OWNER DEPT."
  '  tr.Cells.Add(td)


  '  'td = New TableCell
  '  'With td
  '  '  .Font.Bold = True
  '  '  .Font.Size = FontUnit.Point(14)
  '  'End With
  '  'td.Text = "Option"
  '  'tr.Cells.Add(td)

  '  tbl.Rows.Add(tr)

  '  Dim I As Integer = 0
  '  Dim j As Integer = 0

  '  '================
  '  For Each tmp As SIS.DB.engDoc In Data




  '    Dim utmp As List(Of SIS.DB.UserRoleIDMS) = SIS.DB.UserRoleIDMS.GetUserRoleIDMS(y)
  '    For Each uptm As SIS.DB.UserRoleIDMS In utmp






  '      I += 1

  '      tr = New TableRow

  '      td = New TableCell
  '      td.Text = I
  '      tr.Cells.Add(td)

  '      td = New TableCell
  '      td.Text = tmp.ReceiptID
  '      tr.Cells.Add(td)

  '      td = New TableCell
  '      td.Text = tmp.Rrev
  '      tr.Cells.Add(td)


  '      td = New TableCell
  '      td.Text = tmp.SentDate
  '      tr.Cells.Add(td)

  '      td = New TableCell
  '      td.Text = tmp.Rageindays
  '      With td
  '        .Font.Bold = True


  '      End With
  '      If tmp.Rageindays >= 30 Then
  '        td.ForeColor = Drawing.Color.Red

  '      End If
  '      tr.Cells.Add(td)

  '      td = New TableCell
  '      td.Text = tmp.PType
  '      tr.Cells.Add(td)

  '      td = New TableCell
  '      td.Text = tmp.RProject
  '      tr.Cells.Add(td)

  '      td = New TableCell
  '      td.Text = tmp.Project_Name
  '      tr.Cells.Add(td)

  '      td = New TableCell
  '      td.Text = tmp.ItemDescription
  '      tr.Cells.Add(td)


  '      td = New TableCell
  '      td.Text = tmp.RStatus
  '      tr.Cells.Add(td)



  '      td = New TableCell
  '      td.Text = tmp.Mechanical

  '      If td.Text = "Pending" Then
  '        td.ForeColor = Drawing.Color.Red
  '        With td
  '          .Font.Bold = True


  '        End With


  '      End If
  '      tr.Cells.Add(td)

  '      td = New TableCell
  '      td.Text = tmp.Structure_

  '      If td.Text = "Pending" Then
  '        td.ForeColor = Drawing.Color.Red
  '        With td
  '          .Font.Bold = True
  '        End With
  '      End If
  '      tr.Cells.Add(td)

  '      td = New TableCell
  '      td.Text = tmp.Piping
  '      If td.Text = "Pending" Then
  '        td.ForeColor = Drawing.Color.Red
  '        With td
  '          .Font.Bold = True
  '        End With

  '      End If
  '      tr.Cells.Add(td)

  '      td = New TableCell
  '      td.Text = tmp.Process
  '      If td.Text = "Pending" Then
  '        td.ForeColor = Drawing.Color.Red
  '        With td
  '          .Font.Bold = True
  '        End With
  '      End If

  '      tr.Cells.Add(td)

  '      td = New TableCell
  '      td.Text = tmp.CandI
  '      If td.Text = "Pending" Then
  '        td.ForeColor = Drawing.Color.Red
  '        With td
  '          .Font.Bold = True
  '        End With
  '      End If
  '      tr.Cells.Add(td)

  '      td = New TableCell
  '      td.Text = tmp.Electrical
  '      If td.Text = "Pending" Then
  '        td.ForeColor = Drawing.Color.Red
  '        With td
  '          .Font.Bold = True
  '        End With
  '      End If
  '      tr.Cells.Add(td)

  '      td = New TableCell
  '      td.Text = tmp.Quality

  '      If td.Text = "Pending" Then
  '        td.ForeColor = Drawing.Color.Red
  '        With td
  '          .Font.Bold = True
  '        End With
  '      End If
  '      tr.Cells.Add(td)






  '      td = New TableCell
  '      td.Text = tmp.Owner_Dept
  '      If tmp.Owner_Dept.ToUpper = uptm.EDepartment.ToUpper Then
  '        td.ForeColor = Drawing.Color.DarkGreen
  '        tr.BackColor = Drawing.Color.Yellow
  '        With td
  '          .Font.Bold = True
  '        End With
  '      End If

  '      tr.Cells.Add(td)
  '    Next

  '    'td = New TableCell
  '    'Dim cmd As New Button
  '    'cmd.Text = "Click Me"
  '    'td.Controls.Add(cmd)
  '    'tr.Cells.Add(td)


  '    tbl.Rows.Add(tr)


  '  Next

  '  '================
  '  ppnlDetails.Controls.Add(tbl)

  'End Sub

  'Private Sub ShowDPOSTORDERData(ByVal x As String, ByVal y As String)
  '  Dim Data As List(Of SIS.DB.engDoc) = SIS.DB.engDoc.GetData(x, y)

  '  Dim tbl As New Table
  '  With tbl
  '    .GridLines = GridLines.Both
  '    .BorderWidth = 2
  '    .CellSpacing = 2
  '    .Width = Unit.Percentage(100)
  '    .CssClass = "table-light table-bordered"
  '    '  .CssClass = "table-danger table-bordered thead-primary"
  '  End With
  '  Dim tr As TableRow = Nothing
  '  Dim td As TableCell = Nothing

  '  'Header
  '  tr = New TableRow

  '  td = New TableCell
  '  td.Text = "S.NO."
  '  With td
  '    .Font.Bold = True
  '    .Font.Size = FontUnit.Point(9)
  '  End With
  '  tr.Cells.Add(td)

  '  td = New TableCell
  '  With td
  '    .Font.Bold = True
  '    .Font.Size = FontUnit.Point(9)
  '  End With
  '  td.Text = "RECEIPT"
  '  tr.Cells.Add(td)

  '  td = New TableCell
  '  With td
  '    .Font.Bold = True
  '    .Font.Size = FontUnit.Point(9)
  '  End With
  '  td.Text = "REV"
  '  tr.Cells.Add(td)



  '  td = New TableCell
  '  With td
  '    .Font.Bold = True
  '    .Font.Size = FontUnit.Point(9)
  '  End With
  '  td.Text = "RECEIVED ON"
  '  tr.Cells.Add(td)

  '  td = New TableCell
  '  With td
  '    .Font.Bold = True
  '    .Font.Size = FontUnit.Point(9)
  '  End With
  '  td.Text = "PENDING (DAYS)"
  '  tr.Cells.Add(td)

  '  td = New TableCell
  '  With td
  '    .Font.Bold = True
  '    .Font.Size = FontUnit.Point(9)
  '  End With
  '  td.Text = "PROJECT TYPE"
  '  tr.Cells.Add(td)

  '  td = New TableCell
  '  With td
  '    .Font.Bold = True
  '    .Font.Size = FontUnit.Point(9)
  '  End With
  '  td.Text = "PROJECT ID"
  '  tr.Cells.Add(td)

  '  td = New TableCell
  '  With td
  '    .Font.Bold = True
  '    .Font.Size = FontUnit.Point(9)
  '  End With
  '  td.Text = "PROJECT NAME"
  '  tr.Cells.Add(td)

  '  td = New TableCell
  '  With td
  '    .Font.Bold = True
  '    .Font.Size = FontUnit.Point(9)
  '  End With
  '  td.Text = "ITEM DESCRIPTION"
  '  tr.Cells.Add(td)

  '  td = New TableCell
  '  With td
  '    .Font.Bold = True
  '    .Font.Size = FontUnit.Point(9)
  '  End With
  '  td.Text = "PO NUMBER"
  '  tr.Cells.Add(td)

  '  td = New TableCell
  '  With td
  '    .Font.Bold = True
  '    .Font.Size = FontUnit.Point(9)
  '  End With
  '  td.Text = "PO STATUS"
  '  tr.Cells.Add(td)

  '  td = New TableCell
  '  With td
  '    .Font.Bold = True
  '    .Font.Size = FontUnit.Point(9)
  '  End With
  '  td.Text = "PR STATUS"
  '  tr.Cells.Add(td)

  '  td = New TableCell
  '  With td
  '    .Font.Bold = True
  '    .Font.Size = FontUnit.Point(9)
  '  End With
  '  td.Text = "RECEIPT STATUS"
  '  tr.Cells.Add(td)

  '  td = New TableCell
  '  With td
  '    .Font.Bold = True
  '    .Font.Size = FontUnit.Point(9)
  '  End With
  '  td.Text = "MECH."
  '  tr.Cells.Add(td)

  '  td = New TableCell
  '  With td
  '    .Font.Bold = True
  '    .Font.Size = FontUnit.Point(9)
  '  End With
  '  td.Text = "STR."
  '  tr.Cells.Add(td)

  '  td = New TableCell
  '  With td
  '    .Font.Bold = True
  '    .Font.Size = FontUnit.Point(9)

  '  End With
  '  td.Text = "PIP."
  '  tr.Cells.Add(td)

  '  td = New TableCell
  '  With td
  '    .Font.Bold = True
  '    .Font.Size = FontUnit.Point(9)
  '  End With
  '  td.Text = "PRC."
  '  tr.Cells.Add(td)

  '  td = New TableCell
  '  With td
  '    .Font.Bold = True
  '    .Font.Size = FontUnit.Point(9)
  '  End With
  '  td.Text = "C&I"
  '  tr.Cells.Add(td)

  '  td = New TableCell
  '  With td
  '    .Font.Bold = True
  '    .Font.Size = FontUnit.Point(9)
  '  End With
  '  td.Text = "ELE."
  '  tr.Cells.Add(td)

  '  td = New TableCell
  '  With td
  '    .Font.Bold = True
  '    .Font.Size = FontUnit.Point(9)
  '  End With
  '  td.Text = "QLTY."
  '  tr.Cells.Add(td)

  '  td = New TableCell
  '  With td
  '    .Font.Bold = True
  '    .Font.Size = FontUnit.Point(9)
  '  End With
  '  td.Text = "OWNER DEPT."
  '  tr.Cells.Add(td)


  '  'td = New TableCell
  '  'With td
  '  '  .Font.Bold = True
  '  '  .Font.Size = FontUnit.Point(14)
  '  'End With
  '  'td.Text = "Option"
  '  'tr.Cells.Add(td)

  '  tbl.Rows.Add(tr)

  '  Dim I As Integer = 0
  '  Dim j As Integer = 0

  '  '================
  '  For Each tmp As SIS.DB.engDoc In Data




  '    Dim utmp As List(Of SIS.DB.UserRoleIDMS) = SIS.DB.UserRoleIDMS.GetUserRoleIDMS(y)
  '    For Each uptm As SIS.DB.UserRoleIDMS In utmp






  '      I += 1

  '      tr = New TableRow

  '      td = New TableCell
  '      td.Text = I
  '      tr.Cells.Add(td)

  '      td = New TableCell
  '      td.Text = tmp.ReceiptID
  '      tr.Cells.Add(td)

  '      td = New TableCell
  '      td.Text = tmp.Rrev
  '      tr.Cells.Add(td)


  '      td = New TableCell
  '      td.Text = tmp.SentDate
  '      tr.Cells.Add(td)

  '      td = New TableCell
  '      td.Text = tmp.Rageindays
  '      With td
  '        .Font.Bold = True


  '      End With
  '      If tmp.Rageindays >= 30 Then
  '        td.ForeColor = Drawing.Color.Red

  '      End If
  '      tr.Cells.Add(td)

  '      td = New TableCell
  '      td.Text = tmp.PType
  '      tr.Cells.Add(td)

  '      td = New TableCell
  '      td.Text = tmp.RProject
  '      tr.Cells.Add(td)

  '      td = New TableCell
  '      td.Text = tmp.Project_Name
  '      tr.Cells.Add(td)

  '      td = New TableCell
  '      td.Text = tmp.ItemDescription
  '      tr.Cells.Add(td)

  '      td = New TableCell
  '      td.Text = tmp.PO_Number
  '      tr.Cells.Add(td)

  '      td = New TableCell
  '      td.Text = tmp.PO_Status
  '      tr.Cells.Add(td)

  '      td = New TableCell
  '      td.Text = tmp.PR_Status
  '      tr.Cells.Add(td)


  '      td = New TableCell
  '      td.Text = tmp.RStatus
  '      td.Font.Bold = True
  '      tr.Cells.Add(td)



  '      td = New TableCell
  '      td.Text = tmp.Mechanical

  '      If td.Text = "Pending" Then
  '        td.ForeColor = Drawing.Color.Red
  '        With td
  '          .Font.Bold = True


  '        End With


  '      End If
  '      tr.Cells.Add(td)

  '      td = New TableCell
  '      td.Text = tmp.Structure_

  '      If td.Text = "Pending" Then
  '        td.ForeColor = Drawing.Color.Red
  '        With td
  '          .Font.Bold = True
  '        End With
  '      End If
  '      tr.Cells.Add(td)

  '      td = New TableCell
  '      td.Text = tmp.Piping
  '      If td.Text = "Pending" Then
  '        td.ForeColor = Drawing.Color.Red
  '        With td
  '          .Font.Bold = True
  '        End With

  '      End If
  '      tr.Cells.Add(td)

  '      td = New TableCell
  '      td.Text = tmp.Process
  '      If td.Text = "Pending" Then
  '        td.ForeColor = Drawing.Color.Red
  '        With td
  '          .Font.Bold = True
  '        End With
  '      End If

  '      tr.Cells.Add(td)

  '      td = New TableCell
  '      td.Text = tmp.CandI
  '      If td.Text = "Pending" Then
  '        td.ForeColor = Drawing.Color.Red
  '        With td
  '          .Font.Bold = True
  '        End With
  '      End If
  '      tr.Cells.Add(td)

  '      td = New TableCell
  '      td.Text = tmp.Electrical
  '      If td.Text = "Pending" Then
  '        td.ForeColor = Drawing.Color.Red
  '        With td
  '          .Font.Bold = True
  '        End With
  '      End If
  '      tr.Cells.Add(td)

  '      td = New TableCell
  '      td.Text = tmp.Quality

  '      If td.Text = "Pending" Then
  '        td.ForeColor = Drawing.Color.Red
  '        With td
  '          .Font.Bold = True
  '        End With
  '      End If
  '      tr.Cells.Add(td)






  '      td = New TableCell
  '      td.Text = tmp.Owner_Dept
  '      If tmp.Owner_Dept.ToUpper = uptm.EDepartment.ToUpper Then
  '        td.ForeColor = Drawing.Color.DarkGreen
  '        tr.BackColor = Drawing.Color.Yellow
  '        With td
  '          .Font.Bold = True
  '        End With
  '      End If

  '      tr.Cells.Add(td)
  '    Next

  '    'td = New TableCell
  '    'Dim cmd As New Button
  '    'cmd.Text = "Click Me"
  '    'td.Controls.Add(cmd)
  '    'tr.Cells.Add(td)


  '    tbl.Rows.Add(tr)


  '  Next

  '  '================
  '  ppnlDetails.Controls.Add(tbl)

  'End Sub




  Private Sub GF_DisciplineDBDetails_Load(sender As Object, e As EventArgs) Handles Me.Load
    Dim Det As String = Request.QueryString("detail")
    Dim DivisionID As String = Request.QueryString("DivisionID")
    Dim DisciplineID As String = Request.QueryString("DisciplineID")
    Dim MonthID As String = Request.QueryString("MonthID")
    Dim YearID As String = Request.QueryString("YearID")
    Dim CMonthName As String = ""
    Dim PMonthName As String = ""
    If (MonthID = "1") Then
      CMonthName = "January"
      PMonthName = "December"
    End If
    If (MonthID = "2") Then
      CMonthName = "February"
      PMonthName = "January"
    End If
    If (MonthID = "3") Then
      CMonthName = "March"
      PMonthName = "February"
    End If
    If (MonthID = "4") Then
      CMonthName = "April"
      PMonthName = "March"
    End If
    If (MonthID = "5") Then
      CMonthName = "May"
      PMonthName = "April"
    End If
    If (MonthID = "6") Then
      CMonthName = "June"
      PMonthName = "May"
    End If
    If (MonthID = "7") Then
      CMonthName = "July"
      PMonthName = "June"
    End If
    If (MonthID = "8") Then
      CMonthName = "August"
      PMonthName = "July"
    End If
    If (MonthID = "9") Then
      CMonthName = "September"
      PMonthName = "August"
    End If
    If (MonthID = "10") Then
      CMonthName = "October"
      PMonthName = "September"

    End If
    If (MonthID = "11") Then
      CMonthName = "November"
      PMonthName = "October"

    End If
    If (MonthID = "12") Then
      CMonthName = "December"
      PMonthName = "November"

    End If

    If (Det = "ToRelease_CurrentM") Then
      PPSheading.Text = "Total drawings and documents to release in " & CMonthName & "/" & YearID & " for " & DivisionID & " / " & DisciplineID
      ShowDPLMData(Det, DivisionID, DisciplineID, YearID, MonthID)
    End If


    If (Det = "DueforRelease_CurrentM_A") Then
      PPSheading.Text = "Total drawings and documents due for release in " & CMonthName & "/" & YearID & " for " & DivisionID & " / " & DisciplineID
      ShowDPLMData(Det, DivisionID, DisciplineID, YearID, MonthID)
    End If
    If (Det = "DueforRelease_PreviousM_B") Then
      PPSheading.Text = "Total drawings and documents list due for release in " & PMonthName & "/" & YearID & " for " & DivisionID & " / " & DisciplineID
      ShowDPLMData(Det, DivisionID, DisciplineID, YearID, MonthID)
    End If
    If (Det = "DueforRelease_BothM_C") Then
      PPSheading.Text = "Total drawings and documents list due for release in " & PMonthName & "/" & YearID & " and " & CMonthName & "/" & YearID & " for " & DivisionID & " / " & DisciplineID
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
      PPSheading.Text = "Total drawings and documents released Ontime in " & CMonthName & "/" & YearID & " for " & DivisionID & " / " & DisciplineID
      ShowDPLMData(Det, DivisionID, DisciplineID, YearID, MonthID)
    End If
    If (Det = "Backlog_Release_CurrentM") Then

      PPSheading.Text = "Total drawings and documents backlog released in " & CMonthName & "/" & YearID & " for " & DivisionID & " / " & DisciplineID
      ShowDPLMData(Det, DivisionID, DisciplineID, YearID, MonthID)
    End If

    If (Det = "SAR_TotalCount") Then
      PPSheading.Text = "Total SAR Count in " & CMonthName & "/" & YearID & " for " & DivisionID & " / " & DisciplineID
      ShowDSARData(Det, DivisionID, DisciplineID, YearID, MonthID)
    End If
    If (Det = "SAR_UnderCreation") Then
      PPSheading.Text = "Total SAR in Under Creation State Count in " & CMonthName & "/" & YearID & " for " & DivisionID & " / " & DisciplineID
      ShowDSARData(Det, DivisionID, DisciplineID, YearID, MonthID)
    End If
    If (Det = "SAR_UnderReview") Then
      PPSheading.Text = "Total SAR in Under Review State Count in " & CMonthName & "/" & YearID & " for " & DivisionID & " / " & DisciplineID
      ShowDSARData(Det, DivisionID, DisciplineID, YearID, MonthID)
    End If
    If (Det = "SAR_UnderApproval") Then
      PPSheading.Text = "Total SAR in Under Approval State Count in " & CMonthName & "/" & YearID & " for " & DivisionID & " / " & DisciplineID
      ShowDSARData(Det, DivisionID, DisciplineID, YearID, MonthID)
    End If
    If (Det = "SAR_Pending") Then
      PPSheading.Text = "Total Pending SAR in " & CMonthName & "/" & YearID & " for " & DivisionID & " / " & DisciplineID
      ShowDSARData(Det, DivisionID, DisciplineID, YearID, MonthID)
    End If
    If (Det = "SAR_Approved") Then
      PPSheading.Text = "Total Approved SAR in " & CMonthName & "/" & YearID & " for " & DivisionID & " / " & DisciplineID
      ShowDSARData(Det, DivisionID, DisciplineID, YearID, MonthID)
    End If
    If (Det = "SAR_NotApplicable") Then
      PPSheading.Text = "Total Approved SAR in " & CMonthName & "/" & YearID & " for " & DivisionID & " / " & DisciplineID
      ShowDSARData(Det, DivisionID, DisciplineID, YearID, MonthID)
    End If

    If (Det = "SAR_TotalCountA") Then
      PPSheading.Text = "Total SAR Count in  for " & DivisionID & " / " & DisciplineID
      ShowDSARData(Det, DivisionID, DisciplineID, YearID, MonthID)
    End If
    If (Det = "SAR_UnderCreationA") Then
      PPSheading.Text = "Total SAR in Under Creation State Count in  for " & DivisionID & " / " & DisciplineID
      ShowDSARData(Det, DivisionID, DisciplineID, YearID, MonthID)
    End If
    If (Det = "SAR_UnderReviewA") Then
      PPSheading.Text = "Total SAR in Under Review State Count in  for " & DivisionID & " / " & DisciplineID
      ShowDSARData(Det, DivisionID, DisciplineID, YearID, MonthID)
    End If
    If (Det = "SAR_UnderApprovalA") Then
      PPSheading.Text = "Total SAR in Under Approval State Count in  for " & DivisionID & " / " & DisciplineID
      ShowDSARData(Det, DivisionID, DisciplineID, YearID, MonthID)
    End If
    If (Det = "SAR_PendingA") Then
      PPSheading.Text = "Total Pending SAR in  for " & DivisionID & " / " & DisciplineID
      ShowDSARData(Det, DivisionID, DisciplineID, YearID, MonthID)
    End If
    If (Det = "SAR_ApprovedA") Then
      PPSheading.Text = "Total Approved SAR in  for " & DivisionID & " / " & DisciplineID
      ShowDSARData(Det, DivisionID, DisciplineID, YearID, MonthID)
    End If
    If (Det = "SAR_NotApplicableA") Then
      PPSheading.Text = "Total Approved SAR in  for " & DivisionID & " / " & DisciplineID
      ShowDSARData(Det, DivisionID, DisciplineID, YearID, MonthID)
    End If
    If (Det = "Total_Element") Then
      PPSheading.Text = "Total Element  for " & DivisionID & " / " & DisciplineID
      ShowDELEMENTData(Det, DivisionID, DisciplineID, YearID, MonthID)
    End If
    If (Det = "Element_Free") Then
      PPSheading.Text = "Total Free Element  for " & DivisionID & " / " & DisciplineID
      ShowDELEMENTData(Det, DivisionID, DisciplineID, YearID, MonthID)
    End If
    If (Det = "Element_Partial") Then
      PPSheading.Text = "Total Partial Element  for " & DivisionID & " / " & DisciplineID
      ShowDELEMENTData(Det, DivisionID, DisciplineID, YearID, MonthID)
    End If
    If (Det = "Element_Completed") Then
      PPSheading.Text = "Total Completed Element  for " & DivisionID & " / " & DisciplineID
      ShowDELEMENTData(Det, DivisionID, DisciplineID, YearID, MonthID)
    End If
  End Sub
End Class
