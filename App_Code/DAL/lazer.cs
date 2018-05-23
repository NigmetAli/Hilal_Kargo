
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Web;
using System.Linq;
public class lazer
{
    #region Fields

    private int _ID;
    private string _Adi;
    private string _Aciklama;
    private string _Resim;
    private int _Sira;
    private string _MetaKeyword;
    private string _MetaDescription;
    private string _MetaTitle;
    private string _SeoYazisi;

    #endregion Fields

    #region Public Properties

    public int ID
    {
        get { return _ID; }
        set { _ID = value; }
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
    public int Sira
    {
        get { return _Sira; }
        set { _Sira = value; }
    }
    public string MetaKeyword
    {
        get { return _MetaKeyword; }
        set { _MetaKeyword = value; }
    }
    public string MetaDescription
    {
        get { return _MetaDescription; }
        set { _MetaDescription = value; }
    }
    public string MetaTitle
    {
        get { return _MetaTitle; }
        set { _MetaTitle = value; }
    }
    public string SeoYazisi
    {
        get { return _SeoYazisi; }
        set { _SeoYazisi = value; }
    }
    #endregion Public Properties

    #region Constructors

    public lazer()
    { }

    public lazer(int ID, string Adi, string Aciklama, string Resim, int Sira, string MetaKeyword, string MetaDescription, string MetaTitle,string SeoYazisi)
    {
        this._ID = ID;
        this._Adi = Adi;
        this._Aciklama = Aciklama;
        this._Resim = Resim;
        this._Sira = Sira;
        this._MetaKeyword = MetaKeyword;
        this._MetaDescription = MetaDescription;
        this._MetaTitle = MetaTitle;
        this._SeoYazisi = SeoYazisi;
    }

    public lazer(string Adi, string Aciklama, string Resim, int Sira, string MetaKeyword, string MetaDescription, string MetaTitle,string SeoYazisi)
    {
        this._Adi = Adi;
        this._Aciklama = Aciklama;
        this._Resim = Resim;
        this._Sira = Sira;
        this._MetaKeyword = MetaKeyword;
        this._MetaDescription = MetaDescription;
        this._MetaTitle = MetaTitle;
        this._SeoYazisi = SeoYazisi;
    }

    #endregion Constructors

    #region VeriTabani İşlemleri


    public Result<int> Insert()
    {
        OleDbCommand komut = new OleDbCommand("usp_lazerInsert");
        komut.CommandType = CommandType.StoredProcedure;

        OleDbParameter[] parametreler = new OleDbParameter[]
		{

			//new OleDbParameter("pID", ID)
			new OleDbParameter("pAdi", Adi)
			,new OleDbParameter("pAciklama", Aciklama)
			,new OleDbParameter("pResim", Resim)
			,new OleDbParameter("pSira", Sira)
            ,new OleDbParameter("pMetaKeyword",MetaKeyword)
            ,new OleDbParameter("pMetaDescription",MetaDescription)
            ,new OleDbParameter("pMetaTitle",MetaTitle)            
            ,new OleDbParameter("pSeoYazisi",SeoYazisi)
		};

        komut.Parameters.AddRange(parametreler);

        //OleDbParameter sonuc = new OleDbParameter("@pReturnValue", DbType.Int32);
        //sonuc.Direction = ParameterDirection.Output;
        //komut.Parameters.Add(sonuc);

        OleDbCommand komutIdentity = new OleDbCommand("SELECT @@Identity FROM lazer");
        return ClassDAL.ExecuteReturnIdentity(komut, komutIdentity);
    }

    public Result<int> Update()
    {
        OleDbCommand komut = new OleDbCommand("usp_lazerUpdate");
        komut.CommandType = CommandType.StoredProcedure;

        OleDbParameter[] parametreler = new OleDbParameter[]
		{

			new OleDbParameter("pID", ID)
			,new OleDbParameter("pAdi", Adi)
			,new OleDbParameter("pAciklama", Aciklama)
			,new OleDbParameter("pResim", Resim)
			,new OleDbParameter("pSira", Sira)
            ,new OleDbParameter("pMetaKeyword",MetaKeyword)
            ,new OleDbParameter("pMetaDescription",MetaDescription)
            ,new OleDbParameter("pMetaTitle",MetaTitle)
            ,new OleDbParameter("pSeoYazisi",SeoYazisi)
		};

        komut.Parameters.AddRange(parametreler);

        //OleDbParameter sonuc = new OleDbParameter("@pReturnValue", DbType.Int32);
        //sonuc.Direction = ParameterDirection.Output;
        //komut.Parameters.Add(sonuc);

        return ClassDAL.ExecuteWithResult(komut);
    }

    public Result<int> Delete()
    {
        OleDbCommand komut = new OleDbCommand("usp_lazerDelete");
        komut.CommandType = CommandType.StoredProcedure;

        OleDbParameter[] parametreler = new OleDbParameter[]
		{

			new OleDbParameter("@pID", this.ID)
		};

        komut.Parameters.AddRange(parametreler);

        //OleDbParameter sonuc = new OleDbParameter("@pReturnValue", DbType.Int32);
        //sonuc.Direction = ParameterDirection.Output;
        //komut.Parameters.Add(sonuc);

        return ClassDAL.ExecuteWithResult(komut);
    }

    public static lazer Select(int ID)
    {
        OleDbCommand komut = new OleDbCommand("usp_lazerSelect");
        komut.CommandType = CommandType.StoredProcedure;

        OleDbParameter[] parametreler = new OleDbParameter[]
		{

			new OleDbParameter("@pID", ID)
		};

        komut.Parameters.AddRange(parametreler);

        return ClassDAL.Selectlazer(komut);
    }

    public static List<lazer> SelectAll()
    {
        OleDbCommand komut = new OleDbCommand("usp_lazerSelectAll");
        komut.CommandType = CommandType.StoredProcedure;
        return ClassDAL.SelectAlllazer(komut);
    }


    #endregion VeriTabani İşlemleri

}
