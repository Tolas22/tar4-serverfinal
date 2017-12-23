<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/MasterPageAdmin.master" CodeFile="inventoryManagement.aspx.cs" Inherits="inventoryManagement" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

 </asp:Content>


 <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderAdmin" Runat="Server">
     
     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:productNDBConnectionString %>" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [customers]"></asp:SqlDataSource>
     <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="cust_id" DataSourceID="SqlDataSource1">
         <Columns>
             <asp:BoundField DataField="cust_id" HeaderText="cust_id" InsertVisible="False" ReadOnly="True" SortExpression="cust_id" />
             <asp:BoundField DataField="customer" HeaderText="customer" SortExpression="customer" />
             <asp:BoundField DataField="pass" HeaderText="pass" SortExpression="pass" />
             <asp:CheckBoxField DataField="cust_type" HeaderText="cust_type" SortExpression="cust_type" />
         </Columns>
     </asp:GridView>
     
     </asp:Content>


