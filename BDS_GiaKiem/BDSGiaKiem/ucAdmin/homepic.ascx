<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="homepic.ascx.cs" Inherits="BDSGiaKiem.ucAdmin.homepic" %>
<fieldset class="fset">
    <legend>Tải lên hình mới</legend>
    <asp:FileUpload ID="PicUpload" runat="server" />
    <p class="funcBox"><asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />
    <asp:Label ID="PicUploadMsg" runat="server" Text="" Visible="false"></asp:Label>
    </p>
</fieldset>
<fieldset class="fset">
    <legend>Hình ảnh có sẵn</legend>
    <div style="text-align:center;"><asp:Label ID="PicMsg" runat="server" Text="" Visible="false"></asp:Label></div>
    <asp:DataList ID="PicDataList" runat="server" DataKeyField="ID" 
        DataSourceID="LinqDataSource1" CssClass="tblData"
        RepeatColumns="4" RepeatDirection="Horizontal" ShowFooter="False" 
        ShowHeader="False" HorizontalAlign="Center" 
        onitemdatabound="PicDataList_ItemDataBound" 
        ondeletecommand="PicDataList_DeleteCommand">
        <ItemTemplate>
            <asp:Image ID="Image1" runat="server" ImageUrl='<%# getThumbnailURL(Eval("ImageUrl", "../{0}").ToString()) %>' />
            <br />
            Hiển thị:
            <asp:CheckBox ID="chkUsed" runat="server" Checked='<%# Eval("IsUsed") %>' 
                AutoPostBack="True" oncheckedchanged="CheckBox1_CheckedChanged" /><br />
            <asp:Button ID="btnDelete" runat="server" Text="Xóa" CommandName="delete" 
                onclientclick="return confirm('Xóa hình này?');" />
        </ItemTemplate>
        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
            Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
    </asp:DataList>
    <asp:LinqDataSource ID="LinqDataSource1" runat="server" 
        ContextTypeName="BDSGiaKiem.BDSDataContext" OrderBy="ID" TableName="HomePics">
    </asp:LinqDataSource>
</fieldset>
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