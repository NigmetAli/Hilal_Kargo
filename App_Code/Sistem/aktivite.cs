
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Web;
using System.Linq;

public class aktivite
{
    #region Fields

    private int _Id;
    private int _KullaniciId;
    private DateTime _Tarih;

    #endregion Fields

    #region Public Properties

    public int Id
    {
        get { return _Id; }
        set { _Id = value; }
    }
    public int KullaniciId
    {
        get { return _KullaniciId; }
        set { _KullaniciId = value; }
    }
    public DateTime Tarih
    {
        get { return _Tarih; }
        set { _Tarih = value; }
    }

    #endregion Public Properties

    #region Constructors

    public aktivite()
    { }

    public aktivite(int KullaniciId, DateTime Tarih)
    {
        this._KullaniciId = KullaniciId;
        this._Tarih = Tarih;
    }

    #endregion Constructors

    #region VeriTabani İşlemleri


    public Result<int> Insert()
    {
        OleDbCommand komut = new OleDbCommand("usp_aktiviteInsert");
        komut.CommandType = CommandType.StoredProcedure;

        OleDbParameter[] parametreler = new OleDbParameter[]
		{
            new OleDbParameter("pKullaniciId", KullaniciId)
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
        OleDbCommand komut = new OleDbCommand("usp_aktiviteUpdate");
        komut.CommandType = CommandType.StoredProcedure;

        OleDbParameter[] parametreler = new OleDbParameter[]
		{

			new OleDbParameter("pId", Id)
			,new OleDbParameter("pKullaniciId", KullaniciId)
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
        OleDbCommand komut = new OleDbCommand("usp_aktiviteDelete");
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

    public static aktivite Select(int Id)
    {
        OleDbCommand komut = new OleDbCommand("select * from aktivite where Id=" + Id + "");
        komut.CommandType = CommandType.Text;
        return SistemDAL.Selectaktivite(komut);
    }

    public static aktivite SelectByKullaniciId(Int32 Id)
    {
        OleDbCommand komut = new OleDbCommand("usp_aktiviteSelectByKullaniciId");
        komut.CommandType = CommandType.StoredProcedure;

        OleDbParameter[] parametreler = new OleDbParameter[]
		{

			new OleDbParameter("@pKullaniciId", Id)
		};

        komut.Parameters.AddRange(parametreler);

        return SistemDAL.Selectaktivite(komut);
    }

    public static List<aktivite> SelectAll()
    {
        OleDbCommand komut = new OleDbCommand("select * from aktivite");
        komut.CommandType = CommandType.Text;
        return SistemDAL.SelectAllaktivite(komut);
    }


    #endregion VeriTabani İşlemleri

}
