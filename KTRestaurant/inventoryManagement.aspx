<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/MasterPageAdmin.master" CodeFile="inventoryManagement.aspx.cs" Inherits="inventoryManagement" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

 </asp:Content>


 <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderAdmin" Runat="Server">
     
     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:productNDBConnectionString %>" DeleteCommand="DELETE FROM [productN] WHERE [product_id] = @original_product_id AND (([category_id] = @original_category_id) OR ([category_id] IS NULL AND @original_category_id IS NULL)) AND (([title] = @original_title) OR ([title] IS NULL AND @original_title IS NULL)) AND (([img_url] = @original_img_url) OR ([img_url] IS NULL AND @original_img_url IS NULL)) AND (([price] = @original_price) OR ([price] IS NULL AND @original_price IS NULL)) AND (([inventory] = @original_inventory) OR ([inventory] IS NULL AND @original_inventory IS NULL)) AND (([active] = @original_active) OR ([active] IS NULL AND @original_active IS NULL))" InsertCommand="INSERT INTO [productN] ([category_id], [title], [img_url], [price], [inventory], [active]) VALUES (@category_id, @title, @img_url, @price, @inventory, @active)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [productN]" UpdateCommand="UPDATE [productN] SET [category_id] = @category_id, [title] = @title, [img_url] = @img_url, [price] = @price, [inventory] = @inventory, [active] = @active WHERE [product_id] = @original_product_id AND (([category_id] = @original_category_id) OR ([category_id] IS NULL AND @original_category_id IS NULL)) AND (([title] = @original_title) OR ([title] IS NULL AND @original_title IS NULL)) AND (([img_url] = @original_img_url) OR ([img_url] IS NULL AND @original_img_url IS NULL)) AND (([price] = @original_price) OR ([price] IS NULL AND @original_price IS NULL)) AND (([inventory] = @original_inventory) OR ([inventory] IS NULL AND @original_inventory IS NULL)) AND (([active] = @original_active) OR ([active] IS NULL AND @original_active IS NULL))">
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
     <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="product_id" DataSourceID="SqlDataSource1">
         <Columns>
             <asp:CommandField ShowEditButton="True" ShowSelectButton="True" />
             <asp:BoundField DataField="product_id" HeaderText="product_id" InsertVisible="False" ReadOnly="True" SortExpression="product_id" />
             <asp:BoundField DataField="category_id" HeaderText="category_id" SortExpression="category_id" />
             <asp:BoundField DataField="title" HeaderText="title" SortExpression="title" />
             <asp:BoundField DataField="img_url" HeaderText="img_url" SortExpression="img_url" />
             <asp:BoundField DataField="price" HeaderText="price" SortExpression="price" />
             <asp:BoundField DataField="inventory" HeaderText="inventory" SortExpression="inventory" />
             <asp:CheckBoxField DataField="active" HeaderText="active" SortExpression="active" />
         </Columns>
     </asp:GridView>
     
     </asp:Content>


