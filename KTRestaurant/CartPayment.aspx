<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/MasterPagecustomer.master"CodeFile="CartPayment.aspx.cs" Inherits="CartPayment" %>

  <asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <%-- <link href="StyleSheet2.css" rel="stylesheet" />
         
      <link href="StyleSheet.css" rel="stylesheet" />--%>
      <style>

          table tr td{
              text-align: center;
          }
      </style>
       <script src="JavaScript.js"> </script>
        <script>

  function CheckBoxRequired_ClientValidate(sender, e) {
        e.IsValid = jQuery(".AcceptedAgreement input:checkbox").is(':checked');
    }
        </script>
       </asp:Content>

   <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHoldercustomer" Runat="Server">
  <table>
      <tr>
          <td> Name:</td>
          <td>         <asp:TextBox ID="Name" runat="server" required="required" EnableViewState="False" ViewStateMode="Disabled"  ></asp:TextBox></td>
      </tr>
       <tr>
           <td> Address:</td>
           <td> <asp:TextBox ID="Address" runat="server" EnableViewState="False" ViewStateMode="Disabled"   required="required"></asp:TextBox></td>
       </tr>
       <tr>
           <td>Email:</td>
           <td><asp:TextBox  TextMode="Email" ID="Email" runat="server" EnableViewState="False" ViewStateMode="Disabled"   required="required"></asp:TextBox></td>
       </tr>
       <tr>
           <td> Shipping Date:</td>
           <td><asp:Calendar ID="Calendar1" runat="server"   ></asp:Calendar>
        <asp:CustomValidator id="CustomValidator1" runat="server" ForeColor="Red" AutoPostBack="true"  EnableViewState="False"  ViewStateMode="Disabled" ErrorMessage="please click a day"  OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
      </td>
       </tr>
        
      <tr>
          <td>
Credit <asp:CheckBox ID="ChBCredit" runat="server" AutoPostBack="true" EnableViewState="False"  ViewStateMode="Disabled" OnCheckedChanged="ChBCredit_CheckedChanged" />
  
   
          </td>
          <td>Cash 
        <asp:CheckBox ID="CHbPhone" runat="server" AutoPostBack="true" EnableViewState="False"  ViewStateMode="Disabled"  OnCheckedChanged="CHbPhone_CheckedChanged" />
 <asp:CustomValidator runat="server" ID="CheckBoxRequired" EnableClientScript="true"
    OnServerValidate="CheckBoxRequired_ServerValidate" ForeColor="Red" ClientValidationFunction="CheckBoxRequired_ClientValidate"></asp:CustomValidator>
    
          </td>
      </tr>
      <tr>
          <td></td><td>     <asp:PlaceHolder ID="PH" runat="server"></asp:PlaceHolder>
</td>
      </tr>
   <tr>
       <td>  Upload Signiture Picture </td>
       <td>     <asp:FileUpload ID="FileUpload1"  runat="server"  AutoPostBack="true" EnableViewState="False"  ViewStateMode="Disabled" />
</td>
       <td> <asp:Label ID="UploadStatusLabel" runat="server" Text=""></asp:Label>
     <asp:RequiredFieldValidator  id="rvfu1" runat="server" ForeColor="Red" ErrorMessage="This is a required field!"  
        ControlToValidate="FileUpload1"></asp:RequiredFieldValidator></td>
   </tr>
    <tr>
        <td></td>
        <td> <asp:Button ID="pay" CssClass="btn" class="button bottun4" runat="server" Text="אישור לתשלום" OnClick="pay_Click" /></td>
    </tr>
    <tr>
        <td></td>
        <td>   <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
   </td>
    </tr>
   </table>
 </asp:Content>
