<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="ShowProducts.aspx.cs" Inherits="ShowProducts" %>

    <asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
           <link href="StyleSheet2.css" rel="stylesheet" />
        <style>
            .myClass {
                 display:inline-table;
                 flex-wrap: wrap;
                 margin: 0 0 3em 0;
                 padding: 0;
                 white-space:normal;
                 width: 20%;  
                 text-align: center;
            }
            /*.submit {position:relative;
                     text-align:center;
            }*/
        </style>
     
  </asp:Content>
<asp:content id="Content2" contentplaceholderid="ContentPlaceHolder1" runat="Server">
     <%--<div id="discount">
         <asp:Label ID="discountlbl" runat="server" Text="Label"></asp:Label>
          <asp:PlaceHolder ID="discountPH" runat="server"></asp:PlaceHolder>
     </div>
     
     <asp:PlaceHolder ID="productsPH" runat="server"></asp:PlaceHolder>
     
      <asp:Button ID="Button1"   runat="server" Text="Create List" OnClick="Button1_Click" />
        <asp:Label ID="Label1"  runat="server" Text=""></asp:Label>--%>
    
     <br /><br /><br />

</asp:content>
