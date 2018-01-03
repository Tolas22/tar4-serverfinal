<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPageAdmin.master" CodeFile="addCategory.aspx.cs" Inherits="addCategory" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

 </asp:Content>


 <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderAdmin" Runat="Server">
     <h2>Add Category</h2>
     <p>
         <asp:Label ID="cnameLBL" runat="server" Text="Category name:"></asp:Label>
         <asp:TextBox ID="cnameTB" runat="server"  AutoPostBack="true"></asp:TextBox>
         <asp:CustomValidator ID="catexistVLD" runat="server"  ControlToValidate="cnameTB" ForeColor="Maroon" ErrorMessage="Category already exists" OnServerValidate="catexistVLD_ServerValidate"></asp:CustomValidator>
         <asp:RequiredFieldValidator ID="cnameVLD" runat="server" ControlToValidate="cnameTB" ErrorMessage="Must Enter Category Name" ></asp:RequiredFieldValidator>
     </p>
     <p>
         <asp:Button ID="addctgBTN" runat="server" Text="Add" OnClick="addctgBTN_Click" />
     </p>
   
     <p>
         <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:productNDBConnectionString %>" DeleteCommand="DELETE FROM [category] WHERE [category_id] = @original_category_id AND (([category_name] = @original_category_name) OR ([category_name] IS NULL AND @original_category_name IS NULL))" InsertCommand="INSERT INTO [category] ([category_name]) VALUES (@category_name)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [category]" UpdateCommand="UPDATE [category] SET [category_name] = @category_name WHERE [category_id] = @original_category_id AND (([category_name] = @original_category_name) OR ([category_name] IS NULL AND @original_category_name IS NULL))">
             <DeleteParameters>
                 <asp:Parameter Name="original_category_id" Type="Int32" />
                 <asp:Parameter Name="original_category_name" Type="String" />
             </DeleteParameters>
             <InsertParameters>
                 <asp:Parameter Name="category_name" Type="String" />
             </InsertParameters>
             <UpdateParameters>
                 <asp:Parameter Name="category_name" Type="String" />
                 <asp:Parameter Name="original_category_id" Type="Int32" />
                 <asp:Parameter Name="original_category_name" Type="String" />
             </UpdateParameters>
         </asp:SqlDataSource>
         <asp:GridView ID="catGRD" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="category_id" DataSourceID="SqlDataSource1" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
             <Columns>
                 <asp:BoundField DataField="category_name" HeaderText="Existing Categories" SortExpression="category_name" />
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
     </p>
     
     </asp:Content>
