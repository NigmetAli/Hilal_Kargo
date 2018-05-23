
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Web;
using System.Linq;
public class urunResim
{
    #region Fields

    private int _Id;
    private int _FkUrun;
    private string _Resim;

    #endregion Fields

    #region Public Properties

    public int Id
    {
        get { return _Id; }
        set { _Id = value; }
    }
    public int FkUrun
    {
        get { return _FkUrun; }
        set { _FkUrun = value; }
    }
    public string Resim
    {
        get { return _Resim; }
        set { _Resim = value; }
    }

    #endregion Public Properties

    #region Constructors

    public urunResim()
    { }

    public urunResim(int Id, int FkUrun, string Resim)
    {
        this._Id = Id;
        this._FkUrun = FkUrun;
        this._Resim = Resim;
    }

    public urunResim(int FkUrun, string Resim)
    {
        this._FkUrun = FkUrun;
        this._Resim = Resim;
    }

    #endregion Constructors

    #region VeriTabani İşlemleri


    public Result<int> Insert()
    {
        OleDbCommand komut = new OleDbCommand("usp_urunResimInsert");
        komut.CommandType = CommandType.StoredProcedure;

        OleDbParameter[] parametreler = new OleDbParameter[]
		{

			//new OleDbParameter("pId", Id)
			new OleDbParameter("pFkUrun", FkUrun)
			,new OleDbParameter("pResim", Resim)
		};

        komut.Parameters.AddRange(parametreler);

        //OleDbParameter sonuc = new OleDbParameter("@pReturnValue", DbType.Int32);
        //sonuc.Direction = ParameterDirection.Output;
        //komut.Parameters.Add(sonuc);

        OleDbCommand komutIdentity = new OleDbCommand("SELECT @@Identity FROM urunResim");
        return ClassDAL.ExecuteReturnIdentity(komut, komutIdentity);
    }

    public Result<int> Update()
    {
        OleDbCommand komut = new OleDbCommand("usp_urunResimUpdate");
        komut.CommandType = CommandType.StoredProcedure;

        OleDbParameter[] parametreler = new OleDbParameter[]
		{

			new OleDbParameter("pId", Id)
			,new OleDbParameter("pFkUrun", FkUrun)
			,new OleDbParameter("pResim", Resim)
		};

        komut.Parameters.AddRange(parametreler);

        //OleDbParameter sonuc = new OleDbParameter("@pReturnValue", DbType.Int32);
        //sonuc.Direction = ParameterDirection.Output;
        //komut.Parameters.Add(sonuc);

        return ClassDAL.ExecuteWithResult(komut);
    }

    public Result<int> Delete()
    {
        OleDbCommand komut = new OleDbCommand("usp_urunResimDelete");
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

    public static urunResim Select(int Id)
    {
        OleDbCommand komut = new OleDbCommand("select * from urunResim where Id=" + Id + "");
        komut.CommandType = CommandType.Text;
        return ClassDAL.SelecturunResim(komut);
    }

    public static List<urunResim> SelectAll()
    {
        OleDbCommand komut = new OleDbCommand("select * from urunResim");
        komut.CommandType = CommandType.Text;
        return ClassDAL.SelectAllurunResim(komut);
    }


    #endregion VeriTabani İşlemleri

    public static List<urunResim> SelectByFkUrun(int Id)
    {
        OleDbCommand komut = new OleDbCommand("select * from urunResim where FkUrun=" + Id + "");
        komut.CommandType = CommandType.Text;
        return ClassDAL.SelectAllurunResim(komut);
    }
}
