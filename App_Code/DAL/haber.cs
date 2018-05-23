
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Web;
using System.Linq;
public class haber
{
    #region Fields

    private int _Id;
    private string _Baslik;
    private string _Resim;
    private string _Yazi;
    private string _Tarih;
    private bool _Aktif;
    private string _AltBaslik;

    #endregion Fields

    #region Public Properties

    public int Id
    {
        get { return _Id; }
        set { _Id = value; }
    }
    public string Baslik
    {
        get { return _Baslik; }
        set { _Baslik = value; }
    }
    public string Resim
    {
        get { return _Resim; }
        set { _Resim = value; }
    }
    public string Yazi
    {
        get { return _Yazi; }
        set { _Yazi = value; }
    }
    public string Tarih
    {
        get { return _Tarih; }
        set { _Tarih = value; }
    }
    public bool Aktif
    {
        get { return _Aktif; }
        set { _Aktif = value; }
    }
    public string AltBaslik
    {
        get { return _AltBaslik; }
        set { _AltBaslik = value; }
    }

    #endregion Public Properties

    #region Constructors

    public haber()
    { }

    public haber(int Id, string Baslik, string Resim, string Yazi, string Tarih, bool Aktif, string AltBaslik)
    {
        this._Id = Id;
        this._Baslik = Baslik;
        this._Resim = Resim;
        this._Yazi = Yazi;
        this._Tarih = Tarih;
        this._Aktif = Aktif;
        this._AltBaslik = AltBaslik;
    }

    #endregion Constructors

    #region VeriTabani İşlemleri


    public Result<int> Insert()
    {
        OleDbCommand komut = new OleDbCommand("usp_haberInsert");
        komut.CommandType = CommandType.StoredProcedure;

        OleDbParameter[] parametreler = new OleDbParameter[]
		{
            new OleDbParameter("pBaslik", Baslik)
			,new OleDbParameter("pResim", Resim)
			,new OleDbParameter("pYazi", Yazi)
			,new OleDbParameter("pTarih", Tarih)
			,new OleDbParameter("pAktif", Aktif)
			,new OleDbParameter("pAltBaslik", AltBaslik)
		};

        komut.Parameters.AddRange(parametreler);

        //OleDbParameter sonuc = new OleDbParameter("@pReturnValue", DbType.Int32);
        //sonuc.Direction = ParameterDirection.Output;
        //komut.Parameters.Add(sonuc);

        return ClassDAL.ExecuteWithResult(komut);
    }

    public Result<int> Update()
    {
        OleDbCommand komut = new OleDbCommand("usp_haberUpdate");
        komut.CommandType = CommandType.StoredProcedure;

        OleDbParameter[] parametreler = new OleDbParameter[]
		{

			new OleDbParameter("pId", Id)
			,new OleDbParameter("pBaslik", Baslik)
			,new OleDbParameter("pResim", Resim)
			,new OleDbParameter("pYazi", Yazi)
			,new OleDbParameter("pTarih", Tarih)
			,new OleDbParameter("pAktif", Aktif)
			,new OleDbParameter("pAltBaslik", AltBaslik)
		};

        komut.Parameters.AddRange(parametreler);

        //OleDbParameter sonuc = new OleDbParameter("@pReturnValue", DbType.Int32);
        //sonuc.Direction = ParameterDirection.Output;
        //komut.Parameters.Add(sonuc);

        return ClassDAL.ExecuteWithResult(komut);
    }

    public Result<int> Delete()
    {
        OleDbCommand komut = new OleDbCommand("usp_haberDelete");
        komut.CommandType = CommandType.StoredProcedure;

        OleDbParameter[] parametreler = new OleDbParameter[]
		{

			new OleDbParameter("@pId", this.Id)
		};

        komut.Parameters.AddRange(parametreler);

        //OleDbParameter sonuc = new OleDbParameter("@pReturnValue", DbType.Int32);
        //sonuc.Direction = ParameterDirection.Output;
        //komut.Parameters.Add(sonuc);

        return ClassDAL.ExecuteWithResult(komut);
    }

    public static haber Select(int Id)
    {
        OleDbCommand komut = new OleDbCommand("select * from haber where Id=" + Id + "");
        komut.CommandType = CommandType.Text;
        return ClassDAL.Selecthaber(komut);
    }

    public static List<haber> SelectAll()
    {
        OleDbCommand komut = new OleDbCommand("select * from haber");
        komut.CommandType = CommandType.Text;
        return ClassDAL.SelectAllhaber(komut);
    }


    #endregion VeriTabani İşlemleri

}
