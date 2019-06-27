<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_UserDBDetails.aspx.vb" Inherits="GF_UserDBDetails" title="User Dashboard-Details" %>
<asp:Content ID="CPHtaApprovalWFTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div class="container-fluid">
  <div class="caption">
    <asp:Label ID="LabeltaApprovalWFTypes" runat="server" Text="&nbsp;User Dashboard-Details"></asp:Label>
</div>

<asp:UpdatePanel ID="UPNLtaApprovalWFTypes" runat="server">
  <ContentTemplate>
    <asp:UpdateProgress ID="UPGStaApprovalWFTypes" runat="server" AssociatedUpdatePanelID="UPNLtaApprovalWFTypes" DisplayAfter="100" >
      <ProgressTemplate>
        <span style="color: #ff0031">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
   
    
    
        
    <div class="col-2">
      
        <div class="mb-1 mt-1">
           <a class="btn btn-success" href="GF_UserDB.aspx"  role="button"><i class="fa fa-dashboard" style="font-size:20px"> </i><%--<i class="fa fa-spinner fa-pulse"></i>--%></a>
        </div>
       
     
      <%-- <div class="container text-center">
            <img src="DB.jpg" class="img-rounded" alt="Design DashBoard - Beta Version 1.0.0" width="414" height="98"/> 
             </div>--%>
    </div>
    
     <div class="col-12">
          <div class="alert alert-dark btn-light" role="alert" id="PSC">
            <b>
              <asp:Label ID="PSheading" runat="server"></asp:Label></b>
          </div>
        </div>

    <hr style="color:brown;background-color:darkslategrey;width:100%;height:3px">
    
        <div class="col-sm-auto my-0 table-hover">
          <div id="pnlDetails" runat="server">
          </div>
        </div>
     
  <hr style="color:brown;background-color:darkslategrey;width:100%;height:3px">

      </ContentTemplate>

           <Triggers>
           </Triggers>
      </asp:UpdatePanel>
</div>
</asp:Content>
