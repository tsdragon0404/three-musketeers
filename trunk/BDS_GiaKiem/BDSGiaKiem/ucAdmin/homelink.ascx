<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="homelink.ascx.cs" Inherits="BDSGiaKiem.ucAdmin.homelink" %>
<fieldset class="fset">
    <legend>Liên kết của hình ảnh trên trang chủ</legend>
    <p>
    Liên kết hiện tại: <asp:TextBox ID="txtPicLink" runat="server" CssClass="txtBox400"></asp:TextBox> 
        <asp:HyperLink ID="HLPic" runat="server" Target="_blank">Xem</asp:HyperLink></p>
    <p class="funcBox"><asp:Button ID="btnSavePicLink" runat="server" Text="Save" 
            onclick="btnSavePicLink_Click" />
    <asp:Label ID="PicLinkMsg" runat="server" Text="" Visible="false"></asp:Label>
    </p>
</fieldset>
<fieldset class="fset">
    <legend>Liên kết chi tiết quy hoạch</legend>
    <p>
    Liên kết hiện tại: <asp:TextBox ID="txtPlanningLink" runat="server" CssClass="txtBox400"></asp:TextBox> 
        <asp:HyperLink ID="HLPlanning" runat="server" Target="_blank">Xem</asp:HyperLink></p>
    <p class="funcBox"><asp:Button ID="btnSavePlanningLink" runat="server" Text="Save" 
            onclick="btnSavePlanningLink_Click" />
    <asp:Label ID="PlanningLinkMsg" runat="server" Text="" Visible="false"></asp:Label>
    </p>
</fieldset>
<fieldset class="fset">
    <legend>Liên kết khu vực</legend>
    <p>
    Liên kết hiện tại: <asp:TextBox ID="txtAreaLink" runat="server" CssClass="txtBox400"></asp:TextBox> 
        <asp:HyperLink ID="HLArea" runat="server" Target="_blank">Xem</asp:HyperLink></p>
    <p class="funcBox"><asp:Button ID="btnSaveAreaLink" runat="server" Text="Save" 
            onclick="btnSaveAreaLink_Click" />
    <asp:Label ID="AreaLinkMsg" runat="server" Text="" Visible="false"></asp:Label>
    </p>
</fieldset>