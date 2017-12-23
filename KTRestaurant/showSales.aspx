


<<<<<<< HEAD
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:bgroup59_test1ConnectionString %>" DeleteCommand="DELETE FROM [sales] WHERE [sale_id] = @original_sale_id AND (([product_id] = @original_product_id) OR ([product_id] IS NULL AND @original_product_id IS NULL)) AND (([total_price] = @original_total_price) OR ([total_price] IS NULL AND @original_total_price IS NULL)) AND (([amount] = @original_amount) OR ([amount] IS NULL AND @original_amount IS NULL)) AND (([p_method] = @original_p_method) OR ([p_method] IS NULL AND @original_p_method IS NULL)) AND (([cust_id] = @original_cust_id) OR ([cust_id] IS NULL AND @original_cust_id IS NULL))" InsertCommand="INSERT INTO [sales] ([product_id], [total_price], [amount], [p_method], [cust_id]) VALUES (@product_id, @total_price, @amount, @p_method, @cust_id)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [sales]" UpdateCommand="UPDATE [sales] SET [product_id] = @product_id, [total_price] = @total_price, [amount] = @amount, [p_method] = @p_method, [cust_id] = @cust_id WHERE [sale_id] = @original_sale_id AND (([product_id] = @original_product_id) OR ([product_id] IS NULL AND @original_product_id IS NULL)) AND (([total_price] = @original_total_price) OR ([total_price] IS NULL AND @original_total_price IS NULL)) AND (([amount] = @original_amount) OR ([amount] IS NULL AND @original_amount IS NULL)) AND (([p_method] = @original_p_method) OR ([p_method] IS NULL AND @original_p_method IS NULL)) AND (([cust_id] = @original_cust_id) OR ([cust_id] IS NULL AND @original_cust_id IS NULL))">
            <DeleteParameters>
                <asp:Parameter Name="original_sale_id" Type="Int32" />
                <asp:Parameter Name="original_product_id" Type="Int32" />
                <asp:Parameter Name="original_total_price" Type="Double" />
                <asp:Parameter Name="original_amount" Type="Int32" />
                <asp:Parameter Name="original_p_method" Type="Boolean" />
                <asp:Parameter Name="original_cust_id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="product_id" Type="Int32" />
                <asp:Parameter Name="total_price" Type="Double" />
                <asp:Parameter Name="amount" Type="Int32" />
                <asp:Parameter Name="p_method" Type="Boolean" />
                <asp:Parameter Name="cust_id" Type="Int32" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="product_id" Type="Int32" />
                <asp:Parameter Name="total_price" Type="Double" />
                <asp:Parameter Name="amount" Type="Int32" />
                <asp:Parameter Name="p_method" Type="Boolean" />
                <asp:Parameter Name="cust_id" Type="Int32" />
                <asp:Parameter Name="original_sale_id" Type="Int32" />
                <asp:Parameter Name="original_product_id" Type="Int32" />
                <asp:Parameter Name="original_total_price" Type="Double" />
                <asp:Parameter Name="original_amount" Type="Int32" />
                <asp:Parameter Name="original_p_method" Type="Boolean" />
                <asp:Parameter Name="original_cust_id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="sale_id" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="sale_id" HeaderText="sale_id" InsertVisible="False" ReadOnly="True" SortExpression="sale_id" />
                <asp:BoundField DataField="product_id" HeaderText="product_id" SortExpression="product_id" />
                <asp:BoundField DataField="total_price" HeaderText="total_price" SortExpression="total_price" />
                <asp:BoundField DataField="amount" HeaderText="amount" SortExpression="amount" />
                <asp:CheckBoxField DataField="p_method" HeaderText="p_method" SortExpression="p_method" />
                <asp:BoundField DataField="cust_id" HeaderText="cust_id" SortExpression="cust_id" />
            </Columns>
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
=======
>>>>>>> cf430bc5e12fed89f82a5c9fcafece2ad1d96af1
