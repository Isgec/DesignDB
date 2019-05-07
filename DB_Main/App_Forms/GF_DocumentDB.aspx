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
     
      <div class="row  mt-1">

      
      <div class="col-5">
        <asp:UpdatePanel ID="UPNLctPActivity" runat="server">
          <ContentTemplate>
            <div class="form-group">

              <div class="input-group">
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
       
      </div>
  
        
       <%-- DESCRIPTION--%>
        
         <div class="col-6">
      
      </div>
    </div>

        
    <div class="row container">
      
      <div class="col-11">
        <div class="row">

          <div class="col-1" id="DivDescription1" runat="server" visible="false">
           Tittle: 
          </div>

          <div class="col-11" id="DivDescription2" runat="server" visible="false">
            <asp:Button ID="btn_documentname" runat="server"  Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="Document's Description"></asp:Button>

          </div>
        </div>
      </div>

      <div class="col-1">
        <div class="row">
          <div class="col-8" id="DivRevision1" runat="server" visible="false">
            Revision: 
          </div>

          <div class="col-4" id="DivRevision2" runat="server" visible="false">
            <asp:Button ID="btn_documentrev" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="Document's Current Revision"></asp:Button>
          </div>
        </div>
      </div>
      
    </div>
         <hr/>

     <a href="#erplninformation" text-align: center; cursor: pointer" data-toggle="collapse">BAAN ERPLN -Informations</a>
  <div id="erplninformation" class="collapse">
    <div class="row container">
   

  
         
            <div class="col-3">
              <div class="row">
                <div class="col-5" id="DivSubmittedTime1" runat="server" visible="false">

                 Submitted On:
                
                </div>
                <div class="col-7" id="DivSubmittedTime2" runat="server" visible="false">
                  <asp:Button ID="btn_documentSubmittedTime" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="Document Submission Date/Time in ERPLN "></asp:Button>
             
                   </div>

              </div>
            </div>

            <div class="col-2">
              <div class="row">
                <div class="col-6" id="DivEUserName1" runat="server" visible="false">

                  Username: 
                </div>
                <div class="col-6" id="DivEUserName2" runat="server" visible="false">
                  <asp:Button ID="btn_EUserName" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="ERPLN User Name"></asp:Button>

                </div>
              </div>
            </div>


      <div class="col-2">

        <div class="row">
          <div class="col-6" id="DivEReviewedBy1" runat="server" visible="false">
            Reviewer: 
          </div>
          <div class="col-6" id="DivEReviewedBy2" runat="server" visible="false">

            <asp:Button ID="btn_EReviewedBy" Text="" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="ERPLN Reviewed By"></asp:Button>

          </div>
        </div>
      </div>
            <div class="col-2">
               <div class="row">
          <div class="col-6" id="DivEApprovedBy1" runat="server" visible="false">
            Approver: 
          </div>
         <div class="col-6" id="DivEApprovedBy2" runat="server" visible="false">
           <asp:Button ID="Btn_EApprovedBy" Text="" runat="server"  Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="ERPLN- Approved By"></asp:Button>
          </div>
             </div>
            </div>
                  <div class="col-3">
                    <div class="row">
          <div class="col-5" id="DivISGECDataSource1" runat="server" visible="false">
            Data Source:
             </div>

         <div class="col-7" id="DivISGECDataSource2" runat="server" visible="false">
         
            <asp:Button ID="Btn_IsgecDataSource" Text="" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="Document Datasource"></asp:Button>
  
         
        </div>
             </div>
                   
                </div>   
    

           
           </div>

     <hr/>
  </div>

     <a href="#Documentinformation" text-align: center; cursor: pointer" data-toggle="collapse">Document -Informations</a>
  <div id="Documentinformation" class="collapse">
  
    
      <div class="row mt-1">

      
      <div class="col-2">
     <div class="container" id="DivStatus" runat="server" visible="false">
        
            Status:<asp:Button ID="btn_documentStatus" CssClass="btn-warning" Text="" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="Document's Status"></asp:Button>
         
       
        </div>
          </div>
        <div class="col-2">
     <div class="container" id="DivWorkflow" runat="server" visible="false">
          
            WorkFlow: <asp:Button ID="btn_documentWorkflow" Text="" runat="server"  Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="Document's Workflow"></asp:Button>
         
     
        </div>   
           </div>
        <div class="col-2">

         <div class="container" id="DivResponsible" runat="server" visible="false">
         
            Resonsible Department: </b><asp:Button ID="btn_documentResponsible" Text="" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="Document's Responsible Department"></asp:Button>
  
         
        </div>
             </div>
            <div class="col-2">

         <div class="container" id="DivDate" runat="server" visible="false">
         
            Date: <asp:Button ID="btn_documentDate" Text="" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="Document's Date"></asp:Button>
  
         
        </div>
             </div>
           
            <div class="col-4">
           <div class="row">

             <div class="col-4">

        <div class="container" id="Divweight" runat="server" visible="false">
         
           Weight: <asp:Button ID="btn_documentWeight" Text="" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="Document's Weight"></asp:Button>
  
         </div>
       
             </div>
             <div class="col-4">

         <div class="container" id="Divscale" runat="server" visible="false">
         
            Scale: <asp:Button ID="btn_documentScale" Text="" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="Document's Scale"></asp:Button>
  
           </div>
       
             </div>


            <div class="col-4">

          <div class="container" id="Divsize" runat="server" visible="false">
         
            Size: <asp:Button ID="btn_documentSize" Text="" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="Document's Size"></asp:Button>
  
          </div>
       
             </div>
              </div>
              </div>
           </div>

     <hr/>
  

            <div class="row mt-1">

      
      <div class="col-2">
     <div class="container" id="DivElement" runat="server" visible="false">
        
           Element: <asp:Button ID="btn_documentElement" Text="" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="Document's Element"></asp:Button>
   
       
        </div>
          </div>
        <div class="col-2">
     <div class="container" id="DivDrawnBy" runat="server" visible="false">
          
            Drawn: <asp:Button ID="btn_documentDrawnby" Text="" runat="server"  Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="Drawn By"></asp:Button>
         
     
        </div>   
           </div>
        <div class="col-2">

         <div class="container" id="DivCheckedBy" runat="server" visible="false">
         
            Checked: <asp:Button ID="btn_documentCheckedBy" Text="" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="Checked By"></asp:Button>
  
         
        </div>
             </div>
            <div class="col-2">

         <div class="container" id="DivApprovedBy" runat="server" visible="false">
         
            Approved: <asp:Button ID="btn_documentApprovedBy" Text="" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="Approved By"></asp:Button>
  
         
        </div>
             </div>
            <div class="col-2">

         <div class="container" id="DivDocumenttype" runat="server" visible="false">
         
           Document Type: <asp:Button ID="btn_documentType" Text="" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="Document Type"></asp:Button>
  
         
        </div>
             </div>



            <div class="col-2">

         <div class="container" id="DivDivision" runat="server" visible="false">
         
            Division: <asp:Button ID="btn_documentDivision" Text="" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="Division"></asp:Button>
  
         
        </div>
             </div>


           
           </div>

     <hr/>
             


                <div class="row mt-1">

      
      <div class="col-2">
     <div class="container" id="DivErection" runat="server" visible="false">
        
           For Erection: <asp:Button ID="Btn_Erection" Text="" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="For Erection"></asp:Button>
         
       
        </div>
          </div>
        <div class="col-2">
     <div class="container" id="Divinformation" runat="server" visible="false">
          
           For Infomation: <asp:Button ID="Btn_Information" Text="" runat="server"  Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="For Information"></asp:Button>
         
     
        </div>   
           </div>
        <div class="col-2">

         <div class="container" id="DivProduction" runat="server" visible="false">
         
            For Production: <asp:Button ID="Btn_Production" Text="" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="For Production"></asp:Button>
  
         
        </div>
             </div>
            <div class="col-2">

         <div class="container" id="DivApproval" runat="server" visible="false">
         
            For Approval: <asp:Button ID="Btn_Approval" Text="" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="For Approval"></asp:Button>
  
         
        </div>
             </div>
            <div class="col-2">

         <div class="container" id="DivSoftwareused" runat="server" visible="false">
         
            Software Used: <asp:Button ID="Btn_Softwareused" Text="" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="Software Used"></asp:Button>
  
         
        </div>
             </div>



            <div class="col-2">

         <div class="container" id="DivMachineName" runat="server" visible="false">
         
            Machine Name: <asp:Button ID="Btn_MachineName" Text="" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="Machine Name"></asp:Button>
  
         
        </div>
             </div>


           
           </div>
    <hr/>
    
              <div class="row">
                 <div class="col-3">
         <div class="container" id="DivFilename" runat="server" visible="false">
          File Name: 
            </div>
                    </div>

                 <div class="col-9">
        <asp:Button ID="btn_documentfilename" CssClass="btn-success" Text="" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="Document's File Name"></asp:Button>
  
         </div>
        </div>
          <hr/>
    </div>
     <a href="#BOMinformation" text-align: center; cursor: pointer" data-toggle="collapse">BOM -Informations</a>
  <div id="BOMinformation" class="collapse">




    <hr/>
    </div>
             </ContentTemplate>
           <Triggers>
           </Triggers>
    </asp:UpdatePanel>

</div>
</div>
</asp:Content>
