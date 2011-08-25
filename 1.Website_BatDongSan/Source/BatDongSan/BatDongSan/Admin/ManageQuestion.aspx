<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    ValidateRequest="false" CodeBehind="ManageQuestion.aspx.cs" Inherits="BatDongSan.Admin.ManageQuestion"
    Title="Trả lời câu hỏi tư vấn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <div class="top">
            <img class="icon" src="../images/templates/default/QA/icon.png" />
            <p class="section_title">
                Trả lời câu hỏi tư vấn</p>
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
                DataKeyNames="ID" DataSourceID="detailDataSource" Visible="False" OnItemUpdating="dtView_ItemUpdating"
                DefaultMode="Edit" OnModeChanging="dtView_ModeChanging" OnItemUpdated="dtView_ItemUpdated"
                CssClass="tbl" GridLines="None">
                <Fields>
                    <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True"
                        SortExpression="ID" Visible="False" />
                    <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" SortExpression="Name"
                        Visible="False" />
                    <asp:BoundField DataField="Email" HeaderText="Email" ReadOnly="True" SortExpression="Email"
                        Visible="False" />
                    <asp:BoundField DataField="Phone" HeaderText="Phone" ReadOnly="True" SortExpression="Phone"
                        Visible="False" />
                    <asp:TemplateField HeaderText="Câu hỏi" SortExpression="QuestionText" ShowHeader="False"
                        Visible="false">
                        <EditItemTemplate>
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
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Trả lời" SortExpression="AnswerText" ShowHeader="False">
                        <EditItemTemplate>
                            <div class="QA">
                                <p class="QA_top">
                                    &nbsp;</p>
                                <div class="QA_mid">
                                    <div class="Q">
                                        <p class="text">
                                            <asp:Label ID="QuestionTextLabel2" runat="server" Text='<%# Eval("QuestionText") %>' /></p>
                                        <p class="info">
                                            (<asp:Label ID="NameLabel2" runat="server" Text='<%# Eval("Name") %>' />
                                            -
                                            <asp:Label ID="EmailLabel2" runat="server" Text='<%# Eval("Email") %>' />)</p>
                                    </div>
                                    <div class="A" style="display: inherit;">
                                        <p class="separator">
                                            &nbsp;</p>
                                        <p class="text">
                                            <asp:TextBox ID="TextBox1" runat="server" Rows="3" Name="elm1" Text='<%# Bind("AnswerText") %>'
                                                TextMode="MultiLine" CssClass="textarea"></asp:TextBox></p>
                                    </div>
                                </div>
                                <p class="QA_bot">
                                    &nbsp;</p>
                            </div>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="PostDate" HeaderText="PostDate" ReadOnly="True" SortExpression="PostDate"
                        Visible="False" />
                    <asp:BoundField DataField="AnswerDate" HeaderText="AnswerDate" SortExpression="AnswerDate"
                        Visible="False" />
                    <asp:CheckBoxField DataField="IsAnswered" HeaderText="IsAnswered" SortExpression="IsAnswered"
                        Visible="False" />
                    <asp:TemplateField ShowHeader="False">
                        <EditItemTemplate>
                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="True" CommandName="Update"
                                ImageUrl="~/images/Admin/OK.png" Text="Hoàn tất" ToolTip="Hoàn tất" />
                            &nbsp;<asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False"
                                CommandName="Cancel" ImageUrl="~/images/Admin/Delete.png" Text="Quay lại" ToolTip="Quay lại" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                Text="Trả lời" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
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
                CssClass="datagrid" OnSelectedIndexChanged="gvQuestion_SelectedIndexChanged"
                PageSize="5" onrowdeleting="gvQuestion_RowDeleting">
                <RowStyle CssClass="GridRow"></RowStyle>
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True"
                        SortExpression="ID" Visible="False" />
                    <asp:BoundField DataField="Name" HeaderText="Người gửi" SortExpression="Name">
                        <HeaderStyle Width="15%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email">
                        <HeaderStyle Width="15%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Phone" HeaderText="Điện thoại" SortExpression="Phone">
                        <HeaderStyle Width="15%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="QuestionText" HeaderText="Câu hỏi" SortExpression="QuestionText">
                        <HeaderStyle Width="40%" />
                        <ItemStyle Wrap="True" />
                    </asp:BoundField>
                    <asp:BoundField DataField="AnswerText" HeaderText="Trả lời" SortExpression="AnswerText"
                        Visible="False" />
                    <asp:BoundField DataField="PostDate" HeaderText="Ngày đăng" SortExpression="PostDate"
                        DataFormatString="{0:dd-MM-yy}">
                        <ItemStyle Wrap="False" />
                    </asp:BoundField>
                    <asp:BoundField DataField="AnswerDate" HeaderText="AnswerDate" SortExpression="AnswerDate"
                        Visible="False" />
                    <asp:CheckBoxField DataField="IsAnswered" HeaderText="IsAnswered" SortExpression="IsAnswered"
                        Visible="False" />
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Select"
                                ImageUrl="~/images/Admin/OK.png" Text="Trả lời" ToolTip="Trả lời" />
                            <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                ImageUrl="~/images/Admin/Delete.png" Text="Xóa" ToolTip="Xóa" OnClientClick="return confirm('Xóa câu hỏi này ?');" />
                        </ItemTemplate>
                        <HeaderStyle Width="15%" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
                <SelectedRowStyle CssClass="SelectedGridRow"></SelectedRowStyle>
                <AlternatingRowStyle CssClass="AltGridRow"></AlternatingRowStyle>
            </asp:GridView>
        </div>
        <p class="bot">
            &nbsp;</p>
    </div>
</asp:Content>
