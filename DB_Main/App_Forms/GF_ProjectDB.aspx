<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_ProjectDB.aspx.vb" Inherits="GF_ProjectDB" title="Project Dashboard" %>
<asp:Content ID="CPHtaApprovalWFTypes" ContentPlaceHolderID="cph1" runat="Server">
 
    <div class="caption">
      <asp:Label ID="LabeltaApprovalWFTypes" runat="server" Text="&nbsp;PROJECT DASHBOARD"></asp:Label>
    </div>


    <%--Project Selection Drop Down--%>
   <%-- <div class="col-sm-2 mb-2 ">
      <a class="btn btn-secondary btn-outline-dark" href="GF_UserDB.aspx" role="button"><i class="fa fa-dashboard text-warning" style="font-size: 20px">My DashBoard </i><i class="fa fa-spinner fa-spin text-success"></i></a>

    </div>--%>
    
    <div class="row mt-3 ml-1">

      
      <div class="col-3">
        <asp:UpdatePanel ID="UPNLctPActivity" runat="server">
          <ContentTemplate>
            <div class="form-group">

              <div class="input-group">
               <%-- <span class=" btn btn-sm btn-dark" style="width: 78px; text-align: center; cursor: pointer" title="Enter Project ID:" onclick="openNav()"><b>Project:</b></span>--%>

                <a href="#demo" class="btn btn-light btn-outline-dark" style="width: 120px; text-align: center; cursor: pointer"  data-toggle="collapse"><b>Project ID</b></a>
  <div id="demo" class="collapse">
    Enter Project ID & Click to 'SHOW' button. This will allow system to Generate Project DashBoard Based upon current progress in BAAN ERPLN.
    Click again to Hide this Information
  </div>




                <asp:TextBox
                  ID="F_t_cprj"
                  CssClass="form-control"
                  ClientIDMode="static"
                  runat="Server">
                </asp:TextBox>
                <script>
                  function changeImage() {
                    $get('image1').style.display = 'block';
                    $get('image2').style.display = 'none';
                  }
                </script>
                <asp:Button ID="cmdSubmit" runat="server" CssClass="btn btn-warning btn-sm" Text="SHOW" OnClientClick="return changeImage();" ToolTip="Click to Generate Project DashBoard " Font-Bold="true" Font-Names="Comic Sans MS" />
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
      <div class="col-9">
        <div class="container text-center" id="PDetails" runat="server" visible="false">
          <div class="container  text-center">
            <asp:Button ID="btn_projectname" Text="" runat="server" CssClass="btn-warning btn-sm" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip=""></asp:Button>
            <hr style="color:yellowgreen;background-color:orange;width:100%;height:1px" id="line1" runat="server" visible="false" />
          </div>
        </div>
      </div>
    </div>
    <%--Project & Period Detaila--%>
    
   <div class="row">

        <div class="col-5"> 
    <img src="gifproject.gif" id="image1" style="display:none;" clientidmode="Static" runat="server" width="440" height="330"/>
        <img src="gifpreproject.bmp" id="image2" style="display:block;" width="440" height="330" runat="server" clientidmode="Static"/>
    </div>
       <div class="col-7" id="imagetext" runat="server" visible="true"> 
         <div class="row">
           </div>
                  <br>  
          <br>  
          <br>
          <br>
    <hr style="color:yellowgreen;background-color:aquamarine;width:100%;height:4px" id="imageline1" runat="server" visible="true"/>
        
         <h5><font face="Comic Sans MS"> Kindly keep Patience, After Clicking  <asp:LABEL ID="Button1" Text="SHOW" runat="server" CssClass="btn-warning btn-sm" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip=""></asp:LABEL> Button,</font></h5>
         
         <h5> <font face="Comic Sans MS"> As Project Dashboard may take 2 to 3 minutes time for generating chart and tables.</font></h5>
          <br> 
         <h5><font face="Comic Sans MS"><asp:LABEL ID="LABEL2" Text="SHOW" runat="server" CssClass="btn-warning btn-sm" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip=""></asp:LABEL> बटन पर क्लिक करने के बाद, कृपया धैर्य बनाए रखें। </font></h5>
         <h5><font face="Comic Sans MS">क्योंकि चार्ट और टेबल बनाने में 2 से 3 मिनट का समय लग सकता है।</font></h5>
       <hr style="color:yellowgreen;background-color:aquamarine;width:100%;height:4px" id="imageline2" runat="server" visible="true"/>  
       </div>
     </div>

   <%-- Navigation--%>

    <div class="row container-fluid" id="navmenu" runat="server" visible="false">
