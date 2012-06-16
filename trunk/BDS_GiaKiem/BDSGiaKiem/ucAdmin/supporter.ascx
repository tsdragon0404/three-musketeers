<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="supporter.ascx.cs" Inherits="BDSGiaKiem.ucAdmin.supporter" %>
<fieldset class="fset">
    <legend>Đường dây nóng</legend>
    <table class="tblSupport">
            <colgroup>
                <col width="30%" />
                <col width="70%" />
            </colgroup>
            <tr>
                <td class="right"><asp:Label ID="Label4" runat="server" Text=" Điện thoại: " AssociatedControlID="txtHotline" CssClass="lblsupport"></asp:Label></td>
                <td><asp:TextBox ID="txtHotline" runat="server" CssClass="txtBox200"></asp:TextBox></td>
            </tr>
    </table> 
        <p class="funcBox">
            <asp:Button ID="btnSaveHotline" runat="server" Text="Save" OnClick="btnSaveHotline_Click" />
            <asp:Label ID="HotlineMsg" runat="server" Text="" Visible="false"></asp:Label>
        </p>
</fieldset>
<fieldset class="fset">
    <legend>Hỗ trợ trực tuyến</legend>
    <fieldset class="fset">
        <legend>Hỗ trợ 1</legend>
        <table class="tblSupport">
            <colgroup>
                <col width="30%" />
                <col width="70%" />
            </colgroup>
            <tr>
                <td class="right"><asp:Label ID="Label1" runat="server" Text="Tên: " AssociatedControlID="txtName1" CssClass="lblsupport"></asp:Label></td>
                <td><asp:TextBox ID="txtName1" runat="server" CssClass="txtBox200"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="right"><asp:Label ID="Label2" runat="server" Text="Điện thoại: " AssociatedControlID="txtPhone1" CssClass="lblsupport"></asp:Label></td>
                <td><asp:TextBox ID="txtPhone1" runat="server" CssClass="txtBox200"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="right"><asp:Label ID="Label3" runat="server" Text="Yahoo: " AssociatedControlID="txtYahoo1" CssClass="lblsupport"></asp:Label></td>
                <td><asp:TextBox ID="txtYahoo1" runat="server" CssClass="txtBox200"></asp:TextBox></td>
            </tr>
        </table>

    </fieldset>
    <fieldset class="fset">
        <legend>Hỗ trợ 2</legend>
        <table class="tblSupport">
            <colgroup>
                <col width="30%" />
                <col width="70%" />
            </colgroup>
            <tr>
                <td class="right"><asp:Label ID="Label5" runat="server" Text="Tên: " AssociatedControlID="txtName2" CssClass="lblsupport"></asp:Label></td>
                <td><asp:TextBox ID="txtName2" runat="server" CssClass="txtBox200"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="right"><asp:Label ID="Label6" runat="server" Text="Điện thoại: " AssociatedControlID="txtPhone2" CssClass="lblsupport"></asp:Label></td>
                <td><asp:TextBox ID="txtPhone2" runat="server" CssClass="txtBox200"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="right"><asp:Label ID="Label7" runat="server" Text="Yahoo: " AssociatedControlID="txtYahoo2" CssClass="lblsupport"></asp:Label></td>
                <td><asp:TextBox ID="txtYahoo2" runat="server" CssClass="txtBox200"></asp:TextBox></td>
            </tr>
        </table>
    </fieldset>
    <p class="funcBox">
        <asp:Button ID="btnSaveSupporter" runat="server" Text="Save" OnClick="btnSaveSupporter_Click" />
        <asp:Label ID="SupporterMsg" runat="server" Text="" Visible="false"></asp:Label>
    </p>
</fieldset>
