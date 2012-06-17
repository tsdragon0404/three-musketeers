<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="article_detail.ascx.cs" Inherits="BDSGiaKiem.ucAdmin.article_detail" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<fieldset class="fset">
    <legend><asp:Label ID="lblTitle" runat="server" Text="Thêm bài viết mới"></asp:Label></legend>
    <table class="tblArticleDetail">
        <colgroup>
            <col width="15%" />
            <col width="85%" />
        </colgroup>
        <tr>
            <td class="right">Tiêu đề: </td>
            <td><asp:TextBox ID="txtTitle" runat="server" CssClass="txtBox400" Text=""></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="RequiredFieldValidator" ControlToValidate="txtTitle">* Phải nhập tiêu đề</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="right top">Nội dung: </td>
            <td><CKEditor:CKEditorControl ID="editorContent" runat="server" Text=""></CKEditor:CKEditorControl></td>
        </tr>
        <tr>
            <td></td>
            <td><asp:Button ID="btnSave" runat="server" Text="Save" 
            onclick="btnSave_Click" /></td>
        </tr>
    </table>
</fieldset>