<%@ Page Language="C#" MasterPageFile="~/Client.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs"
    Inherits="BatDongSan.Default" Title="Trang chủ" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content_main">
        <div id="new_pj">
            <asp:LinqDataSource ID="LinqDataSource3" runat="server" ContextTypeName="BatDongSan.BDSDataContext"
                OnSelecting="LinqDataSource3_Selecting" OrderBy="PostDate desc, ID" TableName="Projects">
            </asp:LinqDataSource>
            <asp:DataList ID="DataList2" runat="server" DataKeyField="ID" DataSourceID="LinqDataSource3"
                RepeatLayout="Flow">
                <ItemTemplate>
                    <asp:Image runat="server" ID="picpj" ImageUrl='<%# Eval("Picture") %>' AlternateText='<%# Eval("Title") %>' />
                    <div id="infopj">
                        <p class="title">
                            <a href='HousingDetail.aspx?view=project&key=<%# Eval("ID") %>'><%# Eval("Title") %></a></p>
                        <p class="summary">
                            <%# Eval("Summary") %></p>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
        <div id="top_news">
            <div class="section_content">
                <img class="icon" src="images/templates/default/top_news/icon.png" />
                <p class="section_title">
                    Tin tức - sự kiện</p>
                <div class="section_body clear">
                    <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="BatDongSan.BDSDataContext"
                        OnSelecting="LinqDataSource1_Selecting" TableName="Articles">
                    </asp:LinqDataSource>
                    <asp:DataList CssClass="tbl_topnews" ID="DataList1" runat="server" DataKeyField="ID"
                        DataSourceID="LinqDataSource1">
                        <ItemTemplate>
                            »
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "Article.aspx?key=" + Eval("ID") %>'
                                Text='<%# Eval("Title") %>'></asp:HyperLink>
                        </ItemTemplate>
                    </asp:DataList>
                    <p class="func">
                        <a href="Article.aspx">Xem thêm ...</a></p>
                </div>
            </div>
        </div>
        <asp:LinqDataSource ID="LinqDataSource2" runat="server" ContextTypeName="BatDongSan.BDSDataContext"
            OnSelecting="LinqDataSource2_Selecting" TableName="Houses">
        </asp:LinqDataSource>
        <div id="top_housing">
            <div class="title">
                <img class="icon" src="../images/templates/default/housing/icon.png" alt="icon" />
                <p class="section_title">
                    Bất động sản mới</p>
            </div>
            <div class="body">
            <div class="wrap">
                <asp:DataList ID="DataList3" runat="server" DataKeyField="ID" DataSourceID="LinqDataSource2"
                    CssClass="tbl_house" Width="100%">
                    <ItemTemplate>
                        <table>
                            <tr>
                                <td rowspan="3">
                                    <a href="#"><img class="imgthumb" src='<%# Eval("Thumbnail") %>' alt='<%# Eval("Title") %>' /></a>
                                </td>
                                <td>
                                    <p class="title_house">
                                        <a href="#"><%# Eval("Title") %></a></p>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <p class="price">
                                        Giá : <%# Eval("Price") %></p>
                                </td>
                            </tr>
                            <tr>
                                <td valign="bottom" class="seperate_bot">
                                    <p class="viewcount">
                                        Lượt xem : <%# Eval("ViewCount") %></p>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
                </div>
            </div>
            <p class="bottom">
                &nbsp;</p>
        </div>
    </div>
</asp:Content>
