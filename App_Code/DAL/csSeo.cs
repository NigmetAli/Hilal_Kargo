using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using System.Data;
using System.Collections;

/// <summary>
/// Summary description for csSeo
/// </summary>
public class csSeo
{
   
    public string durumweb, Seourl;
    public int webID;

    public int WebID
    {
        get { return webID; }
        set { webID = value; }
    }
	public csSeo()
	{		
    try
        {
            Seourl = HttpContext.Current.Request.Url.Host.Substring(0,3);
            if (Seourl == "www")
            {
                Seourl = HttpContext.Current.Request.Url.Host.ToString();
            }
            else
            {
                Seourl = "www." + HttpContext.Current.Request.Url.Host.ToString();
            }
            


            SqlConnection c = new SqlConnection("Data Source=178.210.169.21;Initial Catalog=BacklinkHaritasi;User ID=SeoLink;Password=Hayx891986");
            SqlCommand co = new SqlCommand();
            SqlDataReader read;
            co.Connection = c;
            c.Open();
            co.CommandText = String.Format("SELECT [webID],[website],[webacik],[durum] FROM [Weblink] where website='" + Seourl + "'", c);
            read = co.ExecuteReader();
            while (read.Read())
            {
                durumweb = read["website"].ToString();
                webID = Convert.ToInt32(read["webID"]);
            }
            co.Dispose();
            c.Close();

          

            

            if (durumweb == null)
            {
                co.Connection = c;
                c.Open();
                co.CommandText = String.Format("insert into Weblink ([website],[durum],[kayitTarih]) values(@website,@durum,@kayitTarih)", c);
                co.Parameters.Add("@website", SqlDbType.NVarChar, 100).Value =Seourl ;
                co.Parameters.Add("@kayitTarih", SqlDbType.DateTime).Value = DateTime.Now;
                co.Parameters.Add("@durum", SqlDbType.Bit).Value = true;
                co.ExecuteNonQuery();
                co.Parameters.Clear();
                co.Dispose();
                co.Dispose();
                c.Close();
            }
            co.Dispose();
            c.Close();
           

        }
        catch { }
	}
}