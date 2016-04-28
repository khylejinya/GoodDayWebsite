<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="~/checkOut.aspx.cs" Inherits="GoodDayWebsite.checkOut" %>
<script runat=server>
    </script>
<asp:Content ID="BodyContent1" ContentPlaceHolderID="MainContent" runat="server">
    <section id="bodyContent">
        <div class="mainTitle"><asp:Label ID="lbl_titlePage" runat="server" Text="Checkout"></asp:Label></div>
        <br />
        Your order Summary:
        <br />
        Order Total: <asp:label id="lbl_OrderTotal" runat="server" text="Label"></asp:label>
        <br />
        <asp:gridview id="dg_checkout" runat="server"></asp:gridview>
        <br />
        <br />
        <asp:button id="btn_MakePayment" runat="server" text="Make Payment" />
        <br />
        <br />
        <br />
        <table>
         <th>Your Information:</th>
            <tr>
                <td>First Name:</td><td> <asp:textbox id="txt_firstName" runat="server"></asp:textbox></td><td> Last Name: </td> <td><asp:textbox id="txt_lastName" runat="server"></asp:textbox></td>
            </tr>
            <tr>
                <td>Phone: </td><td><asp:textbox id="txt_Phone" runat="server"></asp:textbox></td><td></td><td></td>
                </tr>
            <tr>
             <td>Email Address: </td><td><asp:Label id="lbl_emailAddress" runat="server" Text="Label"></asp:Label></td><td></td><td></td>
                </tr>
        <tr><td>&nbsp;</td></tr>
        <tr><td>&nbsp;</td></tr>
            <tr>
             <td>Billing and Shipment Address:</td><td></td><td></td><td></td>
                </tr>
            <tr>
                <td>Postcode:</td><td> <asp:textbox id="txt_Postcode" runat="server"></asp:textbox></td> <td></td><td></td>
               </tr>
            <tr>
                 <td>House Number: </td><td><asp:textbox id="txt_houseNumber" runat="server"></asp:textbox> </td><td> <asp:button id="FindAddress" runat="server" text="Find Address" onClick="btn_FindAddress_click"/></td><td></td>
             </tr>
             <tr><td>&nbsp;</td></tr>
            <tr><td>&nbsp;</td></tr>
            <tr>
            <td>Street:</td><td><asp:textbox id="txt_Street" runat="server"></asp:textbox></td><td>City:</td><td><asp:textbox id="txt_City" runat="server"></asp:textbox></td>
            </tr>
            <tr>
                <td>Country:</td><td><asp:textbox id="txt_Country" runat="server"></asp:textbox></td><td>Postcode: </td><td><asp:textbox id="txt_postcode2" runat="server"></asp:textbox></td>
            </tr>
                </table>
        <br />
        <table>
            <th>Payment Method</th>
            <tr><td>&nbsp;</td></tr>
            <tr><td>Choose Payment Type:</td><td>
                <asp:DropDownList ID="ddl_paymentMethod" runat="server"></asp:DropDownList></td></tr>
            <tr><td>Card Number:</td> <td>
                <asp:TextBox ID="txt_cardNumber" runat="server"></asp:TextBox></td></tr>
            <tr><td>Card Expiry Month:</td><td>
                <asp:TextBox ID="txt_cardExpiryMonth" runat="server"></asp:TextBox></td></tr>
            <tr><td>Card Expiry Year:</td><td>
                <asp:TextBox ID="txt_cardExpiryYear" runat="server"></asp:TextBox></td></tr>
            <tr><td>Card 3 Digit Security No:</td><td>
                <asp:TextBox ID="txt_SecurityNumber" runat="server"></asp:TextBox></td></tr>
        </table>
        <br />
        <br />
        <asp:button id="btn_Pay" runat="server" text="Pay" OnClick="btn_Pay_Click"/>
      </section>
</asp:Content>
