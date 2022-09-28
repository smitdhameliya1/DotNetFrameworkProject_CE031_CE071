<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateSales.aspx.cs" Inherits="sales_management.CreateSales" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <asp:Label ID="Label7" runat="server" Text="product_name"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="product_name" DataValueField="product_name" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [product_name] FROM [product_table]"></asp:SqlDataSource>
        <br />
        product id&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="label_id" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="quantity available"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="label_quantity" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label9" runat="server" Text="quantity"></asp:Label>
&nbsp;
        <asp:TextBox ID="sales_quantity" runat="server" TextMode="Number" OnTextChanged="sales_quantity_TextChanged" AutoPostBack="True"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="label_validation_quantity" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label8" runat="server" Text="cost price"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="label_cost" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label10" runat="server" Text="sell price"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="label_sellprice" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="rate"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="sales_rate" runat="server" AutoPostBack="True" OnTextChanged="sales_rate_TextChanged"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" Text="total cost"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="label_totalcost" runat="server"></asp:Label>
        <br />
        <br />
        <br />
&nbsp;<asp:Button ID="Button1" runat="server" Text="Add Sales" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Back to homepage" />
    </form>
</body>
</html>