<div class="col-2">
    <div class="nav flex-column nav-pills btn-light" id="v-pills-tab" role="tablist" aria-orientation="vertical">
      <a class="nav-link active" id="PMDL_T" data-toggle="pill" href="#v-pills-pmdl-t" role="tab" aria-controls="v-pills-home" aria-selected="true"><font face="Comic Sans MS">PMDL TABLE</font></a>
      <a class="nav-link" id="PMDL_G" data-toggle="pill" href="#v-pills-pmdl-g" role="tab" aria-controls="v-pills-profile" aria-selected="false"><font face="Comic Sans MS">PMDL GRAPH</font></a>
     <a class="nav-link" id="DCR_T" data-toggle="pill" href="#v-pills-dcr-t" role="tab" aria-controls="v-pills-profile" aria-selected="false"><font face="Comic Sans MS">DCR TABLE</font></a>
       <a class="nav-link" id="DCR_G" data-toggle="pill" href="#v-pills-dcr-g" role="tab" aria-controls="v-pills-profile" aria-selected="false"><font face="Comic Sans MS">DCR GRAPH</font></a>
        <a class="nav-link" id="TRANS_T" data-toggle="pill" href="#v-pills-trans-t" role="tab" aria-controls="v-pills-profile" aria-selected="false"><font face="Comic Sans MS">TRANSMITTAL TABLE</font></a>
      <a class="nav-link" id="TRANS_G" data-toggle="pill" href="#v-pills-trans-g" role="tab" aria-controls="v-pills-profile" aria-selected="false"><font face="Comic Sans MS">TRANSMITTAL GRAPH</font></a>
      <a class="nav-link" id="TRANS_TG" data-toggle="pill" href="#v-pills-trans-tg" role="tab" aria-controls="v-pills-profile" aria-selected="false"><font face="Comic Sans MS">TRANSMITTAL TYPE GRAPH</font></a>
        <a class="nav-link" id="TRANS_TI" data-toggle="pill" href="#v-pills-trans-ti" role="tab" aria-controls="v-pills-profile" aria-selected="false"><font face="Comic Sans MS">TRANSMITTAL ISSUED GRAPH</font></a>
       <a class="nav-link" id="PED" data-toggle="pill" href="#v-pills-ped" role="tab" aria-controls="v-pills-profile" aria-selected="false"><font face="Comic Sans MS">PENDING ERECTION DRAWING TO ISSUE</font></a>
       <a class="nav-link" id="SAR_G" data-toggle="pill" href="#v-pills-sar-g" role="tab" aria-controls="v-pills-profile" aria-selected="false"><font face="Comic Sans MS">SAR GRAPH</font></a>
            <a class="nav-link" id="SAR_T" data-toggle="pill" href="#v-pills-sar-t" role="tab" aria-controls="v-pills-profile" aria-selected="false"><font face="Comic Sans MS">SAR TABLE</font></a>
         <a class="nav-link" id="IDMS_PG" data-toggle="pill" href="#v-pills-idms-pg" role="tab" aria-controls="v-pills-profile" aria-selected="false"><font face="Comic Sans MS">IDMS PREORDER GRAPH</font></a>
         <a class="nav-link" id="IDMS_PT" data-toggle="pill" href="#v-pills-idms-pt" role="tab" aria-controls="v-pills-profile" aria-selected="false"><font face="Comic Sans MS">IDMS PREORDER TABLE</font></a>
              <a class="nav-link" id="IDMS_OG" data-toggle="pill" href="#v-pills-idms-og" role="tab" aria-controls="v-pills-profile" aria-selected="false"><font face="Comic Sans MS">IDMS POST ORDER GRAPH</font></a>
         <a class="nav-link" id="IDMS_OT" data-toggle="pill" href="#v-pills-idms-ot" role="tab" aria-controls="v-pills-profile" aria-selected="false"><font face="Comic Sans MS">IDMS POST ORDER TABLE</font></a>
        <a class="nav-link" id="ELEMENT_G" data-toggle="pill" href="#v-pills-element-g" role="tab" aria-controls="v-pills-profile" aria-selected="false"><font face="Comic Sans MS">ELEMENT GRAPH</font></a>
       <a class="nav-link" id="ELEMENT_T" data-toggle="pill" href="#v-pills-element-t" role="tab" aria-controls="v-pills-profile" aria-selected="false"><font face="Comic Sans MS">ELEMENT TABLE</font></a>
          <a class="nav-link" id="HOLD_G" data-toggle="pill" href="#v-pills-hold-g" role="tab" aria-controls="v-pills-profile" aria-selected="false"><font face="Comic Sans MS">HOLD GRAPH</font></a>
       <a class="nav-link" id="HOLD_T" data-toggle="pill" href="#v-pills-hold-t" role="tab" aria-controls="v-pills-profile" aria-selected="false"><font face="Comic Sans MS">UNDER HOLD GRAPH</font></a>
        </div>
  </div>
 


  <div class="col-10">
    <div class="tab-content" id="v-pills-tabContent">
      <div class="tab-pane fade show active" id="v-pills-pmdl-t" role="tabpanel" aria-labelledby="PMDL_T">
              <div class="container text-center" id="PMDLTABLE" runat="server" visible="false">
      <h5>Drawing and Document Progress Status As per PMDL - As Of Now</h5>
      <div class="row">

        <div class="col-12">
          <asp:Button ID="PMDLDATAI" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Sorry !!! No Data in ERPLN" Text="" Font-Bold="true" Visible="false"></asp:Button>

        </div>
      </div>
      <div class="container text-center" id="PMDLTABLE1" runat="server" visible="false">
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

                  <div class="col-2">
                    <div class="text-dark">
                      <h6><b>Total Count as per PMDL</b></h6>
                    </div>
                  </div>
                  <div class="col-2">
                    <div class="text-primary">
                      <h6><b>Total Released</b></h6>
                    </div>
                  </div>
                  <div class="col-2">
                    <div class="text-warning">

                      <h6><b>Total Pending For Release</b></h6>
                    </div>
                  </div>
                  <div class="col-2">
                    <div class="text-secondary">
                      <h6><b>Due on Today For Release</b></h6>
                    </div>
                  </div>
                  <div class="col-2">
                    <div class="text-success">
                      <h6><b>Ontime Released</b></h6>
                    </div>
                  </div>

                  <div class="col-2">
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
                <h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">Process </font></span></h6>
              </div>
              <div class="col-10">
                <div class="row">

                  <div class="col-2">
                    <asp:Button ID="btn_Process_Total_Count" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="Process - Total Doc in PMDL" Text="" Font-Bold="true"></asp:Button>
                  </div>
                  <div class="col-2">
                    <asp:Button ID="btn_Process_Release_Count" runat="server" CssClass="btn btn-outline-primary btn-sm btn-block font-weight-bold" ToolTip="Process - Released DWG/Doc in PMDL" Text="" Font-Bold="true"></asp:Button>
                  </div>
                  <div class="col-2">
                    <asp:Button ID="btn_Process_Pending_Count" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Process - Total Pending DWG/Doc to Release" Text="" Font-Bold="true"></asp:Button>
                  </div>
                  <div class="col-2">
                    <asp:Button ID="btn_Process_Due_Count" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Process - Due for Today DWG/Doc to Release" Text="" Font-Bold="true"></asp:Button>
                  </div>
                  <div class="col-2">
                    <asp:Button ID="btn_Process_Ontime_Count" runat="server" CssClass="btn btn-outline-success btn-sm btn-block font-weight-bold" ToolTip="Process - Ontime Released DWG/Doc" Text="" Font-Bold="true"></asp:Button>
                  </div>
                  <div class="col-2">
                    <asp:Button ID="btn_Process_Delayed_Count" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Process - Delayed Released DWG/Doc" Text="" Font-Bold="true"></asp:Button>
                  </div>
                </div>
              </div>
            </div>
          </div>

          <div class="container-fluid">
            <div class="row">
              <div class="col-2">
                <h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">Mechanical </font></span></h6>
              </div>
              <div class="col-10">
                <div class="row">

                  <div class="col-sm-2">
                    <asp:Button ID="btn_Mechanical_Total_Count" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="Mechanical - Total Doc in PMDL" Text="" Font-Bold="true"></asp:Button>
                  </div>
                  <div class="col-sm-2">
                    <asp:Button ID="btn_Mechanical_Release_Count" runat="server" CssClass="btn btn-outline-primary btn-sm btn-block font-weight-bold" ToolTip="Mechanical - Released DWG/Doc in PMDL" Text="" Font-Bold="true"></asp:Button>
                  </div>
                  <div class="col-sm-2">
                    <asp:Button ID="btn_Mechanical_Pending_Count" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Mechanical - Total Pending DWG/Doc to Release" Text="" Font-Bold="true"></asp:Button>
                  </div>
                  <div class="col-2">
                    <asp:Button ID="btn_Mechanical_Due_Count" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Mechanical - Due for Today DWG/Doc to Release" Text="" Font-Bold="true"></asp:Button>
                  </div>
                  <div class="col-sm-2">
                    <asp:Button ID="btn_Mechanical_Ontime_Count" runat="server" CssClass="btn btn-outline-success btn-sm btn-block font-weight-bold" ToolTip="Mechanical - Ontime Released DWG/Doc" Text="" Font-Bold="true"></asp:Button>
                  </div>
                  <div class="col-sm-2">
                    <asp:Button ID="btn_Mechanical_Delayed_Count" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Mechanical - Delayed Released DWG/Doc" Text="" Font-Bold="true"></asp:Button>
                  </div>
                </div>
              </div>
            </div>
          </div>

          <div class="container-fluid">
            <div class="row">
              <div class="col-md-2">
                <h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">Structure </font></span></h6>
              </div>
              <div class="col-10">
                <div class="row">

                  <div class="col-sm-2">
                    <asp:Button ID="btn_Structure_Total_Count" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="Structure - Total Doc in PMDL" Text="" Font-Bold="true"></asp:Button>
                  </div>
                  <div class="col-sm-2">
                    <asp:Button ID="btn_Structure_Release_Count" runat="server" CssClass="btn btn-outline-primary btn-sm btn-block font-weight-bold" ToolTip="Structure - Released DWG/Doc in PMDL" Text="" Font-Bold="true"></asp:Button>
                  </div>
                  <div class="col-sm-2">
                    <asp:Button ID="btn_Structure_Pending_Count" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Structure - Total Pending DWG/Doc to Release" Text="" Font-Bold="true"></asp:Button>
                  </div>
                  <div class="col-sm-2">
                    <asp:Button ID="btn_Structure_Due_Count" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Structure - Due for Today DWG/Doc to Release" Text="" Font-Bold="true"></asp:Button>
                  </div>
                  <div class="col-sm-2">
                    <asp:Button ID="btn_Structure_Ontime_Count" runat="server" CssClass="btn btn-outline-success btn-sm btn-block font-weight-bold" ToolTip="Structure - Ontime Released DWG/Doc" Text="" Font-Bold="true"></asp:Button>
                  </div>
                  <div class="col-sm-2">
                    <asp:Button ID="btn_Structure_Delayed_Count" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Structure - Delayed Released DWG/Doc" Text="" Font-Bold="true"></asp:Button>
                  </div>
                </div>
              </div>
            </div>
          </div>

          <div class="container-fluid">
            <div class="row">
              <div class="col-md-2">
                <h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">Piping </font></span></h6>
              </div>
              <div class="col-10">
                <div class="row">

                  <div class="col-sm-2">
                    <asp:Button ID="btn_Piping_Total_Count" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="Piping - Total Doc in PMDL" Text="" Font-Bold="true"></asp:Button>
                  </div>
                  <div class="col-sm-2">
                    <asp:Button ID="btn_Piping_Release_Count" runat="server" CssClass="btn btn-outline-primary btn-sm btn-block font-weight-bold" ToolTip="Piping - Released DWG/Doc in PMDL" Text="" Font-Bold="true"></asp:Button>
                  </div>
                  <div class="col-sm-2">
                    <asp:Button ID="btn_Piping_Pending_Count" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Piping - Total Pending DWG/Doc to Release" Text="" Font-Bold="true"></asp:Button>
                  </div>
                  <div class="col-sm-2">
                    <asp:Button ID="btn_Piping_Due_Count" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Piping - Due for Today DWG/Doc to Release" Text="" Font-Bold="true"></asp:Button>
                  </div>
                  <div class="col-sm-2">
                    <asp:Button ID="btn_Piping_Ontime_Count" runat="server" CssClass="btn btn-outline-success btn-sm btn-block font-weight-bold" ToolTip="Piping - Ontime Released DWG/Doc" Text="" Font-Bold="true"></asp:Button>
                  </div>
                  <div class="col-sm-2">
                    <asp:Button ID="btn_piping_Delayed_Count" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Piping - Delayed Released DWG/Doc" Text="" Font-Bold="true"></asp:Button>
                  </div>
                </div>
              </div>
            </div>
          </div>

          <div class="container-fluid">
            <div class="row">
              <div class="col-md-2">
                <h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">Electrical </font></span></h6>
              </div>
              <div class="col-10">
                <div class="row">

                  <div class="col-sm-2">
                    <asp:Button ID="btn_Electrical_Total_Count" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="Electrical - Total Doc in PMDL" Text="" Font-Bold="true"></asp:Button>
                  </div>
                  <div class="col-sm-2">
                    <asp:Button ID="btn_Electrical_Release_Count" runat="server" CssClass="btn btn-outline-primary btn-sm btn-block font-weight-bold" ToolTip="Electrical - Released DWG/Doc in PMDL" Text="" Font-Bold="true"></asp:Button>
                  </div>
                  <div class="col-sm-2">
                    <asp:Button ID="btn_Electrical_Pending_Count" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Electrical - Total Pending DWG/Doc to Release" Text="" Font-Bold="true"></asp:Button>
                  </div>
                  <div class="col-sm-2">
                    <asp:Button ID="btn_Electrical_Due_Count" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Electrical - Due for Today DWG/Doc to Release" Text="" Font-Bold="true"></asp:Button>
                  </div>
                  <div class="col-sm-2">
                    <asp:Button ID="btn_Electrical_Ontime_Count" runat="server" CssClass="btn btn-outline-success btn-sm btn-block font-weight-bold" ToolTip="Electrical - Ontime Released DWG/Doc" Text="" Font-Bold="true"></asp:Button>
                  </div>
                  <div class="col-sm-2">
                    <asp:Button ID="btn_Electrical_Delayed_Count" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Electrical - Delayed Released DWG/Doc" Text="" Font-Bold="true"></asp:Button>
                  </div>
                </div>
              </div>
            </div>
          </div>


          <div class="container-fluid">
            <div class="row">
              <div class="col-md-2">
                <h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">C & I </font></span></h6>
              </div>
              <div class="col-10">
                <div class="row">

                  <div class="col-sm-2">
                    <asp:Button ID="btn_CI_Total_Count" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="C & I - Total Doc in PMDL" Text="" Font-Bold="true"></asp:Button>
                  </div>
                  <div class="col-sm-2">
                    <asp:Button ID="btn_CI_Release_Count" runat="server" CssClass="btn btn-outline-primary btn-sm btn-block font-weight-bold" ToolTip="C & I - Released DWG/Doc in PMDL" Text="" Font-Bold="true"></asp:Button>
                  </div>
                  <div class="col-sm-2">
                    <asp:Button ID="btn_CI_Pending_Count" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="C & I - Total Pending DWG/Doc to Release" Text="" Font-Bold="true"></asp:Button>
                  </div>
                  <div class="col-sm-2">
                    <asp:Button ID="btn_CI_Due_Count" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="C & I - Due for Today DWG/Doc to Release" Text="" Font-Bold="true"></asp:Button>
                  </div>
                  <div class="col-sm-2">
                    <asp:Button ID="btn_CI_Ontime_Count" runat="server" CssClass="btn btn-outline-success btn-sm btn-block font-weight-bold" ToolTip="C & I - Ontime Released DWG/Doc" Text="" Font-Bold="true"></asp:Button>
                  </div>
                  <div class="col-sm-2">
                    <asp:Button ID="btn_CI_Delayed_Count" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="C & I - Delayed Released DWG/Doc" Text="" Font-Bold="true"></asp:Button>
                  </div>
                </div>
              </div>
            </div>
          </div>

          <div class="container-fluid">
            <div class="row">
              <div class="col-md-2">
                <h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">Total </font></span></h6>
              </div>
              <div class="col-10">
                <div class="row">

                  <div class="col-sm-2">
                    <asp:Button ID="btn_Total_Total_Count" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="Total Doc in PMDL" Text="" Font-Bold="true"></asp:Button>
                  </div>
                  <div class="col-sm-2">
                    <asp:Button ID="btn_Total_Release_Count" runat="server" CssClass="btn btn-outline-primary btn-sm btn-block font-weight-bold" ToolTip="Total Released DWG/Doc in PMDL" Text="" Font-Bold="true"></asp:Button>
                  </div>
                  <div class="col-sm-2">
                    <asp:Button ID="btn_Total_Pending_Count" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Total Pending DWG/Doc to Release" Text="" Font-Bold="true"></asp:Button>
                  </div>
                  <div class="col-sm-2">
                    <asp:Button ID="btn_Total_Due_Count" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Total Due for Today DWG/Doc to Release" Text="" Font-Bold="true"></asp:Button>
                  </div>
                  <div class="col-sm-2">
                    <asp:Button ID="btn_Total_Ontime_Count" runat="server" CssClass="btn btn-outline-success btn-sm btn-block font-weight-bold" ToolTip="Total Ontime Released DWG/Doc" Text="" Font-Bold="true"></asp:Button>
                  </div>
                  <div class="col-sm-2">
                    <asp:Button ID="btn_Total_Delayed_Count" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Total Delayed Released DWG/Doc" Text="" Font-Bold="true"></asp:Button>
                  </div>
                </div>
              </div>
            </div>
          </div>

        </div>
      </div>

    </div>
      </div>
      <div class="tab-pane fade" id="v-pills-pmdl-g" role="tabpanel" aria-labelledby="PMDL_G">
              <div class="row" id="C1" runat="server" visible="false">
      <div class="col-sm-12 text-center ">
        <a class="chartDiv btn btn-outline-danger" id="PLMCHART" runat="server">
          <h5>Drawing Document Release Status </h5>
          <asp:Button ID="DPLMDATA" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Sorry !!! No Data in ERPLN" Text="" Font-Bold="true" Visible="false"></asp:Button>
          <asp:Chart
            ID="Chart1"
            Height="600px"
            Width="1050px"
            ClientIDMode="Predictable"
            runat="server">
            <Legends>
              <asp:Legend Name="Legend1" Docking="Bottom" IsDockedInsideChartArea="true">
                <Position Auto="True" />
              </asp:Legend>
            </Legends>
            <ChartAreas>
              <asp:ChartArea Name="ChartArea1" Area3DStyle-Enable3D="true" BackImageTransparentColor="WhiteSmoke" AlignmentOrientation="All" ShadowOffset="30">
              </asp:ChartArea>
            </ChartAreas>
          </asp:Chart>
          <div id="OverallDataTable" runat="server" class="container-fluid text-center"></div>
        </a>
      </div>
    </div>
      </div>
      <div class="tab-pane fade" id="v-pills-dcr-t" role="tabpanel" aria-labelledby="DCR_T">
         <div class="container text-center" id="DCRTABLE" runat="server" visible="false">
      <h5>DCR Progress Status Discipline Wise</h5>
      <div class="row">

        <div class="col-12">
          <asp:Button ID="DCRDATAI" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Sorry !!! No Data in ERPLN" Text="" Font-Bold="true" Visible="false"></asp:Button>
          </div>
         </div>
        
        <div class="container text-center" id="DCRTABLE1" runat="server" visible="false">
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

                    <div class="col-3">
                      <div class="text-dark">
                        <h6><b>Total DCR Count</b></h6>
                      </div>
                    </div>
                    <div class="col-3">
                      <div class="text-warning">
                        <h6><b>Under Creation</b></h6>
                      </div>
                    </div>
                    <div class="col-3">
                      <div class="text-danger">

                        <h6><b>Under Approval</b></h6>
                      </div>
                    </div>
                    <div class="col-3">
                      <div class="text-success">
                        <h6><b>Approved</b></h6>
                      </div>
                    </div>
                   
                  </div>
                </div>
                
              </div>
             

            <div class="container-fluid">
              <div class="row">
                <div class="col-2">
                  <h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">Process </font></span></h6>
                </div>
                <div class="col-10">
                  <div class="row">

                    <div class="col-3">
                      <asp:Button ID="btn_Process_DCR_Total_Count" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="Process - Total DCR" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-3">
                      <asp:Button ID="btn_Process_DCR_Under_Creation" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Process -DCR- Under Creation" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-3">
                      <asp:Button ID="btn_Process_DCR_Under_Approval" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Process -DCR- Under Approval" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-3">
                      <asp:Button ID="btn_Process_DCR_Approved" runat="server" CssClass="btn btn-outline-success btn-sm btn-block font-weight-bold" ToolTip="Process -DCR- Approved" Text="" Font-Bold="true"></asp:Button>
                    </div>
                   
                  </div>
                </div>
              </div>
            </div>

            <div class="container-fluid">
              <div class="row">
                <div class="col-2">
                  <h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">Mechanical </font></span></h6>
                </div>
                <div class="col-10">
                  <div class="row">

                    <div class="col-3">
                      <asp:Button ID="btn_Mechanical_DCR_Total_Count" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="Mechanical - Total DCR" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-3">
                      <asp:Button ID="btn_Mechanical_DCR_Under_Creation" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Mechanical -DCR- Under Creation" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-3">
                      <asp:Button ID="btn_Mechanical_DCR_Under_Approval" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Mechanical -DCR- Under Approval" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-3">
                      <asp:Button ID="btn_Mechanical_DCR_Approved" runat="server" CssClass="btn btn-outline-success btn-sm btn-block font-weight-bold" ToolTip="Mechanical -DCR- Approved" Text="" Font-Bold="true"></asp:Button>
                    </div>
                   
                  </div>
                </div>
              </div>
            </div>

            <div class="container-fluid">
              <div class="row">
                <div class="col-md-2">
                  <h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">Structure </font></span></h6>
                </div>
                <div class="col-10">
                  <div class="row">

                    <div class="col-3">
                      <asp:Button ID="btn_Structure_DCR_Total_Count" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="Structure - Total DCR" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-3">
                      <asp:Button ID="btn_Structure_DCR_Under_Creation" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Structure -DCR- Under Creation" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-3">
                      <asp:Button ID="btn_Structure_DCR_Under_Approval" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Structure -DCR- Under Approval" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-3">
                      <asp:Button ID="btn_Structure_DCR_Approved" runat="server" CssClass="btn btn-outline-success btn-sm btn-block font-weight-bold" ToolTip="Structure -DCR- Approved" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    
                  </div>
                </div>
              </div>
            </div>

            <div class="container-fluid">
              <div class="row">
                <div class="col-md-2">
                  <h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">Piping </font></span></h6>
                </div>
                <div class="col-10">
                  <div class="row">

                    <div class="col-3">
                      <asp:Button ID="btn_Piping_DCR_Total_Count" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="Piping - Total DCR" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-3">
                      <asp:Button ID="btn_Piping_DCR_Under_Creation" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Piping -DCR- Under Creation" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-3">
                      <asp:Button ID="btn_Piping_DCR_Under_Approval" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Piping -DCR- Under Approval" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-3">
                      <asp:Button ID="btn_Piping_DCR_Approved" runat="server" CssClass="btn btn-outline-success btn-sm btn-block font-weight-bold" ToolTip="Piping -DCR- Approved" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    
                  </div>
                </div>
              </div>
            </div>

            <div class="container-fluid">
              <div class="row">
                <div class="col-md-2">
                  <h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">Electrical </font></span></h6>
                </div>
                <div class="col-10">
                  <div class="row">

                   <div class="col-3">
                      <asp:Button ID="btn_Electrical_DCR_Total_Count" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="Electrical - Total DCR" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-3">
                      <asp:Button ID="btn_Electrical_DCR_Under_Creation" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Electrical -DCR- Under Creation" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-3">
                      <asp:Button ID="btn_Electrical_DCR_Under_Approval" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Electrical -DCR- Under Approval" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-3">
                      <asp:Button ID="btn_Electrical_DCR_Approved" runat="server" CssClass="btn btn-outline-success btn-sm btn-block font-weight-bold" ToolTip="Electrical -DCR- Approved" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    
                  </div>
                </div>
              </div>
            </div>


            <div class="container-fluid">
              <div class="row">
                <div class="col-md-2">
                  <h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">C & I </font></span></h6>
                </div>
                <div class="col-10">
                  <div class="row">

                    <div class="col-3">
                      <asp:Button ID="btn_CI_DCR_Total_Count" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="C & I - Total DCR" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-3">
                      <asp:Button ID="btn_CI_DCR_Under_Creation" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="C & I -DCR- Under Creation" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-3">
                      <asp:Button ID="btn_CI_DCR_Under_Approval" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="C & I -DCR- Under Approval" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-3">
                      <asp:Button ID="btn_CI_DCR_Approved" runat="server" CssClass="btn btn-outline-success btn-sm btn-block font-weight-bold" ToolTip="C & I -DCR- Approved" Text="" Font-Bold="true"></asp:Button>
                    </div>
                   
                  </div>
                </div>
              </div>
            </div>

            <div class="container-fluid">
              <div class="row">
                <div class="col-md-2">
                  <h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">Others </font></span></h6>
                </div>
                <div class="col-10">
                  <div class="row">

                     <div class="col-3">
                      <asp:Button ID="btn_Others_DCR_Total_Count" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="Others - Total DCR" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-3">
                      <asp:Button ID="btn_Others_DCR_Under_Creation" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Others -DCR- Under Creation" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-3">
                      <asp:Button ID="btn_Others_DCR_Under_Approval" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Others -DCR- Under Approval" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-3">
                      <asp:Button ID="btn_Others_DCR_Approved" runat="server" CssClass="btn btn-outline-success btn-sm btn-block font-weight-bold" ToolTip="Others -DCR- Approved" Text="" Font-Bold="true"></asp:Button>
                    </div>
                   
                  </div>
                </div>
              </div>
            </div>

           <div class="container-fluid">
              <div class="row">
                <div class="col-md-2">
                  <h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">Total </font></span></h6>
                </div>
                <div class="col-10">
                  <div class="row">

                    <div class="col-3">
                      <asp:Button ID="btn_Total_DCR_Total_Count" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="Total - Total DCR" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-3">
                      <asp:Button ID="btn_Total_DCR_Under_Creation" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Total -DCR- Under Creation" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-3">
                      <asp:Button ID="btn_Total_DCR_Under_Approval" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Total -DCR- Under Approval" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-3">
                      <asp:Button ID="btn_Total_DCR_Approved" runat="server" CssClass="btn btn-outline-success btn-sm btn-block font-weight-bold" ToolTip="Total -DCR- Approved" Text="" Font-Bold="true"></asp:Button>
                    </div>
                  </div>
                </div>
              </div>
            </div>


          </div>
        </div>
          </div>
       </div>
         </div>
      <div class="tab-pane fade" id="v-pills-dcr-g" role="tabpanel" aria-labelledby="DCR_G">
        
          <div class="row" id="C2" runat="server" visible="false">
      <div class="col-sm-12 text-center ">
        <a class="chartDiv btn btn-outline-success" id="DCRCHART" runat="server">
          <h5>DCR Status </h5>
          <asp:Button ID="DCRDATA" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Sorry !!! No Data in ERPLN" Text="" Font-Bold="true" Visible="false"></asp:Button>
          <asp:Chart
            ID="Chart2"
            Height="600px"
            Width="1050px"
            ClientIDMode="Predictable"
            runat="server">
            <Legends>
              <asp:Legend Name="Legend2" Docking="Bottom" IsDockedInsideChartArea="true">
                <Position Auto="True" />
              </asp:Legend>
            </Legends>
            <ChartAreas>
              <asp:ChartArea Name="ChartArea2" Area3DStyle-Enable3D="true" BackImageTransparentColor="WhiteSmoke" AlignmentOrientation="All" ShadowOffset="30">
              </asp:ChartArea>
            </ChartAreas>
          </asp:Chart>
          <div id="Div1" runat="server" class="container-fluid text-center"></div>
        </a>
      </div>
    </div>
         </div>
       <div class="tab-pane fade" id="v-pills-trans-t" role="tabpanel" aria-labelledby="TRANS_T">
           <div class="container text-center" id="TRANSMITTALTABLE" runat="server" visible="false">
      <h5>Transmittal Progress Status Discipline Wise</h5>
      <div class="row">

        <div class="col-12">
          <asp:Button ID="TRANSMITTALDATAI" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Sorry !!! No Data in ERPLN" Text="" Font-Bold="true" Visible="false"></asp:Button>
          </div>
         </div>
        
        <div class="container text-center" id="TRANSMITTALTABLE1" runat="server" visible="false">
          <div class="border border-dark btn-outline-light">
            <div class="container-fluid">

              <div class="row">
                 
                <div class="col-2">
                  <div class="text-dark">
                    <h6><b>Discipline</b></h6>
                  </div>
                </div>



                <div class="col-2">
                  <div class="text-dark">
                   <h6> <b>Total Transmittal Count</b></h6>
                  </div>
                </div>

             
                   
                    <div class="col-1">
                      <div class="text-info">
                      <h6>  <b>Free</b></h6>
                      </div>
                    </div>
                    <div class="col-1">
                      <div class="text-warning">
                      <h6>  <b>Under Approval</b></h6>
                      </div>
                    </div>
                    <div class="col-1">
                      <div class="text-danger">
                       <h6> <b>Under Issue</b></h6>
                      </div>
                    </div>
                    <div class="col-1">
                      <div class="text-success">
                       <h6> <b>Issued</b></h6>
                      </div>
                    </div>
                     <div class="col-1">
                      <div class="text-primary">
                       <h6> <b>Partial Received</b></h6>
                      </div>
                    </div>
                     <div class="col-1">
                      <div class="text-secondary">
                      <h6>  <b>Received</b></h6>
                      </div>
                    </div>
                     <div class="col-1">
                      <div class="text-secondary">
                      <h6>  <b>Closed</b></h6>
                      </div>
                    </div>
                     <div class="col-1">
                      <div class="text-secondary">
                        <h6><b>Returned</b></h6>
                      </div>
                    </div>






            
                
              

              </div>
             

            <div class="container-fluid text-center">
              <div class="row">
                <div class="col-2">
                  <h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">Process </font></span></h6>
                </div>
                

                    <div class="col-2">
                      <asp:Button ID="btn_Process_Transmittal_Total_Count" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="Process - Total Transmittal Count" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Process_Transmittal_Free" runat="server" CssClass="btn btn-outline-info btn-sm btn-block font-weight-bold" ToolTip="Process - Transmittal in Free State" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Process_Transmittal_Under_Approval" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Process - Transmittal in Under Approval State" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Process_Transmittal_Under_Issue" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Process - Transmittal in Under Issue State" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Process_Transmittal_Issued" runat="server" CssClass="btn btn-outline-success btn-sm btn-block font-weight-bold" ToolTip="Process - Transmittal - Issued" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Process_Transmittal_Partial_Received" runat="server" CssClass="btn btn-outline-primary btn-sm btn-block font-weight-bold" ToolTip="Process - Transmittal - Partial Recieved" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Process_Transmittal_Received" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Process - Transmittal - Recieved" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Process_Transmittal_Closed" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Process - Transmittal - Closed" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Process_Transmittal_Returned" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Process - Transmittal - Returned" Text="" Font-Bold="true"></asp:Button>
                    </div>
                   

                
              </div>
            </div>

            <div class="container-fluid">
              <div class="row">
                <div class="col-2">
                  <h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">Mechanical </font></span></h6>
                </div>
               

                    <div class="col-2">
                      <asp:Button ID="btn_Mechanical_Transmittal_Total_Count" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="Mechanical - Total Transmittal Count   " Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Mechanical_Transmittal_Free" runat="server" CssClass="btn btn-outline-info btn-sm btn-block font-weight-bold" ToolTip="Mechanical - Transmittal in Free State" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Mechanical_Transmittal_Under_Approval" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Mechanical - Transmittal in Under Approval State" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Mechanical_Transmittal_Under_Issue" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Mechanical - Transmittal in Under Issue State" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Mechanical_Transmittal_Issued" runat="server" CssClass="btn btn-outline-success btn-sm btn-block font-weight-bold" ToolTip="Mechanical - Transmittal - Issued" Text="" Font-Bold="true"></asp:Button>
                    </div>

                 <div class="col-1">
                      <asp:Button ID="btn_Mechanical_Transmittal_Partial_Received" runat="server" CssClass="btn btn-outline-primary btn-sm btn-block font-weight-bold" ToolTip="Mechanical - Transmittal - Partial Recieved" Text="" Font-Bold="true"></asp:Button>

                    </div>
                
                    <div class="col-1">
                      <asp:Button ID="btn_Mechanical_Transmittal_Received" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Mechanical - Transmittal - Recieved" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Mechanical_Transmittal_Closed" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Mechanical - Transmittal - Closed" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Mechanical_Transmittal_Returned" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Mechanical - Transmittal - Returned" Text="" Font-Bold="true"></asp:Button>
                    </div>
                   
                  </div>
               
            </div>

            <div class="container-fluid">
              <div class="row">
                <div class="col-md-2">
                  <h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">Structure </font></span></h6>
                </div>
               

                     <div class="col-2">
                      <asp:Button ID="btn_Structure_Transmittal_Total_Count" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="Structure - Total Transmittal Count   " Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Structure_Transmittal_Free" runat="server" CssClass="btn btn-outline-info btn-sm btn-block font-weight-bold" ToolTip="Structure - Transmittal in Free State" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Structure_Transmittal_Under_Approval" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Structure - Transmittal in Under Approval State" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Structure_Transmittal_Under_Issue" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Structure - Transmittal in Under Issue State" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Structure_Transmittal_Issued" runat="server" CssClass="btn btn-outline-success btn-sm btn-block font-weight-bold" ToolTip="Structure - Transmittal - Issued" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Structure_Transmittal_Partial_Received" runat="server" CssClass="btn btn-outline-primary btn-sm btn-block font-weight-bold" ToolTip="Structure - Transmittal - Partial Received" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Structure_Transmittal_Recieved" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Structure - Transmittal - Received" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Structure_Transmittal_Closed" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Structure - Transmittal - Closed" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Structure_Transmittal_Returned" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Structure - Transmittal - Returned" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    
               
              </div>
            </div>

            <div class="container-fluid">
              <div class="row">
                <div class="col-md-2">
                  <h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">Piping </font></span></h6>
                </div>
                <div class="col-2">
                      <asp:Button ID="btn_Piping_Transmittal_Total_Count" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="Piping - Total Transmittal Count" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Piping_Transmittal_Free" runat="server" CssClass="btn btn-outline-info btn-sm btn-block font-weight-bold" ToolTip="Piping - Transmittal in Free State" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Piping_Transmittal_Under_Approval" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Piping - Transmittal in Under Approval State" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Piping_Transmittal_Under_Issue" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Piping - Transmittal in Under Issue State" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Piping_Transmittal_Issued" runat="server" CssClass="btn btn-outline-success btn-sm btn-block font-weight-bold" ToolTip="Piping - Transmittal - Issued" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Piping_Transmittal_Partial_Received" runat="server" CssClass="btn btn-outline-primary btn-sm btn-block font-weight-bold" ToolTip="Piping - Transmittal - Partial Received" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Piping_Transmittal_Received" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Piping - Transmittal - Received" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Piping_Transmittal_Closed" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Piping - Transmittal - Closed" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Piping_Transmittal_Returned" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Piping - Transmittal - Returned" Text="" Font-Bold="true"></asp:Button>
                    </div>
              </div>
            </div>

            <div class="container-fluid">
              <div class="row">
                <div class="col-md-2">
                  <h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">Electrical </font></span></h6>
                </div>
                <div class="col-2">
                      <asp:Button ID="btn_Electrical_Transmittal_Total_Count" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="Electrical - Total Transmittal Count   " Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Electrical_Transmittal_Free" runat="server" CssClass="btn btn-outline-info btn-sm btn-block font-weight-bold" ToolTip="Electrical - Transmittal in Free State" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Electrical_Transmittal_Under_Approval" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Electrical - Transmittal in Under Approval State" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Electrical_Transmittal_Under_Issue" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Electrical - Transmittal in Under Issue State" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Electrical_Transmittal_Issued" runat="server" CssClass="btn btn-outline-success btn-sm btn-block font-weight-bold" ToolTip="Electrical - Transmittal - Issued" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Electrical_Transmittal_Partial_Received" runat="server" CssClass="btn btn-outline-primary btn-sm btn-block font-weight-bold" ToolTip="Electrical - Transmittal - Partial Received" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Electrical_Transmittal_Received" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Electrical - Transmittal - Received" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Electrical_Transmittal_Closed" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Electrical - Transmittal - Closed" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Electrical_Transmittal_Returned" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Electrical - Transmittal - Returned" Text="" Font-Bold="true"></asp:Button>
                    </div>
                </div>
              </div>
           

            <div class="container-fluid">
              <div class="row">
                <div class="col-md-2">
                  <h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">C & I </font></span></h6>
                </div>
               <div class="col-2">
                      <asp:Button ID="btn_CI_Transmittal_Total_Count" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="C & I - Total Transmittal Count   " Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_CI_Transmittal_Free" runat="server" CssClass="btn btn-outline-info btn-sm btn-block font-weight-bold" ToolTip="C & I - Transmittal in Free State" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_CI_Transmittal_Under_Approval" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="C & I - Transmittal in Under Approval State" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_CI_Transmittal_Under_Issue" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="C & I - Transmittal in Under Issue State" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_CI_Transmittal_Issued" runat="server" CssClass="btn btn-outline-success btn-sm btn-block font-weight-bold" ToolTip="C & I - Transmittal - Issued" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_CI_Transmittal_Partial_Received" runat="server" CssClass="btn btn-outline-primary btn-sm btn-block font-weight-bold" ToolTip="C & I - Transmittal - Partial Received" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_CI_Transmittal_Received" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="C & I - Transmittal - Received" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_CI_Transmittal_Closed" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="C & I - Transmittal - Closed" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_CI_Transmittal_Returned" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="C & I - Transmittal - Returned" Text="" Font-Bold="true"></asp:Button>
                    </div>
              </div>
            </div>

            <div class="container-fluid">
              <div class="row">
                <div class="col-md-2">
                  <h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">Others </font></span></h6>
                </div>
                <div class="col-2">
                      <asp:Button ID="btn_Others_Transmittal_Total_Count" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="Others - Total Transmittal Count   " Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Others_Transmittal_Free" runat="server" CssClass="btn btn-outline-info btn-sm btn-block font-weight-bold" ToolTip="Others - Transmittal in Free State" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Others_Transmittal_Under_Approval" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Others - Transmittal in Under Approval State" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Others_Transmittal_Under_Issue" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Others - Transmittal in Under Issue State" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Others_Transmittal_Issued" runat="server" CssClass="btn btn-outline-success btn-sm btn-block font-weight-bold" ToolTip="Others - Transmittal - Issued" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Others_Transmittal_Partial_Received" runat="server" CssClass="btn btn-outline-primary btn-sm btn-block font-weight-bold" ToolTip="Others - Transmittal - Partial Received" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Others_Transmittal_Received" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Others - Transmittal - Received" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Others_Transmittal_Closed" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Others - Transmittal - Closed" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Others_Transmittal_Returned" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Others - Transmittal - Returned" Text="" Font-Bold="true"></asp:Button>
                    </div>
              </div>
            </div>

           <div class="container-fluid">
              <div class="row">
                <div class="col-md-2">
                  <h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">Total </font></span></h6>
                </div>
                <div class="col-2">
                      <asp:Button ID="btn_Total_Transmittal_Total_Count" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="Total - Total Transmittal Count   " Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Total_Transmittal_Free" runat="server" CssClass="btn btn-outline-info btn-sm btn-block font-weight-bold" ToolTip="Total - Transmittal in Free State" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Total_Transmittal_Under_Approval" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Total - Transmittal in Under Approval State" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Total_Transmittal_Under_Issue" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Total - Transmittal in Under Issue State" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Total_Transmittal_Issued" runat="server" CssClass="btn btn-outline-success btn-sm btn-block font-weight-bold" ToolTip="Total - Transmittal - Issued" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Total_Transmittal_Partial_Received" runat="server" CssClass="btn btn-outline-primary btn-sm btn-block font-weight-bold" ToolTip="Total - Transmittal - Partial Received" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Total_Transmittal_Received" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Total - Transmittal - Received" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Total_Transmittal_Closed" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Total - Transmittal - Closed" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Total_Transmittal_Returned" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Total - Transmittal - Returned" Text="" Font-Bold="true"></asp:Button>
                    </div>
              </div>
            </div>


          </div>
        </div>
          </div>
       
