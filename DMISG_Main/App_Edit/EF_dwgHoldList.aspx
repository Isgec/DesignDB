<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_dwgHoldList.aspx.vb" Inherits="EF_dwgHoldList" title="Edit: Hold Drawing List" %>
<asp:Content ID="CPHdwgHoldList" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeldwgHoldList" runat="server" Text="&nbsp;Edit: Hold Drawing List"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLdwgHoldList" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLdwgHoldList"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "dwgHoldList"
    runat = "server" />
<asp:FormView ID="FVdwgHoldList"
  runat = "server"
  DataKeyNames = "ProjectID,DocumentID,SerialNo"
  DataSourceID = "ODSdwgHoldList"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_SerialNo" runat="server" ForeColor="#CC6633" Text="S.N. :" /></b>
        </td>
        <td>
          <asp:TextBox ID="F_SerialNo"
            Text='<%# Bind("SerialNo") %>'
            ToolTip="Value of S.N.."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="88px"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_HoldStatus" runat="server" Text="Status :" />
        </td>
        <td>
          <asp:DropDownList
            ID="F_HoldStatus"
            SelectedValue='<%# Bind("HoldStatus") %>'
            Width="100px"
            Enabled = "False"
            Runat="Server" >
            <asp:ListItem Value="">-----</asp:ListItem>
            <asp:ListItem Value="True">HOLD</asp:ListItem>
            <asp:ListItem Value="False">UNHOLD</asp:ListItem>
          </asp:DropDownList>
         </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ProjectID" runat="server" ForeColor="#CC6633" Text="Project :" />
        </td>
        <td>
          <asp:TextBox
            ID = "F_ProjectID"
            Width="56px"
            Text='<%# Bind("ProjectID") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            Runat="Server" />
          <asp:Label
            ID = "F_ProjectID_Display"
            Text='<%# Eval("IDM_Projects2_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="Label1" runat="server" Text="Released On :" />
        </td>
        <td>
          <asp:TextBox ID="F_DateOfIssue"
            Text='<%# Bind("DateOfIssue") %>'
            Width="80px"
            Enabled="false"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_DocumentID" runat="server" ForeColor="#CC6633" Text="Document :" /></b>
        </td>
        <td>
          <asp:TextBox ID="F_DocumentID"
            Text='<%# Bind("DocumentID") %>'
            Enabled="false"
            Width="208px"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_RevisionAtHold" runat="server" Text="Revision :" />
        </td>
        <td>
          <asp:TextBox ID="F_RevisionAtHold"
            Text='<%# Bind("RevisionAtHold") %>'
            Width="64px"
            Enabled="false"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Description" runat="server" Text="Title :" />
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Description"
            Text='<%# Bind("Description") %>'
            Width="550px"
            Enabled="false"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Element" runat="server" Text="Element :" />
        </td>
        <td>
          <asp:TextBox ID="F_Element"
            Text='<%# Bind("Element") %>'
            Width="72px"
            Enabled="false"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ResponsibleDept" runat="server" Text="Responsible Dept :" />
        </td>
        <td>
          <asp:TextBox ID="F_ResponsibleDept"
            Text='<%# Bind("ResponsibleDept") %>'
            Width="32px"
            Enabled="false"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr id="r_Part" runat="server" clientIDMode="Static">
        <td class="alignright">
          <asp:Label ID="L_PartUnderHold" runat="server" Text="Part Under Hold :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_PartUnderHold"
            Text='<%# Bind("PartUnderHold") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="dwgHoldList"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Part Under Hold."
            MaxLength="50"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVPartUnderHold"
            runat = "server"
            ControlToValidate = "F_PartUnderHold"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "dwgHoldList"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr id="r_Reason" runat="server" clientIDMode="Static">
        <td class="alignright">
          <asp:Label ID="L_ReasonForHold" runat="server" Text="Reason For Hold :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ReasonForHold"
            Text='<%# Bind("ReasonForHold") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="dwgHoldList"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Reason For Hold."
            MaxLength="50"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVReasonForHold"
            runat = "server"
            ControlToValidate = "F_ReasonForHold"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "dwgHoldList"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr id="r_input" runat="server" clientIDMode="Static">
        <td class="alignright">
          <asp:Label ID="L_InputReceivedOn" runat="server" Text="Input Received On :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_InputReceivedOn"
            Text='<%# Bind("InputReceivedOn") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="dwgHoldList"
            runat="server" />
          <asp:Image ID="ImageButtonInputReceivedOn" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEInputReceivedOn"
            TargetControlID="F_InputReceivedOn"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonInputReceivedOn" />
          <AJX:MaskedEditExtender 
            ID = "MEEInputReceivedOn"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_InputReceivedOn" />
          <AJX:MaskedEditValidator 
            ID = "MEVInputReceivedOn"
            runat = "server"
            ControlToValidate = "F_InputReceivedOn"
            ControlExtender = "MEEInputReceivedOn"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "dwgHoldList"
            IsValidEmpty = "false"
            SetFocusOnError="true" />
        </td>

      </tr>
      <tr id="r_issue" runat="server" clientIDMode="Static">
        <td class="alignright">
          <asp:Label ID="L_DateOfIssue" runat="server" Text="Date Of Issue :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_HoldRemovedIssued"
            Text='<%# Bind("HoldRemovedIssued") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="dwgHoldList"
            runat="server" />
          <asp:Image ID="ImageButtonDateOfIssue" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEDateOfIssue"
            TargetControlID="F_HoldRemovedIssued"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonDateOfIssue" />
          <AJX:MaskedEditExtender 
            ID = "MEEDateOfIssue"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_HoldRemovedIssued" />
          <AJX:MaskedEditValidator 
            ID = "MEVDateOfIssue"
            runat = "server"
            ControlToValidate = "F_HoldRemovedIssued"
            ControlExtender = "MEEDateOfIssue"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "dwgHoldList"
            IsValidEmpty = "false"
            SetFocusOnError="true" />
        </td>
      </tr>
    </table>
  </div>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSdwgHoldList"
  DataObjectTypeName = "SIS.DMISG.dwgHoldList"
  SelectMethod = "UZ_dwgHoldListGetByID"
  UpdateMethod="UZ_dwgHoldListUpdate"
  DeleteMethod="dwgHoldListDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.DMISG.dwgHoldList"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ProjectID" Name="ProjectID" Type="String" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="DocumentID" Name="DocumentID" Type="String" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SerialNo" Name="SerialNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
