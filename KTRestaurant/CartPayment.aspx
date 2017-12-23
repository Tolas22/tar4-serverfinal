<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/myMasterPage.master"CodeFile="CartPayment.aspx.cs" Inherits="CartPayment" %>

  <asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <link href="StyleSheet2.css" rel="stylesheet" />
      <link href="StyleSheet.css" rel="stylesheet" />
       </asp:Content>

   <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="text-align:center;">
  <asp:Label ID="Label1" runat="server" Text=""></asp:Label>

        <asp:Button ID="pay" CssClass="btn" class="button bottun4" runat="server" Text="אישור לתשלום" OnClick="pay_Click" />
    </div>
 </asp:Content>
