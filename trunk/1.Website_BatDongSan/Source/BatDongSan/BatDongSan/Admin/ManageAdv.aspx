<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="ManageAdv.aspx.cs" Inherits="BatDongSan.Admin.ManageAdv" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <div class="top">
            <img class="icon" src="../images/templates/default/sidebar/icon_6.png" />
            <p class="section_title">
                Quản lý quảng cáo</p>
        </div>
        <div class="mid">
            <asp:ImageButton ID="ImageButton3" runat="server" CssClass="add" ImageUrl="~/images/Admin/Add.png"
                OnClick="ImageButton3_Click" ToolTip="Thêm mới" />
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                DataKeyNames="ID" DataSourceID="LinqDataSource1" AllowSorting="True" Width="100%"
                OnRowDeleting="GridView1_RowDeleting" OnRowUpdated="GridView1_RowUpdated" 
                OnRowUpdating="GridView1_RowUpdating" PageSize="5">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True"
                        SortExpression="ID" Visible="False" />
                    <asp:TemplateField HeaderText="Tên" SortExpression="Name">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" CssClass="smalltb" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Hình ảnh" SortExpression="Picture">
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Picture", "../{0}") %>'
                                Width="150px" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Picture", "../{0}") %>'
                                Width="150px" /><br />
                            <asp:FileUpload ID="FUpPic" runat="server" CssClass="fup" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Website" SortExpression="Url">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" CssClass="smalltb" runat="server" Text='<%# Bind("Url") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# Eval("Url") %>' Target="_blank"
                                Text='<%# Eval("Url") %>'></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CheckBoxField DataField="IsValid" HeaderText="Hiển thị" SortExpression="IsValid"
                        ItemStyle-HorizontalAlign="Center">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:CheckBoxField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                ImageUrl="~/images/Admin/Edit.png" Text="Edit" ToolTip="Chỉnh sửa" />
                            &nbsp;<asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False"
                                CommandName="Delete" ImageUrl="~/images/Admin/Delete.png" Text="Delete" ToolTip="Xóa"
                                OnClientClick="return confirm('Xóa hình này ?');" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="True" CommandName="Update"
                                ImageUrl="~/images/Admin/OK.png" Text="Update" ToolTip="Hoàn tất" />
                            &nbsp;<asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False"
                                CommandName="Cancel" ImageUrl="~/images/Admin/Back.png" Text="Cancel" ToolTip="Quay lại" />
                        </EditItemTemplate>
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataSourceID="LinqDataSource2"
                Visible="False" DataKeyNames="ID" Width="100%" OnModeChanging="DetailsView1_ModeChanging"
                OnItemInserting="DetailsView1_ItemInserting" OnItemInserted="DetailsView1_ItemInserted">
                <Fields>
                    <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True"
                        SortExpression="ID" Visible="False" />
                    <asp:BoundField DataField="Name" HeaderText="Tên" SortExpression="Name" />
                    <asp:TemplateField HeaderText="Hình ảnh" SortExpression="Picture">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Picture") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:FileUpload ID="FUpPic" runat="server" />
                        </InsertItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Picture") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Url" HeaderText="Website" SortExpression="Url" />
                    <asp:CheckBoxField DataField="IsValid" HeaderText="IsValid" 
                        SortExpression="IsValid" Visible="False" />
                    <asp:TemplateField ShowHeader="False">
                        <InsertItemTemplate>
                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="True" CommandName="Insert"
                                ImageUrl="~/images/Admin/OK.png" ToolTip="Hoàn tất" />
                            &nbsp;<asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False"
                                CommandName="Cancel" ImageUrl="~/images/Admin/Back.png" ToolTip="Quay lại" />
                        </InsertItemTemplate>
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="New" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Fields>
                <HeaderTemplate>
                    Thêm quảng cáo
                </HeaderTemplate>
            </asp:DetailsView>
            <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="BatDongSan.BDSDataContext"
                EnableDelete="True" TableName="Advs" EnableInsert="True" EnableUpdate="True"
                OrderBy="IsValid desc">
            </asp:LinqDataSource>
            <asp:LinqDataSource ID="LinqDataSource2" runat="server" ContextTypeName="BatDongSan.BDSDataContext"
                TableName="Advs" EnableUpdate="True" EnableInsert="True">
            </asp:LinqDataSource>
        </div>
        <p class="bot">
            &nbsp;</p>
    </div>
</asp:Content>
