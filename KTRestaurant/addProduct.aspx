<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPageAdmin.master" CodeFile="addProduct.aspx.cs" Inherits="addProduct" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

 </asp:Content>


 <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderAdmin" Runat="Server">





     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:productNDBConnectionString %>" SelectCommand="SELECT * FROM [category]"></asp:SqlDataSource>
     <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="category_name" DataValueField="category_name">
     </asp:DropDownList>





     </asp:Content>