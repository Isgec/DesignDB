<%@ Control Language="VB" AutoEventWireup="false"%>
		<script type="text/javascript">
			function hideAlert(ev) {
				var mPB = $find('mpeLgAlert');
				mPB.hide();
				return false;
			}
			function showAlert(ev) {
			  var mPB = $find('mpeLgAlert');
				mPB.show();
				return false;
			}
		</script>

		<asp:Label ID="dummy" runat="server" Style="display: none"></asp:Label>
		<asp:Panel ID="pnl1" runat="server" Height="250px" Width="400px" BackColor="Black" Style="display: none">
			<table width="100%">
				<tr>
					<td id="tdTitle" runat="server" style="background-color: Navy; cursor: move; text-align: left; width: 100%; font-weight: bold; color: Red">
						Warning...
					</td>
					<td style="background-color: Navy">
						<input type="image" id="cmdClose0" runat="server" style="height:18px; width:18px" onclick="return hideProcessingMPV();" alt="Close" title="Close" src="../App_Themes/Default/Images/closeWindow.png" />
					</td>
				</tr>
				<tr>
					<td id="msgbox" colspan="2" style="height: 225px; vertical-align:middle; text-align:center">
					  
					</td>
				</tr>
			</table>
		</asp:Panel>
		<AJX:ModalPopupExtender ID="pPopup" TargetControlID="dummy" BackgroundCssClass="modalBackground" BehaviorID="mpeLgAlert" CancelControlID="cmdClose0" OkControlID="dummy" PopupControlID="pnl1" PopupDragHandleControlID="tdTitle" runat="server">
		</AJX:ModalPopupExtender>
