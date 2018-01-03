<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/MasterPageAdmin.master" CodeFile="showSales - Copy.aspx.cs" Inherits="showSales" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link href="gridviewstyles.css" rel="stylesheet" />
 </asp:Content>

 <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderAdmin" Runat="Server">
     <nav class="product-filter ">

		<h1>Sales<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:productNDBConnectionString %>" SelectCommand="SELECT DISTINCT * FROM [category]"></asp:SqlDataSource>
            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="category_name" DataValueField="category_id">
            </asp:DropDownList>
         </h1>
         </nav>
	     <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:productNDBConnectionString %>" DeleteCommand="DELETE FROM [productN] WHERE [product_id] = @original_product_id AND (([category_id] = @original_category_id) OR ([category_id] IS NULL AND @original_category_id IS NULL)) AND (([title] = @original_title) OR ([title] IS NULL AND @original_title IS NULL)) AND (([img_url] = @original_img_url) OR ([img_url] IS NULL AND @original_img_url IS NULL)) AND (([price] = @original_price) OR ([price] IS NULL AND @original_price IS NULL)) AND (([inventory] = @original_inventory) OR ([inventory] IS NULL AND @original_inventory IS NULL)) AND (([active] = @original_active) OR ([active] IS NULL AND @original_active IS NULL))" InsertCommand="INSERT INTO [productN] ([category_id], [title], [img_url], [price], [inventory], [active]) VALUES (@category_id, @title, @img_url, @price, @inventory, @active)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [productN] WHERE ([category_id] = @category_id)" UpdateCommand="UPDATE [productN] SET [category_id] = @category_id, [title] = @title, [img_url] = @img_url, [price] = @price, [inventory] = @inventory, [active] = @active WHERE [product_id] = @original_product_id AND (([category_id] = @original_category_id) OR ([category_id] IS NULL AND @original_category_id IS NULL)) AND (([title] = @original_title) OR ([title] IS NULL AND @original_title IS NULL)) AND (([img_url] = @original_img_url) OR ([img_url] IS NULL AND @original_img_url IS NULL)) AND (([price] = @original_price) OR ([price] IS NULL AND @original_price IS NULL)) AND (([inventory] = @original_inventory) OR ([inventory] IS NULL AND @original_inventory IS NULL)) AND (([active] = @original_active) OR ([active] IS NULL AND @original_active IS NULL))">
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
             <SelectParameters>
                 <asp:ControlParameter ControlID="DropDownList1" DefaultValue="Choose Category" Name="category_id" PropertyName="SelectedValue" Type="Int32" />
             </SelectParameters>
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
     <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" DataSourceID="SqlDataSource2">
         <Columns>
             <asp:CommandField ShowEditButton="True" />
             <asp:ImageField DataImageUrlField="img_url" HeaderText="Image">
             </asp:ImageField>
         </Columns>
     </asp:GridView>
	     <br />
        
	
 </asp:Content>

