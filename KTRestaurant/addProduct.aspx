<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPageAdmin.master" CodeFile="addProduct.aspx.cs" Inherits="addProduct" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

 </asp:Content>


 <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderAdmin" Runat="Server">





     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:productNDBConnectionString %>" SelectCommand="SELECT * FROM [category]"></asp:SqlDataSource>
    <table>
        <tr>
            <td><asp:Label ID="lblcat" runat="server" Text="Category Name"></asp:Label></td>
            <td><asp:DropDownList ID="DDlCat"  runat="server" DataSourceID="SqlDataSource1" DataTextField="category_name" DataValueField="category_name" AutoPostBack="True" >
                <asp:ListItem Value="-1">Choose Category Name</asp:ListItem>
  
            </asp:DropDownList></td>
        </tr>
      
     
       <tr>
            <td>
                <asp:Label ID="LblProduct" runat="server" Text="Product Name"></asp:Label></td>
            <td> <asp:TextBox ID="ProductTB" runat="server"></asp:TextBox></td>
        </tr> 

        <tr>

            <td>
                <asp:Label ID="lblpic" runat="server" Text="Upload Image"></asp:Label> </td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" /> </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="LblPrice" runat="server" Text="Product Price"></asp:Label></td>
            <td>
                <asp:TextBox ID="PriceTB" runat="server"></asp:TextBox></td>
        </tr>

        <tr>
          <td>
                <asp:Label ID="Lblin" runat="server" Text="Product Inventory"></asp:Label></td>
            <td>
                <asp:TextBox ID="inventoryTB" runat="server"></asp:TextBox></td>
        </tr>

        <tr>
         <td>   <asp:Label ID="blActive" runat="server" Text="Active?"></asp:Label></td>
           <td>
               <asp:RadioButtonList ID="ActiveRBL" runat="server">
                   <asp:ListItem>yes</asp:ListItem>
                   <asp:ListItem>no</asp:ListItem>
               </asp:RadioButtonList> </td>
        </tr>
    </table>
     <asp:Button ID="addBTN" runat="server" Text="ADD PRODUCT" />


     <br />
     <br />
     <br />


     </asp:Content>