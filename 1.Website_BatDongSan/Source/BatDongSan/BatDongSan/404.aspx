<%@ Page Language="C#" MasterPageFile="~/Client.Master" AutoEventWireup="true" CodeBehind="404.aspx.cs" Inherits="BatDongSan._04" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Refresh" content="3;URL=Default.aspx"/>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="content">
        <div class="top">
            <img class="icon" src="images/templates/default/top_news/icon.png" />
            <p class="section_title">
                Tin tức</p>
        </div>
        <div class="mid">
    <p>
        Không tìm thấy trang bạn yêu cầu.</p>
    <p>
        Đang tự động quay về trang chủ, nếu bạn thấy lâu, vui lòng bấm vào đây
        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Default.aspx" 
            Font-Overline="False" Font-Underline="True" ForeColor="#0066FF">Quay về trang chủ</asp:HyperLink>
    </p>
    <p>
        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/wait_animated.gif" />
    </p>
    </div>
        </div>
        <p class="bot">
            &nbsp;</p>
    </div>
</asp:Content>
