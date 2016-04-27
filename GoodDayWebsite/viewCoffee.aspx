<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="~/viewCoffee.aspx.cs" Inherits="GoodDayWebsite.viewCoffee" %>
<asp:Content ID="BodyContent1" ContentPlaceHolderID="MainContent" runat="server">
    <section id="breadCrumbContent"> 
    <ol class="breadcrumb">
        <li><a href="Default.aspx">Home</a></li>  
        <li class ="divider"> > </li>
        <li><a href="ListCoffees.aspx"><asp:Label ID="lbl_breadcrumbCoffee" runat="server" Text="All"></asp:Label> 
        Coffees</a></li>
        <li class ="divider"> > </li>
        <li  class="current"><asp:Label ID="lbl_breadcrumbCurrent" runat="server" Text="One"></asp:Label> 
        Coffee</li>
    </ol>
        </section>
     <section id="bodyContent">
            <table>
                <tr>
                    <td style="width:30%;">
                        <div class="coffeeImage"><asp:Image ID="IM_CoffeeImage" runat="server" /></div>
                        <br />
                        <b>Coffee Strength:</b>
                        <br />
                        <asp:Image ID="IM_Strength" runat="server" />
                    </td>
                    <%--<td>&nbsp;</td>--%>  
                    <td style="vertical-align: top; text-align:left;">
                        <div class="mainTitle"><asp:Label ID="lbl_SelectedCoffee" runat="server" Text=""></asp:Label></div>
                        <b>Price:</b><br /><br /><asp:Label ID="lbl_coffeePrice" runat="server" CssClass="coffeePrice"></asp:Label>
                        <br />
                        <br />
                        <b>Origin:</b><br /><asp:Label ID="lbl_coffeeOrigin" runat="server"></asp:Label>
                        <br />
                        <br />
                        <b>Choose a Grind:</b>
                        <br />
                        <asp:DropDownList ID="ddl_CoffeeGrind" runat="server">
                              <asp:ListItem Selected="True" Value="Beans"> Beans </asp:ListItem>
                              <asp:ListItem Value="Medium"> Medium </asp:ListItem>
                              <asp:ListItem Value="Fine"> Fine </asp:ListItem>
                              <asp:ListItem Value="Extra Fine"> Extra Fine </asp:ListItem>
                              <asp:ListItem Value="Turkish"> Turkish </asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        <br />
                        <b>Quantity:</b><br /><asp:Label ID="lbl_QuantityStock" runat="server" Visible="false"></asp:Label>
                        <br />
                        <asp:TextBox ID="txt_Quantity" runat="server" Text="1"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txt_Quantity" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                        <br />
                        <br />
                        <b>Description:</b><br /><asp:Label ID="lbl_coffeeDesc" runat="server"></asp:Label>
                        <br />
                        <br />
                        <asp:Button ID="btn_AddtoCart" runat="server" Text="Add To Cart" OnClick="btn_AddtoCart_Click" />&nbsp;<asp:Label ID="lbl_QunatityError" runat="server" Text="Not enough quantity for your purchase." Visible="false" ForeColor="Red"></asp:Label>
                        <br />
                        <asp:Button ID="btn_UpdateMe" runat="server" Text="Email Me When Stock Is Updated" Visible="false" OnClick="btn_UpdateMe_Click" /> &nbsp;&nbsp;<asp:Label ID="Label1" runat="server" Text="or" Visible="false"></asp:Label><asp:Button ID="btn_StartAgain" runat="server" Text="Start Again" Visible="false" OnClick="btn_StartAgain_Click" /> 
                        <a href="Login.aspx"><asp:Label ID="lbl_Login" runat="server" Text="Login " Visible="false"></asp:Label></a><asp:Label ID="lbl_OR" runat="server" Text="or " Visible="false"></asp:Label><a href="Signup.aspx"><asp:Label ID="lbl_SignUp" runat="server" Text="Signup " Visible="false"></asp:Label></a><asp:Label ID="lbl_alertSignIn" runat="server" Text="to Add to Cart." Visible="false"></asp:Label><asp:Label ID="lbl_alertQuantity" runat="server" Text="to be updated when quantity is stocked." Visible="false"></asp:Label>
                        <br />
                </tr>
            </table>
         
         
         
        </section>
</asp:Content>
