<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="planning.ascx.cs" Inherits="BDSGiaKiem.ucUser.planning" %>
<div id="pictures">
    <p class="title">Chi tiết quy hoạch dự án<asp:HyperLink ID="HyperLink1" runat="server" CssClass="link">Quay lại trang dự án</asp:HyperLink></p>
    <p class="func"></p>
    <div class="prev">
        <a href="javascript:void(0)">
            <img src="../images/prev.jpg" title='Previous' alt="prev" /></a>
    </div>
    <div class="pic">
        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="LinqDataSource1">
            <ItemTemplate>
                <div class="zoomArea">
                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("ImageUrl", "/{0}") %>'
                        AlternateText='<%# Eval("Description") %>' CssClass='zoompic' /></div>
            </ItemTemplate>
        </asp:Repeater>
        <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="BDSGiaKiem.BDSDataContext"
            TableName="Plannings" Where="ProjectID == @ProjectID">
            <WhereParameters>
                <asp:QueryStringParameter DefaultValue="0" Name="ProjectID" QueryStringField="pid"
                    Type="Int64" />
            </WhereParameters>
        </asp:LinqDataSource>
    </div>
    <div class="next">
        <a href="javascript:void(0)">
            <img src="../images/next.jpg" title='Next' alt="next" /></a>
    </div>
    <div class="clear"></div>
</div>
