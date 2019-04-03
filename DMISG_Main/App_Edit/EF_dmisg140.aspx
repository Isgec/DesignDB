<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_dmisg140.aspx.vb" Inherits="EF_dmisg140" title="Edit: PMDL" %>
<asp:Content ID="CPHdmisg140" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="Labeldmisg140" runat="server" Text="&nbsp;Edit: PMDL"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLdmisg140" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLdmisg140"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnablePrint = "True"
    PrintUrl = "../App_Print/RP_dmisg140.aspx?pk="
    ValidationGroup = "dmisg140"
    runat = "server" />
    <script type="text/javascript">
      var pcnt = 0;
      function print_report(o) {
        pcnt = pcnt + 1;
        var nam = 'wTask' + pcnt;
        var url = self.location.href.replace('App_Forms/GF_','App_Print/RP_');
        url = url + '?pk=' + o.alt;
        url = o.alt;
        window.open(url, nam, 'left=20,top=20,width=1000,height=600,toolbar=1,resizable=1,scrollbars=1');
        return false;
      }
    </script>
<asp:FormView ID="FVdmisg140"
  runat = "server"
  DataKeyNames = "t_cprj,t_docn"
  DataSourceID = "ODSdmisg140"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_t_cprj" runat="server" ForeColor="#CC6633" Text="Project :" />&nbsp;</b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_t_cprj"
            Text='<%# Bind("t_cprj") %>'
            ToolTip="Value of Project."
            Enabled = "False"
            Width="80px"
            CssClass = "dmypktxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_t_docn" runat="server" ForeColor="#CC6633" Text="Document :" />&nbsp;</b>
        </td>
        <td>
          <asp:TextBox ID="F_t_docn"
            Text='<%# Bind("t_docn") %>'
            ToolTip="Value of Document."
            Enabled = "False"
            Width="264px"
            CssClass = "dmypktxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_t_revn" runat="server" Text="REV :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_t_revn"
            Text='<%# Bind("t_revn") %>'
            ToolTip="Value of REV."
            Enabled = "False"
            Width="264px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_t_dsca" runat="server" Text="Title :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_t_dsca"
            Text='<%# Bind("t_dsca") %>'
            ToolTip="Value of Title."
            Enabled = "False"
            Width="350px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_t_cspa" runat="server" Text="Element :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_t_cspa"
            Text='<%# Bind("t_cspa") %>'
            ToolTip="Value of Element."
            Enabled = "False"
            Width="72px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_t_resp" runat="server" Text="Department :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_t_resp"
            Text='<%# Bind("t_resp") %>'
            ToolTip="Value of Department."
            Enabled = "False"
            Width="32px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_t_lrrd" runat="server" Text="Released On :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_t_lrrd"
            Text='<%# Bind("t_lrrd") %>'
            ToolTip="Value of Released On."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabeldwgHoldList" runat="server" Text="&nbsp;List: Hold Drawing List"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLdwgHoldList" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLdwgHoldList"
      ToolType = "lgNMGrid"
      EditUrl = "~/DMISG_Main/App_Edit/EF_dwgHoldList.aspx"
      EnableAdd = "False"
      EnableExit = "false"
      ValidationGroup = "dwgHoldList"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSdwgHoldList" runat="server" AssociatedUpdatePanelID="UPNLdwgHoldList" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVdwgHoldList" SkinID="gv_silver" runat="server" DataSourceID="ODSdwgHoldList" DataKeyNames="ProjectID,DocumentID,SerialNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="S.N." SortExpression="SerialNo">
          <ItemTemplate>
            <asp:Label ID="LabelSerialNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SerialNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Document" SortExpression="DocumentID">
          <ItemTemplate>
            <asp:Label ID="LabelDocumentID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DocumentID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Revision At Hold" SortExpression="RevisionAtHold">
          <ItemTemplate>
            <asp:Label ID="LabelRevisionAtHold" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("RevisionAtHold") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Title" SortExpression="Description">
          <ItemTemplate>
            <asp:Label ID="LabelDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Description") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Element" SortExpression="Element">
          <ItemTemplate>
            <asp:Label ID="LabelElement" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Element") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Responsible Dept" SortExpression="ResponsibleDept">
          <ItemTemplate>
            <asp:Label ID="LabelResponsibleDept" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ResponsibleDept") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Created By" SortExpression="aspnet_users1_UserFullName">
          <ItemTemplate>
             <asp:Label ID="L_CreatedBy" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("CreatedBy") %>' Text='<%# Eval("aspnet_users1_UserFullName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Created On" SortExpression="CreatedOn">
          <ItemTemplate>
            <asp:Label ID="LabelCreatedOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CreatedOn") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSdwgHoldList"
      runat = "server"
      DataObjectTypeName = "SIS.DMISG.dwgHoldList"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_dwgHoldListSelectList"
      TypeName = "SIS.DMISG.dwgHoldList"
      SelectCountMethod = "dwgHoldListSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_DocumentID" PropertyName="Text" Name="DocumentID" Type="String" Size="25" />
        <asp:ControlParameter ControlID="F_ProjectID" PropertyName="Text" Name="ProjectID" Type="String" Size="6" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVdwgHoldList" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSdmisg140"
  DataObjectTypeName = "SIS.DMISG.dmisg140"
  SelectMethod = "dmisg140GetByID"
  UpdateMethod="UZ_dmisg140Update"
  DeleteMethod="dmisg140Delete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.DMISG.dmisg140"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="t_cprj" Name="t_cprj" Type="String" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="t_docn" Name="t_docn" Type="String" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
