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
    <div class="container" style="margin-top: 10px">
      
    <div class="row">
        <div class="col-2 mb-2">
            <a class="btn btn-success" href="GF_UserDB.aspx"  role="button"><i class="fa fa-dashboard" style="font-size:20px">My DashBoard</i><i class="fa fa-cog fa-spin"></i></a>
        </div>
      <div class="col-2">
         
     </div>
        <div class="col-7">
          <a href="#" class="btn btn-sm btn-success" role="alert"><i class="fa fa-street-view" style="font-size:20px"> Employee: </i></span>
                  <asp:Button ID="Luser" Text="Luser" runat="server"></asp:Button>
          </a>
        </div>
      </div>
      <h5><b><u> ERPLN ROLES/ACCESS </u></b></h5>
     <hr />
     
  <%--<div class="jumbotron">
    <h2>BAAN - ERPLM Access</h2> 
   
 
 
</div>--%>
      

      <div class="row">
        <div class="col-6">
          <h6>
            <div class="badge badge-info">
            PLM</h6>
          <div class="row">
            <div class="col-sm-auto" id="plm" runat="server" clientidmode="static">
            </div>
          </div>
        </div>
       
         <div class="col-auto">
          <div class="col-auto">
            <h6>
              <div class="badge badge-info">
              DCR</h6>
          </div>

          <div class="col-sm-auto" id="Dcr" runat="server" clientidmode="static">
          </div>

        </div>

      </div>
      <hr />
      
   

    <div class="row">
      <div class="col-6">
        <h6>
          <div class="badge badge-info">
          IDMS</h6>
        <div class="row">
          <div class="col-sm-auto" id="idms" runat="server" clientidmode="static">
          </div>
        </div>
      </div>
      <div class="col-auto">
        <div class="col-auto">
          <h6>
            <div class="badge badge-info">
            IDMS APPROVER</h6>
        </div>
          <div class="col-sm-auto" id="trans" runat="server" clientidmode="static">
        
        </div>
      </div>
     
    </div>
   <hr />
      </div>
 
             </ContentTemplate>
           <Triggers>
           </Triggers>
    </asp:UpdatePanel>

   </div>


</asp:Content>