</div>
             </div>
       <div class="tab-pane fade" id="v-pills-trans-g" role="tabpanel" aria-labelledby="TRANS_G">
          <div class="row" id="C3" runat="server" visible="false">
      <div class="col-sm-12 text-center ">
        <a class="chartDiv btn btn-outline-primary" id="IDMSCHART" runat="server">
          <h5>Drawing Document Transmittal Status </h5>
          <asp:Button ID="DTRANMITTALDATA" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Sorry !!! No Data in ERPLN" Text="" Font-Bold="true" Visible="false"></asp:Button>

          <asp:Chart
            ID="Chart3"
            Height="600px"
            Width="1050px"
            ClientIDMode="Predictable"
            runat="server">
            <Legends>
              <asp:Legend Name="Legend3" Docking="Bottom" IsDockedInsideChartArea="true">
                <Position Auto="True" />
              </asp:Legend>
            </Legends>
            <ChartAreas>
              <asp:ChartArea Name="ChartArea3" Area3DStyle-Enable3D="true" BackImageTransparentColor="WhiteSmoke" AlignmentOrientation="All" ShadowOffset="30">
              </asp:ChartArea>
            </ChartAreas>
          </asp:Chart>
          <div id="Div2" runat="server" class="container-fluid text-center"></div>
        </a>
      </div>

    </div>
             </div>
        <div class="tab-pane fade" id="v-pills-trans-tg" role="tabpanel" aria-labelledby="TRANS_TG">
            <div class="row" id="C4" runat="server" visible="false">
      <div class="col-sm-3 text-center ">
        <a class="chartDiv btn btn-outline-warning" id="IDMSCCHART" runat="server">
          <h5>Customer </h5>
          <asp:Button ID="CUSTOMERTRANSMITTALDATA" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Sorry !!! No Data in ERPLN" Text="" Font-Bold="true" Visible="false"></asp:Button>

          <asp:Chart
            ID="Chart31"
            Height="250px"
            Width="260px"
            ClientIDMode="Predictable"
            runat="server">
            <Legends>
              <asp:Legend Name="Legend31" Docking="Bottom" IsDockedInsideChartArea="true">
                <Position Auto="True" />
              </asp:Legend>
            </Legends>
            <ChartAreas>
              <asp:ChartArea Name="ChartArea31" Area3DStyle-Enable3D="true" BackImageTransparentColor="WhiteSmoke" AlignmentOrientation="All" ShadowOffset="30">
              </asp:ChartArea>
            </ChartAreas>
          </asp:Chart>
          <div id="Div31" runat="server" class="container-fluid text-center"></div>
        </a>
      </div>
      <div class="col-sm-3 text-center ">
        <a class="chartDiv btn btn-outline-warning" id="IDMSICHART" runat="server">
          <h5>Internal </h5>
          <asp:Button ID="INTERNALTRANSMITTALDATA" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Sorry !!! No Data in ERPLN" Text="" Font-Bold="true" Visible="false"></asp:Button>

          <asp:Chart
            ID="Chart32"
            Height="250px"
            Width="260px"
            ClientIDMode="Predictable"
            runat="server">
            <Legends>
              <asp:Legend Name="Legend32" Docking="Bottom" IsDockedInsideChartArea="true">
                <Position Auto="True" />
              </asp:Legend>
            </Legends>
            <ChartAreas>
              <asp:ChartArea Name="ChartArea32" Area3DStyle-Enable3D="true" BackImageTransparentColor="WhiteSmoke" AlignmentOrientation="All" ShadowOffset="30">
              </asp:ChartArea>
            </ChartAreas>
          </asp:Chart>
          <div id="Div32" runat="server" class="container-fluid text-center"></div>
        </a>
      </div>
      <div class="col-sm-3 text-center ">
        <a class="chartDiv btn btn-outline-warning" id="IDMSSCHART" runat="server">
          <h5>Site </h5>
          <asp:Button ID="SITETRANSMITTALDATA" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Sorry !!! No Data in ERPLN" Text="" Font-Bold="true" Visible="false"></asp:Button>

          <asp:Chart
            ID="Chart33"
            Height="250px"
            Width="260px"
            ClientIDMode="Predictable"
            runat="server">
            <Legends>
              <asp:Legend Name="Legend33" Docking="Bottom" IsDockedInsideChartArea="true">
                <Position Auto="True" />
              </asp:Legend>
            </Legends>
            <ChartAreas>
              <asp:ChartArea Name="ChartArea33" Area3DStyle-Enable3D="true" BackImageTransparentColor="WhiteSmoke" AlignmentOrientation="All" ShadowOffset="30">
              </asp:ChartArea>
            </ChartAreas>
          </asp:Chart>
          <div id="Div33" runat="server" class="container-fluid text-center"></div>
        </a>
      </div>

      <div class="col-sm-3 text-center ">
        <a class="chartDiv btn btn-outline-warning" id="IDMSVCHART" runat="server">
          <h5>Vendor </h5>
          <asp:Button ID="VENDORTRANSMITTALDATA" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Sorry !!! No Data in ERPLN" Text="" Font-Bold="true" Visible="false"></asp:Button>

          <asp:Chart
            ID="Chart34"
            Height="250px"
            Width="260px"
            ClientIDMode="Predictable"
            IsMapEnabled="true"
            runat="server">
            <Legends>
              <asp:Legend Name="Legend34" Docking="Bottom" IsDockedInsideChartArea="true">
                <Position Auto="True" />
              </asp:Legend>
            </Legends>
            <ChartAreas>
              <asp:ChartArea Name="ChartArea34" Area3DStyle-Enable3D="true" BackImageTransparentColor="WhiteSmoke" AlignmentOrientation="All" ShadowOffset="30">
              </asp:ChartArea>
            </ChartAreas>
          </asp:Chart>
          <div id="Div34" runat="server" class="container-fluid text-center"></div>
        </a>
      </div>
    </div>
           </div>
       <div class="tab-pane fade" id="v-pills-trans-ti" role="tabpanel" aria-labelledby="TRANS_TI">
            <div class="row" id="C5" runat="server" visible="false">
      <div class="col-sm-12 text-center ">
        <a class="chartDiv btn btn-outline-success" id="IDMSIICHART" runat="server">
          <h5>Transmittal Issued </h5>
          <asp:Button ID="ITRANSMITTALDATA" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Sorry !!! No Data in ERPLN" Text="" Font-Bold="true" Visible="false"></asp:Button>

          <asp:Chart
            ID="Chart8"
            Height="600px"
            Width="1050px"
            ClientIDMode="Predictable"
            runat="server">
            <Legends>
              <asp:Legend Name="Legend8" Docking="Bottom" IsDockedInsideChartArea="true">
                <Position Auto="True" />
              </asp:Legend>
            </Legends>
            <ChartAreas>
              <asp:ChartArea Name="ChartArea8" Area3DStyle-Enable3D="true" BackImageTransparentColor="WhiteSmoke" AlignmentOrientation="All" ShadowOffset="30">
              </asp:ChartArea>
            </ChartAreas>
          </asp:Chart>
          <div id="Div8" runat="server" class="container-fluid text-center"></div>
        </a>
      </div>
    </div>
         </div>

       <div class="tab-pane fade" id="v-pills-ped" role="tabpanel" aria-labelledby="PED">
            <div class="row" id="C12" runat="server"  style="display:none;" clientidmode="Static">
      <div class="col-sm-12 text-center ">
        <a class="chartDiv btn btn-outline-primary" id="PSTRANMITTALCHART" runat="server"  style="display:none;" clientidmode="Static">
          <h5>Pending Site Transmittal Status </h5>
          <asp:Button ID="PSTRANMITTALDATA" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Sorry !!! No Data in ERPLN" Text="" Font-Bold="true"  style="display:none;" clientidmode="Static"></asp:Button>

          <asp:Chart
            ID="Chart9"
            Height="600px"
            Width="1050px"
            ClientIDMode="Predictable"
            runat="server">
            <Legends>
              <asp:Legend Name="Legend12" Docking="Bottom" IsDockedInsideChartArea="true">
                <Position Auto="True" />
              </asp:Legend>
            </Legends>
            <ChartAreas>
              <asp:ChartArea Name="ChartArea12" Area3DStyle-Enable3D="true" BackImageTransparentColor="WhiteSmoke" AlignmentOrientation="All" ShadowOffset="30">
              </asp:ChartArea>
            </ChartAreas>
          </asp:Chart>
          <div id="Div9" runat="server" class="container-fluid text-center"></div>
        </a>
      </div>

    </div>
   
      <div class="container text-center" id="PSTRANSMITTALTABLE" runat="server" visible="false">
      <h5>Pending issue Status of Erection drawings Discipline Wise</h5>
      <div class="row">

        <div class="col-12">
          <asp:Button ID="PSTRANSMITTALDATAI" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Sorry !!! No Data in ERPLN" Text="" Font-Bold="true"   visible="false"></asp:Button>
          </div>
         </div>
        
        <div class="container text-center" id="PSTRANSMITTALTABLE1" runat="server" visible="false">
          <div class="border border-dark btn-outline-light">
            <div class="container-fluid">

              <div class="row">
                 
                <div class="col-2">
                  <div class="text-dark">
                    <h6><b>Discipline</b></h6>
                  </div>
                </div>



                <div class="col-2">
                  <div class="text-dark">
                    <h6><b>Total Drawing Count</b></h6>
                  </div>
                </div>

             
                   
                    <div class="col-2">
                      <div class="text-info">
                       <h6> <b>Pending Drawing Count</b></h6>
                      </div>
                    </div>
                   


              </div>
             

            <div class="container-fluid text-center">
              <div class="row">
                <div class="col-2">
                  <h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">Process </font></span></h6>
                </div>
                

                    <div class="col-2">
                      <asp:Button ID="btn_Process_PSTransmittal_Total_Drawing_Count" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="Process - Total Site Drawing Count" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-2">
                      <asp:Button ID="btn_Process_PSTransmittal_Pending_Drawing_Count" runat="server" CssClass="btn btn-outline-info btn-sm btn-block font-weight-bold" ToolTip="Process - Site Transmittal Pending - Drawing Count" Text="" Font-Bold="true"></asp:Button>
                    </div>
                   
                    
                   

                
              </div>
            </div>

            <div class="container-fluid">
              <div class="row">
                <div class="col-2">
                  <h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">Mechanical </font></span></h6>
                </div>
               

                   <div class="col-2">
                      <asp:Button ID="btn_Mechanical_PSTransmittal_Total_Drawing_Count" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="Process - Total Site Drawing Count" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-2">
                      <asp:Button ID="btn_Mechanical_PSTransmittal_Pending_Drawing_Count" runat="server" CssClass="btn btn-outline-info btn-sm btn-block font-weight-bold" ToolTip="Process - Site Transmittal Pending - Drawing Count" Text="" Font-Bold="true"></asp:Button>
                    </div>
                   
                
                   
                   
                  </div>
               
            </div>

            <div class="container-fluid">
              <div class="row">
                <div class="col-md-2">
                  <h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">Structure </font></span></h6>
                </div>
               

                    <div class="col-2">
                      <asp:Button ID="btn_Structure_PSTransmittal_Total_Drawing_Count" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="Structure - Total Site Drawing Count" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-2">
                      <asp:Button ID="btn_Structure_PSTransmittal_Pending_Drawing_Count" runat="server" CssClass="btn btn-outline-info btn-sm btn-block font-weight-bold" ToolTip="Structure - Site Transmittal Pending - Drawing Count" Text="" Font-Bold="true"></asp:Button>
                    </div>
                   
               
              </div>
            </div>

            <div class="container-fluid">
              <div class="row">
                <div class="col-md-2">
                  <h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">Piping </font></span></h6>
                </div>
                  <div class="col-2">
                      <asp:Button ID="btn_Piping_PSTransmittal_Total_Drawing_Count" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="Piping - Total Site Drawing Count" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-2">
                      <asp:Button ID="btn_Piping_PSTransmittal_Pending_Drawing_Count" runat="server" CssClass="btn btn-outline-info btn-sm btn-block font-weight-bold" ToolTip="Piping - Site Transmittal Pending - Drawing Count" Text="" Font-Bold="true"></asp:Button>
                    </div>
                   
              </div>
            </div>

            <div class="container-fluid">
              <div class="row">
                <div class="col-md-2">
                  <h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">Electrical </font></span></h6>
                </div>
               <div class="col-2">
                      <asp:Button ID="btn_Electrical_PSTransmittal_Total_Drawing_Count" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="Electrical - Total Site Drawing Count" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-2">
                      <asp:Button ID="btn_Electrical_PSTransmittal_Pending_Drawing_Count" runat="server" CssClass="btn btn-outline-info btn-sm btn-block font-weight-bold" ToolTip="Electrical - Site Transmittal Pending - Drawing Count" Text="" Font-Bold="true"></asp:Button>
                    </div>
                   
                </div>
              </div>
           

            <div class="container-fluid">
              <div class="row">
                <div class="col-md-2">
                  <h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">C & I </font></span></h6>
                </div>
               <div class="col-2">
                      <asp:Button ID="btn_CI_PSTransmittal_Total_Drawing_Count" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="C&I - Total Site Drawing Count" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-2">
                      <asp:Button ID="btn_CI_PSTransmittal_Pending_Drawing_Count" runat="server" CssClass="btn btn-outline-info btn-sm btn-block font-weight-bold" ToolTip="C&I - Site Transmittal Pending - Drawing Count" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    
              </div>
            </div>

            <div class="container-fluid">
              <div class="row">
                <div class="col-md-2">
                  <h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">Others </font></span></h6>
                </div>
                <div class="col-2">
                      <asp:Button ID="btn_Others_PSTransmittal_Total_Drawing_Count" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="Others - Total Site Drawing Count" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-2">
                      <asp:Button ID="btn_Others_PSTransmittal_Pending_Drawing_Count" runat="server" CssClass="btn btn-outline-info btn-sm btn-block font-weight-bold" ToolTip="Others - Site Transmittal Pending - Drawing Count" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    
              </div>
            </div>

           <div class="container-fluid">
              <div class="row">
                <div class="col-md-2">
                  <h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">Total </font></span></h6>
                </div>
                <div class="col-2">
                      <asp:Button ID="btn_Total_PSTransmittal_Total_Drawing_Count" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="Total Site Drawing Count" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-2">
                      <asp:Button ID="btn_Total_PSTransmittal_Pending_Drawing_Count" runat="server" CssClass="btn btn-outline-info btn-sm btn-block font-weight-bold" ToolTip="Site Transmittal Pending - Drawing Count" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    
              </div>
            </div>


          </div>
        </div>
          </div>
       
