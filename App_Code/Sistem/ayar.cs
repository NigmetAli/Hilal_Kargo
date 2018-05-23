
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Web;
using System.Linq;
public class ayar
{
    #region Fields

    private int _Id;
    private string _SirketAdi;
    private string _SiteAdi;
    private string _Adres;
    private string _Telefon;
    private string _Telefon2;
    private string _Faks;
    private string _Gsm;
    private string _Klasor;
    private string _AdminMail;
    private string _Mail;
    private string _MailServer;
    private string _MailPassword;
    private string _MailPort;
    private string _SorumluMail;
    private bool _HataLoglama;
    private bool _HataMail;
    private bool _Aktif;

    #endregion Fields

    #region Public Properties

    public int Id
    {
        get { return _Id; }
        set { _Id = value; }
    }
    public string SirketAdi
    {
        get { return _SirketAdi; }
        set { _SirketAdi = value; }
    }
    public string SiteAdi
    {
        get { return _SiteAdi; }
        set { _SiteAdi = value; }
    }
    public string Adres
    {
        get { return _Adres; }
        set { _Adres = value; }
    }
    public string Telefon
    {
        get { return _Telefon; }
        set { _Telefon = value; }
    }
    public string Telefon2
    {
        get { return _Telefon2; }
        set { _Telefon2 = value; }
    }
    public string Faks
    {
        get { return _Faks; }
        set { _Faks = value; }
    }
    public string Gsm
    {
        get { return _Gsm; }
        set { _Gsm = value; }
    }
    public string Klasor
    {
        get { return _Klasor; }
        set { _Klasor = value; }
    }
    public string AdminMail
    {
        get { return _AdminMail; }
        set { _AdminMail = value; }
    }
    public string Mail
    {
        get { return _Mail; }
        set { _Mail = value; }
    }
    public string MailServer
    {
        get { return _MailServer; }
        set { _MailServer = value; }
    }
    public string MailPassword
    {
        get { return _MailPassword; }
        set { _MailPassword = value; }
    }
    public string MailPort
    {
        get { return _MailPort; }
        set { _MailPort = value; }
    }
    public string SorumluMail
    {
        get { return _SorumluMail; }
        set { _SorumluMail = value; }
    }
    public bool HataLoglama
    {
        get { return _HataLoglama; }
        set { _HataLoglama = value; }
    }
    public bool HataMail
    {
        get { return _HataMail; }
        set { _HataMail = value; }
    }
    public bool Aktif
    {
        get { return _Aktif; }
        set { _Aktif = value; }
    }

    #endregion Public Properties

    #region Constructors

    public ayar()
    { }

    public ayar(int Id, string SirketAdi, string SiteAdi, string Adres, string Telefon, string Telefon2, string Faks, string Gsm, string Klasor, string AdminMail, string Mail, string MailServer, string MailPassword, string MailPort, string SorumluMail, bool HataLoglama, bool HataMail, bool Aktif)
    {
        this._Id = Id;
        this._SirketAdi = SirketAdi;
        this._SiteAdi = SiteAdi;
        this._Adres = Adres;
        this._Telefon = Telefon;
        this._Telefon2 = Telefon2;
        this._Faks = Faks;
        this._Gsm = Gsm;
        this._Klasor = Klasor;
        this._AdminMail = AdminMail;
        this._Mail = Mail;
        this._MailServer = MailServer;
        this._MailPassword = MailPassword;
        this._MailPort = MailPort;
        this._SorumluMail = SorumluMail;
        this._HataLoglama = HataLoglama;
        this._HataMail = HataMail;
        this._Aktif = Aktif;
    }

    #endregion Constructors

    #region VeriTabani İşlemleri


