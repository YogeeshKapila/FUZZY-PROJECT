<%@ Page Language="C#" AutoEventWireup="true" CodeFile="user.aspx.cs" Inherits="user" %>

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
            width: 611px;
            text-align: right;
            font-weight: 700;
        }
        .style4
        {
            height: 23px;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <div class="style1" style="color: #FFFFFF; background-color: #0000FF"><strong>FUZZY SEARCHING OVER ENCRYPTED DATA IN CLOUD COMPUTING</strong></div><br />
        </div>
    <table class="style2">
        <tr>
            <td class="style3">
                    &nbsp;</td>
            <td style="text-align: right">
                    <asp:LinkButton ID="LinkButton1" runat="server" Font-Size="Small" 
                        onclick="LinkButton1_Click">LOGOUT</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="style3">
                    <strong>Please enter some keywords for searching a file: </strong>
                </td>
            <td>
                    &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                    <asp:TextBox ID="TextBox1" runat="server" Height="22px" 
                        style="text-align: left; margin-left: 0px" Width="211px" 
                        TextMode="MultiLine"></asp:TextBox>
                </td>
            <td>
                    <br />
                    <br />
                    <asp:Button ID="Button1" runat="server" style="text-align: right" 
                        Text="Search" onclick="Button1_Click" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                        runat="server" ErrorMessage="Separate using spaces" 
                        ForeColor="Red" 
                        
                        ValidationExpression="^[a-zA-Z ]*$" 
                        ControlToValidate="TextBox1"></asp:RegularExpressionValidator>
                    <br />
                    <br />
                    <br />
                </td>
        </tr>
        <tr>
            <td class="style3">
                    Files associated with keyword from FUZZY SEARCHING (where jaccard &gt; 0 ): </td>
            <td>
                    &nbsp;</td>
        </tr>
    </table>
    <table class="style2">
        <tr>

            <td class="style4">
               
               <td style="text-align: center">
               <center>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" ForeColor="Black" GridLines="Horizontal" Height="232px" 
                    Width="309px" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" 
                        BorderWidth="1px"  
                        style="text-align: center" 
                        >
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#242121" />
<Columns>
<asp:TemplateField HeaderText="File Name">

    <ItemTemplate>
        <asp:Label ID="Label1" runat="server" Text='<%# Bind("[File Name]") %>'></asp:Label>
    </ItemTemplate>

</asp:TemplateField> 
</Columns>
                    </asp:GridView>
                    </center>
                </td>
        </tr>
    </table>
    </form>
</body>
</html>
