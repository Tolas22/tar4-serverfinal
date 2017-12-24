<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/MasterPageAdmin.master" CodeFile="inventoryManagement.aspx.cs" Inherits="inventoryManagement" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

 </asp:Content>


 <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderAdmin" Runat="Server">
     
     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:productNDBConnectionString %>" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [AddProduct]">
     </asp:SqlDataSource>
     <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
         <Columns>
             <asp:BoundField DataField="title" HeaderText="title" SortExpression="title" />
             <asp:BoundField DataField="category_name" HeaderText="category_name" SortExpression="category_name" />
             <asp:ImageField DataImageUrlField="img_url" HeaderText="Picture">
             </asp:ImageField>
             <asp:BoundField DataField="price" HeaderText="price" SortExpression="price" />
             <asp:BoundField DataField="inventory" HeaderText="inventory" SortExpression="inventory" />
             <asp:CheckBoxField DataField="active" HeaderText="active" SortExpression="active" />
         </Columns>
     </asp:GridView>
     
     </asp:Content>


