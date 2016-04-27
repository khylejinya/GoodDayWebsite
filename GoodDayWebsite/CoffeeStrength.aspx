<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="~/CoffeeStrength.aspx.cs" Inherits="GoodDayWebsite.CoffeeStrength" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <section id="breadCrumbContent"> 
    <ol class="breadcrumb">
        <li><a href="#">Home</a></li>  
        <li class ="divider"> > </li>
        <li  class="current">Coffee Strength</li>
    </ol>
        </section>
    <section id="bodyContent">
        <div class="mainTitle"> Our Coffee Strength</div>
        <p id="description"> Many people find it useful to choose their coffees based on the strength 
            of the bean. Whilst the brewing method will of course also effect the strength of your coffee, 
            the fundamental flavour of the bean is key to selecting the right bean to suit your taste. 
            Simply select from the options below to view coffees categorised as strong, medium and mild.</p>

        
      <br />  <asp:LinkButton  ID="LB_AllCoffee" runat="server"  Text="All Coffees" onclick="LB_AllCoffee_Click" />
      <br />  <asp:LinkButton  ID="LB_StrongCoffee" runat="server"  Text="Strong Coffees" onclick="LB_StrongCoffee_Click" />
      <br />  <asp:LinkButton  ID="LB_MediumCoffee" runat="server"  Text="Medium Coffees" onclick="LB_MediumCoffee_Click" />
      <br />  <asp:LinkButton  ID="LB_MildCoffee" runat="server"  Text="Mild Coffees" onclick="LB_MildCoffee_Click" />

       
    </section>
</asp:Content>
