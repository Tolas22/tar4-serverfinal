<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPagecustomer.master" CodeFile="ShowProducts.aspx.cs" Inherits="ShowProducts" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
    

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <link href="showP.css" rel="stylesheet" />
           <%--<link href="StyleSheet2.css" rel="stylesheet"
                />

        <link href="StyleSheet.css" rel="stylesheet" />--%>
 
        <style>
        .modalBackground
        {
            background-color: Black;
            filter: alpha(opacity=60);
            opacity: 0.6;
        }
        .modalPopup
        {
            background-color: #FFFFFF;
            width: 900px;
          
            border: 3px solid #0DA9D0;
            padding: 0;
        }
        .modalPopup .header
        {
            background-color: #2FBDF1;
            height: 50px;
            color: White;
            line-height: 30px;
            text-align: center;
            font-weight: bold;
        }
        .modalPopup .body
        {
            min-height: 50px;
            line-height: 30px;
            text-align: center;
            font-weight: bold;
            margin-bottom: 5px;
        }
            .myClass {
                 display:inline-table;
                 flex-wrap: wrap;
                 margin: 0 0 3em 0;
                 padding: 0;
                 white-space:normal;
                 width: 20%;  
                 text-align: center;

            }
            .discountclass {
                 text-align: center;
                 background-color:darkblue;
                 flex-wrap: wrap;
                 margin: 0 0 3em 0;
                 padding: 0;
                 white-space:normal;
                 width: 100%; 
                 color:black; 
            }
           
        </style>
     
  </asp:Content>
 <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHoldercustomer" Runat="Server">
     <div class="" >
         <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
</cc1:ToolkitScriptManager>
<asp:LinkButton ID="lnkDummy" runat="server"></asp:LinkButton>
<cc1:ModalPopupExtender ID="ModalPopupExtender1" BehaviorID="mpe" runat="server"
    PopupControlID="pnlPopup" TargetControlID="lnkDummy" BackgroundCssClass="modalBackground" CancelControlID = "btnHide">
</cc1:ModalPopupExtender>
<asp:Panel ID="pnlPopup" runat="server" CssClass="modalPopup" Style="display: none">
    <div class="header">
    <h1>HOT DISCOUNT</h1>   
    </div>
    <div class="body" id="discount">
        <asp:Label ID="discountlbl" runat="server" Text="Label"></asp:Label>
          <asp:PlaceHolder ID="discountPH" runat="server"></asp:PlaceHolder>
        <br />
        <asp:Button ID="btnHide" runat="server" Text="Hide Modal Popup" />
    </div>
</asp:Panel>
        
         <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:productNDBConnectionString %>" SelectCommand="SELECT * FROM [category]"></asp:SqlDataSource>
        
     </div>
     
<%--     <asp:PlaceHolder ID="productsPH" runat="server"></asp:PlaceHolder>--%>
     
      <%--<asp:Button ID="Button1" class="button bottun4"  runat="server" Text="Create List" OnClick="Button1_Click" />
     <%--   <asp:Label ID="Label1"  runat="server" Text=""></asp:Label>
    
     <br /><br /><br />--%>
   
     <nav class="product-filter ">
		<h1>Jackets</h1>
		
		<div class="sort">
			<div class="collection-sort">
				<label>Filter by:</label>
                <asp:DropDownList ID="fcategoryDDL" runat="server" DataSourceID="SqlDataSource1" DataTextField="category_name" DataValueField="category_id"></asp:DropDownList>
			</div>
			
			
		</div>
	</nav>
	
	<section class="products" >
             <asp:PlaceHolder ID="productsPH" runat="server"></asp:PlaceHolder>


		<%--<div class="product-card">
			<div class="product-image">
				<img src="https://cdn.shopify.com/s/files/1/0938/8938/products/10231100205_1_1315x1800_300_CMYK_1024x1024.jpeg?v=1445623369">
			</div>
			<div class="product-info">
				<h5>Winter Jacket</h5>
				<h6>$99.99</h6>
			</div>
		</div>
		
		<div class="product-card">
			<div class="product-image">
				<img src="https://cdn.shopify.com/s/files/1/0938/8938/products/10231100205_1_1315x1800_300_CMYK_1024x1024.jpeg?v=1445623369">
			</div>
			<div class="product-info">
				<h5>Winter Jacket</h5>
				<h6>$99.99</h6>
			</div>
		</div>
		
		<div class="product-card">
			<div class="product-image">
				<img src="https://cdn.shopify.com/s/files/1/0938/8938/products/10231100205_1_1315x1800_300_CMYK_1024x1024.jpeg?v=1445623369">
			</div>
			<div class="product-info">
				<h5>Winter Jacket</h5>
				<h6>$99.99</h6>
			</div>
		</div>
		
		<div class="product-card">
			<div class="product-image">
				<img src="https://cdn.shopify.com/s/files/1/0938/8938/products/10231100205_1_1315x1800_300_CMYK_1024x1024.jpeg?v=1445623369">
			</div>
			<div class="product-info">
				<h5>Winter Jacket</h5>
				<h6>$99.99</h6>
			</div>
		</div>
		
		<div class="product-card">
			<div class="product-image">
				<img src="https://cdn.shopify.com/s/files/1/0938/8938/products/10231100205_1_1315x1800_300_CMYK_1024x1024.jpeg?v=1445623369">
			</div>
			<div class="product-info">
				<h5>Winter Jacket</h5>
				<h6>$99.99</h6>
			</div>
		</div>
		
		<div class="product-card">
			<div class="product-image">
				<img src="https://cdn.shopify.com/s/files/1/0938/8938/products/10231100205_1_1315x1800_300_CMYK_1024x1024.jpeg?v=1445623369">
			</div>
			<div class="product-info">
				<h5>Winter Jacket</h5>
				<h6>$99.99</h6>
			</div>
		</div>
		
		<div class="product-card">
			<div class="product-image">
				<img src="https://cdn.shopify.com/s/files/1/0938/8938/products/10231100205_1_1315x1800_300_CMYK_1024x1024.jpeg?v=1445623369">
			</div>
			<div class="product-info">
				<h5>Winter Jacket</h5>
				<h6>$99.99</h6>
			</div>
		</div>
		
		<div class="product-card">
			<div class="product-image">
				<img src="https://cdn.shopify.com/s/files/1/0938/8938/products/10231100205_1_1315x1800_300_CMYK_1024x1024.jpeg?v=1445623369">
			</div>
			<div class="product-info">
				<h5>Winter Jacket</h5>
				<h6>$99.99</h6>
			</div>
		</div>
		
		<div class="product-card">
			<div class="product-image">
				<img src="https://cdn.shopify.com/s/files/1/0938/8938/products/10231100205_1_1315x1800_300_CMYK_1024x1024.jpeg?v=1445623369">
			</div>
			<div class="product-info">
				<h5>Winter Jacket</h5>
				<h6>$99.99</h6>
			</div>
		</div>
		
		<div class="product-card">
			<div class="product-image">
				<img src="https://cdn.shopify.com/s/files/1/0938/8938/products/10231100205_1_1315x1800_300_CMYK_1024x1024.jpeg?v=1445623369">
			</div>
			<div class="product-info">
				<h5>Winter Jacket</h5>
				<h6>$99.99</h6>
			</div>
		</div>
		--%>
	</section>
</asp:Content>
