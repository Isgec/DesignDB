<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_UserDB.aspx.vb" Inherits="GF_UserDB" title="User Dashboard" %>
<asp:Content ID="CPHtaApprovalWFTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div class="container-fluid">
<div class="caption">
    <asp:Label ID="LabeltaApprovalWFTypes" runat="server" Text="&nbsp;USER DASHBOARD"></asp:Label>
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
     
   


     <div class="container text-center my-1" >
        <div class="border border-danger btn-outline-light">
    <div class="container-fluid text-center">
      <div class="row">

        <div class="col-auto">
          <div class="text-danger">
            <u><b>
              <h6><b>PENDING DWGS/DOCS IN RELEASE WORKFLOW</b></h6>
            </b></u>
          </div>
        </div>
        
      </div>
    </div>


    <div class="container-fluid">
      <div class="row">
        <div class="col-sm-3">
         <%--' '<h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">Under Drafting: </font></span></h6>--%>
           <h6><a href="#demo" class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"  data-toggle="collapse"><b><font face="Comic Sans MS">Under Drafting: </font></b></a></h6>
  <div id="demo" class="collapse">
    <b>Count of Documents and Drawings which are in Under Design  State with My Login ie. <%= HttpContext.Current.Session("LoginID") %> </b>
  </div>
        </div>
        <div class="col-sm-1">
          <asp:Button ID="cpd" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Under Design" Text="cpd" Font-Bold="true"></asp:Button>
        </div>

        <div class="col-sm-3 ">
        <%--  <h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">Under Review: </font></span></h6>--%>
          <h6><a href="#demo1" class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"  data-toggle="collapse"><b><font face="Comic Sans MS">Under Review: </font></b></a></h6>
  <div id="demo1" class="collapse">
    <b>Count of Documents and Drawings which are in Under Review  State with My Login ie. <%= HttpContext.Current.Session("LoginID") %> </b>
  </div>
        </div>
        <div class="col-sm-1">
          <asp:Button ID="cpr" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Under Review" Text="cpr" Font-Bold="true"></asp:Button>
        </div>

        <div class="col-sm-3">
         <%-- <h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">Under Approval: </font></span></h6>--%>
          <h6><a href="#demo2" class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"  data-toggle="collapse"><b><font face="Comic Sans MS">Under Approval: </font></b></a></h6>
  <div id="demo2" class="collapse">
    <b>Count of Documents and Drawings which are in Under Review  State with My Login ie. <%= HttpContext.Current.Session("LoginID") %> </b>
  </div>
        </div>
        <div class="col-sm-1">
          <asp:Button ID="cpa" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Under Approval" Text="cpa" Font-Bold="true"></asp:Button>

        </div>
      </div>
    </div>
       </div>
       </div>
         

         <div class="container text-center my-1" >
           <div class="border border-warning btn-outline-light">
    <div class="container-fluid text-center">
      <div class="row">
        <div class="col-sm-auto">
          <div class=" text-warning">
            <u><b>
              <h6><b>IDMS</b></h6>
            </b></u>
          </div>
        </div>
      </div>
    </div>

    <div class="container-fluid">
      <div class="row">
        <div class="col-md-3">
        <%-- <h6> <span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">Pre-Order_For Evaluation : </font></span></h6>--%>
          <h6><a href="#demo3" class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"  data-toggle="collapse"><b><font face="Comic Sans MS">Pre-Order__For Evaluation : </font></b></a></h6>
  <div id="demo3" class="collapse">
    <b>Count of Pre Order Receipts which are in Under Evaluation State with My Department </b>
  </div>
        </div>
        <div class="col-xs-1">
          <asp:Button ID="cipre" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block" ToolTip="Total Pending in Your Department" Text="cipre" Font-Bold="true"></asp:Button>
        </div>
        <div class="col-md-3">
       <%-- <h6>  <span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">Post-Order__For Evaluation :</font></span></h6>--%>
          <h6><a href="#demo4" class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"  data-toggle="collapse"><b><font face="Comic Sans MS">Post-Order__For Evaluation :</font></b></a></h6>
  <div id="demo4" class="collapse">
    <b>Count of Post Order Receipts which are in Under Evaluation State with My Department </b>
  </div>
        </div>
        <div class="col-xs-1">
          <asp:Button ID="cipoe" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block" ToolTip="Total Pending in Your Department" Text="cipoe" Font-Bold="true"></asp:Button>
        </div>
      </div>
    </div>
    </div>
  </div>

     <div class="container text-center my-1" >
        <div class="border border-info btn-outline-light">
    <div class="container-fluid text-center">
      <div class="row">
        <div class="col-sm-auto">
          <div class="text-info">
            <u><b>
              <h6><b>TRANSMITTAL</b></h6>
            </b></u>
          </div>
        </div>
      </div>
    </div>


    <div class="container-fluid">
      <div class="row">
        <div class="col-md-3">
        <%-- <h6> <span class="btn btn-info  btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">In Approval (Created By Me): </font></span></h6>--%>
          <h6><a href="#demo5" class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"  data-toggle="collapse"><b><font face="Comic Sans MS">In Approval (Created By Me): </font></b></a></h6>
  <div id="demo5" class="collapse">
     <b>Count of Transmittals which are in Pending for My Approval </b>
  </div>
        </div>
        <div class="col-xs-auto">
          <asp:Button ID="cta" runat="server" CssClass="btn btn-outline-info btn-sm btn-block" ToolTip="Transmittals Pending for Approval" Text="cta" Font-Bold="true"></asp:Button>
        </div>


        <div class="col-md-3">
      <%-- <h6>   <span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">For Issue (Created By Me): </font></span></h6>--%>
          <h6><a href="#demo6" class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"  data-toggle="collapse"><b><font face="Comic Sans MS">For Issue (Created By Me): </font></b></a></h6>
  <div id="demo6" class="collapse">
    <b>Count of Transmittals which are in Pending for Issue Created By Me : <%= HttpContext.Current.Session("LoginID") %> </b>
  </div>
        </div>
        <div class="col-xs-auto">
          <asp:Button ID="cti" runat="server" CssClass="btn btn-outline-info btn-sm btn-block" ToolTip="Transmittals Pending for Issue" Text="cti" Font-Bold="true"></asp:Button>
        </div>
      </div>
    </div>
       </div>
  
         </div>

    <div class="container text-center my-1" >
      <div class="border border-warning btn-outline-light">
    <div class="container">
      <div class="row">
        <div class="col-sm-auto">
          <div class="text-success">
            <u><b>
              <h6><b>DWG/DOC CHANGE REQUEST </b></h6>
            </b></u>
          </div>
        </div>
      </div>
    </div>

    
    <div class="container-fluid">
      <div class="row">
        <div class="col-md-3">
          <%--<h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">For Approval : </font></span></h6>--%>
          <h6><a href="#demo7" class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"  data-toggle="collapse"><b><font face="Comic Sans MS">For Approval : </font></b></a></h6>
  <div id="demo7" class="collapse">
     <b>Count of DCRs which are in Pending for My Approval </b>
  </div>
        </div>
        <div class="col-xs-auto">
          <asp:Button ID="cda" runat="server" CssClass="btn btn-outline-success btn-sm btn-block" ToolTip="DCR Pending for Approval" Text="cda" Font-Bold="true"></asp:Button>
        </div>


        <div class="col-md-3">
          <%--<h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">In Approval(Created By Me):</font></span></h6>--%>
          <h6><a href="#demo8" class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"  data-toggle="collapse"><b><font face="Comic Sans MS">In Approval (Created By Me):</font></b></a></h6>
  <div id="demo8" class="collapse">
     <b>Count of DCRs which are Created by me but Still are in Approval State</b>
  </div>
        </div>
        <div class="col-xs-auto">
          <asp:Button ID="cdac" runat="server" CssClass="btn btn-outline-success btn-sm btn-block" ToolTip="DCR Pending for Approval" Text="cdac" Font-Bold="true"></asp:Button>
        </div>
      </div>
    </div>
      </div>
   </div>

    <div class="container text-center my-1" >
         <div class="border border-secondary btn-outline-light">
    <div class="container">
      <div class="row">
        <div class="col-sm-auto">
          <div class=" text-dark">
            <u><b>
              <h6><b>SAR</b></h6>
            </b></u>
          </div>
        </div>
      </div>
    </div>

    
    <div class="container-fluid">
      <div class="row">
        <div class="col-md-3">
         <%--<h6> <span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><b><font face="Comic Sans MS">For Review : </font></b></span></h6>--%>
           <h6><a href="#demo9" class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"  data-toggle="collapse"><b><font face="Comic Sans MS">For Review : </font></b></a></h6>
  <div id="demo9" class="collapse">
     <b>Count of SARs which are Pending with Me in Review State</b>
  </div>
        </div>
        <div class="col-xs-auto">
          <asp:Button ID="csr" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block" ToolTip="SAR Pending for Review" Text="csr" Font-Bold="true"></asp:Button>
        </div>

        <div class="col-md-3">
          <%--<h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><b><font face="Comic Sans MS">For Approval :</font></b></span></h6>--%>
           <h6><a href="#demo10" class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"  data-toggle="collapse"><b><font face="Comic Sans MS">For Approval :</font></b></a></h6>
  <div id="demo10" class="collapse">
     <b>Count of SARs which are Pending with Me in Approval State</b>
  </div>
        </div>
        <div class="col-xs-auto">
          <asp:Button ID="csa" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block" ToolTip="SAR Pending for Approval" Text="csa" Font-Bold="true"></asp:Button>
        </div>
      </div>
    </div>
    </div>
 
      </div>

     <div class="container text-center my-1" >
       <div class="border border-warning btn-outline-light">
           <div class="container">
      <div class="row">
        <div class="col-sm-auto">
          <div class="text-danger">
            <u><b>
              <h6><b>ManHour Entry Details</b></h6>
            </b></u>
          </div>
        </div>
      </div>
    </div>


    <div class="container-fluid">
      <div class="row">
        <div class="col-md-3">
       <%-- <h6>  <span class="btn btn-danger btn-sm btn-block text-lg-left font-weight-bold"><b><font face="Comic Sans MS">Manhours Entered for Today: </font></b></span></h6>--%>
           <h6><a href="#demo11" class="btn btn-danger btn-sm btn-block text-lg-left font-weight-bold"  data-toggle="collapse"><b><b><font face="Comic Sans MS">Manhours Entered for Today: </font></b></a></h6>
  <div id="demo11" class="collapse">
     <b>Todays ManHours Entry in ERPLN .Click on Red Button to get Last 30 Days Report. </b>
  </div>
        </div>
        <div class="col-xs-auto">
          
          <asp:Button ID="cmh" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block" ToolTip="Hrs." Text="cmh" Font-Bold="true"></asp:Button>
       
             </div>
      </div>
    </div>
       </div>
       </div>

    
          
     <div class="container text-center mt-0 con">   
           
       <div class="border border-primary btn-outline-light">
         
       <div class="container text-center">
      <div class="row">
        <div class="col-sm-auto">
          <div class="text-info">
            <u><b>
              <h6><b>USER DETAILS</b></h6>
            </b></u>
          </div>
        </div>
      </div>
    </div>

          
       <div class="container-fluid text-center my-0">
         <div class ="row">
           <div class="col-sm-3">
  	          <div class="alert alert-primary btn-primary" role="alert">
                  <b>Employee ID : <asp:button ID="Luser" text="Luser" runat="server"></asp:button></b>
              </div>
           </div>

          <div class="col-sm-6">
  	
              <div class="alert alert-primary btn-primary" role="alert">
                  <b>Group in ERPLN : <asp:button ID="LuserG" text="LuserG" runat="server"></asp:button></b>
              </div>
         </div>
           
           
           </div>
        </div>
          </div>
       </div>
      
        
      
   
             </ContentTemplate>
           <Triggers>
           </Triggers>
    </asp:UpdatePanel>

</div>
</div>
</asp:Content>
