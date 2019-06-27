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
     
     
  <%--  <input class="form-control" type ="date"  required="required"/>--%>
<%--        <div class="row">

    <div class="col-5">
    <div class="btn-group btn-group-toggle" data-toggle="buttons">
      <label class="btn btn-info active">
    <input type="radio" name="options" id="option"> ALL
  </label>
  &nbsp;&nbsp;&nbsp;<label class="btn btn-info"><input type="radio" name="options" id="option1"> BOILER
  </label>
  &nbsp;&nbsp;&nbsp;<label class="btn btn-success"><input type="radio" name="options" id="option2" > EPC
  </label>
  &nbsp;&nbsp;&nbsp;<label class="btn btn-success"><input type="radio" name="options" id="option3" > SMD
  </label>
      &nbsp;&nbsp;&nbsp;<label class="btn btn-success"><input type="radio" name="options" id="option4" > PC
  </label>
      &nbsp;&nbsp;&nbsp;<label class="btn btn-success"><input type="radio" name="options" id="option5" > APC
  </label>
&nbsp;&nbsp;&nbsp;</div>
      </div>

         <div class="col-7">
    <div class="btn-group btn-group-toggle" data-toggle="buttons">
  <label class="btn btn-warning active">
    <input type="radio" name="options" id="option6">    ALL
  </label>
       &nbsp;&nbsp;&nbsp;<label class="btn btn-warning"><input type="radio" name="options" id="option12" > MECHANICAL
  </label>
  &nbsp;&nbsp;&nbsp;<label class="btn btn-warning"><input type="radio" name="options" id="option7" > STRUCTURE
  </label>
  &nbsp;&nbsp;&nbsp;<label class="btn btn-success"><input type="radio" name="options" id="option8" > PIPING
  </label>
      &nbsp;&nbsp;&nbsp;<label class="btn btn-success"><input type="radio" name="options" id="option9" > PROCESS
  </label>
      &nbsp;&nbsp;&nbsp;<label class="btn btn-success"><input type="radio" name="options" id="option10" > ELECTRICAL
  </label>
        &nbsp;&nbsp;&nbsp;<label class="btn btn-success"><input type="radio" name="options" id="option11" > C&I
  </label>
&nbsp;&nbsp;&nbsp;</div>
      </div>

         </div>     --%>
     <hr style="color:brown;background-color:darkslategrey;width:100%;height:3px">

     <div class="row  mt-3">
       
      <div class="col-3">
     
            <div class="form-group">

              <div class="input-group">
                
                 
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
        <div class="col-6">
       
            <div class="form-group">

              <div class="input-group">

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
       
     <div class="row mt-3">

     
    <div class="col-10">
       
            <div class="form-group">

              <div class="input-group">

                <a href="#Repo" class="btn btn-warning btn-outline-dark" style="width: 140px; text-align: center; cursor: pointer" data-toggle="collapse"><b>Report</b></a>
  <div id="Repo" class="collapse">
    Select Report for which Information need to fetched from ERPLN and displayed on DashBoard.
    Click again 'Division' button To Hide this Information.
  </div>