    public int Insert()
    {
        OleDbCommand komut = new OleDbCommand("usp_ayarInsert");
        komut.CommandType = CommandType.StoredProcedure;

        OleDbParameter[] parametreler = new OleDbParameter[]
		{

			new OleDbParameter("pId", Id)
			,new OleDbParameter("pSirketAdi", SirketAdi)
			,new OleDbParameter("pSiteAdi", SiteAdi)
			,new OleDbParameter("pAdres", Adres)
			,new OleDbParameter("pTelefon", Telefon)
			,new OleDbParameter("pTelefon2", Telefon2)
			,new OleDbParameter("pFaks", Faks)
			,new OleDbParameter("pGsm", Gsm)
			,new OleDbParameter("pKlasor", Klasor)
			,new OleDbParameter("pAdminMail", AdminMail)
			,new OleDbParameter("pMail", Mail)
			,new OleDbParameter("pMailServer", MailServer)
			,new OleDbParameter("pMailPassword", MailPassword)
			,new OleDbParameter("pMailPort", MailPort)
			,new OleDbParameter("pSorumluMail", SorumluMail)
			,new OleDbParameter("pHataLoglama", HataLoglama)
			,new OleDbParameter("pHataMail", HataMail)
			,new OleDbParameter("pAktif", Aktif)
		};

        komut.Parameters.AddRange(parametreler);

        //OleDbParameter sonuc = new OleDbParameter("@pReturnValue", DbType.Int32);
        //sonuc.Direction = ParameterDirection.Output;
        //komut.Parameters.Add(sonuc);

        return SistemDAL.Execute(komut);
    }

    public int Update()
    {
        OleDbCommand komut = new OleDbCommand("usp_ayarUpdate");
        komut.CommandType = CommandType.StoredProcedure;

        OleDbParameter[] parametreler = new OleDbParameter[]
		{

			new OleDbParameter("pId", Id)
			,new OleDbParameter("pSirketAdi", SirketAdi)
			,new OleDbParameter("pSiteAdi", SiteAdi)
			,new OleDbParameter("pAdres", Adres)
			,new OleDbParameter("pTelefon", Telefon)
			,new OleDbParameter("pTelefon2", Telefon2)
			,new OleDbParameter("pFaks", Faks)
			,new OleDbParameter("pGsm", Gsm)
			,new OleDbParameter("pKlasor", Klasor)
			,new OleDbParameter("pAdminMail", AdminMail)
			,new OleDbParameter("pMail", Mail)
			,new OleDbParameter("pMailServer", MailServer)
			,new OleDbParameter("pMailPassword", MailPassword)
			,new OleDbParameter("pMailPort", MailPort)
			,new OleDbParameter("pSorumluMail", SorumluMail)
			,new OleDbParameter("pHataLoglama", HataLoglama)
			,new OleDbParameter("pHataMail", HataMail)
			,new OleDbParameter("pAktif", Aktif)
		};

        komut.Parameters.AddRange(parametreler);

        //OleDbParameter sonuc = new OleDbParameter("@pReturnValue", DbType.Int32);
        //sonuc.Direction = ParameterDirection.Output;
        //komut.Parameters.Add(sonuc);

        return SistemDAL.Execute(komut);
    }

    public int Delete()
    {
        OleDbCommand komut = new OleDbCommand("usp_ayarDelete");
        komut.CommandType = CommandType.StoredProcedure;

        OleDbParameter[] parametreler = new OleDbParameter[]
		{

			new OleDbParameter("@pId", this.Id)
		};

        komut.Parameters.AddRange(parametreler);

        //OleDbParameter sonuc = new OleDbParameter("@pReturnValue", DbType.Int32);
        //sonuc.Direction = ParameterDirection.Output;
        //komut.Parameters.Add(sonuc);

        return SistemDAL.Execute(komut);
    }

    public static ayar Select(int Id)
    {
        OleDbCommand komut = new OleDbCommand("select * from ayar where Id=" + Id + "");
        komut.CommandType = CommandType.Text;
        return SistemDAL.Selectayar(komut);
    }

    public static ayar Select()
    {
        OleDbCommand komut = new OleDbCommand("select top 1 * from ayar");
        komut.CommandType = CommandType.Text;
        return SistemDAL.Selectayar(komut);
    }

    public static List<ayar> SelectAll()
    {
        OleDbCommand komut = new OleDbCommand("select * from ayar");
        komut.CommandType = CommandType.Text;
        return SistemDAL.SelectAllayar(komut);
    }
    

    #endregion VeriTabani İşlemleri

}
