<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPageAdmin.master" CodeFile="addCategory.aspx.cs" Inherits="addCategory" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

 </asp:Content>


 <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderAdmin" Runat="Server">
     <h2>Add Category</h2>
     <p>
         <asp:Label ID="cnameLBL" runat="server" Text="Category name:"></asp:Label>
         <asp:TextBox ID="cnameTB" runat="server" ></asp:TextBox>
         <asp:RequiredFieldValidator ID="cnameVLD" runat="server" ControlToValidate="cnameTB" ErrorMessage="Must Enter Category Name" ></asp:RequiredFieldValidator>
     </p>
     <p>
         <asp:Button ID="addctgBTN" runat="server" Text="Add" OnClick="addctgBTN_Click" />
     </p>
     
     </asp:Content>
