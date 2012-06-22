<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="project.ascx.cs" Inherits="BDSGiaKiem.ucAdmin.project" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<fieldset class="fset">
<legend id="lblStatus" runat="server">Danh sách các dự án</legend>
        <asp:Button ID="btnAddNew" runat="server" onclick="btnAddNew_Click" 
            Text="Thêm dự án" />
    <p class="funcBox" id="func" runat="server"><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="/admin.aspx?section=planning">Quản lý quy hoạch</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="/admin.aspx?section=area">Quản lý khu vực</asp:HyperLink></p>
<asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" DataKeyNames="ID" 
            DataSourceID="LinqDataSource1" Cssclass="tblProject"
            onselectedindexchanged="GridView1_SelectedIndexChanged">
    <Columns>
        <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" 
            ReadOnly="True" SortExpression="ID" Visible="False" />
        <asp:BoundField DataField="Name" HeaderText="Dự án" SortExpression="Name" />
        <asp:BoundField DataField="Description" HeaderText="Mô tả" 
            SortExpression="Description" />
        <asp:BoundField DataField="ContentText" HeaderText="Chi tiết" 
            SortExpression="ContentText" Visible="False" />
        <asp:TemplateField ShowHeader="False">
            <ItemTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                    CommandName="Select" Text="Chi tiết"></asp:LinkButton>
                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                    CommandName="Delete" Text="Xóa" OnClientClick="return confirm('Xóa dự án này ?');"></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
        <asp:LinqDataSource ID="LinqDataSource1" runat="server" 
            ContextTypeName="BDSGiaKiem.BDSDataContext" EnableDelete="True" 
            EnableUpdate="True" OrderBy="Name" TableName="Projects">
        </asp:LinqDataSource>
        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" 
            DataKeyNames="ID" DataSourceID="LinqDataSource2"
            oniteminserted="DetailsView1_ItemInserted" CssClass="tbl" 
            onitemupdated="DetailsView1_ItemUpdated">
            <Fields>
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" 
                    ReadOnly="True" SortExpression="ID" Visible="False" />
                <asp:TemplateField HeaderText="Tên dự án">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server"
                            Text='<%# Bind("Name") %>' Cssclass="txtBox400"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="TextBox1" ErrorMessage="* Chưa nhập tên dự án"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server"
                            Text='<%# Bind("Name") %>' Cssclass="txtBox400"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="TextBox2" ErrorMessage="* Chưa nhập tên dự án"></asp:RequiredFieldValidator>
                    </InsertItemTemplate>
                    <HeaderStyle ForeColor="Red" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Mô tả">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Height="50px" 
                            Text='<%# Bind("Description") %>' TextMode="MultiLine" Cssclass="txtBox400"></asp:TextBox>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Height="50px" 
                            Text='<%# Bind("Description") %>' TextMode="MultiLine" Cssclass="txtBox400"></asp:TextBox>
                    </InsertItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Chi tiết">
                    <EditItemTemplate>
                        <CKEditor:CKEditorControl ID="editorContent" runat="server" 
                            Text='<%# Bind("ContentText") %>' TextMode="MultiLine" Width="">
                            
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                            
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</CKEditor:CKEditorControl>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <CKEditor:CKEditorControl ID="editorContent" runat="server" 
                            Text='<%# Bind("ContentText") %>' TextMode="MultiLine" Width="">
                            
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                            
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</CKEditor:CKEditorControl>
                    </InsertItemTemplate>
                </asp:TemplateField>
                <asp:CommandField CancelText="Hủy bỏ" EditText="Sửa" InsertText="Thêm mới" 
                    ShowEditButton="True" ShowInsertButton="True" UpdateText="Lưu" />
            </Fields>
        </asp:DetailsView>
        <asp:LinqDataSource ID="LinqDataSource2" runat="server" 
            ContextTypeName="BDSGiaKiem.BDSDataContext" EnableInsert="True" 
            EnableUpdate="True" TableName="Projects" Where="ID == @ID">
            <WhereParameters>
                <asp:ControlParameter ControlID="GridView1" DefaultValue="0" Name="ID" 
                    PropertyName="SelectedValue" Type="Int64" />
            </WhereParameters>
        </asp:LinqDataSource>
</fieldset>