</div>
          </div>
       <div class="tab-pane fade" id="v-pills-sar-g" role="tabpanel" aria-labelledby="SAR_G">
             <div class="row" id="C6" runat="server" visible="false">
      <div class="col-sm-12 text-center ">
        <a class="chartDiv btn btn-outline-primary" id="SARCHART" runat="server">

          <h5>SAR Status </h5>
          <asp:Button ID="SARDATA" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Sorry !!! No Data in ERPLN" Text="" Font-Bold="true" Visible="false"></asp:Button>
          <asp:Chart
            ID="Chart4"
            Height="600px"
            Width="1050px"
            ClientIDMode="Predictable"
            runat="server">
            <Legends>
              <asp:Legend Name="Legend4" Docking="Bottom" IsDockedInsideChartArea="true">
                <Position Auto="True" />
              </asp:Legend>
            </Legends>
            <ChartAreas>
              <asp:ChartArea Name="ChartArea4" Area3DStyle-Enable3D="true" BackImageTransparentColor="WhiteSmoke" AlignmentOrientation="All" ShadowOffset="30">
              </asp:ChartArea>
            </ChartAreas>
          </asp:Chart>
          <div id="Div3" runat="server" class="container-fluid text-center"></div>
        </a>
      </div>
    </div>
         </div>
      <div class="tab-pane fade" id="v-pills-sar-t" role="tabpanel" aria-labelledby="SAR_T">
                    <div class="container text-center" id="SARTABLE" runat="server" visible="false">
      <h5>SAR Progress Status Discipline Wise</h5>
      <div class="row">

        <div class="col-12">
          <asp:Button ID="SARDATAI" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Sorry !!! No Data in ERPLN" Text="" Font-Bold="true" Visible="false"></asp:Button>
          </div>
         </div>
        
        <div class="container text-center" id="SARTABLE1" runat="server" visible="false">
          <div class="border border-dark btn-outline-light">
            <div class="container-fluid">

              <div class="row">
                 
                <div class="col-2">
                  <div class="text-secondary">
                    <h6><b>Discipline</b></h6>
                  </div>
                </div>



                <div class="col-10">
                   <div class="row">
                     <div class="col-2">
                       <div class="text-dark">
                         <h6><b>Total SAR Count</b></h6>
                       </div>
                     </div>

                     <div class="col-2">
                       <div class="text-info">
                        <h6> <b>Created</b></h6>
                       </div>
                     </div>
                     <div class="col-2">
                       <div class="text-warning">
                        <h6> <b>Under Review</b></h6>
                       </div>
                     </div>
                     <div class="col-2">
                       <div class="text-danger">
                        <h6> <b>Under Approval</b></h6>
                       </div>
                     </div>
                     <div class="col-2">
                       <div class="text-success">
                         <h6><b>Approved</b></h6>
                       </div>
                     </div>
                     <div class="col-2">
                       <div class="text-secondary">
                         <h6><b>Not Applicable</b></h6>
                       </div>
                     </div>
                        </div>
                    </div>
              </div>
             

            <div class="container-fluid text-center">
              <div class="row">
                <div class="col-2">
                  <h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">Process </font></span></h6>
                </div>
                <div class="col-10">
                   <div class="row">
                    <div class="col-2">
                      <asp:Button ID="btn_Process_SAR_Total_Count" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="Process - Total SAR Count" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-2">
                      <asp:Button ID="btn_Process_SAR_Under_Creation" runat="server" CssClass="btn btn-outline-info btn-sm btn-block font-weight-bold" ToolTip="Process - SAR - Under Creation" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-2">
                      <asp:Button ID="btn_Process_SAR_Under_Review" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Process - SAR - Under Review" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-2">
                      <asp:Button ID="btn_Process_SAR_Under_Approval" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Process - SAR - Under Approval" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-2">
                      <asp:Button ID="btn_Process_SAR_Approved" runat="server" CssClass="btn btn-outline-success btn-sm btn-block font-weight-bold" ToolTip="Process - SAR - Approved" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-2">
                      <asp:Button ID="btn_Process_SAR_Not_Applicable" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Process - SAR - Not Applicable" Text="" Font-Bold="true"></asp:Button>
                    </div>
                   
                   
 </div>
            </div>
                
              </div>
            </div>

            <div class="container-fluid">
              <div class="row">
                <div class="col-2">
                  <h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">Mechanical </font></span></h6>
                </div>
               

                    <div class="col-10">
                   <div class="row">
                    <div class="col-2">
                      <asp:Button ID="btn_Mechanical_SAR_Total_Count" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="Mechanical - Total SAR Count" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-2">
                      <asp:Button ID="btn_Mechanical_SAR_Under_Creation" runat="server" CssClass="btn btn-outline-info btn-sm btn-block font-weight-bold" ToolTip="Mechanical - SAR - Under Creation" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-2">
                      <asp:Button ID="btn_Mechanical_SAR_Under_Review" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Mechanical - SAR - Under Review" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-2">
                      <asp:Button ID="btn_Mechanical_SAR_Under_Approval" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Mechanical - SAR - Under Approval" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-2">
                      <asp:Button ID="btn_Mechanical_SAR_Approved" runat="server" CssClass="btn btn-outline-success btn-sm btn-block font-weight-bold" ToolTip="Mechanical - SAR - Approved" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-2">
                      <asp:Button ID="btn_Mechanical_SAR_Not_Applicable" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Mechanical - SAR - Not Applicable" Text="" Font-Bold="true"></asp:Button>
                    </div>
                   
                   
 </div>
            </div>
                    
                   
                  </div>
               
            </div>

            <div class="container-fluid">
              <div class="row">
                <div class="col-md-2">
                  <h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">Structure </font></span></h6>
                </div>
               

                     <div class="col-10">
                   <div class="row">
                    <div class="col-2">
                      <asp:Button ID="btn_Structure_SAR_Total_Count" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="Structure - Total SAR Count" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-2">
                      <asp:Button ID="btn_Structure_SAR_Under_Creation" runat="server" CssClass="btn btn-outline-info btn-sm btn-block font-weight-bold" ToolTip="Structure - SAR - Under Creation" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-2">
                      <asp:Button ID="btn_Structure_SAR_Under_Review" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Structure - SAR - Under Review" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-2">
                      <asp:Button ID="btn_Structure_SAR_Under_Approval" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Structure - SAR - Under Approval" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-2">
                      <asp:Button ID="btn_Structure_SAR_Approved" runat="server" CssClass="btn btn-outline-success btn-sm btn-block font-weight-bold" ToolTip="Structure - SAR - Approved" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-2">
                      <asp:Button ID="btn_Structure_SAR_Not_Applicable" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Structure - SAR - Not Applicable" Text="" Font-Bold="true"></asp:Button>
                    </div>
                   
                   
 </div>
            </div>
                    
               
              </div>
            </div>

            <div class="container-fluid">
              <div class="row">
                <div class="col-md-2">
                  <h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">Piping </font></span></h6>
                </div>
                <div class="col-10">
                   <div class="row">
                   <div class="col-2">
                      <asp:Button ID="btn_Piping_SAR_Total_Count" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="Piping - Total SAR Count" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-2">
                      <asp:Button ID="btn_Piping_SAR_Under_Creation" runat="server" CssClass="btn btn-outline-info btn-sm btn-block font-weight-bold" ToolTip="Piping - SAR - Under Creation" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-2">
                      <asp:Button ID="btn_Piping_SAR_Under_Review" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Piping - SAR - Under Review" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-2">
                      <asp:Button ID="btn_Piping_SAR_Under_Approval" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Piping - SAR - Under Approval" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-2">
                      <asp:Button ID="btn_Piping_SAR_Approved" runat="server" CssClass="btn btn-outline-success btn-sm btn-block font-weight-bold" ToolTip="Piping - SAR - Approved" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-2">
                      <asp:Button ID="btn_Piping_SAR_Not_Applicable" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Piping - SAR - Not Applicable" Text="" Font-Bold="true"></asp:Button>
                    </div>
                   
                   
 </div>
            </div>
              </div>
            </div>

            <div class="container-fluid">
              <div class="row">
                <div class="col-md-2">
                  <h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">Electrical </font></span></h6>
                </div>
                <div class="col-10">
                   <div class="row">
                   <div class="col-2">
                      <asp:Button ID="btn_Electrical_SAR_Total_Count" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="Electrical - Total SAR Count" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-2">
                      <asp:Button ID="btn_Electrical_SAR_Under_Creation" runat="server" CssClass="btn btn-outline-info btn-sm btn-block font-weight-bold" ToolTip="Electrical - SAR - Under Creation" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-2">
                      <asp:Button ID="btn_Electrical_SAR_Under_Review" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Electrical - SAR - Under Review" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-2">
                      <asp:Button ID="btn_Electrical_SAR_Under_Approval" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Electrical - SAR - Under Approval" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-2">
                      <asp:Button ID="btn_Electrical_SAR_Approved" runat="server" CssClass="btn btn-outline-success btn-sm btn-block font-weight-bold" ToolTip="Electrical - SAR - Approved" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-2">
                      <asp:Button ID="btn_Electrical_SAR_Not_Applicable" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Electrical - SAR - Not Applicable" Text="" Font-Bold="true"></asp:Button>
                    </div>
                   
                   
 </div>
            </div>
                </div>
              </div>
           

            <div class="container-fluid">
              <div class="row">
                <div class="col-md-2">
                  <h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">C & I </font></span></h6>
                </div>
               <div class="col-10">
                   <div class="row">
                     <div class="col-2">
                      <asp:Button ID="btn_CI_SAR_Total_Count" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="C & I - Total SAR Count" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-2">
                      <asp:Button ID="btn_CI_SAR_Under_Creation" runat="server" CssClass="btn btn-outline-info btn-sm btn-block font-weight-bold" ToolTip="C & I - SAR - Under Creation" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-2">
                      <asp:Button ID="btn_CI_SAR_Under_Review" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="C & I - SAR - Under Review" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-2">
                      <asp:Button ID="btn_CI_SAR_Under_Approval" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="C & I - SAR - Under Approval" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-2">
                      <asp:Button ID="btn_CI_SAR_Approved" runat="server" CssClass="btn btn-outline-success btn-sm btn-block font-weight-bold" ToolTip="C & I - SAR - Approved" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-2">
                      <asp:Button ID="btn_CI_SAR_Not_Applicable" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="C & I - SAR - Not Applicable" Text="" Font-Bold="true"></asp:Button>
                    </div>
                   
                   
 </div>
            </div>
              </div>
            </div>

            <div class="container-fluid">
              <div class="row">
                <div class="col-md-2">
                  <h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">Others </font></span></h6>
                </div>
                <div class="col-10">
                   <div class="row">
                   <div class="col-2">
                      <asp:Button ID="btn_Others_SAR_Total_Count" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="Others - Total SAR Count" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-2">
                      <asp:Button ID="btn_Others_SAR_Under_Creation" runat="server" CssClass="btn btn-outline-info btn-sm btn-block font-weight-bold" ToolTip="Others - SAR - Under Creation" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-2">
                      <asp:Button ID="btn_Others_SAR_Under_Review" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Others - SAR - Under Review" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-2">
                      <asp:Button ID="btn_Others_SAR_Under_Approval" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Others - SAR - Under Approval" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-2">
                      <asp:Button ID="btn_Others_SAR_Approved" runat="server" CssClass="btn btn-outline-success btn-sm btn-block font-weight-bold" ToolTip="Others - SAR - Approved" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-2">
                      <asp:Button ID="btn_Others_SAR_Not_Applicable" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Others - SAR - Not Applicable" Text="" Font-Bold="true"></asp:Button>
                    </div>
                   
                   
 </div>
            </div>
              </div>
            </div>

           <div class="container-fluid">
              <div class="row">
                <div class="col-md-2">
                  <h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">Total </font></span></h6>
                </div>
                <div class="col-10">
                   <div class="row">
                    <div class="col-2">
                      <asp:Button ID="btn_Total_SAR_Total_Count" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="Total - Total SAR Count" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-2">
                      <asp:Button ID="btn_Total_SAR_Under_Creation" runat="server" CssClass="btn btn-outline-info btn-sm btn-block font-weight-bold" ToolTip="Total - SAR - Under Creation" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-2">
                      <asp:Button ID="btn_Total_SAR_Under_Review" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Total - SAR - Under Review" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-2">
                      <asp:Button ID="btn_Total_SAR_Under_Approval" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Total - SAR - Under Approval" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-2">
                      <asp:Button ID="btn_Total_SAR_Approved" runat="server" CssClass="btn btn-outline-success btn-sm btn-block font-weight-bold" ToolTip="Total - SAR - Approved" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-2">
                      <asp:Button ID="btn_Total_SAR_Not_Applicable" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Total - SAR - Not Applicable" Text="" Font-Bold="true"></asp:Button>
                    </div>
                   
                   
 </div>
            </div>
              </div>
            </div>


          </div>
        </div>
          </div>
       
