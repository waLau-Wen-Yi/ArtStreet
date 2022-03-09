<%@ Page Title="" Language="C#" MasterPageFile="~/ArtStreet.Master" AutoEventWireup="true" CodeBehind="AboutUs.aspx.cs" Inherits="ArtStreet.AboutUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .parallax {
          background-image: url("https://www.biography.com/.image/ar_16:9%2Cc_fill%2Ccs_srgb%2Cfl_progressive%2Cq_auto:good%2Cw_1200/MTI1NDg4NTg2MDAxODA1Mjgy/bob-ross-promojpg.jpg");

          min-height: 350px;

          background-attachment: fixed;
          background-position: center;
          background-repeat: no-repeat;
          background-size: cover;
        }

        .parallax1 {
          background-image: url("https://images.unsplash.com/photo-1596567181723-ba7d15eacefb?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=327&q=80");

          min-height: 250px;

          background-attachment: fixed;
          background-position: center;
          background-repeat: no-repeat;
          background-size: cover;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height: 560px; overflow-y: scroll;">
        <asp:Label ID="Label2" runat="server" Text="About Us"></asp:Label>
        <div class="parallax"></div>
        <div style="padding: 20px">
            <asp:Label ID="Label3" runat="server" Text="ArtStreet is a gallery website which focuses on the creativity of the people no matter what gender, races, nationality and more. ArtStreet always make sure everyone have a chance to reveal piece of their heART. This website aims to promote painting arts as this can reflect someone's emotion and make everyone express their emotion through this beautiful platform."></asp:Label>
        </div>
        <div class="parallax1"></div>
        <asp:DataList ID="DataList1" runat="server" CellPadding="10" DataSourceID="SqlDataSource1" HorizontalAlign="Center" RepeatColumns="2" RepeatDirection="Horizontal" Width="80%" OnSelectedIndexChanged="DataList1_SelectedIndexChanged">
            <ItemTemplate>
                <div style="border: 1px solid black; padding: 5px; width:300px;">
                    <img alt="profile picture" src='<%# Eval("credPicture") %>' style="width:100%; text-align:center;" />
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
