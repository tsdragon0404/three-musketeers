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
            <td class="right">&nbsp;<asp:Label ID="Label1" runat="server" ForeColor="Red" 
                    Text="Tiêu đề"></asp:Label></td>
            <td><asp:TextBox ID="txtTitle" runat="server" CssClass="txtBox400" Text=""></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="right top">Nội dung: </td>
            <td><CKEditor:CKEditorControl ID="editorContent" runat="server" Text=""></CKEditor:CKEditorControl></td>
        </tr>
        <tr>
            <td></td>
            <td><asp:Button ID="btnSave" runat="server" Text="Lưu" onclick="btnSave_Click" />
            <asp:Button ID="btnCancel" runat="server" Text="Hủy bỏ" onclick="btnCancel_Click"/></td>
        </tr>
    </table>
</fieldset>

<script type="text/javascript">
    function checkSave() {
        var txtTitle = document.getElementById('ctl00_ContentPlaceHolder1_ctl00_txtTitle');
        if (trim(txtTitle.value) == '') {
            alert("Chưa nhập đầy đủ thông tin");
            txtTitle.value.value = '';
            txtTitle.focus();
            return false;
        }
    }
    function trim(str)
     {
        var start = 0;
        var end = str.length;
        while (start < str.length && str.charAt(start) == ' ') start++;
        while (end > 0 && str.charAt(end - 1) == ' ') end--;
        return str.substr(start, end - start);
    }
</script>