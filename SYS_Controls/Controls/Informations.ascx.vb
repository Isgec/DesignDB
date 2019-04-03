Imports System.Collections.Generic
Partial Class Informations
  Inherits System.Web.UI.UserControl
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    If HttpContext.Current.User.Identity.IsAuthenticated Then
      Dim oEmp As SIS.TA.taEmployees = SIS.TA.taEmployees.taEmployeesGetByID(HttpContext.Current.User.Identity.Name)
      If Not oEmp Is Nothing Then
        F_EmployeeName.Text = oEmp.EmployeeName
        F_Department.Text = oEmp.HRM_Departments2_Description
        F_Designation.Text = oEmp.HRM_Designations3_Description
      End If
      Me.Visible = True
      If Not Page.IsPostBack And Not Page.IsCallback Then
        Try
        Catch ex As Exception
          Response.Redirect("~/Expired.aspx")
        End Try
      End If
    End If
  End Sub
End Class
