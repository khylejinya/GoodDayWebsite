<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="~/ListCoffees.aspx.cs" Inherits="GoodDayWebsite.AllCoffees" %>
<script runat=server>
    </script>
<asp:Content ID="BodyContent1" ContentPlaceHolderID="MainContent" runat="server">
    <section id="breadCrumbContent"> 
    <ol class="breadcrumb">
        <li><a href="Default.aspx">Home</a></li>  
        <li class ="divider"> > </li>
        <li  class="current"><asp:Label ID="lbl_breadcrumbCurrent" runat="server" Text="All"></asp:Label> 
        Coffees</li>
    </ol>
        </section>
    <section id="bodyContent">
        <div class="mainTitle"><asp:Label ID="lbl_CoffeeType" runat="server" Text="Coffee Type"></asp:Label> Coffees</div>
        <div class="sortBy"> Sort by: <asp:DropDownList ID="ddl_SortBy" runat="server" OnSelectedIndexChanged="ddl_SortBy_SelectedIndexChanged" AutoPostBack="true" CssClass="sortByBox">
                              <asp:ListItem Selected="True" Value="A-Z"> Alphabetically, A-Z </asp:ListItem>
                              <asp:ListItem Value="Z-A"> Alphabetically, Z-A </asp:ListItem>
                              <asp:ListItem Value="Low-High"> Price, Low-High </asp:ListItem>
                              <asp:ListItem Value="High-Low"> Price, High-Low </asp:ListItem>
                              <asp:ListItem Value="Mild-Strong"> Strength, Mild-Strong </asp:ListItem>
                              <asp:ListItem Value="Strong-Mild"> Strength, Strong-Mild </asp:ListItem>
                              <asp:ListItem Value="Origin"> Origin </asp:ListItem>
                        </asp:DropDownList></div>
        
        <asp:ListView ID="LVcoffees" runat="server" GroupPlaceholderID="groupPlaceHolder" ItemPlaceholderID="itemPlaceHolder" GroupItemCount="4">
                <EmptyDataTemplate>
                        <table >
                            <tr>
                                <td>No data was returned.</td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                    <EmptyItemTemplate>
                        <td/>
                    </EmptyItemTemplate>
                    <GroupTemplate>
                        <tr id="itemPlaceholderContainer" runat="server">
                            <td id="itemPlaceholder" runat="server"></td>
                        </tr>
                    </GroupTemplate>
                    <ItemTemplate>
                        <td runat="server">
                            <table>
                                <tr>
                                    <td>
                                            <img src="/images/Coffee/<%# Eval("CoffeeImageLoc") %>"
                                                width="200" height="250"/></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <a href="viewCoffee.aspx?coffeeID=<%# Eval("CoffeeId")%>">
                                            <span>
                                                <%# Eval("CoffeeName") %>
                                            </span>
                                        </a>
                                        <br />
                                        <span>
                                            <b>Price: </b><%#:String.Format("{0:c}", Eval("CoffeePrice"))%>
                                        </span>
                                        <br />
                                        <span>
                                            <b>Strength: </b><%# Eval("CoffeeStrength")%>
                                        </span>
                                        <br />
                                        <span>
                                            <asp:LoginView ID="LoginView1" runat="server">
                                                <AnonymousTemplate>
                                            <b>Quantity: </b>(Login to check stock quantity)
                                            </AnonymousTemplate>
                                                <LoggedInTemplate>
                                                    <b>Quantity: </b><%# Eval("CoffeeQuantity")%> in stock
                                                </LoggedInTemplate>
                                                </asp:LoginView>
                                        </span>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>
                            </p>
                        </td>
                    </ItemTemplate>
                    <LayoutTemplate>
                        <table style="width:100%;">
                            <tbody>
                                <tr>
                                    <td>
                                        <table id="groupPlaceholderContainer" runat="server" style="width:100%">
                                            <tr id="groupPlaceholder"></tr>
                                        </table>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </LayoutTemplate>
        </asp:ListView>
        
        <br />

        </section>
    
</asp:Content>

