<%@ Page Language="C#" MasterPageFile="~/Client.Master" AutoEventWireup="true" CodeBehind="Services.aspx.cs"
    Inherits="BatDongSan.Services" Title="Dịch vụ" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <div class="top">
            <img class="icon" src="images/templates/default/services.png" />
            <p class="section_title">
                Dịch vụ</p>
        </div>
        <div class="mid">
            <div class="wrap">
                <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="BatDongSan.BDSDataContext"
                    TableName="OtherPages" Where="PageName == @PageName">
                    <WhereParameters>
                        <asp:Parameter DefaultValue="Services" Name="PageName" Type="String" />
                    </WhereParameters>
                </asp:LinqDataSource>
                <asp:DataList ID="DataList1" runat="server" DataKeyField="ID" DataSourceID="LinqDataSource1"
                    RepeatLayout="Flow">
                    <ItemTemplate>
                        <asp:Label ID="ContentsLabel" runat="server" Text='<%# Eval("Contents") %>' />
                    </ItemTemplate>
                </asp:DataList>
            </div>
        </div>
        <p class="bot">
            &nbsp;</p>
    </div>
</asp:Content>
