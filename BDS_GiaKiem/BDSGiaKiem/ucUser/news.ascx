<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="news.ascx.cs" Inherits="BDSGiaKiem.ucUser.news" %>
<%@ Register src="news_detail.ascx" tagname="news_detail" tagprefix="uc1" %>
<div id="article">
    <p class="title">Tin tức bất động sản</p>
    <ul class="lstnews">
<asp:Repeater ID="Repeater1" runat="server" DataSourceID="LinqDataSource1">
           <ItemTemplate>
                <li>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("ID", "/default.aspx?section=news_detail&id={0}") %>'>>> <%# formatTitle(Eval("Title").ToString()) %></asp:HyperLink>
                </li>
               
            </ItemTemplate>
</asp:Repeater>
</ul>
<asp:LinqDataSource ID="LinqDataSource1" runat="server" 
    ContextTypeName="BDSGiaKiem.BDSDataContext" OrderBy="LastUpdatedTime desc" 
    Select="new (ID, Title, LastUpdatedTime)" TableName="News">
</asp:LinqDataSource>
</div>