</div>
         </div>
       <div class="tab-pane fade" id="v-pills-idms-pg" role="tabpanel" aria-labelledby="IDMS_PT">
             <div class="row" id="C7" runat="server" visible="false">
      <div class="col-sm-12 text-center ">
        <a class="chartDiv btn btn-outline-primary" id="IDMSPCHART" runat="server">
          <h5>IDMS Pre-Order Status </h5>
          <asp:Button ID="IDMSP" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Sorry !!! No Data in ERPLN" Text="" Font-Bold="true" Visible="false"></asp:Button>

          <asp:Chart
            ID="Chart5"
            Height="600px"
            Width="1050px"
            ClientIDMode="Predictable"
            runat="server">
            <Legends>
              <asp:Legend Name="Legend5" Docking="Bottom" IsDockedInsideChartArea="true">
                <Position Auto="True" />
              </asp:Legend>
            </Legends>
            <ChartAreas>
              <asp:ChartArea Name="ChartArea5" Area3DStyle-Enable3D="true" BackImageTransparentColor="WhiteSmoke" AlignmentOrientation="All" ShadowOffset="30">
              </asp:ChartArea>
            </ChartAreas>
          </asp:Chart>
          <div id="Div4" runat="server" class="container-fluid text-center"></div>
        </a>
      </div>
    </div>
          </div>
       <div class="tab-pane fade" id="v-pills-idms-pt" role="tabpanel" aria-labelledby="IDMS_PT">
              <div class="container text-center" id="IDMSPTABLE" runat="server" visible="false">
      <h5>Pre Order Receipt Progress Status Discipline Wise</h5>
      <div class="row">

        <div class="col-12">
          <asp:Button ID="IDMSPDATAI" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Sorry !!! No Data in ERPLN" Text="" Font-Bold="true" Visible="false"></asp:Button>
          </div>
         </div>
        
        <div class="container text-center" id="IDMSPTABLE1" runat="server" visible="false">
          <div class="border border-dark btn-outline-light">
            <div class="container-fluid">

              <div class="row">
                 
                <div class="col-2">
                  <div class="text-secondary">
                    <h6><b>Discipline</b></h6>
                  </div>
                </div>



                <div class="col-2">
                  <div class="text-secondary">
                  <b>Total Receipt Count</b>
                  </div>
                </div>

             
                   
                    <div class="col-1">
                      <div class="text-primary">
                       <b>Submitted</b>
                      </div>
                    </div>
                    <div class="col-1">
                      <div class="text-warning">
                        <b>Document Linked</b>
                      </div>
                    </div>
                    <div class="col-1">
                      <div class="text-secondary">
                      <b>Under Evaluation</b>
                      </div>
                    </div>
                    <div class="col-1">
                      <div class="text-secondary">
                       <b>Comments Submitted</b>
                      </div>
                    </div>
                     <div class="col-1">
                      <div class="text-secondary">
                       <b>Technically Cleared</b>
                      </div>
                    </div>
                     <div class="col-1">
                      <div class="text-secondary">
                       <b>Transmittal Issued</b>
                      </div>
                    </div>
                     <div class="col-1">
                      <div class="text-secondary">
                        <b>Superceded</b>
                      </div>
                    </div>
                     <div class="col-1">
                      <div class="text-secondary">
                       <b>Closed</b>
                      </div>
                    </div>






            
                
              

              </div>
             

            <div class="container-fluid">
              <div class="row">
                <div class="col-2">
                  <h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">Process </font></span></h6>
                </div>
                

                   <div class="col-2">
                      <asp:Button ID="btn_Process_IDMSP_Total_Count" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="Process - Pre Order Receipt - Total Count" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Process_IDMSP_Submitted" runat="server" CssClass="btn btn-outline-primary btn-sm btn-block font-weight-bold" ToolTip="Process - Pre Order Receipt - Submitted" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Process_IDMSP_Document_linked" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Process - Pre Order Receipt - Document Linked" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Process_IDMSP_Under_Evaluation" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Process - Pre Order Receipt - Under Evaluation" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Process_IDMSP_Comments_Submitted" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Process - Pre Order Receipt - Comments Submitted" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Process_IDMSP_Technically_Cleared" runat="server" CssClass="btn btn-outline-primary btn-sm btn-block font-weight-bold" ToolTip="Process - Pre Order Receipt - Technically Cleared" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Process_IDMSP_Transmittal_Issued" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Process - Pre Order Receipt - Transmittal Issued" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Process_IDMSP_Superceded" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Process - Pre Order Receipt - Superceded" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Process_IDMSP_Closed" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Process - Pre Order Receipt - Closed" Text="" Font-Bold="true"></asp:Button>
                    </div>
                   

                
              </div>
            </div>

            <div class="container-fluid">
              <div class="row">
                <div class="col-2">
                  <h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">Mechanical </font></span></h6>
                </div>
               

                   
 		               <div class="col-2">
                      <asp:Button ID="btn_Mechanical_IDMSP_Total_Count" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="Mechanical - Pre Order Receipt - Total Count" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Mechanical_IDMSP_Submitted" runat="server" CssClass="btn btn-outline-primary btn-sm btn-block font-weight-bold" ToolTip="Mechanical - Pre Order Receipt - Submitted" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Mechanical_IDMSP_Document_linked" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Mechanical - Pre Order Receipt - Document Linked" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Mechanical_IDMSP_Under_Evaluation" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Mechanical - Pre Order Receipt - Under Evaluation" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Mechanical_IDMSP_Comments_Submitted" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Mechanical - Pre Order Receipt - Comments Submitted" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Mechanical_IDMSP_Technically_Cleared" runat="server" CssClass="btn btn-outline-primary btn-sm btn-block font-weight-bold" ToolTip="Mechanical - Pre Order Receipt - Technically Cleared" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Mechanical_IDMSP_Transmittal_Issued" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Mechanical - Pre Order Receipt - Transmittal Issued" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Mechanical_IDMSP_Superceded" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Mechanical - Pre Order Receipt - Superceded" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Mechanical_IDMSP_Closed" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Mechanical - Pre Order Receipt - Closed" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    
                   
                  </div>
               
            </div>

            <div class="container-fluid">
              <div class="row">
                <div class="col-md-2">
                  <h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">Structure </font></span></h6>
                </div>
               

                     <div class="col-2">
                      <asp:Button ID="btn_Structure_IDMSP_Total_Count" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="Structure - Pre Order Receipt - Total Count" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Structure_IDMSP_Submitted" runat="server" CssClass="btn btn-outline-primary btn-sm btn-block font-weight-bold" ToolTip="Structure - Pre Order Receipt - Submitted" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Structure_IDMSP_Document_linked" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Structure - Pre Order Receipt - Document Linked" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Structure_IDMSP_Under_Evaluation" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Structure - Pre Order Receipt - Under Evaluation" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Structure_IDMSP_Comments_Submitted" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Structure - Pre Order Receipt - Comments Submitted" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Structure_IDMSP_Technically_Cleared" runat="server" CssClass="btn btn-outline-primary btn-sm btn-block font-weight-bold" ToolTip="Structure - Pre Order Receipt - Technically Cleared" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Structure_IDMSP_Transmittal_Issued" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Structure - Pre Order Receipt - Transmittal Issued" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Structure_IDMSP_Superceded" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Structure - Pre Order Receipt - Superceded" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Structure_IDMSP_Closed" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Structure - Pre Order Receipt - Closed" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    
               
              </div>
            </div>

            <div class="container-fluid">
              <div class="row">
                <div class="col-md-2">
                  <h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">Piping </font></span></h6>
                </div>
                <div class="col-2">
                      <asp:Button ID="btn_Piping_IDMSP_Total_Count" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="Piping - Pre Order Receipt - Total Count" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Piping_IDMSP_Submitted" runat="server" CssClass="btn btn-outline-primary btn-sm btn-block font-weight-bold" ToolTip="Piping - Pre Order Receipt - Submitted" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Piping_IDMSP_Document_linked" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Piping - Pre Order Receipt - Document Linked" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Piping_IDMSP_Under_Evaluation" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Piping - Pre Order Receipt - Under Evaluation" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Piping_IDMSP_Comments_Submitted" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Piping - Pre Order Receipt - Comments Submitted" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Piping_IDMSP_Technically_Cleared" runat="server" CssClass="btn btn-outline-primary btn-sm btn-block font-weight-bold" ToolTip="Piping - Pre Order Receipt - Technically Cleared" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Piping_IDMSP_Transmittal_Issued" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Piping - Pre Order Receipt - Transmittal Issued" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Piping_IDMSP_Superceded" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Piping - Pre Order Receipt - Superceded" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Piping_IDMSP_Closed" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Piping - Pre Order Receipt - Closed" Text="" Font-Bold="true"></asp:Button>
                    </div>
              </div>
            </div>

            <div class="container-fluid">
              <div class="row">
                <div class="col-md-2">
                  <h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">Electrical </font></span></h6>
                </div>
               
 		    <div class="col-2">
                      <asp:Button ID="btn_Electrical_IDMSP_Total_Count" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="Electrical - Pre Order Receipt - Total Count" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Electrical_IDMSP_Submitted" runat="server" CssClass="btn btn-outline-primary btn-sm btn-block font-weight-bold" ToolTip="Electrical - Pre Order Receipt - Submitted" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Electrical_IDMSP_Document_linked" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Electrical - Pre Order Receipt - Document Linked" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Electrical_IDMSP_Under_Evaluation" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Electrical - Pre Order Receipt - Under Evaluation" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Electrical_IDMSP_Comments_Submitted" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Electrical - Pre Order Receipt - Comments Submitted" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Electrical_IDMSP_Technically_Cleared" runat="server" CssClass="btn btn-outline-primary btn-sm btn-block font-weight-bold" ToolTip="Electrical - Pre Order Receipt - Technically Cleared" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Electrical_IDMSP_Transmittal_Issued" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Electrical - Pre Order Receipt - Transmittal Issued" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Electrical_IDMSP_Superceded" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Electrical - Pre Order Receipt - Superceded" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Electrical_IDMSP_Closed" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Electrical - Pre Order Receipt - Closed" Text="" Font-Bold="true"></asp:Button>
                    </div>
                </div>
              </div>
           

            <div class="container-fluid">
              <div class="row">
                <div class="col-md-2">
                  <h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">C & I </font></span></h6>
                </div>
               <div class="col-2">
                      <asp:Button ID="btn_CI_IDMSP_Total_Count" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="C & I - Pre Order Receipt - Total Count" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_CI_IDMSP_Submitted" runat="server" CssClass="btn btn-outline-primary btn-sm btn-block font-weight-bold" ToolTip="C & I - Pre Order Receipt - Submitted" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_CI_IDMSP_Document_linked" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="C & I - Pre Order Receipt - Document Linked" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_CI_IDMSP_Under_Evaluation" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="C & I - Pre Order Receipt - Under Evaluation" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_CI_IDMSP_Comments_Submitted" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="C & I - Pre Order Receipt - Comments Submitted" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_CI_IDMSP_Technically_Cleared" runat="server" CssClass="btn btn-outline-primary btn-sm btn-block font-weight-bold" ToolTip="C & I - Pre Order Receipt - Technically Cleared" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_CI_IDMSP_Transmittal_Issued" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="C & I - Pre Order Receipt - Transmittal Issued" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_CI_IDMSP_Superceded" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="C & I - Pre Order Receipt - Superceded" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_CI_IDMSP_Closed" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="C & I - Pre Order Receipt - Closed" Text="" Font-Bold="true"></asp:Button>
                    </div>
              </div>
            </div>

            <div class="container-fluid">
              <div class="row">
                <div class="col-md-2">
                  <h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">Others </font></span></h6>
                </div>
                <div class="col-2">
                      <asp:Button ID="btn_Others_IDMSP_Total_Count" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="Others - Pre Order Receipt - Total Count" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Others_IDMSP_Submitted" runat="server" CssClass="btn btn-outline-primary btn-sm btn-block font-weight-bold" ToolTip="Others - Pre Order Receipt - Submitted" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Others_IDMSP_Document_linked" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Others - Pre Order Receipt - Document Linked" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Others_IDMSP_Under_Evaluation" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Others - Pre Order Receipt - Under Evaluation" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Others_IDMSP_Comments_Submitted" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Others - Pre Order Receipt - Comments Submitted" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Others_IDMSP_Technically_Cleared" runat="server" CssClass="btn btn-outline-primary btn-sm btn-block font-weight-bold" ToolTip="Others - Pre Order Receipt - Technically Cleared" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Others_IDMSP_Transmittal_Issued" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Others - Pre Order Receipt - Transmittal Issued" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Others_IDMSP_Superceded" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Others - Pre Order Receipt - Superceded" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Others_IDMSP_Closed" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Others - Pre Order Receipt - Closed" Text="" Font-Bold="true"></asp:Button>
                    </div>
              </div>
            </div>

           <div class="container-fluid">
              <div class="row">
                <div class="col-md-2">
                  <h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">Total </font></span></h6>
                </div>
               <div class="col-2">
                      <asp:Button ID="btn_Total_IDMSP_Total_Count" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="Total - Pre Order Receipt - Total Count" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Total_IDMSP_Submitted" runat="server" CssClass="btn btn-outline-primary btn-sm btn-block font-weight-bold" ToolTip="Total - Pre Order Receipt - Submitted" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Total_IDMSP_Document_linked" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Total - Pre Order Receipt - Document Linked" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Total_IDMSP_Under_Evaluation" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Total - Pre Order Receipt - Under Evaluation" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Total_IDMSP_Comments_Submitted" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Total - Pre Order Receipt - Comments Submitted" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Total_IDMSP_Technically_Cleared" runat="server" CssClass="btn btn-outline-primary btn-sm btn-block font-weight-bold" ToolTip="Total - Pre Order Receipt - Technically Cleared" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Total_IDMSP_Transmittal_Issued" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Total - Pre Order Receipt - Transmittal Issued" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Total_IDMSP_Superceded" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Total - Pre Order Receipt - Superceded" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Total_IDMSP_Closed" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Total - Pre Order Receipt - Closed" Text="" Font-Bold="true"></asp:Button>
                    </div>
              </div>
            </div>


          </div>
        </div>
          </div>
       
