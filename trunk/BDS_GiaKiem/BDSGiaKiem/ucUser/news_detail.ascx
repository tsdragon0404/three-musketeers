<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="news_detail.ascx.cs"
    Inherits="BDSGiaKiem.ucUser.news_detail" %>
<div id="article">
    <p class="title">
        <asp:Label ID="lblTitle" runat="server"></asp:Label>
        <asp:Label ID="lblDate" runat="server" class="date"></asp:Label>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="/Default.aspx?section=news" CssClass="link">Quay lại trang tin tức</asp:HyperLink>
        </p>
    <div>
        <asp:Label ID="lblContent" runat="server"></asp:Label>
    </div>
</div>
