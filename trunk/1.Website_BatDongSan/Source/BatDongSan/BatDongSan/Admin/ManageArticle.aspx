<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="ManageArticle.aspx.cs" Inherits="BatDongSan.Admin.ManageArticle"
    Title="Quản lý tin tức" %>
<%@ Register Assembly="obout_Editor" Namespace="OboutInc.Editor" TagPrefix="obout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <div class="top">
            <img class="icon" src="../images/templates/default/top_news/icon.png" />
            <p class="section_title">
                Quản lý tin tức</p>
        </div>
        <div class="mid">
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
                <asp:ListItem Value="True">Sử dụng</asp:ListItem>
                <asp:ListItem Value="False">Không sử dụng</asp:ListItem>
            </asp:DropDownList>
            <asp:ImageButton ID="ImageButton3" runat="server" CssClass="add" ImageUrl="~/images/Admin/Add.png"
                OnClick="ImageButton3_Click" ToolTip="Thêm mới" />
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                DataKeyNames="ID" DataSourceID="LinqDataSource1" Width="100%" 
                OnSelectedIndexChanged="GridView1_SelectedIndexChanged" 
                onrowdeleting="GridView1_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True"
                        SortExpression="ID" Visible="False" />
                    <asp:TemplateField HeaderText="Tiêu đề" SortExpression="Title">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Title") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Title") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Summary" HeaderText="Tóm tắt" SortExpression="Summary" />
                    <asp:BoundField DataField="Contents" HeaderText="Contents" SortExpression="Contents"
                        Visible="False" />
                    <asp:TemplateField HeaderText="Ngày đăng" SortExpression="PostDate" ItemStyle-Wrap="false">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("PostDate") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblDate" runat="server" Text='<%# Bind("PostDate", "{0:dd-MM-yy}") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Wrap="False"></ItemStyle>
                    </asp:TemplateField>
                    <asp:BoundField DataField="LatestModifiedDate" Visible="false" HeaderText="Ngày chỉnh sửa"
                        SortExpression="LatestModifiedDate" />
                    <asp:CheckBoxField Visible="false" DataField="IsValid" HeaderText="Có hiệu lực" SortExpression="IsValid">
                    </asp:CheckBoxField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Select"
                                ImageUrl="~/images/Admin/Edit.png" Text="Select" ToolTip="Chỉnh sửa" />
                            <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                ImageUrl="~/images/Admin/Delete.png" Text="Delete" ToolTip="Xóa" OnClientClick="return confirm('Xóa bài viết này ?');" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="BatDongSan.BDSDataContext"
                EnableDelete="True" EnableInsert="True" EnableUpdate="True" TableName="Articles"
                Where="IsValid == @IsValid">
                <WhereParameters>
                    <asp:ControlParameter ControlID="DropDownList1" Name="IsValid" PropertyName="SelectedValue"
                        Type="Boolean" />
                </WhereParameters>
            </asp:LinqDataSource>
            <%--<uc1:ucAddArticle ID="ucAddArticle1" runat="server" Visible="False" />
            <uc2:ucEditArticle ID="ucEditArticle1" runat="server" EnableViewState="True" />--%>
            <asp:DetailsView ID="DetailsView1" runat="server" Width="100%" AutoGenerateRows="False"
                DataKeyNames="ID" DataSourceID="LinqDataSource2" OnItemInserting="DetailsView1_ItemInserting"
                OnItemInserted="DetailsView1_ItemInserted" OnItemUpdated="DetailsView1_ItemUpdated"
                OnItemUpdating="DetailsView1_ItemUpdating" OnModeChanging="DetailsView1_ModeChanging">
                <Fields>
                    <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True"
                        SortExpression="ID" Visible="False" />
                    <asp:TemplateField HeaderText="Title" SortExpression="Title">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" CssClass="textbox" Text='<%# Bind("Title") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" CssClass="textbox" Text='<%# Bind("Title") %>'></asp:TextBox>
                        </InsertItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("Title") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Summary" SortExpression="Summary">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Rows="3" Text='<%# Bind("Summary") %>'
                                CssClass="textarea2" TextMode="MultiLine"></asp:TextBox>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Rows="3" Text='<%# Bind("Summary") %>'
                                CssClass="textarea2" TextMode="MultiLine"></asp:TextBox>
                        </InsertItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Summary") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Contents" SortExpression="Contents">
                        <EditItemTemplate>
                            <obout:Editor ID="editorNoidung" runat="server" Content='<%# Bind("Contents") %>'
                                PathPrefix="Editor_data/" PreviewMode="True" ShowQuickFormat="False" Submit="false">
                                <Buttons>
                                    <obout:HorizontalSeparator />
                                    <obout:Custom ImageName="ed_upload_image_n.gif" OnClientClick="myImageUpload" ToolTip="Upload image" />
                                </Buttons>
                            </obout:Editor>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <obout:Editor ID="editorNoidung" runat="server" Content='<%# Bind("Contents") %>'
                                PathPrefix="Editor_data/" PreviewMode="True" ShowQuickFormat="False" Submit="false">
                                <Buttons>
                                    <obout:HorizontalSeparator />
                                    <obout:Custom ImageName="ed_upload_image_n.gif" OnClientClick="myImageUpload" ToolTip="Upload image" />
                                </Buttons>
                            </obout:Editor>
                        </InsertItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("Contents") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="PostDate" HeaderText="PostDate" SortExpression="PostDate"
                        Visible="False" />
                    <asp:BoundField DataField="LatestModifiedDate" HeaderText="LatestModifiedDate" SortExpression="LatestModifiedDate"
                        Visible="False" />
                    <asp:CheckBoxField DataField="IsValid" HeaderText="IsValid" SortExpression="IsValid" />
                    <asp:TemplateField ShowHeader="False">
                        <EditItemTemplate>
                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="True" CommandName="Update"
                                ImageUrl="~/images/Admin/OK.png" Text="Update" />
                            &nbsp;<asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False"
                                CommandName="Cancel" ImageUrl="~/images/Admin/Back.png" Text="Cancel" />
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="True" CommandName="Insert"
                                ImageUrl="~/images/Admin/OK.png" Text="Insert" />
                            &nbsp;<asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False"
                                CommandName="Cancel" ImageUrl="~/images/Admin/Back.png" Text="Cancel" />
                        </InsertItemTemplate>
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                Text="Edit" />
                            &nbsp;<asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False"
                                CommandName="New" Text="New" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Fields>
            </asp:DetailsView>
            <asp:LinqDataSource ID="LinqDataSource2" runat="server" ContextTypeName="BatDongSan.BDSDataContext"
                EnableInsert="True" EnableUpdate="True" TableName="Articles" Where="ID == @ID">
                <WhereParameters>
                    <asp:ControlParameter ControlID="GridView1" Name="ID" PropertyName="SelectedValue"
                        DefaultValue="0" Type="Int64" />
                </WhereParameters>
            </asp:LinqDataSource>
        </div>
        <p class="bot">
            &nbsp;</p>
    </div>
</asp:Content>
