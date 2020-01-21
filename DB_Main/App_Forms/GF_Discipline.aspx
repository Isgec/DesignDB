<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_Discipline.aspx.vb" Inherits="GF_Discipline" Title="Discipline" %>

<asp:Content ID="CPHtaApprovalWFTypes" ContentPlaceHolderID="cph1" runat="Server">

  <div class="container-fluid">
    <div class="caption">
      <asp:Label ID="LabeltaApprovalWFTypes" runat="server" Text="&nbsp;Discipline DashBoard"></asp:Label>
    </div>
    <div class="pagedata">
      <asp:UpdatePanel ID="UPNLtaApprovalWFTypes" runat="server">
        <ContentTemplate>

          <asp:UpdateProgress ID="UPGStaApprovalWFTypes" runat="server" AssociatedUpdatePanelID="UPNLtaApprovalWFTypes" DisplayAfter="100">
            <ProgressTemplate>
              <span style="color: #ff0031">Loading...</span>
            </ProgressTemplate>
          </asp:UpdateProgress>

          <hr style="color: brown; background-color: darkslategrey; width: 100%; height: 3px">
          <%-- Query Buttons--%>
          <div class="row">

            <div class="col-3">

              <div class="form-group">

                <div class="input-group">

                  <a href="#ID_Division" class="btn btn-warning btn-outline-dark" style="width: 140px; text-align: center; cursor: pointer" data-toggle="collapse"><b>Division</b></a>
                  <div id="ID_Division" class="collapse">
                    Select Division for which Information need to fetched for Dashboard.
    Click again 'Division' button To Hide this Information.
                  </div>
                  <asp:DropDownList ID="F_DivisionID" CssClass="form-control" ClientIDMode="static" runat="Server">
                    <asp:ListItem Value="">BOILER</asp:ListItem>
                    <asp:ListItem>EPC</asp:ListItem>
                    <asp:ListItem>SMD</asp:ListItem>
                    <asp:ListItem>APC</asp:ListItem>

                  </asp:DropDownList>
                </div>
              </div>
            </div>

            <div class="col-3">

              <div class="form-group">

                <div class="input-group">

                  <a href="#ID_Discipline" class="btn btn-light btn-outline-dark" style="width: 140px; text-align: center; cursor: pointer" data-toggle="collapse"><b>Discipline</b></a>
                  <div id="ID_Discipline" class="collapse">
                    Select Department for which Information need to fetched for Dashboard.
    Click again 'Department' button To Hide this Information.
                  </div>
                  <asp:DropDownList ID="F_DisciplineID" CssClass="form-control" ClientIDMode="static" runat="Server">
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


                  </asp:DropDownList>
                </div>
              </div>
            </div>

            <div class="col-3">

              <div class="form-group">

                <div class="input-group">

                  <a href="#ID_Year" class="btn btn-light btn-outline-dark" style="width: 140px; text-align: center; cursor: pointer" data-toggle="collapse"><b>Year</b></a>
                  <div id="ID_Year" class="collapse">
                    Select Department for which Information need to fetched for Dashboard.
    Click again 'Department' button To Hide this Information.
                  </div>
                  <asp:DropDownList ID="F_YearID" CssClass="form-control" ClientIDMode="static" runat="Server">
                    <asp:ListItem Value="">2020</asp:ListItem>
                    <asp:ListItem>2019</asp:ListItem>
                    <asp:ListItem>2018</asp:ListItem>
                    <asp:ListItem>2017</asp:ListItem>
                    <asp:ListItem>2016</asp:ListItem>
                    <asp:ListItem>2015</asp:ListItem>
                    <asp:ListItem>2014</asp:ListItem>
                    <asp:ListItem>2013</asp:ListItem>
                    <asp:ListItem>2012</asp:ListItem>
                    <asp:ListItem>2011</asp:ListItem>
                    <asp:ListItem>2010</asp:ListItem>


                  </asp:DropDownList>
                </div>
              </div>
            </div>

            <div class="col-3">

              <div class="form-group">

                <div class="input-group">

                  <a href="#ID_Month" class="btn btn-light btn-outline-dark" style="width: 140px; text-align: center; cursor: pointer" data-toggle="collapse"><b>Month</b></a>
                  <div id="ID_Month" class="collapse">
                    Select Department for which Information need to fetched for Dashboard.
    Click again 'Department' button To Hide this Information.
                  </div>
                  <asp:DropDownList ID="F_MonthID" CssClass="form-control" runat="server">
                    <asp:ListItem>JANUARY</asp:ListItem>
                    <asp:ListItem>FEBRUARY</asp:ListItem>
                    <asp:ListItem>MARCH</asp:ListItem>
                    <asp:ListItem>APRIL</asp:ListItem>
                    <asp:ListItem>MAY</asp:ListItem>
                    <asp:ListItem>JUNE</asp:ListItem>
                    <asp:ListItem>JULY</asp:ListItem>
                    <asp:ListItem>AUGUST</asp:ListItem>
                    <asp:ListItem>SEPTEMBER</asp:ListItem>
                    <asp:ListItem>OCTOBER</asp:ListItem>
                    <asp:ListItem>NOVEMBER</asp:ListItem>
                    <asp:ListItem>DECEMBER</asp:ListItem>
                  </asp:DropDownList>
                </div>
              </div>
            </div>

          </div>

          <div class="row">
            <div class="col-9">
            </div>
            <div class="col-3">

              <asp:Button ID="cmdSubmit" runat="server" CssClass="btn btn-block btn-outline-danger" Font-Bold="true" Text="Generate DashBoard" ToolTip="-" Style="width: 210px; text-align: center; cursor: pointer" />
            </div>
          </div>
          <%-- Query Buttons--%>

          <hr style="color: brown; background-color: darkslategrey; width: 100%; height: 3px">
          
        
          
          <hr>
           <%-- PMDL TABLE--%>
          <div class="container text-center" id="DPMDLTABLE" runat="server" visible="false">
            <h5>Drawing and Document Progress Status As per PMDL - As Of Now </h5>


            <div class="container text-center" id="DPMDLTABLE1" runat="server" visible="true">
              <div class="border border-dark btn-outline-light">
                <div class="container-fluid text-center">

                  <div class="row">
                    <div class="col-3">
                      <div class="text-secondary">
                        <h6><b>Discipline</b></h6>
                      </div>
                    </div>

                    <div class="col-9">
                      <div class="row">

                        <div class="col">
                          <div class="text-dark">
                            <h6><b>Total Due for Release Current Month -A</b></h6>
                          </div>
                        </div>
                        <div class="col">
                          <div class="text-primary">
                            <h6><b>Backlog for Release (Previous months) -B</b></h6>
                          </div>
                        </div>
                        <div class="col">
                          <div class="text-warning">

                            <h6><b>All Due For Release - C = A + B</b></h6>
                          </div>
                        </div>
                        <div class="col">
                          <div class="text-secondary">
                            <h6><b>All Due Till Today For Release</b></h6>
                          </div>
                        </div>

                        <div class="col">
                          <div class="text-secondary">
                            <h6><b>Due for Today Only To Release</b></h6>
                          </div>
                        </div>

                        <div class="col">
                          <div class="text-success">
                            <h6><b>Ontime Released in This Month</b></h6>
                          </div>
                        </div>

                        <div class="col">
                          <div class="text-danger">
                            <h6><b>Backlog Released in This Month</b></h6>
                          </div>
                        </div>
                      </div>
                    </div>

                  </div>

                </div>

                <div class="container-fluid">
                  <div class="row">
                    <div class="col-3">
                      <asp:Button ID="Btn_Discipline" runat="server" CssClass="btn btn-info btn-sm btn-block text-lg-left font-weight-bold" ToolTip="" Text="" Font-Bold="true"></asp:Button>
                    </div>
                    <div class="col-9">
                      <div class="row">

                        <div class="col">
                          <asp:Button ID="btn_DueforRelease_CurrentM_A" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="Total Due for Release Current Month -A" Text="" Font-Bold="true"></asp:Button>
                        </div>
                        <div class="col">
                          <asp:Button ID="btn_DueforRelease_PreviousM_B" runat="server" CssClass="btn btn-outline-primary btn-sm btn-block font-weight-bold" ToolTip="Total Due for Release Previous Month -B" Text="" Font-Bold="true"></asp:Button>
                        </div>
                        <div class="col">
                          <asp:Button ID="btn_DueforRelease_BothM_C" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Total Due For Release - C = A + B" Text="" Font-Bold="true"></asp:Button>
                        </div>

                        <div class="col">
                          <asp:Button ID="btn_AllDueTillToday_Release" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="All Due Till Today For Release" Text="" Font-Bold="true"></asp:Button>

                        </div>

                        <div class="col">
                          <asp:Button ID="btn_DueOnlyToday_Release" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Due for Today Only To Release" Text="" Font-Bold="true"></asp:Button>
                        </div>
                        <div class="col">
                          <asp:Button ID="btn_Ontime_Release_CurrentM" runat="server" CssClass="btn btn-outline-success btn-sm btn-block font-weight-bold" ToolTip="Ontime Released in This Month" Text="" Font-Bold="true"></asp:Button>
                        </div>
                        <div class="col">
                          <asp:Button ID="btn_Backlog_Release_CurrentM" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="Backlog Released in This Month" Text="" Font-Bold="true"></asp:Button>
                        </div>

                      </div>
                    </div>

                  </div>
                </div>
              </div>
            </div>

          </div>
          
          <hr>
          <%-- SAR TABLE--%>
          <div class="container text-center" id="DSARTABLE" runat="server" visible="false">
            <h5>SAR Progress Status</h5>
           

            <div class="container text-center" id="DSARTABLE1" runat="server" visible="true">
              <div class="border border-dark btn-outline-light">
                <div class="container-fluid text-center">

                  <div class="row">

                    <div class="col-3">
                      <div class="text-secondary">
                        <h6><b>Discipline</b></h6>
                      </div>
                    </div>



                    <div class="col-9">
                      <div class="row">
                        <div class="col">
                          <div class="text-dark">
                            <h6><b>Total SAR Count</b></h6>
                          </div>
                        </div>

                        <div class="col">
                          <div class="text-info">
                          <h6> <b>Under Creation</b></h6>
                          </div>
                        </div>
                        <div class="col">
                          <div class="text-warning">
                           <h6> <b>Under Review</b></h6>
                          </div>
                        </div>
                        <div class="col">
                          <div class="text-danger">
                          <h6>  <b>Under Approval</b></h6>
                          </div>
                        </div>
                        <div class="col">
                        <div class="text-success">
                          <h6>  <b>Pending</b></h6>
                          </div>
                        </div>
                        <div class="col">
                          <div class="text-success">
                           <h6> <b>Approved</b></h6>
                          </div>
                        </div>
                        <div class="col">
                          <div class="text-secondary">
                           <h6> <b>Not Applicable</b></h6>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>


                  <div class="container-fluid">
                    <div class="row">
                      <div class="col-3">
                        <asp:Button ID="Btn_Discipline1" runat="server" CssClass="btn btn-info btn-sm btn-block text-lg-left font-weight-bold" ToolTip="" Text="" Font-Bold="true"></asp:Button>

                      </div>
                      <div class="col-9">
                        <div class="row">
                          <div class="col">
                            <asp:Button ID="btn_SAR_TotalCount" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="Total SAR Count" Text="" Font-Bold="true"></asp:Button>
                          </div>
                          <div class="col">
                            <asp:Button ID="btn_SAR_UnderCreation" runat="server" CssClass="btn btn-outline-info btn-sm btn-block font-weight-bold" ToolTip="SAR - Under Creation" Text="" Font-Bold="true"></asp:Button>
                          </div>
                          <div class="col">
                            <asp:Button ID="btn_SAR_UnderReview" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="SAR - Under Review" Text="" Font-Bold="true"></asp:Button>
                          </div>
                          <div class="col">
                            <asp:Button ID="btn_SAR_UnderApproval" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="SAR - Under Approval" Text="" Font-Bold="true"></asp:Button>
                          </div>
                          <div class="col">
                            <asp:Button ID="btn_SAR_Pending" runat="server" CssClass="btn btn-outline-success btn-sm btn-block font-weight-bold" ToolTip="SAR - Pending" Text="" Font-Bold="true"></asp:Button>
                          </div>
                          <div class="col">
                            <asp:Button ID="btn_SAR_Approved" runat="server" CssClass="btn btn-outline-success btn-sm btn-block font-weight-bold" ToolTip="SAR - Approved" Text="" Font-Bold="true"></asp:Button>
                          </div>
                          <div class="col">
                            <asp:Button ID="btn_SAR_NotApplicable" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="SAR - Not Applicable" Text="" Font-Bold="true"></asp:Button>
                          </div>


                        </div>
                      </div>

                    </div>
                  </div>
                           <div class="container-fluid text-center">
                    <div class="row">
                      <div class="col-3">
                        <asp:Button ID="Btn_Discipline2" runat="server" CssClass="btn btn-info btn-sm btn-block text-lg-left font-weight-bold" ToolTip="" Text="" Font-Bold="true"></asp:Button>

                      </div>
                      <div class="col-9">
                        <div class="row">
                          <div class="col">
                            <asp:Button ID="btn_SAR_TotalCountA" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="Total SAR Count" Text="" Font-Bold="true"></asp:Button>
                          </div>
                          <div class="col">
                            <asp:Button ID="btn_SAR_UnderCreationA" runat="server" CssClass="btn btn-outline-info btn-sm btn-block font-weight-bold" ToolTip="SAR - Under Creation" Text="" Font-Bold="true"></asp:Button>
                          </div>
                          <div class="col">
                            <asp:Button ID="btn_SAR_UnderReviewA" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="SAR - Under Review" Text="" Font-Bold="true"></asp:Button>
                          </div>
                          <div class="col">
                            <asp:Button ID="btn_SAR_UnderApprovalA" runat="server" CssClass="btn btn-outline-danger btn-sm btn-block font-weight-bold" ToolTip="SAR - Under Approval" Text="" Font-Bold="true"></asp:Button>
                          </div>
                          <div class="col">
                            <asp:Button ID="btn_SAR_PendingA" runat="server" CssClass="btn btn-outline-success btn-sm btn-block font-weight-bold" ToolTip="SAR - Pending" Text="" Font-Bold="true"></asp:Button>
                          </div>
                          <div class="col">
                            <asp:Button ID="btn_SAR_ApprovedA" runat="server" CssClass="btn btn-outline-success btn-sm btn-block font-weight-bold" ToolTip="SAR - Approved" Text="" Font-Bold="true"></asp:Button>
                          </div>
                          <div class="col">
                            <asp:Button ID="btn_SAR_NotApplicableA" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="SAR - Not Applicable" Text="" Font-Bold="true"></asp:Button>
                          </div>


                        </div>
                      </div>

                    </div>
                  </div>



                </div>
              </div>
            </div>

          </div>
          
          <hr>
          <%-- ELEMENT TABLE--%>
          <div class="container text-center" id="DELEMENTTABLE" runat="server" visible="false">
            <h5>Active Element Progress</h5>
            

            <div class="container text-center" id="DELEMENTTABLE1" runat="server" visible="true">
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




                  <div class="container-fluid">
                    <div class="row">
                      <div class="col-md-2">
                        <h6><span class="btn btn-info btn-sm btn-block text-lg-left font-weight-bold"><font face="Comic Sans MS">Total </font></span></h6>
                      </div>
                      <div class="col-5">
                        <div class="row">
                          <div class="col-6">
                            <asp:Button ID="btn_Total_Element" runat="server" CssClass="btn btn-outline-dark btn-sm btn-block font-weight-bold" ToolTip="Total - Total Active Element Count" Text="" Font-Bold="true"></asp:Button>
                          </div>
                          <div class="col-6">
                            <asp:Button ID="btn_Element_Free" runat="server" CssClass="btn btn-outline-primary btn-sm btn-block font-weight-bold" ToolTip="Total - Active Element - Free" Text="" Font-Bold="true"></asp:Button>
                          </div>
                        </div>
                      </div>
                      <div class="col-5">
                        <div class="row">

                          <div class="col-6">
                            <asp:Button ID="btn_Element_Partial" runat="server" CssClass="btn btn-outline-warning btn-sm btn-block font-weight-bold" ToolTip="Total - Active Element - Partial" Text="" Font-Bold="true"></asp:Button>
                          </div>
                          <div class="col-6">
                            <asp:Button ID="btn_Element_Completed" runat="server" CssClass="btn btn-outline-secondary btn-sm btn-block font-weight-bold" ToolTip="Total - Active Element - Completed" Text="" Font-Bold="true"></asp:Button>
                          </div>

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
