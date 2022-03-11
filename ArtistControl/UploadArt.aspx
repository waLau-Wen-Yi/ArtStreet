<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ArtStreet.Master" CodeBehind="UploadArt.aspx.cs" Inherits="ArtStreet.ArtistControl.UploadArt" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>

        .auto-style8 {
            width: 100%;
            height: 672px;
        }

        .auto-style9 {
            width: 398px;
            text-align: right;
        }

        .auto-style10 {
            text-align: right;
            margin-right:20px;
        }

    </style>
<div style="overflow-y: scroll; height: 669px; width: 80%; margin: 30px auto;">
    


    <table class="auto-style8">
        <tr>
            <td colspan="2" style="margin-left: auto; margin-right: auto; text-align: center;">
                <asp:Label ID="Label1" runat="server" Text="Upload Your Artwork" Font-Size="30px" width="100%" padding-left="50%" Font-Underline="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style9">Artist Name :&nbsp;&nbsp;&nbsp; </td>
            <td>
                <asp:TextBox ID="txtName" runat="server" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style9">
                
                Phone :&nbsp;&nbsp;&nbsp; </td>
            <td>
                
                <asp:TextBox ID="txtPhone" runat="server" Enabled="False"></asp:TextBox>
                
            </td>
        </tr>
        <tr>
            <td class="auto-style9">Email :&nbsp;&nbsp;&nbsp; </td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style9">Art Name :&nbsp;&nbsp;&nbsp;&nbsp; </td>
            <td>
                <asp:TextBox ID="txtArtName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style9">Upload your artwork (in URL) :&nbsp;&nbsp;&nbsp; </td>
            <td>
                <asp:TextBox ID="txtArt" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style9">Type :&nbsp;&nbsp;&nbsp; </td>
            <td>
                <asp:RadioButtonList ID="radioType" runat="server">
                    <asp:ListItem>Impressionism</asp:ListItem>
                    <asp:ListItem>Modernism</asp:ListItem>
                    <asp:ListItem>Abstract painting</asp:ListItem>
                    <asp:ListItem>Others</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td class="auto-style9">Art Collection (optional) :&nbsp;&nbsp;&nbsp; </td>
            <td>
                <asp:DropDownList ID="ddlCollection" runat="server" OnSelectedIndexChanged="ddlCollection_SelectedIndexChanged">
                    <asp:ListItem Value="Null">None</asp:ListItem>
                    <asp:ListItem>Brice Marden: Etchings</asp:ListItem>
                    <asp:ListItem>Christopher Wool: Posters</asp:ListItem>
                    <asp:ListItem>French Art Style</asp:ListItem>
                    <asp:ListItem>Middle Eastern Art Style</asp:ListItem>
                    <asp:ListItem>European Art Style</asp:ListItem>
                    <asp:ListItem>Alexander Calder: Jewelry</asp:ListItem>
                    <asp:ListItem>Art Inspired by Cartoons</asp:ListItem>
                    <asp:ListItem>Bearbrick</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style9">Art Genre :&nbsp;&nbsp;&nbsp; </td>
            <td>
                <asp:RadioButtonList ID="radioGenre" runat="server">
                    <asp:ListItem>History Painting</asp:ListItem>
                    <asp:ListItem>Portraiture</asp:ListItem>
                    <asp:ListItem>Genre Painting</asp:ListItem>
                    <asp:ListItem>Landscapes</asp:ListItem>
                    <asp:ListItem>Still Life</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td class="auto-style9">Art Price :&nbsp;&nbsp;&nbsp; </td>
            <td>
                RM
                <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style10" colspan="2">
    


    <asp:Button ID="submitBtn" runat="server" Height="50px" Text="Submit" ViewStateMode="Enabled" Width="133px" BackColor="Blue" ForeColor="White" OnClick="submitBtn_Click" PostBackUrl="~/ArtistControl/UploadArt.aspx"/>
    


            </td>
        </tr>
    </table>
    


    </div>
    </asp:Content>
