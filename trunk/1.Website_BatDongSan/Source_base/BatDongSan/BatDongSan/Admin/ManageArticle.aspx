<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ManageArticle.aspx.cs" Inherits="BatDongSan.Admin.ManageArticle" Title="Untitled Page" %>
<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>
<%@ Register src="uc/ucAddArticle.ascx" tagname="ucAddArticle" tagprefix="uc1" %>
<%@ Register src="uc/ucEditArticle.ascx" tagname="ucEditArticle" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <p>
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="15pt" 
            Text="CÁC TIN ĐÃ ĐĂNG"></asp:Label>
    </p>
    <p>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="LinqDataSource1">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" 
                    ReadOnly="True" SortExpression="ID" Visible="False" />
                
                <asp:TemplateField HeaderText="Tiêu đề" SortExpression="Title">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Title") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" Text='<%# Bind("Title") %>' NavigateUrl='<%# "ManageArticle.aspx?action=edit&key=" + Eval("ID") %>'  
                            ></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="Summary" HeaderText="Tóm tắt" 
                    SortExpression="Summary" />
                <asp:BoundField DataField="Contents" HeaderText="Contents" 
                    SortExpression="Contents" Visible="False" />
                <asp:BoundField DataField="PostDate" HeaderText="PostDate" 
                    SortExpression="PostDate" Visible="False" />
                <asp:BoundField DataField="LatestModifiedDate" HeaderText="Ngày chỉnh sửa" 
                    SortExpression="LatestModifiedDate" />
                <asp:CheckBoxField DataField="IsValid" HeaderText="Có hiệu lực" 
                    SortExpression="IsValid">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:CheckBoxField>
                <asp:CommandField ButtonType="Image" 
                    DeleteImageUrl="~/images/Admin/Symbols-Delete-icon.png" DeleteText="" 
                    ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
        <asp:Button ID="btnThem" runat="server" onclick="btnThem_Click" Text="Thêm" />
        <br />
        <asp:LinqDataSource ID="LinqDataSource1" runat="server" 
            ContextTypeName="BatDongSan.BDSDataContext" EnableDelete="True" 
            EnableInsert="True" EnableUpdate="True" TableName="Articles">
        </asp:LinqDataSource>
    </p>
    
    <p>
        <uc1:ucAddArticle ID="ucAddArticle1" runat="server" Visible="False" />
    </p>
    <p>
        <uc2:ucEditArticle ID="ucEditArticle1" runat="server" EnableViewState="True" />
    </p>
    
</asp:Content>
