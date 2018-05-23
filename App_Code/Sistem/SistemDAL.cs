
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
public static class SistemDAL
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
        return "Provider=Microsoft.Jet.OleDb.4.0; Data Source=" + HttpContext.Current.Server.MapPath("~/App_Data\\sistem.mdb");
    }
    public static string GetConnectionString(string BaglantiAdi)
    {
        return ConfigurationManager.ConnectionStrings["BaglantiAdi"].ConnectionString;
    }
    #endregion
    public static object ExecuteScalar(OleDbCommand komut)
    {
        object donusDegeri = null;
        OleDbConnection baglanti = AcikBaglantiGetir();
        try
        {
            komut.Connection = baglanti;
            donusDegeri = komut.ExecuteScalar();
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
    public static string ExecuteReturnString(OleDbCommand komut)
    {
        string donusDegeri = "-1";
        OleDbConnection baglanti = AcikBaglantiGetir();
        try
        {
            komut.Connection = baglanti;
            komut.ExecuteNonQuery();
            donusDegeri = "0";
        }
        catch (Exception exc)
        {
            donusDegeri = exc.Message;
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

    #region mail islemleri

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
                //smtpserver.Host = ay.MailServer;
                //MailAddress MailTo = new MailAddress(ay.Mail);
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


    public static Toplam SelectToplam(OleDbCommand komut)
    {
        Toplam yeniToplam = null;

        OleDbConnection baglanti = AcikBaglantiGetir();
        try
        {
            komut.Connection = baglanti;
            OleDbDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                yeniToplam = new Toplam();
                if (!oku.IsDBNull(0))
                    yeniToplam.Id = oku.GetInt32(0);
                if (!oku.IsDBNull(1))
                    yeniToplam.Total = oku.GetInt32(1);
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
        return yeniToplam;
    }

    public static List<Toplam> SelectAllToplam(OleDbCommand komut)
    {
        List<Toplam> ListToplam = new List<Toplam>();

        OleDbConnection baglanti = AcikBaglantiGetir();
        try
        {
            komut.Connection = baglanti;
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                Toplam yeniToplam = new Toplam();
                if (!oku.IsDBNull(0))
                    yeniToplam.Id = oku.GetInt32(0);
                if (!oku.IsDBNull(1))
                    yeniToplam.Total = oku.GetInt32(1);

                ListToplam.Add(yeniToplam);
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
        return ListToplam;
    }

    public static iletisim Selectiletisim(OleDbCommand komut)
    {
        iletisim yeniiletisim = null;

        OleDbConnection baglanti = AcikBaglantiGetir();
        try
        {
            komut.Connection = baglanti;
            OleDbDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                yeniiletisim = new iletisim();
                if (!oku.IsDBNull(0))
                    yeniiletisim.Id = oku.GetInt32(0);
                if (!oku.IsDBNull(1))
                    yeniiletisim.Isim = oku.GetString(1);
                if (!oku.IsDBNull(2))
                    yeniiletisim.Email = oku.GetString(2);
                if (!oku.IsDBNull(3))
                    yeniiletisim.Konu = oku.GetString(3);
                if (!oku.IsDBNull(4))
                    yeniiletisim.Mesaj = oku.GetString(4);
                if (!oku.IsDBNull(5))
                    yeniiletisim.Durum = oku.GetBoolean(5);
                if (!oku.IsDBNull(6))
                    yeniiletisim.Tarih = oku.GetDateTime(6);
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
        return yeniiletisim;
    }
    public static sayac Selectsayac(OleDbCommand komut)
    {
        sayac yenisayac = null;

        OleDbConnection baglanti = AcikBaglantiGetir();
        try
        {
            komut.Connection = baglanti;
            OleDbDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                yenisayac = new sayac();
                if (!oku.IsDBNull(0))
                    yenisayac.Tarih = oku.GetString(0);
                if (!oku.IsDBNull(1))
                    yenisayac.Gunluk = oku.GetInt32(1);
                if (!oku.IsDBNull(2))
                    yenisayac.Aylik = oku.GetInt32(2);
                if (!oku.IsDBNull(3))
                    yenisayac.Yillik = oku.GetInt32(3);
                if (!oku.IsDBNull(4))
                    yenisayac.Toplam = oku.GetInt32(4);
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
        return yenisayac;
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
    public static List<sayac> SelectAllsayac(OleDbCommand komut)
    {
        List<sayac> Listsayac = new List<sayac>();

        OleDbConnection baglanti = AcikBaglantiGetir();
        try
        {
            komut.Connection = baglanti;
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                sayac yenisayac = new sayac();
                if (!oku.IsDBNull(0))
                    yenisayac.Tarih = oku.GetString(0);
                if (!oku.IsDBNull(1))
                    yenisayac.Gunluk = oku.GetInt32(1);
                if (!oku.IsDBNull(2))
                    yenisayac.Aylik = oku.GetInt32(2);
                if (!oku.IsDBNull(3))
                    yenisayac.Yillik = oku.GetInt32(3);
                if (!oku.IsDBNull(4))
                    yenisayac.Toplam = oku.GetInt32(4);

                Listsayac.Add(yenisayac);
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
        return Listsayac;
    }


    public static SayacIp SelectSayacIp(OleDbCommand komut)
    {
        SayacIp yeniSayacIp = null;

        OleDbConnection baglanti = AcikBaglantiGetir();
        try
        {
            komut.Connection = baglanti;
            OleDbDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                yeniSayacIp = new SayacIp();
                if (!oku.IsDBNull(0))
                    yeniSayacIp.IpId = oku.GetInt32(0);
                if (!oku.IsDBNull(1))
                    yeniSayacIp.Ip = oku.GetString(1);
                if (!oku.IsDBNull(2))
                    yeniSayacIp.Hit = oku.GetInt32(2);
                if (!oku.IsDBNull(3))
                    yeniSayacIp.Tarih = oku.GetDateTime(3);
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
        return yeniSayacIp;
    }

    public static List<SayacIp> SelectAllSayacIp(OleDbCommand komut)
    {
        List<SayacIp> ListSayacIp = new List<SayacIp>();

        OleDbConnection baglanti = AcikBaglantiGetir();
        try
        {
            komut.Connection = baglanti;
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                SayacIp yeniSayacIp = new SayacIp();
                if (!oku.IsDBNull(0))
                    yeniSayacIp.IpId = oku.GetInt32(0);
                if (!oku.IsDBNull(1))
                    yeniSayacIp.Ip = oku.GetString(1);
                if (!oku.IsDBNull(2))
                    yeniSayacIp.Hit = oku.GetInt32(2);
                if (!oku.IsDBNull(3))
                    yeniSayacIp.Tarih = oku.GetDateTime(3);

                ListSayacIp.Add(yeniSayacIp);
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
        return ListSayacIp;
    }


    public static tblSayacGunluk SelecttblSayacGunluk(OleDbCommand komut)
    {
        tblSayacGunluk yenitblSayacGunluk = null;

        OleDbConnection baglanti = AcikBaglantiGetir();
        try
        {
            komut.Connection = baglanti;
            OleDbDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                yenitblSayacGunluk = new tblSayacGunluk();
                if (!oku.IsDBNull(0))
                    yenitblSayacGunluk.SayacId = oku.GetInt32(0);
                if (!oku.IsDBNull(1))
                    yenitblSayacGunluk.Tekil = oku.GetInt32(1);
                if (!oku.IsDBNull(2))
                    yenitblSayacGunluk.Cogul = oku.GetInt32(2);
                if (!oku.IsDBNull(3))
                    yenitblSayacGunluk.Gun = oku.GetDateTime(3);
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
        return yenitblSayacGunluk;
    }

    public static List<tblSayacGunluk> SelectAlltblSayacGunluk(OleDbCommand komut)
    {
        List<tblSayacGunluk> ListtblSayacGunluk = new List<tblSayacGunluk>();

        OleDbConnection baglanti = AcikBaglantiGetir();
        try
        {
            komut.Connection = baglanti;
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                tblSayacGunluk yenitblSayacGunluk = new tblSayacGunluk();
                if (!oku.IsDBNull(0))
                    yenitblSayacGunluk.SayacId = oku.GetInt32(0);
                if (!oku.IsDBNull(1))
                    yenitblSayacGunluk.Tekil = oku.GetInt32(1);
                if (!oku.IsDBNull(2))
                    yenitblSayacGunluk.Cogul = oku.GetInt32(2);
                if (!oku.IsDBNull(3))
                    yenitblSayacGunluk.Gun = oku.GetDateTime(3);

                ListtblSayacGunluk.Add(yenitblSayacGunluk);
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
        return ListtblSayacGunluk;
    }
    public static List<iletisim> SelectAlliletisim(OleDbCommand komut)
    {
        List<iletisim> Listiletisim = new List<iletisim>();

        OleDbConnection baglanti = AcikBaglantiGetir();
        try
        {
            komut.Connection = baglanti;
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                iletisim yeniiletisim = new iletisim();
                if (!oku.IsDBNull(0))
                    yeniiletisim.Id = oku.GetInt32(0);
                if (!oku.IsDBNull(1))
                    yeniiletisim.Isim = oku.GetString(1);
                if (!oku.IsDBNull(2))
                    yeniiletisim.Email = oku.GetString(2);
                if (!oku.IsDBNull(3))
                    yeniiletisim.Konu = oku.GetString(3);
                if (!oku.IsDBNull(4))
                    yeniiletisim.Mesaj = oku.GetString(4);
                if (!oku.IsDBNull(5))
                    yeniiletisim.Durum = oku.GetBoolean(5);
                if (!oku.IsDBNull(6))
                    yeniiletisim.Tarih = oku.GetDateTime(6);

                Listiletisim.Add(yeniiletisim);
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
        return Listiletisim;
    }


    public static aktivite Selectaktivite(OleDbCommand komut)
    {
        aktivite yeniaktivite = null;

        OleDbConnection baglanti = AcikBaglantiGetir();
        try
        {
            komut.Connection = baglanti;
            OleDbDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                yeniaktivite = new aktivite();
                if (!oku.IsDBNull(0))
                    yeniaktivite.Id = oku.GetInt32(0);
                if (!oku.IsDBNull(1))
                    yeniaktivite.KullaniciId = oku.GetInt32(1);
                if (!oku.IsDBNull(2))
                    yeniaktivite.Tarih = oku.GetDateTime(2);
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
        return yeniaktivite;
    }

    public static List<aktivite> SelectAllaktivite(OleDbCommand komut)
    {
        List<aktivite> Listaktivite = new List<aktivite>();

        OleDbConnection baglanti = AcikBaglantiGetir();
        try
        {
            komut.Connection = baglanti;
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                aktivite yeniaktivite = new aktivite();
                if (!oku.IsDBNull(0))
                    yeniaktivite.Id = oku.GetInt32(0);
                if (!oku.IsDBNull(1))
                    yeniaktivite.KullaniciId = oku.GetInt32(1);
                if (!oku.IsDBNull(2))
                    yeniaktivite.Tarih = oku.GetDateTime(2);

                Listaktivite.Add(yeniaktivite);
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
        return Listaktivite;
    }


    public static kullanici Selectkullanici(OleDbCommand komut)
    {
        kullanici yenikullanici = null;

        OleDbConnection baglanti = AcikBaglantiGetir();
        try
        {
            komut.Connection = baglanti;
            OleDbDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                yenikullanici = new kullanici();
                if (!oku.IsDBNull(0))
                    yenikullanici.Id = oku.GetInt32(0);
                if (!oku.IsDBNull(1))
                    yenikullanici.AdiSoyadi = oku.GetString(1);
                if (!oku.IsDBNull(2))
                    yenikullanici.KullaniciAdi = oku.GetString(2);
                if (!oku.IsDBNull(3))
                    yenikullanici.Sifre = oku.GetString(3);
                if (!oku.IsDBNull(4))
                    yenikullanici.Mail = oku.GetString(4);
                if (!oku.IsDBNull(5))
                    yenikullanici.Tel = oku.GetString(5);
                if (!oku.IsDBNull(6))
                    yenikullanici.Adres = oku.GetString(6);
                if (!oku.IsDBNull(7))
                    yenikullanici.AdminMi = oku.GetBoolean(7);
                if (!oku.IsDBNull(8))
                    yenikullanici.Durum = oku.GetBoolean(8);
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
        return yenikullanici;
    }

    public static List<kullanici> SelectAllkullanici(OleDbCommand komut)
    {
        List<kullanici> Listkullanici = new List<kullanici>();

        OleDbConnection baglanti = AcikBaglantiGetir();
        try
        {
            komut.Connection = baglanti;
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                kullanici yenikullanici = new kullanici();
                if (!oku.IsDBNull(0))
                    yenikullanici.Id = oku.GetInt32(0);
                if (!oku.IsDBNull(1))
                    yenikullanici.AdiSoyadi = oku.GetString(1);
                if (!oku.IsDBNull(2))
                    yenikullanici.KullaniciAdi = oku.GetString(2);
                if (!oku.IsDBNull(3))
                    yenikullanici.Sifre = oku.GetString(3);
                if (!oku.IsDBNull(4))
                    yenikullanici.Mail = oku.GetString(4);
                if (!oku.IsDBNull(5))
                    yenikullanici.Tel = oku.GetString(5);
                if (!oku.IsDBNull(6))
                    yenikullanici.Adres = oku.GetString(6);
                if (!oku.IsDBNull(7))
                    yenikullanici.AdminMi = oku.GetBoolean(7);
                if (!oku.IsDBNull(8))
                    yenikullanici.Durum = oku.GetBoolean(8);

                Listkullanici.Add(yenikullanici);
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
        return Listkullanici;
    }


    public static ayar Selectayar(OleDbCommand komut)
    {
        ayar yeniayar = null;

        OleDbConnection baglanti = AcikBaglantiGetir();
        try
        {
            komut.Connection = baglanti;
            OleDbDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                yeniayar = new ayar();
                if (!oku.IsDBNull(0))
                    yeniayar.Id = oku.GetInt32(0);
                if (!oku.IsDBNull(1))
                    yeniayar.SirketAdi = oku.GetString(1);
                if (!oku.IsDBNull(2))
                    yeniayar.SiteAdi = oku.GetString(2);
                if (!oku.IsDBNull(3))
                    yeniayar.Adres = oku.GetString(3);
                if (!oku.IsDBNull(4))
                    yeniayar.Telefon = oku.GetString(4);
                if (!oku.IsDBNull(5))
                    yeniayar.Telefon2 = oku.GetString(5);
                if (!oku.IsDBNull(6))
                    yeniayar.Faks = oku.GetString(6);
                if (!oku.IsDBNull(7))
                    yeniayar.Gsm = oku.GetString(7);
                if (!oku.IsDBNull(8))
                    yeniayar.Klasor = oku.GetString(8);
                if (!oku.IsDBNull(9))
                    yeniayar.AdminMail = oku.GetString(9);
                if (!oku.IsDBNull(10))
                    yeniayar.Mail = oku.GetString(10);
                if (!oku.IsDBNull(11))
                    yeniayar.MailServer = oku.GetString(11);
                if (!oku.IsDBNull(12))
                    yeniayar.MailPassword = oku.GetString(12);
                if (!oku.IsDBNull(13))
                    yeniayar.MailPort = oku.GetString(13);
                if (!oku.IsDBNull(14))
                    yeniayar.SorumluMail = oku.GetString(14);
                if (!oku.IsDBNull(15))
                    yeniayar.HataLoglama = oku.GetBoolean(15);
                if (!oku.IsDBNull(16))
                    yeniayar.HataMail = oku.GetBoolean(16);
                if (!oku.IsDBNull(17))
                    yeniayar.Aktif = oku.GetBoolean(17);
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
        return yeniayar;
    }

    public static List<ayar> SelectAllayar(OleDbCommand komut)
    {
        List<ayar> Listayar = new List<ayar>();

        OleDbConnection baglanti = AcikBaglantiGetir();
        try
        {
            komut.Connection = baglanti;
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ayar yeniayar = new ayar();
                if (!oku.IsDBNull(0))
                    yeniayar.Id = oku.GetInt32(0);
                if (!oku.IsDBNull(1))
                    yeniayar.SirketAdi = oku.GetString(1);
                if (!oku.IsDBNull(2))
                    yeniayar.SiteAdi = oku.GetString(2);
                if (!oku.IsDBNull(3))
                    yeniayar.Adres = oku.GetString(3);
                if (!oku.IsDBNull(4))
                    yeniayar.Telefon = oku.GetString(4);
                if (!oku.IsDBNull(5))
                    yeniayar.Telefon2 = oku.GetString(5);
                if (!oku.IsDBNull(6))
                    yeniayar.Faks = oku.GetString(6);
                if (!oku.IsDBNull(7))
                    yeniayar.Gsm = oku.GetString(7);
                if (!oku.IsDBNull(8))
                    yeniayar.Klasor = oku.GetString(8);
                if (!oku.IsDBNull(9))
                    yeniayar.AdminMail = oku.GetString(9);
                if (!oku.IsDBNull(10))
                    yeniayar.Mail = oku.GetString(10);
                if (!oku.IsDBNull(11))
                    yeniayar.MailServer = oku.GetString(11);
                if (!oku.IsDBNull(12))
                    yeniayar.MailPassword = oku.GetString(12);
                if (!oku.IsDBNull(13))
                    yeniayar.MailPort = oku.GetString(13);
                if (!oku.IsDBNull(14))
                    yeniayar.SorumluMail = oku.GetString(14);
                if (!oku.IsDBNull(15))
                    yeniayar.HataLoglama = oku.GetBoolean(15);
                if (!oku.IsDBNull(16))
                    yeniayar.HataMail = oku.GetBoolean(16);
                if (!oku.IsDBNull(17))
                    yeniayar.Aktif = oku.GetBoolean(17);

                Listayar.Add(yeniayar);
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
        return Listayar;
    }


    public static hata Selecthata(OleDbCommand komut)
    {
        hata yenihata = null;

        OleDbConnection baglanti = AcikBaglantiGetir();
        try
        {
            komut.Connection = baglanti;
            OleDbDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                yenihata = new hata();
                if (!oku.IsDBNull(0))
                    yenihata.Id = oku.GetInt32(0);
                if (!oku.IsDBNull(1))
                    yenihata.HelpLink = oku.GetString(1);
                if (!oku.IsDBNull(2))
                    yenihata.InnerException = oku.GetString(2);
                if (!oku.IsDBNull(3))
                    yenihata.Message = oku.GetString(3);
                if (!oku.IsDBNull(4))
                    yenihata.Source = oku.GetString(4);
                if (!oku.IsDBNull(5))
                    yenihata.StackTrace = oku.GetString(5);
                if (!oku.IsDBNull(6))
                    yenihata.TargetSite = oku.GetString(6);
                if (!oku.IsDBNull(7))
                    yenihata.Tarih = oku.GetDateTime(7);
                if (!oku.IsDBNull(8))
                    yenihata.FkKullanici = oku.GetString(8);
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
        return yenihata;
    }

    public static List<hata> SelectAllhata(OleDbCommand komut)
    {
        List<hata> Listhata = new List<hata>();

        OleDbConnection baglanti = AcikBaglantiGetir();
        try
        {
            komut.Connection = baglanti;
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                hata yenihata = new hata();
                if (!oku.IsDBNull(0))
                    yenihata.Id = oku.GetInt32(0);
                if (!oku.IsDBNull(1))
                    yenihata.HelpLink = oku.GetString(1);
                if (!oku.IsDBNull(2))
                    yenihata.InnerException = oku.GetString(2);
                if (!oku.IsDBNull(3))
                    yenihata.Message = oku.GetString(3);
                if (!oku.IsDBNull(4))
                    yenihata.Source = oku.GetString(4);
                if (!oku.IsDBNull(5))
                    yenihata.StackTrace = oku.GetString(5);
                if (!oku.IsDBNull(6))
                    yenihata.TargetSite = oku.GetString(6);
                if (!oku.IsDBNull(7))
                    yenihata.Tarih = oku.GetDateTime(7);
                if (!oku.IsDBNull(8))
                    yenihata.FkKullanici = oku.GetString(8);

                Listhata.Add(yenihata);
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
        return Listhata;
    }



    public static ziyaretci Selectziyaretci(OleDbCommand komut)
    {
        ziyaretci yeniziyaretci = null;

        OleDbConnection baglanti = AcikBaglantiGetir();
        try
        {
            komut.Connection = baglanti;
            OleDbDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                yeniziyaretci = new ziyaretci();
                if (!oku.IsDBNull(0))
                    yeniziyaretci.Id = oku.GetInt32(0);
                if (!oku.IsDBNull(1))
                    yeniziyaretci.Ip = oku.GetString(1);
                if (!oku.IsDBNull(2))
                    yeniziyaretci.Dil = oku.GetString(2);
                if (!oku.IsDBNull(3))
                    yeniziyaretci.Sistem = oku.GetString(3);
                if (!oku.IsDBNull(4))
                    yeniziyaretci.Browser = oku.GetString(4);
                if (!oku.IsDBNull(5))
                    yeniziyaretci.Tarih = oku.GetDateTime(5);
                if (!oku.IsDBNull(6))
                    yeniziyaretci.Link = oku.GetString(6);
                if (!oku.IsDBNull(7))
                    yeniziyaretci.Gonderen = oku.GetString(7);
                if (!oku.IsDBNull(8))
                    yeniziyaretci.Durum = oku.GetBoolean(8);
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
        return yeniziyaretci;
    }

    public static List<ziyaretci> SelectAllziyaretci(OleDbCommand komut)
    {
        List<ziyaretci> Listziyaretci = new List<ziyaretci>();

        OleDbConnection baglanti = AcikBaglantiGetir();
        try
        {
            komut.Connection = baglanti;
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ziyaretci yeniziyaretci = new ziyaretci();
                if (!oku.IsDBNull(0))
                    yeniziyaretci.Id = oku.GetInt32(0);
                if (!oku.IsDBNull(1))
                    yeniziyaretci.Ip = oku.GetString(1);
                if (!oku.IsDBNull(2))
                    yeniziyaretci.Dil = oku.GetString(2);
                if (!oku.IsDBNull(3))
                    yeniziyaretci.Sistem = oku.GetString(3);
                if (!oku.IsDBNull(4))
                    yeniziyaretci.Browser = oku.GetString(4);
                if (!oku.IsDBNull(5))
                    yeniziyaretci.Tarih = oku.GetDateTime(5);
                if (!oku.IsDBNull(6))
                    yeniziyaretci.Link = oku.GetString(6);
                if (!oku.IsDBNull(7))
                    yeniziyaretci.Gonderen = oku.GetString(7);
                if (!oku.IsDBNull(8))
                    yeniziyaretci.Durum = oku.GetBoolean(8);

                Listziyaretci.Add(yeniziyaretci);
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
        return Listziyaretci;
    }

}



