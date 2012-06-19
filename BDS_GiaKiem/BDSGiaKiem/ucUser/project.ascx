<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="project.ascx.cs" Inherits="BDSGiaKiem.ucUser.project" %>
<div id="article">
    <p class="title"><asp:Label ID="title" runat="server" Text="Danh sách dự án"></asp:Label></p>
    <div class="text">
        <ul class="lstPj">
            <asp:Repeater ID="Repeater1" runat="server" DataSourceID="LinqDataSource1">
            <ItemTemplate>
                <li>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("ID", "/default.aspx?section=project_detail&id={0}") %>'><%# Eval("Name") %></asp:HyperLink>
                    <div class="shortdesc"><%# Eval("Description") %></div>
                    </li>
            </ItemTemplate>
            </asp:Repeater>
            <asp:LinqDataSource ID="LinqDataSource1" runat="server" 
                ContextTypeName="BDSGiaKiem.BDSDataContext" Select="new (ID, Name, Description)" 
                TableName="Projects">
            </asp:LinqDataSource>
        </ul>
    </div>
</div>