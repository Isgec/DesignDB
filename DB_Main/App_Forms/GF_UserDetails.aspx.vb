Partial Class GF_UserDetails
  Inherits System.Web.UI.Page



  Private Sub GF_UserDetails_Load(sender As Object, e As EventArgs) Handles Me.Load
    Dim x As SIS.DB.dbUserDB = SIS.DB.dbUserDB.GetUserDB

    Luser.Text = x.L_Usercode

  End Sub




  Private Sub GF_UserDetails_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
    Dim PLMstr As String = ""


    PLMstr &= "<div class='row'>"
    PLMstr &= "<div class='col-4'>"

    PLMstr &= "<b>Division</b>"
    PLMstr &= "</div>"
    PLMstr &= "<div class='col-4'>"
    PLMstr &= "<b>Group</b>"
    PLMstr &= "</div>"
    PLMstr &= "<div class='col-4'>"
    PLMstr &= "<b>Role</b>"
    PLMstr &= "</div>"
    PLMstr &= "</div>"

    Dim tmp As List(Of SIS.DB.UserRolePLM) = SIS.DB.UserRolePLM.GetUserRolePLM("")
    For Each ptm As SIS.DB.UserRolePLM In tmp

      PLMstr &= "<table style = 'width:100%' border='1'>"
      PLMstr &= "<tr><td><div class='row'>"
      PLMstr &= "<div class='col-xs-4 mr-1 ml-2 mb-1'>"

      PLMstr &= "<div class='btn-sm btn-dark btn-block'& 'role=" & "'alert'>"

      PLMstr &= ptm.PLMEmployeeDivision
      PLMstr &= "</div>"
      PLMstr &= "</div></td>"
      PLMstr &= "<td><div class='col-xs-4 mb-1'>"
      PLMstr &= "<div class='btn-sm btn-dark'& 'role=" & "'alert'>"
      PLMstr &= ptm.PLMEmployeeGroup
      PLMstr &= "</div>"
      PLMstr &= "</div></td>"
      PLMstr &= "<td><div class='col-xs-4  mr-1 ml-1 mb-1'>"
      PLMstr &= "<div class='btn-sm btn-dark'& 'role=" & "'alert'>"
      PLMstr &= ptm.PLMEmployeeRole
      PLMstr &= "</div>"
      PLMstr &= "</div>"
      PLMstr &= "</div></td></tr></table>"

    Next
    plm.InnerHtml = PLMstr
  End Sub

  Private Sub GF_UserDetailsDCR_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
    Dim DCRstr As String = ""
    DCRstr &= "<div class='row'>"
    DCRstr &= "<div class='col-4'>"

    DCRstr &= "<b>Division</b>"
    DCRstr &= "</div>"
    DCRstr &= "<div class='col-4'>"
    DCRstr &= "<b>Group</b>"
    DCRstr &= "</div>"
    DCRstr &= "<div class='col-4'>"
    DCRstr &= "<b>Role</b>"
    DCRstr &= "</div>"
    DCRstr &= "</div>"

    Dim tmp As List(Of SIS.DB.UserRoleDCR) = SIS.DB.UserRoleDCR.GetUserRoleDCR("")
    For Each dtm As SIS.DB.UserRoleDCR In tmp
      DCRstr &= "<table style = 'width:100%' border='1'>"
      DCRstr &= "<tr><td><div class='row'>"
      DCRstr &= "<div class='col-xs-4 mr-1 ml-2 mb-1'>"

      DCRstr &= "<div class='btn-sm btn-dark'& 'role=" & "'alert'>"

      DCRstr &= dtm.DCREmployeeDivision
      DCRstr &= "</div>"
      DCRstr &= "</div></td>"
      DCRstr &= "<td><div class='col-xs-4 mb-1'>"
      DCRstr &= "<div class='btn-sm btn-dark'& 'role=" & "'alert'>"
      DCRstr &= dtm.DCREmployeeGroup
      DCRstr &= "</div>"
      DCRstr &= "</div></td>"
      DCRstr &= "<td><div class='col-xs-4  mr-1 ml-1 mb-1'>"
      DCRstr &= "<div class='btn-sm btn-dark'& 'role=" & "'alert'>"
      DCRstr &= dtm.DCREmployeeRole
      DCRstr &= "</div>"
      DCRstr &= "</div>"
      DCRstr &= "</div></td></tr></table>"

    Next
    Dcr.InnerHtml = DCRstr
  End Sub


  Private Sub GF_UserDetailstrans_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
    Dim TRANSstr As String = ""
    TRANSstr &= "<div class='row'>"
    TRANSstr &= "<div class='col-sm-4'>"
    TRANSstr &= "<b>Division</b>"
    TRANSstr &= "</div>"
    TRANSstr &= "<div class='col-sm-4'>"
    TRANSstr &= "<b>Project</b>"
    TRANSstr &= "</div>"
    TRANSstr &= "<div class='col-sm-4'>"
    TRANSstr &= "<b>Type</b>"
    TRANSstr &= "</div>"
    TRANSstr &= "</div>"


    Dim tmp As List(Of SIS.DB.UserRoleTRANS) = SIS.DB.UserRoleTRANS.GetUserRoleTRANS("")
    For Each dtm As SIS.DB.UserRoleTRANS In tmp
      TRANSstr &= "<table style = 'width:100%' border='1'>"
      TRANSstr &= "<tr><td><div class='row'>"
      TRANSstr &= "<div class='col-xs-4 mr-1 ml-2 mb-1'>"
      TRANSstr &= "<div class='btn-sm btn-light'& 'role=" & "'alert'>"
      TRANSstr &= "<b>" & dtm.TRANSEDivision & "</b>"
      TRANSstr &= "</div>"
      TRANSstr &= "</div></td>"
      TRANSstr &= "<td><div class='col-xs-4 mb-1'>"
      TRANSstr &= "<div class='btn-sm btn-dark'& 'role=" & "'alert'>"
      TRANSstr &= "<b>" & dtm.TRANSProject & "</b>"
      TRANSstr &= "</div>"
      TRANSstr &= "</div></td>"

      TRANSstr &= "<td><div class='col-xs-4  mr-1 ml-1 mb-1'>"
      TRANSstr &= "<div class='btn-sm btn-dark'& 'role=" & "'alert'>"
      TRANSstr &= "<b>" & dtm.TransmittalType & "</b>"
      TRANSstr &= "</div>"
      TRANSstr &= "</div>"

      TRANSstr &= "</div></td></tr></table>"

    Next
    trans.InnerHtml = TRANSstr
  End Sub


  Private Sub GF_UserDetailsIDMS_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
    Dim IDMSstr As String = ""
    IDMSstr &= "<div class='row'>"
    IDMSstr &= "<div class='col-sm-4'>"
    IDMSstr &= "<b>Division<b>"
    IDMSstr &= "</div>"
    IDMSstr &= "<div class='col-sm-6 ml-2'>"
    IDMSstr &= "Department"
    IDMSstr &= "</div>"

    IDMSstr &= "</div>"

    Dim tmp As List(Of SIS.DB.UserRoleIDMS) = SIS.DB.UserRoleIDMS.GetUserRoleIDMS("")
    For Each dtm As SIS.DB.UserRoleIDMS In tmp
      IDMSstr &= "<div class='row'>"
      IDMSstr &= "<div class='col-xs-4 mr-1 ml-2 mb-1'>"
      IDMSstr &= "<div class='btn-sm btn-dark'& 'role=" & "'alert'>"
      IDMSstr &= "<b>" & dtm.EDivision & "</b>"
      IDMSstr &= "</div>"
      IDMSstr &= "</div>"
      IDMSstr &= "<div class='col-xs-4'>"
      IDMSstr &= "<div class='btn-sm btn-dark'& 'role=" & "'alert'>"
      IDMSstr &= "<b>" & dtm.EDepartment & "</b>"
      IDMSstr &= "</div>"
      IDMSstr &= "</div>"

      IDMSstr &= "</div>"

    Next
    idms.InnerHtml = IDMSstr
  End Sub


End Class
