<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPageAdmin.master" CodeFile="addProduct.aspx.cs" Inherits="addProduct" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

 </asp:Content>


 <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderAdmin" Runat="Server">





     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:productNDBConnectionString %>" SelectCommand="SELECT * FROM [category]" OldValuesParameterFormatString="original_{0}"></asp:SqlDataSource>
    <table>
        <tr>
            <td><asp:Label ID="lblcat" runat="server" Text="Category Name"></asp:Label></td>
            <td><asp:DropDownList ID="DDlCat"  runat="server" DataSourceID="SqlDataSource1" DataTextField="category_name" DataValueField="category_id" AutoPostBack="True" >
  
            </asp:DropDownList></td>
            <td>     <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ErrorMessage="Must choose category" InitialValue="0" ForeColor="Red"  ControlToValidate="DDlCat"></asp:RequiredFieldValidator>
</td>

        </tr>
      
     
       <tr>
            <td>
                <asp:Label ID="LblProduct" runat="server" Text="Product Name"></asp:Label></td>
            <td> <asp:TextBox ID="ProductTB" required="required" ErrorMessage="Must Enter Product Name" runat="server" ></asp:TextBox></td>
        </tr> 

        <tr>

            <td>
                <asp:Label ID="lblpic" runat="server" Text="Upload Image"></asp:Label> </td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" /> </td>
            <td>
                <asp:Label ID="UploadStatusLabel" runat="server" ></asp:Label>
            </td>
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
                   <asp:ListItem >yes</asp:ListItem>
                   <asp:ListItem>no</asp:ListItem>
               </asp:RadioButtonList> </td>
        </tr>
    </table>
     <asp:Button ID="addBTN" runat="server" Text="ADD PRODUCT" OnClick="addBTN_Click" />


     <br />
     <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:productNDBConnectionString %>" SelectCommand="SELECT * FROM [productN]"></asp:SqlDataSource>
     <br />
     <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource2" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="product_id">
         <Columns>
             <asp:BoundField DataField="category_id" HeaderText="category_id" SortExpression="category_id" />
             <asp:BoundField DataField="title" HeaderText="title" SortExpression="title" />
             <asp:BoundField DataField="img_url" HeaderText="img_url" SortExpression="img_url" />
             <asp:BoundField DataField="price" HeaderText="price" SortExpression="price" />
             <asp:BoundField DataField="inventory" HeaderText="inventory" SortExpression="inventory" />
             <asp:CheckBoxField DataField="active" HeaderText="active" SortExpression="active" />
         </Columns>
     </asp:GridView>
     <br />


     </asp:Content>