﻿<%@ Page Language="C#" AutoEventWireup="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>Default</title>
	</head>
	<body>
		<form id="form1" runat="server">
			<asp:TreeView ID="TreeView1" ForeColor="White" DataSourceID="SiteMapDataSource1" NodeIndent="0" NodeStyle-ChildNodesPadding="10" runat="server">
				<LevelStyles>
					<asp:TreeNodeStyle Font-Bold="true" />
					<asp:TreeNodeStyle />
					<asp:TreeNodeStyle Font-Size="x-small" />
				</LevelStyles>
				<NodeStyle ForeColor="White" HorizontalPadding="5" />
				<SelectedNodeStyle BackColor="lightblue" ForeColor="blue" />
				<HoverNodeStyle Font-Underline="true" />
			</asp:TreeView>
			<b>Current Page: </b>
			<asp:SiteMapPath ID="SiteMapPath2" runat="server" />
			<br />
			<br />
			<b>Jump To Page: </b>
			<asp:Menu ID="Menu1" DataSourceID="SiteMapDataSource1" runat="server" />
			<br />
			<br />
			<asp:SiteMapDataSource ID="SiteMapDataSource1" StartFromCurrentNode="true" ShowStartingNode="true" StartingNodeOffset="-1" runat="server" />
		</form>
	</body>
</html>
