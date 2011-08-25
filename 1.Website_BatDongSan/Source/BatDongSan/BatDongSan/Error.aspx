<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="BatDongSan.Error" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <meta http-equiv="Refresh" content="5;URL=Default.aspx"/>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Xảy ra lỗi trong quá trình xử lý. Vui lòng thử lại sau.<br />
        Đang tự động chuyển về trang chủ, nếu bạn thấy quá lâu xin vui lòng bấm vào đây
        <asp:HyperLink ID="HyperLink1" runat="server" Font-Underline="True" 
            ForeColor="#0066FF" NavigateUrl="~/Default.aspx">Quay về trang chủ</asp:HyperLink>
        <br />
        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/wait_animated.gif" />
    
    </div>
    </form>
</body>
</html>
