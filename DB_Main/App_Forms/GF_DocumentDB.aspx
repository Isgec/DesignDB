<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_DocumentDB.aspx.vb" Inherits="GF_DocumentDB" title="Document Dashboard" %>
<asp:Content ID="CPHtaApprovalWFTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div class="container-fluid">
<div class="caption">
    <asp:Label ID="LabeltaApprovalWFTypes" runat="server" Text="&nbsp;DOCUMENT DASHBOARD"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtaApprovalWFTypes" runat="server">
  <ContentTemplate>
    <asp:UpdateProgress ID="UPGStaApprovalWFTypes" runat="server" AssociatedUpdatePanelID="UPNLtaApprovalWFTypes" DisplayAfter="100" >
      <ProgressTemplate>
        <span style="color: #ff0031">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
     <%-- <div class="container text-center">
            <img src="DB.jpg" class="img-rounded" alt="Design DashBoard - Beta Version 1.0.0" width="414" height="98"/> 
             </div>--%>
     
      <div class="row  mt-2">

      
      <div class="col-5">
        <asp:UpdatePanel ID="UPNLctPActivity" runat="server">
          <ContentTemplate>
            <div class="form-group">

              <div class="input-group mb-3">
               <%-- <span class=" btn btn-sm btn-dark" style="width: 78px; text-align: center; cursor: pointer" title="Enter Project ID:" onclick="openNav()"><b>Project:</b></span>--%>

                <a href="#doci" class="btn btn-light btn-outline-dark" style="width: 140px; text-align: center; cursor: pointer" data-toggle="collapse"><b>Document ID</b></a>
  <div id="doci" class="collapse">
    Enter Document ID & Click to 'SHOW' button. This will allow system to Search and Show all available information in BAAN ERPLN.
    Click again 'Document ID' button To Hide this Information.
  </div>

                <asp:TextBox
                  ID="F_t_docn"
                  CssClass="form-control"
                  ClientIDMode="static"
                  runat="Server">
                </asp:TextBox>
               
                <asp:Button ID="cmdSubmit" runat="server" CssClass="btn btn-warning ml-1" Text="SHOW" ToolTip="Click to Search Document " Font-Bold="true" Font-Names="Comic Sans MS" />
            
              </div>
            </div>
            <%-- <br />
           <asp:button ID="pd" runat="server" CssClass="btn btn-warning btn-lg" ToolTip="pd" Text="pd" Font-Bold="true"></asp:button>--%>
          </ContentTemplate>
          <Triggers>
            <asp:PostBackTrigger ControlID="cmdSubmit" />
          </Triggers>
        </asp:UpdatePanel>
      </div>

      <%--  REVISION--%>
     <div class="col-1">
        <div class="container mr-4" id="DRevDetails" runat="server" visible="false">
          <div class="container  text-center my-0">
            <asp:Button ID="btn_documentrev" Text="" runat="server" CssClass="btn-warning btn-sm" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="Document's Current Revision"></asp:Button>
         
          </div>
        </div>
      </div>
  
        
       <%-- DESCRIPTION--%>
        
         <div class="col-5">
        <div class="container mt-0" id="DDetails" runat="server" visible="false">
          <div class="container  text-center my-0">
            <asp:Button ID="btn_documentfilename" Text="" runat="server" CssClass="btn-warning btn-sm" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="Document's Description"></asp:Button>
  
          </div>
        </div>
      </div>
    </div>

     <div class="container mr-4" id="DFDetails" runat="server" visible="false">
          <div class="container  text-center my-0">
            <asp:Button ID="btn_documentname" Text="" runat="server" CssClass="btn-warning btn-sm" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="Document's File Name"></asp:Button>
         
          </div>
        </div>

   
             </ContentTemplate>
           <Triggers>
           </Triggers>
    </asp:UpdatePanel>

</div>
</div>
</asp:Content>
