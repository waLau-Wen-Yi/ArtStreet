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
        .total-item{
            text-align: right;
        }
        
        
        .auto-style8 {
            height: 136px;
        }
        .auto-style9 {
            height: 81px;
        }
       
        
        
        .auto-style10 {
            text-align: right;
            width: 761px;
        }
       
        
        
        .auto-style11 {
            text-align: right;
            width: 207px;
        }
       
        
        
    </style>

    <div style="overflow-y: scroll; height: 200px; width: 80%; margin: 30px auto;">

        <div class="title-container">
            <u><asp:Label ID="Label1" runat="server" Text="Checkout Page" class="title-label"></asp:Label></u>
        </div>

        <table class="height: 300px;">
            <tr>
                <td class="auto-style11">
                    <asp:Label ID="lblName" runat="server" Text="Buyer Name:"></asp:Label>
                </td>
                <td class="auto-style9" id="txtName">
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </td>
                <td rowspan="4" class="datalist-container">
                    <asp:DataList ID="DataList1" runat="server" class="datalist">
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
                <td class="auto-style11">
                    <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style11">
                    <asp:Label ID="lblPhoneNo" runat="server" Text="Phone No:"></asp:Label>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txtPhoneNo" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style11">
                    <asp:Label ID="lblPayment" runat="server" Text="Select your payment method:"></asp:Label>
                </td>
                <td class="auto-style8">
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                        <asp:ListItem>Credit/Debit Card</asp:ListItem>
                    </asp:RadioButtonList>
                    </td>
            </tr>
        </table>

        <table class="auto-style10">
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
                    <asp:Button ID="chkoutBtn" runat="server" BackColor="Lime" Font-Size="Medium" Height="41px" Text="Checkout" Width="150px" OnClick="chkoutBtn_Click" />
                </td>
            </tr>
        </table>

        </div>
</asp:Content>
