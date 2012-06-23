<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="default.ascx.cs" Inherits="BDSGiaKiem.ucUser._default" %>
<div id="home_pic">
    <asp:HyperLink ID="HLPic" runat="server">
        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="LinqDataSource1">
            <ItemTemplate>
                <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("ImageUrl", "../{0}") %>' AlternateText="Dự án" />
            </ItemTemplate>
        </asp:Repeater>
    </asp:HyperLink>
    <asp:LinqDataSource ID="LinqDataSource1" runat="server" 
        ContextTypeName="BDSGiaKiem.BDSDataContext" TableName="HomePics" 
        Where="IsUsed == @IsUsed">
        <WhereParameters>
            <asp:Parameter DefaultValue="true" Name="IsUsed" Type="Boolean" />
        </WhereParameters>
    </asp:LinqDataSource>
</div>
<div id="topics">
    <div class="topic">
        <asp:HyperLink ID="HLPlanning" runat="server" CssClass="topiclink">Chi tiết quy hoạch<img src="/images/topic_1.png" />
        </asp:HyperLink>
    </div>
    <div class="topic">
        <asp:HyperLink ID="HLArea" runat="server" CssClass="topiclink">Các khu vực<img src="/images/topic_1.png" />
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
        <p class="more"><a href="/Default.aspx?section=news">Xem thêm</a></p>
    </div>
    <div class="clear">
    </div>
</div>