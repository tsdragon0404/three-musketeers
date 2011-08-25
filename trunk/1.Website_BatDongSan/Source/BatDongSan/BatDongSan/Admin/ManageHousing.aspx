<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="ManageHousing.aspx.cs" Inherits="BatDongSan.Admin.ManageHousing"
    Title="Quản lý bất động sản" %>

<%@ Register Assembly="obout_Editor" Namespace="OboutInc.Editor" TagPrefix="obout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <div class="top">
            <img class="icon" src="../images/templates/default/housing/icon.png" />
            <p class="section_title">
                Quản lý bất động sản</p>
        </div>
        <div class="mid">
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
                <asp:ListItem Value="True">Sử dụng</asp:ListItem>
                <asp:ListItem Value="False">Không sử dụng</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True">
                <asp:ListItem Value="False">Đất nền</asp:ListItem>
                <asp:ListItem Value="True">Đất nông nghiệp</asp:ListItem>
            </asp:DropDownList>
            <asp:ImageButton ID="ImageButton3" runat="server" CssClass="add" ImageUrl="~/images/Admin/Add.png"
                OnClick="ImageButton3_Click" ToolTip="Thêm mới" />
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="LinqDataSource3"
                OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="100%" 
                onrowdeleting="GridView1_RowDeleting">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Image ID="Image2" runat="server" ImageUrl='<%# Eval("Thumbnail", "../{0}") %>' />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Title" HeaderText="Tiêu đề" SortExpression="Title">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Price" HeaderText="Giá bán" SortExpression="Price">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ViewCount" HeaderText="ViewCount" SortExpression="ViewCount"
                        Visible="False" />
                    <asp:CheckBoxField DataField="ForSale" HeaderText="Bán" SortExpression="ForSale">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:CheckBoxField>
                    <asp:CheckBoxField DataField="ForRent" HeaderText="Cho thuê" SortExpression="ForRent">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:CheckBoxField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Select"
                                ImageUrl="~/images/Admin/Edit.png" Text="Select" ToolTip="Chỉnh sửa" />
                            <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                ImageUrl="~/images/Admin/Delete.png" OnClientClick="return confirm('Xóa mục này ?');"
                                Text="Delete" ToolTip="Xóa" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:DetailsView ID="DetailsView1" runat="server" Width="100%" AutoGenerateRows="False"
                DataKeyNames="ID" DataSourceID="LinqDataSource4" OnItemInserted="DetailsView1_ItemInserted"
                OnItemInserting="DetailsView1_ItemInserting" OnItemUpdated="DetailsView1_ItemUpdated"
                OnItemUpdating="DetailsView1_ItemUpdating" OnModeChanging="DetailsView1_ModeChanging">
                <Fields>
                    <asp:TemplateField HeaderText="ID" InsertVisible="False" SortExpression="ID" Visible="False">
                        <EditItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tiêu đề" SortExpression="Title">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Title") %>' Width="100%"></asp:TextBox>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Title") %>' Width="100%"></asp:TextBox>
                        </InsertItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Thumbnail" HeaderText="Thumbnail" SortExpression="Thumbnail"
                        Visible="False" />
                    <asp:TemplateField HeaderText="Hình ảnh" SortExpression="Picture">
                        <EditItemTemplate>
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Thumbnail", "../{0}") %>' />
                            <br />
                            <asp:FileUpload ID="FileUpload1B" runat="server" />
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:FileUpload ID="FileUpload1B" runat="server" />
                        </InsertItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Giá" SortExpression="Price">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Price") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Price") %>'></asp:TextBox>
                        </InsertItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Chi tiết" SortExpression="Description">
                        <EditItemTemplate>
                            <obout:Editor ID="editorNoidung"  runat="server" Content='<%# Bind("Description") %>'
                                PathPrefix="Editor_data/" PreviewMode="True" ShowQuickFormat="False" Submit="false">
                                <Buttons>
                                    <obout:HorizontalSeparator />
                                    <obout:Custom ImageName="ed_upload_image_n.gif" OnClientClick="myImageUpload" ToolTip="Upload image" />
                                </Buttons>
                            </obout:Editor>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <obout:Editor ID="editorNoidung" runat="server" Content='<%# Bind("Description") %>'
                                PathPrefix="Editor_data/" PreviewMode="True" ShowQuickFormat="False" Submit="false">
                                <Buttons>
                                    <obout:HorizontalSeparator />
                                    <obout:Custom ImageName="ed_upload_image_n.gif" OnClientClick="myImageUpload" ToolTip="Upload image" />
                                </Buttons>
                            </obout:Editor>
                        </InsertItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ViewCount" SortExpression="ViewCount" Visible="False">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("ViewCount") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("ViewCount") %>'></asp:TextBox>
                        </InsertItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Đất nông nghiệp" SortExpression="Agri">
                        <EditItemTemplate>
                            <asp:CheckBox ID="CheckBox4" runat="server" Checked='<%# Bind("Agri") %>' />
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:CheckBox ID="CheckBox4" runat="server" Checked='<%# Bind("Agri") %>' />
                        </InsertItemTemplate>
                        <HeaderStyle Width="11%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Bán" SortExpression="ForSale">
                        <EditItemTemplate>
                            <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("ForSale") %>' />
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("ForSale") %>' />
                        </InsertItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Thuê" SortExpression="ForRent">
                        <EditItemTemplate>
                            <asp:CheckBox ID="CheckBox2" runat="server" Checked='<%# Bind("ForRent") %>' />
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:CheckBox ID="CheckBox2" runat="server" Checked='<%# Bind("ForRent") %>' />
                        </InsertItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Hiệu lực" SortExpression="IsValid">
                        <EditItemTemplate>
                            <asp:CheckBox ID="CheckBox3" runat="server" Checked='<%# Bind("IsValid") %>' />
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:CheckBox ID="CheckBox3" runat="server" Checked='<%# Bind("IsValid") %>' />
                        </InsertItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <EditItemTemplate>
                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="True" CommandName="Update"
                                ImageUrl="~/images/Admin/OK.png" Text="Update" ToolTip="Hoàn tất" />
                            &nbsp;<asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False"
                                CommandName="Cancel" ImageUrl="~/images/Admin/Back.png" Text="Cancel" ToolTip="Quay lại" />
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="True" CommandName="Insert"
                                ImageUrl="~/images/Admin/OK.png" Text="Update" ToolTip="Hoàn tất" />
                            &nbsp;<asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False"
                                CommandName="Cancel" ImageUrl="~/images/Admin/Back.png" Text="Cancel" ToolTip="Quay lại" />
                        </InsertItemTemplate>
                    </asp:TemplateField>
                </Fields>
            </asp:DetailsView>
            <asp:LinqDataSource ID="LinqDataSource3" runat="server" ContextTypeName="BatDongSan.BDSDataContext"
                OrderBy="ID desc" TableName="Houses" EnableDelete="True" Where="IsValid == @IsValid &amp;&amp; Agri == @Agri">
                <WhereParameters>
                    <asp:ControlParameter ControlID="DropDownList1" Name="IsValid" PropertyName="SelectedValue"
                        Type="Boolean" />
                    <asp:ControlParameter ControlID="DropDownList2" Name="Agri" PropertyName="SelectedValue"
                        Type="Boolean" />
                </WhereParameters>
            </asp:LinqDataSource>
            <asp:LinqDataSource ID="LinqDataSource4" runat="server" ContextTypeName="BatDongSan.BDSDataContext"
                EnableInsert="True" EnableUpdate="True" TableName="Houses" Where="ID == @ID">
                <WhereParameters>
                    <asp:ControlParameter ControlID="GridView1" DefaultValue="0" Name="ID" PropertyName="SelectedValue"
                        Type="Int64" />
                </WhereParameters>
            </asp:LinqDataSource>
        </div>
        <p class="bot">
            &nbsp;</p>
    </div>
</asp:Content>
