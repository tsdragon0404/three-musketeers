<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ManageArticle.aspx.cs" Inherits="BatDongSan.Admin.ManageArticle" Title="Untitled Page" %>
<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table border="0" style="border:none;">
    <tr>
        <td><asp:Label ID="Label1" runat="server" Text="Tiêu đề"></asp:Label></td>
        <td><asp:TextBox ID="txttieude" runat="server" Width="600px"></asp:TextBox></td>
    </tr>
    <tr>
        <td><asp:Label ID="Label2" runat="server" Text="Tóm tắt"></asp:Label></td>
        <td><asp:TextBox ID="txttomtat" runat="server" TextMode="MultiLine" Height="60px" Width="600px"></asp:TextBox></td>
    </tr>
    <tr>
        <td><asp:Label ID="Label3" runat="server" Text="Nội dung"></asp:Label></td>
        <td><CKEditor:CKEditorControl ID="ckeNoidung" runat="server" Width="600px"></CKEditor:CKEditorControl></td>
    </tr>
</table>
<br />
    <asp:Button ID="btnOk" runat="server" Text="Save" onclick="btnOk_Click" />

</asp:Content>