</div>
          </div>
      <div class="tab-pane fade" id="v-pills-idms-og" role="tabpanel" aria-labelledby="IDMS_OT">
          <div class="row" id="C8" runat="server" visible="false">
      <div class="col-sm-12 text-center ">
        <a class="chartDiv btn btn-outline-dark" id="IDMSOCHART" runat="server">
          <h5>IDMS Post-Order Status </h5>
          <asp:Button ID="IDMSO" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Sorry !!! No Data in ERPLN" Text="" Font-Bold="true" Visible="false"></asp:Button>

          <asp:Chart
            ID="Chart6"
            Height="600px"
            Width="1050px"
            ClientIDMode="Predictable"
            runat="server">
            <Legends>
              <asp:Legend Name="Legend6" Docking="Bottom" IsDockedInsideChartArea="true">
                <Position Auto="True" />
              </asp:Legend>
            </Legends>
            <ChartAreas>
              <asp:ChartArea Name="ChartArea6" Area3DStyle-Enable3D="true" BackImageTransparentColor="WhiteSmoke" AlignmentOrientation="All" ShadowOffset="30">
              </asp:ChartArea>
            </ChartAreas>
          </asp:Chart>
          <div id="Div5" runat="server" class="container-fluid text-center"></div>
        </a>
      </div>
    </div>
          </div>
       <div class="tab-pane fade" id="v-pills-idms-ot" role="tabpanel" aria-labelledby="IDMS_OT">
             <div class="container text-center" id="IDMSOTABLE" runat="server" visible="false">
      <h5>Post Order Receipt Progress Status Discipline Wise</h5>
      <div class="row">

        <div class="col-12">
          <asp:Button ID="IDMSODATAI" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Sorry !!! No Data in ERPLN" Text="" Font-Bold="true" Visible="false"></asp:Button>
          </div>
         </div>
        
        <div class="container text-center" id="IDMSOTABLE1" runat="server" visible="false">
          <div class="border border-dark btn-outline-light">
            <div class="container-fluid">

              <div class="row">
                 
                <div class="col-2">
                  <div class="text-secondary">
                    <h6><b>Discipline</b></h6>
                  </div>
                </div>



                <div class="col-2">
                  <div class="text-secondary">
                    <b>Total Receipt Count</b>
                  </div>
                </div>

             
                   
                    <div class="col-1">
                      <div class="text-primary">
                        <b>Submitted</b>
                      </div>
                    </div>
                    <div class="col-1">
                      <div class="text-warning">
                        <b>Document Linked</b>
                      </div>
                    </div>
                    <div class="col-1">
                      <div class="text-secondary">
                        <b>Under Evaluation</b>
                      </div>
                    </div>
                    <div class="col-1">
                      <div class="text-secondary">
                        <b>Comments Submitted</b>
                      </div>
                    </div>
                     <div class="col-1">
                      <div class="text-secondary">
                        <b>Technically Cleared</b>
                      </div>
                    </div>
                     <div class="col-1">
                      <div class="text-secondary">
                        <b>Transmittal Issued</b>
                      </div>
                    </div>
                     <div class="col-1">
                      <div class="text-secondary">
                        <b>Superceded</b>
                      </div>
                    </div>
                     <div class="col-1">
                      <div class="text-secondary">
                        <b>Closed</b>
                      </div>
                    </div>






            
                
              

              </div>
             

          
 		       <div class="container-fluid">
              <div class="row">
                <div class="col-2">
                  <h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">Process </font></span></h6>
                </div>
                

                   <div class="col-2">
                      <asp:Button ID="btn_Process_IDMSO_Total_Count" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="Process - Post Order Receipt - Total Count" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Process_IDMSO_Submitted" runat="server" CssClass="btn btn-outline-primary btn-sm btn-block font-weight-bold" ToolTip="Process - Post Order Receipt - Submitted" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Process_IDMSO_Document_linked" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Process - Post Order Receipt - Document Linked" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Process_IDMSO_Under_Evaluation" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Process - Post Order Receipt - Under Evaluation" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Process_IDMSO_Comments_Submitted" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Process - Post Order Receipt - Comments Submitted" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Process_IDMSO_Technically_Cleared" runat="server" CssClass="btn btn-outline-primary btn-sm btn-block font-weight-bold" ToolTip="Process - Post Order Receipt - Technically Cleared" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Process_IDMSO_Transmittal_Issued" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Process - Post Order Receipt - Transmittal Issued" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Process_IDMSO_Superceded" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Process - Post Order Receipt - Superceded" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Process_IDMSO_Closed" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Process - Post Order Receipt - Closed" Text="" Font-Bold="true"></asp:Button>
                    </div>
                   

                
              </div>
            </div>

            <div class="container-fluid">
              <div class="row">
                <div class="col-2">
                  <h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">Mechanical </font></span></h6>
                </div>
               

                   
 		               <div class="col-2">
                      <asp:Button ID="btn_Mechanical_IDMSO_Total_Count" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="Mechanical - Post Order Receipt - Total Count" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Mechanical_IDMSO_Submitted" runat="server" CssClass="btn btn-outline-primary btn-sm btn-block font-weight-bold" ToolTip="Mechanical - Post Order Receipt - Submitted" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Mechanical_IDMSO_Document_linked" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Mechanical - Post Order Receipt - Document Linked" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Mechanical_IDMSO_Under_Evaluation" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Mechanical - Post Order Receipt - Under Evaluation" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Mechanical_IDMSO_Comments_Submitted" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Mechanical - Post Order Receipt - Comments Submitted" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Mechanical_IDMSO_Technically_Cleared" runat="server" CssClass="btn btn-outline-primary btn-sm btn-block font-weight-bold" ToolTip="Mechanical - Post Order Receipt - Technically Cleared" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Mechanical_IDMSO_Transmittal_Issued" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Mechanical - Post Order Receipt - Transmittal Issued" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Mechanical_IDMSO_Superceded" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Mechanical - Post Order Receipt - Superceded" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Mechanical_IDMSO_Closed" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Mechanical - Post Order Receipt - Closed" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    
                   
                  </div>
               
            </div>

            <div class="container-fluid">
              <div class="row">
                <div class="col-md-2">
                  <h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">Structure </font></span></h6>
                </div>
               

                     <div class="col-2">
                      <asp:Button ID="btn_Structure_IDMSO_Total_Count" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="Structure - Post Order Receipt - Total Count" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Structure_IDMSO_Submitted" runat="server" CssClass="btn btn-outline-primary btn-sm btn-block font-weight-bold" ToolTip="Structure - Post Order Receipt - Submitted" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Structure_IDMSO_Document_linked" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Structure - Post Order Receipt - Document Linked" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Structure_IDMSO_Under_Evaluation" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Structure - Post Order Receipt - Under Evaluation" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Structure_IDMSO_Comments_Submitted" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Structure - Post Order Receipt - Comments Submitted" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Structure_IDMSO_Technically_Cleared" runat="server" CssClass="btn btn-outline-primary btn-sm btn-block font-weight-bold" ToolTip="Structure - Post Order Receipt - Technically Cleared" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Structure_IDMSO_Transmittal_Issued" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Structure - Post Order Receipt - Transmittal Issued" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Structure_IDMSO_Superceded" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Structure - Post Order Receipt - Superceded" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Structure_IDMSO_Closed" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Structure - Post Order Receipt - Closed" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    
               
              </div>
            </div>

            <div class="container-fluid">
              <div class="row">
                <div class="col-md-2">
                  <h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">Piping </font></span></h6>
                </div>
                <div class="col-2">
                      <asp:Button ID="btn_Piping_IDMSO_Total_Count" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="Piping - Post Order Receipt - Total Count" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Piping_IDMSO_Submitted" runat="server" CssClass="btn btn-outline-primary btn-sm btn-block font-weight-bold" ToolTip="Piping - Post Order Receipt - Submitted" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Piping_IDMSO_Document_linked" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Piping - Post Order Receipt - Document Linked" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Piping_IDMSO_Under_Evaluation" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Piping - Post Order Receipt - Under Evaluation" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Piping_IDMSO_Comments_Submitted" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Piping - Post Order Receipt - Comments Submitted" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Piping_IDMSO_Technically_Cleared" runat="server" CssClass="btn btn-outline-primary btn-sm btn-block font-weight-bold" ToolTip="Piping - Post Order Receipt - Technically Cleared" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Piping_IDMSO_Transmittal_Issued" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Piping - Post Order Receipt - Transmittal Issued" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Piping_IDMSO_Superceded" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Piping - Post Order Receipt - Superceded" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Piping_IDMSO_Closed" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Piping - Post Order Receipt - Closed" Text="" Font-Bold="true"></asp:Button>
                    </div>
              </div>
            </div>

            <div class="container-fluid">
              <div class="row">
                <div class="col-md-2">
                  <h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">Electrical </font></span></h6>
                </div>
               
 		    <div class="col-2">
                      <asp:Button ID="btn_Electrical_IDMSO_Total_Count" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="Electrical - Post Order Receipt - Total Count" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Electrical_IDMSO_Submitted" runat="server" CssClass="btn btn-outline-primary btn-sm btn-block font-weight-bold" ToolTip="Electrical - Post Order Receipt - Submitted" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Electrical_IDMSO_Document_linked" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Electrical - Post Order Receipt - Document Linked" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Electrical_IDMSO_Under_Evaluation" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Electrical - Post Order Receipt - Under Evaluation" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Electrical_IDMSO_Comments_Submitted" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Electrical - Post Order Receipt - Comments Submitted" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Electrical_IDMSO_Technically_Cleared" runat="server" CssClass="btn btn-outline-primary btn-sm btn-block font-weight-bold" ToolTip="Electrical - Post Order Receipt - Technically Cleared" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Electrical_IDMSO_Transmittal_Issued" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Electrical - Post Order Receipt - Transmittal Issued" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Electrical_IDMSO_Superceded" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Electrical - Post Order Receipt - Superceded" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Electrical_IDMSO_Closed" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Electrical - Post Order Receipt - Closed" Text="" Font-Bold="true"></asp:Button>
                    </div>
                </div>
              </div>
           

            <div class="container-fluid">
              <div class="row">
                <div class="col-md-2">
                  <h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">C & I </font></span></h6>
                </div>
               <div class="col-2">
                      <asp:Button ID="btn_CI_IDMSO_Total_Count" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="C & I - Post Order Receipt - Total Count" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_CI_IDMSO_Submitted" runat="server" CssClass="btn btn-outline-primary btn-sm btn-block font-weight-bold" ToolTip="C & I - Post Order Receipt - Submitted" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_CI_IDMSO_Document_linked" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="C & I - Post Order Receipt - Document Linked" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_CI_IDMSO_Under_Evaluation" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="C & I - Post Order Receipt - Under Evaluation" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_CI_IDMSO_Comments_Submitted" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="C & I - Post Order Receipt - Comments Submitted" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_CI_IDMSO_Technically_Cleared" runat="server" CssClass="btn btn-outline-primary btn-sm btn-block font-weight-bold" ToolTip="C & I - Post Order Receipt - Technically Cleared" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_CI_IDMSO_Transmittal_Issued" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="C & I - Post Order Receipt - Transmittal Issued" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_CI_IDMSO_Superceded" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="C & I - Post Order Receipt - Superceded" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_CI_IDMSO_Closed" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="C & I - Post Order Receipt - Closed" Text="" Font-Bold="true"></asp:Button>
                    </div>
              </div>
            </div>

            <div class="container-fluid">
              <div class="row">
                <div class="col-md-2">
                  <h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">Others </font></span></h6>
                </div>
                <div class="col-2">
                      <asp:Button ID="btn_Others_IDMSO_Total_Count" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="Others - Post Order Receipt - Total Count" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Others_IDMSO_Submitted" runat="server" CssClass="btn btn-outline-primary btn-sm btn-block font-weight-bold" ToolTip="Others - Post Order Receipt - Submitted" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Others_IDMSO_Document_linked" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Others - Post Order Receipt - Document Linked" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Others_IDMSO_Under_Evaluation" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Others - Post Order Receipt - Under Evaluation" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Others_IDMSO_Comments_Submitted" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Others - Post Order Receipt - Comments Submitted" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Others_IDMSO_Technically_Cleared" runat="server" CssClass="btn btn-outline-primary btn-sm btn-block font-weight-bold" ToolTip="Others - Post Order Receipt - Technically Cleared" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Others_IDMSO_Transmittal_Issued" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Others - Post Order Receipt - Transmittal Issued" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Others_IDMSO_Superceded" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Others - Post Order Receipt - Superceded" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Others_IDMSO_Closed" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Others - Post Order Receipt - Closed" Text="" Font-Bold="true"></asp:Button>
                    </div>
              </div>
            </div>

           <div class="container-fluid">
              <div class="row">
                <div class="col-md-2">
                  <h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">Total </font></span></h6>
                </div>
               <div class="col-2">
                      <asp:Button ID="btn_Total_IDMSO_Total_Count" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="Total - Post Order Receipt - Total Count" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Total_IDMSO_Submitted" runat="server" CssClass="btn btn-outline-primary btn-sm btn-block font-weight-bold" ToolTip="Total - Post Order Receipt - Submitted" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Total_IDMSO_Document_linked" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Total - Post Order Receipt - Document Linked" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Total_IDMSO_Under_Evaluation" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Total - Post Order Receipt - Under Evaluation" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Total_IDMSO_Comments_Submitted" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Total - Post Order Receipt - Comments Submitted" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Total_IDMSO_Technically_Cleared" runat="server" CssClass="btn btn-outline-primary btn-sm btn-block font-weight-bold" ToolTip="Total - Post Order Receipt - Technically Cleared" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Total_IDMSO_Transmittal_Issued" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Total - Post Order Receipt - Transmittal Issued" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Total_IDMSO_Superceded" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Total - Post Order Receipt - Superceded" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-1">
                      <asp:Button ID="btn_Total_IDMSO_Closed" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Total - Post Order Receipt - Closed" Text="" Font-Bold="true"></asp:Button>
                    </div>
              </div>
            </div>


          </div>
        </div>
          </div>
       
