<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="ManagePartner.aspx.cs" Inherits="BatDongSan.Admin.ManagePartner"
    Title="Quản lý đối tác" %>

<%@ Register Assembly="obout_Editor" Namespace="OboutInc.Editor" TagPrefix="obout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <div class="top">
            <img class="icon" src="../images/templates/default/sidebar/icon_1.png" />
            <p class="section_title">
                Quản lý đối tác</p>
        </div>
        <div class="mid">
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
                <asp:ListItem Value="True">Sử dụng</asp:ListItem>
                <asp:ListItem Value="False">Không sử dụng</asp:ListItem>
            </asp:DropDownList>
            <asp:ImageButton ID="ImageButton3" runat="server" CssClass="add" ImageUrl="~/images/Admin/Add.png"
                OnClick="ImageButton3_Click" ToolTip="Thêm mới" />
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                DataKeyNames="ID" DataSourceID="LinqDataSource1" AllowSorting="True"
                Width="100%" onrowdeleting="GridView1_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="STT" InsertVisible="False" ReadOnly="True"
                        SortExpression="ID" Visible="False" />
                    <asp:BoundField DataField="Name" HeaderText="Tên" SortExpression="Name" />
                    <asp:BoundField DataField="Contents" HeaderText="Thông tin" SortExpression="Contents" />
                    <asp:CheckBoxField DataField="IsValid" HeaderText="Hiển thị" SortExpression="IsValid"
                        Visible="False" ItemStyle-HorizontalAlign="Center">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:CheckBoxField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <a href='ManagePartner.aspx?id=<%# Eval("ID") %>'><img src="../images/Admin/Edit.png" title="Chỉnh sửa"/></a>
                            <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                ImageUrl="~/images/Admin/Delete.png" ToolTip="Xóa" OnClientClick="return confirm('Xóa đối tác này ?');" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataSourceID="LinqDataSource2"
                Visible="False" DataKeyNames="ID" OnItemUpdating="DetailsView1_ItemUpdating" Width="100%"
                OnModeChanging="DetailsView1_ModeChanging" OnItemUpdated="DetailsView1_ItemUpdated"
                OnItemInserting="DetailsView1_ItemInserting" OnItemInserted="DetailsView1_ItemInserted">
                <Fields>
                    <asp:TemplateField HeaderText="STT" Visible="False">
                        <ItemTemplate>
                            <asp:TextBox ID="txtID" runat="server" Text='<%# Eval("ID") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tên">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:TextBox ID="txtName2" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                        </InsertItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Thông tin">
                        <EditItemTemplate>
                            <obout:Editor ID="editorNoidung" runat="server" Content='<%# Bind("Contents") %>'
                                PathPrefix="Editor_data/" PreviewMode="True" ShowQuickFormat="False">
                                <Buttons>
                                    <obout:HorizontalSeparator />
                                    <obout:Custom ImageName="ed_upload_image_n.gif" OnClientClick="myImageUpload" ToolTip="Upload image" />
                                </Buttons>
                            </obout:Editor>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <obout:Editor ID="editorNoidung" runat="server" Content='<%# Bind("Contents") %>'
                                PathPrefix="Editor_data/" PreviewMode="True" ShowQuickFormat="False">
                                <Buttons>
                                    <obout:HorizontalSeparator />
                                    <obout:Custom ImageName="ed_upload_image_n.gif" OnClientClick="myImageUpload" ToolTip="Upload image" />
                                </Buttons>
                            </obout:Editor>
                        </InsertItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Hiển thị">
                        <EditItemTemplate>
                            <asp:CheckBox ID="ckbValid" runat="server" Checked='<%# Bind("IsValid") %>' />
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:CheckBox ID="ckbValid" runat="server" Checked='<%# Bind("IsValid") %>' />
                        </InsertItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <EditItemTemplate>
                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="True" CommandName="Update"
                                ImageUrl="~/images/Admin/OK.png" ToolTip="Hoàn tất" />
                            &nbsp;<asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False"
                                CommandName="Cancel" ImageUrl="~/images/Admin/Back.png" ToolTip="Quay lại" />
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="True" CommandName="Insert"
                                ImageUrl="~/images/Admin/OK.png" ToolTip="Hoàn tất" />
                            &nbsp;<asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False"
                                CommandName="Cancel" ImageUrl="~/images/Admin/Back.png" ToolTip="Quay lại" />
                        </InsertItemTemplate>
                    </asp:TemplateField>
                </Fields>
            </asp:DetailsView>
            <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="BatDongSan.BDSDataContext"
                EnableDelete="True" TableName="Partners" Where="IsValid == @IsValid" 
                EnableInsert="True" onselecting="LinqDataSource1_Selecting">
                <WhereParameters>
                    <asp:ControlParameter ControlID="DropDownList1" Name="IsValid" PropertyName="SelectedValue"
                        Type="Boolean" />
                </WhereParameters>
            </asp:LinqDataSource>
            <asp:LinqDataSource ID="LinqDataSource2" runat="server" ContextTypeName="BatDongSan.BDSDataContext"
                TableName="Partners" EnableUpdate="True" EnableInsert="True">
            </asp:LinqDataSource>
        </div>
        <p class="bot">
            &nbsp;</p>
    </div>
</asp:Content>
