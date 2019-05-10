<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="UserFB.Web.Feedback.Show" Title="显示页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>                   
                    <td class="tdbg">
                               
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		feedbackID
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblfeedbackID" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		UserID
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblUserID" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		feedbackTime
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblfeedbackTime" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		categoryID
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblcategoryID" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Info
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblInfo" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		contact
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblcontact" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		isInvalid
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblisInvalid" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		solutionState
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblsolutionState" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		handler
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblhandler" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		remark
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblremark" runat="server"></asp:Label>
	</td></tr>
</table>

                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>




