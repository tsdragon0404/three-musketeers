<%@ Page Language="C#" MasterPageFile="~/Client.Master" AutoEventWireup="true" CodeBehind="Article.aspx.cs"
    Inherits="BatDongSan.Article1" Title="Tin tức - Sự kiện" %>

<%@ Register Assembly="obout_Editor" Namespace="OboutInc.Editor" TagPrefix="obout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <div class="top">
            <img class="icon" src="images/templates/default/top_news/icon.png" />
            <p class="section_title">
                Tin tức</p>
        </div>
        <div class="mid">
            <div class="wrap">
                <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="BatDongSan.BDSDataContext"
                    TableName="Articles" Where="ID == @ID">
                    <WhereParameters>
                        <asp:QueryStringParameter DefaultValue="0" Name="ID" QueryStringField="key" Type="Int64" />
                    </WhereParameters>
                </asp:LinqDataSource>
                <asp:DataList ID="DataList1" CssClass="tbl_1" runat="server" DataKeyField="ID" DataSourceID="LinqDataSource1"
                    Width="100%">
                    <ItemTemplate>
                        <p class="article_title">
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("Title") %>'></asp:Label></p>
                        <p class="info">
                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("PostDate", "Đăng ngày {0:dd-MM-yyyy} .") %>'></asp:Label></p>
                        <p class="article_summary">
                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("Summary") %>'></asp:Label>
                        </p>
                        <p class="article_content">
                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("Contents") %>'></asp:Label></p>
                    </ItemTemplate>
                </asp:DataList>
                <asp:LinqDataSource ID="LinqDataSource3" runat="server" ContextTypeName="BatDongSan.BDSDataContext"
                    OrderBy="ID desc" TableName="Articles" Where="ID &gt; @ID &amp;&amp; IsValid == @IsValid"
                    OnSelecting="LinqDataSource3_Selecting">
                    <WhereParameters>
                        <asp:QueryStringParameter DefaultValue="0" Name="ID" QueryStringField="key" Type="Int64" />
                        <asp:Parameter DefaultValue="True" Name="IsValid" Type="Boolean" />
                    </WhereParameters>
                </asp:LinqDataSource>
                <hr runat="server" id="line" />
                <asp:DataList CssClass="tbl_2" ID="DataList3" runat="server" DataSourceID="LinqDataSource3">
                    <HeaderTemplate>
                        <p class="info2">
                            Các tin mới hơn</p>
                    </HeaderTemplate>
                    <ItemTemplate>
                        •
                        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl='<%# "Article.aspx?key=" + Eval("ID") %>'
                            Text='<%# Eval("Title") %>'></asp:HyperLink>
                        <asp:Label ID="Label8" runat="server" CssClass="info" Text='<%# Eval("PostDate", "{0:(dd-MM-yyyy)}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:DataList>
                <asp:LinqDataSource ID="LinqDataSource2" runat="server" ContextTypeName="BatDongSan.BDSDataContext"
                    TableName="Articles" Where="ID &lt; @ID &amp;&amp; IsValid == @IsValid" OrderBy="ID desc"
                    OnSelecting="LinqDataSource2_Selecting">
                    <WhereParameters>
                        <asp:QueryStringParameter DefaultValue="0" Name="ID" QueryStringField="key" Type="Int64" />
                        <asp:Parameter DefaultValue="True" Name="IsValid" Type="Boolean" />
                    </WhereParameters>
                </asp:LinqDataSource>
                <asp:DataList ID="DataList2" CssClass="tbl_2" runat="server" DataSourceID="LinqDataSource2">
                    <HeaderTemplate>
                        <p class="info2">
                            Các tin cũ hơn</p>
                    </HeaderTemplate>
                    <ItemTemplate>
                        •
                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# "Article.aspx?key=" + Eval("ID") %>'
                            Text='<%# Eval("Title") %>'></asp:HyperLink>
                        <asp:Label ID="Label7" runat="server" CssClass="info" Text='<%# Eval("PostDate", "{0:(dd-MM-yyyy)}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:DataList>
                <asp:DataList CssClass="tbl_2" ID="DataList4" runat="server" DataSourceID="LinqDataSource4">
                    <HeaderTemplate>
                        <p class="info2">
                            Các tin mới nhất</p>
                    </HeaderTemplate>
                    <ItemTemplate>
                        •
                        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl='<%# "Article.aspx?key=" + Eval("ID") %>'
                            Text='<%# Eval("Title") %>'></asp:HyperLink>
                        <asp:Label ID="Label8" runat="server" CssClass="info" Text='<%# Eval("PostDate", "{0:(dd-MM-yyyy)}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:DataList>
                <asp:LinqDataSource ID="LinqDataSource4" runat="server" ContextTypeName="BatDongSan.BDSDataContext"
                    TableName="Articles" OnSelecting="LinqDataSource4_Selecting">
                </asp:LinqDataSource>
            </div>
        </div>
        <p class="bot">
            &nbsp;</p>
    </div>
</asp:Content>
