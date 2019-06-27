<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_UserDetails.aspx.vb" Inherits="GF_UserDetails" title="User Details" %>
<asp:Content ID="CPHtaApprovalWFTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div class="container-fluid">
  <div class="caption">
    <asp:Label ID="LabeltaApprovalWFTypes" runat="server" Text="&nbsp;USER Details "></asp:Label>
</div>
<asp:UpdatePanel ID="UPNLtaApprovalWFTypes" runat="server">
  <ContentTemplate>
    <asp:UpdateProgress ID="UPGStaApprovalWFTypes" runat="server" AssociatedUpdatePanelID="UPNLtaApprovalWFTypes" DisplayAfter="100">
      <ProgressTemplate>

        <span style="color: #ff0031">Loading...</span>
      </ProgressTemplate>

    </asp:UpdateProgress>
  
    <div class="col-2">
      
        <div class="mb-1 mt-1">
            <a class="btn btn-success" href="GF_UserDB.aspx"  role="button"><i class="fa fa-dashboard" style="font-size:20px"></i><%--<i class="fa fa-cog fa-spin"></i>--%></a>
        </div>
    
     
      
          <a href="#" class="btn btn-sm btn-success mt-4 btn-block" role="alert"><i class="fa fa-street-view" style="font-size:20px"> Employee : </i></span>
                  <asp:Button ID="Luser" Text="Luser" runat="server"></asp:Button>
          </a>
     
      </div>



      <h5><b><u> ERPLN ROLES/ACCESS </u></b></h5>
     <hr style="color:brown;background-color:darkslategrey;width:100%;height:3px">
     
  <%--<div class="jumbotron">
    <h2>BAAN - ERPLM Access</h2> 
   
 
 
</div>--%>
      
   
    <div class="row">
      <div class="col-6">
        <h6>
          <div class="badge badge-info">
          PLM</h6>
        <div class="row">
          <div class="col-10" id="plm" runat="server" clientidmode="static">
          </div>
        </div>
      </div>

      <div class="col-6">
        <h6>
          <div class="badge badge-info">
          DCR</h6>
        <div class="row">
          <div class="col-10" id="Dcr" runat="server" clientidmode="static">
          </div>
        </div>
      </div>
    </div>
    <hr style="color:brown;background-color:darkslategrey;width:100%;height:3px">
      
    <div class="row">
      <div class="col-6">
        <h6>
          <div class="badge badge-info">
          IDMS</h6>
        <div class="row">
          <div class="col-10" id="idms" runat="server" clientidmode="static">
          </div>
        </div>
      </div>
      <div class="col-6">
                  <h6>
            <div class="badge badge-info">
            IDMS APPROVER</h6>
       
      <div class="row">
          <div class="col-sm-auto" id="trans" runat="server" clientidmode="static">
        </div>
        </div>
      </div> </div>
     
   
    <hr style="color:brown;background-color:darkslategrey;width:100%;height:3px">
 
             </ContentTemplate>
           <Triggers>
           </Triggers>
    </asp:UpdatePanel>

   </div>


</asp:Content>
