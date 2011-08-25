<%@ Page Language="C#" MasterPageFile="~/Client.Master" AutoEventWireup="true" CodeBehind="Partners.aspx.cs"
    Inherits="BatDongSan.Partners" Title="Đối tác" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <div class="top">
            <img class="icon" src="images/templates/default/sidebar/icon_1.png" />
            <p class="section_title">
                Đối tác</p>
        </div>
        <div class="mid">
            <asp:LinqDataSource ID="LinqDataSource3" runat="server" ContextTypeName="BatDongSan.BDSDataContext"
                OrderBy="ID" TableName="Partners" Where="IsValid == @IsValid">
                <WhereParameters>
                    <asp:Parameter DefaultValue="True" Name="IsValid" Type="Boolean" />
                </WhereParameters>
            </asp:LinqDataSource>
            <ul runat="server" id="listPartner" class="lstPartner">
                <asp:Repeater ID="Repeater2" runat="server" DataSourceID="LinqDataSource3">
                    <ItemTemplate>
                        <li><a href='Partners.aspx?id=<%# Eval("ID") %>'>
                            <%# Eval("Name") %></a></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
            <asp:LinqDataSource ID="LinqDataSource4" runat="server" 
                ContextTypeName="BatDongSan.BDSDataContext" TableName="Partners" 
                Where="ID == @ID">
                <WhereParameters>
                    <asp:QueryStringParameter DefaultValue="0" Name="ID" QueryStringField="id" 
                        Type="Int64" />
                </WhereParameters>
                </asp:LinqDataSource>
            <asp:Repeater ID="Repeater3" runat="server" Visible="false" DataSourceID="LinqDataSource4">
                <ItemTemplate>
                    <p class="partnername"><%# Eval("Name") %></p>
                    <div class="wrap"><%# Eval("Contents") %></div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <p class="bot">
            &nbsp;</p>
    </div>
</asp:Content>
