<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ArtStreet.Master" CodeBehind="CheckoutPage.aspx.cs" Inherits="ArtStreet.com.CheckoutPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <style type="text/css">
        
        .title-label{
            font-size:30px;
        }
        .title-container{
            text-align: center;
        }

        input[type="Text"] .backBtn{
            text-align:left; 
        } 
        .datalist{
            margin-left: 60px;
        }
        
        
        .auto-style8 {
            width: 168px;
        }
        
        
    </style>

    <div style="overflow-y: scroll; height: 200px; width: 80%; margin: 30px auto;">

        <div class="title-container">
            <u><asp:Label ID="Label1" runat="server" Text="Checkout Page" class="title-label"></asp:Label></u>
        </div>

        <table class="height: 300px;">
            <tr>
                <td class="">
                    <asp:Label ID="lblName" runat="server" Text="Buyer Name:"></asp:Label>
                </td>
                <td class="auto-style8">
                    <input id="Text1" type="text" /></td>
                <td rowspan="4" class="datalist-container">
                    <asp:DataList ID="DataList1" runat="server" class="datalist" Height="">
                        <ItemTemplate>
                            <table style="width:100%;border-bottom:1px solid grey">
                                <tr>
                                    <td rowspan="3">
                                        <img alt="" src="<%# Eval("artURL") %>" />
                                    </td>
                                    <td class="">Name of product:<%# Eval("productName") %></td>
                                </tr>
                                <tr>
                                    <td>Quantity:<%# Eval("quantity") %></td>
                                </tr>
                                <tr>
                                    <td class="">Current price:<%# Eval("currentPrice") %></td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:DataList>
                </td>
            </tr>
            <tr>
                <td class="total-item">
                    <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
                </td>
                <td class="auto-style8">
                    <input id="Text2" type="text" /></td>
            </tr>
            <tr>
                <td class="total-item">
                    <asp:Label ID="lblPhoneNo" runat="server" Text="Phone No:"></asp:Label>
                </td>
                <td class="auto-style8">
                    <input id="Text3" type="text" /></td>
            </tr>
            <tr>
                <td class="total-item">
                    <asp:Label ID="lblPayment" runat="server" Text="Select your payment method:"></asp:Label>
                </td>
                <td class="auto-style8">
                    </td>
            </tr>
        </table>

        <table class="total-item">
            <tr>
                <td class="total-item">
                    <asp:Label ID="lblCharge" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="total-item">
                    <asp:Label ID="lblTotal" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="total-item">
                    <asp:Button ID="chkoutBtn" runat="server" BackColor="Lime" Font-Size="Medium" Height="41px" Text="Checkout" Width="150px" />
                </td>
            </tr>
        </table>

        </div>
</asp:Content>
