<%@ Page Language="C#" MasterPageFile="~/Client.Master" AutoEventWireup="true" CodeBehind="Housing.aspx.cs"
    Inherits="BatDongSan.Housing" Title="Bất động sản" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <div class="top">
            <img class="icon" src="images/templates/default/housing/icon.png" />
            <p class="section_title">
                Bất động sản</p>
        </div>
        <div class="mid">
            <div class="wrap">
                <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="BatDongSan.BDSDataContext"
                    OnSelecting="LinqDataSource1_Selecting" TableName="Houses">
                </asp:LinqDataSource>
                <asp:DataList ID="datalisthouse" runat="server" DataSourceID="LinqDataSource1" Width="100%"
                    CssClass="tbl seperate_bot">
                    <HeaderTemplate>
                        <img src="images/templates/default/housing/house.png" class="tblimg" />
                        <p class="title">
                            Nhà ở</p>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="wrap">
                            <table class="tbl_house">
                                <colgroup>
                                    <col width="25%" />
                                    <col width="75%" />
                                </colgroup>
                                <tr>
                                    <td rowspan="3" valign="middle" class="center">
                                        <a href='<%# "HousingDetail.aspx?view=house&key=" + Eval("ID") %>'>
                                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Thumbnail") %>' Width="100px"
                                                Height="75px" ToolTip='<%# Eval("Title") %>' AlternateText='<%# Eval("Title") %>' /></a>
                                    </td>
                                    <td>
                                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "HousingDetail.aspx?view=house&key=" + Eval("ID") %>'
                                            Text='<%# Eval("Title") %>' ToolTip='<%# Eval("Title") %>'></asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Giá :
                                        <%# Eval("Price") %>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <%# Eval("Description") %>
                                    </td>
                                </tr>
                            </table>
                            <hr />
                        </div>
                    </ItemTemplate>
                    <FooterTemplate>
                        <p class="func">
                            <a href="HousingDetail.aspx?view=house">Xem thêm...</a></p>
                    </FooterTemplate>
                </asp:DataList>
                <asp:LinqDataSource ID="LinqDataSource2" runat="server" ContextTypeName="BatDongSan.BDSDataContext"
                    OnSelecting="LinqDataSource2_Selecting" TableName="Houses">
                </asp:LinqDataSource>
                <asp:DataList ID="datalistagri" CssClass="tbl seperate_bot" runat="server" DataSourceID="LinqDataSource2">
                    <HeaderTemplate>
                        <img src="images/templates/default/housing/agri.png" class="tblimg" />
                        <p class="title">
                            Đất thổ cư - Nông nghiệp</p>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="wrap">
                            <table class="tbl_house">
                                <colgroup>
                                    <col width="25%" />
                                    <col width="75%" />
                                </colgroup>
                                <tr>
                                    <td rowspan="3" valign="middle" class="center">
                                        <a href='<%# "HousingDetail.aspx?view=agri&key=" + Eval("ID") %>'>
                                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Thumbnail") %>' Width="100px"
                                                Height="75px" ToolTip='<%# Eval("Title") %>' AlternateText='<%# Eval("Title") %>' /></a>
                                    </td>
                                    <td>
                                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "HousingDetail.aspx?view=agri&key=" + Eval("ID") %>'
                                            Text='<%# Eval("Title") %>' ToolTip='<%# Eval("Title") %>'></asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Giá :
                                        <%# Eval("Price") %>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <%# Eval("Description") %>
                                    </td>
                                </tr>
                            </table>
                            <hr />
                        </div>
                    </ItemTemplate>
                    <FooterTemplate>
                        <p class="func">
                            <a href="HousingDetail.aspx?view=agri">Xem thêm...</a></p>
                    </FooterTemplate>
                </asp:DataList>
                <asp:LinqDataSource ID="LinqDataSource3" runat="server" ContextTypeName="BatDongSan.BDSDataContext"
                    OnSelecting="LinqDataSource3_Selecting" OrderBy="ID desc" TableName="Projects"
                    Where="IsValid == @IsValid">
                    <WhereParameters>
                        <asp:Parameter DefaultValue="True" Name="IsValid" Type="Boolean" />
                    </WhereParameters>
                </asp:LinqDataSource>
                <asp:DataList CssClass="tbl" ID="datalistproject" runat="server" DataSourceID="LinqDataSource3">
                    <HeaderTemplate>
                        <img src="images/templates/default/housing/pj.png" class="tblimg" />
                        <p class="title">
                            Dự án</p>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="wrap">
                            <table class="tbl_house">
                                <colgroup>
                                    <col width="25%" />
                                    <col width="75%" />
                                </colgroup>
                                <tr>
                                    <td rowspan="2" valign="middle" class="center">
                                        <a href='<%# "HousingDetail.aspx?view=project&key=" + Eval("ID") %>'>
                                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Picture") %>' Width="100px"
                                                Height="75px" ToolTip='<%# Eval("Title") %>' AlternateText='<%# Eval("Title") %>' /></a>
                                    </td>
                                    <td>
                                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "HousingDetail.aspx?view=project&key=" + Eval("ID") %>'
                                            Text='<%# Eval("Title") %>' ToolTip='<%# Eval("Title") %>'></asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <%# Eval("Summary") %>
                                    </td>
                                </tr>
                            </table>
                            <hr />
                        </div>
                    </ItemTemplate>
                    <FooterTemplate>
                        <p class="func">
                            <a href="HousingDetail.aspx?view=project">Xem thêm...</a></p>
                    </FooterTemplate>
                </asp:DataList>
            </div>
        </div>
        <p class="bot">
            &nbsp;</p>
    </div>
</asp:Content>
