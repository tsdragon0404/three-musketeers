<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="news.ascx.cs" Inherits="BDSGiaKiem.ucAdmin.news" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<fieldset class="fset">
<legend>Tin tức</legend>
        <asp:Button ID="btnAddNew" runat="server" onclick="btnAddNew_Click" 
            Text="Thêm mới" />
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ID" 
            DataSourceID="LinqDataSource1" onrowdeleted="GridView1_RowDeleted" 
            onrowdeleting="GridView1_RowDeleting" CssClass="tblProject"
            onselectedindexchanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" Visible="False" />
                <asp:BoundField DataField="Name" HeaderText="Dự án" SortExpression="Name" />
                <asp:BoundField DataField="Title" HeaderText="Tiêu đề" SortExpression="Title">
                    <ItemStyle Width="300px" />
                </asp:BoundField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                            CommandName="Select" Text="Chi tiết"></asp:LinkButton>
                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                            CommandName="Delete" Text="Xóa" OnClientClick="return confirm('Xóa tin tức này ?');"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:LinqDataSource ID="LinqDataSource1" runat="server" 
            onselecting="LinqDataSource1_Selecting">
        </asp:LinqDataSource>
        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" 
            DataKeyNames="ID" DataSourceID="LinqDataSource2"
            oniteminserted="DetailsView1_ItemInserted" 
            oniteminserting="DetailsView1_ItemInserting" 
            onitemupdated="DetailsView1_ItemUpdated" CssClass="tbl"
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
                <asp:TemplateField HeaderText="Tiêu đề">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="txtBox400"
                            Text='<%# Bind("Title") %>' TextMode="MultiLine"></asp:TextBox>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" CssClass="txtBox400"
                            Text='<%# Bind("Title") %>' TextMode="MultiLine"></asp:TextBox>
                    </InsertItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Nội dung chính">
                    <EditItemTemplate>
                        <CKEditor:CKEditorControl ID="editorContent" runat="server" 
                            Text='<%# Bind("ContentText") %>' TextMode="MultiLine" Width=""></CKEditor:CKEditorControl>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <CKEditor:CKEditorControl ID="editorContent" runat="server" 
                            Text='<%# Bind("ContentText") %>' TextMode="MultiLine" Width=""></CKEditor:CKEditorControl>
                    </InsertItemTemplate>
                </asp:TemplateField>
                <asp:CommandField CancelText="Hủy bỏ" InsertText="Thêm mới" 
                    ShowEditButton="True" ShowInsertButton="True" UpdateText="Lưu" />
            </Fields>
        </asp:DetailsView>
        <asp:LinqDataSource ID="LinqDataSource2" runat="server" 
            ContextTypeName="BDSGiaKiem.BDSDataContext" EnableInsert="True" 
            EnableUpdate="True" TableName="News" Where="ID == @ID">
            <WhereParameters>
                <asp:ControlParameter ControlID="GridView1" DefaultValue="0" Name="ID" 
                    PropertyName="SelectedValue" Type="Int64" />
            </WhereParameters>
        </asp:LinqDataSource>

</fieldset>