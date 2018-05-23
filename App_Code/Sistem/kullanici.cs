
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Web;
using System.Linq;
public class kullanici
{
    #region Fields

    private int _Id;
    private string _AdiSoyadi;
    private string _KullaniciAdi;
    private string _Sifre;
    private string _Mail;
    private string _Tel;
    private string _Adres;
    private bool _AdminMi;
    private bool _Durum;

    #endregion Fields

    #region Public Properties

    public int Id
    {
        get { return _Id; }
        set { _Id = value; }
    }
    public string AdiSoyadi
    {
        get { return _AdiSoyadi; }
        set { _AdiSoyadi = value; }
    }
    public string KullaniciAdi
    {
        get { return _KullaniciAdi; }
        set { _KullaniciAdi = value; }
    }
    public string Sifre
    {
        get { return _Sifre; }
        set { _Sifre = value; }
    }
    public string Mail
    {
        get { return _Mail; }
        set { _Mail = value; }
    }
    public string Tel
    {
        get { return _Tel; }
        set { _Tel = value; }
    }
    public string Adres
    {
        get { return _Adres; }
        set { _Adres = value; }
    }
    public bool AdminMi
    {
        get { return _AdminMi; }
        set { _AdminMi = value; }
    }
    public bool Durum
    {
        get { return _Durum; }
        set { _Durum = value; }
    }

    #endregion Public Properties

    #region Constructors

    public kullanici()
    { }

    public kullanici(  string AdiSoyadi, string KullaniciAdi, string Sifre, string Mail, string Tel, string Adres, bool AdminMi, bool Durum)
    {
        this._Id = Id;
        this._AdiSoyadi = AdiSoyadi;
        this._KullaniciAdi = KullaniciAdi;
        this._Sifre = Sifre;
        this._Mail = Mail;
        this._Tel = Tel;
        this._Adres = Adres;
        this._AdminMi = AdminMi;
        this._Durum = Durum;
    }

    #endregion Constructors

    #region VeriTabani İşlemleri


    public Result<int> Insert()
    {
        OleDbCommand komut = new OleDbCommand("usp_kullaniciInsert");
        komut.CommandType = CommandType.StoredProcedure;

        OleDbParameter[] parametreler = new OleDbParameter[]
		{
            new OleDbParameter("pAdiSoyadi", AdiSoyadi)
			,new OleDbParameter("pKullaniciAdi", KullaniciAdi)
			,new OleDbParameter("pSifre", Sifre)
			,new OleDbParameter("pMail", Mail)
			,new OleDbParameter("pTel", Tel)
			,new OleDbParameter("pAdres", Adres)
			,new OleDbParameter("pAdminMi", AdminMi)
			,new OleDbParameter("pDurum", Durum)
		};

        komut.Parameters.AddRange(parametreler);

        //OleDbParameter sonuc = new OleDbParameter("@pReturnValue", DbType.Int32);
        //sonuc.Direction = ParameterDirection.Output;
        //komut.Parameters.Add(sonuc);

        return SistemDAL.ExecuteWithResult(komut);
    }

    public Result<int> Update()
    {
        OleDbCommand komut = new OleDbCommand("usp_kullaniciUpdate");
        komut.CommandType = CommandType.StoredProcedure;

        OleDbParameter[] parametreler = new OleDbParameter[]
		{

			new OleDbParameter("pId", Id)
			,new OleDbParameter("pAdiSoyadi", AdiSoyadi)
			,new OleDbParameter("pKullaniciAdi", KullaniciAdi)
			,new OleDbParameter("pSifre", Sifre)
			,new OleDbParameter("pMail", Mail)
			,new OleDbParameter("pTel", Tel)
			,new OleDbParameter("pAdres", Adres)
			,new OleDbParameter("pAdminMi", AdminMi)
			,new OleDbParameter("pDurum", Durum)
		};

        komut.Parameters.AddRange(parametreler);

        //OleDbParameter sonuc = new OleDbParameter("@pReturnValue", DbType.Int32);
        //sonuc.Direction = ParameterDirection.Output;
        //komut.Parameters.Add(sonuc);

        return SistemDAL.ExecuteWithResult(komut);
    }

    public Result<int> Delete()
    {
        OleDbCommand komut = new OleDbCommand("usp_kullaniciDelete");
        komut.CommandType = CommandType.StoredProcedure;

        OleDbParameter[] parametreler = new OleDbParameter[]
		{

			new OleDbParameter("@pId", this.Id)
		};

        komut.Parameters.AddRange(parametreler);

        //OleDbParameter sonuc = new OleDbParameter("@pReturnValue", DbType.Int32);
        //sonuc.Direction = ParameterDirection.Output;
        //komut.Parameters.Add(sonuc);

        return SistemDAL.ExecuteWithResult(komut);
    }

    public static kullanici Select(int Id)
    {
        OleDbCommand komut = new OleDbCommand("select * from kullanici where Id=" + Id + "");
        komut.CommandType = CommandType.Text;
        return SistemDAL.Selectkullanici(komut);
    }

    public static List<kullanici> SelectAll()
    {
        OleDbCommand komut = new OleDbCommand("select * from kullanici");
        komut.CommandType = CommandType.Text;
        return SistemDAL.SelectAllkullanici(komut);
    }



    #endregion VeriTabani İşlemleri

}
