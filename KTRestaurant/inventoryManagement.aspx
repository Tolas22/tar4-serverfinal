<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/MasterPageAdmin.master" CodeFile="inventoryManagement.aspx.cs" Inherits="inventoryManagement" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <script type="text/javascript" >
        
    </script>
     <link href="gridviewstyles.css" rel="stylesheet" />
 </asp:Content>


 <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderAdmin" Runat="Server">

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:productNDBConnectionString %>" SelectCommand="SELECT * FROM [productN]" OldValuesParameterFormatString="original_{0}" ConflictDetection="CompareAllValues" DeleteCommand="DELETE FROM [productN] WHERE [product_id] = @original_product_id AND (([category_id] = @original_category_id) OR ([category_id] IS NULL AND @original_category_id IS NULL)) AND (([title] = @original_title) OR ([title] IS NULL AND @original_title IS NULL)) AND (([img_url] = @original_img_url) OR ([img_url] IS NULL AND @original_img_url IS NULL)) AND (([price] = @original_price) OR ([price] IS NULL AND @original_price IS NULL)) AND (([inventory] = @original_inventory) OR ([inventory] IS NULL AND @original_inventory IS NULL)) AND (([active] = @original_active) OR ([active] IS NULL AND @original_active IS NULL))" InsertCommand="INSERT INTO [productN] ([category_id], [title], [img_url], [price], [inventory], [active]) VALUES (@category_id, @title, @img_url, @price, @inventory, @active)" UpdateCommand="UPDATE [productN] SET [inventory] = @inventory, [active] = @active WHERE (([inventory] = @original_inventory) OR ([inventory] IS NULL AND @original_inventory IS NULL)) AND (([active] = @original_active) OR ([active] IS NULL AND @original_active IS NULL))">
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
         <UpdateParameters >        
             <asp:Parameter Name="inventory" Type="Int32" />
             <asp:Parameter Name="active" Type="Boolean" />
             <asp:Parameter Name="original_inventory" Type="Int32" />
             <asp:Parameter Name="original_active" Type="Boolean" />
         </UpdateParameters>
     </asp:SqlDataSource>
     <br />
     <asp:label id="Message"
        forecolor="Red"          
        runat="server"/>

     <asp:GridView class="design" ID="GridView1" runat="server" OnRowDataBound="GridView1_RowDataBound" DataSourceID="SqlDataSource1" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="product_id" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4"  onrowupdated="GridView1_RowUpdated" OnRowCancelingEdit="GridView1_RowCancelingEdit" onrowediting="GridView1_RowEditing"  >
         <Columns>
             
             <asp:CommandField ShowEditButton="True"   />

             <asp:BoundField DataField="product_id" HeaderText="product_id" SortExpression="product_id" InsertVisible="False" >
             <HeaderStyle CssClass="design" />
             </asp:BoundField>
             <asp:BoundField DataField="category_id" HeaderText="category_id" SortExpression="category_id" ReadOnly="True" >             <HeaderStyle CssClass="design" />
             </asp:BoundField>
             <asp:TemplateField HeaderText="Category Name"> <HeaderStyle CssClass="design" />

                 <ItemTemplate>
                     <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                 </ItemTemplate>
             </asp:TemplateField>
             <asp:BoundField DataField="title" HeaderText="title" SortExpression="title" ReadOnly="True" ><HeaderStyle CssClass="design" /> </asp:BoundField>
             <asp:BoundField DataField="price" HeaderText="price" SortExpression="price" ReadOnly="True" ><HeaderStyle CssClass="design" /> </asp:BoundField>
             <asp:ImageField DataImageUrlField="img_url" HeaderText="Image" ReadOnly="True">
                 <ItemStyle CssClass="imge" />
                              <HeaderStyle CssClass="design" />
             </asp:ImageField>
             <asp:BoundField DataField="inventory" HeaderText="inventory" SortExpression="inventory" >  <HeaderStyle CssClass="design" />
                              </asp:BoundField>

              <asp:CheckBoxField DataField="active" HeaderText="active" SortExpression="active" >  <HeaderStyle CssClass="design" />
                  </asp:CheckBoxField>
         </Columns>
         <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
         <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
         <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
         <RowStyle BackColor="White" ForeColor="#003399" />
         <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
         <SortedAscendingCellStyle BackColor="#EDF6F6" />
         <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
         <SortedDescendingCellStyle BackColor="#D6DFDF" />
         <SortedDescendingHeaderStyle BackColor="#002876" />
     </asp:GridView>
     <br />


     </asp:Content>