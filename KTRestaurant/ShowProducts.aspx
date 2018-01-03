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
        <asp:Button ID="btnHide"  runat="server" Text="Hide Modal Popup" />
    </div>
</asp:Panel>
        
         <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:productNDBConnectionString %>" SelectCommand="SELECT * FROM [category]"></asp:SqlDataSource>
        
     </div>
   
     <nav class="product-filter ">
		<h1>Food</h1>
	</nav>
	
	<section class="products" >
             <asp:PlaceHolder ID="productsPH" runat="server"></asp:PlaceHolder> 
        <br />     
        <asp:Button ID="addCartBTN" runat="server" Text="Add To Cart" OnClick="addCartBTN_Click" />
	</section>
</asp:Content>
