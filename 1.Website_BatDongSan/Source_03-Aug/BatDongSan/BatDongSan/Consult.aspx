<%@ Page Language="C#" MasterPageFile="~/Client.Master" AutoEventWireup="true" CodeBehind="Consult.aspx.cs"
    Inherits="BatDongSan.Consult" Title="Untitled Page" %>

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
                OrderBy="AnswerDate desc, ID" TableName="Questions" Where="IsAnswered == @IsAnswered">
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
                            <div class="Q">
                                <p class="text">
                                    <asp:Label ID="QuestionTextLabel" runat="server" Text='<%# Eval("QuestionText") %>' /></p>
                                <p class="info">
                                    (<asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                                    -
                                    <asp:Label ID="EmailLabel" runat="server" Text='<%# Eval("Email") %>' />)</p>
                            </div>
                            <div class="A">
                                <p class="separator">
                                    &nbsp;</p>
                                <p class="text">
                                    <asp:Label ID="AnswerTextLabel" runat="server" Text='<%# Eval("AnswerText") %>' /></p>
                            </div>
                            <div class="func">
                                <a class="showhide">Xem trả lời</a><br />
                            </div>
                        </div>
                        <p class="QA_bot">
                            &nbsp;</p>
                    </div>
                </ItemTemplate>
            </asp:DataList>
            <asp:Table runat="server">
                <asp:TableRow>
                    <asp:TableHeaderCell>Tên</asp:TableHeaderCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableHeaderCell>Email</asp:TableHeaderCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableHeaderCell>Điện thoại</asp:TableHeaderCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableHeaderCell>Nội dung</asp:TableHeaderCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtQuestion" runat="server" TextMode="MultiLine" Rows="3" AutoCompleteType="None"></asp:TextBox></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="2">
                        <asp:Button ID="btnSubmit" runat="server" Text="Button" OnClick="btnSubmit_Click" /></asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
        <p class="bot">
            &nbsp;</p>
    </div>
</asp:Content>
