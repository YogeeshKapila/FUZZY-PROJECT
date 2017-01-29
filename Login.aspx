<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            text-align: center;
            font-size: large;
            font-family: Arial;
        }
        #form1
        {
            height: 28px;
        }
        .style2
        {
            width: 100%;
        }
        .style3
        {
            width: 465px;
            text-align: right;
        }
        .style4
        {
            width: 465px;
            height: 23px;
        }
        .style5
        {
            height: 23px;
        }
        .style6
        {
            width: 465px;
            height: 23px;
            text-align: right;
        }
        
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
            <div class="style1" style="background-color: #0000FF; color: #FFFFFF;"><strong>FUZZY SEARCHING OVER ENCRYPTED DATA IN CLOUD COMPUTING</strong></div><br />

            <table class="style2">
                <tr>
                    <td class="style3">
                        Username :</td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style6">
                        Password :</td>
                    <td class="style5">
                        <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style6">
                        User type :</td>
                    <td class="style5">
                        <asp:DropDownList ID="DropDownList1" runat="server">
                            <asp:ListItem Value="a">Admin</asp:ListItem>
                            <asp:ListItem Value="o">Other</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        &nbsp;</td>
                    <td class="style5">
                        <asp:Button ID="Button1" runat="server" Text="Submit" onclick="Button1_Click" />
                        <br />
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Red" 
                            Text="WRONG CREDENTIALS!" Visible="False"></asp:Label>
                    </td>
                </tr>
            </table>

    </form>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
</body>
</html>
