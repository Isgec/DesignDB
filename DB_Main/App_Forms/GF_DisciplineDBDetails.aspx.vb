Partial Class GF_DisciplineDBDetails
  Inherits System.Web.UI.Page

  Private Sub ShowDPLMData(ByVal det As String, ByVal DivisionID As String, ByVal DisciplineID As String, ByVal YearID As String, ByVal MonthID As String)
    Dim Data As List(Of SIS.DD.DisciplineDetail) = SIS.DD.DisciplineDetail.GetDPLMData(det, DivisionID, DisciplineID, YearID, MonthID)
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


        'ElseIf (tmp.t_acdt <= tmp.t_bsfd) Then
        '  tr.BackColor = Drawing.Color.GreenYellow

        'ElseIf (tmp.t_acdt > tmp.t_bsfd) Then
        '  tr.BackColor = Drawing.Color.Red
      End If


      ' Dim t As Date = DateAdd(DateInterval.Minute, 330, tmp.t_acdt)
      td.Text = tmp.t_acdt

      tr.Cells.Add(td)




      tbl.Rows.Add(tr)


    Next
    '================
    ppnlDetails.Controls.Add(tbl)

  End Sub

  Private Sub ShowDSARData(ByVal det As String, ByVal DivisionID As String, ByVal DisciplineID As String, ByVal YearID As String, ByVal MonthID As String)
    Dim Data As List(Of SIS.DD.DisciplineDetail) = SIS.DD.DisciplineDetail.GetDSARData(det, DivisionID, DisciplineID, YearID, MonthID)
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
    td.Text = "CREATED ON"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    td.Text = "ISSUED ON"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    td.Text = "PENDING Days"
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
    td.Text = "CREATOR"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(8)
    End With
    td.Text = "REVIEWER"
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
      td.Text = tmp.Ptype
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
      td.Text = tmp.t_cdat
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.t_idat
      tr.Cells.Add(td)



      td = New TableCell



      If tmp.t_stat.ToUpper = "UNDER REVIEW" Or tmp.t_stat.ToUpper = "UNDER APPROVAL" Then
        If tmp.t_sars.ToUpper = "WORK STOPPED" And tmp.Sageindays >= 4 Then
          With td
            .Text = tmp.Sageindays
            .Font.Bold = True
            .ForeColor = Drawing.Color.Red
            .Font.Size = FontUnit.Point(11)

            .ToolTip = "As per KV Sir's Mail Dated 1st July 2019 regarding 'SAR Corrective Actions'" & Environment.NewLine &
                        "If SAR Severity is 'Work Stopped' then it should be replied within 3 working days " & Environment.NewLine &
             "*(This RED color alert is as per Calender Days)"
          End With
        Else
          If (tmp.Sageindays <= 1) Then
            td.Text = tmp.Sageindays
            td.Font.Size = FontUnit.Point(10)


          Else
            td.Text = tmp.Sageindays
            td.Font.Size = FontUnit.Point(10)
            td.Font.Bold = True

          End If
          'Else
          '  td.Text = tmp.Sageindays
          '  td.Font.Bold = True
          '  td.Font.Size = FontUnit.Point(10)

        End If

        If tmp.t_sars.ToUpper = "WORK CAN PROCEED" And tmp.Sageindays >= 7 Then
          With td
            .Text = tmp.Sageindays
            .Font.Bold = True
            .ForeColor = Drawing.Color.Red
            .Font.Size = FontUnit.Point(11)
            .ToolTip = "As per KV Sir's Mail Dated 1st July 2019 regarding 'SAR Corrective Actions'" & Environment.NewLine &
                         "If SAR Severity is 'Work Can Proceed' then it should be replied within 6 working days " & Environment.NewLine &
                         "*(This RED color alert is as per Calender Days)"
          End With
        Else
          If (tmp.Sageindays <= 1) Then
            td.Text = tmp.Sageindays
            td.Font.Size = FontUnit.Point(10)


          Else
            td.Text = tmp.Sageindays
            td.Font.Size = FontUnit.Point(10)
            td.Font.Bold = True

          End If
          'Else
          '  td.Text = tmp.Sageindays
          '  td.Font.Bold = True
          '  td.Font.Size = FontUnit.Point(10)
        End If


      Else
        td.Text = ""

      End If


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
        td.ToolTip = "Pending"
        With td
          .Font.Bold = True
        End With
      End If
      If tmp.t_stat.ToUpper = "UNDER APPROVAL" Then
        td.ForeColor = Drawing.Color.Red
        tr.BackColor = Drawing.Color.Yellow
        td.ToolTip = "Pending"
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

  Private Sub ShowDELEMENTData(ByVal det As String, ByVal DivisionID As String, ByVal DisciplineID As String, ByVal YearID As String, ByVal MonthID As String)
    Dim Data As List(Of SIS.DD.DisciplineDetail) = SIS.DD.DisciplineDetail.GetDELEMENTData(det, DivisionID, DisciplineID, YearID, MonthID)
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
      td.Text = tmp.Ptype
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

  Private Sub ShowDIDMSPREData(ByVal det As String, ByVal DivisionID As String, ByVal DisciplineID As String, ByVal YearID As String, ByVal MonthID As String)
    Dim Data As List(Of SIS.DD.DisciplineDetail) = SIS.DD.DisciplineDetail.GetDIDMSPREData(det, DivisionID, DisciplineID, YearID, MonthID)


    Dim tbl As New Table
    With tbl
      .GridLines = GridLines.Both
      .BorderWidth = 2
      .CellSpacing = 2
      .Width = Unit.Percentage(100)
      .CssClass = "table-light table-bordered"
      '  .CssClass = "table-danger table-bordered thead-primary"
    End With
    Dim tr As TableRow = Nothing
    Dim td As TableCell = Nothing

    'Header
    tr = New TableRow

    td = New TableCell
    td.Text = "S.NO."
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "RECEIPT"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "REV"
    tr.Cells.Add(td)


    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "RECEIVED ON"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "PENDING (DAYS)"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "TYPE"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "PROJECT ID"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "PROJECT NAME"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "ITEM DESCRIPTION"
    tr.Cells.Add(td)


    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "RECEIPT STATUS"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "MECH."
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "STR."
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "PIP."
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "PRC."
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "C&I"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "ELE."
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "QLTY."
    tr.Cells.Add(td)




    'td = New TableCell
    'With td
    '  .Font.Bold = True
    '  .Font.Size = FontUnit.Point(14)
    'End With
    'td.Text = "Option"
    'tr.Cells.Add(td)

    tbl.Rows.Add(tr)

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
        td.Text = tmp.ReceiptID
        tr.Cells.Add(td)

        td = New TableCell
        td.Text = tmp.Rrev
        tr.Cells.Add(td)


        td = New TableCell
      td.Text = tmp.SentDate
      If tmp.SentDate = "01/01/1970" Then
        td.Text = ""
      End If
      If tmp.SentDate = "01/01/1900" Then
        td.Text = ""
      End If

      tr.Cells.Add(td)

      '  td = New TableCell
      '  td.Text = tmp.Rageindays
      '  With td
      '  .Font.Bold = True



      'End With
      '  If tmp.Rageindays >= 30 Then
      '    td.ForeColor = Drawing.Color.Red

      '  End If
      '  tr.Cells.Add(td)

      td = New TableCell
      td.Text = ""
      If tmp.RStatus = "Under Evaluation" Then
        td.Text = tmp.Rageindays
        td.Font.Bold = True
        tr.BackColor = Drawing.Color.Yellow
      End If
      If tmp.RStatus = "Comments Submitted" Then
        td.Text = tmp.Rageindays
        td.Font.Bold = True
        tr.BackColor = Drawing.Color.Yellow
      End If





      tr.Cells.Add(td)








      td = New TableCell
        td.Text = tmp.Ptype
        tr.Cells.Add(td)

        td = New TableCell
        td.Text = tmp.RProject
        tr.Cells.Add(td)

        td = New TableCell
        td.Text = tmp.Project_Name
        tr.Cells.Add(td)

        td = New TableCell
        td.Text = tmp.ItemDescription
        tr.Cells.Add(td)


        td = New TableCell
        td.Text = tmp.RStatus
        tr.Cells.Add(td)



        td = New TableCell
        td.Text = tmp.Mechanical

        If td.Text = "Pending" Then
          td.ForeColor = Drawing.Color.Red
          With td
            .Font.Bold = True


          End With


        End If
        tr.Cells.Add(td)

        td = New TableCell
      td.Text = tmp.sStructure

      If td.Text = "Pending" Then
          td.ForeColor = Drawing.Color.Red
          With td
            .Font.Bold = True
          End With
        End If
        tr.Cells.Add(td)

        td = New TableCell
        td.Text = tmp.Piping
        If td.Text = "Pending" Then
          td.ForeColor = Drawing.Color.Red
          With td
            .Font.Bold = True
          End With

        End If
        tr.Cells.Add(td)

        td = New TableCell
        td.Text = tmp.Process
        If td.Text = "Pending" Then
          td.ForeColor = Drawing.Color.Red
          With td
            .Font.Bold = True
          End With
        End If

        tr.Cells.Add(td)

        td = New TableCell
        td.Text = tmp.CandI
        If td.Text = "Pending" Then
          td.ForeColor = Drawing.Color.Red
          With td
            .Font.Bold = True
          End With
        End If
        tr.Cells.Add(td)

        td = New TableCell
        td.Text = tmp.Electrical
        If td.Text = "Pending" Then
          td.ForeColor = Drawing.Color.Red
          With td
            .Font.Bold = True
          End With
        End If
        tr.Cells.Add(td)

        td = New TableCell
        td.Text = tmp.Quality

        If td.Text = "Pending" Then
          td.ForeColor = Drawing.Color.Red
          With td
            .Font.Bold = True
          End With
        End If
        tr.Cells.Add(td)




      'td = New TableCell
      'Dim cmd As New Button
      'cmd.Text = "Click Me"
      'td.Controls.Add(cmd)
      'tr.Cells.Add(td)


      tbl.Rows.Add(tr)


    Next

    '================
    ppnlDetails.Controls.Add(tbl)

  End Sub

  Private Sub ShowDIDMSPOSTData(ByVal det As String, ByVal DivisionID As String, ByVal DisciplineID As String, ByVal YearID As String, ByVal MonthID As String)
    Dim Data As List(Of SIS.DD.DisciplineDetail) = SIS.DD.DisciplineDetail.GetDIDMSPOSTData(det, DivisionID, DisciplineID, YearID, MonthID)


    Dim tbl As New Table
    With tbl
      .GridLines = GridLines.Both
      .BorderWidth = 2
      .CellSpacing = 2
      .Width = Unit.Percentage(100)
      .CssClass = "table-light table-bordered"
      '  .CssClass = "table-danger table-bordered thead-primary"
    End With
    Dim tr As TableRow = Nothing
    Dim td As TableCell = Nothing

    'Header
    tr = New TableRow

    td = New TableCell
    td.Text = "S.NO."
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "RECEIPT"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "REV"
    tr.Cells.Add(td)


    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "RECEIVED ON"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "PENDING (DAYS)"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "TYPE"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "PROJECT ID"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "PROJECT NAME"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "ITEM DESCRIPTION"
    tr.Cells.Add(td)


    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "RECEIPT STATUS"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "MECH."
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "STR."
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "PIP."
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "PRC."
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "C&I"
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "ELE."
    tr.Cells.Add(td)

    td = New TableCell
    With td
      .Font.Bold = True
      .Font.Size = FontUnit.Point(9)
    End With
    td.Text = "QLTY."
    tr.Cells.Add(td)




    'td = New TableCell
    'With td
    '  .Font.Bold = True
    '  .Font.Size = FontUnit.Point(14)
    'End With
    'td.Text = "Option"
    'tr.Cells.Add(td)

    tbl.Rows.Add(tr)

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
      td.Text = tmp.ReceiptID
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.Rrev
      tr.Cells.Add(td)


      td = New TableCell
      td.Text = tmp.SentDate
      If tmp.SentDate = "01/01/1970" Then
        td.Text = ""
      End If
      tr.Cells.Add(td)

      '  td = New TableCell
      '  td.Text = tmp.Rageindays
      '  With td
      '  .Font.Bold = True



      'End With
      '  If tmp.Rageindays >= 30 Then
      '    td.ForeColor = Drawing.Color.Red

      '  End If
      '  tr.Cells.Add(td)

      td = New TableCell
      td.Text = ""
      If tmp.RStatus = "Under Evaluation" Then
        td.Text = tmp.Rageindays
        td.Font.Bold = True
      End If
      If tmp.RStatus = "Comments Submitted" Then
        td.Text = tmp.Rageindays
        td.Font.Bold = True
      End If





      tr.Cells.Add(td)








      td = New TableCell
      td.Text = tmp.Ptype
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.RProject
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.Project_Name
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.ItemDescription
      tr.Cells.Add(td)


      td = New TableCell
      td.Text = tmp.RStatus
      tr.Cells.Add(td)



      td = New TableCell
      td.Text = tmp.Mechanical

      If td.Text = "Pending" Then
        td.ForeColor = Drawing.Color.Red
        With td
          .Font.Bold = True


        End With


      End If
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.sStructure

      If td.Text = "Pending" Then
        td.ForeColor = Drawing.Color.Red
        With td
          .Font.Bold = True
        End With
      End If
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.Piping
      If td.Text = "Pending" Then
        td.ForeColor = Drawing.Color.Red
        With td
          .Font.Bold = True
        End With

      End If
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.Process
      If td.Text = "Pending" Then
        td.ForeColor = Drawing.Color.Red
        With td
          .Font.Bold = True
        End With
      End If

      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.CandI
      If td.Text = "Pending" Then
        td.ForeColor = Drawing.Color.Red
        With td
          .Font.Bold = True
        End With
      End If
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.Electrical
      If td.Text = "Pending" Then
        td.ForeColor = Drawing.Color.Red
        With td
          .Font.Bold = True
        End With
      End If
      tr.Cells.Add(td)

      td = New TableCell
      td.Text = tmp.Quality

      If td.Text = "Pending" Then
        td.ForeColor = Drawing.Color.Red
        With td
          .Font.Bold = True
        End With
      End If
      tr.Cells.Add(td)




      'td = New TableCell
      'Dim cmd As New Button
      'cmd.Text = "Click Me"
      'td.Controls.Add(cmd)
      'tr.Cells.Add(td)


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




    If (Det = "IDMSPre_Total_Count") Then
      PPSheading.Text = "Total Pre Order Receipt  for " & DivisionID & " / " & DisciplineID
      ShowDIDMSPREData(Det, DivisionID, DisciplineID, YearID, MonthID)
    End If
    If (Det = "IDMSPre_Submitted") Then
      PPSheading.Text = "Total Pre Order Receipt  for " & DivisionID & " / " & DisciplineID & "In Submitted State"
      ShowDIDMSPREData(Det, DivisionID, DisciplineID, YearID, MonthID)
    End If
    If (Det = "IDMSPre_Document_linked") Then
      PPSheading.Text = "Total Pre Order Receipt  for " & DivisionID & " / " & DisciplineID & "In Document linked State"
      ShowDIDMSPREData(Det, DivisionID, DisciplineID, YearID, MonthID)
    End If

    If (Det = "IDMSPre_Under_Evaluation") Then
      PPSheading.Text = "Total Pre Order Receipt  for " & DivisionID & " / " & DisciplineID & "In Under Evaluation State"
      ShowDIDMSPREData(Det, DivisionID, DisciplineID, YearID, MonthID)
    End If

    If (Det = "IDMSPre_Comments_Submitted") Then
      PPSheading.Text = "Total Pre Order Receipt  for " & DivisionID & " / " & DisciplineID & "In Comments_Submitted State"
      ShowDIDMSPREData(Det, DivisionID, DisciplineID, YearID, MonthID)
    End If

    If (Det = "IDMSPre_Technically_Cleared") Then
      PPSheading.Text = "Total Pre Order Receipt  for " & DivisionID & " / " & DisciplineID & "In Technically_Cleared State"
      ShowDIDMSPREData(Det, DivisionID, DisciplineID, YearID, MonthID)
    End If

    If (Det = "IDMSPre_Transmittal_Issued") Then
      PPSheading.Text = "Total Pre Order Receipt  for " & DivisionID & " / " & DisciplineID & "In Transmittal_Issued State"
      ShowDIDMSPREData(Det, DivisionID, DisciplineID, YearID, MonthID)
    End If

    If (Det = "IDMSPre_Superceded") Then
      PPSheading.Text = "Total Pre Order Receipt  for " & DivisionID & " / " & DisciplineID & "In Superceded State"
      ShowDIDMSPREData(Det, DivisionID, DisciplineID, YearID, MonthID)
    End If

    If (Det = "IDMSPre_Closed") Then
      PPSheading.Text = "Total Pre Order Receipt  for " & DivisionID & " / " & DisciplineID & "In Closed State"
      ShowDIDMSPREData(Det, DivisionID, DisciplineID, YearID, MonthID)
    End If


    If (Det = "All_IDMSPre_Total_Count") Then
      PPSheading.Text = "Total Pre Order Receipt  for " & DivisionID & " / " & DisciplineID
      ShowDIDMSPREData(Det, DivisionID, DisciplineID, YearID, MonthID)
    End If
    If (Det = "All_IDMSPre_Submitted") Then
      PPSheading.Text = "Total Pre Order Receipt  for " & DivisionID & " / " & DisciplineID & "In Submitted State"
      ShowDIDMSPREData(Det, DivisionID, DisciplineID, YearID, MonthID)
    End If
    If (Det = "All_IDMSPre_Document_linked") Then
      PPSheading.Text = "Total Pre Order Receipt  for " & DivisionID & " / " & DisciplineID & "In Document linked State"
      ShowDIDMSPREData(Det, DivisionID, DisciplineID, YearID, MonthID)
    End If

    If (Det = "All_IDMSPre_Under_Evaluation") Then
      PPSheading.Text = "Total Pre Order Receipt  for " & DivisionID & " / " & DisciplineID & "In Under Evaluation State"
      ShowDIDMSPREData(Det, DivisionID, DisciplineID, YearID, MonthID)
    End If

    If (Det = "All_IDMSPre_Comments_Submitted") Then
      PPSheading.Text = "Total Pre Order Receipt  for " & DivisionID & " / " & DisciplineID & "In Comments_Submitted State"
      ShowDIDMSPREData(Det, DivisionID, DisciplineID, YearID, MonthID)
    End If

    If (Det = "All_IDMSPre_Technically_Cleared") Then
      PPSheading.Text = "Total Pre Order Receipt  for " & DivisionID & " / " & DisciplineID & "In Technically_Cleared State"
      ShowDIDMSPREData(Det, DivisionID, DisciplineID, YearID, MonthID)
    End If

    If (Det = "All_IDMSPre_Transmittal_Issued") Then
      PPSheading.Text = "Total Pre Order Receipt  for " & DivisionID & " / " & DisciplineID & "In Transmittal_Issued State"
      ShowDIDMSPREData(Det, DivisionID, DisciplineID, YearID, MonthID)
    End If

    If (Det = "All_IDMSPre_Superceded") Then
      PPSheading.Text = "Total Pre Order Receipt  for " & DivisionID & " / " & DisciplineID & "In Superceded State"
      ShowDIDMSPREData(Det, DivisionID, DisciplineID, YearID, MonthID)
    End If

    If (Det = "All_IDMSPre_Closed") Then
      PPSheading.Text = "Total Pre Order Receipt  for " & DivisionID & " / " & DisciplineID & "In Closed State"
      ShowDIDMSPREData(Det, DivisionID, DisciplineID, YearID, MonthID)
    End If

    If (Det = "IDMSPost_Total_Count") Then
      PPSheading.Text = "Total Post Order Receipt  for " & DivisionID & " / " & DisciplineID
      ShowDIDMSPostData(Det, DivisionID, DisciplineID, YearID, MonthID)
    End If
    If (Det = "IDMSPost_Submitted") Then
      PPSheading.Text = "Total Post Order Receipt  for " & DivisionID & " / " & DisciplineID & "In Submitted State"
      ShowDIDMSPostData(Det, DivisionID, DisciplineID, YearID, MonthID)
    End If
    If (Det = "IDMSPost_Document_linked") Then
      PPSheading.Text = "Total Post Order Receipt  for " & DivisionID & " / " & DisciplineID & "In Document linked State"
      ShowDIDMSPostData(Det, DivisionID, DisciplineID, YearID, MonthID)
    End If

    If (Det = "IDMSPost_Under_Evaluation") Then
      PPSheading.Text = "Total Post Order Receipt  for " & DivisionID & " / " & DisciplineID & "In Under Evaluation State"
      ShowDIDMSPostData(Det, DivisionID, DisciplineID, YearID, MonthID)
    End If

    If (Det = "IDMSPost_Comments_Submitted") Then
      PPSheading.Text = "Total Post Order Receipt  for " & DivisionID & " / " & DisciplineID & "In Comments_Submitted State"
      ShowDIDMSPostData(Det, DivisionID, DisciplineID, YearID, MonthID)
    End If

    If (Det = "IDMSPost_Technically_Cleared") Then
      PPSheading.Text = "Total Post Order Receipt  for " & DivisionID & " / " & DisciplineID & "In Technically_Cleared State"
      ShowDIDMSPostData(Det, DivisionID, DisciplineID, YearID, MonthID)
    End If

    If (Det = "IDMSPost_Transmittal_Issued") Then
      PPSheading.Text = "Total Post Order Receipt  for " & DivisionID & " / " & DisciplineID & "In Transmittal_Issued State"
      ShowDIDMSPostData(Det, DivisionID, DisciplineID, YearID, MonthID)
    End If

    If (Det = "IDMSPost_Superceded") Then
      PPSheading.Text = "Total Post Order Receipt  for " & DivisionID & " / " & DisciplineID & "In Superceded State"
      ShowDIDMSPostData(Det, DivisionID, DisciplineID, YearID, MonthID)
    End If

    If (Det = "IDMSPost_Closed") Then
      PPSheading.Text = "Total Post Order Receipt  for " & DivisionID & " / " & DisciplineID & "In Closed State"
      ShowDIDMSPostData(Det, DivisionID, DisciplineID, YearID, MonthID)
    End If


    If (Det = "All_IDMSPost_Total_Count") Then
      PPSheading.Text = "Total Post Order Receipt  for " & DivisionID & " / " & DisciplineID
      ShowDIDMSPostData(Det, DivisionID, DisciplineID, YearID, MonthID)
    End If
    If (Det = "All_IDMSPost_Submitted") Then
      PPSheading.Text = "Total Post Order Receipt  for " & DivisionID & " / " & DisciplineID & "In Submitted State"
      ShowDIDMSPostData(Det, DivisionID, DisciplineID, YearID, MonthID)
    End If
    If (Det = "All_IDMSPost_Document_linked") Then
      PPSheading.Text = "Total Post Order Receipt  for " & DivisionID & " / " & DisciplineID & "In Document linked State"
      ShowDIDMSPostData(Det, DivisionID, DisciplineID, YearID, MonthID)
    End If

    If (Det = "All_IDMSPost_Under_Evaluation") Then
      PPSheading.Text = "Total Post Order Receipt  for " & DivisionID & " / " & DisciplineID & "In Under Evaluation State"
      ShowDIDMSPostData(Det, DivisionID, DisciplineID, YearID, MonthID)
    End If

    If (Det = "All_IDMSPost_Comments_Submitted") Then
      PPSheading.Text = "Total Post Order Receipt  for " & DivisionID & " / " & DisciplineID & "In Comments_Submitted State"
      ShowDIDMSPostData(Det, DivisionID, DisciplineID, YearID, MonthID)
    End If

    If (Det = "All_IDMSPost_Technically_Cleared") Then
      PPSheading.Text = "Total Post Order Receipt  for " & DivisionID & " / " & DisciplineID & "In Technically_Cleared State"
      ShowDIDMSPostData(Det, DivisionID, DisciplineID, YearID, MonthID)
    End If

    If (Det = "All_IDMSPost_Transmittal_Issued") Then
      PPSheading.Text = "Total Post Order Receipt  for " & DivisionID & " / " & DisciplineID & "In Transmittal_Issued State"
      ShowDIDMSPostData(Det, DivisionID, DisciplineID, YearID, MonthID)
    End If

    If (Det = "All_IDMSPost_Superceded") Then
      PPSheading.Text = "Total Post Order Receipt  for " & DivisionID & " / " & DisciplineID & "In Superceded State"
      ShowDIDMSPostData(Det, DivisionID, DisciplineID, YearID, MonthID)
    End If

    If (Det = "All_IDMSPost_Closed") Then
      PPSheading.Text = "Total Post Order Receipt  for " & DivisionID & " / " & DisciplineID & "In Closed State"
      ShowDIDMSPostData(Det, DivisionID, DisciplineID, YearID, MonthID)
    End If



  End Sub
End Class
