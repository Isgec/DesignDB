<%@ Control Language="VB" AutoEventWireup="false" CodeFile="lgMessage.ascx.vb" Inherits="lgMessage" %>
<script type="text/javascript">
	function cancelMessage() {
		try {
			var tmp = '<%=OnBeforeCancel %>';
			eval(tmp);
		} catch (ex) { }
		var mPB = $find('mpe1');
		mPB.hide();
		try {
			var tmp = '<%=OnAfterCancel %>';
			eval(tmp);
		} catch (ex) { }

		return '<%=GetReturnTrueOnCancel %>';
	}
	function hideMessageMPV(s,e) {
		var mPB = $find('mpe1');
		mPB.hide();
		e.set_errorHandled(true);
		return false;
	}
	function showMessageMPV(ev) {
		var mPB = $find('mpe1');
		if (ev)
			$get('<%=dynamicData.ClientID %>').innerHTML = ev;
		mPB.show();
		return false;
	}
	function dynamicMessage(msg) {
		$get('<%=dynamicData.ClientID %>').style.display = 'block';
		$get('<%=dynamicData.ClientID %>').innerHTML = msg;
	}
	function backgroundColor(color) {
		$get('<%=dynamicData.ClientID %>').style.backgroundColor = color;
	}
</script>
<asp:Label ID="dummy" runat="server" Style="display: none"></asp:Label>
<asp:Panel ID="pnl1" runat="server" BackColor="Black" Style="display: none; min-height: 100px; min-width: 400px">
	<table style="width:100%">
		<tr>
			<td style="background-color:Navy; min-width:400px">
				<asp:Image ID="imgerr" runat="server" AlternateText="Message" ToolTip="Message" ImageUrl="~/App_Themes/Default/Images/Error1.gif" />
			</td>
			<td id="tdTitle" runat="server" style="background-color: Navy; cursor: move; text-align: left; width: 100%; font-weight: bold; color: White">
				Attendance System
			</td>
			<td style="background-color: Navy">
				<asp:ImageButton ID="cmdClose0" runat="server" Height="18px" Width="18px" OnClientClick="return cancelMessage();" AlternateText="Close" ToolTip="Close" ImageUrl="~/App_Themes/Default/Images/closeWindow.png" />
			</td>
		</tr>
	</table>
	<div id="dynamicData" runat="server" style="color:White; min-height:100px; min-width:400px;display:block" ></div>
</asp:Panel>
<AJX:ModalPopupExtender ID="mPopup" TargetControlID="dummy" BackgroundCssClass="modalBackground" BehaviorID="mpe1" CancelControlID="cmdClose0" OkControlID="cmdClose0" PopupControlID="pnl1" PopupDragHandleControlID="tdTitle" runat="server">
</AJX:ModalPopupExtender>
