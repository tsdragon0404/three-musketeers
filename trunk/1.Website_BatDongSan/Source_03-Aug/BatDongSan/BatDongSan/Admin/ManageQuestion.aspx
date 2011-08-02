<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    ValidateRequest="false" CodeBehind="ManageQuestion.aspx.cs" Inherits="BatDongSan.Admin.ManageQuestion"
    Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <div class="top">
            <img class="icon" src="../images/templates/default/QA/icon.png" />
            <p class="section_title">
                Tư vấn</p>
        </div>
        <div class="mid">
            <asp:LinqDataSource ID="detailDataSource" runat="server" ContextTypeName="BatDongSan.BDSDataContext"
                TableName="Questions" Where="ID == @ID" EnableUpdate="True">
                <WhereParameters>
                    <asp:ControlParameter ControlID="gvQuestion" Name="ID" PropertyName="SelectedValue"
                        Type="Int64" DefaultValue="0" />
                </WhereParameters>
            </asp:LinqDataSource>
            <asp:DetailsView ID="dtView" runat="server" Height="50px" Width="100%" AutoGenerateRows="False"
                DataKeyNames="ID" DataSourceID="detailDataSource" Visible="false" OnItemUpdating="dtView_ItemUpdating"
                DefaultMode="Edit" OnModeChanging="dtView_ModeChanging" OnItemUpdated="dtView_ItemUpdated">
                <Fields>
                    <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True"
                        SortExpression="ID" Visible="False" />
                    <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" SortExpression="Name"
                        Visible="False" />
                    <asp:BoundField DataField="Email" HeaderText="Email" ReadOnly="True" SortExpression="Email"
                        Visible="False" />
                    <asp:BoundField DataField="Phone" HeaderText="Phone" ReadOnly="True" SortExpression="Phone"
                        Visible="False" />
                    <asp:TemplateField HeaderText="Câu hỏi" SortExpression="QuestionText">
                        <EditItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("QuestionText") %>'></asp:Label>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("QuestionText") %>'></asp:TextBox>
                        </InsertItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("QuestionText") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Trả lời" SortExpression="AnswerText">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Rows="3" Name="elm1" Text='<%# Bind("AnswerText") %>'
                                TextMode="MultiLine"></asp:TextBox>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("AnswerText") %>'></asp:TextBox>
                        </InsertItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("AnswerText") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="PostDate" HeaderText="PostDate" ReadOnly="True" SortExpression="PostDate"
                        Visible="False" />
                    <asp:BoundField DataField="AnswerDate" HeaderText="AnswerDate" SortExpression="AnswerDate"
                        Visible="False" />
                    <asp:CheckBoxField DataField="IsAnswered" HeaderText="IsAnswered" SortExpression="IsAnswered"
                        Visible="False" />
                    <asp:CommandField ShowEditButton="True" CancelText="Quay lại" EditText="Trả lời"
                        UpdateText="Hoàn tất" />
                </Fields>
            </asp:DetailsView>
            <asp:LinqDataSource ID="QuestionDataSource" ContextTypeName="BatDongSan.BDSDataContext"
                TableName="Questions" runat="server" EnableDelete="True" EnableInsert="True"
                EnableUpdate="True" OrderBy="PostDate desc, ID" Where="IsAnswered == @IsAnswered">
                <WhereParameters>
                    <asp:ControlParameter ControlID="ddlAnswer" Name="IsAnswered" PropertyName="SelectedValue"
                        Type="Boolean" />
                </WhereParameters>
            </asp:LinqDataSource>
            <asp:DropDownList ID="ddlAnswer" runat="server" AutoPostBack="True">
                <asp:ListItem Value="False">Chưa Trả lời</asp:ListItem>
                <asp:ListItem Value="True">Đã trả lời</asp:ListItem>
            </asp:DropDownList>
            <asp:GridView ID="gvQuestion" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                DataKeyNames="ID" DataSourceID="QuestionDataSource" RowStyle-CssClass="GridRow"
                AlternatingRowStyle-CssClass="AltGridRow" SelectedRowStyle-CssClass="SelectedGridRow"
                CssClass="datagrid" OnSelectedIndexChanged="gvQuestion_SelectedIndexChanged">
                <RowStyle CssClass="GridRow"></RowStyle>
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True"
                        SortExpression="ID" Visible="False" />
                    <asp:BoundField DataField="Name" HeaderText="Người gửi" SortExpression="Name" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                    <asp:BoundField DataField="Phone" HeaderText="Điện thoại" SortExpression="Phone" />
                    <asp:BoundField DataField="QuestionText" HeaderText="Câu hỏi" SortExpression="QuestionText" />
                    <asp:BoundField DataField="AnswerText" HeaderText="Trả lời" SortExpression="AnswerText"
                        Visible="False" />
                    <asp:BoundField DataField="PostDate" HeaderText="Ngày đăng" SortExpression="PostDate" />
                    <asp:BoundField DataField="AnswerDate" HeaderText="AnswerDate" SortExpression="AnswerDate"
                        Visible="False" />
                    <asp:CheckBoxField DataField="IsAnswered" HeaderText="IsAnswered" SortExpression="IsAnswered"
                        Visible="False" />
                    <asp:CommandField ButtonType="Image" DeleteImageUrl="~/images/admin/Sysbols-Delete-icon.png"
                        ShowDeleteButton="True" CancelText="Quay lại" DeleteText="Xóa" EditText="Trả lời"
                        UpdateText="OK" ShowSelectButton="True">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:CommandField>
                </Columns>
                <SelectedRowStyle CssClass="SelectedGridRow"></SelectedRowStyle>
                <AlternatingRowStyle CssClass="AltGridRow"></AlternatingRowStyle>
            </asp:GridView>
        </div>
        <p class="bot">
            &nbsp;</p>
    </div>
</asp:Content>
