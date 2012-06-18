<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="area.ascx.cs" Inherits="BDSGiaKiem.ucAdmin.area" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<fieldset class="fset">
<legend>Danh sách các khu vực</legend>
    <p class="funcBox">
        <asp:Button ID="btnAddNew" runat="server" onclick="btnAddNew_Click" 
            Text="Thêm mới" /></p>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ID" 
            DataSourceID="LinqDataSource1" onrowdeleted="GridView1_RowDeleted" 
            onrowdeleting="GridView1_RowDeleting" 
            onselectedindexchanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" Visible="False" />
                <asp:BoundField DataField="Name" HeaderText="Dự án" SortExpression="Name" />
                <asp:BoundField DataField="ImageUrl" Visible="False" />
                <asp:TemplateField HeaderText="Hình ảnh">
                    <ItemTemplate>
                        <asp:Image ID="Image2" runat="server" Height="50px" ImageAlign="Middle" 
                            ImageUrl='<%# Eval("ImageUrl", "../{0}") %>' Width="50px" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Description" HeaderText="Mô tả" />
                <asp:CommandField ShowSelectButton="True" />
                <asp:ButtonField CommandName="Delete" Text="Xóa" />
            </Columns>
        </asp:GridView>
        <asp:LinqDataSource ID="LinqDataSource1" runat="server" 
            onselecting="LinqDataSource1_Selecting" ContextTypeName="" TableName="">
            <DeleteParameters>
                <asp:ControlParameter ControlID="GridView1" Name="newparameter" 
                    PropertyName="SelectedValue" />
            </DeleteParameters>
        </asp:LinqDataSource>
        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" 
            DataKeyNames="ID" DataSourceID="LinqDataSource2"
            oniteminserted="DetailsView1_ItemInserted" 
            oniteminserting="DetailsView1_ItemInserting" 
            onitemupdated="DetailsView1_ItemUpdated" 
            onitemupdating="DetailsView1_ItemUpdating">
            <Fields>
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" 
                    ReadOnly="True" SortExpression="ID" Visible="False" />
                <asp:TemplateField HeaderText="Dự án">
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownList1" runat="server" 
                            DataSourceID="LinqDataSource3" DataTextField="Name" DataValueField="ID" 
                            SelectedValue='<%# Bind("ProjectID") %>'>
                        </asp:DropDownList>
                        <asp:LinqDataSource ID="LinqDataSource3" runat="server" 
                            ContextTypeName="BDSGiaKiem.BDSDataContext" OrderBy="Name" 
                            Select="new (ID, Name)" TableName="Projects">
                        </asp:LinqDataSource>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:DropDownList ID="DropDownList2" runat="server" 
                            DataSourceID="LinqDataSource4" DataTextField="Name" DataValueField="ID" 
                            SelectedValue='<%# Bind("ProjectID") %>'>
                        </asp:DropDownList>
                        <asp:LinqDataSource ID="LinqDataSource4" runat="server" 
                            ContextTypeName="BDSGiaKiem.BDSDataContext" OrderBy="Name" 
                            Select="new (ID, Name)" TableName="Projects">
                        </asp:LinqDataSource>
                    </InsertItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Hình ảnh">
                    <EditItemTemplate>
                        <asp:Image ID="Image1" runat="server" 
                            ImageUrl='<%# Eval("ImageUrl", "../{0}") %>' Height="40px" Width="40px" />
                        <br />
                        <asp:FileUpload ID="FileUpload1B" runat="server" />
                        <br />
                        <asp:Label ID="Label1" runat="server" Font-Italic="True" Font-Size="9pt" 
                            ForeColor="#FF3300" Text="* Dung lượng không vượt quá 4MB"></asp:Label>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:FileUpload ID="FileUpload1B" runat="server" />
                        <br />
                        <asp:Label ID="Label1" runat="server" Font-Size="9pt" ForeColor="#FF3300" 
                            Text="* Dung lượng không vượt quá 4MB"></asp:Label>
                    </InsertItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Mô tả">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Height="50px" 
                            Text='<%# Bind("Description") %>' TextMode="MultiLine"></asp:TextBox>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Height="50px" 
                            Text='<%# Bind("Description") %>' TextMode="MultiLine"></asp:TextBox>
                    </InsertItemTemplate>
                </asp:TemplateField>
                <asp:CommandField CancelText="Hủy bỏ" EditText="Sửa" InsertText="Thêm mới" 
                    ShowEditButton="True" ShowInsertButton="True" UpdateText="Lưu" />
            </Fields>
        </asp:DetailsView>
        <asp:LinqDataSource ID="LinqDataSource2" runat="server" 
            ContextTypeName="BDSGiaKiem.BDSDataContext" EnableInsert="True" 
            EnableUpdate="True" TableName="Areas" Where="ID == @ID">
            <WhereParameters>
                <asp:ControlParameter ControlID="GridView1" DefaultValue="0" Name="ID" 
                    PropertyName="SelectedValue" Type="Int64" />
            </WhereParameters>
        </asp:LinqDataSource>

</fieldset>