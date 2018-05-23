
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Web;
using System.Linq;
public class iletisim
{
    #region Fields

    private int _Id;
    private string _Isim;
    private string _Email;
    private string _Konu;
    private string _Mesaj;
    private bool _Durum;
    private DateTime _Tarih;

    #endregion Fields

    #region Public Properties

    public int Id
    {
        get { return _Id; }
        set { _Id = value; }
    }
    public string Isim
    {
        get { return _Isim; }
        set { _Isim = value; }
    }
    public string Email
    {
        get { return _Email; }
        set { _Email = value; }
    }
    public string Konu
    {
        get { return _Konu; }
        set { _Konu = value; }
    }
    public string Mesaj
    {
        get { return _Mesaj; }
        set { _Mesaj = value; }
    }
    public bool Durum
    {
        get { return _Durum; }
        set { _Durum = value; }
    }
    public DateTime Tarih
    {
        get { return _Tarih; }
        set { _Tarih = value; }
    }

    #endregion Public Properties

    #region Constructors

    public iletisim()
    { }

    public iletisim(int Id, string Isim, string Email, string Konu, string Mesaj, bool Durum, DateTime Tarih)
    {
        this._Id = Id;
        this._Isim = Isim;
        this._Email = Email;
        this._Konu = Konu;
        this._Mesaj = Mesaj;
        this._Durum = Durum;
        this._Tarih = Tarih;
    }

    #endregion Constructors

    #region VeriTabani İşlemleri


    public Result<int> Insert()
    {
        OleDbCommand komut = new OleDbCommand("usp_iletisimInsert");
        komut.CommandType = CommandType.StoredProcedure;

        OleDbParameter[] parametreler = new OleDbParameter[]
		{

            new OleDbParameter("pIsim", Isim)
			,new OleDbParameter("pEmail", Email)
			,new OleDbParameter("pKonu", Konu)
			,new OleDbParameter("pMesaj", Mesaj)
			,new OleDbParameter("pDurum", Durum)
			,new OleDbParameter("pTarih", Tarih.ToString())
		};

        komut.Parameters.AddRange(parametreler);

        //OleDbParameter sonuc = new OleDbParameter("@pReturnValue", DbType.Int32);
        //sonuc.Direction = ParameterDirection.Output;
        //komut.Parameters.Add(sonuc);

        return SistemDAL.ExecuteWithResult(komut);
    }

    public Result<int> Update()
    {
        OleDbCommand komut = new OleDbCommand("usp_iletisimUpdate");
        komut.CommandType = CommandType.StoredProcedure;

        OleDbParameter[] parametreler = new OleDbParameter[]
		{

			new OleDbParameter("pId", Id)
			,new OleDbParameter("pIsim", Isim)
			,new OleDbParameter("pEmail", Email)
			,new OleDbParameter("pKonu", Konu)
			,new OleDbParameter("pMesaj", Mesaj)
			,new OleDbParameter("pDurum", Durum)
			,new OleDbParameter("pTarih", Tarih.ToString())
		};

        komut.Parameters.AddRange(parametreler);

        //OleDbParameter sonuc = new OleDbParameter("@pReturnValue", DbType.Int32);
        //sonuc.Direction = ParameterDirection.Output;
        //komut.Parameters.Add(sonuc);

        return SistemDAL.ExecuteWithResult(komut);
    }

    public Result<int> Delete()
    {
        OleDbCommand komut = new OleDbCommand("usp_iletisimDelete");
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

    public static iletisim Select(int Id)
    {
        OleDbCommand komut = new OleDbCommand("select * from iletisim where Id=" + Id + "");
        komut.CommandType = CommandType.Text;
        return SistemDAL.Selectiletisim(komut);
    }
    
    public static List<iletisim> SelectAll()
    {
        OleDbCommand komut = new OleDbCommand("select * from iletisim");
        komut.CommandType = CommandType.Text;
        return SistemDAL.SelectAlliletisim(komut);
    }


    #endregion VeriTabani İşlemleri

}
