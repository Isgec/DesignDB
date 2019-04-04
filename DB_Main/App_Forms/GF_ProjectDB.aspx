<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_ProjectDB.aspx.vb" Inherits="GF_ProjectDB" title="Project Dashboard" %>
<asp:Content ID="CPHtaApprovalWFTypes" ContentPlaceHolderID="cph1" runat="Server">
 
    <div class="caption">
      <asp:Label ID="LabeltaApprovalWFTypes" runat="server" Text="&nbsp;PROJECT DASHBOARD"></asp:Label>
    </div>

  <div class="container" style="margin-top: 10px">
    <%--Project Selection Drop Down--%>
    <div class="col-sm-2 mb-2">
      <a class="btn btn-success" href="GF_UserDB.aspx" role="button"><i class="fa fa-dashboard" style="font-size: 20px">My DashBoard </i><i class="fa fa-spinner fa-spin text-secondary"></i></a>

    </div>
    <hr />
    <div class="row">

      
      <div class="col-3  mb-2 ml-3">
        <asp:UpdatePanel ID="UPNLctPActivity" runat="server">
          <ContentTemplate>
            <div class="form-group">

              <div class="input-group mb-3">
                <span class=" btn btn-sm btn-dark" style="width: 78px; text-align: center; cursor: pointer" title="Enter Project ID:" onclick="openNav()"><b>Project:</b></span>
                <asp:TextBox
                  ID="F_t_cprj"
                  CssClass="form-control"
                  ClientIDMode="static"
                  runat="Server">
                </asp:TextBox>
                <asp:Button ID="cmdSubmit" runat="server" CssClass="btn btn-warning btn-sm" Text="SHOW" ToolTip="Click to Generate Project DashBoard " Font-Bold="true" Font-Names="Comic Sans MS" />
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
      <div class="col-8 mt-1">
        <div class="container mt-0" id="PDetails" runat="server" visible="false">
          <div class="container  text-center my-0">
            <asp:Button ID="btn_projectname" Text="" runat="server" CssClass="btn-warning btn-sm" Font-Bold="true" Font-Names="Comic Sans MS" ToolTip=""></asp:Button>
            <hr />
          </div>
        </div>
      </div>
    </div>
    <%--Project & Period Detaila--%>
    
    

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
                    <asp:Button ID="btn_Mechanical_Ontime_Count" runat="server" CssClass="btn btn-outline-success btn-sm btn-block font-weight-bold" ToolTip="Mechanical - Delayed Released DWG/Doc" Text="" Font-Bold="true"></asp:Button>
                  </div>
                  <div class="col-sm-2">
                    <asp:Button ID="btn_Mechanical_Delayed_Count" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Mechanical - Ontime Released DWG/Doc" Text="" Font-Bold="true"></asp:Button>
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
                    <asp:Button ID="btn_Structure_Ontime_Count" runat="server" CssClass="btn btn-outline-success btn-sm btn-block font-weight-bold" ToolTip="Structure - Delayed Released DWG/Doc" Text="" Font-Bold="true"></asp:Button>
                  </div>
                  <div class="col-sm-2">
                    <asp:Button ID="btn_Structure_Delayed_Count" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Structure - Ontime Released DWG/Doc" Text="" Font-Bold="true"></asp:Button>
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
                    <asp:Button ID="btn_Piping_Ontime_Count" runat="server" CssClass="btn btn-outline-success btn-sm btn-block font-weight-bold" ToolTip="Piping - Delayed Released DWG/Doc" Text="" Font-Bold="true"></asp:Button>
                  </div>
                  <div class="col-sm-2">
                    <asp:Button ID="btn_piping_Delayed_Count" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Piping - Ontime Released DWG/Doc" Text="" Font-Bold="true"></asp:Button>
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
                    <asp:Button ID="btn_Electrical_Ontime_Count" runat="server" CssClass="btn btn-outline-success btn-sm btn-block font-weight-bold" ToolTip="Electrical - Delayed Released DWG/Doc" Text="" Font-Bold="true"></asp:Button>
                  </div>
                  <div class="col-sm-2">
                    <asp:Button ID="btn_Electrical_Delayed_Count" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Electrical - Ontime Released DWG/Doc" Text="" Font-Bold="true"></asp:Button>
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
                    <asp:Button ID="btn_CI_Ontime_Count" runat="server" CssClass="btn btn-outline-success btn-sm btn-block font-weight-bold" ToolTip="C & I - Delayed Released DWG/Doc" Text="" Font-Bold="true"></asp:Button>
                  </div>
                  <div class="col-sm-2">
                    <asp:Button ID="btn_CI_Delayed_Count" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="C & I - Ontime Released DWG/Doc" Text="" Font-Bold="true"></asp:Button>
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
                    <asp:Button ID="btn_Total_Ontime_Count" runat="server" CssClass="btn btn-outline-success btn-sm btn-block font-weight-bold" ToolTip="Total Delayed Released DWG/Doc" Text="" Font-Bold="true"></asp:Button>
                  </div>
                  <div class="col-sm-2">
                    <asp:Button ID="btn_Total_Delayed_Count" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Total Ontime Released DWG/Doc" Text="" Font-Bold="true"></asp:Button>
                  </div>
                </div>
              </div>
            </div>
          </div>

        </div>
      </div>

    </div>
    <hr />
    
    <%--Main Graph Row--%>
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
    <hr />
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
    <hr />
    
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
     
    
    <hr />
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
    <hr />

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
                    <b>Total Transmittal Count</b>
                  </div>
                </div>

             
                   
                    <div class="col-1">
                      <div class="text-info">
                        <b>Free</b>
                      </div>
                    </div>
                    <div class="col-1">
                      <div class="text-warning">
                        <b>Under Approval</b>
                      </div>
                    </div>
                    <div class="col-1">
                      <div class="text-danger">
                        <b>Under Issue</b>
                      </div>
                    </div>
                    <div class="col-1">
                      <div class="text-success">
                        <b>Issued</b>
                      </div>
                    </div>
                     <div class="col-1">
                      <div class="text-primary">
                        <b>Partial Received</b>
                      </div>
                    </div>
                     <div class="col-1">
                      <div class="text-secondary">
                        <b>Received</b>
                      </div>
                    </div>
                     <div class="col-1">
                      <div class="text-secondary">
                        <b>Closed</b>
                      </div>
                    </div>
                     <div class="col-1">
                      <div class="text-secondary">
                        <b>Returned</b>
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
    <hr />
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
    <hr />
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
    <hr />
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
    <hr />
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
                         <b>Total SAR Count</b>
                       </div>
                     </div>

                     <div class="col-2">
                       <div class="text-info">
                         <b>Created</b>
                       </div>
                     </div>
                     <div class="col-2">
                       <div class="text-warning">
                         <b>Under Review</b>
                       </div>
                     </div>
                     <div class="col-2">
                       <div class="text-danger">
                         <b>Under Approval</b>
                       </div>
                     </div>
                     <div class="col-2">
                       <div class="text-success">
                         <b>Approved</b>
                       </div>
                     </div>
                     <div class="col-2">
                       <div class="text-secondary">
                         <b>Not Applicable</b>
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

    <hr />
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
    <hr />
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

    <hr />
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
    <hr />
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

    <hr />
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
    <hr />
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
                         <b>Total Active Element Count</b>
                       </div>
                     </div>

                     <div class="col-6">
                       <div class="text-primary">
                         <b>Free</b>
                       </div>
                     </div>
                     </div>
                  </div>

                      <div class="col-5">
                   <div class="row">

                     <div class="col-6">
                       <div class="text-warning">
                         <b>Partial</b>
                       </div>
                     </div>
                     <div class="col-6">
                       <div class="text-secondary">
                         <b>Completed</b>
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

    <hr />

  </div>
</asp:Content>
