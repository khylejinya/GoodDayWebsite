<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GoodDayWebsite.Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <section id="home">
            	
        	<!--Slider-->
            <div class="full_slider">
                <div id="fullwidth_slider" class="flexslider">                	
                    <ul class="slides">
                        <li> 
                        	<div class="slideshow-overlay"></div>                                    
                            <img src="images/slider/1.jpg" alt="" class="slide_bg" />
                            <div class="full_slider_caption">
                                <div class="container">
                                	<div class="cont">
                                        <div class="title">Freshly Roasted
                                            <br /> Coffee..</div>
                                        <br>We roast over 100 varieties of coffee 
                                        <br>fresh to order.
                                    </div>
                                </div>                              
                            </div>                        
                        </li>
                        <li>
                        	<div class="slideshow-overlay"></div>
                            <img src="images/slider/2.jpg" alt="" class="slide_bg" />                            	
                            <div class="full_slider_caption">
                                <div class="container">
                                	<div class="cont">
                                        <div class="title">..Delivered Free To 
                                            <br /> To Your Door
                                        </div>
                                        <br>*Free Standard UK Delivery on order over £20
                                    </div>
                                </div>
                            </div>
                        </li>                                           
                    </ul>
                </div>
             </div>          
            <!--//Slider-->            
        </section>
        <!-- //end home content -->
        <!-- Tab Section -->
        <!-- // end tab section -->
        <!-- booking section -->
        <div class="color-container">
            <div class="container">
                <div class="goodDay" id="title1">
                <div class="row">
                    <div class="col-md-12">
                         <div class="mainTitle"> 
                            Freshly Roasted Coffee Beans, Delivered.
                             </div>
                                <p>Welcome to GoodDayCoffee.co.uk. We roast over 100 wonderful coffees from around the world, including rare and exclusive varieties such as Kopi Luwak and Blue Mountain Jamaica, and deliver them directly to your door. We roast to order, so your coffee will always arrive in the freshest condition possible, and offer a range of grind options as well as whole beans. We also offer a sumptuous range of teas, as well as our ever-popular coffee gift hampers.</p>
                               </div>
                                  </div>
                                </div>
                        </div>
                    </div>
                    
        <!-- portfolio content-->
        <section class="page_section" id="portfolio">
            <!-- section header -->
            <header class="head_section center_section">
                <div class="container">
                    <h2>Our Awesome Coffees</h2>
                    <div class="separator"></div>
                    <p>It's world class coffee that's traditionally roasted and posted the same day for an unbelievable fresh taste.</p>
                </div><!-- end .container -->
