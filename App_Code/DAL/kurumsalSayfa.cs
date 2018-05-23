
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Web;
using System.Linq;
public class kurumsalSayfa
{
    #region Fields

    private int _Id;
    private string _Adi;
    private string _Icerik;

    #endregion Fields

    #region Public Properties

    public int Id
    {
        get { return _Id; }
        set { _Id = value; }
    }
    public string Adi
    {
        get { return _Adi; }
        set { _Adi = value; }
    }
    public string Icerik
    {
        get { return _Icerik; }
        set { _Icerik = value; }
    }

    #endregion Public Properties

    #region Constructors

    public kurumsalSayfa()
    { }

    public kurumsalSayfa(int Id, string Adi, string Icerik)
    {
        this._Id = Id;
        this._Adi = Adi;
        this._Icerik = Icerik;
    }

    public kurumsalSayfa(string Adi, string Icerik)
    {
        this._Adi = Adi;
        this._Icerik = Icerik;
    }

    #endregion Constructors

    #region VeriTabani İşlemleri


    public Result<int> Insert()
    {
        OleDbCommand komut = new OleDbCommand("usp_kurumsalSayfaInsert");
        komut.CommandType = CommandType.StoredProcedure;

        OleDbParameter[] parametreler = new OleDbParameter[]
		{

			//new OleDbParameter("pId", Id)
			new OleDbParameter("pAdi", Adi)
			,new OleDbParameter("pIcerik", Icerik)
		};

        komut.Parameters.AddRange(parametreler);

        //OleDbParameter sonuc = new OleDbParameter("@pReturnValue", DbType.Int32);
        //sonuc.Direction = ParameterDirection.Output;
        //komut.Parameters.Add(sonuc);

        OleDbCommand komutIdentity = new OleDbCommand("SELECT @@Identity FROM kurumsalSayfa");
        return ClassDAL.ExecuteReturnIdentity(komut, komutIdentity);
    }

    public Result<int> Update()
    {
        OleDbCommand komut = new OleDbCommand("usp_kurumsalSayfaUpdate");
        komut.CommandType = CommandType.StoredProcedure;

        OleDbParameter[] parametreler = new OleDbParameter[]
		{

			new OleDbParameter("pId", Id)
			,new OleDbParameter("pAdi", Adi)
			,new OleDbParameter("pIcerik", Icerik)
		};

        komut.Parameters.AddRange(parametreler);

        //OleDbParameter sonuc = new OleDbParameter("@pReturnValue", DbType.Int32);
        //sonuc.Direction = ParameterDirection.Output;
        //komut.Parameters.Add(sonuc);

        return ClassDAL.ExecuteWithResult(komut);
    }

    public Result<int> Delete()
    {
        OleDbCommand komut = new OleDbCommand("usp_kurumsalSayfaDelete");
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

    public static kurumsalSayfa Select(int Id)
    {
        OleDbCommand komut = new OleDbCommand("select * from kurumsalSayfa where Id=" + Id + "");
        komut.CommandType = CommandType.Text;
        return ClassDAL.SelectkurumsalSayfa(komut);
    }

    public static List<kurumsalSayfa> SelectAll()
    {
        OleDbCommand komut = new OleDbCommand("select * from kurumsalSayfa");
        komut.CommandType = CommandType.Text;
        return ClassDAL.SelectAllkurumsalSayfa(komut);
    }


    #endregion VeriTabani İşlemleri

}
