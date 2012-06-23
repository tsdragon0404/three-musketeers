<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="project_detail.ascx.cs" Inherits="BDSGiaKiem.ucUser.project_detail" %>
<div id="article">
<p class="title">
    <asp:Label ID="title" runat="server" Text="Label"></asp:Label></p>
    <div class="text">
        <asp:Label ID="text" runat="server" Text="Label"></asp:Label></div>
</div>
<div id="topics">
    <div class="topic">
        <asp:HyperLink ID="HLPlanning" runat="server" CssClass="topiclink">Chi tiết quy hoạch<img src="images/topic_1.png" />
        </asp:HyperLink>
    </div>
    <div class="topic">
        <asp:HyperLink ID="HLArea" runat="server" CssClass="topiclink">Các khu vực<img src="images/topic_1.png" />
        </asp:HyperLink>
    </div>
    <div class="topic">
        <p class="title">Tin tức liên quan</p>
        <asp:Repeater ID="Repeater2" runat="server">
            <HeaderTemplate>
                <ul class="listNews">
            </HeaderTemplate>
            <ItemTemplate>
                <li><a href='/Default.aspx?section=news_detail&id=<%# Eval("ID") %>'>» <%# cutTitle(Eval("Title").ToString()) %></a></li>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    <div class="clear">
    </div>
</div>