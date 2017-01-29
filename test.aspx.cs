using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Net;
using System.IO;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Text;


public partial class test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(TextBox1.Text);
        Label1.Text = System.Convert.ToBase64String(plainTextBytes);
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        byte[] AsBytes = File.ReadAllBytes(FileUpload1.PostedFile.FileName.ToString());
        String AsBase64String = Convert.ToBase64String(AsBytes); //encrypt  

        Label1.Text = AsBase64String;
        /*
        byte[] tempBytes = Convert.FromBase64String(AsBase64String);
        File.WriteAllBytes(@"C:\Users\a\Desktop\newt2.txt", tempBytes);

        FileInfo orig = new FileInfo(@"C:\Users\a\Desktop\new.txt");
        FileInfo copy = new FileInfo(@"C:\Users\a\Desktop\newt2.txt");
        // Confirm that both original and copy file have the same number of bytes
      //  return (orig.Length) == (copy.Length);*/
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        EncryptFile(Server.MapPath("testdoc.txt"), Server.MapPath("New Text Document.txt"));
    }
    private void EncryptFile(string inputFile, string outputFile)
    {
        //byte[] AsBytes = File.ReadAllBytes(Server.MapPath(FileUpload1.FileName));
        //String AsBase64String = Convert.ToBase64String(AsBytes);
        string crypt = outputFile;
     //   FileStream fscypt = new FileStream(crypt, FileMode.Create);
      
     //   FileStream fsinp = new FileStream(inputFile, FileMode.Open);
        byte[] AsBytes = File.ReadAllBytes(inputFile);
        string base64 = Convert.ToBase64String(AsBytes);
        File.WriteAllText(outputFile, base64);
        
        /* UNICODE ENC IS WORKING vvvv.
        * try
        {
            string password = @"myKey123"; // Your Key Here
            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] key = UE.GetBytes(password);

            string cryptFile = outputFile;
         --   FileStream fsCrypt = new FileStream(cryptFile, FileMode.Create);

            RijndaelManaged RMCrypto = new RijndaelManaged();

            CryptoStream cs = new CryptoStream(fsCrypt,
                RMCrypto.CreateEncryptor(key, key),
                CryptoStreamMode.Write);

       --     FileStream fsIn = new FileStream(inputFile, FileMode.Open);

            int data;
            while ((data = fsIn.ReadByte()) != -1)
                cs.WriteByte((byte)data);


            fsIn.Close();
            cs.Close();
            fsCrypt.Close();
        }
        catch
        {
            Response.Write("Encryption failed!");
        } */
    }
}