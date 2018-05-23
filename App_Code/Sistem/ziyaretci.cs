
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Web;
using System.Linq;
public class ziyaretci
{
    #region Fields

    private int _Id;
    private string _Ip;
    private string _Dil;
    private string _Sistem;
    private string _Browser;
    private DateTime _Tarih;
    private string _Link;
    private string _Gonderen;
    private bool _Durum;

    #endregion Fields

    #region Public Properties

    public int Id
    {
        get { return _Id; }
        set { _Id = value; }
    }
    public string Ip
    {
        get { return _Ip; }
        set { _Ip = value; }
    }
    public string Dil
    {
        get { return _Dil; }
        set { _Dil = value; }
    }
    public string Sistem
    {
        get { return _Sistem; }
        set { _Sistem = value; }
    }
    public string Browser
    {
        get { return _Browser; }
        set { _Browser = value; }
    }
    public DateTime Tarih
    {
        get { return _Tarih; }
        set { _Tarih = value; }
    }
    public string Link
    {
        get { return _Link; }
        set { _Link = value; }
    }
    public string Gonderen
    {
        get { return _Gonderen; }
        set { _Gonderen = value; }
    }
    public bool Durum
    {
        get { return _Durum; }
        set { _Durum = value; }
    }

    #endregion Public Properties

    #region Constructors

    public ziyaretci()
    { }

    public ziyaretci(string Ip, string Dil, string Sistem, string Browser, DateTime Tarih, string Link, string Gonderen, bool Durum)
    {
        this._Ip = Ip;
        this._Dil = Dil;
        this._Sistem = Sistem;
        this._Browser = Browser;
        this._Tarih = Tarih;
        this._Link = Link;
        this._Gonderen = Gonderen;
        this._Durum = Durum;
    }

    #endregion Constructors

    #region VeriTabani İşlemleri


    public Result<int> Insert()
    {
        OleDbCommand komut = new OleDbCommand("usp_ziyaretciInsert");
        komut.CommandType = CommandType.StoredProcedure;

        OleDbParameter[] parametreler = new OleDbParameter[]
		{
            new OleDbParameter("pIp", Ip)
			,new OleDbParameter("pDil", Dil)
			,new OleDbParameter("pSistem", Sistem)
			,new OleDbParameter("pBrowser", Browser)
			,new OleDbParameter("pTarih", Tarih.ToString())
			,new OleDbParameter("pLink", Link)
			,new OleDbParameter("pGonderen", Gonderen)
			,new OleDbParameter("pDurum", Durum)
		};

        komut.Parameters.AddRange(parametreler);

        //OleDbParameter sonuc = new OleDbParameter("@pReturnValue", DbType.Int32);
        //sonuc.Direction = ParameterDirection.Output;
        //komut.Parameters.Add(sonuc);

        return SistemDAL.ExecuteWithResult(komut);
    }

    public int Update()
    {
        OleDbCommand komut = new OleDbCommand("usp_ziyaretciUpdate");
        komut.CommandType = CommandType.StoredProcedure;

        OleDbParameter[] parametreler = new OleDbParameter[]
		{

			new OleDbParameter("pId", Id)
			,new OleDbParameter("pIp", Ip)
			,new OleDbParameter("pDil", Dil)
			,new OleDbParameter("pSistem", Sistem)
			,new OleDbParameter("pBrowser", Browser)
			,new OleDbParameter("pTarih", Tarih.ToString())
			,new OleDbParameter("pLink", Link)
			,new OleDbParameter("pGonderen", Gonderen)
			,new OleDbParameter("pDurum", Durum)
		};

        komut.Parameters.AddRange(parametreler);

        //OleDbParameter sonuc = new OleDbParameter("@pReturnValue", DbType.Int32);
        //sonuc.Direction = ParameterDirection.Output;
        //komut.Parameters.Add(sonuc);

        return SistemDAL.Execute(komut);
    }

    public int Delete()
    {
        OleDbCommand komut = new OleDbCommand("usp_ziyaretciDelete");
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

    public static ziyaretci Select(int Id)
    {
        OleDbCommand komut = new OleDbCommand("select * from ziyaretci where Id=" + Id + "");
        komut.CommandType = CommandType.Text;
        return SistemDAL.Selectziyaretci(komut);
    }

    public static List<ziyaretci> SelectAll()
    {
        OleDbCommand komut = new OleDbCommand("select * from ziyaretci");
        komut.CommandType = CommandType.Text;
        return SistemDAL.SelectAllziyaretci(komut);
    }


    #endregion VeriTabani İşlemleri

}
