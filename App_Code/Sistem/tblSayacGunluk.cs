
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Web;
using System.Linq;
public class tblSayacGunluk
{
    #region Fields

    private int _SayacId;
    private int _Tekil;
    private int _Cogul;
    private DateTime _Gun;

    #endregion Fields

    #region Public Properties

    public int SayacId
    {
        get { return _SayacId; }
        set { _SayacId = value; }
    }
    public int Tekil
    {
        get { return _Tekil; }
        set { _Tekil = value; }
    }
    public int Cogul
    {
        get { return _Cogul; }
        set { _Cogul = value; }
    }
    public DateTime Gun
    {
        get { return _Gun; }
        set { _Gun = value; }
    }

    #endregion Public Properties

    #region Constructors

    public tblSayacGunluk()
    { }

    public tblSayacGunluk(int SayacId, int Tekil, int Cogul, DateTime Gun)
    {
        this._SayacId = SayacId;
        this._Tekil = Tekil;
        this._Cogul = Cogul;
        this._Gun = Gun;
    }

    public tblSayacGunluk(int SayacId, int Tekil, DateTime Gun)
    {
        this._SayacId = SayacId;
        this._Tekil = Tekil;
        this._Gun = Gun;
    }

    #endregion Constructors

    #region VeriTabani İşlemleri


    public Result<int> Insert()
    {
        OleDbCommand komut = new OleDbCommand("usp_tblSayacGunlukInsert");
        komut.CommandType = CommandType.StoredProcedure;

        OleDbParameter[] parametreler = new OleDbParameter[]
		{

			new OleDbParameter("pSayacId", SayacId)
			,new OleDbParameter("pTekil", Tekil)
			,new OleDbParameter("pCogul", Cogul)
			,new OleDbParameter("pGun", Gun.ToString())
		};

        komut.Parameters.AddRange(parametreler);

        //OleDbParameter sonuc = new OleDbParameter("@pReturnValue", DbType.Int32);
        //sonuc.Direction = ParameterDirection.Output;
        //komut.Parameters.Add(sonuc);

        return SistemDAL.ExecuteWithResult(komut);
    }

    public Result<int> Update()
    {
        OleDbCommand komut = new OleDbCommand("usp_tblSayacGunlukUpdate");
        komut.CommandType = CommandType.StoredProcedure;

        OleDbParameter[] parametreler = new OleDbParameter[]
		{

			new OleDbParameter("pSayacId", SayacId)
			,new OleDbParameter("pTekil", Tekil)
            ,new OleDbParameter("pCogul", Cogul)
			,new OleDbParameter("pGun", Gun.ToString())
		};

        komut.Parameters.AddRange(parametreler);

        //OleDbParameter sonuc = new OleDbParameter("@pReturnValue", DbType.Int32);
        //sonuc.Direction = ParameterDirection.Output;
        //komut.Parameters.Add(sonuc);

        return SistemDAL.ExecuteWithResult(komut);
    }

    public Result<int> Delete()
    {
        OleDbCommand komut = new OleDbCommand("usp_tblSayacGunlukDelete");
        komut.CommandType = CommandType.StoredProcedure;

        OleDbParameter[] parametreler = new OleDbParameter[]
		{

			new OleDbParameter("@pSayacId", this.SayacId)
			,new OleDbParameter("@pTekil", this.Tekil)
			,new OleDbParameter("@pCogul", this.Cogul)
			,new OleDbParameter("@pGun", this.Gun)
		};

        komut.Parameters.AddRange(parametreler);

        //OleDbParameter sonuc = new OleDbParameter("@pReturnValue", DbType.Int32);
        //sonuc.Direction = ParameterDirection.Output;
        //komut.Parameters.Add(sonuc);

        return SistemDAL.ExecuteWithResult(komut);
    }

    public static tblSayacGunluk Select(string gunn)
    {

      
        OleDbCommand komut = new OleDbCommand("select * from tblSayacGunluk where gun=#" + gunn + "#");
        komut.CommandType = CommandType.Text;

        return SistemDAL.SelecttblSayacGunluk(komut);
    }

    public static List<tblSayacGunluk> SelectAll()
    {
        OleDbCommand komut = new OleDbCommand("usp_tblSayacGunlukSelectAll");
        komut.CommandType = CommandType.StoredProcedure;
        return SistemDAL.SelectAlltblSayacGunluk(komut);
    }


    #endregion VeriTabani İşlemleri

}
