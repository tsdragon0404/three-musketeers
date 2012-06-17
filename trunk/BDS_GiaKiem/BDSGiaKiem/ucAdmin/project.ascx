<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="project.ascx.cs" Inherits="BDSGiaKiem.ucAdmin.project" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<fieldset class="fset">
<legend>Danh sách các dự án</legend>
        <asp:Button ID="btnAddNew" runat="server" onclick="btnAddNew_Click" 
            Text="Thêm dự án" />
<asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" 
            AutoGenerateColumns="False" DataKeyNames="ID" 
            DataSourceID="LinqDataSource1" 
            onselectedindexchanged="GridView1_SelectedIndexChanged">
    <Columns>
        <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" 
            ReadOnly="True" SortExpression="ID" Visible="False" />
        <asp:BoundField DataField="Name" HeaderText="Dự án" SortExpression="Name" />
        <asp:BoundField DataField="Description" HeaderText="Mô tả" 
            SortExpression="Description" />
        <asp:BoundField DataField="ContentText" HeaderText="Chi tiết" 
            SortExpression="ContentText" Visible="False" />
        <asp:CommandField ShowDeleteButton="True" ShowSelectButton="True" 
            DeleteText="Xóa" SelectText="Sửa" />
    </Columns>
</asp:GridView>
        <asp:LinqDataSource ID="LinqDataSource1" runat="server" 
            ContextTypeName="BDSGiaKiem.BDSDataContext" EnableDelete="True" 
            EnableUpdate="True" OrderBy="Name" TableName="Projects">
        </asp:LinqDataSource>
        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" 
            DataKeyNames="ID" DataSourceID="LinqDataSource2" Height="50px" 
            Width="125px" oniteminserted="DetailsView1_ItemInserted" 
            onitemupdated="DetailsView1_ItemUpdated">
            <Fields>
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" 
                    ReadOnly="True" SortExpression="ID" />
                <asp:TemplateField HeaderText="Dự án">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Height="50px" 
                            Text='<%# Bind("Name") %>' TextMode="MultiLine"></asp:TextBox>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Height="50px" 
                            Text='<%# Bind("Name") %>' TextMode="MultiLine"></asp:TextBox>
                    </InsertItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Mô tả">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Height="50px" 
                            Text='<%# Bind("Description") %>' TextMode="MultiLine"></asp:TextBox>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Height="50px" 
                            Text='<%# Bind("Description") %>' TextMode="MultiLine"></asp:TextBox>
                    </InsertItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Chi tiết">
                    <EditItemTemplate>
                        <CKEditor:CKEditorControl ID="editorContent" runat="server" 
                            Text='<%# Bind("ContentText") %>' TextMode="MultiLine" Width="">
</CKEditor:CKEditorControl>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <CKEditor:CKEditorControl ID="editorContent" runat="server" 
                            Text='<%# Bind("ContentText") %>' TextMode="MultiLine" Width="">
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
