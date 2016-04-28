<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddToCart.aspx.cs" Inherits="GoodDayWebsite.AddToCart" %>
<asp:Content ID="BodyContent1" ContentPlaceHolderID="MainContent" runat="server">

    <section id="bodyContent">
        <div class="mainTitle"><asp:Label ID="lbl_AddtoCart" runat="server" Text="My Shopping Cart"></asp:Label></div>
        <div class ="shoppingCartTable">
        <asp:ListView ID="lvCustomers" runat="server" GroupPlaceholderID="groupPlaceHolder1"
                ItemPlaceholderID="itemPlaceHolder1" OnPagePropertiesChanging="OnPagePropertiesChanging" 
            OnItemDeleting="lvCustomers_ItemDeleting" OnItemUpdating="lvCustomers_ItemUpdating">
            <EmptyDataTemplate>
                        <table class="shoppingCart">
                            <tr>
                                <td>Continue shopping <a href="CoffeeType.aspx">here</a>.</td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                    <EmptyItemTemplate>
                        <td/>
                    </EmptyItemTemplate>    
            <LayoutTemplate>
                    <table style="width: 100%">
                        <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>
                       <%-- <tr>
                            <td style="text-align:center" width: 100%">
                                <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lvCustomers" PageSize="10">
                                    <Fields>
                                        <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="false" ShowPreviousPageButton="true"
                                            ShowNextPageButton="false" />
                                        <asp:NumericPagerField ButtonType="Link" />
                                        <asp:NextPreviousPagerField ButtonType="Link" ShowNextPageButton="true" ShowLastPageButton="false" ShowPreviousPageButton = "false" />
                                    </Fields>
                                </asp:DataPager>
                            </td>
                        </tr>--%>
                    </table>
                </LayoutTemplate>
                <GroupTemplate>
                    <tr>
                        <asp:PlaceHolder runat="server" ID="itemPlaceHolder1"></asp:PlaceHolder>
                    </tr>
                </GroupTemplate>
                <ItemTemplate>
                    <td style="width: 20%">
                        <img src="/images/Coffee/<%# Eval("CoffeeImageLoc") %>"
                                                width="200" height="250"/></a>
                    </td>
                    <td style="width: 20%">
                        <a href="viewCoffee.aspx?coffeeID=<%# Eval("CoffeeId")%>">
                                            <span>
                                               <asp:Label ID="cartID" runat="server" Text='<%# Eval("Id") %>' Visible="false"></asp:Label>
                                               <asp:Label ID="coffeeName" runat="server" Text='<%# Eval("CoffeeName") %>'></asp:Label>
                                            </span>
                                        </a>
                        <br />
                        <asp:Label ID="coffeeGrind" runat="server" Text='<%# Eval("Grind") %>'></asp:Label>
                    </td>
                    <td style="text-align:right" width: 30%">
                        <asp:TextBox ID="txt_Quantity" runat="server" Text='<%# Eval("Quantity") %>'></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txt_Quantity" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+"></asp:RegularExpressionValidator>

                    </td>
                    <td style="text-align:right" width: 10%">
                       <asp:Label ID="coffeePrice" runat="server" Text='<%# Eval("Price") %>' CssClass="coffeePrice"></asp:Label> 
                    </td>
                    <td style="text-align:right" width: 20%">
                       <asp:Button ID="btn_Delete" CommandName="Delete" Text="Remove" runat="server" />
                        <asp:Button ID="btn_Update" CommandName="Update" Text="Update" runat="server" />
                    </td>
                </ItemTemplate>
                </asp:ListView>
            </div>
        <div class="cartSubTotal">SubTotal: &nbsp; &nbsp;<asp:Label ID="lbl_subTotal" runat="server" CssClass="coffeePrice"></asp:Label>
            <br /> <asp:Button ID="btn_Checkout" Text="Checkout" runat="server" OnClick="btn_Checkout_Click"/>
        </div> 
     <br />    
        
    </section>
</asp:Content>
