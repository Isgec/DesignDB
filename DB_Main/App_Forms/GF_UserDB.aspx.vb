Partial Class GF_UserDB
  Inherits System.Web.UI.Page


  Private Sub cpd_Click(sender As Object, e As EventArgs) Handles cpd.Click
    Response.Redirect("GF_UserDBDetails.aspx?detail=cpd&EmpID=" & HttpContext.Current.Session("LoginID"))
  End Sub
  Private Sub cpr_Click(sender As Object, e As EventArgs) Handles cpr.Click
    Response.Redirect("GF_UserDBDetails.aspx?detail=cpr&EmpID=" & HttpContext.Current.Session("LoginID"))
  End Sub

  Private Sub cpa_Click(sender As Object, e As EventArgs) Handles cpa.Click
    Response.Redirect("GF_UserDBDetails.aspx?detail=cpa&EmpID=" & HttpContext.Current.Session("LoginID"))
  End Sub

  'Private Sub cipre_Click(sender As Object, e As EventArgs) Handles cipre.Click
  '  Response.Redirect("GF_UserDBDetails.aspx?detail=cipre&EmpID=" & HttpContext.Current.Session("LoginID"))
  'End Sub

  Private Sub GF_UserDB_Load(sender As Object, e As EventArgs) Handles Me.Load
    Dim x As SIS.DB.dbUserDB = SIS.DB.dbUserDB.GetUserDB
    cpr.Text = x.P_Review
    'If x.P_Review = 0 Then
    '  cpr.Text = "Nothing Pending with Your Login"
    'End If

    cpa.Text = x.P_Approve
    'If x.P_Approve = 0 Then
    '  cpr.Text = "Nothing Pending with Your Login"
    'End If
    cpd.Text = x.P_Designer
    'If x.P_Designer = 0 Then
    '  cpr.Text = "Nothing Pending with Your Login"
    'End If
    cta.Text = x.T_UApproval
    'If x.T_UApproval = 0 Then
    '  cpr.Text = "Nothing Pending with Your Login"
    'End If
    cti.Text = x.T_UIssue
    'If x.T_UIssue = 0 Then
    '  cpr.Text = "Nothing Pending with Your Login"
    'End If
    cda.Text = x.D_Approval
    cdac.Text = x.D_AppCrtd
    csr.Text = x.S_Review
    csa.Text = x.S_Approval
    cipre.Text = x.I_PreUEvaluation
    cipoe.Text = x.I_PostUEvaluation
    cmh.Text = x.M_EntryForToday
    Luser.Text = x.L_Usercode
    LuserG.Text = x.L_UserGroup


  End Sub


  Private Sub cipre_Click(sender As Object, e As EventArgs) Handles cipre.Click
    Response.Redirect("GF_UserDBDetails.aspx?detail=cipre&EmpID=" & HttpContext.Current.Session("LoginID"))
  End Sub

  Private Sub cipoe_Click(sender As Object, e As EventArgs) Handles cipoe.Click
    Response.Redirect("GF_UserDBDetails.aspx?detail=cipoe&EmpID=" & HttpContext.Current.Session("LoginID"))
  End Sub

  Private Sub cta_Click(sender As Object, e As EventArgs) Handles cta.Click
    Response.Redirect("GF_UserDBDetails.aspx?detail=cta&EmpID=" & HttpContext.Current.Session("LoginID"))
  End Sub



  Private Sub Luser_Click(sender As Object, e As EventArgs) Handles Luser.Click
    Response.Redirect("GF_UserDetails.aspx?detail=cta&EmpID=" & HttpContext.Current.Session("LoginID"))
  End Sub

  Private Sub cti_Click(sender As Object, e As EventArgs) Handles cti.Click
    Response.Redirect("GF_UserDBDetails.aspx?detail=cti&EmpID=" & HttpContext.Current.Session("LoginID"))
  End Sub

  Private Sub cda_Click(sender As Object, e As EventArgs) Handles cda.Click
    Response.Redirect("GF_UserDBDetails.aspx?detail=cda&EmpID=" & HttpContext.Current.Session("LoginID"))
  End Sub

  Private Sub cdac_Click(sender As Object, e As EventArgs) Handles cdac.Click
    Response.Redirect("GF_UserDBDetails.aspx?detail=cdac&EmpID=" & HttpContext.Current.Session("LoginID"))
  End Sub

  Private Sub csr_Click(sender As Object, e As EventArgs) Handles csr.Click
    Response.Redirect("GF_UserDBDetails.aspx?detail=csr&EmpID=" & HttpContext.Current.Session("LoginID"))
  End Sub

  Private Sub csa_Click(sender As Object, e As EventArgs) Handles csa.Click
    Response.Redirect("GF_UserDBDetails.aspx?detail=csa&EmpID=" & HttpContext.Current.Session("LoginID"))
  End Sub

  Private Sub cmh_Click(sender As Object, e As EventArgs) Handles cmh.Click
    Response.Redirect("GF_UserDBDetails.aspx?detail=cmh&EmpID=" & HttpContext.Current.Session("LoginID"))
  End Sub
End Class
