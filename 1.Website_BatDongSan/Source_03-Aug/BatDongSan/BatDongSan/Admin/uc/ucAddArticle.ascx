<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucAddArticle.ascx.cs" Inherits="BatDongSan.Admin.uc.ucAddArticle" %>
<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>
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
        <td>
            <CKEditor:CKEditorControl ID="ckenoidung" runat="server">
            </CKEditor:CKEditorControl>
        </td>
    </tr>
</table>
    <asp:Button ID="btnOk" runat="server" Text="Save" onclick="btnOk_Click" />