
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Web;
using System.Linq;
public class kategori
{
    #region Fields

    private int _Id;
    private int _FkUstKategori;
    private string _Adi;
    private string _Resim;
    private bool _Aktif;

    #endregion Fields

    #region Public Properties

    public int Id
    {
        get { return _Id; }
        set { _Id = value; }
    }
    public int FkUstKategori
    {
        get { return _FkUstKategori; }
        set { _FkUstKategori = value; }
    }
    public string Adi
    {
        get { return _Adi; }
        set { _Adi = value; }
    }
    public string Resim
    {
        get { return _Resim; }
        set { _Resim = value; }
    }
    public bool Aktif
    {
        get { return _Aktif; }
        set { _Aktif = value; }
    }

    #endregion Public Properties

    #region Constructors

    public kategori()
    { }

    public kategori(int Id, int FkUstKategori, string Adi, string Resim, bool Aktif)
    {
        this._Id = Id;
        this._FkUstKategori = FkUstKategori;
        this._Adi = Adi;
        this._Resim = Resim;
        this._Aktif = Aktif;
    }

    #endregion Constructors

    #region VeriTabani İşlemleri


    public Result<int> Insert()
    {
        OleDbCommand komut = new OleDbCommand("usp_kategoriInsert");
        komut.CommandType = CommandType.StoredProcedure;

        OleDbParameter[] parametreler = new OleDbParameter[]
		{
            new OleDbParameter("pFkUstKategori", FkUstKategori)
			,new OleDbParameter("pAdi", Adi)
			,new OleDbParameter("pResim", Resim)
			,new OleDbParameter("pAktif", Aktif)
		};

        if (FkUstKategori == null)
            parametreler[0].Value = DBNull.Value;

        komut.Parameters.AddRange(parametreler);

        //OleDbParameter sonuc = new OleDbParameter("@pReturnValue", DbType.Int32);
        //sonuc.Direction = ParameterDirection.Output;
        //komut.Parameters.Add(sonuc);

        return ClassDAL.ExecuteWithResult(komut);
    }

    public Result<int> Update()
    {
        OleDbCommand komut = new OleDbCommand("usp_kategoriUpdate");
        komut.CommandType = CommandType.StoredProcedure;

        OleDbParameter[] parametreler = new OleDbParameter[]
		{

			new OleDbParameter("pId", Id)
			,new OleDbParameter("pFkUstKategori", FkUstKategori)
			,new OleDbParameter("pAdi", Adi)
			,new OleDbParameter("pResim", Resim)
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
        OleDbCommand komut = new OleDbCommand("usp_kategoriDelete");
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

    public static kategori Select(int Id)
    {
        OleDbCommand komut = new OleDbCommand("select * from kategori where Id=" + Id + "");
        komut.CommandType = CommandType.Text;
        return ClassDAL.Selectkategori(komut);
    }

    public static List<kategori> SelectAll()
    {
        OleDbCommand komut = new OleDbCommand("select * from kategori");
        komut.CommandType = CommandType.Text;
        return ClassDAL.SelectAllkategori(komut);
    }


    public static List<kategori> SelectUrunIcerenler()
    {
        OleDbCommand komut = new OleDbCommand("SELECT * FROM [kategori] WHERE ([Aktif] = True) and Id not in(select FkUstKategori from Kategori) order by Id");
        komut.CommandType = CommandType.Text;
        return ClassDAL.SelectAllkategori(komut);
    }


    #endregion VeriTabani İşlemleri

}
