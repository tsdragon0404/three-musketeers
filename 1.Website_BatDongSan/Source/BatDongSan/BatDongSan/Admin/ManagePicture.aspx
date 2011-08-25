<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="ManagePicture.aspx.cs" Inherits="BatDongSan.Admin.ManagePicture"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <div class="top">
            <img class="icon" src="../images/templates/default/sidebar/icon_6.png" />
            <p class="section_title">
                Quản lý hình ảnh</p>
        </div>
        <div class="mid">
            <asp:ImageButton ID="ImageButton3" runat="server" CssClass="add" ImageUrl="~/images/Admin/Add.png"
                OnClick="ImageButton3_Click" ToolTip="Thêm mới" />
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                DataKeyNames="ID" DataSourceID="LinqDataSource1" AllowSorting="True" Width="100%"
                OnRowDeleting="GridView1_RowDeleting" onrowupdated="GridView1_RowUpdated" 
                onrowupdating="GridView1_RowUpdating" PageSize="5">
                <Columns>
                    <asp:TemplateField HeaderText="STT">
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"/>
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True"
                        SortExpression="ID" Visible="False" />
                    <asp:BoundField DataField="Url" HeaderText="Url" SortExpression="Url" Visible="False" />
                    <asp:TemplateField HeaderText="Hình ảnh" SortExpression="Thumbnail">
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Thumbnail", "../{0}") %>' />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Thumbnail", "../{0}") %>' /><br />
                            <asp:FileUpload ID="FUpPic" runat="server" />
                        </EditItemTemplate>
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
                    <asp:TemplateField HeaderText="Chọn hình" SortExpression="Url">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Url") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Url") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:FileUpload ID="FUpPic2" runat="server" />
                        </InsertItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Thumbnail" HeaderText="Thumbnail" SortExpression="Thumbnail"
                        Visible="False" />
                    <asp:CheckBoxField DataField="IsValid" HeaderText="IsValid" SortExpression="IsValid"
                        Visible="False" />
                    <asp:CommandField ButtonType="Image" CancelImageUrl="~/images/Admin/Back.png" InsertImageUrl="~/images/Admin/OK.png"
                        ShowInsertButton="True" />
                </Fields>
                <HeaderTemplate>
                    Thêm hình
                </HeaderTemplate>
            </asp:DetailsView>
            <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="BatDongSan.BDSDataContext"
                EnableDelete="True" TableName="HeaderPics" EnableInsert="True" EnableUpdate="True"
                OrderBy="IsValid desc">
            </asp:LinqDataSource>
            <asp:LinqDataSource ID="LinqDataSource2" runat="server" ContextTypeName="BatDongSan.BDSDataContext"
                TableName="HeaderPics" EnableUpdate="True" EnableInsert="True">
            </asp:LinqDataSource>
        </div>
        <p class="bot">
            &nbsp;</p>
    </div>
</asp:Content>
