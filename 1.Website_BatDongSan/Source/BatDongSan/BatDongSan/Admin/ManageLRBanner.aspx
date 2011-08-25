<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ManageLRBanner.aspx.cs" Inherits="BatDongSan.Admin.ManageLRBanner" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="content">
        <div class="top">
            <img class="icon" src="../images/templates/default/sidebar/icon_6.png" />
            <p class="section_title">
                Quản lý quảng cáo</p>
        </div>
        <div class="mid">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                DataKeyNames="ID" DataSourceID="LinqDataSource1" Width="100%"
                OnRowUpdated="GridView1_RowUpdated" 
                OnRowUpdating="GridView1_RowUpdating" PageSize="5">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="STT" ReadOnly="True"
                        SortExpression="ID" >
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Picture" SortExpression="Picture">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Picture") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("Picture") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Url" SortExpression="Url">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Url") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Url") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CheckBoxField DataField="IsValid" HeaderText="IsValid" 
                        SortExpression="IsValid">
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:CheckBoxField>
                    <asp:CommandField ButtonType="Image" CancelImageUrl="~/images/Admin/Back.png" 
                        EditImageUrl="~/images/Admin/Edit.png" ShowEditButton="True" 
                        UpdateImageUrl="~/images/Admin/OK.png">
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:CommandField>
                </Columns>
            </asp:GridView>
            <asp:LinqDataSource ID="LinqDataSource1" runat="server" 
                ContextTypeName="BatDongSan.BDSDataContext" TableName="LRBanners" EnableUpdate="True"
                OrderBy="IsValid desc">
            </asp:LinqDataSource>
        </div>
        <p class="bot">
            &nbsp;</p>
    </div>
</asp:Content>
