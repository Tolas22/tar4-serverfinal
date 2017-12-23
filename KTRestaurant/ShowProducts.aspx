<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPagecustomer.master" CodeFile="ShowProducts.aspx.cs" Inherits="ShowProducts" %>

    <asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
           <link href="StyleSheet2.css" rel="stylesheet" />
        <link href="StyleSheet.css" rel="stylesheet" />
        <style>
            /*.myClass {
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
                 color:red; 
            }*/
           
        </style>
     
  </asp:Content>
 <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="discountclass unit-copy font-medium" id="discount">
         <asp:Label ID="discountlbl" runat="server" Text="Label"></asp:Label>
          <asp:PlaceHolder ID="discountPH" runat="server"></asp:PlaceHolder>
     </div>
     
     <asp:PlaceHolder ID="productsPH" runat="server"></asp:PlaceHolder>
     
      <%--<asp:Button ID="Button1" class="button bottun4"  runat="server" Text="Create List" OnClick="Button1_Click" />--%>
        <asp:Label ID="Label1"  runat="server" Text=""></asp:Label>
    
     <br /><br /><br />

</asp:Content>