</header>
            <!-- //section header --> 
            
            <!-- section content --> 
            <div class="portfolio-block">           
                <div class="container wow fadeInUp">
                    <ul class="portfolio-menu" id="filters">
                        <li class="active"><a data-filter="*">All</a></li>
                        <li><a data-filter=".fly">Types</a></li>
                        <li><a data-filter=".hotel">Strength</a></li>
                        <li><a data-filter=".air">Brewing Methods</a></li>
                    </ul>
                    <div class="row portfolio-list image-grid">
                        <div class="item col-md-4 col-sm-4 col-xs-12 car">
                            <a href="ListCoffees.aspx?coffeeType=All">
                                <img src="images/Home/AllCoffees.jpg" alt="">
                                <div class="caption">
                                    <div class="info">
                                        <h4>All Coffees</h4>
                                        <div class="separator"></div>
                                        <p>Select from our coffee list.</p>
                                    </div>
                                </div>
                            </a>
                        </div>
                        <div class="item col-md-4 col-sm-4 col-xs-12 fly">
                            <a href="ListCoffees.aspx?coffeeType=Blended">
                                <img src="images/Home/BlendCoffee.jpg" alt="">
                                <div class="caption">
                                    <div class="info">
                                        <h4>Blend Coffees</h4>
                                        <div class="separator"></div>
                                        <p>Insert details.</p>
                                    </div>
                                </div>
                            </a>
                        </div>
                        <div class="item col-md-4 col-sm-4 col-xs-12 fly">
                            <a href="ListCoffees.aspx?coffeeType=Decaffeinated">
                                <img src="images/Home/DecafCoffee.jpg" alt="">
                                <div class="caption">
                                    <div class="info">
                                        <h4>Decaffeinated Coffees</h4>
                                        <div class="separator"></div>
                                        <p>Insert details.</p>
                                    </div>
                                </div>
                            </a>
                        </div>
                        <div class="item col-md-4 col-sm-4 col-xs-12 fly">
                            <a href="ListCoffees.aspx?coffeeType=Flavoured">
                                <img src="images/Home/FlavouredCoffee.jpg" alt="">
                                <div class="caption">
                                    <div class="info">
                                        <h4>Flavoured Coffees</h4>
                                        <div class="separator"></div>
                                        <p>Insert details.</p>
                                    </div>
                                </div>
                            </a>
                        </div>
                        <div class="item col-md-4 col-sm-4 col-xs-12 fly">
                           <a href="ListCoffees.aspx?coffeeType=Origin">
                                <img src="images/Home/originCoffee.jpg" alt="">
                                <div class="caption">
                                    <div class="info">
                                        <h4>Origin Coffees</h4>
                                        <div class="separator"></div>
                                        <p>Insert details.</p>
                                    </div>
                                </div>
                            </a>
                        </div>
                        <div class="item col-md-4 col-sm-4 col-xs-12 hotel">
                            <a href="images/1.jpg" class="prettyPhoto" data-rel="prettyPhoto[portfolio55]">
                                <img src="images/Home/AllCoffees.jpg" alt="">
                                <div class="caption">
                                    <div class="info">
                                        <h4>Strong Coffees</h4>
                                        <div class="separator"></div>
                                        <p>Insert details.</p>
                                    </div>
                                </div>
                            </a>
                        </div>
                        <div class="item col-md-4 col-sm-4 col-xs-12 hotel">
                            <a href="images/1.jpg" class="prettyPhoto" data-rel="prettyPhoto[portfolio55]">
                                <img src="images/Home/AllCoffees.jpg" alt="">
                                <div class="caption">
                                    <div class="info">
                                        <h4>Medium Coffees</h4>
                                        <div class="separator"></div>
                                        <p>Insert details.</p>
                                    </div>
                                </div>
                            </a>
                        </div>
                        <div class="item col-md-4 col-sm-4 col-xs-12 hotel">
                            <a href="#" class="prettyPhoto" data-rel="prettyPhoto[portfolio55]">
                                <img src="images/Home/AllCoffees.jpg" alt="">
                                <div class="caption">
                                    <div class="info">
                                        <h4>Mild Coffees</h4>
                                        <div class="separator"></div>
                                        <p>Insert details</p>
                                    </div>
                                </div>
                            </a>
                        </div>
                        <div class="item col-md-4 col-sm-4 col-xs-12 air">
                            <a href="images/1.jpg" class="prettyPhoto" data-rel="prettyPhoto[portfolio55]">
                                <img src="images/Home/AllCoffees.jpg" alt="">
                                <div class="caption">
                                    <div class="info">
                                        <h4>Brewing Methods</h4>
                                        <div class="separator"></div>
                                        <p>Insert details.</p>
                                    </div>
                                </div>
                            </a>
                        </div>
                    </div>
                    <div class="app-item"><a class="shortcode_button add-item">Load More</a></div>  
                </div>                                                                    
			</div>
            <!-- //section content -->    
        </section>
        <!-- //end portfolio content-->
        <!-- map section-->
        <div class="map-canvas">
            <iframe src="https://www.google.com/maps/embed?pb=!1m16!1m12!1m3!1d193572.00379171042!2d-73.97800350000001!3d40.70563080000002!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!2m1!1s87-89+E+4th+St%2C+New+York%2C+NY+10003%2C+Stati+Uniti!5e0!3m2!1sit!2sit!4v1416499866904">
            </iframe>
        </div>
        <!-- /end map section -->
    </asp:Content>