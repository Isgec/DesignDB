<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_Discipline.aspx.vb" Inherits="GF_Discipline" title="Discipline" %>
<asp:Content ID="CPHtaApprovalWFTypes" ContentPlaceHolderID="cph1" Runat="Server">
   
<div class="container-fluid">
<div class="caption">
    <asp:Label ID="LabeltaApprovalWFTypes" runat="server" Text="&nbsp;Discipline DashBoard"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtaApprovalWFTypes" runat="server">
  <ContentTemplate>
    <asp:UpdateProgress ID="UPGStaApprovalWFTypes" runat="server" AssociatedUpdatePanelID="UPNLtaApprovalWFTypes" DisplayAfter="100" >
      <ProgressTemplate>
        <span style="color: #ff0031">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>


     <hr style="color:brown;background-color:darkslategrey;width:100%;height:3px">

     <div class="row  mt-3">
       
      <div class="col-4">
     
            <div class="form-group">

              <div class="input-group">
                
                 
                <a href="#ID_Division" class="btn btn-warning btn-outline-dark" style="width: 140px; text-align: center; cursor: pointer" data-toggle="collapse"><b>Division</b></a>
  <div id="ID_Division" class="collapse">
    Select Division for which Information need to fetched for Dashboard.
    Click again 'Division' button To Hide this Information.
  </div>
                 <asp:dropdownlist ID="F_DivisionID" CssClass="form-control" ClientIDMode="static" runat="Server" >
                  <asp:ListItem Value="">BOILER</asp:ListItem>  
                  <asp:ListItem>EPC</asp:ListItem>  
                  <asp:ListItem>SMD</asp:ListItem>  
                  <asp:ListItem>APC</asp:ListItem> 

                </asp:dropdownlist>
                 </div>
            </div>
             </div> 
         
      <div class="col-4">
      
            <div class="form-group">

              <div class="input-group">
    
                <a href="#ID_Discipline" class="btn btn-light btn-outline-dark" style="width: 140px; text-align: center; cursor: pointer" data-toggle="collapse"><b>Discipline</b></a>
  <div id="ID_Discipline" class="collapse">
   Select Department for which Information need to fetched for Dashboard.
    Click again 'Department' button To Hide this Information.
  </div>
                 <asp:dropdownlist ID="F_DisciplineID" CssClass="form-control" ClientIDMode="static" runat="Server" >
                  <asp:ListItem Value="">MECHANICAL</asp:ListItem>  
                  <asp:ListItem>PROCESS</asp:ListItem> 
                  <asp:ListItem>STRUCTURE</asp:ListItem>  
                  <asp:ListItem>PIPING</asp:ListItem>  
                  <asp:ListItem>ELECTRICAL</asp:ListItem>  
                  <asp:ListItem>INSTRUMENTATION</asp:ListItem> 
                   <asp:ListItem>CIVIL</asp:ListItem>
                   <asp:ListItem>MATERIAL HANDLING</asp:ListItem>
                   <asp:ListItem>PROJECT</asp:ListItem>
                   <asp:ListItem>WWS</asp:ListItem>


                </asp:dropdownlist>
                 </div>
            </div>
             </div>  
           


          
       <div class="col-1">
               </div>
     
      <div class="col-3">
           
          <asp:Button ID="cmdSubmit" runat="server" CssClass="btn  btn-block btn-outline-danger"  Font-Bold="true" Text="Generate DashBoard" ToolTip="-" style="width: 210px; text-align: center; cursor:pointer"/>
          </div>

         
            
     </div>   
              


    <hr style="color:brown;background-color:darkslategrey;width:100%;height:3px">
  
   <hr>
       <div class="container text-center" id="DPMDLTABLE" runat="server" visible="false">
      <h5>Drawing and Document Progress Status As per PMDL - As Of Now </h5> 
      <div class="row">

        <div class="col-12">
          <asp:Button ID="DPMDLDATAI" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Sorry !!! No Data in ERPLN" Text="" Font-Bold="true" Visible="false"></asp:Button>

        </div>
      </div>
      <div class="container text-center" id="DPMDLTABLE1" runat="server" visible="true">
        <div class="border border-dark btn-outline-light">
          <div class="container-fluid text-center">

            <div class="row">
              <div class="col-2">
                <div class="text-secondary">
                  <h6><b>Discipline</b></h6>
                </div>
              </div>

              <div class="col-10">
                <div class="row">

                  <div class="col">
                    <div class="text-dark">
                      <h6><b>Total Count as per PMDL</b></h6>
                    </div>
                  </div>
                  <div class="col">
                    <div class="text-primary">
                      <h6><b>Total Released</b></h6>
                    </div>
                  </div>
                  <div class="col">
                    <div class="text-warning">

                      <h6><b>Total Pending For Release</b></h6>
                    </div>
                  </div>
                   <div class="col">
                    <div class="text-secondary">
                      <h6><b>Due Till Today For Release</b></h6>
                    </div>
                  </div>
                  
                  <div class="col">
                    <div class="text-secondary">
                      <h6><b>Due on Today For Release</b></h6>
                    </div>
                  </div>

                  <div class="col">
                    <div class="text-success">
                      <h6><b>Ontime Released</b></h6>
                    </div>
                  </div>

                  <div class="col">
                    <div class="text-danger">
                      <h6><b>Delayed Released</b></h6>
                    </div>
                  </div>
                </div>
              </div>

            </div>

          </div>

          <div class="container-fluid">
            <div class="row">
              <div class="col-2">
                 <asp:Button ID="Btn_Discipline" runat="server" CssClass="btn btn-info btn-sm btn-block text-lg-left font-weight-bold" ToolTip="" Text="" Font-Bold="true"></asp:Button>
              </div>
              <div class="col-10">
                <div class="row">

                  <div class="col">
                    <asp:Button ID="btn_Discipline_Total_Count" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="Process - Total Doc in PMDL" Text="" Font-Bold="true"></asp:Button>
                  </div>
                  <div class="col">
                    <asp:Button ID="btn_Discipline_Release_Count" runat="server" CssClass="btn btn-outline-primary btn-sm btn-block font-weight-bold" ToolTip="Process - Released DWG/Doc in PMDL" Text="" Font-Bold="true"></asp:Button>
                  </div>
                  <div class="col">
                    <asp:Button ID="btn_Discipline_Pending_Count" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Process - Total Pending DWG/Doc to Release" Text="" Font-Bold="true"></asp:Button>
                  </div>

                   <div class="col">
              <asp:Button ID="btn_Discipline_DueTillToday_Count" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Process - Due for Today DWG/Doc to Release" Text="" Font-Bold="true"></asp:Button>

                  </div>

                  <div class="col">
                    <asp:Button ID="btn_Discipline_Due_Count" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Process - Due for Today DWG/Doc to Release" Text="" Font-Bold="true"></asp:Button>
                  </div>
                  <div class="col">
                    <asp:Button ID="btn_Discipline_Ontime_Count" runat="server" CssClass="btn btn-outline-success btn-sm btn-block font-weight-bold" ToolTip="Process - Ontime Released DWG/Doc" Text="" Font-Bold="true"></asp:Button>
                  </div>
                  <div class="col">
                    <asp:Button ID="btn_Discipline_Delayed_Count" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Process - Delayed Released DWG/Doc" Text="" Font-Bold="true"></asp:Button>
                  </div>
                  
                </div>
              </div>
              
            </div>
          </div>

        

        </div>
      </div>

    </div>
   <hr>
        
     </ContentTemplate>
          <Triggers>
            <asp:PostBackTrigger ControlID="cmdSubmit" />
          </Triggers>
        </asp:UpdatePanel>
           
    
</div>
</div>
</asp:Content>