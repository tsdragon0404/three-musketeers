<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="ChangePassword.aspx.cs" Inherits="BatDongSan.Admin.ChangePassword"
    Title="Thay đổi mật khẩu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <div class="top">
            <img class="icon" src="../images/templates/default/changepass.png" />
            <p class="section_title">
                Thay đổi mật khẩu</p>
        </div>
        <div class="mid">
            <table class="login">
                <tr>
                    <td colspan="2" align="center">
                        <asp:Label ID="Label3" runat="server" ForeColor="Red" Text="Mật khẩu không chính xác"
                            Visible="False"></asp:Label>
                        <br />
                        <asp:Label ID="Label4" runat="server" Text="Đổi mật khẩu thành công" ForeColor="#3366FF"
                            Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="UserNameLabel" runat="server">Mật khẩu cũ:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="Oldpass" TextMode="Password" runat="server" ontextchanged="Oldpass_TextChanged"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="Oldpass"
                            ErrorMessage=" (*)" ToolTip="Phải nhập mật khẩu cũ"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label1" runat="server">Mật khẩu mới:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
                            ErrorMessage="(*)" ToolTip="Phải nhập mật khẩu mới"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label2" runat="server">Nhập lại mật khẩu mới:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2"
                            ErrorMessage="(*)" ToolTip="Phải nhập lại mật khẩu mới"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center;">
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Mật khẩu mới không khớp"
                            ControlToCompare="TextBox2" ControlToValidate="TextBox1" Display="Dynamic"></asp:CompareValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox1"
                            ErrorMessage="Mật khẩu không được phép" Display="Dynamic" ValidationExpression="^([a-zA-Z0-9]{4,20})$"></asp:RegularExpressionValidator>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center;">
                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/Admin/OK.png"
                            OnClick="ImageButton1_Click" Width="32px" />
                    </td>
                    <td style="text-align: center;">
                        <a href="Default.aspx"><img src="../images/Admin/Back.png"/></a>
                    </td>
                </tr>
            </table>
        </div>
        <p class="bot">
            &nbsp;</p>
    </div>
</asp:Content>
