<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="ManageSupporter.aspx.cs" Inherits="BatDongSan.Admin.ManageSupporter"
    Title="Quản lý người hỗ trợ trực tuyến" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <div class="top">
            <img class="icon" src="../images/templates/default/sidebar/icon_5.png" />
            <p class="section_title">
                Quản lý người hỗ trợ trực tuyến</p>
        </div>
        <div class="mid">
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
                <asp:ListItem Value="True">Sử dụng</asp:ListItem>
                <asp:ListItem Value="False">Không sử dụng</asp:ListItem>
            </asp:DropDownList>
            <asp:ImageButton ID="ImageButton3" runat="server" CssClass="add" ImageUrl="~/images/Admin/Add.png"
                OnClick="ImageButton3_Click" ToolTip="Thêm mới" />
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                DataKeyNames="ID" DataSourceID="LinqDataSource1" AllowSorting="True" Width="100%"
                OnRowUpdated="GridView1_RowUpdated" OnRowDeleting="GridView1_RowDeleting" 
                OnRowUpdating="GridView1_RowUpdating">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True"
                        SortExpression="ID" Visible="False" />
                    <asp:BoundField DataField="Name" HeaderText="Tên" SortExpression="Name" />
                    <asp:BoundField DataField="Phone" HeaderText="Điện thoại" SortExpression="Phone" />
                    <asp:BoundField DataField="Yahoo" HeaderText="Yahoo" SortExpression="Yahoo" />
                    <asp:TemplateField HeaderText="Hiển thị" SortExpression="IsValid">
                        <EditItemTemplate>
                            <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("IsValid") %>' />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("IsValid") %>' Enabled="false" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <EditItemTemplate>
                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="True" CommandName="Update"
                                ImageUrl="~/images/Admin/OK.png" Text="Update" ToolTip="Hoàn tất" />
                            &nbsp;<asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False"
                                CommandName="Cancel" ImageUrl="~/images/Admin/Back.png" Text="Cancel" ToolTip="Quay lại" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                ImageUrl="~/images/Admin/Edit.png" Text="Edit" ToolTip="Chỉnh sửa" />
                            &nbsp;<asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False"
                                CommandName="Delete" ImageUrl="~/images/Admin/Delete.png" Text="Delete" ToolTip="Xóa"
                                OnClientClick="return confirm('Xóa dữ liệu này ?');" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataSourceID="LinqDataSource2"
                Visible="False" DataKeyNames="ID" OnModeChanging="DetailsView1_ModeChanging"
                OnItemInserted="DetailsView1_ItemInserted">
                <Fields>
                    <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True"
                        SortExpression="ID" Visible="False" />
                    <asp:BoundField DataField="Name" HeaderText="Tên" SortExpression="Name" />
                    <asp:BoundField DataField="Phone" HeaderText="Điện thoại" SortExpression="Phone" />
                    <asp:BoundField DataField="Yahoo" HeaderText="Yahoo" SortExpression="Yahoo" />
                    <asp:CheckBoxField DataField="IsValid" HeaderText="Hiển thị" SortExpression="IsValid" />
                    <asp:TemplateField ShowHeader="False">
                        <InsertItemTemplate>
                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="True" CommandName="Insert"
                                ImageUrl="~/images/Admin/OK.png" Text="Insert" ToolTip="Hoàn tất" />
                            &nbsp;<asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False"
                                CommandName="Cancel" ImageUrl="~/images/Admin/Back.png" Text="Cancel" ToolTip="Quay lại" />
                        </InsertItemTemplate>
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="New"
                                Text="New" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Fields>
            </asp:DetailsView>
            <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="BatDongSan.BDSDataContext"
                EnableDelete="True" TableName="Supporters" Where="IsValid == @IsValid" EnableInsert="True"
                EnableUpdate="True">
                <WhereParameters>
                    <asp:ControlParameter ControlID="DropDownList1" Name="IsValid" PropertyName="SelectedValue"
                        Type="Boolean" />
                </WhereParameters>
            </asp:LinqDataSource>
            <asp:LinqDataSource ID="LinqDataSource2" runat="server" ContextTypeName="BatDongSan.BDSDataContext"
                TableName="Supporters" Where="ID == @ID" EnableUpdate="True" EnableInsert="True">
                <WhereParameters>
                    <asp:QueryStringParameter DefaultValue="1" Name="ID" QueryStringField="stt" Type="Int64" />
                </WhereParameters>
            </asp:LinqDataSource>
        </div>
        <p class="bot">
            &nbsp;</p>
    </div>
</asp:Content>
