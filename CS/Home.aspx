<%@ Page Title="" Language="C#" MasterPageFile="~/CS/Client.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="PatelTeaSource.CS.Default" %>

<%--<asp:Content ID="Content5" ContentPlaceHolderID="menu" runat="server">
    <div id="navbar" class="navbar-collapse collapse">
        <ul class="nav navbar-nav">
            <li id="li_Home" class="active"><a href="Default.aspx">Home</a></li>
            <li id="li_Abt"><a href="AboutUs" onclick="makeChange(2)" id="abt">About Us</a>
               
            </li>
            <li id="li_Products"><a href="Products.aspx" onclick="makeChange(3)">Shop</a></li>
             <li id="li_Awards" ><a href="AwardsCertificate.aspx" onclick="makeChange(5)">Awards</a></li>
                        <li><a href="Contactus.aspx" onclick="makeChange(6)">Contact Us</a> </li>
            <li><a href="WhereToBuy.aspx" onclick="makeChange(7)">Locate Us</a> </li>
              <li id="li_MyAcc"><a href="MyAccount.aspx" >My Account</a>
            </li>
         
        </ul>
    </div>
</asp:Content>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <style>
        .myButton:hover {
        }
        /* generated element for shine effect.
 * normal state is semi-transparent
 * white but with zero width. Set no
 * transition here for no mouse-leave
 * animations. Otherwise the effect
 * will play in reverse when your mouse
 * leaves the element
 */
        .myButton:after {
            content: "";
            position: absolute;
            top: 0px;
            left: 0px;
            width: 0%;
            height: 100%;
            background-color: rgba(255,255,255,0.4);
            -webkit-transition: none;
            -moz-transition: none;
            -ms-transition: none;
            -o-transition: none;
            transition: none;
        }
        /* on hover we animate the width to
 * 100% and opacity to 0 so the element
 * grows and fades out
 */
        .myButton:hover:after {
            width: 120%;
            background-color: rgba(255,255,255,0);
            -webkit-transition: all 0.3s ease-out;
            -moz-transition: all 0.3s ease-out;
            -ms-transition: all 0.3s ease-out;
            -o-transition: all 0.3s ease-out;
            transition: all 0.3s ease-out;
        }

        body.modal-open .supreme-container {
            -webkit-filter: blur(1px);
            -moz-filter: blur(1px);
            -o-filter: blur(1px);
            -ms-filter: blur(1px);
            filter: blur(1px);
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="banner" runat="server">
    <!-- Banner -->
    <div id="banner">
        <div class="slider-wrapper">

            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>

        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <section id="infoUs" class="section infoUs supreme-container"
        style="background-image: url(../Template/images/paralax-right.png); background-position: right center; background-repeat: no-repeat;">
        <div class="container">
            <div class="row">
                <div class="col-sm-6 col-sm-push-6">

                    <figure>
                        <%--<img alt="" src="../Template/images/info-img-1.png" style="width:250px;height:600px" class="animated" data-animate="fadeInRight animation animation-delay-25" />
                        <img alt="" src="../Template/images/info-img-2.png" style="width:300px;height:600px" class="animated" data-animate="fadeInRight animation" />--%>

                        <%--<img alt="" src="../Template/images/Download/Kabuse.png" class="animated" style="width: 40%;" data-animate="fadeInRight animation animation-delay-25" />--%>
                        <img alt="" src="../Template/images/Download/Darjeeling-Leaf-Tea.png" class="animated" style="width: 40%;" data-animate="fadeInRight animation" />

                        <img alt="" src="../Template/images/Download/Gold-CTC-Orthodox-Blend-Image_6-600x600.jpg" style="width: 50%; margin-top: -1%; margin-left: 22%;" class="animated" data-animate="fadeInRight animation" />

                    </figure>

                </div>


                <div class="col-sm-6 col-sm-pull-6">
                    <h1 class="title line-title">Welcome to Patel Tea Packers<i class="fa">&#xf111;</i>
                    </h1>
                    <aside>

                        <p style="text-align: justify">
                            Patel Tea Packers is a Premium Tea Company, having presence in tea business since 1954.Patel Tea Packers, blends natural teas, along with organic teas. The Patel Tea enriches people with their various products of tea.  
                        </p>
                        <p style="text-align: justify">
                            While blending tea, every care is taken by Quality testers to make each cup add a refreshment and joy for the day. Tea buyers get the pure teas from the world’s finest tea quality and botanicals. By getting the pure tea from botanicals, the customers are able to take pure tea. We makes sure that the tea is tasted multiple times before it reaches the customers.     
                        </p>
                        <p style="text-align: justify">
                            Our process is carried out by the means of stringent quality control process,in modern automated factories with untouched hands under the supervision of a knowledgeable team of professionals.The end result is a high quality tea that connoisseurs the world over the acclaimed as the finest. 
                        </p>
                    </aside>
                </div>
            </div>
        </div>
    </section>

    <section id="latestMission" class="section section info-recipe" style="padding: 25px 0 50px !important">

        <div class="container">

            <div class="row">
                <div class="col-md-6">
                    <div class="col-sm-12" style="text-align: center">
                        <h1 class="title line-title">Our Mission<i class="fa">&#xf111;</i>
                        </h1>
                    </div>

                    <p style="text-align: justify">
                        Our mission is to be the most successful tea company in India, providing the most unique, healthy and ethical tea experience. In doing so, Patel Tea Packers will meet customer expectations of having the highest quality tea experience, while striving to meet our own expectations of the triple bottom line: People, Planet, Profit.
                    </p>
                </div>

                <div class="col-md-6">
                    <div class="col-sm-12" style="text-align: center">
                        <h1 class="title line-title">Our Vision<i class="fa">&#xf111;</i>
                        </h1>
                    </div>

                    <p style="text-align: justify">

                        <b>"To sustainably transform the Indian tea industry for the benefit of consumers, workers, farmers and the environment, by:</b>
                        <ul style="text-align: justify">
                            <li>Verifying tea producers against a world class sustainability code of conduct.</li>
                            <li>Working with tea industry to address key sustainability challenges such as food safety, stagnating yields, pest and disease control, living wages, worker welfare and equality".</li>
                        </ul>
                    </p>

                </div>
            </div>

        </div>
    </section>
    <section id="latest" class="section bulletproof" style="padding: 25px 0 50px !important">

        <div class="container">

            <div class="col-sm-12" style="text-align: center">
                <h1 class="title line-title">In The Spotlight<i class="fa">&#xf111;</i>
                </h1>
            </div>
            <div class="row">

                <div class="col-sm-6">
                    <figure class="animated" data-animate="fadeInLeft animation" style="margin-top: -42px !important; text-align: center !important">
                        <div class="myButton">
                            <img alt="" style="width: 35%; margin-top: 40px;" src="../Template/images/01.png" />
                            <img alt="" style="width: 35%; margin-top: 82px; transform: rotate(360deg);" src="../Template/images/02OurBrands.png" />
                        </div>

                    </figure>
                </div>
                <div class="col-sm-6">
                    <aside>
                        <h3 class="title"><b>PREMIUM LEAF Tea</b></h3>

                        <ul style="padding-left: 30px;">
                            <li>The Tea is made of quality Tea Leaves</li>
                            <li>Prepared by experienced Tea Tasters </li>
                            <li>Hygienically packed </li>
                            <li>Preferred choice of supreme consumers</li>
                            <li>No added perservatives</li>
                            <li><strong>Packaging size:</strong>  5rs, 10rs, 50gm, 100gm, 250gm, 500gm, 1kg </li>
                        </ul>

                    </aside>
                </div>
            </div>
            <h4 class="title">“A cup of tea would restore my normality. – Douglas Adams”</h4>
        </div>

    </section>
    <section id="bulletproof1" class="section bulletproof" style="padding: 25px 0 50px !important">

        <div class="container">

            <div class="col-sm-12" style="text-align: center; margin-top: -73px">
                <h1 class="title line-title">
                    <label style="color: white">In The Spotlight</label><i class="fa">&#xf111;</i>
                </h1>
            </div>
            <div class="row">

                <div class="col-sm-6">
                    <figure class="animated" data-animate="fadeInLeft animation" style="margin-top: -42px !important; text-align: center !important">
                        <div class="myButton">
                            <img alt="" style="width: 50%; margin-top: 31px; transform: rotate(352deg);" src="../Template/images/13.png" />
                            <img alt="" style="width: 35%; margin-top: 60px; margin-left: -14px; transform: rotate(360deg);" src="../Template/images/JD_250g.png" />
                        </div>
                    </figure>
                </div>
                <div class="col-sm-6">
                    <aside>
                        <h3 class="title"><b>FANNING TEA</b></h3>

                        <ul style="padding-left: 30px;">
                            <%--    
                            <li><strong>Brand:</strong> Patel Tea Packers  </li>
                            <li><strong>Packaging Size:</strong> 2rs, 5rs, 10rs, 20rs, 50gm, 100gm, 250gm, 500gm, 1kg </li>
                            <li><strong>Type:</strong>CTC</li>
                            <li>No Added Preservative</li>
                            <li>Botanically Tested</li>
                            <li>No Artifical Ingredients</li>--%>

                            <li>Fanning Tea is blend cut between leaf and dust</li>
                            <li>Fanning Tea offers strong taste, more cup and bright colour
                            </li>
                            <li>Hygienically packed </li>
                            <li>No added preservative</li>
                            <li>Blend that gives Strength and Aroma</li>
                            <li><strong>Packaging size:</strong> 3rs, 5rs, 10rs, 20rs, 50gm, 100gm, 250gm, 500gm, 1kg </li>

                        </ul>

                    </aside>
                </div>
            </div>
            <h4 class="title">“I am in no way interested in immortality, but only in the taste of tea. – Lu T’ung.”</h4>
        </div>

    </section>
    <section id="bulletproof" class="section bulletproof" style="padding: 25px 0 50px !important">

        <div class="container">

            <div class="col-sm-12" style="text-align: center; margin-top: -73px">
                <h1 class="title line-title">
                    <label style="color: white">In The Spotlight</label><i class="fa">&#xf111;</i>
                </h1>
            </div>
            <div class="row">

                <div class="col-sm-6">
                    <figure class="animated" data-animate="fadeInLeft animation" style="margin-top: -42px !important; text-align: center !important">
                        <div class="myButton">
                            <img alt="" style="width: 35%; margin-top: 40px;" src="../Template/images/Degalig500gOurBrands.png" />
                            <img alt="" style="width: 35%; margin-top: 82px; transform: rotate(360deg);" src="../Template/images/11.png" />
                        </div>
                    </figure>
                </div>
                <div class="col-sm-6">
                    <aside>
                        <h3 class="title">Dazzling (Strong Leaf Tea)</h3>
                        <ul style="padding-left: 30px;">


                            <%--                            <li><strong>Brand:</strong> Patel Tea Packers  </li>
                            <li><strong>Packaging Size:</strong> 10rs, 20rs, 100gm, 250gm, 500gm, 1kg </li>
                            <li><strong>Type:</strong>CTC</li>
                            <li>No Added Preservative</li>
                            <li>Botanically Tested</li>
                            <li>No Artifical Ingredients</li>--%>

                            <li>Dazzling Tea offers strong taste more cup and deep colour</li>
                            <li>Dazzling Tea is made from the tea garden of Assam</li>
                            <li>Blend that gives Strength and Aroma</li>
                            <li>Hygienically packed </li>
                            <li>No added preservative</li>
                            <li><strong>Packaging Size:</strong> 10rs, 20rs, 250gm, 500gm, 1kg , Pet Jar - 500gm and 1kg</li>
							 
                        </ul> 
						
						<br/>
						<div class="embed-responsive embed-responsive-16by9">
						<iframe class="embed-responsive-item" width="330" height="235" src="https://www.youtube.com/embed/ndv9XPNkhoE?rel=0" frameborder="0" allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>
						</div>
                    </aside>
                </div>
            </div>
            <h4 class="title">“There is something in the nature of tea that leads us into a world of quiet contemplation of life. – Lin Yutang”</h4>
        </div>

    </section>

    <section id="bulletproof12" class="section bulletproof" style="padding: 25px 0 20px !important">

        <div class="container">

            <div class="col-sm-12" style="text-align: center; margin-top: -13px">
                <h1 class="title line-title">" 5 Reasons to drink more Tea "<i class="fa">&#xf111;</i>
                </h1>
            </div>
        </div>
    </section>
    <section id="services" class="section services"
        style="background-image: url(../Template/images/Download/wsBack.jpg); background-repeat: no-repeat; background-position: center top; background-size: 100% auto;">

        <div class="container">
            <!-- 
					<ul class="service-effect">
						<li><img alt="" src="../images/home/services/service-1.png"  class="animated animation-duration-15" data-animate="fadeInLeft animation"></li>
						<li><img alt="" src="../images/home/services/service-2.png"  class="animated animation-duration-15" data-animate="fadeInDown animation"></li>
						<li><img alt="" src="../images/home/services/service-3.png"  class="animated animation-duration-15" data-animate="fadeInDown animation"></li>
						<li><img alt="" src="../images/home/services/service-4.png"  class="animated animation-duration-15" data-animate="fadeInDown animation"></li>
						<li><img alt="" src="../images/home/services/service-5.png"  class="animated animation-duration-15" data-animate="fadeInDown animation"></li>
						<li><img alt="" src="../images/home/services/service-6.png"  class="animated animation-duration-15" data-animate="fadeInRight animation"></li>
					</ul>-->
            <ul id="services-item">
                <li class="service">
                    <aside>
                        <div class="service-inner">
                            <h3>Antioxidants
                            </h3>
                            <p>Teas of all varieties contains high levels of antioxidants polyphenols.</p>
                        </div>
                    </aside>
                    <em class="animated animation infinite bullets"></em>
                </li>
                <li class="service">
                    <aside>
                        <div class="service-inner">
                            <h3>Less Caffine Than Coffee
                            </h3>
                            <p>Coffee usually has two to three times the caffeine of tea.</p>
                        </div>
                    </aside>
                    <em class="animated animation infinite bullets animation-delay-50"></em>
                </li>
                <li class="service">
                    <aside>
                        <div class="service-inner">
                            <h3>Calorie Free
                            </h3>
                            <p>Drinking tea in place of high calorie beverages can help you loose weight.</p>
                        </div>
                    </aside>
                    <em class="animated animation infinite bullets animation-delay-100"></em>
                </li>
                <li class="service">
                    <aside>
                        <div class="service-inner">
                            <h3>Aids In Digestion
                            </h3>
                            <p>Due to the high levels of tunnins it contains, tea makes a great after-meal digestive</p>
                        </div>
                    </aside>
                    <em class="animated animation infinite bullets animation-delay-150"></em>
                </li>
                <li class="service">
                    <aside>
                        <div class="service-inner">
                            <h3>Hydrating to the body
                            </h3>
                            <p>Despite the caffeine, tea can help you hydrated.</p>
                        </div>
                    </aside>
                    <em class="animated animation infinite bullets animation-delay-200"></em>
                </li>

            </ul>
        </div>
    </section>



    <div class="modal fade text-xs-left" id="backdrop" tabindex="-1" role="dialog" aria-labelledby="myModalLabel4" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header" style="padding: 18px 18px 0px 15px !important">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                    <h4 class="modal-title" id="myModalLabel4">Order Number
                            <asp:Label ID="lblOrderId" runat="server" Text="Label"></asp:Label></h4>

                </div>
                <div class="modal-body">
                    Subscribe here
                            
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn grey btn-outline-secondary" data-dismiss="modal">Close</button>

                    <asp:Button ID="btnUpdate" class="btn btn-outline-primary" runat="server" Text="Update" />
                </div>
            </div>
        </div>
    </div>


</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="footers" runat="server">

    <script>
        //$(window).on('load', function () {
        //    $('#backdrop').modal('show');
        //});
    </script>

</asp:Content>
