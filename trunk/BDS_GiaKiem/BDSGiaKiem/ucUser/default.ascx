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