
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Xml;
using System.Configuration;
using System.Web;
using System.Linq;
using System.Net.Mail;
using System.Web.UI;

public static class ClassDAL
{

    #region baglantı
    //private static OleDbConnection baglanti;
    public static void BaglantiyiAc(OleDbConnection baglanti)
    {
        try
        {
            if (baglanti.State != ConnectionState.Open)
                baglanti.Open();
        }
        catch (Exception exc)
        {
            baglanti.Dispose();
        }
    }
    public static void BaglantiyiKapat(OleDbConnection baglanti)
    {
        try
        {
            if (baglanti != null && baglanti.State != ConnectionState.Closed)
                baglanti.Close();
        }
        catch
        {
            throw;
        }
        finally
        {
            baglanti.Dispose();
        }
    }
    public static OleDbConnection AcikBaglantiGetir()
    {
        OleDbConnection baglanti = new OleDbConnection();
        string connectionString = GetConnectionString();
        baglanti.ConnectionString = connectionString;
        BaglantiyiAc(baglanti);
        return baglanti;
    }
    public static OleDbConnection AcikBaglantiGetir(string BaglantiAdi)
    {
        OleDbConnection baglanti = new OleDbConnection();
        string connectionString = GetConnectionString(BaglantiAdi);
        baglanti.ConnectionString = connectionString;
        BaglantiyiAc(baglanti);
        return baglanti;
    }
    public static OleDbConnection BaglantiGetir(string BaglantiAdi)
    {
        OleDbConnection baglanti = new OleDbConnection();
        string connectionString = GetConnectionString();
        baglanti.ConnectionString = connectionString;
        return baglanti;
    }
    public static OleDbConnection BaglantiGetir()
    {
        OleDbConnection baglanti = new OleDbConnection();
        string connectionString = GetConnectionString();
        baglanti.ConnectionString = connectionString;
        return baglanti;
    }
    public static string GetConnectionString()
    {
        string dil = (string)HttpContext.Current.Session["dil"];

        if (dil == null || dil == "tr")
            return "Provider=Microsoft.Jet.OleDb.4.0; Data Source=" + HttpContext.Current.Server.MapPath("~/App_Data\\panel.mdb");
        else
            return "Provider=Microsoft.Jet.OleDb.4.0; Data Source=" + HttpContext.Current.Server.MapPath("~/en/App_Data\\panel.mdb");

    }
    public static string GetConnectionString(string BaglantiAdi)
    {
        return ConfigurationManager.ConnectionStrings["BaglantiAdi"].ConnectionString;
    }
    #endregion
    public static int Execute(OleDbCommand komut)
    {
        int donusDegeri = -1;
        OleDbConnection baglanti = AcikBaglantiGetir();
        try
        {
            komut.Connection = baglanti;
            komut.ExecuteNonQuery();
            donusDegeri = 0;
        }
        catch (Exception exc)
        {
        }
        finally
        {
            BaglantiyiKapat(baglanti);
        }
        return donusDegeri;
    }
    public static Result<int> ExecuteWithResult(OleDbCommand komut)
    {
        Result<int> sonuc = new Result<int>(-1);
        int donusDegeri = -1;
        OleDbConnection baglanti = AcikBaglantiGetir();
        try
        {
            komut.Connection = baglanti;
            komut.ExecuteNonQuery();
            donusDegeri = 0;
            sonuc = new Result<int>(donusDegeri);
        }
        catch (Exception exc)
        {
            sonuc = new Result<int>(exc);
            sonuc.Item = -1;
        }
        finally
        {
            BaglantiyiKapat(baglanti);
        }
        return sonuc;
    }
    public static Result<int> ExecuteReturnIdentity(OleDbCommand komut, OleDbCommand komutIdentity)
    {
        Result<int> sonuc = new Result<int>("Hata Oldu");
        int donusDegeri = -1;
        OleDbConnection baglanti = AcikBaglantiGetir();
        try
        {
            komut.Connection = baglanti;
            komut.ExecuteNonQuery();

            komutIdentity.Connection = baglanti;
            object deger = komutIdentity.ExecuteScalar();
            donusDegeri = Convert.ToInt32(deger);

            sonuc = new Result<int>(donusDegeri);
        }
        catch (Exception exc)
        {
            sonuc = new Result<int>(exc);
            sonuc.Item = -1;
        }
        finally
        {
            BaglantiyiKapat(baglanti);
        }
        return sonuc;
    }
    public static int KimlikDenetle(string kull, string sifre)
    {
        int sonuc = -1;
        OleDbCommand komut = new OleDbCommand();
        OleDbDataReader dt;
        OleDbConnection baglanti = AcikBaglantiGetir();
        try
        {
            OleDbParameter[] parametreler = new OleDbParameter[] { new OleDbParameter("@KullaniciAdi", kull), new OleDbParameter("@Sifre", sifre) };
            komut = new OleDbCommand("select * from kullanici where (KullaniciAdi = @KullaniciAdi) AND (Sifre = @Sifre)");
            komut.Parameters.Add(parametreler[0]);
            komut.Parameters.Add(parametreler[1]);
            komut.Connection = baglanti;
            dt = komut.ExecuteReader();
            if (dt.Read())
            {
                sonuc = dt.GetInt32(0);
            }
            dt.Close();
            dt.Dispose();
        }
        catch (Exception exc)
        {
        }
        finally
        {
            komut.Dispose();
            BaglantiyiKapat(baglanti);
        }
        return sonuc;
    }

