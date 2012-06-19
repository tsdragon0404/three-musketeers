<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="project_detail.ascx.cs" Inherits="BDSGiaKiem.ucUser.project_detail" %>
<div id="article">
<p class="title">
    <asp:Label ID="title" runat="server" Text="Label"></asp:Label></p>
    <div class="text">
        <asp:Label ID="text" runat="server" Text="Label"></asp:Label></div>
</div>
<div id="topics">
    <div class="topic">
        <asp:HyperLink ID="HLPlanning" runat="server">Chi tiết quy hoạch<img src="images/topic_1.png" />
        </asp:HyperLink>
    </div>
    <div class="topic">
        <asp:HyperLink ID="HLArea" runat="server">Các khu vực<img src="images/topic_1.png" />
        </asp:HyperLink>
    </div>
    <div class="topic">
        <a href="#">Tin tức liên quan<img src="images/topic_1.png" /></a>
    </div>
    <div class="clear">
    </div>
</div>