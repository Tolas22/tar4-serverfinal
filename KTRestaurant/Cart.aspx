<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPagecustomer.master" CodeFile="Cart.aspx.cs" Inherits="Cart" %>
  <asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <link href="StyleSheet2.css" rel="stylesheet" />
      <link href="StyleSheet.css" rel="stylesheet" />
      <style>
        .form-control {
    display: block;
    width: 70px;
    height: 34px;
    padding: 6px 12px;
    font-size: 14px;
    line-height: 1.42857143;
    color: #555;
    background-color: #fff;
    background-image: none;
    border: 1px solid #ccc;
    border-radius: 4px;
    -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
    box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
    -webkit-transition: border-color ease-in-out .15s,-webkit-box-shadow ease-in-out .15s;
    -o-transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
    transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
}
      </style>
       </asp:Content>


   <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHoldercustomer" Runat="Server">
               <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
       <asp:Label ID="Label2" runat="server" Text="Welcome"></asp:Label>
    <div>
        <asp:PlaceHolder ID="cartPH" runat="server"></asp:PlaceHolder>
        <asp:PlaceHolder ID="cartPH1" runat="server"></asp:PlaceHolder>
        <asp:Label ID="priceLBL" runat="server" Text="Label"></asp:Label>
        </div>
       <div style="text-align:center;">
    </div>
        </asp:Content>
