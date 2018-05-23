
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Web;
using System.Linq;
public class urun
{
    #region Fields

    private int _Id;
    private int _FkKategori;
    private string _Adi;
    private string _Aciklama;
    private string _Resim;
    private string _Kumas;
    private bool _Aktif;

    #endregion Fields

    #region Public Properties

    public int Id
    {
        get { return _Id; }
        set { _Id = value; }
    }
    public int FkKategori
    {
        get { return _FkKategori; }
        set { _FkKategori = value; }
    }
    public string Adi
    {
        get { return _Adi; }
        set { _Adi = value; }
    }
    public string Aciklama
    {
        get { return _Aciklama; }
        set { _Aciklama = value; }
    }
    public string Resim
    {
        get { return _Resim; }
        set { _Resim = value; }
    }
    public string Kumas
    {
        get { return _Kumas; }
        set { _Kumas = value; }
    }
    public bool Aktif
    {
        get { return _Aktif; }
        set { _Aktif = value; }
    }

    #endregion Public Properties

    #region Constructors

    public urun()
    { }

    public urun(int Id, int FkKategori, string Adi, string Aciklama, string Resim, string Kumas, bool Aktif)
    {
        this._Id = Id;
        this._FkKategori = FkKategori;
        this._Adi = Adi;
        this._Aciklama = Aciklama;
        this._Resim = Resim;
        this._Kumas = Kumas;
        this._Aktif = Aktif;
    }

    public urun(int FkKategori, string Adi, string Aciklama, string Resim, string Kumas, bool Aktif)
    {
        this._FkKategori = FkKategori;
        this._Adi = Adi;
        this._Aciklama = Aciklama;
        this._Resim = Resim;
        this._Kumas = Kumas;
        this._Aktif = Aktif;
    }

    #endregion Constructors

    #region VeriTabani İşlemleri


    public Result<int> Insert()
    {
        OleDbCommand komut = new OleDbCommand("usp_urunInsert");
        komut.CommandType = CommandType.StoredProcedure;

        OleDbParameter[] parametreler = new OleDbParameter[]
		{

			//new OleDbParameter("pId", Id)
			new OleDbParameter("pFkKategori", FkKategori)
			,new OleDbParameter("pAdi", Adi)
			,new OleDbParameter("pAciklama", Aciklama)
			,new OleDbParameter("pResim", Resim)
			,new OleDbParameter("pKumas", Kumas)
			,new OleDbParameter("pAktif", Aktif)
		};

        komut.Parameters.AddRange(parametreler);

        //OleDbParameter sonuc = new OleDbParameter("@pReturnValue", DbType.Int32);
        //sonuc.Direction = ParameterDirection.Output;
        //komut.Parameters.Add(sonuc);

        OleDbCommand komutIdentity = new OleDbCommand("SELECT @@Identity FROM urun");
        return ClassDAL.ExecuteReturnIdentity(komut, komutIdentity);
    }

    public Result<int> Update()
    {
        OleDbCommand komut = new OleDbCommand("usp_urunUpdate");
        komut.CommandType = CommandType.StoredProcedure;

        OleDbParameter[] parametreler = new OleDbParameter[]
		{

			new OleDbParameter("pId", Id)
			,new OleDbParameter("pFkKategori", FkKategori)
			,new OleDbParameter("pAdi", Adi)
			,new OleDbParameter("pAciklama", Aciklama)
			,new OleDbParameter("pResim", Resim)
			,new OleDbParameter("pKumas", Kumas)
			,new OleDbParameter("pAktif", Aktif)
		};

        komut.Parameters.AddRange(parametreler);

        //OleDbParameter sonuc = new OleDbParameter("@pReturnValue", DbType.Int32);
        //sonuc.Direction = ParameterDirection.Output;
        //komut.Parameters.Add(sonuc);

        return ClassDAL.ExecuteWithResult(komut);
    }

    public Result<int> Delete()
    {
        OleDbCommand komut = new OleDbCommand("usp_urunDelete");
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

    public static urun Select(int Id)
    {
        OleDbCommand komut = new OleDbCommand("select * from urun where Id=" + Id + "");
        komut.CommandType = CommandType.Text;
        return ClassDAL.Selecturun(komut);
    }

    public static List<urun> SelectAll()
    {
        OleDbCommand komut = new OleDbCommand("select * from urun");
        komut.CommandType = CommandType.Text;
        return ClassDAL.SelectAllurun(komut);
    }
    public static List<urun> SelectByFkKategori(int fkkategori)
    {
        OleDbCommand komut = new OleDbCommand("select * from urun where Aktif=True and  FkKategori=" + fkkategori);
        komut.CommandType = CommandType.Text;
        return ClassDAL.SelectAllurun(komut);
    }


    #endregion VeriTabani İşlemleri

}
