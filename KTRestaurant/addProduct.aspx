<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPageAdmin.master" CodeFile="addProduct.aspx.cs" Inherits="addProduct" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     
 </asp:Content>


 <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderAdmin" Runat="Server">


     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:productNDBConnectionString %>" SelectCommand="SELECT * FROM [category]" OldValuesParameterFormatString="original_{0}"></asp:SqlDataSource>
    <table>
        <tr>
            <td><asp:Label ID="lblcat" runat="server" Text="Category Name"></asp:Label></td>
            <td><asp:DropDownList ID="DDlCat"  runat="server" DataSourceID="SqlDataSource1" DataTextField="category_name" DataValueField="category_id" AutoPostBack="True" >
                <asp:ListItem Selected="True" Value="0">Choose category</asp:ListItem>
  
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
    <td><asp:RequiredFieldValidator 
             ID="RequiredFieldValidator"
             runat="server"
             ControlToValidate="FileUpload1"
             ErrorMessage="Choose a file!"
        forecolor="Red"
             >
        </asp:RequiredFieldValidator>    </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="LblPrice" runat="server" Text="Product Price"></asp:Label></td>
            <td>
                <asp:TextBox ID="PriceTB" required="required" runat="server"></asp:TextBox></td>
        </tr>

        <tr>
          <td>
                <asp:Label ID="Lblin" runat="server" Text="Product Inventory"></asp:Label></td>
            <td>
                <asp:TextBox ID="inventoryTB" required="required" runat="server"></asp:TextBox></td>
        </tr>

        <tr>
         <td>   <asp:Label ID="blActive" runat="server" Text="Active?"></asp:Label></td>
           <td>
               <asp:RadioButtonList ID="ActiveRBL" runat="server">
                   <asp:ListItem >yes</asp:ListItem>
                   <asp:ListItem>no</asp:ListItem>
               </asp:RadioButtonList> </td>
            <td> <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
            ControlToValidate="ActiveRBL" ErrorMessage="Must choose one" ForeColor="Red">
        </asp:RequiredFieldValidator></td>
        </tr>
    </table>
     <asp:Button ID="addBTN" runat="server" Text="ADD PRODUCT" OnClick="addBTN_Click" />


     <br />
     <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:productNDBConnectionString %>" SelectCommand="SELECT * FROM [productN]" OldValuesParameterFormatString="original_{0}" ConflictDetection="CompareAllValues" DeleteCommand="DELETE FROM [productN] WHERE [product_id] = @original_product_id AND (([category_id] = @original_category_id) OR ([category_id] IS NULL AND @original_category_id IS NULL)) AND (([title] = @original_title) OR ([title] IS NULL AND @original_title IS NULL)) AND (([img_url] = @original_img_url) OR ([img_url] IS NULL AND @original_img_url IS NULL)) AND (([price] = @original_price) OR ([price] IS NULL AND @original_price IS NULL)) AND (([inventory] = @original_inventory) OR ([inventory] IS NULL AND @original_inventory IS NULL)) AND (([active] = @original_active) OR ([active] IS NULL AND @original_active IS NULL))" InsertCommand="INSERT INTO [productN] ([category_id], [title], [img_url], [price], [inventory], [active]) VALUES (@category_id, @title, @img_url, @price, @inventory, @active)" UpdateCommand="UPDATE [productN] SET [category_id] = @category_id, [title] = @title, [img_url] = @img_url, [price] = @price, [inventory] = @inventory, [active] = @active WHERE [product_id] = @original_product_id AND (([category_id] = @original_category_id) OR ([category_id] IS NULL AND @original_category_id IS NULL)) AND (([title] = @original_title) OR ([title] IS NULL AND @original_title IS NULL)) AND (([img_url] = @original_img_url) OR ([img_url] IS NULL AND @original_img_url IS NULL)) AND (([price] = @original_price) OR ([price] IS NULL AND @original_price IS NULL)) AND (([inventory] = @original_inventory) OR ([inventory] IS NULL AND @original_inventory IS NULL)) AND (([active] = @original_active) OR ([active] IS NULL AND @original_active IS NULL))">
         <DeleteParameters>
             <asp:Parameter Name="original_product_id" Type="Int32" />
             <asp:Parameter Name="original_category_id" Type="Int32" />
             <asp:Parameter Name="original_title" Type="String" />
             <asp:Parameter Name="original_img_url" Type="String" />
             <asp:Parameter Name="original_price" Type="Double" />
             <asp:Parameter Name="original_inventory" Type="Int32" />
             <asp:Parameter Name="original_active" Type="Boolean" />
         </DeleteParameters>
         <InsertParameters>
             <asp:Parameter Name="category_id" Type="Int32" />
             <asp:Parameter Name="title" Type="String" />
             <asp:Parameter Name="img_url" Type="String" />
             <asp:Parameter Name="price" Type="Double" />
             <asp:Parameter Name="inventory" Type="Int32" />
             <asp:Parameter Name="active" Type="Boolean" />
         </InsertParameters>
         <UpdateParameters>
             <asp:Parameter Name="category_id" Type="Int32" />
             <asp:Parameter Name="title" Type="String" />
             <asp:Parameter Name="img_url" Type="String" />
             <asp:Parameter Name="price" Type="Double" />
             <asp:Parameter Name="inventory" Type="Int32" />
             <asp:Parameter Name="active" Type="Boolean" />
             <asp:Parameter Name="original_product_id" Type="Int32" />
             <asp:Parameter Name="original_category_id" Type="Int32" />
             <asp:Parameter Name="original_title" Type="String" />
             <asp:Parameter Name="original_img_url" Type="String" />
             <asp:Parameter Name="original_price" Type="Double" />
             <asp:Parameter Name="original_inventory" Type="Int32" />
             <asp:Parameter Name="original_active" Type="Boolean" />
         </UpdateParameters>
     </asp:SqlDataSource>
     <br />
     <asp:GridView ID="GridView1" runat="server" OnRowDataBound="GridView1_RowDataBound" DataSourceID="SqlDataSource2" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="product_id">
         <Columns>
             
             <asp:CommandField ShowEditButton="True" />
             
             <asp:BoundField DataField="product_id" HeaderText="product_id" SortExpression="product_id" InsertVisible="False" ReadOnly="True" />
             <asp:BoundField DataField="category_id" HeaderText="category_id" SortExpression="category_id" ReadOnly="True" />
             <asp:BoundField DataField="title" HeaderText="title" SortExpression="title" ReadOnly="True" />
             <asp:BoundField DataField="price" HeaderText="price" SortExpression="price" ReadOnly="True" />
             <asp:ImageField DataImageUrlField="img_url" HeaderText="Image" ReadOnly="True">
             </asp:ImageField>
             <asp:BoundField DataField="inventory" HeaderText="inventory" SortExpression="inventory" />
             <asp:CheckBoxField DataField="active" HeaderText="active" SortExpression="active" />
         </Columns>
     </asp:GridView>
     <br />


     </asp:Content>