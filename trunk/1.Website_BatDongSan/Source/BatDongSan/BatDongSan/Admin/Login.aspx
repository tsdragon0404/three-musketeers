<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="BatDongSan.Admin.Login" Title="Đăng nhập hệ thống" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <div class="top">
            <img class="icon" src="../images/admin/loginicon.png" />
            <p class="section_title">
                Đăng nhập</p>
        </div>
        <div class="mid">
            <asp:Login ID="Login1" runat="server" CssClass="login" DestinationPageUrl="~/Admin/Default.aspx" FailureText="Tên đăng nhập hoặc mật khẩu không chính xác"
                LoginButtonText="Đăng nhập" LoginButtonType="Image" OnAuthenticate="Login1_Authenticate"
                PasswordLabelText="Mật khẩu" PasswordRequiredErrorMessage="Mật khẩu còn trống"
                RememberMeText="Ghi nhớ" TitleText="Đăng nhập" UserNameLabelText="Tên đăng nhập"
                UserNameRequiredErrorMessage="Tên đăng nhập còn trống" OnLoginError="Login1_LoginError">
                <LayoutTemplate>
                    <table border="0" cellpadding="0">
                        <tr>
                            <td align="right">
                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Tên 
                                            đăng nhập</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                    ErrorMessage="Tên đăng nhập còn trống" ToolTip="Tên đăng nhập còn trống" ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Mật 
                                            khẩu</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                    ErrorMessage="Mật khẩu còn trống" ToolTip="Mật khẩu còn trống" ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2" style="color: Red;">
                                <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:ImageButton ID="LoginImageButton" runat="server" AlternateText="Đăng nhập" CommandName="Login"
                                    ValidationGroup="Login1" ImageUrl="../images/admin/login.png" />
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>
            </asp:Login>
            <%--<asp:Login ID="Login1" runat="server">
                <LayoutTemplate>
                    <table border="0" cellpadding="1" cellspacing="0" style="border-collapse: collapse;">
                        <tr>
                            <td>
                                <table border="0" cellpadding="0">
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name:</asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                                ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                                ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:CheckBox ID="RememberMe" runat="server" Text="Ghi nhớ cho lần đăng nhập tiếp theo." />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2" style="color: Red;">
                                            <asp:Literal ID="FailureText" runat="server" EnableViewState="False" Text="Tài khoản hoặc mật khẩu không đúng."></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" colspan="2">
                                            <asp:Button ID="LoginButton" runat="server" CommandName="Login" OnClick="LoginButton_Click"
                                                Text="Log In" ValidationGroup="Login1" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>
            </asp:Login>--%>
        </div>
        <p class="bot">
            &nbsp;</p>
    </div>
</asp:Content>
