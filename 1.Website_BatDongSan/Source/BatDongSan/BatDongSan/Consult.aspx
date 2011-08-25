<%@ Page Language="C#" MasterPageFile="~/Client.Master" AutoEventWireup="true" CodeBehind="Consult.aspx.cs"
    Inherits="BatDongSan.Consult" Title="Tư vấn" %>

<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="js/QA.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <div class="top">
            <img class="icon" src="images/templates/default/QA/icon.png" />
            <p class="section_title">
                Tư vấn</p>
        </div>
        <div class="mid">
            <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="BatDongSan.BDSDataContext"
                OrderBy="AnswerDate desc, ID" TableName="Questions" Where="IsAnswered == @IsAnswered"
                OnSelecting="LinqDataSource1_Selecting">
                <WhereParameters>
                    <asp:Parameter DefaultValue="True" Name="IsAnswered" Type="Boolean" />
                </WhereParameters>
            </asp:LinqDataSource>
            <asp:DataList ID="dlQA" runat="server" CellPadding="5" DataKeyField="ID" DataSourceID="LinqDataSource1"
                GridLines="Horizontal" RepeatLayout="Flow">
                <ItemTemplate>
                    <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' Visible="False" />
                    <div class="QA">
                        <p class="QA_top">
                            &nbsp;</p>
                        <div class="QA_mid">
                            <div class="Q wrap">
                                <p class="text">
                                    <asp:Label ID="QuestionTextLabel" runat="server" Text='<%# Eval("QuestionText") %>' /></p>
                                <p class="info">
                                    (<asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                                    -
                                    <asp:Label ID="EmailLabel" runat="server" Text='<%# Eval("Email") %>' />)</p>
                            </div>
                            <div class="A wrap">
                                <p class="separator">
                                    &nbsp;</p>
                                <p class="text">
                                    <asp:Label ID="AnswerTextLabel" runat="server" Text='<%# Eval("AnswerText") %>' /></p>
                            </div>
                            <div class="func">
                                <a class="showhide">Xem trả lời</a>
                            </div>
                        </div>
                        <p class="QA_bot">
                            &nbsp;</p>
                    </div>
                </ItemTemplate>
            </asp:DataList>
            <hr runat="server" id="line" visible="false" />
            <p class="func">
                <asp:HyperLink ID="HyperLink3" runat="server">Trang trước</asp:HyperLink>
                <asp:Label ID="Label1" runat="server" Text=" - " Visible="false"></asp:Label>
                <asp:HyperLink ID="HyperLink4" runat="server">Trang sau</asp:HyperLink></p>
            <div id="sendques">
                <p>
                    Gửi câu hỏi</p>
                <p class="information" runat="server" visible="false" id="info">
                    Câu hỏi đã được gửi</p>
                <table class="tbl_ques">
                    <colgroup>
                        <col style="width: 25%;" />
                        <col style="width: 75%;" />
                    </colgroup>
                    <tr>
                        <th>
                            Tên
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                ErrorMessage="(*)" ControlToValidate="txtName"></asp:RequiredFieldValidator>
                        </th>
                        <td>
                            <asp:TextBox ID="txtName" CssClass="textbox" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            Email
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                ErrorMessage="(*)" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                        </th>
                        <td>
                            <asp:TextBox ID="txtEmail" CssClass="textbox" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            Điện thoại
                            </th>
                        <td>
                            <asp:TextBox ID="txtPhone" CssClass="textbox" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            Nội dung
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                ErrorMessage="(*)" ControlToValidate="txtQuestion"></asp:RequiredFieldValidator>
                        </th>
                        <td valign="middle">
                            <asp:TextBox ID="txtQuestion" CssClass="textarea" runat="server" TextMode="MultiLine"
                                Rows="3" AutoCompleteType="None"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            Mã bảo vệ
                        </th>
                        <td>
                            <asp:TextBox ID="txtCaptcha" CssClass="textbox" runat="server"></asp:TextBox>
                            &nbsp;&nbsp;
                            <asp:Label ID="lblError" runat="server" Text="Mã bảo vệ không đúng" Visible="false"
                                ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <cc1:CaptchaControl ID="CaptchaControl1" runat="server" Width="180px" Height="50px"
                                CssClass="captcha" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="last">
                            <asp:Button ID="btnSubmit" runat="server" Text="  Gửi  " OnClick="btnSubmit_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <p class="bot">
            &nbsp;</p>
    </div>
</asp:Content>
