<%@ Page Language="C#" MasterPageFile="~/Client.Master" AutoEventWireup="true" CodeBehind="HousingDetail.aspx.cs"
    Inherits="BatDongSan.HousingDetail" Title="Bất động sản" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <div class="top">
            <img class="icon" src="images/templates/default/housing/housedetail.png" />
            <p class="section_title">
                Thông tin chi tiết</p>
        </div>
        <div class="mid">
            <div class="wrap">
                <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="BatDongSan.BDSDataContext"
                    TableName="Houses" Where="ID == @ID">
                    <WhereParameters>
                        <asp:QueryStringParameter DefaultValue="0" Name="ID" QueryStringField="key" Type="Int64" />
                    </WhereParameters>
                </asp:LinqDataSource>
                <asp:DataList ID="DataList1" CssClass="tbl" runat="server" DataKeyField="ID" DataSourceID="LinqDataSource1">
                    <ItemTemplate>
                        <table cellpadding="0" cellspacing="0" align="center" width="100%">
                            <tr>
                                <td rowspan="2" width="450px">
                                    <asp:Image ID="Image2" CssClass="imgHouse seperate_bot" runat="server" ImageUrl='<%# Eval("Picture") %>' />
                                </td>
                                <td valign="top">
                                    <p class="title">
                                        <%# Eval("Title")%></p>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <p class="price">
                                        Giá:
                                        <%# Eval("Price")%></p>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <img class="tblimg" src="images/templates/default/housing/housedetail.png" /><p class="title">
                                        Thông tin chi tiết</p>
                                    <div class="wrap clear">
                                        <%# Eval("Description")%>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
                <asp:LinqDataSource ID="LinqDataSource5" runat="server" ContextTypeName="BatDongSan.BDSDataContext"
                    TableName="Projects" Where="ID == @ID">
                    <WhereParameters>
                        <asp:QueryStringParameter DefaultValue="0" Name="ID" QueryStringField="key" Type="Int64" />
                    </WhereParameters>
                </asp:LinqDataSource>
                <asp:DataList ID="DataList3" runat="server" DataKeyField="ID" DataSourceID="LinqDataSource5"
                    Width="100%" RepeatLayout="Flow">
                    <ItemTemplate>
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td align="center">
                                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Picture", "../{0}") %>' />
                                    <br />
                                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="14pt" ForeColor="#FF6600"
                                        Text='<%# Eval("Title") %>'></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <asp:Label ID="Label5" runat="server" Font-Bold="True" Text='<%# Eval("Summary") %>'></asp:Label>
                        <br />
                        <asp:Label ID="Label6" runat="server" Text='<%# Eval("Description") %>'></asp:Label>
                        <br />
                        <br />
                    </ItemTemplate>
                </asp:DataList>
                <asp:LinqDataSource ID="LinqDataSource2" runat="server" ContextTypeName="BatDongSan.BDSDataContext"
                    TableName="Houses" OnSelecting="LinqDataSource2_Selecting">
                </asp:LinqDataSource>
                <asp:DataList ID="datalisthouse" runat="server" DataSourceID="LinqDataSource2" CssClass="tbl_1"
                    Width="100%">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "HousingDetail.aspx?view=house?key=" + Eval("ID") %>'
                            Text='<%# Eval("Title") %>'></asp:HyperLink>
                    </ItemTemplate>
                    <HeaderTemplate>
                    <hr />
                        <p class="info2">
                            Các tin liên quan</p>
                    </HeaderTemplate>
                </asp:DataList>
                <asp:LinqDataSource ID="LinqDataSource3" runat="server" ContextTypeName="BatDongSan.BDSDataContext"
                    TableName="Houses" OnSelecting="LinqDataSource3_Selecting">
                </asp:LinqDataSource>
                <asp:DataList ID="datalistagri" runat="server" DataSourceID="LinqDataSource3" 
                    CssClass="tbl_1" Width="100%">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# "HousingDetail.aspx?view=agri&key=" + Eval("ID") %>'
                            Text='<%# Eval("Title") %>'></asp:HyperLink>
                    </ItemTemplate>
                    <HeaderTemplate>
                    <hr />
                        <p class="info2">
                            Các tin liên quan</p>
                    </HeaderTemplate>
                </asp:DataList>
                <asp:LinqDataSource ID="LinqDataSource4" runat="server" ContextTypeName="BatDongSan.BDSDataContext"
                    TableName="Projects" OnSelecting="LinqDataSource4_Selecting">
                </asp:LinqDataSource>
                <asp:DataList ID="datalistproject" runat="server" 
                    DataSourceID="LinqDataSource4" Width="100%" CssClass="tbl_1">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl='<%# "HousingDetail.aspx?view=project&key=" + Eval("ID") %>'
                            Text='<%# Eval("Title") %>'></asp:HyperLink>
                    </ItemTemplate>
                    <HeaderTemplate>
                    <hr />
                        <p class="info2">
                            Các tin liên quan</p>
                    </HeaderTemplate>
                </asp:DataList>
            </div>
        </div>
        <p class="bot">
            &nbsp;</p>
    </div>
</asp:Content>
