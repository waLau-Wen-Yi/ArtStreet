<%@ Page Title="" Language="C#" MasterPageFile="~/ArtStreet.Master" AutoEventWireup="true" CodeBehind="AboutUs.aspx.cs" Inherits="ArtStreet.AboutUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .parallax {
            background-attachment: fixed;
            background-position: center;
            background-repeat: no-repeat;
            background-size: cover;
        }

        #palax1 {
            background-image: url("https://www.biography.com/.image/ar_16:9%2Cc_fill%2Ccs_srgb%2Cfl_progressive%2Cq_auto:good%2Cw_1200/MTI1NDg4NTg2MDAxODA1Mjgy/bob-ross-promojpg.jpg");
            min-height: 350px;
        }

        #palax2 {
            background-image: url("https://images.pexels.com/photos/1365168/pexels-photo-1365168.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940");
            min-height: 250px;
        }

        #palax3 {
            background-image: url("https://images.pexels.com/photos/5622348/pexels-photo-5622348.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940");
            min-height: 250px;
        }

        #palax4 {
            background-image: url("https://images.unsplash.com/photo-1517774622-3557d56f00bf?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=580&q=80");
            min-height: 250px;
        }

        .title {
            background-color: rgb(0,0,0);
            background-color: rgba(0,0,0, 0.4);
            color: white;
            font-weight: bold;
            font-size: 80px;
            border: 10px solid #f1f1f1;
            margin: 0 auto;
            position: relative;
            top: 70px;
            height: 50%;
            width: 300px;
        }

        .contentText {
            padding: 20px;
            font-size: 20px;
            font-weight: 200;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height: 560px; overflow-y: scroll;">
        <div id="palax1" class="parallax">
            <div class="title">About Us</div>
        </div>
        <div class="contentText">ArtStreet is a gallery website which focuses on the creativity of the people no matter what gender, races, nationality and more.</div>
        <div id="palax2" class="parallax"></div>
        <div class="contentText">ArtStreet always make sure everyone have a chance to reveal piece of their heART.</div>
        <div id="palax3" class="parallax"></div>
        <div class="contentText">This website aims to promote painting arts as this can reflect someone's emotion and make everyone express their emotion through this beautiful platform.</div>
        <div id="palax4" class="parallax"></div>


        <asp:DataList ID="DataList1" runat="server" CellPadding="10" DataSourceID="SqlDataSource1" HorizontalAlign="Center" RepeatColumns="2" RepeatDirection="Horizontal" Width="80%" OnSelectedIndexChanged="DataList1_SelectedIndexChanged">
            <ItemTemplate>
                <div style="border: 1px solid black; padding: 5px; width: 300px;">
                    <img alt="profile picture" src='<%# Eval("credPicture") %>' style="width: 100%; text-align: center;" />
                    <br />
                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("credCmt") %>'></asp:Label>
                    <hr />
                    <div style="float: right;">
                        <asp:Label ID="Label6" runat="server" Text='<%# "~ " + Eval("credName") + ", " + Eval("credPos") %>'></asp:Label>
                    </div>
                    <br />
                </div>
            </ItemTemplate>
        </asp:DataList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [credName], [credCmt], [credPos], [credPicture] FROM [tb_Credits]"></asp:SqlDataSource>

    </div>
</asp:Content>
