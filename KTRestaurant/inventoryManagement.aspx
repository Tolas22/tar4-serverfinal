﻿<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/MasterPageAdmin.master" CodeFile="inventoryManagement.aspx.cs" Inherits="inventoryManagement" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

 </asp:Content>


 <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderAdmin" Runat="Server">
     
     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:productNDBConnectionString %>" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [AddProduct]">
     </asp:SqlDataSource>
<<<<<<< HEAD
     <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"  AutoGenerateColumns="false" DataSourceID="SqlDataSource1">
         <Columns>
             <asp:BoundField DataField="title" HeaderText="title" SortExpression="title" />
             <asp:BoundField DataField="category_name" HeaderText="category_name" SortExpression="category_name" />
             <asp:ImageField DataImageUrlField="img_url" HeaderText="Picture">
             </asp:ImageField>
=======
>>>>>>> 7d82e00de049bf8d5ecde51f3d0a6f2943017ce7
             <asp:BoundField DataField="price" HeaderText="price" SortExpression="price" />
             <asp:BoundField DataField="inventory" HeaderText="inventory" SortExpression="inventory" />
             <asp:CheckBoxField DataField="active" HeaderText="active" SortExpression="active" />
         </Columns>
     </asp:GridView>
     
     </asp:Content>


