<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_DisciplineDBDetails.aspx.vb" Inherits="GF_DisciplineDBDetails" title="Discipline Dashboard-Details" %>
<asp:Content ID="CPHtaApprovalWFTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div class="container-fluid">
<asp:UpdatePanel ID="UPNLtaApprovalWFTypes" runat="server">
  <ContentTemplate>
    <asp:UpdateProgress ID="UPGStaApprovalWFTypes" runat="server" AssociatedUpdatePanelID="UPNLtaApprovalWFTypes" DisplayAfter="10" >
      <ProgressTemplate>
        <span style="color: #ff0031">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <div class="container-fluid text-center">
      <div class="row">

       <%-- <div class="col-sm-1">
          <a class="btn btn-success" href="GF_UserDB.aspx" role="button">Back</a>
        </div>--%>
     <%-- <div class="container text-center">
            <img src="DB.jpg" class="img-rounded" alt="Design DashBoard - Beta Version 1.0.0" width="414" height="98"/> 
             </div>--%>
      
      
      </div>



    </div>



    <div class="col-12 text-center">
          <div class="btn btn-warning btn-outline-dark" role="alert" id="PSC">
            <b>
              <asp:Label ID="PPSheading" runat="server"></asp:Label></b>
          </div>
        </div>
      <div class="row">
        
          <hr style="color:brown;background-color:darkslategrey;width:100%;height:3px">
    
        <div class="col-sm-auto my-0 table-hover text-center">
          <div id="ppnlDetails" runat="server">
          </div>
        </div>
     
  <hr style="color:brown;background-color:darkslategrey;width:100%;height:3px">
      </div>
          
 


      </ContentTemplate>

           <Triggers>
           </Triggers>
      </asp:UpdatePanel>
</div>
</asp:Content>
