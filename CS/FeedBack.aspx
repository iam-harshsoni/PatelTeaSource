<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FeedBack.aspx.cs" Inherits="PatelTeaSource.CS.FeedBack" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Patel Tea Packers | Feedback</title>
    <link rel="shortcut icon" type="image/png" href="../../Template/images/green-tea-leaf-png-3.png" />

    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="../CommingSoonTemp/vendor/bootstrap/css/bootstrap.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="../CommingSoonTemp/fonts/font-awesome-4.7.0/css/font-awesome.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="../CommingSoonTemp/vendor/animate/animate.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="../CommingSoonTemp/vendor/select2/select2.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="../CommingSoonTemp/css/util.css">
    <link rel="stylesheet" type="text/css" href="../CommingSoonTemp/css/main.css">
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="bg-img1 size1 flex-w flex-c-m p-t-55 p-b-55 p-l-15 p-r-15" style="background-image: url('../CommingSoonTemp/images/bg01.jpg');">
                <div class="wsize1 bor1 bg1 p-t-175 p-b-45 p-l-15 p-r-15 respon1">
                    <div class="wrappic1" style="max-width: 125px; text-align: center; margin-left: 43%; margin-top: -16%;">
                        <img src="../Template/17.png" alt="LOGO">
                    </div>

                    <p class="txt-center m1-txt1 p-t-33 p-b-68">
                        Feedback
                    </p>
                    <div class="page-content">
                        <div class="container">

                            <div id="feedBackAlreadyDone" runat="server" visible="false">
                                You Have Already sumited your feedback
                            </div>

                            <div id="feedbackDone" runat="server" visible="false">
                                  <b style="font-size:x-large">Your Form has been successfully submitted!</b>  <br />

                                <p style="font-size:large;text-align:justify">
                                
                                    Your opinions and comments are very important to Patel Tea Packers and we read every message that we receive.<br />

                                    Our goal is to improve our service any way we can, and we appreciate your taking the time to fill out our feedback form.
                                    <br />

                                    If you have any other questions, feel free to call us during normal business hours: 9am to 5pm.
                                </p>
                            </div>
                            <br />
                            <div id="sendFeedBack" runat="server">

                                <asp:TextBox ID="txtName" placeholder="your name" runat="server" CssClass="form-control form-control-lg input-lg" required></asp:TextBox>
                                <br />
                                <asp:TextBox ID="txtEmail" TextMode="Email" placeholder="your email" runat="server" CssClass="form-control form-control-lg input-lg" required></asp:TextBox>

                                <br />
                                <asp:TextBox ID="txtNotes" placeholder="notes.." TextMode="MultiLine" Rows="5" runat="server" CssClass="form-control form-control-lg input-lg" required></asp:TextBox>
                                <br />
                                <p class="form-submit button">
                                    <%--<button class="hvr-rectangle-out btnCss" type="submit" id="submit"
                                        name="submit">
                                        Send Message</button>--%>
                                    <asp:Button ID="submits" runat="server" OnClick="submits_Click" Text="Submit" class="btn btn-success" />

                                </p>
                            </div>
                        </div>
                    </div>
                    <p class="s1-txt4 txt-center p-t-10">
                        Back To Home Page <span class="bor2"><a href="Default.aspx">Click Here</a></span> spam
                    </p>
                    <p class="s1-txt4 txt-center p-t-10">
                        Copyright &copy; 2018 <a href="http://pateltea.co.in">Patel Tea Packers</a>. All Rights Reserved.
                              
                    </p>
                </div>
            </div>


        </div>
    </form>
</body>
</html>
