<%@ Page Language="C#" MasterPageFile="~/Client.Master" AutoEventWireup="true" CodeBehind="Article.aspx.cs" Inherits="BatDongSan.Article1" Title="Untitled Page" %>
<%@ Register assembly="obout_Editor" namespace="OboutInc.Editor" tagprefix="obout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:LinqDataSource ID="LinqDataSource1" runat="server" 
        ContextTypeName="BatDongSan.BDSDataContext" TableName="Articles" 
        Where="ID == @ID">
        <WhereParameters>
            <asp:QueryStringParameter DefaultValue="0" Name="ID" QueryStringField="key" 
                Type="Int64" />
        </WhereParameters>
    </asp:LinqDataSource>
    <asp:DataList ID="DataList1" runat="server" DataKeyField="ID" 
        DataSourceID="LinqDataSource1" Width="100%">
        <ItemTemplate>
            <table class="style1">
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink1" runat="server" Font-Overline="False" 
                            Font-Underline="True" ForeColor="#0099FF">Tin tức &gt;&gt;</asp:HyperLink>
                    </td>
                    <td align="right" width="30%">
                        <asp:Label ID="Label4" runat="server" Font-Size="8pt" 
                            Text='<%# Eval("LatestModifiedDate") %>'></asp:Label>
                    </td>
                </tr>
            </table>
            <br />
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="16pt" 
                Text='<%# Eval("Title") %>'></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Font-Bold="True" 
                Text='<%# Eval("Summary") %>'></asp:Label>
            <br />
            <asp:Label ID="Label3" runat="server" Text='<%# Eval("Contents") %>'></asp:Label>
        </ItemTemplate>
    </asp:DataList>
    <br />
    <asp:LinqDataSource ID="LinqDataSource3" runat="server" 
        ContextTypeName="BatDongSan.BDSDataContext" OrderBy="ID desc" 
        Select="new (ID, Title)" TableName="Articles" 
        Where="ID &gt; @ID &amp;&amp; IsValid == @IsValid">
        <WhereParameters>
            <asp:QueryStringParameter DefaultValue="0" Name="ID" QueryStringField="key" 
                Type="Int64" />
            <asp:Parameter DefaultValue="True" Name="IsValid" Type="Boolean" />
        </WhereParameters>
    </asp:LinqDataSource>
    <asp:DataList ID="DataList3" runat="server" DataSourceID="LinqDataSource3">
        <ItemTemplate>
            <asp:HyperLink ID="HyperLink3" runat="server" 
                NavigateUrl='<%# "Article.aspx?key=" + Eval("ID") %>' 
                Text='<%# Eval("Title") %>'></asp:HyperLink>
            <br />
        </ItemTemplate>
    </asp:DataList>
    <br />
    <asp:LinqDataSource ID="LinqDataSource2" runat="server" 
        ContextTypeName="BatDongSan.BDSDataContext" Select="new (Title, ID)" 
        TableName="Articles" Where="ID &lt; @ID &amp;&amp; IsValid == @IsValid" 
        OrderBy="ID desc">
        <WhereParameters>
            <asp:QueryStringParameter DefaultValue="0" Name="ID" QueryStringField="key" 
                Type="Int64" />
            <asp:Parameter DefaultValue="True" Name="IsValid" Type="Boolean" />
        </WhereParameters>
    </asp:LinqDataSource>
    <asp:DataList ID="DataList2" runat="server" DataSourceID="LinqDataSource2">
        <ItemTemplate>
            <asp:HyperLink ID="HyperLink2" runat="server" 
                NavigateUrl='<%# "Article.aspx?key=" + Eval("ID") %>' Text='<%# Eval("Title") %>'></asp:HyperLink>
            <br />
            <br />
            </ItemTemplate>
    </asp:DataList>
</asp:Content>