<asp:dropdownlist ID="Dropdownlist4" CssClass="form-control" ClientIDMode="static" runat="Server" style="color:green">
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
   
         </div>

        
     
          <div class="col-2">
          <asp:Button ID="cmdSubmit" runat="server" CssClass="btn btn-warning ml-1" Text="SHOW" ToolTip="Click to Search Document " Font-Bold="true" Font-Names="Comic Sans MS" />
          </div>
         
         </div>

    <hr style="color:brown;background-color:darkslategrey;width:100%;height:3px">
  
      
          <div class="row">
          <div class="col-4"></div>
    <div class="col-4">
     
     
  
   

      <div class="row">
              
                <div class="col-4">

                </div> 

        <div class="col-8">

                    <div class="row">
            <div class="col-4">
                                   <asp:label ID="label3" runat="server" ToolTip="" Font-Size="Large" Text="Planned" Font-Bold="true" Font-Names="Comic Sans MS" ></asp:label>

                </div>

              <div class="col-4">
                                   <asp:label ID="label4" runat="server"  Font-Size="Large" ToolTip="" Text="Released" Font-Bold="true" Font-Names="Comic Sans MS" ></asp:label>

                </div>

              <div class="col-4">
                                   <asp:label ID="label5" runat="server"  Font-Size="Large" ToolTip="" Text="Balance" Font-Bold="true" Font-Names="Comic Sans MS" ></asp:label>

                </div>
                       </div>
           </div>
           
         
          
                 </div>
    
           
              
   

         <div class="row">
                   
                <div class="col-4">
                  <asp:label ID="label101" runat="server" CssClass="btn btn-light btn-block" ToolTip="" Text="" Font-Bold="true" Font-Names="Comic Sans MS" ></asp:label>
                </div>


                <div class="col-8">
                    <div class="row">
                      <div class="col-4">
                      <asp:Button ID="Button1" runat="server" CssClass="btn btn-outline-primary btn-block" ToolTip="" Text=""  Font-Names="Comic Sans MS"></asp:Button>
                    </div>
                    <div class="col-4">
                      <asp:Button ID="Button2" runat="server" CssClass="btn btn-outline-success btn-block" ToolTip="Process - Active Element - Free" Text="" Font-Bold="true"></asp:Button>
                    </div>
                     
                   
                     <div class="col-4">
                  
                      <asp:Button ID="Button3" runat="server" CssClass="btn btn-outline-danger btn-block" ToolTip="Process - Active Element - Partial" Text="" Font-Bold="true"></asp:Button>
                    </div>
                     </div>
                  </div>
                       </div>

          <div class="row">
                   
                <div class="col-4">
                  <asp:label ID="label102" runat="server" CssClass="btn btn-light btn-block" ToolTip="" Text="" Font-Bold="true" Font-Names="Comic Sans MS" ></asp:label>
                </div>
             <div class="col-8">
                    <div class="row">

                <div class="col-4">
                   
                      <asp:Button ID="Button61" runat="server" CssClass="btn btn-outline-primary btn-block" ToolTip="" Text=""  Font-Names="Comic Sans MS"></asp:Button>
                    </div>
                    <div class="col-4">
                      <asp:Button ID="Button62" runat="server" CssClass="btn btn-outline-success btn-block" ToolTip="Process - Active Element - Free" Text="" Font-Bold="true"></asp:Button>
                    </div>
                     
                   
                     <div class="col-4">
                  
                      <asp:Button ID="Button63" runat="server" CssClass="btn btn-outline-danger btn-block" ToolTip="Process - Active Element - Partial" Text="" Font-Bold="true"></asp:Button>
                    </div>
                     
                       </div>
                   </div>

                </div>
      <div class="row">
                   
                <div class="col-4">
                  <asp:label ID="label103" runat="server" CssClass="btn btn-light btn-block" ToolTip="" Text="" Font-Bold="true" Font-Names="Comic Sans MS" ></asp:label>
                </div>
             <div class="col-8">
                    <div class="row">

                <div class="col-4">
                   
                      <asp:Button ID="Button4" runat="server" CssClass="btn btn-outline-primary btn-block" ToolTip="" Text=""  Font-Names="Comic Sans MS"></asp:Button>
                    </div>
                    <div class="col-4">
                      <asp:Button ID="Button5" runat="server" CssClass="btn btn-outline-success btn-block" ToolTip="Process - Active Element - Free" Text="" Font-Bold="true"></asp:Button>
                    </div>
                     
                   
                     <div class="col-4">
                  
                      <asp:Button ID="Button6" runat="server" CssClass="btn btn-outline-danger btn-block" ToolTip="Process - Active Element - Partial" Text="" Font-Bold="true"></asp:Button>
                    </div>
                     
                       </div>
                   </div>

                </div>
      <div class="row">
                   
                <div class="col-4">
                  <asp:label ID="label104" runat="server" CssClass="btn btn-light btn-block" ToolTip="" Text="" Font-Bold="true" Font-Names="Comic Sans MS" ></asp:label>
                </div>
             <div class="col-8">
                    <div class="row">

                <div class="col-4">
                   
                      <asp:Button ID="Button7" runat="server" CssClass="btn btn-outline-primary btn-block" ToolTip="" Text=""  Font-Names="Comic Sans MS"></asp:Button>
                    </div>
                    <div class="col-4">
                      <asp:Button ID="Button8" runat="server" CssClass="btn btn-outline-success btn-block" ToolTip="Process - Active Element - Free" Text="" Font-Bold="true"></asp:Button>
                    </div>
                     
                   
                     <div class="col-4">
                  
                      <asp:Button ID="Button9" runat="server" CssClass="btn btn-outline-danger btn-block" ToolTip="Process - Active Element - Partial" Text="" Font-Bold="true"></asp:Button>
                    </div>
                     
                       </div>
                   </div>

                </div>
      <div class="row">
                   
                <div class="col-4">
                  <asp:label ID="label105" runat="server" CssClass="btn btn-light btn-block" ToolTip="" Text="" Font-Bold="true" Font-Names="Comic Sans MS" ></asp:label>
                </div>
             <div class="col-8">
                    <div class="row">

                <div class="col-4">
                   
                      <asp:Button ID="Button10" runat="server" CssClass="btn btn-outline-primary btn-block" ToolTip="" Text=""  Font-Names="Comic Sans MS"></asp:Button>
                    </div>
                    <div class="col-4">
                      <asp:Button ID="Button11" runat="server" CssClass="btn btn-outline-success btn-block" ToolTip="Process - Active Element - Free" Text="" Font-Bold="true"></asp:Button>
                    </div>
                     
                   
                     <div class="col-4">
                  
                      <asp:Button ID="Button12" runat="server" CssClass="btn btn-outline-danger btn-block" ToolTip="Process - Active Element - Partial" Text="" Font-Bold="true"></asp:Button>
                    </div>
                     
                       </div>
                   </div>

                </div>
      <div class="row">
                   
                <div class="col-4">
                  <asp:label ID="label106" runat="server" CssClass="btn btn-light btn-block" ToolTip="" Text="" Font-Bold="true" Font-Names="Comic Sans MS" ></asp:label>
                </div>
             <div class="col-8">
                    <div class="row">

                <div class="col-4">
                   
                      <asp:Button ID="Button13" runat="server" CssClass="btn btn-outline-primary btn-block" ToolTip="" Text=""  Font-Names="Comic Sans MS"></asp:Button>
                    </div>
                    <div class="col-4">
                      <asp:Button ID="Button14" runat="server" CssClass="btn btn-outline-success btn-block" ToolTip="Process - Active Element - Free" Text="" Font-Bold="true"></asp:Button>
                    </div>
                     
                   
                     <div class="col-4">
                  
                      <asp:Button ID="Button15" runat="server" CssClass="btn btn-outline-danger btn-block" ToolTip="Process - Active Element - Partial" Text="" Font-Bold="true"></asp:Button>
                    </div>
                     
                       </div>
                   </div>

                </div>
      <div class="row">
                   
                <div class="col-4">
                  <asp:label ID="label107" runat="server" CssClass="btn btn-light btn-block" ToolTip="" Text="" Font-Bold="true" Font-Names="Comic Sans MS" ></asp:label>
                </div>
             <div class="col-8">
                    <div class="row">

                <div class="col-4">
                   
                      <asp:Button ID="Button16" runat="server" CssClass="btn btn-outline-primary btn-block" ToolTip="" Text=""  Font-Names="Comic Sans MS"></asp:Button>
                    </div>
                    <div class="col-4">
                      <asp:Button ID="Button17" runat="server" CssClass="btn btn-outline-success btn-block" ToolTip="Process - Active Element - Free" Text="" Font-Bold="true"></asp:Button>
                    </div>
                     
                   
                     <div class="col-4">
                  
                      <asp:Button ID="Button18" runat="server" CssClass="btn btn-outline-danger btn-block" ToolTip="Process - Active Element - Partial" Text="" Font-Bold="true"></asp:Button>
                    </div>
                     
                       </div>
                   </div>

                </div>
      <div class="row">
                   
                <div class="col-4">
                  <asp:label ID="label108" runat="server" CssClass="btn btn-light btn-block" ToolTip="" Text="" Font-Bold="true" Font-Names="Comic Sans MS" ></asp:label>
                </div>
             <div class="col-8">
                    <div class="row">

                <div class="col-4">
                   
                      <asp:Button ID="Button19" runat="server" CssClass="btn btn-outline-primary btn-block" ToolTip="" Text=""  Font-Names="Comic Sans MS"></asp:Button>
                    </div>
                    <div class="col-4">
                      <asp:Button ID="Button20" runat="server" CssClass="btn btn-outline-success btn-block" ToolTip="Process - Active Element - Free" Text="" Font-Bold="true"></asp:Button>
                    </div>
                     
                   
                     <div class="col-4">
                  
                      <asp:Button ID="Button21" runat="server" CssClass="btn btn-outline-danger btn-block" ToolTip="Process - Active Element - Partial" Text="" Font-Bold="true"></asp:Button>
                    </div>
                     
                       </div>
                   </div>

                </div>
          <div class="row">
                   
                <div class="col-4">
                  <asp:label ID="label109" runat="server" CssClass="btn btn-light btn-block" ToolTip="" Text="" Font-Bold="true" Font-Names="Comic Sans MS" ></asp:label>
                </div>
             <div class="col-8">
                    <div class="row">

                <div class="col-4">
                   
                      <asp:Button ID="Button22" runat="server" CssClass="btn btn-outline-primary btn-block" ToolTip="" Text=""  Font-Names="Comic Sans MS"></asp:Button>
                    </div>
                    <div class="col-4">
                      <asp:Button ID="Button23" runat="server" CssClass="btn btn-outline-success btn-block" ToolTip="Process - Active Element - Free" Text="" Font-Bold="true"></asp:Button>
                    </div>
                     
                   
                     <div class="col-4">
                  
                      <asp:Button ID="Button24" runat="server" CssClass="btn btn-outline-danger btn-block" ToolTip="Process - Active Element - Partial" Text="" Font-Bold="true"></asp:Button>
                    </div>
                     
                       </div>
                   </div>

                </div>
       <div class="row">
                   
                <div class="col-4">
                  <asp:label ID="label110" runat="server" CssClass="btn btn-light btn-block" ToolTip="" Text="" Font-Bold="true" Font-Names="Comic Sans MS" ></asp:label>
                </div>
             <div class="col-8">
                    <div class="row">

                <div class="col-4">
                   
                      <asp:Button ID="Button25" runat="server" CssClass="btn btn-outline-primary btn-block" ToolTip="" Text=""  Font-Names="Comic Sans MS"></asp:Button>
                    </div>
                    <div class="col-4">
                      <asp:Button ID="Button26" runat="server" CssClass="btn btn-outline-success btn-block" ToolTip="Process - Active Element - Free" Text="" Font-Bold="true"></asp:Button>
                    </div>
                     
                   
                     <div class="col-4">
                  
                      <asp:Button ID="Button27" runat="server" CssClass="btn btn-outline-danger btn-block" ToolTip="Process - Active Element - Partial" Text="" Font-Bold="true"></asp:Button>
                    </div>
                     
                       </div>
                   </div>

                </div>
       <div class="row">
                   
                <div class="col-4">
                  <asp:label ID="label111" runat="server" CssClass="btn btn-light btn-block" ToolTip="" Text="" Font-Bold="true" Font-Names="Comic Sans MS" ></asp:label>
                </div>
             <div class="col-8">
                    <div class="row">

                <div class="col-4">
                   
                      <asp:Button ID="Button28" runat="server" CssClass="btn btn-outline-primary btn-block" ToolTip="" Text=""  Font-Names="Comic Sans MS"></asp:Button>
                    </div>
                    <div class="col-4">
                      <asp:Button ID="Button29" runat="server" CssClass="btn btn-outline-success btn-block" ToolTip="Process - Active Element - Free" Text="" Font-Bold="true"></asp:Button>
                    </div>
                     
                   
                     <div class="col-4">
                  
                      <asp:Button ID="Button30" runat="server" CssClass="btn btn-outline-danger btn-block" ToolTip="Process - Active Element - Partial" Text="" Font-Bold="true"></asp:Button>
                    </div>
                     
                       </div>
                   </div>

                </div>
        
      
     </div>
         <div class="col-4"></div>
    
          </div>
 

  <%--  <table style="width:50%" border="2">
  <tr>
    <th><asp:label ID="Button1" runat="server" ToolTip="Process - Active Element - Partial" Text="" Font-Bold="true"></asp:label></th>
    <th><asp:label ID="Button2" runat="server"  ToolTip="Process - Active Element - Partial" Text="Planned" Font-Bold="true"></asp:label></th>
   <th><asp:label ID="Button3" runat="server"  ToolTip="Process - Active Element - Partial" Text="Released" Font-Bold="true"></asp:label></th>
    <th><asp:label ID="Button4" runat="server"  ToolTip="Process - Active Element - Partial" Text="Balance" Font-Bold="true"></asp:label></th>
  </tr>
  <tr>
    <td><asp:button ID="Label1" runat="server"  ToolTip="Process - Active Element - Partial" Text="" Font-Bold="true"></asp:button></td>
     <td><asp:button ID="Button5" runat="server"  ToolTip="Process - Active Element - Partial" Text="" Font-Bold="true"></asp:button></td>
     <td><asp:button ID="Button6" runat="server"  ToolTip="Process - Active Element - Partial" Text="" Font-Bold="true"></asp:button></td>
     <td><asp:button ID="Button7" runat="server"  ToolTip="Process - Active Element - Partial" Text="" Font-Bold="true"></asp:button></td>
  </tr>
  <tr>
    <td><asp:button ID="Button8" runat="server"  ToolTip="Process - Active Element - Partial" Text="" Font-Bold="true"></asp:button></td>
     <td><asp:button ID="Button9" runat="server"  ToolTip="Process - Active Element - Partial" Text="" Font-Bold="true"></asp:button></td>
     <td><asp:button ID="Button10" runat="server"  ToolTip="Process - Active Element - Partial" Text="" Font-Bold="true"></asp:button></td>
     <td><asp:button ID="Button11" runat="server"  ToolTip="Process - Active Element - Partial" Text="" Font-Bold="true"></asp:button></td>
  </tr>
      <tr>
    <td><asp:button ID="Button12" runat="server"  ToolTip="Process - Active Element - Partial" Text="" Font-Bold="true"></asp:button></td>
     <td><asp:button ID="Button13" runat="server"  ToolTip="Process - Active Element - Partial" Text="" Font-Bold="true"></asp:button></td>
     <td><asp:button ID="Button14" runat="server"  ToolTip="Process - Active Element - Partial" Text="" Font-Bold="true"></asp:button></td>
     <td><asp:button ID="Button15" runat="server"  ToolTip="Process - Active Element - Partial" Text="" Font-Bold="true"></asp:button></td>
  </tr>
      <tr>
    <td><asp:button ID="Button16" runat="server"  ToolTip="Process - Active Element - Partial" Text="" Font-Bold="true"></asp:button></td>
     <td><asp:button ID="Button17" runat="server"  ToolTip="Process - Active Element - Partial" Text="" Font-Bold="true"></asp:button></td>
     <td><asp:button ID="Button18" runat="server"  ToolTip="Process - Active Element - Partial" Text="" Font-Bold="true"></asp:button></td>
     <td><asp:button ID="Button19" runat="server"  ToolTip="Process - Active Element - Partial" Text="" Font-Bold="true"></asp:button></td>
  </tr>
      <tr>
    <td><asp:button ID="Button20" runat="server"  ToolTip="Process - Active Element - Partial" Text="" Font-Bold="true"></asp:button></td>
     <td><asp:button ID="Button21" runat="server"  ToolTip="Process - Active Element - Partial" Text="" Font-Bold="true"></asp:button></td>
     <td><asp:button ID="Button22" runat="server"  ToolTip="Process - Active Element - Partial" Text="" Font-Bold="true"></asp:button></td>
     <td><asp:button ID="Button23" runat="server"  ToolTip="Process - Active Element - Partial" Text="" Font-Bold="true"></asp:button></td>
  </tr>
       <tr>
    <td><asp:button ID="Button24" runat="server"  ToolTip="Process - Active Element - Partial" Text="" Font-Bold="true"></asp:button></td>
     <td><asp:button ID="Button25" runat="server"  ToolTip="Process - Active Element - Partial" Text="" Font-Bold="true"></asp:button></td>
     <td><asp:button ID="Button26" runat="server"  ToolTip="Process - Active Element - Partial" Text="" Font-Bold="true"></asp:button></td>
     <td><asp:button ID="Button27" runat="server"  ToolTip="Process - Active Element - Partial" Text="" Font-Bold="true"></asp:button></td>
  </tr>
  <tr>
    <td><asp:button ID="Button28" runat="server"  ToolTip="Process - Active Element - Partial" Text="" Font-Bold="true"></asp:button></td>
     <td><asp:button ID="Button29" runat="server"  ToolTip="Process - Active Element - Partial" Text="" Font-Bold="true"></asp:button></td>
     <td><asp:button ID="Button30" runat="server"  ToolTip="Process - Active Element - Partial" Text="" Font-Bold="true"></asp:button></td>
     <td><asp:button ID="Button31" runat="server"  ToolTip="Process - Active Element - Partial" Text="" Font-Bold="true"></asp:button></td>
  </tr>
      <tr>
    <td><asp:button ID="Button32" runat="server"  ToolTip="Process - Active Element - Partial" Text="" Font-Bold="true"></asp:button></td>
     <td><asp:button ID="Button33" runat="server"  ToolTip="Process - Active Element - Partial" Text="" Font-Bold="true"></asp:button></td>
     <td><asp:button ID="Button34" runat="server"  ToolTip="Process - Active Element - Partial" Text="" Font-Bold="true"></asp:button></td>
     <td><asp:button ID="Button35" runat="server"  ToolTip="Process - Active Element - Partial" Text="" Font-Bold="true"></asp:button></td>
  </tr>
      <tr>
    <td><asp:button ID="Button36" runat="server"  ToolTip="Process - Active Element - Partial" Text="" Font-Bold="true"></asp:button></td>
     <td><asp:button ID="Button37" runat="server"  ToolTip="Process - Active Element - Partial" Text="" Font-Bold="true"></asp:button></td>
     <td><asp:button ID="Button38" runat="server"  ToolTip="Process - Active Element - Partial" Text="" Font-Bold="true"></asp:button></td>
     <td><asp:button ID="Button39" runat="server"  ToolTip="Process - Active Element - Partial" Text="" Font-Bold="true"></asp:button></td>
  </tr>
      <tr>
    <td><asp:button ID="Button40" runat="server"  ToolTip="Process - Active Element - Partial" Text="" Font-Bold="true"></asp:button></td>
     <td><asp:button ID="Button41" runat="server"  ToolTip="Process - Active Element - Partial" Text="" Font-Bold="true"></asp:button></td>
     <td><asp:button ID="Button42" runat="server"  ToolTip="Process - Active Element - Partial" Text="" Font-Bold="true"></asp:button></td>
     <td><asp:button ID="Button43" runat="server"  ToolTip="Process - Active Element - Partial" Text="" Font-Bold="true"></asp:button></td>
  </tr>
       <tr>
    <td><asp:button ID="Button44" runat="server"  ToolTip="Process - Active Element - Partial" Text="" Font-Bold="true"></asp:button></td>
     <td><asp:button ID="Button45" runat="server"  ToolTip="Process - Active Element - Partial" Text="" Font-Bold="true"></asp:button></td>
     <td><asp:button ID="Button46" runat="server"  ToolTip="Process - Active Element - Partial" Text="" Font-Bold="true"></asp:button></td>
     <td><asp:button ID="Button47" runat="server"  ToolTip="Process - Active Element - Partial" Text="" Font-Bold="true"></asp:button></td>
  </tr>
      <tr>
    <td><asp:button ID="Button48" runat="server"  ToolTip="Process - Active Element - Partial" Text="" Font-Bold="true"></asp:button></td>
     <td><asp:button ID="Button49" runat="server"  ToolTip="Process - Active Element - Partial" Text="" Font-Bold="true"></asp:button></td>
     <td><asp:button ID="Button50" runat="server"  ToolTip="Process - Active Element - Partial" Text="" Font-Bold="true"></asp:button></td>
     <td><asp:button ID="Button51" runat="server"  ToolTip="Process - Active Element - Partial" Text="" Font-Bold="true"></asp:button></td>
  </tr>

</table>--%>

   <hr>
    <hr>
    
    
     </ContentTemplate>
          <Triggers>
            <asp:PostBackTrigger ControlID="cmdSubmit" />
          </Triggers>
        </asp:UpdatePanel>
   
       
         
    
</div>
</div>
</asp:Content>