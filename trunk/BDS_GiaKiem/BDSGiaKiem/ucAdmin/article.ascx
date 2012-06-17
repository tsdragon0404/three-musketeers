<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="article.ascx.cs" Inherits="BDSGiaKiem.ucAdmin.article" %>
<fieldset class="fset">
    <legend>Danh sách bài viết</legend>
    <p>
        Thêm bài viết mới, nhấn vào <a href="?section=article_detail">đây</a></p>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
        DataSourceID="LinqDataSource1" CssClass="tblArticleList">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="Mã" ReadOnly="True" 
                SortExpression="ID" >
                <ItemStyle Width="10%" />
            </asp:BoundField>
            <asp:BoundField DataField="Title" HeaderText="Tiêu đề" SortExpression="Title" >
                <ItemStyle Width="70%" />
            </asp:BoundField>
            <asp:BoundField DataField="ContentText" SortExpression="ContentText" Visible="False" />
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("ID", "../Admin.aspx?section=article_detail&id={0}") %>'
                        Text="Chi tiết"></asp:HyperLink>
                    &nbsp;<asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                        Text="Xóa" OnClientClick="return confirm('Xóa bài viết này?');"></asp:LinkButton>
                </ItemTemplate>
                <ItemStyle Width="20%" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="BDSGiaKiem.BDSDataContext"
        EnableDelete="True" TableName="Articles">
    </asp:LinqDataSource>
</fieldset>
