<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPagecustomer.master" CodeFile="Cart.aspx.cs" Inherits="Cart" %>
  <asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <link href="StyleSheet2.css" rel="stylesheet" />
      <link href="StyleSheet.css" rel="stylesheet" />
       </asp:Content>

   <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
               <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
       <asp:Label ID="Label2" runat="server" Text="Welcome"></asp:Label>
    <div>
        <asp:PlaceHolder ID="cartPH" runat="server"></asp:PlaceHolder>
        <asp:Label ID="priceLBL" runat="server" Text="Label"></asp:Label>
        </div>
       <div style="text-align:center;">
        <%--<asp:Button ID="confirmbtn" runat="server" class="button bottun4" Text="אישור ומעבר לתשלום" OnClick="confirmbtn_Click" />--%>
    </div>

         </asp:Content>
