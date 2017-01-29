using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using Dropbox.Api.Files;
using AppLimit.CloudComputing.SharpBox;
using AppLimit.CloudComputing.SharpBox.StorageProvider.DropBox;
using Dropbox.Api;
using Dropbox.Api.Auth;
using System.Web.Security;
using System.Net;
public partial class user : System.Web.UI.Page
{
    string passPhrase = "Pas5pr@se";        // can be any string
    string saltValue = "s@1tValue";        // can be any string
    string hashAlgorithm = "SHA1";             // can be "MD5"
    int passwordIterations = 2;                // can be any number
    string initVector = "@1B2c3D4e5F6g7H8"; // must be 16 bytes
    int keySize = 256;                // can be 192 or 128
    SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\a\Documents\Visual Studio 2010\WebSites\Fuzzy\App_Data\Database.mdf;Integrated Security=True;User Instance=True");
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["utype"] == null)
        {
            Response.Redirect("~/Login.aspx");
        }
        
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        /*con.Open();
        SqlCommand cmd = new SqlCommand("DELETE FROM ugrams", con);
        cmd.ExecuteNonQuery();
        con.Close(); */
        gen(TextBox1.Text);
        search();
        //download();
    }
    public void download()
    {
        CloudStorage dropboxstorage = new CloudStorage();
        DropBoxConfiguration config = CloudStorage.GetCloudConfigurationEasy(nSupportedCloudConfigurations.DropBox) as DropBoxConfiguration;
        ICloudStorageAccessToken access;
        using (var fss = File.Open(@"C:\Users\a\AppData\Local\Apps\2.0\K196XRQA.A6J\NQGYCOOJ.43R\drop..tion_a1128f7c65ce6ddb_0001.0000_f76ed57366d0fd5a\SharpDropBox.Token", FileMode.Open, FileAccess.Read, FileShare.None))
        {
            access = dropboxstorage.DeserializeSecurityToken(fss);
        }
        var dt = dropboxstorage.Open(config, access);
        ICloudDirectoryEntry publicfolder = dropboxstorage.GetFolder("/Apps/Fuzzy/test");
      //  string sql = @"SELECT fname,jaccard FROM jaccard WHERE jaccard > 0 ORDERYBY jaccard DESC";
        DataTable datatable = new DataTable(); 
        
        
        string src = Environment.ExpandEnvironmentVariables(".txt");
        
    }
    public void search()
    {
        
       // DataTable dt = new DataTable();
        //SqlDataAdapter da = new SqlDataAdapter("SELECT distinct(ngrams.trigrams) AS 'ngramss' FROM ngrams JOIN ugrams ON ngrams.trigrams = ugrams.trigrams ", con);
        //SqlCommand cmd = new SqlCommand("SELECT count(distinct(ngrams.trigrams)) FROM ngrams JOIN ugrams ON ngrams.trigrams = ugrams.trigrams GROUP BY fname", con); 
        
       // SqlCommand cmd2 = new SqlCommand("SELECT ngrams.Fname FROM ngrams CROSS JOIN ugrams WHERE ngrams.trigrams = ugrams.trigrams",con);
        SqlCommand cmd2 = new SqlCommand("INSERT INTO mid SELECT count(distinct(ngrams.trigrams)) AS expr,fname AS fname FROM ngrams INNER JOIN ugrams ON ngrams.trigrams = ugrams.trigrams GROUP BY fname", con); // sahil1 - 8 sahil2 - 8 sahil3 - 8 xyz - 1, a intersection b for each file.

        SqlCommand cmd = new SqlCommand("SELECT count(*) FROM ugrams", con);

        con.Open();
        Int32 b = (Int32)cmd.ExecuteScalar();
        con.Close();

        SqlCommand cmd3 = new SqlCommand("INSERT INTO fora SELECT count(ngrams.trigrams) AS a, ngrams.fname AS fname FROM ngrams INNER JOIN mid ON ngrams.fname = mid.fname GROUP BY ngrams.fname", con);
        
        


        SqlCommand cmd5 = new SqlCommand("INSERT INTO forapb SELECT (a + @b) AS a_b, fora.fname AS fname FROM fora", con);
        cmd5.Parameters.AddWithValue("b", b);

        SqlCommand cmd6 = new SqlCommand("INSERT INTO denom SELECT (a_b - exp) AS a_b_mid, forapb.fname AS fname FROM forapb,mid WHERE forapb.fname = mid.fname", con);
        //SqlCommand cmd6 = new SqlCommand("INSERT INTO denom SELECT (forapb.a_b - mid.exp) FROM forapb,mid", con);

        SqlCommand cmd7 = new SqlCommand("INSERT INTO jaccard SELECT denom.fname AS fname,  (mid.exp / denom.a_b_mid) AS jaccard FROM mid,denom WHERE mid.fname = denom.fname", con);
        con.Open();
        // cmd.ExecuteNonQuery();
        cmd2.ExecuteNonQuery();
        cmd3.ExecuteNonQuery();
        // cmd4.ExecuteNonQuery();
        cmd5.ExecuteNonQuery();
        cmd6.ExecuteNonQuery();
        cmd7.ExecuteNonQuery();
        con.Close();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter("SELECT fname AS 'File Name' FROM jaccard", con);
        con.Open();
        da.Fill(dt);
        con.Close();
        if (dt.Rows.Count > 0)
        {
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        //SqlCommand cmd3 = new SqlCommand("SELECT count(ngrams.trigrams) FROM ngrams WHERE fname = ", con);

       
        //Label1.Text = cmd.ExecuteScalar().ToString();
        //Int32 count = (Int32)cmd.ExecuteScalar(); // matching n grams
        //Label1.Text = count.ToString();

       // SqlCommand cmd2 = new SqlCommand("SELECT count(ngrams.trigrams) UNION count(ugrams.trigrams) FROM ngrams,ugrams", con);
        /*da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        else
        {
            Label1.Text = "EMPTY";
        }*/ 
        con.Open();
        SqlCommand deletemid = new SqlCommand("DELETE FROM mid", con);
        SqlCommand deletefora = new SqlCommand("DELETE FROM fora", con);
        SqlCommand deleteforapb = new SqlCommand("DELETE FROM forapb", con);
        SqlCommand deletefordenom = new SqlCommand("DELETE FROM denom", con);
        SqlCommand deleteforjacc = new SqlCommand("DELETE FROM jaccard", con);
        deletemid.ExecuteNonQuery();
        deletefora.ExecuteNonQuery();
        deleteforapb.ExecuteNonQuery();
        deletefordenom.ExecuteNonQuery();
        deleteforjacc.ExecuteNonQuery();
        con.Close(); 
    }
    public void gen(string keyw)
    {
        con.Open();
        SqlCommand cmd2 = new SqlCommand("DELETE FROM ugrams",con);
        cmd2.ExecuteNonQuery();
        con.Close();
        string[] tokens = keyw.Split(' ');


        for (int i = 0; i < tokens.Length; i++)
        {
            string[] grams = new string[50];
            int v = 0;
            for (int j = 0; j < tokens[i].Length - 2; j++)
            {
                grams[j] = tokens[i].Substring(v, 3);
                v++;
            }
            foreach (string element in grams)
            {
                // string s = grams[k];
                if (element == null)
                    break;
                else
                {
                    byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
                    byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
                    byte[] plainTextBytes = Encoding.UTF8.GetBytes(element);
                    PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations);
                    byte[] keyBytes = password.GetBytes(keySize / 8);
                    RijndaelManaged symmetricKey = new RijndaelManaged();
                    symmetricKey.Mode = CipherMode.CBC;
                    ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
                    MemoryStream memoryStream = new MemoryStream();
                    CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                    cryptoStream.FlushFinalBlock();
                    byte[] cipherTextBytes = memoryStream.ToArray();
                    memoryStream.Close();
                    cryptoStream.Close();
                    string cipherText = Convert.ToBase64String(cipherTextBytes);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO ugrams VALUES(@ng)", con);
                    cmd.Parameters.AddWithValue("ng",cipherText);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
    }

    

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        Session.Clear();
        Session.Abandon();
        Response.Redirect("~/login.aspx");
    }
  /*  protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "dwn")
        {
            string file = Server.MapPath("~/" + e.CommandArgument);
        }
    }
 */   
       
}