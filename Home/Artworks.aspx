<%@ Page Title="" Language="C#" MasterPageFile="~/ArtStreet.Master" AutoEventWireup="true" CodeBehind="Artworks.aspx.cs" Inherits="ArtStreet.Home.Artworks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="overflow-y: scroll; height: 550px;">
        <asp:DataList ID="DataList1" runat="server" DataKeyField="artID" DataSourceID="SqlDataSource1" RepeatColumns="3" Width="738px" RepeatDirection="Horizontal">
            <ItemTemplate>
                <div style="border: solid 1px black; padding: 10px; margin: 5px;">
                    <img alt="" src="<%# Eval("artURL") %>" style="width: 335px;" />
                    <br />
                    <asp:Label ID="artIDLabel" runat="server" Text='<%# Eval("artID") %>' />
                    :
                    <asp:Label ID="artNameLabel" runat="server" Text='<%# Eval("artName") %>' />
                    <p style="font-style: italic; line-height:1px;">
                        created by
                    </p>
                    <asp:Label ID="artistIDLabel" runat="server" Text='<%# Eval("artistID") %>' />
                    &nbsp;<div style="font-style: italic; display:inline-block;">on</div>
                    &nbsp;<asp:Label ID="artCreateTimeLabel" runat="server" Text='<%# Eval("artCreateTime") %>' />
                    <p style="font-style: italic; line-height:1px; text-decoration: underline;">
                        Collection
                    </p>
                    <asp:Label ID="artCollectionLabel" runat="server" Text='<%# Eval("artCollection") %>' />
                    <hr />
                    <asp:Label ID="artTypeLabel" runat="server" Text='<%# Eval("artType") %>' />
                    &nbsp;| <asp:Label ID="artGenreLabel" runat="server" Text='<%# Eval("artGenre") %>' />
                    <br />
                    <br />
                    <asp:Button ID="btn_addCart" runat="server" OnClientClick="confirm_addCart()" OnClick="btn_addCart_Click" Text="Add into cart" />
                </div>
                <br />
            </ItemTemplate>
        </asp:DataList>
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [tb_Art]"></asp:SqlDataSource>
    <script type="text/Javascript" language="javascript">  
        function confirm_addCart() {

            if (confirm('You will add this item into the cart?')) {
                <%addCart_Confirm();%>
            }
            else {
               You have cancel the action: Add item to cart to cart");
            }
        }
    </script>
</asp:Content>