</div>
          </div>
       <div class="tab-pane fade" id="v-pills-element-g" role="tabpanel" aria-labelledby="ELEMENT_G">
           <div class="row" id="C9" runat="server" visible="false">
      <div class="col-sm-12 text-center ">
        <a class="chartDiv btn btn-outline-warning" id="ELEMENTCHART" runat="server">
          <h5>Element Completion Status </h5>
          <asp:Button ID="ELEMENTDATA" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Sorry !!! No Data in ERPLN" Text="" Font-Bold="true" Visible="false"></asp:Button>

          <asp:Chart
            ID="Chart7"
            Height="600px"
            Width="1050px"
            ClientIDMode="Predictable"
            runat="server">
            <Legends>
              <asp:Legend Name="Legend7" Docking="Bottom" IsDockedInsideChartArea="true">
                <Position Auto="True" />
              </asp:Legend>
            </Legends>
            <ChartAreas>
              <asp:ChartArea Name="ChartArea7" Area3DStyle-Enable3D="true" BackImageTransparentColor="WhiteSmoke" AlignmentOrientation="All" ShadowOffset="30">
              </asp:ChartArea>
            </ChartAreas>
          </asp:Chart>
          <div id="Div6" runat="server" class="container-fluid text-center"></div>
        </a>
      </div>
    </div>
             </div>
        <div class="tab-pane fade" id="v-pills-element-t" role="tabpanel" aria-labelledby="ELEMENT_T">
                  <div class="container text-center" id="ELEMENTTABLE" runat="server" visible="false">
      <h5>Active Element Progress Status Department Wise</h5>
      <div class="row">

        <div class="col-12">
          <asp:Button ID="ELEMENTDATAI" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Sorry !!! No Data in ERPLN" Text="" Font-Bold="true" Visible="false"></asp:Button>
          </div>
         </div>
        
        <div class="container text-center" id="ELEMENTTABLE1" runat="server" visible="false">
          <div class="border border-dark btn-outline-light">
            <div class="container-fluid">

              <div class="row">
                 
                <div class="col-2">
                  <div class="text-secondary">
                    <h6><b>Discipline</b></h6>
                  </div>
                </div>



                <div class="col-5">
                   <div class="row">
                     <div class="col-6">
                       <div class="text-secondary">
                         <h6> <b>Total Active Element Count</b></h6>
                       </div>
                     </div>

                     <div class="col-6">
                       <div class="text-primary">
                         <h6> <b>Free</b></h6>
                       </div>
                     </div>
                     </div>
                  </div>

                      <div class="col-5">
                   <div class="row">

                     <div class="col-6">
                       <div class="text-warning">
                         <h6> <b>Partial</b></h6>
                       </div>
                     </div>
                     <div class="col-6">
                       <div class="text-secondary">
                        <h6>  <b>Completed</b></h6>
                       </div>
                     </div>
                     
                        </div>
                    </div>
              </div>
             

            <div class="container-fluid text-center">
              <div class="row">
                <div class="col-2">
                  <h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">Process </font></span></h6>
                </div>
                <div class="col-5">
                   <div class="row">
                    <div class="col-6">
                      <asp:Button ID="btn_Process_Element_Total_Active_Element_Count" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="Process - Total Active Element Count" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-6">
                      <asp:Button ID="btn_Process_Element_Free" runat="server" CssClass="btn btn-outline-primary btn-sm btn-block font-weight-bold" ToolTip="Process - Active Element - Free" Text="" Font-Bold="true"></asp:Button>
                    </div>
                      </div>
                   </div>
                     <div class="col-5">
                   <div class="row">

                    <div class="col-6">
                      <asp:Button ID="btn_Process_Element_Partial" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Process - Active Element - Partial" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-6">
                      <asp:Button ID="btn_Process_Element_Completed" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Process - Active Element - Completed" Text="" Font-Bold="true"></asp:Button>
                    </div>

                     </div>
                   </div>  
                  
                   
                   
 </div>
            </div>
                
           
            <div class="container-fluid">
              <div class="row">
                <div class="col-2">
                  <h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">Mechanical </font></span></h6>
                </div>
               

                  		<div class="col-5">
                   <div class="row">
                    <div class="col-6">
                      <asp:Button ID="btn_Mechanical_Element_Total_Active_Element_Count" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="Mechanical - Total Active Element Count" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-6">
                      <asp:Button ID="btn_Mechanical_Element_Free" runat="server" CssClass="btn btn-outline-primary btn-sm btn-block font-weight-bold" ToolTip="Mechanical - Active Element - Free" Text="" Font-Bold="true"></asp:Button>
                    </div>
                      </div>
                   </div>
                     <div class="col-5">
                   <div class="row">

                    <div class="col-6">
                      <asp:Button ID="btn_Mechanical_Element_Partial" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Mechanical - Active Element - Partial" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-6">
                      <asp:Button ID="btn_Mechanical_Element_Completed" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Mechanical - Active Element - Completed" Text="" Font-Bold="true"></asp:Button>
                    </div>

                     </div>
                   </div>  
                    </div>
                   </div>

                    
                   
            

            <div class="container-fluid">
              <div class="row">
                <div class="col-md-2">
                  <h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">Structure </font></span></h6>
                </div>
               

                   		<div class="col-5">
                   <div class="row">
                    <div class="col-6">
                      <asp:Button ID="btn_Structure_Element_Total_Active_Element_Count" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="Structure - Total Active Element Count" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-6">
                      <asp:Button ID="btn_Structure_Element_Free" runat="server" CssClass="btn btn-outline-primary btn-sm btn-block font-weight-bold" ToolTip="Structure - Active Element - Free" Text="" Font-Bold="true"></asp:Button>
                    </div>
                      </div>
                   </div>
                     <div class="col-5">
                   <div class="row">

                    <div class="col-6">
                      <asp:Button ID="btn_Structure_Element_Partial" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Structure - Active Element - Partial" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-6">
                      <asp:Button ID="btn_Structure_Element_Completed" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Structure - Active Element - Completed" Text="" Font-Bold="true"></asp:Button>
                    </div>

                     </div>
                   </div>  


                    </div>
                   </div>
            <div class="container-fluid">
              <div class="row">
                <div class="col-md-2">
                  <h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">Piping </font></span></h6>
                </div>
               		<div class="col-5">
                   <div class="row">
                    <div class="col-6">
                      <asp:Button ID="btn_Piping_Element_Total_Active_Element_Count" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="Piping - Total Active Element Count" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-6">
                      <asp:Button ID="btn_Piping_Element_Free" runat="server" CssClass="btn btn-outline-primary btn-sm btn-block font-weight-bold" ToolTip="Piping - Active Element - Free" Text="" Font-Bold="true"></asp:Button>
                    </div>
                      </div>
                   </div>
                     <div class="col-5">
                   <div class="row">

                    <div class="col-6">
                      <asp:Button ID="btn_Piping_Element_Partial" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Piping - Active Element - Partial" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-6">
                      <asp:Button ID="btn_Piping_Element_Completed" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Piping - Active Element - Completed" Text="" Font-Bold="true"></asp:Button>
                    </div>

                     </div>
                   </div>  
                    </div>
                   </div>

            <div class="container-fluid">
              <div class="row">
                <div class="col-md-2">
                  <h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">Electrical </font></span></h6>
                </div>
                 		<div class="col-5">
                   <div class="row">
                    <div class="col-6">
                      <asp:Button ID="btn_Electrical_Element_Total_Active_Element_Count" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="Electrical - Total Active Element Count" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-6">
                      <asp:Button ID="btn_Electrical_Element_Free" runat="server" CssClass="btn btn-outline-primary btn-sm btn-block font-weight-bold" ToolTip="Electrical - Active Element - Free" Text="" Font-Bold="true"></asp:Button>
                    </div>
                      </div>
                   </div>
                     <div class="col-5">
                   <div class="row">

                    <div class="col-6">
                      <asp:Button ID="btn_Electrical_Element_Partial" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Electrical - Active Element - Partial" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-6">
                      <asp:Button ID="btn_Electrical_Element_Completed" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Electrical - Active Element - Completed" Text="" Font-Bold="true"></asp:Button>
                    </div>

                     </div>
                   </div>  
                    </div>
                   </div>
           

            <div class="container-fluid">
              <div class="row">
                <div class="col-md-2">
                  <h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">C & I </font></span></h6>
                </div>
              		<div class="col-5">
                   <div class="row">
                    <div class="col-6">
                      <asp:Button ID="btn_CI_Element_Total_Active_Element_Count" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="C & I - Total Active Element Count" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-6">
                      <asp:Button ID="btn_CI_Element_Free" runat="server" CssClass="btn btn-outline-primary btn-sm btn-block font-weight-bold" ToolTip="C & I - Active Element - Free" Text="" Font-Bold="true"></asp:Button>
                    </div>
                      </div>
                   </div>
                     <div class="col-5">
                   <div class="row">

                    <div class="col-6">
                      <asp:Button ID="btn_CI_Element_Partial" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="C & I - Active Element - Partial" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-6">
                      <asp:Button ID="btn_CI_Element_Completed" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="C & I - Active Element - Completed" Text="" Font-Bold="true"></asp:Button>
                    </div>

                     </div>
                   </div>  
                    </div>
                   </div>

            <div class="container-fluid">
              <div class="row">
                <div class="col-md-2">
                  <h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">Others </font></span></h6>
                </div>
               <div class="col-5">
                   <div class="row">
                    <div class="col-6">
                      <asp:Button ID="btn_Others_Element_Total_Active_Element_Count" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="Others - Total Active Element Count" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-6">
                      <asp:Button ID="btn_Others_Element_Free" runat="server" CssClass="btn btn-outline-primary btn-sm btn-block font-weight-bold" ToolTip="Others - Active Element - Free" Text="" Font-Bold="true"></asp:Button>
                    </div>
                      </div>
                   </div>
                     <div class="col-5">
                   <div class="row">

                    <div class="col-6">
                      <asp:Button ID="btn_Others_Element_Partial" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Others - Active Element - Partial" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-6">
                      <asp:Button ID="btn_Others_Element_Completed" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Others - Active Element - Completed" Text="" Font-Bold="true"></asp:Button>
                    </div>

                     </div>
                   </div>  
                    </div>
                   </div>

           <div class="container-fluid">
              <div class="row">
                <div class="col-md-2">
                  <h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">Total </font></span></h6>
                </div>
                		<div class="col-5">
                   <div class="row">
                    <div class="col-6">
                      <asp:Button ID="btn_Total_Element_Total_Active_Element_Count" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="Total - Total Active Element Count" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-6">
                      <asp:Button ID="btn_Total_Element_Free" runat="server" CssClass="btn btn-outline-primary btn-sm btn-block font-weight-bold" ToolTip="Total - Active Element - Free" Text="" Font-Bold="true"></asp:Button>
                    </div>
                      </div>
                   </div>
                     <div class="col-5">
                   <div class="row">

                    <div class="col-6">
                      <asp:Button ID="btn_Total_Element_Partial" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Total - Active Element - Partial" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-6">
                      <asp:Button ID="btn_Total_Element_Completed" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Total - Active Element - Completed" Text="" Font-Bold="true"></asp:Button>
                    </div>

                     </div>
                   </div>  
                    </div>
                   </div>


          </div>
        </div>
          </div>
       
