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

      
      <div class="col-6">
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
        
         <div class="col-5">
      
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
    <div class="row container">

     
         <div class="col-3">
     <div class="container" id="DivStatus" runat="server" visible="false">
        
            Status:<asp:Button ID="btn_documentStatus" CssClass="btn-warning" Text="" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="Document's Status"></asp:Button>
         
       
        </div>
          </div>
        <div class="col-3">
     <div class="container" id="DivWorkflow" runat="server" visible="false">
          
            WorkFlow: <asp:Button ID="btn_documentWorkflow" CssClass="btn-warning" Text="" runat="server"  Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="Document's Workflow"></asp:Button>
         
     
        </div>   
           </div>
        <div class="col-3">

         <div class="container" id="DivDocumenttype" runat="server" visible="false">
         
           Document Type: <asp:Button ID="btn_documentType" Text="" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="Document Type"></asp:Button>
  
         
        </div>
             </div>



            <div class="col-3">

         <div class="container" id="DivDivision" runat="server" visible="false">
         
            Division: <asp:Button ID="btn_documentDivision" Text="" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="Division"></asp:Button>
  
         
        </div>
             </div>

      </div>

     <hr/>
  <div id="di" runat="server" visible="false">
      <a href="#Documentinformation" text-align: center; cursor: pointer" data-toggle="collapse">Document -Informations</a>
  <div id="Documentinformation" class="collapse">
  
    
      <div class="row mt-1">
      
   
        <div class="col-3">
         <div class="container" id="DivResponsible" runat="server" visible="false">
         
            Responsible Department: </b><asp:Button ID="btn_documentResponsible" Text="" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="Document's Responsible Department"></asp:Button>
  
         
        </div>
             </div>
            <div class="col-3">
         <div class="container" id="DivDate" runat="server" visible="false">
         
            Date: <asp:Button ID="btn_documentDate" Text="" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="Document's Date"></asp:Button>
  
         
        </div>
             </div>
           
            <div class="col-6">
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
            <div class="col-4">
         <div class="container" id="DivApprovedBy" runat="server" visible="false">
         
            Approved: <asp:Button ID="btn_documentApprovedBy" Text="" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="Approved By"></asp:Button>
  
         
        </div>
             </div>
               <div class="col-2">
         <div class="container" id="DivSoftwareused" runat="server" visible="false">
         
            Software Used: <asp:Button ID="Btn_Softwareused" Text="" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="Software Used"></asp:Button>
  
         
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
           
            <div class="col-4">
         <div class="container" id="DivMachineName" runat="server" visible="false">
         
            Machine Name: <asp:Button ID="Btn_MachineName" Text="" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="Machine Name"></asp:Button>
  
         
        </div>
             </div>
           
           </div>
    <hr/>
    
              <div class="row" id="DivFilename" runat="server" visible="false" >
                 <div class="col-3">
         <div class="container">
          File Name: 
            </div>
                    </div>
                 <div class="col-9">
        <asp:Button ID="btn_documentfilename" CssClass="btn-success" Text="" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="Document's File Name"></asp:Button>
  
         </div>
        </div>
         
    </div>
    <hr/>
    <div id="ti" runat="server" visible="false">
      <a href="#Transmittalinformation" text-align: center; cursor: pointer" data-toggle="collapse">Transmittal -Informations</a>
  <div id="Transmittalinformation" class="collapse">
  
    
      <div class="row mt-1">
      
   
        <div class="col-3">
         <div class="container" id="DivTransmittalid" runat="server" visible="false">
         
            Transmittal Number: </b><asp:Button ID="btn_transmittalid" Text="" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="Transmittal ID"></asp:Button>
  
         
        </div>
             </div>
            
  
         
    </div>
 
      </div>
      </div>
       <hr/>
    <div id="pi" runat="server" visible="false">
      <a href="#Projectinformation" text-align: center; cursor: pointer" data-toggle="collapse">Project -Informations</a>
  <div id="Projectinformation" class="collapse">
      <div class="row mt-1">
      
      <div class="col-2">
     <div class="container" id="DivProjectID" runat="server" visible="false">
        
           Project ID: <asp:Button ID="btn_ProjectID" Text="" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="Project ID"></asp:Button>
         
       
        </div>
          </div>
      
            <div class="col-2">
         <div class="container" id="DivProjectYear" runat="server" visible="false">
         
            Year: <asp:Button ID="btn_ProjectYear" Text="" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="Year"></asp:Button>
  
         
        </div>
             </div>
           
            <div class="col-2">
         <div class="container" id="DivProjectIWT" runat="server" visible="false">
         
            IWT: <asp:Button ID="btn_ProjectIWT" Text="" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="IWT"></asp:Button>
  
         
        </div>
             </div>
        
           
           </div>
      <hr/>
  
            <div class="row">
      
       <div class="col-auto">
         <div class="container" id="DivProject_Service" runat="server" visible="false">
         
            Service: <asp:Button ID="Btn_Project_Service" Text="" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="Service"></asp:Button>
  
         
        </div>
             </div>
                <div class="col-auto">
     <div class="container" id="DivProjectClient" runat="server" visible="false">
          
           Client: <asp:Button ID="btn_ProjectClient" Text="" runat="server"  Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="Client"></asp:Button>
         
     
        </div>   
           </div>
        <div class="col-auto">
         <div class="container" id="DivProjectConsultant" runat="server" visible="false">
         
            Consultant: <asp:Button ID="btn_ProjectConsultant" Text="" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="Consultant"></asp:Button>
  
         
        </div>
             </div>
 </div>
   
    </div>
     <hr/>
       </div>
   
   <div id="ii" runat="server" visible="false">
        <a href="#Indentinformation" text-align: center; cursor: pointer" data-toggle="collapse">Indent -Informations</a>
  <div id="Indentinformation" class="collapse">
  
    
      <div class="row mt-1">
      
   
        <div class="col-3">
         <div class="container" id="DivIndentNumber" runat="server" visible="false">
         
            Indent Number: </b><asp:Button ID="btn_IndentNumber" Text="" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="Document's indent Number"></asp:Button>
  
         
        </div>
             </div>
            <div class="col-4">
         <div class="container" id="DivindentDate" runat="server" visible="false">
         
            Indent Date: <asp:Button ID="btn_IndentDate" Text="" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="Indent's Date"></asp:Button>
  
         
        </div>
             </div>
           
            <div class="col-5">
           
        <div class="container" id="DivIndentRequester" runat="server" visible="false">
         
          Indent Requsted By: <asp:Button ID="btn_IndentRequester" Text="" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="Indenter"></asp:Button>
  
         </div>
       
             </div>
            
             
           </div>
    </div>
     <hr/>
      </div>
    <div id="poi" runat="server" visible="false">
     <a href="#POinformation" text-align: center; cursor: pointer" data-toggle="collapse">PO -Informations</a>
  <div id="POinformation" class="collapse">
  
    
      <div class="row mt-1">
      
   
        <div class="col-2">
         <div class="container" id="DivPONumber" runat="server" visible="false">
         
            PO Number: </b><asp:Button ID="btn_PONumber" Text="" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="PONumber"></asp:Button>
  
         
        </div>
             </div>
          
           
            <div class="col-8">
 <div class="row">
     <div class="col-4">
         <div class="container" id="DivPODate" runat="server" visible="false">
         
            Date: <asp:Button ID="btn_PODate" Text="" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="PO Date"></asp:Button>
  
         
        </div>
             </div>
            <div class="col-3">
        <div class="container" id="DivPOSupplier" runat="server" visible="false">
         
          Supplier: <asp:Button ID="btn_POSupplier" Text="" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="Supplier"></asp:Button>
   </div>
         </div>
       
            
         <div class="col-5">
           
        <div class="container" id="DivPOSuppliername" runat="server" visible="false">
         
          Name: <asp:Button ID="btn_POSuppliername" Text="" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="Supplier"></asp:Button>
  
         </div>
       </div>
             </div>
        </div>
         <div class="col-2">
           
        <div class="container" id="DivPOBuyer" runat="server" visible="false">
         
          Buyer: <asp:Button ID="btn_POBuyer" Text="" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="Buyer"></asp:Button>
  
         </div>
       
             </div>
            
             
           </div>
    </div>
    
      <%--<div id="potable" runat="server" visible="true">
        <div class="col-auto">
          <div class="col-auto">
            <h6>
              <div class="badge badge-info">
              PO Item Details</h6>
          </div>
          <div class="col-sm-auto" id="POT" runat="server" clientidmode="static">
          </div>
        </div>
        </div>--%>
       <hr/>
   </div>
      <div id="pmdli" runat="server" visible="false">
    <a href="#PMDLinformation" text-align: center; cursor: pointer" data-toggle="collapse">PMDL -Informations</a>
  <div id="PMDLinformation" class="collapse">
  
    
      <div class="row mt-1">
      
   
        <div class="col-3">
         <div class="container" id="DivPMDLProjectType" runat="server" visible="false">
         
            Project Type: </b><asp:Button ID="btn_PMDLProjectType" Text="" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="Project Type"></asp:Button>
  
         
        </div>
             </div>
            <div class="col-3">
         <div class="container" id="DivPMDLProjectId" runat="server" visible="false">
         
            ProjectId: <asp:Button ID="btn_PMDLProjectId" Text="" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="Project Id"></asp:Button>
  
         
        </div>
             </div>
           
            <div class="col-3">
           
        <div class="container" id="DivPMDLUID" runat="server" visible="false">
         
          UID: <asp:Button ID="btn_PMDLUID" Text="" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="UID"></asp:Button>
  
         </div>
       
             </div>
         <div class="col-3">
           
        <div class="container" id="DivPMDLDocumentRevision" runat="server" visible="false">
         
          Revision Number: <asp:Button ID="btnPMDLDocumentRevision" Text="" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="Revision Number"></asp:Button>
  
         </div>
       
             </div>
            
             
           </div>
     <div class="row mt-1">
      
   
        <div class="col-3">
         <div class="container" id="DivPMDLBSFD" runat="server" visible="false">
         
            Project Type: </b><asp:Button ID="btn_" Text="" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="Project Type"></asp:Button>
  
         
        </div>
             </div>
            <div class="col-3">
         <div class="container" id="Div2" runat="server" visible="false">
         
            ProjectId: <asp:Button ID="Button2" Text="" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="Project Id"></asp:Button>
  
         
        </div>
             </div>
           
            <div class="col-3">
           
        <div class="container" id="Div3" runat="server" visible="false">
         
          UID: <asp:Button ID="Button3" Text="" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="UID"></asp:Button>
  
         </div>
       
             </div>
         <div class="col-3">
           
        <div class="container" id="Div4" runat="server" visible="false">
         
          Revision Number: <asp:Button ID="Button4" Text="" runat="server" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip="Revision Number"></asp:Button>
  
         </div>
       
             </div>
            
             
           </div>
    </div>
     <hr/>
</div>
    </div>
   
             </ContentTemplate>
           <Triggers>
           </Triggers>
    </asp:UpdatePanel>
</div>
</div>
</asp:Content>