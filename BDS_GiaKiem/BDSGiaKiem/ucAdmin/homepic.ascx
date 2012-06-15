<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="homepic.ascx.cs" Inherits="BDSGiaKiem.ucAdmin.homepic" %>
<fieldset>
    <legend>Upload new image</legend>
    <asp:FileUpload ID="PicUpload" runat="server" />
    <asp:Button ID="Button1" runat="server" Text="Upload" />
    <asp:Label ID="PicUploadError" runat="server"
        Text="Error"></asp:Label>
</fieldset>
<fieldset>
    <legend>Available images</legend>
    <asp:DataList ID="PicDataList" runat="server" DataKeyField="ID" 
        DataSourceID="LinqDataSource1" RepeatColumns="4" RepeatDirection="Horizontal" 
        ShowFooter="False" ShowHeader="False">
        <ItemTemplate>
            <asp:Image ID="Image1" runat="server" />
            <asp:Label ID="ImageUrlLabel" runat="server" Text='<%# Eval("ImageUrl") %>' />
            <br />
            IsUsed:
            <asp:Label ID="IsUsedLabel" runat="server" Text='<%# Eval("IsUsed") %>' />
            <br />
            <br />
        </ItemTemplate>
    </asp:DataList>
    <asp:LinqDataSource ID="LinqDataSource1" runat="server" 
        ContextTypeName="BDSGiaKiem.BDSDataContext" EnableDelete="True" 
        EnableInsert="True" EnableUpdate="True" OrderBy="ID" TableName="HomePics">
    </asp:LinqDataSource>
</fieldset>