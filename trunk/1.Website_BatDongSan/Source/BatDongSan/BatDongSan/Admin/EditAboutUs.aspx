<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="EditAboutUs.aspx.cs" Inherits="BatDongSan.Admin.EditAboutUs" Title="Chỉnh sửa nội dung trang giới thiệu" %>

<%@ Register Assembly="obout_Editor" Namespace="OboutInc.Editor" TagPrefix="obout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <div class="top">
            <img class="icon" src="../images/templates/aboutus.png" />
            <p class="section_title">
                Thay đổi nội dung trang giới thiệu</p>
        </div>
        <div class="mid">
            <asp:DetailsView ID="DetailsView1" CssClass="tbl" runat="server" 
                AutoGenerateRows="False" DataKeyNames="ID"
                DataSourceID="LinqDataSource3" DefaultMode="Edit" Width="695px" 
                GridLines="None">
                <Fields>
                    <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True"
                        SortExpression="ID" Visible="False" />
                    <asp:BoundField DataField="PageName" HeaderText="PageName" SortExpression="PageName"
                        Visible="False" />
                    <asp:TemplateField HeaderText="Contents" ShowHeader="False" SortExpression="Contents">
                        <EditItemTemplate>
                            <obout:Editor ID="editorNoidung" runat="server" Content='<%# Bind("Contents") %>'
                                PathPrefix="Editor_data/" PreviewMode="True" ShowQuickFormat="False">
                                <Buttons>
                                    <obout:HorizontalSeparator />
                                    <obout:Custom ImageName="ed_upload_image_n.gif" OnClientClick="myImageUpload" ToolTip="Upload image" />
                                </Buttons>
                            </obout:Editor>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="True" Visible="False" />
                </Fields>
            </asp:DetailsView>
            <asp:LinqDataSource ID="LinqDataSource3" runat="server" ContextTypeName="BatDongSan.BDSDataContext"
                EnableUpdate="True" TableName="OtherPages" Where="PageName == @PageName">
                <WhereParameters>
                    <asp:Parameter DefaultValue="AboutUs" Name="PageName" Type="String" />
                </WhereParameters>
            </asp:LinqDataSource>
        </div>
        <p class="bot">
            &nbsp;</p>
    </div>
</asp:Content>
