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
using Dropbox.Api;
using Dropbox.Api.Auth;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dropbox.Api.Files;
using AppLimit.CloudComputing.SharpBox;
using AppLimit.CloudComputing.SharpBox.StorageProvider.DropBox;
using System.Web.Security;


public partial class _Default : System.Web.UI.Page
{
 //   private MySqlConnection connection;
   // private string server;
  //  private string database;
  //  private string uid;
   // private string password;
    SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\a\Documents\Visual Studio 2010\WebSites\Fuzzy\App_Data\Database.mdf;Integrated Security=True;User Instance=True");

    string passPhrase = "Pas5pr@se";        // can be any string
    string saltValue = "s@1tValue";        // can be any string
    string hashAlgorithm = "SHA1";             // can be "MD5"
    int passwordIterations = 2;                // can be any number
    string initVector = "@1B2c3D4e5F6g7H8"; // must be 16 bytes
    int keySize = 256;                // can be 192 or 128

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["utype"] == null)
        {
            Response.Redirect("~/Login.aspx");
        }

        

        
    }
   
    

  /*  protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            server = "192.168.1.35";
            database = "test";
            uid = "root";
            password = "major";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);

            MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM sahil.test", connection);
            connection.Open();
            DataSet ds = new DataSet();
            da.Fill(ds, "test");
            GridView1.DataSource = ds;
            GridView1.DataBind();
            connection.Close();
        }
        catch (Exception ex)
        {
            Label1.Text = ex.ToString();
        }
    }
    */
    protected void Button2_Click(object sender, EventArgs e)
    {
       // MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
       // MySqlCommand cmd = new MySqlCommand("INSERT INTO fuzzy.test VALUES(@fn,@fl)", con);
       // cmd.Parameters.AddWithValue("fn", TextBox1.Text);
     //   char a = Server.MapPath(FileUpload1.FileName);
       // cmd.Parameters.AddWithValue("fl", a);
        
       /* TEST 1
        * WebClient webClient = new WebClient();
        string sourceFilePath = @"C:\Users\a\Desktop\cet.txt";
        string webAddress = "http://localhost/uploads";
        string destinationFilePath = webAddress + "cet.txt";
        //webClient.Credentials = new System.Net.NetworkCredential("username", "password");
        webClient.UseDefaultCredentials = true;
        byte[] responseArray = webClient.UploadFile(destinationFilePath, "POST", sourceFilePath);
        webClient.Dispose(); */

      /*   TEST 2
       * string fileToUpload = "C:\\Users\\a\\Desktop\\old.txt";
        FileStream rdr = new FileStream(fileToUpload, FileMode.Open);
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost/uploads"); //Given URI     exists
        req.Method = "POST";
        req.ContentLength = rdr.Length;
        req.AllowWriteStreamBuffering = true;
        Stream reqStream = req.GetRequestStream();
        Console.WriteLine(rdr.Length);
        byte[] inData = new byte[rdr.Length];

        // Get data from upload file to inData 
        int bytesRead = rdr.Read(inData, 0, (int)rdr.Length);

        // put data into request stream
        reqStream.Write(inData, 0, (int)rdr.Length);
        rdr.Close();
        
                        
        req.GetResponse();
        
        // after uploading close stream 
        reqStream.Close(); 
        */
        /*
        NameValueCollection nvc = new NameValueCollection();
        long length = 0;
        string boundary = "----------------------------" +
        DateTime.Now.Ticks.ToString("x");


        HttpWebRequest httpWebRequest2 = (HttpWebRequest)WebRequest.Create("http://localhost/uploads");
        httpWebRequest2.ContentType = "multipart/form-data; boundary=" +
        boundary;
        httpWebRequest2.Method = "POST";
        httpWebRequest2.KeepAlive = true;
        httpWebRequest2.Credentials =
        System.Net.CredentialCache.DefaultCredentials;



        Stream memStream = new System.IO.MemoryStream();

        byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" +
        boundary + "\r\n");


        string formdataTemplate = "\r\n--" + boundary +
        "\r\nContent-Disposition: form-data; name=\"{0}\";\r\n{1}";

        foreach (string key in nvc.Keys)
        {
            string formitem = string.Format(formdataTemplate, key, nvc[key]);
            byte[] formitembytes = System.Text.Encoding.UTF8.GetBytes(formitem);
            memStream.Write(formitembytes, 0, formitembytes.Length);
        }


        memStream.Write(boundarybytes, 0, boundarybytes.Length);

        string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: text/plain\r\n";
        string files = "C://Users//a//Desktop//cet.txt";
        
            //string header = string.Format(headerTemplate, "file" + i, files[i]);
            string header = string.Format(headerTemplate, "uplTheFile", files);

            byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);

            memStream.Write(headerbytes, 0, headerbytes.Length);


            FileStream fileStream = new FileStream(files, FileMode.Open,
            FileAccess.Read);
            byte[] buffer = new byte[1024];

            int bytesRead = 0;

            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                memStream.Write(buffer, 0, bytesRead);

            }


            memStream.Write(boundarybytes, 0, boundarybytes.Length);


            fileStream.Close();
        

        httpWebRequest2.ContentLength = memStream.Length;

        Stream requestStream = httpWebRequest2.GetRequestStream();

        memStream.Position = 0;
        byte[] tempBuffer = new byte[memStream.Length];
        memStream.Read(tempBuffer, 0, tempBuffer.Length);
        memStream.Close();
        requestStream.Write(tempBuffer, 0, tempBuffer.Length);
        requestStream.Close();


        WebResponse webResponse2 = httpWebRequest2.GetResponse();

        Stream stream2 = webResponse2.GetResponseStream();
        StreamReader reader2 = new StreamReader(stream2);


     //   MessageBox.Show(reader2.ReadToEnd());
        Label2.Text = reader2.ReadToEnd();
        webResponse2.Close();
        httpWebRequest2 = null;
        webResponse2 = null;    
        */
        //Upload(Server.MapPath(FileUpload1.FileName));
     //   FileUpload1.SaveAs(Server.MapPath("Uploadedfiles\\"+FileUpload1.FileName));
       
     /*   FileUpload1.SaveAs(Server.MapPath(FileUpload1.FileName));
        string a = Server.MapPath(FileUpload1.FileName);
        string b = Server.MapPath(FileUpload1.FileName);
        encrypt64(a, b);
        Upload(b    ); */
       // SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\a\Documents\Visual Studio 2010\WebSites\Fuzzy\App_Data\Database.mdf;Integrated Security=True;User Instance=True");
     //   con.Open();
     //   SqlCommand cmd = new SqlCommand("INSERT INTO keywords VALUES(@fn,@key)",con);
     //   cmd.Parameters.AddWithValue("fn", TextBox1.Text);
       // cmd.Parameters.AddWithValue("key", TextBox2.Text);
       // cmd.ExecuteNonQuery();
       // con.Close();
      //  gen(TextBox2.Text,TextBox1.Text);
      //  dropboxup();
          //buildsharpbox();
         // dropboxup();
      //  CloudStorage dropboxstorage = new CloudStorage();
     //   DropBoxConfiguration config = CloudStorage.GetCloudConfigurationEasy(nSupportedCloudConfigurations.DropBox) as DropBoxConfiguration;
     //   config.AuthorizationCallBack = new Uri("http://localhost:11873/Fuzzy/admin.aspx");
     //   DropBoxRequestToken requestToken = DropBoxStorageProviderTools.GetDropBoxRequestToken(config, "0dqe4oviko1kxcs", "sagn9jy6kegufdz");
        
      //  String AuthorizationUrl = DropBoxStorageProviderTools.GetDropBoxAuthorizationUrl(config, requestToken);
    //    Response.Redirect(AuthorizationUrl.ToString());
        // DropBoxStorageProviderTools.ExchangeDropBoxRequestTokenIntoAccessToken ex = 
        //upload();

        /* BUTTON2_CLICK*/
        
        FileUpload1.SaveAs(Server.MapPath(FileUpload1.FileName));
        string filename = TextBox1.Text;
        string pathstring = @"C:\Users\a\Documents\Visual Studio 2010\WebSites\Fuzzy";
        pathstring = Path.Combine(pathstring, filename);
        var close = File.Create(pathstring + ".txt");
        close.Close();
        
       // Label2.Text = pathstring;
        using (Stream input = File.OpenRead(Server.MapPath(FileUpload1.FileName)))
        using (Stream output = new FileStream(pathstring + ".txt", FileMode.Append,
                                              FileAccess.Write, FileShare.None))
        {
            input.CopyTo(output);
        }
        //ENCRYPT TO 64
        byte[] asbytes = File.ReadAllBytes(pathstring + ".txt");
        string base64 = Convert.ToBase64String(asbytes);
        File.WriteAllText(pathstring + ".txt", base64);
        //UPLOAD TO DROPBOX
        CloudStorage dropboxstorage = new CloudStorage();
        DropBoxConfiguration config = CloudStorage.GetCloudConfigurationEasy(nSupportedCloudConfigurations.DropBox) as DropBoxConfiguration;
        ICloudStorageAccessToken access;
        using (var fss = File.Open(@"C:\Users\a\AppData\Local\Apps\2.0\K196XRQA.A6J\NQGYCOOJ.43R\drop..tion_a1128f7c65ce6ddb_0001.0000_f76ed57366d0fd5a\SharpDropBox.Token", FileMode.Open, FileAccess.Read, FileShare.None))
        {
            access = dropboxstorage.DeserializeSecurityToken(fss);
        }
        var storagetoken = dropboxstorage.Open(config, access);
        ICloudDirectoryEntry publicfolder = dropboxstorage.GetFolder("/Apps/Fuzzy/test");
        string src = Environment.ExpandEnvironmentVariables(pathstring + ".txt");

        dropboxstorage.UploadFile(src, publicfolder);
        dropboxstorage.Close(); 
       /* con.Open();
        SqlCommand cmd = new SqlCommand("DELETE FROM ngrams", con);
        cmd.ExecuteNonQuery();
        con.Close(); */
        gen(TextBox2.Text, filename);
        
       
    }

    public void gen(string keyw,string fname) 
    {
        
        string[] tokens = keyw.Split(' ');
        
       
        for(int i = 0; i < tokens.Length; i++)
        {
            string[] grams = new string[50];
            int v = 0;
            for(int j = 0; j < tokens[i].Length - 2; j++)
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
                    byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector); //Strings to byte arrays.
                    byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue); //used for hashing,  salt is random data that is used as an additional input to a one-way function that "hashes" a password or passphrase.
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
                    string cipher = Convert.ToBase64String(cipherTextBytes);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO ngrams VALUES(@fn,@gr)", con);
                    cmd.Parameters.AddWithValue("fn", fname);
                    cmd.Parameters.AddWithValue("gr", cipher);
                    cmd.ExecuteNonQuery();
                    con.Close();
                 /*   WORKING DECRYPTION 
                    byte[] cipherTextBytes2 = Convert.FromBase64String("0dGGulalIu8VWx5HtW2u5A==");
                    ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
                    MemoryStream memoryStream2 = new MemoryStream(cipherTextBytes2);
                    CryptoStream cryptoStream2 = new CryptoStream(memoryStream2, decryptor, CryptoStreamMode.Read);
                    byte[] plainTextBytes2 = new byte[cipherTextBytes2.Length];
                    int decryptedByteCount = cryptoStream2.Read(plainTextBytes2,0,plainTextBytes2.Length);
                    memoryStream2.Close();
                    cryptoStream2.Close();
                    string plain = Encoding.UTF8.GetString(plainTextBytes2, 0, decryptedByteCount);
                    Label2.Text = plain; */

                }
            }
            
        }
        

      

        
        /*for (int i = 0; i < (tokens.Length - 1); i++)
        {
            string s = "";
            int start = i;
            int end = i + 2;
            for (int j = start; j < end; j++)
            {
                s = s + "" + tokens[j];
            } */
           /* SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\a\Documents\Visual Studio 2010\WebSites\Fuzzy\App_Data\Database.mdf;Integrated Security=True;User Instance=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO ngrams VALUES(@fn,@ng)",con);
            cmd.Parameters.AddWithValue("fn",fname);
            cmd.Parameters.AddWithValue("ng",grams);
            cmd.ExecuteNonQuery();
            con.Close(); */
        }



    public void Upload(string Filetoup)
    {
        
        try
        {
        /*    // Get the object used to communicate with the server.
            
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://127.0.0.1/");
            request.Method = WebRequestMethods.Ftp.UploadFile;

            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential("vish", "vish");

            // Copy the entire contents of the file to the request stream.
            StreamReader sourceStream = new StreamReader(Filetoup);
            byte[] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
            sourceStream.Close();
            request.ContentLength = fileContents.Length;

            // Upload the file stream to the server.
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(fileContents, 0, fileContents.Length);
            requestStream.Close();

            // Get the response from the FTP server.
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            // Close the connection = Happy a FTP server.
            response.Close();

            // Return the status of the upload.
            // return response.StatusDescription; */

            /* APRIL'2016
            
            FtpWebRequest myFtpWebRequest; //An object for a communication request with the FTP server i.e. ftp://127.0.0.1.
            FtpWebResponse myFtpWebResponse; //.. For getting response from server
            StreamWriter myStreamWriter; //For writing characters 
            string random = Path.GetRandomFileName(); //RANDOMIZE FILE NAME FOR SECURITY PURPOSES.


            myFtpWebRequest = (FtpWebRequest)WebRequest.Create("ftp://127.0.0.1/" + random); //myFtpWebRequest = (FtpWebRequest)WebRequest.Create("ftp://127.0.0.1/"+FileUpload1.FileName);
            
            myFtpWebRequest.Credentials = new NetworkCredential("vish", "vish"); //ftp uname:vish, pass:vish

            myFtpWebRequest.Method = WebRequestMethods.Ftp.UploadFile; //For uploading a file
            myFtpWebRequest.UseBinary = true; //Data to be transferred is in binary. FOR IMAGE - TRUE, FOR TEXT - FALSE

            myStreamWriter = new StreamWriter(myFtpWebRequest.GetRequestStream()); //Get the stream object to write data.
            myStreamWriter.Write(new StreamReader(Server.MapPath(FileUpload1.FileName)).ReadToEnd()); // Read characters from byte stream 
            myStreamWriter.Close();

            myFtpWebResponse = (FtpWebResponse)myFtpWebRequest.GetResponse();

            Response.Write("Upload File Complete, status: " + myFtpWebResponse.StatusDescription);

            myFtpWebResponse.Close(); */



        }
        catch(WebException e)
        {
           // Label1.Text = ((FtpWebResponse)e.Response).StatusDescription;
        }
    }
    public void encrypt64(string inputFile, string outputFile) /* Convert file to be uploaded into bytes, then convert those bytes
                                                                into base64 string, then overwrite the file with the string*/
    {
        byte[] AsBytes = File.ReadAllBytes(inputFile);
        string base64 = Convert.ToBase64String(AsBytes);
        File.WriteAllText(outputFile, base64);
    }

    

    
    public ICloudStorageAccessToken buildsharpbox()
    {
        CloudStorage dropboxstorage = new CloudStorage();
        DropBoxConfiguration config = CloudStorage.GetCloudConfigurationEasy(nSupportedCloudConfigurations.DropBox) as DropBoxConfiguration;
        config.AuthorizationCallBack = new Uri("http://localhost:11873/Fuzzy/admin.aspx");
        DropBoxRequestToken requestToken = DropBoxStorageProviderTools.GetDropBoxRequestToken(config, "0dqe4oviko1kxcs", "sagn9jy6kegufdz");

        String AuthorizationUrl = DropBoxStorageProviderTools.GetDropBoxAuthorizationUrl(config, requestToken);
        Response.Redirect(AuthorizationUrl.ToString());
        // DropBoxStorageProviderTools.ExchangeDropBoxRequestTokenIntoAccessToken ex = 
        ICloudStorageAccessToken access;
        access = DropBoxStorageProviderTools.ExchangeDropBoxRequestTokenIntoAccessToken(config, "0dqe4oviko1kxcs", "sagn9jy6kegufdz", requestToken);
        var storagetoken = dropboxstorage.Open(config, access);
        FileStream fs = File.Open(Server.MapPath(FileUpload1.FileName),FileMode.Open,FileAccess.Read,FileShare.None);
        ICloudDirectoryEntry publicfolder = dropboxstorage.GetFolder("/Apps/Fuzzy/test");
        string src = Environment.ExpandEnvironmentVariables(Server.MapPath(FileUpload1.FileName));
        dropboxstorage.UploadFile(src, publicfolder);
        return access;
    }


    protected void Button4_Click(object sender, EventArgs e)
    {
        CloudStorage dropboxstorage = new CloudStorage();
        DropBoxConfiguration config = CloudStorage.GetCloudConfigurationEasy(nSupportedCloudConfigurations.DropBox) as DropBoxConfiguration;
        config.AuthorizationCallBack = new Uri("http://localhost:11873/Fuzzy/admin.aspx");
        DropBoxRequestToken requestToken = DropBoxStorageProviderTools.GetDropBoxRequestToken(config, "0dqe4oviko1kxcs", "sagn9jy6kegufdz");

        String AuthorizationUrl = DropBoxStorageProviderTools.GetDropBoxAuthorizationUrl(config, requestToken);
        Response.Redirect(AuthorizationUrl.ToString());
    }


    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        Session.Clear();
        Session.Abandon();
        Response.Redirect("~/login.aspx");
    }
}