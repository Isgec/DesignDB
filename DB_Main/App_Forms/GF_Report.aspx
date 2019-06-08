<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_Report.aspx.vb" Inherits="GF_Report" title="Reports" %>
<asp:Content ID="CPHtaApprovalWFTypes" ContentPlaceHolderID="cph1" Runat="Server">
 
  

  

<div class="container-fluid">
<div class="caption">
    <asp:Label ID="LabeltaApprovalWFTypes" runat="server" Text="&nbsp;REPORT DASHBOARD"></asp:Label>
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
     
      <div class="row  mt-3">
       
      <div class="col-3">
     
            <div class="form-group">

              <div class="input-group">
               <%-- <span class=" btn btn-sm btn-dark" style="width: 78px; text-align: center; cursor: pointer" title="Enter Project ID:" onclick="openNav()"><b>Project:</b></span>--%>

                <a href="#divi" class="btn btn-warning btn-outline-dark" style="width: 140px; text-align: center; cursor: pointer" data-toggle="collapse"><b>Division</b></a>
  <div id="divi" class="collapse">
    Select Division for which Information need to fetched for Dashboard.
    Click again 'Division' button To Hide this Information.
  </div>
                 <asp:dropdownlist ID="F_t_docn" CssClass="form-control" ClientIDMode="static" runat="Server" >
                  <asp:ListItem Value="">ALL</asp:ListItem>  
                  <asp:ListItem>BOILER</asp:ListItem>  
                  <asp:ListItem>SMD</asp:ListItem>  
                  <asp:ListItem>EPC</asp:ListItem>  
                  <asp:ListItem>PC</asp:ListItem>  
                  <asp:ListItem>ASP</asp:ListItem> 

                </asp:dropdownlist>
                 </div>
            </div>
             </div> 
         
      <div class="col-3">
      
            <div class="form-group">

              <div class="input-group">
               <%-- <span class=" btn btn-sm btn-dark" style="width: 78px; text-align: center; cursor: pointer" title="Enter Project ID:" onclick="openNav()"><b>Project:</b></span>--%>

                <a href="#dept" class="btn btn-light btn-outline-dark" style="width: 140px; text-align: center; cursor: pointer" data-toggle="collapse"><b>Department</b></a>
  <div id="dept" class="collapse">
   Select Department for which Information need to fetched for Dashboard.
    Click again 'Department' button To Hide this Information.
  </div>
                 <asp:dropdownlist ID="Dropdownlist1" CssClass="form-control" ClientIDMode="static" runat="Server" >
                  <asp:ListItem Value="">ALL</asp:ListItem>  
                  <asp:ListItem>MECHANICAL</asp:ListItem> 
                  <asp:ListItem>PROCESS</asp:ListItem> 
                  <asp:ListItem>STRUCTURE</asp:ListItem>  
                  <asp:ListItem>PIPING</asp:ListItem>  
                  <asp:ListItem>ELECTRICAL</asp:ListItem>  
                  <asp:ListItem>C&I</asp:ListItem> 

                </asp:dropdownlist>
                 </div>
            </div>
             </div>  
       
       
         
      </div> 
       
     <div class="row">

      <div class="col-6">
       
            <div class="form-group">

              <div class="input-group">
               <%-- <span class=" btn btn-sm btn-dark" style="width: 78px; text-align: center; cursor: pointer" title="Enter Project ID:" onclick="openNav()"><b>Project:</b></span>--%>

                <a href="#grop" class="btn btn-light btn-outline-dark" style="width: 140px; text-align: center; cursor: pointer" data-toggle="collapse"><b>Sub Groups</b></a>
  <div id="grop" class="collapse">
    Select Division for which Information need to fetched from ERPLN and displayed on DashBoard & Click to 'SHOW' button.
    
  </div>
                 <asp:dropdownlist ID="Dropdownlist2" CssClass="form-control" ClientIDMode="static" runat="Server" >
                  <asp:ListItem Value="">ALL</asp:ListItem>  
                  <asp:ListItem>BOUGHT OUT</asp:ListItem> 
                  <asp:ListItem>FIRING AND FUEL FEEDING SYSTEM</asp:ListItem> 
                  <asp:ListItem>LAYOUT AND PLANT 3D</asp:ListItem> 
                   <asp:ListItem>NON PRESSURE PARTS & INSULATION</asp:ListItem> 
                    <asp:ListItem>PRESSURE PARTS & REFRACTORY</asp:ListItem> 
                    <asp:ListItem>VESSELS</asp:ListItem> 

                    
                                  </asp:dropdownlist>
                 </div>
            </div>
             </div> 
    
         </div>

       <div class="row">

      <div class="col-6">
       
            <div class="form-group">

              <div class="input-group">
               <%-- <span class=" btn btn-sm btn-dark" style="width: 78px; text-align: center; cursor: pointer" title="Enter Project ID:" onclick="openNav()"><b>Project:</b></span>--%>

                <a href="#Repo" class="btn btn-warning btn-outline-dark" style="width: 140px; text-align: center; cursor: pointer" data-toggle="collapse"><b>Report</b></a>
  <div id="Repo" class="collapse">
    Select Report for which Information need to fetched from ERPLN and displayed on DashBoard.
    Click again 'Division' button To Hide this Information.
  </div>

<asp:dropdownlist ID="Dropdownlist4" CssClass="form-control" ClientIDMode="static" runat="Server" >
                  <asp:ListItem Value="">PENDING SPECIFICATIONS</asp:ListItem>  
                  <asp:ListItem>-</asp:ListItem> 
                  <asp:ListItem>-</asp:ListItem> 
                  <asp:ListItem>-</asp:ListItem>  
                  <asp:ListItem>-</asp:ListItem>  
                  <asp:ListItem>-</asp:ListItem>  
                  <asp:ListItem>-</asp:ListItem> 

                </asp:dropdownlist>

 </div>
               </div>
        <hr>
         </div>
     
          <div class="col-1">
          <asp:Button ID="cmdSubmit" runat="server" CssClass="btn btn-warning ml-1" Text="SHOW" ToolTip="Click to Search Document " Font-Bold="true" Font-Names="Comic Sans MS" />
          </div>
         
         </div>
      
               
              
                

           


            <%-- <br />
           <asp:button ID="pd" runat="server" CssClass="btn btn-warning btn-lg" ToolTip="pd" Text="pd" Font-Bold="true"></asp:button>--%>
        
     

         
       
      
             

                

      <%--  REVISION--%>
     <div class="col-1">
       
      </div>
  
        
       <%-- DESCRIPTION--%>
        
         <div class="col-5">
      
      </div>
    </div>

        
    </ContentTemplate>
          <Triggers>
            <asp:PostBackTrigger ControlID="cmdSubmit" />
          </Triggers>
        </asp:UpdatePanel>
   
       
         
    
</div>
</div>
</asp:Content>