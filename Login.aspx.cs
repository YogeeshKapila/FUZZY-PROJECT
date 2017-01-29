using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Visible = false;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\a\Documents\Visual Studio 2010\WebSites\Fuzzy\App_Data\Database.mdf;Integrated Security=True;User Instance=True");
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT * FROM Master_Login WHERE uname=@u AND password=@p AND utype=@ut", con);
        cmd.Parameters.AddWithValue("u", TextBox1.Text);
        cmd.Parameters.AddWithValue("p", TextBox2.Text);
        cmd.Parameters.AddWithValue("ut", DropDownList1.SelectedValue.ToString());
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        cmd.ExecuteReader();
        con.Close();

        if (dt != null && dt.Rows.Count > 0) //If login table not empty then do the following
        {
            string utype = DropDownList1.SelectedValue.ToString();
            Session["utype"] = DropDownList1.SelectedItem.ToString();

            if (utype == "a")
            {
                Response.Redirect("~/admin.aspx");
            }
            else if (utype == "o")
            {
                Response.Redirect("~/user.aspx");
            }
        }
        else
        {
            Label1.Visible = true;  
        }
    }
}