﻿<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/MasterPageAdmin.master" CodeFile="showSales.aspx.cs" Inherits="showSales" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link href="gridviewstyles.css" rel="stylesheet" />
 </asp:Content>

 <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderAdmin" Runat="Server">
     <nav class="product-filter ">

		<h1>Sales</h1>
         <asp:DropDownList ID="fcatddl" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="category_name" DataValueField="category_name" AppendDataBoundItems="true">
          <asp:ListItem Text="Choose Category" Value="" />
             </asp:DropDownList>
         </nav>
	     <br />
         <asp:GridView CssClass="design" ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" OnRowDataBound="GridView1_DataBound" AllowPaging="True" AllowSorting="True" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
             <Columns>
                 <asp:BoundField DataField="category_name" HeaderText="category_name" SortExpression="category_name" />
                 <asp:BoundField DataField="title" HeaderText="title" SortExpression="title" />
                 <asp:ImageField DataImageUrlField="img_url" HeaderText="Image">
                 </asp:ImageField>
                 <asp:BoundField DataField="total_price" HeaderText="total_price" SortExpression="total_price" />
                 <asp:BoundField DataField="amount" HeaderText="amount" SortExpression="amount" />
                 <asp:CheckBoxField DataField="p_method" HeaderText="p_method" SortExpression="p_method" />
                 <asp:BoundField DataField="cust_id" HeaderText="cust_id" SortExpression="cust_id" />
                 <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" />
             </Columns>
             <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
             <HeaderStyle BackColor="#003399"  Font-Bold="True" ForeColor="#CCCCFF"  />
             <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
             <RowStyle BackColor="White" ForeColor="#003399" />
             <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
             <SortedAscendingCellStyle BackColor="#EDF6F6" />
             <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
             <SortedDescendingCellStyle BackColor="#D6DFDF" />
             <SortedDescendingHeaderStyle BackColor="#002876" />
         </asp:GridView>
         <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:productNDBConnectionString %>" SelectCommand="SELECT DISTINCT [category_name] FROM [completeSales]"></asp:SqlDataSource>
         <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:productNDBConnectionString %>" SelectCommand="SELECT * FROM [completeSales]" FilterExpression="category_name = '{0}'">
             <SelectParameters>
                 <asp:ControlParameter ControlID="fcatddl" DefaultValue="Choose Category" Name="category_name" PropertyName="SelectedValue" Type="String" />

             </SelectParameters>
                <FilterParameters>
        <asp:ControlParameter Name="category_name" ControlID="fcatddl" PropertyName="SelectedValue" />
    </FilterParameters>
         </asp:SqlDataSource>
	
 </asp:Content>