</div>
             </div>
      <div class="tab-pane fade" id="v-pills-hold-g" role="tabpanel" aria-labelledby="HOLD_G">
            <div class="row" id="C11" runat="server" visible="false">
      <div class="col-sm-12 text-center ">
        <a class="chartDiv btn btn-outline-warning" id="HOLDCHART1" runat="server">
          <h5>HOLD STATUS </h5>
          <asp:Button ID="HOLD1DATA" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Sorry !!! No Data in ERPLN" Text="" Font-Bold="true" Visible="false"></asp:Button>

          <asp:Chart
            ID="Chart11"
            Height="600px"
            Width="1050px"
            ClientIDMode="Predictable"
            runat="server">
            <Legends>
              <asp:Legend Name="Legend11" Docking="Bottom" IsDockedInsideChartArea="true">
                <Position Auto="True" />
              </asp:Legend>
            </Legends>
            <ChartAreas>
              <asp:ChartArea Name="ChartArea11" Area3DStyle-Enable3D="true" BackImageTransparentColor="WhiteSmoke" AlignmentOrientation="All" ShadowOffset="30">
              </asp:ChartArea>
            </ChartAreas>
          </asp:Chart>
          <div id="Div11" runat="server" class="container-fluid text-center"></div>
        </a>
      </div>
    </div>
         </div>
      <div class="tab-pane fade" id="v-pills-hold-t" role="tabpanel" aria-labelledby="HOLD_T">
          <div class="row" id="C10" runat="server" visible="false">
      <div class="col-sm-12 text-center ">
        <a class="chartDiv btn btn-outline-warning" id="HOLDCHART" runat="server">
          <h5>UNDER HOLD STATUS </h5>
          <asp:Button ID="HOLDDATA" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Sorry !!! No Data in ERPLN" Text="" Font-Bold="true" Visible="false"></asp:Button>

          <asp:Chart
            ID="Chart10"
            Height="600px"
            Width="1050px"
            ClientIDMode="Predictable"
            runat="server">
            <Legends>
              <asp:Legend Name="Legend10" Docking="Bottom" IsDockedInsideChartArea="true">
                <Position Auto="True" />
              </asp:Legend>
            </Legends>
            <ChartAreas>
              <asp:ChartArea Name="ChartArea10" Area3DStyle-Enable3D="true" BackImageTransparentColor="WhiteSmoke" AlignmentOrientation="All" ShadowOffset="30">
              </asp:ChartArea>
            </ChartAreas>
          </asp:Chart>
          <div id="Div10" runat="server" class="container-fluid text-center"></div>
        </a>
      </div>
    </div>
         </div>
    </div>
  </div>
      

</div>


    
    <%--Main Graph Row--%>
   
   
</asp:Content>
