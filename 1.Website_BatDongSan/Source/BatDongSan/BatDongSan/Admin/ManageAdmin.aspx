<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="ManageAdmin.aspx.cs" Inherits="BatDongSan.Admin.ManageAdmin" Title="Quản lý Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <div class="top">
            <img class="icon" src="../images/templates/default/admin.png" />
            <p class="section_title">
                Quản lý admin</p>
        </div>
        <div class="mid">
            <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="~/images/Admin/Add.png" OnClick="btnAdd_Click"
                ToolTip="Thêm mới tài khoản" />
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="LinqDataSource3"
                 Width="100%">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="STT" InsertVisible="False" ReadOnly="True"
                        SortExpression="ID" Visible="False" />
                    <asp:BoundField DataField="UserName" HeaderText="UserName" ReadOnly="True" SortExpression="UserName" />
                    <asp:TemplateField HeaderText="Password" SortExpression="Password">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" TextMode="Password" Text='<%# Bind("Password") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="super" HeaderText="super" SortExpression="super" Visible="False" />
                    <asp:TemplateField ShowHeader="False">
                        <EditItemTemplate>
                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="True" CommandName="Update"
                                Text="Update" ImageUrl="~/images/Admin/OK.png" ToolTip="Hoàn tất" />
                            &nbsp;<asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False"
                                CommandName="Cancel" Text="Cancel" ImageUrl="~/images/Admin/Back.png" ToolTip="Quay lại" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton3" runat="server" CausesValidation="False" CommandName="Edit"
                                ImageUrl="~/images/Admin/Edit.png" Text="Edit" ToolTip="Đổi mật khẩu" />
                            <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                ImageUrl="~/images/Admin/Delete.png" Text="Delete" ToolTip="Xóa" 
                                OnClientClick="return confirm('Xóa quản trị viên này ?');" />
                        
                        </ItemTemplate>
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton3" runat="server" CausesValidation="False" CommandName="Edit"
                                ImageUrl="~/images/Admin/Edit.png" Text="Edit" ToolTip="Đổi mật khẩu" />
                            <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                ImageUrl="~/images/Admin/Delete.png" Text="Delete" ToolTip="Xóa" OnClientClick="return confirm('Xóa quản trị viên này ?');" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:LinqDataSource ID="LinqDataSource3" runat="server" ContextTypeName="BatDongSan.BDSDataContext"
                EnableDelete="True" TableName="Administrators" Where="super == @super" EnableUpdate="True">
                <WhereParameters>
                    <asp:Parameter DefaultValue="false" Name="super" Type="Boolean" />
                </WhereParameters>
            </asp:LinqDataSource>
            <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataKeyNames="ID"
                DataSourceID="LinqDataSource4" Height="50px" Width="125px" 
                OnItemInserted="DetailsView1_ItemInserted" 
                OnItemInserting="DetailsView1_ItemInserting" 
                onmodechanging="DetailsView1_ModeChanging1" Visible="False">
                <Fields>
                    <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True"
                        SortExpression="ID" Visible="False" />
                    <asp:BoundField DataField="UserName" HeaderText="UserName" 
                        SortExpression="UserName" />
                    <asp:TemplateField HeaderText="Password" SortExpression="Password">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Password") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:TextBox ID="TextBox1" TextMode="Password" runat="server" Text='<%# Bind("Password") %>'></asp:TextBox>
                        </InsertItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Password") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CheckBoxField DataField="Super" HeaderText="Super" SortExpression="Super" 
                        Visible="False" />
                    <asp:TemplateField ShowHeader="False">
                        <InsertItemTemplate>
                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="True" 
                                CommandName="Insert" ImageUrl="~/images/Admin/OK.png" Text="Insert" ToolTip="Hoàn tất" />
                            &nbsp;<asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False" 
                                CommandName="Cancel" ImageUrl="~/images/Admin/Back.png" Text="Cancel" ToolTip="Quay lại" />
                        </InsertItemTemplate>
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" 
                                CommandName="New" Text="New" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Fields>
            </asp:DetailsView>
            <asp:LinqDataSource ID="LinqDataSource4" runat="server" ContextTypeName="BatDongSan.BDSDataContext"
                EnableInsert="True" TableName="Administrators">
            </asp:LinqDataSource>
        </div>
        <p class="bot">
            &nbsp;</p>
    </div>
</asp:Content>
