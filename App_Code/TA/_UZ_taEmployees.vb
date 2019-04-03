Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TA
  Partial Public Class taEmployees
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Blue
      Return mRet
    End Function
    Public Function GetVisible() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetEnable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetEditable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public ReadOnly Property Editable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Deleteable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        'CType(.FindControl("F_CardNo"), TextBox).Text = ""
        'CType(.FindControl("F_EmployeeName"), TextBox).Text = ""
        'CType(.FindControl("F_C_CompanyID"), TextBox).Text = ""
        'CType(.FindControl("F_C_CompanyID_Display"), Label).Text = ""
        'CType(.FindControl("F_C_DivisionID"), TextBox).Text = ""
        'CType(.FindControl("F_C_DivisionID_Display"), Label).Text = ""
        'CType(.FindControl("F_C_DepartmentID"), TextBox).Text = ""
        'CType(.FindControl("F_C_DepartmentID_Display"), Label).Text = ""
        'CType(.FindControl("F_C_DesignationID"), TextBox).Text = ""
        'CType(.FindControl("F_C_DesignationID_Display"), Label).Text = ""
        'CType(.FindControl("F_C_OfficeID"), TextBox).Text = ""
        'CType(.FindControl("F_C_OfficeID_Display"), Label).Text = ""
        'CType(.FindControl("F_CategoryID"), TextBox).Text = ""
        'CType(.FindControl("F_CategoryID_Display"), Label).Text = ""
        'CType(.FindControl("F_EMailID"), TextBox).Text = ""
        'CType(.FindControl("F_Contractual"), CheckBox).Checked = False
        'CType(.FindControl("F_NonTechnical"), CheckBox).Checked = False
        'CType(.FindControl("F_VerificationRequired"), CheckBox).Checked = False
        'CType(.FindControl("F_VerifierID"), TextBox).Text = ""
        'CType(.FindControl("F_VerifierID_Display"), Label).Text = ""
        'CType(.FindControl("F_ApprovalRequired"), CheckBox).Checked = False
        'CType(.FindControl("F_ApproverID"), TextBox).Text = ""
        'CType(.FindControl("F_ApproverID_Display"), Label).Text = ""
      End With
      Return sender
    End Function
  End Class
End Namespace
