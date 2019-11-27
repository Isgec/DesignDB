Partial Class GF_Discipline

  Inherits System.Web.UI.Page

  Public Property DivisionID As String
    Get
      If ViewState("DivisionID") IsNot Nothing Then
        Return ViewState("DivisionID")
      End If
      Return ""
    End Get
    Set(value As String)

      ViewState.Add("DivisionID", value)
    End Set
  End Property

  Public Property DisciplineID As String
    Get
      If ViewState("DisciplineID") IsNot Nothing Then
        Return ViewState("DisciplineID")
      End If
      Return ""
    End Get
    Set(value As String)

      ViewState.Add("DisciplineID", value)
    End Set
  End Property

  Public Property YearID As String
    Get
      If ViewState("YearID") IsNot Nothing Then
        Return ViewState("YearID")
      End If
      Return ""
    End Get
    Set(value As String)

      ViewState.Add("YearID", value)
    End Set
  End Property

  Public Property MonthID As String
    Get
      If ViewState("MonthID") IsNot Nothing Then
        Return ViewState("MonthID")
      End If
      Return ""
    End Get
    Set(value As String)

      ViewState.Add("MonthID", value)
    End Set
  End Property

  Private Sub GF_Discipline_Load(sender As Object, e As EventArgs) Handles Me.Load

    MonthID = Month(Now)
    DivisionID = Convert.ToString(F_DivisionID.SelectedItem.Text)
    DisciplineID = Convert.ToString(F_DisciplineID.SelectedItem.Text)

    F_DivisionID.Text = DivisionID
    F_DisciplineID.Text = DisciplineID


    Select Case MonthID

      Case "1"
        F_MonthID.SelectedIndex = 0
      Case "2"
        F_MonthID.SelectedIndex = 1
      Case "3"
        F_MonthID.SelectedIndex = 2
      Case "4"
        F_MonthID.SelectedIndex = 3
      Case "5"
        F_MonthID.SelectedIndex = 4
      Case "6"
        F_MonthID.SelectedIndex = 5
      Case "7"
        F_MonthID.SelectedIndex = 6
      Case "8"
        F_MonthID.SelectedIndex = 7
      Case "9"
        F_MonthID.SelectedIndex = 8
      Case "10"
        F_MonthID.SelectedIndex = 9
      Case "11"
        F_MonthID.SelectedIndex = 10
      Case "12"
        F_MonthID.SelectedIndex = 11



    End Select



    Select Case DisciplineID

      Case "PROCESS"
        DisciplineID = "PRC"
      Case "MECHANICAL"
        DisciplineID = "MEC"
      Case "STRUCTURE"
        DisciplineID = "STR"
      Case "PIPING"
        DisciplineID = "PIP"
      Case "ELECTRICAL"
        DisciplineID = "ELE"
      Case "INSTRUMENTATION"
        DisciplineID = "C&I"
      Case "CIVIL"
        DisciplineID = "CVL"
      Case "MATERIAL HANDLING"
        DisciplineID = "MHE"
      Case "PROJECT"
        DisciplineID = "PRJ"
      Case "WWS"
        DisciplineID = "WWS"

    End Select

    Btn_Discipline.Text = DivisionID + "-" + DisciplineID

    '  pd.Text = y.ProjectDesc


    If DivisionID = "" Then Exit Sub
    If DisciplineID = "" Then Exit Sub
  End Sub

  Private Sub cmdSubmit_Click(sender As Object, e As EventArgs) Handles cmdSubmit.Click
    F_MonthID.SelectedValue = MonthID

    DPMDLTABLE.Visible = True
    Btn_Discipline.Text = DivisionID + "-" + DisciplineID
    MonthID = F_MonthID.SelectedValue
    'PMDL

    Dim Dt As SIS.DD.DBDiscipline = SIS.DD.DBDiscipline.GetDPMDLDB(DivisionID, DisciplineID)

    btn_Discipline_Total_Count.Text = Dt.Discipline_Total_Count
    btn_Discipline_Release_Count.Text = Dt.Discipline_Release_Count
    btn_Discipline_Pending_Count.Text = Dt.Discipline_Pending_Count
    btn_Discipline_Due_Count.Text = Dt.Discipline_DueForToday_Count
    btn_Discipline_DueTillToday_Count.Text = Dt.Discipline_DueTillToday_Count
    btn_Discipline_Ontime_Count.Text = Dt.Discipline_OnTime_Count
    btn_Discipline_Delayed_Count.Text = Dt.Discipline_Delayed_Count

  End Sub

  'Private Sub btn_Discipline_Total_Count_Click(sender As Object, e As EventArgs) Handles btn_Discipline_Total_Count.Click
  '  Response.Redirect("GF_DisciplineDBDetails.aspx?detail=BOILER&DisciplineID=" & F_DisciplineID.Text)
  'End Sub


End Class