    #region mail islemleri

    public static ik Selectik(OleDbCommand komut)
    {
        ik yeniik = null;

        OleDbConnection baglanti = AcikBaglantiGetir();
        try
        {
            komut.Connection = baglanti;
            OleDbDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                yeniik = new ik();
                if (!oku.IsDBNull(0))
                    yeniik.ID = oku.GetInt32(0);
                if (!oku.IsDBNull(1))
                    yeniik.Adi = oku.GetString(1);
                if (!oku.IsDBNull(2))
                    yeniik.Pozisyon = oku.GetString(2);
                if (!oku.IsDBNull(3))
                    yeniik.Telefon = oku.GetString(3);
                if (!oku.IsDBNull(4))
                    yeniik.Eposta = oku.GetString(4);
                if (!oku.IsDBNull(5))
                    yeniik.Ek = oku.GetString(5);
                if (!oku.IsDBNull(6))
                    yeniik.Tarih = oku.GetString(6);
            }
        }
        catch
        {
            throw;
        }
        finally
        {
            BaglantiyiKapat(baglanti);
        }
        return yeniik;
    }

    public static List<ik> SelectAllik(OleDbCommand komut)
    {
        List<ik> Listik = new List<ik>();

        OleDbConnection baglanti = AcikBaglantiGetir();
        try
        {
            komut.Connection = baglanti;
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ik yeniik = new ik();
                if (!oku.IsDBNull(0))
                    yeniik.ID = oku.GetInt32(0);
                if (!oku.IsDBNull(1))
                    yeniik.Adi = oku.GetString(1);
                if (!oku.IsDBNull(2))
                    yeniik.Pozisyon = oku.GetString(2);
                if (!oku.IsDBNull(3))
                    yeniik.Telefon = oku.GetString(3);
                if (!oku.IsDBNull(4))
                    yeniik.Eposta = oku.GetString(4);
                if (!oku.IsDBNull(5))
                    yeniik.Ek = oku.GetString(5);
                if (!oku.IsDBNull(6))
                    yeniik.Tarih = oku.GetString(6);

                Listik.Add(yeniik);
            }
        }
        catch
        {
            throw;
        }
        finally
        {
            BaglantiyiKapat(baglanti);
        }
        return Listik;
    }

    public static int SifreHatirlat(string email)
    {
        int sonuc = 0;

        try
        {

            kullanici kul = (from kull in kullanici.SelectAll()
                             where kull.Mail == email
                             select kull).FirstOrDefault();

            List<kullanici> liste = kullanici.SelectAll();

            if (kul != null)
            {
                string sablon = "Sayın " + kul.AdiSoyadi + " ,<br /><br />";
                sablon += "<table><tr><td>Kullanıcı Adı:</td><td>" + kul.KullaniciAdi + "</td></tr>";
                sablon += "<tr><td>Şifre:</td><td>" + kul.Sifre + "</td></tr>";

                if (Convert.ToBoolean(kul.Durum))
                {
                    sablon += "<tr><td>Durumunuz:</td><td> Aktif </td></tr>";
                }
                else
                {
                    sablon += "<tr><td>Durumunuz:</td><td> Pasif </td></tr>";
                }

                sablon += "</table>";


                ayar ay = ayar.Select(1);

                //if (KolayMail(email,ay.Mail, "Şifre Hatırlatma", sablon))
                string hata = "";
                if (KolayMail(email, ay.Mail, "Şifre Hatırlatma", sablon))
                {
                    sonuc = 2;
                }
                else
                {
                    sonuc = 3;
                }
            }
            else
            {
                sonuc = 4;
            }
        }
        catch
        {
        }
        finally
        {

        }

        return sonuc;
    }
    public static bool KolayMail(string kime, string kimden, string konu, string mesaj)
    {
        SmtpClient smtpserver = new SmtpClient();
        //ayar ay = ayar.Select(1);
        //smtpserver.Host = ay.MailServer;
        //MailAddress MailTo = new MailAddress(ay.Mail);
        smtpserver.Host = "localhost";
        try
        {
            MailAddress mSender = new MailAddress(kimden);
            MailAddress MailTo = new MailAddress(kime);
            MailMessage newMail = new MailMessage(mSender, MailTo);
            newMail.IsBodyHtml = true;
            newMail.Subject = konu;
            newMail.Body = mesaj;
            smtpserver.Send(newMail);
            return true;
        }
        catch
        {
            return false;
        }
        finally
        {
            smtpserver.Dispose();
        }
    }

    #endregion mail islemleri

    public static lazer Selectlazer(OleDbCommand komut)
    {
        lazer yenilazer = null;

        OleDbConnection baglanti = AcikBaglantiGetir();
        try
        {
            komut.Connection = baglanti;
            OleDbDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                yenilazer = new lazer();
                if (!oku.IsDBNull(0))
                    yenilazer.ID = oku.GetInt32(0);
                if (!oku.IsDBNull(1))
                    yenilazer.Adi = oku.GetString(1);
                if (!oku.IsDBNull(2))
                    yenilazer.Aciklama = oku.GetString(2);
                if (!oku.IsDBNull(3))
                    yenilazer.Resim = oku.GetString(3);
                if (!oku.IsDBNull(4))
                    yenilazer.Sira = oku.GetInt32(4);
                if (!oku.IsDBNull(5))
                    yenilazer.MetaKeyword = oku.GetString(5);
                if (!oku.IsDBNull(6))
                    yenilazer.MetaDescription = oku.GetString(6);
                if (!oku.IsDBNull(7))
                    yenilazer.MetaTitle = oku.GetString(7);
                if (!oku.IsDBNull(8))
                    yenilazer.SeoYazisi = oku.GetString(8);
            }
        }
        catch
        {
            throw;
        }
        finally
        {
            BaglantiyiKapat(baglanti);
        }
        return yenilazer;
    }

    public static List<lazer> SelectAlllazer(OleDbCommand komut)
    {
        List<lazer> Listlazer = new List<lazer>();

        OleDbConnection baglanti = AcikBaglantiGetir();
        try
        {
            komut.Connection = baglanti;
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                lazer yenilazer = new lazer();
                if (!oku.IsDBNull(0))
                    yenilazer.ID = oku.GetInt32(0);
                if (!oku.IsDBNull(1))
                    yenilazer.Adi = oku.GetString(1);
                if (!oku.IsDBNull(2))
                    yenilazer.Aciklama = oku.GetString(2);
                if (!oku.IsDBNull(3))
                    yenilazer.Resim = oku.GetString(3);
                if (!oku.IsDBNull(4))
                    yenilazer.Sira = oku.GetInt32(4);
                if (!oku.IsDBNull(5))
                    yenilazer.MetaKeyword = oku.GetString(5);
                if (!oku.IsDBNull(6))
                    yenilazer.MetaDescription = oku.GetString(6);
                if (!oku.IsDBNull(7))
                    yenilazer.MetaTitle = oku.GetString(7);
                if (!oku.IsDBNull(8))
                    yenilazer.SeoYazisi = oku.GetString(8);

                Listlazer.Add(yenilazer);
            }
        }
        catch
        {
            throw;
        }
        finally
        {
            BaglantiyiKapat(baglanti);
        }
        return Listlazer;
    }
    public static epostaList SelectepostaList(OleDbCommand komut)
    {
        epostaList yeniepostaList = null;

        OleDbConnection baglanti = AcikBaglantiGetir();
        try
        {
            komut.Connection = baglanti;
            OleDbDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                yeniepostaList = new epostaList();
                if (!oku.IsDBNull(0))
                    yeniepostaList.Id = oku.GetInt32(0);
                if (!oku.IsDBNull(1))
                    yeniepostaList.Eposta = oku.GetString(1);
                if (!oku.IsDBNull(2))
                    yeniepostaList.Tarih = oku.GetDateTime(2);
                if (!oku.IsDBNull(3))
                    yeniepostaList.Telefon = oku.GetString(3);
            }
        }
        catch
        {
            throw;
        }
        finally
        {
            BaglantiyiKapat(baglanti);
        }
        return yeniepostaList;
    }

    public static List<epostaList> SelectAllepostaList(OleDbCommand komut)
    {
        List<epostaList> ListepostaList = new List<epostaList>();

        OleDbConnection baglanti = AcikBaglantiGetir();
        try
        {
            komut.Connection = baglanti;
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                epostaList yeniepostaList = new epostaList();
                if (!oku.IsDBNull(0))
                    yeniepostaList.Id = oku.GetInt32(0);
                if (!oku.IsDBNull(1))
                    yeniepostaList.Eposta = oku.GetString(1);
                if (!oku.IsDBNull(2))
                    yeniepostaList.Tarih = oku.GetDateTime(2);
                if (!oku.IsDBNull(3))
                    yeniepostaList.Telefon = oku.GetString(3);

                ListepostaList.Add(yeniepostaList);
            }
        }
        catch
        {
            throw;
        }
        finally
        {
            BaglantiyiKapat(baglanti);
        }
        return ListepostaList;
    }

    public static referans Selectreferans(OleDbCommand komut)
    {
        referans yenireferans = null;

        OleDbConnection baglanti = AcikBaglantiGetir();
        try
        {
            komut.Connection = baglanti;
            OleDbDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                yenireferans = new referans();
                if (!oku.IsDBNull(0))
                    yenireferans.Id = oku.GetInt32(0);
                if (!oku.IsDBNull(1))
                    yenireferans.Adi = oku.GetString(1);
                if (!oku.IsDBNull(2))
                    yenireferans.Aciklama = oku.GetString(2);
                if (!oku.IsDBNull(3))
                    yenireferans.Resim = oku.GetString(3);
            }
        }
        catch
        {
            throw;
        }
        finally
        {
            BaglantiyiKapat(baglanti);
        }
        return yenireferans;
    }

    public static List<referans> SelectAllreferans(OleDbCommand komut)
    {
        List<referans> Listreferans = new List<referans>();

        OleDbConnection baglanti = AcikBaglantiGetir();
        try
        {
            komut.Connection = baglanti;
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                referans yenireferans = new referans();
                if (!oku.IsDBNull(0))
                    yenireferans.Id = oku.GetInt32(0);
                if (!oku.IsDBNull(1))
                    yenireferans.Adi = oku.GetString(1);
                if (!oku.IsDBNull(2))
                    yenireferans.Aciklama = oku.GetString(2);
                if (!oku.IsDBNull(3))
                    yenireferans.Resim = oku.GetString(3);

                Listreferans.Add(yenireferans);
            }
        }
        catch
        {
            throw;
        }
        finally
        {
            BaglantiyiKapat(baglanti);
        }
        return Listreferans;
    }

    public static urunkat Selecturunkat(OleDbCommand komut)
    {
        urunkat yeniurunkat = null;

        OleDbConnection baglanti = AcikBaglantiGetir();
        try
        {
            komut.Connection = baglanti;
            OleDbDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                yeniurunkat = new urunkat();
                if (!oku.IsDBNull(0))
                    yeniurunkat.Id = oku.GetInt32(0);
                if (!oku.IsDBNull(1))
                    yeniurunkat.FkUstKategori = oku.GetInt32(1);
                if (!oku.IsDBNull(2))
                    yeniurunkat.Adi = oku.GetString(2);
                if (!oku.IsDBNull(3))
                    yeniurunkat.Resim = oku.GetString(3);
                if (!oku.IsDBNull(4))
                    yeniurunkat.Aktif = oku.GetBoolean(4);
            }
        }
        catch
        {
            throw;
        }
        finally
        {
            BaglantiyiKapat(baglanti);
        }
        return yeniurunkat;
    }

    public static List<urunkat> SelectAllurunkat(OleDbCommand komut)
    {
        List<urunkat> Listurunkat = new List<urunkat>();

        OleDbConnection baglanti = AcikBaglantiGetir();
        try
        {
            komut.Connection = baglanti;
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                urunkat yeniurunkat = new urunkat();
                if (!oku.IsDBNull(0))
                    yeniurunkat.Id = oku.GetInt32(0);
                if (!oku.IsDBNull(1))
                    yeniurunkat.FkUstKategori = oku.GetInt32(1);
                if (!oku.IsDBNull(2))
                    yeniurunkat.Adi = oku.GetString(2);
                if (!oku.IsDBNull(3))
                    yeniurunkat.Resim = oku.GetString(3);
                if (!oku.IsDBNull(4))
                    yeniurunkat.Aktif = oku.GetBoolean(4);

                Listurunkat.Add(yeniurunkat);
            }
        }
        catch
        {
            throw;
        }
        finally
        {
            BaglantiyiKapat(baglanti);
        }
        return Listurunkat;
    }

    public static haber Selecthaber(OleDbCommand komut)
    {
        haber yenihaber = null;

        OleDbConnection baglanti = AcikBaglantiGetir();
        try
        {
            komut.Connection = baglanti;
            OleDbDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                yenihaber = new haber();
                if (!oku.IsDBNull(0))
                    yenihaber.Id = oku.GetInt32(0);
                if (!oku.IsDBNull(1))
                    yenihaber.Baslik = oku.GetString(1);
                if (!oku.IsDBNull(2))
                    yenihaber.Resim = oku.GetString(2);
                if (!oku.IsDBNull(3))
                    yenihaber.Yazi = oku.GetString(3);
                if (!oku.IsDBNull(4))
                    yenihaber.Tarih = oku.GetString(4);
                if (!oku.IsDBNull(5))
                    yenihaber.Aktif = oku.GetBoolean(5);
                if (!oku.IsDBNull(6))
                    yenihaber.AltBaslik = oku.GetString(6);
            }
        }
        catch
        {
            throw;
        }
        finally
        {
            BaglantiyiKapat(baglanti);
        }
        return yenihaber;
    }

    public static List<haber> SelectAllhaber(OleDbCommand komut)
    {
        List<haber> Listhaber = new List<haber>();

        OleDbConnection baglanti = AcikBaglantiGetir();
        try
        {
            komut.Connection = baglanti;
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                haber yenihaber = new haber();
                if (!oku.IsDBNull(0))
                    yenihaber.Id = oku.GetInt32(0);
                if (!oku.IsDBNull(1))
                    yenihaber.Baslik = oku.GetString(1);
                if (!oku.IsDBNull(2))
                    yenihaber.Resim = oku.GetString(2);
                if (!oku.IsDBNull(3))
                    yenihaber.Yazi = oku.GetString(3);
                if (!oku.IsDBNull(4))
                    yenihaber.Tarih = oku.GetString(4);
                if (!oku.IsDBNull(5))
                    yenihaber.Aktif = oku.GetBoolean(5);
                if (!oku.IsDBNull(6))
                    yenihaber.AltBaslik = oku.GetString(6);

                Listhaber.Add(yenihaber);
            }
        }
        catch
        {
            throw;
        }
        finally
        {
            BaglantiyiKapat(baglanti);
        }
        return Listhaber;
    }

    public static ktlg Selectktlg(OleDbCommand komut)
    {
        ktlg yeniktlg = null;

        OleDbConnection baglanti = AcikBaglantiGetir();
        try
        {
            komut.Connection = baglanti;
            OleDbDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                yeniktlg = new ktlg();
                if (!oku.IsDBNull(0))
                    yeniktlg.Id = oku.GetInt32(0);
                if (!oku.IsDBNull(1))
                    yeniktlg.Adi = oku.GetString(1);
                if (!oku.IsDBNull(2))
                    yeniktlg.Link = oku.GetString(2);
            }
        }
        catch
        {
            throw;
        }
        finally
        {
            BaglantiyiKapat(baglanti);
        }
        return yeniktlg;
    }

    public static List<ktlg> SelectAllktlg(OleDbCommand komut)
    {
        List<ktlg> Listktlg = new List<ktlg>();

        OleDbConnection baglanti = AcikBaglantiGetir();
        try
        {
            komut.Connection = baglanti;
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ktlg yeniktlg = new ktlg();
                if (!oku.IsDBNull(0))
                    yeniktlg.Id = oku.GetInt32(0);
                if (!oku.IsDBNull(1))
                    yeniktlg.Adi = oku.GetString(1);
                if (!oku.IsDBNull(2))
                    yeniktlg.Link = oku.GetString(2);

                Listktlg.Add(yeniktlg);
            }
        }
        catch
        {
            throw;
        }
        finally
        {
            BaglantiyiKapat(baglanti);
        }
        return Listktlg;
    }

    public static kurumsalSayfa SelectkurumsalSayfa(OleDbCommand komut)
    {
        kurumsalSayfa yenikurumsalSayfa = null;

        OleDbConnection baglanti = AcikBaglantiGetir();
        try
        {
            komut.Connection = baglanti;
            OleDbDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                yenikurumsalSayfa = new kurumsalSayfa();
                if (!oku.IsDBNull(0))
                    yenikurumsalSayfa.Id = oku.GetInt32(0);
                if (!oku.IsDBNull(1))
                    yenikurumsalSayfa.Adi = oku.GetString(1);
                if (!oku.IsDBNull(2))
                    yenikurumsalSayfa.Icerik = oku.GetString(2);
            }
        }
        catch
        {
            throw;
        }
        finally
        {
            BaglantiyiKapat(baglanti);
        }
        return yenikurumsalSayfa;
    }

    public static List<kurumsalSayfa> SelectAllkurumsalSayfa(OleDbCommand komut)
    {
        List<kurumsalSayfa> ListkurumsalSayfa = new List<kurumsalSayfa>();

        OleDbConnection baglanti = AcikBaglantiGetir();
        try
        {
            komut.Connection = baglanti;
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                kurumsalSayfa yenikurumsalSayfa = new kurumsalSayfa();
                if (!oku.IsDBNull(0))
                    yenikurumsalSayfa.Id = oku.GetInt32(0);
                if (!oku.IsDBNull(1))
                    yenikurumsalSayfa.Adi = oku.GetString(1);
                if (!oku.IsDBNull(2))
                    yenikurumsalSayfa.Icerik = oku.GetString(2);

                ListkurumsalSayfa.Add(yenikurumsalSayfa);
            }
        }
        catch
        {
            throw;
        }
        finally
        {
            BaglantiyiKapat(baglanti);
        }
        return ListkurumsalSayfa;
    }


    public static kategori Selectkategori(OleDbCommand komut)
    {
        kategori yenikategori = null;

        OleDbConnection baglanti = AcikBaglantiGetir();
        try
        {
            komut.Connection = baglanti;
            OleDbDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                yenikategori = new kategori();
                if (!oku.IsDBNull(0))
                    yenikategori.Id = oku.GetInt32(0);
                if (!oku.IsDBNull(1))
                    yenikategori.FkUstKategori = oku.GetInt32(1);
                if (!oku.IsDBNull(2))
                    yenikategori.Adi = oku.GetString(2);
                if (!oku.IsDBNull(3))
                    yenikategori.Resim = oku.GetString(3);
                if (!oku.IsDBNull(4))
                    yenikategori.Aktif = oku.GetBoolean(4);
            }
        }
        catch
        {
            throw;
        }
        finally
        {
            BaglantiyiKapat(baglanti);
        }
        return yenikategori;
    }

    public static List<kategori> SelectAllkategori(OleDbCommand komut)
    {
        List<kategori> Listkategori = new List<kategori>();

        OleDbConnection baglanti = AcikBaglantiGetir();
        try
        {
            komut.Connection = baglanti;
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                kategori yenikategori = new kategori();
                if (!oku.IsDBNull(0))
                    yenikategori.Id = oku.GetInt32(0);
                if (!oku.IsDBNull(1))
                    yenikategori.FkUstKategori = oku.GetInt32(1);
                if (!oku.IsDBNull(2))
                    yenikategori.Adi = oku.GetString(2);
                if (!oku.IsDBNull(3))
                    yenikategori.Resim = oku.GetString(3);
                if (!oku.IsDBNull(4))
                    yenikategori.Aktif = oku.GetBoolean(4);

                Listkategori.Add(yenikategori);
            }
        }
        catch
        {
            throw;
        }
        finally
        {
            BaglantiyiKapat(baglanti);
        }
        return Listkategori;
    }


    public static urun Selecturun(OleDbCommand komut)
    {
        urun yeniurun = null;

        OleDbConnection baglanti = AcikBaglantiGetir();
        try
        {
            komut.Connection = baglanti;
            OleDbDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                yeniurun = new urun();
                if (!oku.IsDBNull(0))
                    yeniurun.Id = oku.GetInt32(0);
                if (!oku.IsDBNull(1))
                    yeniurun.FkKategori = oku.GetInt32(1);
                if (!oku.IsDBNull(2))
                    yeniurun.Adi = oku.GetString(2);
                if (!oku.IsDBNull(3))
                    yeniurun.Aciklama = oku.GetString(3);
                if (!oku.IsDBNull(4))
                    yeniurun.Resim = oku.GetString(4);
                if (!oku.IsDBNull(5))
                    yeniurun.Kumas = oku.GetString(5);
                if (!oku.IsDBNull(6))
                    yeniurun.Aktif = oku.GetBoolean(6);
            }
        }
        catch
        {
            throw;
        }
        finally
        {
            BaglantiyiKapat(baglanti);
        }
        return yeniurun;
    }

    public static List<urun> SelectAllurun(OleDbCommand komut)
    {
        List<urun> Listurun = new List<urun>();

        OleDbConnection baglanti = AcikBaglantiGetir();
        try
        {
            komut.Connection = baglanti;
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                urun yeniurun = new urun();
                if (!oku.IsDBNull(0))
                    yeniurun.Id = oku.GetInt32(0);
                if (!oku.IsDBNull(1))
                    yeniurun.FkKategori = oku.GetInt32(1);
                if (!oku.IsDBNull(2))
                    yeniurun.Adi = oku.GetString(2);
                if (!oku.IsDBNull(3))
                    yeniurun.Aciklama = oku.GetString(3);
                if (!oku.IsDBNull(4))
                    yeniurun.Resim = oku.GetString(4);
                if (!oku.IsDBNull(5))
                    yeniurun.Kumas = oku.GetString(5);
                if (!oku.IsDBNull(6))
                    yeniurun.Aktif = oku.GetBoolean(6);

                Listurun.Add(yeniurun);
            }
        }
        catch
        {
            throw;
        }
        finally
        {
            BaglantiyiKapat(baglanti);
        }
        return Listurun;
    }


    public static urunResim SelecturunResim(OleDbCommand komut)
    {
        urunResim yeniurunResim = null;

        OleDbConnection baglanti = AcikBaglantiGetir();
        try
        {
            komut.Connection = baglanti;
            OleDbDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                yeniurunResim = new urunResim();
                if (!oku.IsDBNull(0))
                    yeniurunResim.Id = oku.GetInt32(0);
                if (!oku.IsDBNull(1))
                    yeniurunResim.FkUrun = oku.GetInt32(1);
                if (!oku.IsDBNull(2))
                    yeniurunResim.Resim = oku.GetString(2);
            }
        }
        catch
        {
            throw;
        }
        finally
        {
            BaglantiyiKapat(baglanti);
        }
        return yeniurunResim;
    }

    public static List<urunResim> SelectAllurunResim(OleDbCommand komut)
    {
        List<urunResim> ListurunResim = new List<urunResim>();

        OleDbConnection baglanti = AcikBaglantiGetir();
        try
        {
            komut.Connection = baglanti;
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                urunResim yeniurunResim = new urunResim();
                if (!oku.IsDBNull(0))
                    yeniurunResim.Id = oku.GetInt32(0);
                if (!oku.IsDBNull(1))
                    yeniurunResim.FkUrun = oku.GetInt32(1);
                if (!oku.IsDBNull(2))
                    yeniurunResim.Resim = oku.GetString(2);

                ListurunResim.Add(yeniurunResim);
            }
        }
        catch
        {
            throw;
        }
        finally
        {
            BaglantiyiKapat(baglanti);
        }
        return ListurunResim;
    }


    public static iletisimmesaj Selectiletisimmesaj(OleDbCommand komut)
    {
        iletisimmesaj yeniiletisimmesaj = null;

        OleDbConnection baglanti = AcikBaglantiGetir();
        try
        {
            komut.Connection = baglanti;
            OleDbDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                yeniiletisimmesaj = new iletisimmesaj();
                if (!oku.IsDBNull(0))
                    yeniiletisimmesaj.Id = oku.GetInt32(0);
                if (!oku.IsDBNull(1))
                    yeniiletisimmesaj.Isim = oku.GetString(1);
                if (!oku.IsDBNull(2))
                    yeniiletisimmesaj.Email = oku.GetString(2);
                if (!oku.IsDBNull(3))
                    yeniiletisimmesaj.Konu = oku.GetString(3);
                if (!oku.IsDBNull(4))
                    yeniiletisimmesaj.Mesaj = oku.GetString(4);
                if (!oku.IsDBNull(5))
                    yeniiletisimmesaj.Durum = oku.GetBoolean(5);
                if (!oku.IsDBNull(6))
                    yeniiletisimmesaj.Tarih = oku.GetDateTime(6);
                if (!oku.IsDBNull(7))
                    yeniiletisimmesaj.Telefon = oku.GetString(7);
            }
        }
        catch
        {
            throw;
        }
        finally
        {
            BaglantiyiKapat(baglanti);
        }
        return yeniiletisimmesaj;
    }

    public static List<iletisimmesaj> SelectAlliletisimmesaj(OleDbCommand komut)
    {
        List<iletisimmesaj> Listiletisimmesaj = new List<iletisimmesaj>();

        OleDbConnection baglanti = AcikBaglantiGetir();
        try
        {
            komut.Connection = baglanti;
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                iletisimmesaj yeniiletisimmesaj = new iletisimmesaj();
                if (!oku.IsDBNull(0))
                    yeniiletisimmesaj.Id = oku.GetInt32(0);
                if (!oku.IsDBNull(1))
                    yeniiletisimmesaj.Isim = oku.GetString(1);
                if (!oku.IsDBNull(2))
                    yeniiletisimmesaj.Email = oku.GetString(2);
                if (!oku.IsDBNull(3))
                    yeniiletisimmesaj.Konu = oku.GetString(3);
                if (!oku.IsDBNull(4))
                    yeniiletisimmesaj.Mesaj = oku.GetString(4);
                if (!oku.IsDBNull(5))
                    yeniiletisimmesaj.Durum = oku.GetBoolean(5);
                if (!oku.IsDBNull(6))
                    yeniiletisimmesaj.Tarih = oku.GetDateTime(6);
                if (!oku.IsDBNull(7))
                    yeniiletisimmesaj.Telefon = oku.GetString(7);

                Listiletisimmesaj.Add(yeniiletisimmesaj);
            }
        }
        catch
        {
            throw;
        }
        finally
        {
            BaglantiyiKapat(baglanti);
        }
        return Listiletisimmesaj;
    }


    public static marka Selectmarka(OleDbCommand komut)
    {
        marka yenimarka = null;

        OleDbConnection baglanti = AcikBaglantiGetir();
        try
        {
            komut.Connection = baglanti;
            OleDbDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                yenimarka = new marka();
                if (!oku.IsDBNull(0))
                    yenimarka.Id = oku.GetInt32(0);
                if (!oku.IsDBNull(1))
                    yenimarka.Resim = oku.GetString(1);
                if (!oku.IsDBNull(2))
                    yenimarka.Adi = oku.GetString(2);
            }
        }
        catch
        {
            throw;
        }
        finally
        {
            BaglantiyiKapat(baglanti);
        }
        return yenimarka;
    }

    public static List<marka> SelectAllmarka(OleDbCommand komut)
    {
        List<marka> Listmarka = new List<marka>();

        OleDbConnection baglanti = AcikBaglantiGetir();
        try
        {
            komut.Connection = baglanti;
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                marka yenimarka = new marka();
                if (!oku.IsDBNull(0))
                    yenimarka.Id = oku.GetInt32(0);
                if (!oku.IsDBNull(1))
                    yenimarka.Resim = oku.GetString(1);
                if (!oku.IsDBNull(2))
                    yenimarka.Adi = oku.GetString(2);

                Listmarka.Add(yenimarka);
            }
        }
        catch
        {
            throw;
        }
        finally
        {
            BaglantiyiKapat(baglanti);
        }
        return Listmarka;
    }


    public static slider Selectslider(OleDbCommand komut)
    {
        slider yenislider = null;

        OleDbConnection baglanti = AcikBaglantiGetir();
        try
        {
            komut.Connection = baglanti;
            OleDbDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                yenislider = new slider();
                if (!oku.IsDBNull(0))
                    yenislider.Id = oku.GetInt32(0);
                if (!oku.IsDBNull(1))
                    yenislider.Yazi = oku.GetString(1);
                if (!oku.IsDBNull(2))
                    yenislider.Resim = oku.GetString(2);
            }
        }
        catch
        {
            throw;
        }
        finally
        {
            BaglantiyiKapat(baglanti);
        }
        return yenislider;
    }

    public static List<slider> SelectAllslider(OleDbCommand komut)
    {
        List<slider> Listslider = new List<slider>();

        OleDbConnection baglanti = AcikBaglantiGetir();
        try
        {
            komut.Connection = baglanti;
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                slider yenislider = new slider();
                if (!oku.IsDBNull(0))
                    yenislider.Id = oku.GetInt32(0);
                if (!oku.IsDBNull(1))
                    yenislider.Yazi = oku.GetString(1);
                if (!oku.IsDBNull(2))
                    yenislider.Resim = oku.GetString(2);

                Listslider.Add(yenislider);
            }
        }
        catch
        {
            throw;
        }
        finally
        {
            BaglantiyiKapat(baglanti);
        }
        return Listslider;
    }


    public static bayi Selectbayi(OleDbCommand komut)
    {
        bayi yenibayi = null;

        OleDbConnection baglanti = AcikBaglantiGetir();
        try
        {
            komut.Connection = baglanti;
            OleDbDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                yenibayi = new bayi();
                if (!oku.IsDBNull(0))
                    yenibayi.Id = oku.GetInt32(0);
                if (!oku.IsDBNull(1))
                    yenibayi.Bayi_adi = oku.GetString(1);
                if (!oku.IsDBNull(2))
                    yenibayi.Bayi_aciklama = oku.GetString(2);
                if (!oku.IsDBNull(3))
                    yenibayi.Resim = oku.GetString(3);
            }
        }
        catch
        {
            throw;
        }
        finally
        {
            BaglantiyiKapat(baglanti);
        }
        return yenibayi;
    }

    public static List<bayi> SelectAllbayi(OleDbCommand komut)
    {
        List<bayi> Listbayi = new List<bayi>();

        OleDbConnection baglanti = AcikBaglantiGetir();
        try
        {
            komut.Connection = baglanti;
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                bayi yenibayi = new bayi();
                if (!oku.IsDBNull(0))
                    yenibayi.Id = oku.GetInt32(0);
                if (!oku.IsDBNull(1))
                    yenibayi.Bayi_adi = oku.GetString(1);
                if (!oku.IsDBNull(2))
                    yenibayi.Bayi_aciklama = oku.GetString(2);
                if (!oku.IsDBNull(3))
                    yenibayi.Resim = oku.GetString(3);

                Listbayi.Add(yenibayi);
            }
        }
        catch
        {
            throw;
        }
        finally
        {
            BaglantiyiKapat(baglanti);
        }
        return Listbayi;
    }

    public static hizmet Selecthizmet(OleDbCommand komut)
    {
        hizmet yenihizmet = null;

        OleDbConnection baglanti = AcikBaglantiGetir();
        try
        {
            komut.Connection = baglanti;
            OleDbDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                yenihizmet = new hizmet();
                if (!oku.IsDBNull(0))
                    yenihizmet.Id = oku.GetInt32(0);
                if (!oku.IsDBNull(1))
                    yenihizmet.Adi = oku.GetString(1);
                if (!oku.IsDBNull(2))
                    yenihizmet.Aciklama = oku.GetString(2);
                if (!oku.IsDBNull(3))
                    yenihizmet.Resim = oku.GetString(3);
                if (!oku.IsDBNull(4))
                    yenihizmet.Sira = oku.GetInt32(4);
                if (!oku.IsDBNull(5))
                    yenihizmet.MetaKeyword = oku.GetString(5);
                if (!oku.IsDBNull(6))
                    yenihizmet.MetaDescription = oku.GetString(6);
                if (!oku.IsDBNull(7))
                    yenihizmet.MetaTitle = oku.GetString(7);
                if (!oku.IsDBNull(8))
                    yenihizmet.SeoYazisi = oku.GetString(8);
            }
        }
        catch
        {
            throw;
        }
        finally
        {
            BaglantiyiKapat(baglanti);
        }
        return yenihizmet;
    }

    public static List<hizmet> SelectAllhizmet(OleDbCommand komut)
    {
        List<hizmet> Listhizmet = new List<hizmet>();

        OleDbConnection baglanti = AcikBaglantiGetir();
        try
        {
            komut.Connection = baglanti;
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                hizmet yenihizmet = new hizmet();
                if (!oku.IsDBNull(0))
                    yenihizmet.Id = oku.GetInt32(0);
                if (!oku.IsDBNull(1))
                    yenihizmet.Adi = oku.GetString(1);
                if (!oku.IsDBNull(2))
                    yenihizmet.Aciklama = oku.GetString(2);
                if (!oku.IsDBNull(3))
                    yenihizmet.Resim = oku.GetString(3);
                if (!oku.IsDBNull(4))
                    yenihizmet.Sira = oku.GetInt32(4);
                if (!oku.IsDBNull(5))
                    yenihizmet.MetaKeyword = oku.GetString(5);
                if (!oku.IsDBNull(6))
                    yenihizmet.MetaDescription = oku.GetString(6);
                if (!oku.IsDBNull(7))
                    yenihizmet.MetaTitle = oku.GetString(7);
                if (!oku.IsDBNull(8))
                    yenihizmet.SeoYazisi = oku.GetString(8);
                Listhizmet.Add(yenihizmet);
            }
        }
        catch
        {
            throw;
        }
        finally
        {
            BaglantiyiKapat(baglanti);
        }
        return Listhizmet;
    }




}
public class Result
{
    public bool HasError { get; set; }
    public string CustomErrorMessage { get; set; }
    public Result()
    {
        HasError = false;
        CustomErrorMessage = null;
    }
    public Result(Exception exc)
    {
        HasError = true;
        CustomErrorMessage = exc.Message;
    }
    public Result(string uyari)
    {
        HasError = true;
        CustomErrorMessage = uyari;
    }
}
public class Result<T> : Result
{
    public T Item { get; set; }
    public Result(T item)
        : base()
    {
        this.Item = item;
    }
    public Result(Exception exc)
        : base(exc)
    {
        Item = default(T);
    }public Result(string uyari) : base(uyari) { Item = default(T); }
}
public class ResultList<T> : Result
{
    public List<T> Items { get; set; }
    public ResultList(List<T> items)
        : base()
    {
        this.Items = items;
    }
    public ResultList(Exception exc)
        : base(exc)
    {
        Items = default(List<T>);
    }public ResultList(string uyari) : base(uyari) { Items = default(List<T>); }
}


public static class Alert
{
    public static void Show(string message)
    {
        // '  karakterine izin vermek için ayar
        string cleanMessage = message.Replace("'", "\'");
        string script = "<script type=\"text/javascript\">alert('" + cleanMessage + "');</script>";
        // çalışan sayfayı al
        Page page = HttpContext.Current.CurrentHandler as Page;
        // handler sayfa ise ve script zaten sayfada degilse
        if (page != null && !page.ClientScript.IsClientScriptBlockRegistered("alert"))
        {
            page.ClientScript.RegisterClientScriptBlock(typeof(Alert), "alert", script);
        }
    }
}


