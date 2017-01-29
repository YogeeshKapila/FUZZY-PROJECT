<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin.aspx.cs" Inherits="_Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            text-align: center;
            font-family: Arial;
            font-size: large;
        }
        .style2
        {
            width: 100%;
        }
        .style3
        {
            width: 473px;
            text-align: right;
            font-weight: 700;
        }
        .style4
        {
            width: 473px;
            text-align: right;
            height: 30px;
        }
        .style5
        {
            height: 30px;
        }
        .style6
        {
            width: 469px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <div class="style1" style="color: #FFFFFF; background-color: #0000FF"><strong>FUZZY SEARCHING OVER ENCRYPTED DATA IN CLOUD COMPUTING</strong></div><br />
        <table class="style2">
            <tr>
                <td class="style3" style="text-align: right">
                    &nbsp;</td>
                <td style="text-align: right">
                    <asp:LinkButton ID="LinkButton1" runat="server" Font-Size="Small" 
                        onclick="LinkButton1_Click">LOGOUT</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td class="style3" style="text-align: right">
                    <strong>Enter File Name :</strong></td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" Height="24px" Width="154px"></asp:TextBox>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3" style="text-align: right">
                    <strong>Enter keywords associated with the file 
                    (SEPARATE BY SPACE):</strong> </td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine"></asp:TextBox>
                    &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                        runat="server" ErrorMessage="Separate using spaces" 
                        ForeColor="Red" 
                        
                        ValidationExpression="^[a-zA-Z ]*$" 
                        ControlToValidate="TextBox2"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    <strong>Browse File :
                </strong>
                </td>
                <td class="style5">
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                    &nbsp;<br />
<br />
               </td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="Button2" runat="server" Text="Submit" onclick="Button2_Click" 
                        style="height: 26px" />
                    <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="Label" Visible="False"></asp:Label>
                    <br />
                 </td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        <br />
        
        <table class="style2">
            <tr>
                <td class="style6" style="text-align: right">
                    &nbsp;</td>
                <td style="text-align: left">
                    &nbsp;</td>
            </tr>
        </table>
        
        <br />
        <br />
        <br />
    
        <br />
        <br />
    
        <br />
        <br />
    
    </div>
    </form>
    
</body>
</html>
