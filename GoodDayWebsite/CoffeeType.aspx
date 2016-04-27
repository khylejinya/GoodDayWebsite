<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="~/CoffeeType.aspx.cs" Inherits="GoodDayWebsite.CoffeeType" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <section id="breadCrumbContent"> 
    <ol class="breadcrumb">
        <li><a href="#">Home</a></li>  
        <li class ="divider"> > </li>
        <li  class="current">Coffee Types</li>
    </ol>
        </section>
    <section id="bodyContent">
        <div class="mainTitle"> Our Coffee Types</div>
        <p id="description"> We group our coffees into four categories - origin coffees are the more traditional types,
            including popular names such a Blue Mountain Jamaica, Dark Colombian and Kona Hawaii. 
            We even offer the extremely rare Kopi Luwak, one of the most sought-after and exclusive 
            coffees in the world. Our blends have been expertly constructed over the last 25 years to 
            offer some exquisite and flavoursome coffee options, with top secret combinations of coffees 
            from around the globe. For something a little different, why not try our flavoured coffees, 
            or enjoy coffee without the caffeine with our decaffeinated range.</p>

        
      <br />  <asp:LinkButton  ID="LB_AllCoffee" runat="server"  Text="All Coffees" onclick="LB_AllCoffee_Click" />
      <br />  <asp:LinkButton  ID="LB_BlendedCoffee" runat="server"  Text="Blended Coffees" onclick="LB_BlendedCoffee_Click" />
      <br />  <asp:LinkButton  ID="LB_DecafCoffee" runat="server"  Text="Decaffeinated Coffees" onclick="LB_DecafCoffee_Click" />
      <br />  <asp:LinkButton  ID="LB_FlavCoffee" runat="server"  Text="Flavoured Coffees" onclick="LB_FlavCoffee_Click" />
      <br />  <asp:LinkButton  ID="LB_OrigCoffee" runat="server"  Text="Origin Coffees" onclick="LB_OrigCoffee_Click" />

        
    <%--<br /><a href ="#">Blended Coffee</a>--%>
    <%--<br /><a href ="#">Decaffeinated Coffee</a>
    <br /><a href ="#">Flavoured Coffee</a>
    <br /><a href ="#">Origin Coffee</a>--%>
    </section>

    

    </asp:Content>