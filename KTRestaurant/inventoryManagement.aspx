<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/MasterPageAdmin.master" CodeFile="inventoryManagement.aspx.cs" Inherits="inventoryManagement" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

 </asp:Content>


 <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderAdmin" Runat="Server">
     
     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:productNDBConnectionString %>" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [AddProduct]" >
     </asp:SqlDataSource>
     <asp:GridView ID="GridView1"  runat="server" AutoGenerateEditButton="True" AllowPaging="True" AllowSorting="True"  AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
           <Columns>
   
               <asp:CommandField ShowSelectButton="True" />
   
             <asp:BoundField DataField="title" HeaderText="title" SortExpression="title" />
               <asp:BoundField DataField="category_name" HeaderText="category_name" SortExpression="category_name" />
             <asp:BoundField DataField="img_url" HeaderText="img_url" SortExpression="img_url" />
             <asp:BoundField DataField="price" HeaderText="price" SortExpression="price" />
               <asp:TemplateField HeaderText="inventory" SortExpression="inventory">
                   <EditItemTemplate>
                       <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="false" >
                           <asp:ListItem>0</asp:ListItem>
                           <asp:ListItem>1</asp:ListItem>
                           <asp:ListItem>2</asp:ListItem>
                           <asp:ListItem>3</asp:ListItem>
                           <asp:ListItem>4</asp:ListItem>
                           <asp:ListItem>5</asp:ListItem>
                           <asp:ListItem>6</asp:ListItem>
                           <asp:ListItem>7</asp:ListItem>
                           <asp:ListItem>8</asp:ListItem>
                           <asp:ListItem>9</asp:ListItem>
                           <asp:ListItem>10</asp:ListItem>
                       </asp:DropDownList>
                   </EditItemTemplate>
                   <ItemTemplate>
                       <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="false">
                           <asp:ListItem>0</asp:ListItem>
                           <asp:ListItem>1</asp:ListItem>
                           <asp:ListItem>2</asp:ListItem>
                           <asp:ListItem>3</asp:ListItem>
                           <asp:ListItem>4</asp:ListItem>
                           <asp:ListItem>5</asp:ListItem>
                           <asp:ListItem>6</asp:ListItem>
                           <asp:ListItem>7</asp:ListItem>
                           <asp:ListItem>8</asp:ListItem>
                           <asp:ListItem>9</asp:ListItem>
                           <asp:ListItem>10</asp:ListItem>
                       </asp:DropDownList>
                   </ItemTemplate>
               </asp:TemplateField>
               <asp:TemplateField HeaderText="active" SortExpression="active">
                   <EditItemTemplate>
                       <asp:RadioButtonList ID="RadioButtonList1" runat="server" SelectedValue='<%# Eval("**DepartmentId**") %>' AutoPostBack="false">
                           <asp:ListItem Value="True">Active</asp:ListItem>
                           <asp:ListItem Value="False">Disabled</asp:ListItem>
                       </asp:RadioButtonList>
                   </EditItemTemplate>
                   <ItemTemplate>
                       <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="false">
                           <asp:ListItem Value="True">Active</asp:ListItem>
                           <asp:ListItem Value="False">Disabled</asp:ListItem>
                       </asp:RadioButtonList>
                   </ItemTemplate>
               </asp:TemplateField>
         </Columns>
     </asp:GridView>
     
     </asp:Content>