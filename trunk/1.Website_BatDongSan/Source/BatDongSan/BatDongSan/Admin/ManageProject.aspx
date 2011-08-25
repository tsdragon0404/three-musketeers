<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="ManageProject.aspx.cs" Inherits="BatDongSan.Admin.ManageProject"
    Title="Quản lý dự án" %>

<%@ Register Assembly="obout_Editor" Namespace="OboutInc.Editor" TagPrefix="obout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <div class="top">
            <img class="icon" src="../images/templates/default/housing/pj.png" />
            <p class="section_title">
                Quản lý dự án</p>
        </div>
        <div class="mid">
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
                <asp:ListItem Value="True">Sử dụng</asp:ListItem>
                <asp:ListItem Value="False">Không sử dụng</asp:ListItem>
            </asp:DropDownList>
            <asp:ImageButton ID="ImageButton3" runat="server" CssClass="add" ImageUrl="~/images/Admin/Add.png"
                OnClick="ImageButton3_Click" ToolTip="Thêm mới" />
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                DataSourceID="LinqDataSource1" AllowSorting="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                Width="100%" DataKeyNames="ID" onrowdeleting="GridView1_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" SortExpression="ID"
                        Visible="False" />
                    <asp:BoundField DataField="Title" HeaderText="Tiêu đề" SortExpression="Title" />
                    <asp:TemplateField HeaderText="Hình ảnh" SortExpression="Picture">
                        <ItemTemplate>
                            <asp:Image ID="Image2" runat="server" AlternateText='<%# Eval("Title") %>' ImageUrl='<%# Eval("Picture", "../{0}") %>'
                                Width="145px" Height="100px" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Summary" HeaderText="Tóm tắt" SortExpression="Summary" />
                    <asp:BoundField DataField="Description" HeaderText="Chi tiết" SortExpression="Description"
                        Visible="False" />
                    <asp:TemplateField HeaderText="Ngày đăng" SortExpression="PostDate" ItemStyle-Wrap="false">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("PostDate", "{0:dd-MM-yy}") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Wrap="False"></ItemStyle>
                    </asp:TemplateField>
                    <asp:BoundField DataField="LastestModifiedDate" HeaderText="LastestModifiedDate"
                        SortExpression="LastestModifiedDate" Visible="False" />
                    <asp:BoundField DataField="ViewCount" HeaderText="Lượt xem" SortExpression="ViewCount">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:CheckBoxField DataField="IsValid" HeaderText="IsValid" SortExpression="IsValid"
                        Visible="False" ItemStyle-HorizontalAlign="Center">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:CheckBoxField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Select"
                                ImageUrl="~/images/Admin/Edit.png" Text="Select" ToolTip="Chỉnh sửa" />
                            <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                ImageUrl="~/images/Admin/Delete.png" Text="Delete" ToolTip="Xóa" OnClientClick="return confirm('Xóa dự án này ?');" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataSourceID="LinqDataSource2"
                DataKeyNames="ID" Visible="False" OnItemUpdating="DetailsView1_ItemUpdating"
                OnModeChanging="DetailsView1_ModeChanging" OnItemUpdated="DetailsView1_ItemUpdated"
                OnItemInserting="DetailsView1_ItemInserting" OnItemInserted="DetailsView1_ItemInserted"
                Width="100%">
                <Fields>
                    <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" SortExpression="ID"
                        Visible="False" />
                    <asp:TemplateField HeaderText="Tiêu đề" SortExpression="Title">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" CssClass="textbox" runat="server" Text='<%# Bind("Title") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:TextBox ID="TextBox1" CssClass="textbox" runat="server" Text='<%# Bind("Title") %>'></asp:TextBox>
                        </InsertItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Hình ảnh" SortExpression="Picture">
                        <EditItemTemplate>
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Picture", "../{0}") %>'
                                Width="145px" Height="100px" /><br />
                            <asp:FileUpload ID="FileUpload1B" runat="server" />
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:FileUpload ID="FileUpload1B" runat="server" />
                        </InsertItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tóm tắt" SortExpression="Summary">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox3" CssClass="textarea2" Rows="3" TextMode="MultiLine" runat="server"
                                Text='<%# Bind("Summary") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:TextBox ID="TextBox3" CssClass="textarea2" Rows="3" TextMode="MultiLine" runat="server"
                                Text='<%# Bind("Summary") %>'></asp:TextBox>
                        </InsertItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Chi tiết" SortExpression="Description">
                        <EditItemTemplate>
                            <obout:Editor ID="editorNoidung" runat="server" Content='<%# Bind("Description") %>'
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
                    <asp:BoundField DataField="PostDate" HeaderText="PostDate" SortExpression="PostDate"
                        Visible="False" />
                    <asp:BoundField DataField="LatestModifiedDate" HeaderText="LatestModifiedDate" SortExpression="LatestModifiedDate"
                        Visible="False" />
                    <asp:BoundField DataField="ViewCount" HeaderText="ViewCount" SortExpression="ViewCount"
                        Visible="False" />
                    <asp:CheckBoxField DataField="IsValid" HeaderText="Hiển thị" SortExpression="IsValid" />
                    <asp:TemplateField ShowHeader="False">
                        <EditItemTemplate>
                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="True" CommandName="Update"
                                ImageUrl="~/images/Admin/OK.png" Text="Update" ToolTip="Hoàn tất" />
                            &nbsp;<asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False"
                                CommandName="Cancel" ImageUrl="~/images/Admin/Back.png" Text="Cancel" ToolTip="Quay lại" />
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="True" CommandName="Insert"
                                ImageUrl="~/images/Admin/OK.png" Text="Insert" ToolTip="Hoàn tất" />
                            &nbsp;<asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False"
                                CommandName="Cancel" ImageUrl="~/images/Admin/Back.png" Text="Cancel" ToolTip="Quay lại" />
                        </InsertItemTemplate>
                    </asp:TemplateField>
                </Fields>
            </asp:DetailsView>
            <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="BatDongSan.BDSDataContext"
                EnableDelete="True" TableName="Projects" Where="IsValid == @IsValid" EnableInsert="True"
                OrderBy="PostDate desc">
                <WhereParameters>
                    <asp:ControlParameter ControlID="DropDownList1" Name="IsValid" PropertyName="SelectedValue"
                        Type="Boolean" />
                </WhereParameters>
            </asp:LinqDataSource>
            <asp:LinqDataSource ID="LinqDataSource2" runat="server" ContextTypeName="BatDongSan.BDSDataContext"
                TableName="Projects" Where="ID == @ID" EnableUpdate="True" EnableInsert="True">
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
