
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Web;
using System.Linq;
public class hata
{
    #region Fields

    private int _Id;
    private string _HelpLink;
    private string _InnerException;
    private string _Message;
    private string _Source;
    private string _StackTrace;
    private string _TargetSite;
    private DateTime _Tarih;
    private string _FkKullanici;

    #endregion Fields

    #region Public Properties

    public int Id
    {
        get { return _Id; }
        set { _Id = value; }
    }
    public string HelpLink
    {
        get { return _HelpLink; }
        set { _HelpLink = value; }
    }
    public string InnerException
    {
        get { return _InnerException; }
        set { _InnerException = value; }
    }
    public string Message
    {
        get { return _Message; }
        set { _Message = value; }
    }
    public string Source
    {
        get { return _Source; }
        set { _Source = value; }
    }
    public string StackTrace
    {
        get { return _StackTrace; }
        set { _StackTrace = value; }
    }
    public string TargetSite
    {
        get { return _TargetSite; }
        set { _TargetSite = value; }
    }
    public DateTime Tarih
    {
        get { return _Tarih; }
        set { _Tarih = value; }
    }
    public string FkKullanici
    {
        get { return _FkKullanici; }
        set { _FkKullanici = value; }
    }

    #endregion Public Properties

    #region Constructors

    public hata()
    { }

    public hata(string HelpLink, string InnerException, string Message, string Source, string StackTrace, string TargetSite, DateTime Tarih, string FkKullanici)
    {
        this._HelpLink = HelpLink;
        this._InnerException = InnerException;
        this._Message = Message;
        this._Source = Source;
        this._StackTrace = StackTrace;
        this._TargetSite = TargetSite;
        this._Tarih = Tarih;
        this._FkKullanici = FkKullanici;
    }

    #endregion Constructors

    #region VeriTabani İşlemleri


    public int Insert()
    {
        OleDbCommand komut = new OleDbCommand("usp_hataInsert");
        komut.CommandType = CommandType.StoredProcedure;

        OleDbParameter[] parametreler = new OleDbParameter[]
		{
            new OleDbParameter("pHelpLink", HelpLink)
			,new OleDbParameter("pInnerException", InnerException)
			,new OleDbParameter("pMessage", Message)
			,new OleDbParameter("pSource", Source)
			,new OleDbParameter("pStackTrace", StackTrace)
			,new OleDbParameter("pTargetSite", TargetSite)
			,new OleDbParameter("pTarih", Tarih.ToString())
			,new OleDbParameter("pFkKullanici", FkKullanici)
		};

        komut.Parameters.AddRange(parametreler);

        //OleDbParameter sonuc = new OleDbParameter("@pReturnValue", DbType.Int32);
        //sonuc.Direction = ParameterDirection.Output;
        //komut.Parameters.Add(sonuc);

        return SistemDAL.Execute(komut);
    }

    public int Update()
    {
        OleDbCommand komut = new OleDbCommand("usp_hataUpdate");
        komut.CommandType = CommandType.StoredProcedure;

        OleDbParameter[] parametreler = new OleDbParameter[]
		{

			new OleDbParameter("pId", Id)
			,new OleDbParameter("pHelpLink", HelpLink)
			,new OleDbParameter("pInnerException", InnerException)
			,new OleDbParameter("pMessage", Message)
			,new OleDbParameter("pSource", Source)
			,new OleDbParameter("pStackTrace", StackTrace)
			,new OleDbParameter("pTargetSite", TargetSite)
			,new OleDbParameter("pTarih",  Tarih.ToString())
			,new OleDbParameter("pFkKullanici", FkKullanici)
		};

        komut.Parameters.AddRange(parametreler);

        //OleDbParameter sonuc = new OleDbParameter("@pReturnValue", DbType.Int32);
        //sonuc.Direction = ParameterDirection.Output;
        //komut.Parameters.Add(sonuc);

        return SistemDAL.Execute(komut);
    }

    public int Delete()
    {
        OleDbCommand komut = new OleDbCommand("usp_hataDelete");
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

    public static int Temizle(DateTime tarih)
    {
        OleDbCommand komut = new OleDbCommand("usp_hataTemizle");
        komut.CommandType = CommandType.StoredProcedure;

        OleDbParameter[] parametreler = new OleDbParameter[]
		{

			new OleDbParameter("@pTarih", tarih.ToString())
		};

        komut.Parameters.AddRange(parametreler);

        //OleDbParameter sonuc = new OleDbParameter("@pReturnValue", DbType.Int32);
        //sonuc.Direction = ParameterDirection.Output;
        //komut.Parameters.Add(sonuc);

        return SistemDAL.Execute(komut);
    }

    public static hata Select(int Id)
    {
        OleDbCommand komut = new OleDbCommand("select * from hata where Id=" + Id + "");
        komut.CommandType = CommandType.Text;
        return SistemDAL.Selecthata(komut);
    }

    public static List<hata> SelectAll()
    {
        OleDbCommand komut = new OleDbCommand("select * from hata");
        komut.CommandType = CommandType.Text;
        return SistemDAL.SelectAllhata(komut);
    }

    #endregion VeriTabani İşlemleri

}
