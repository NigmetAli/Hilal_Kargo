
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Web;
using System.Linq;
public class hizmet
{
    #region Fields

    private int _Id;
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

    public hizmet()
    { }

    public hizmet(int Id, string Adi, string Aciklama, string Resim, int Sira, string MetaKeyword, string MetaDescription, string MetaTitle, string SeoYazisi)
    {
        this._Id = Id;
        this._Adi = Adi;
        this._Aciklama = Aciklama;
        this._Resim = Resim;
        this._Sira = Sira;
        this._MetaKeyword = MetaKeyword;
        this._MetaDescription = MetaDescription;
        this._MetaTitle = MetaTitle;
        this._MetaTitle = MetaTitle;
        this._SeoYazisi = SeoYazisi;
    }

    public hizmet(string Adi, string Aciklama, string Resim, int Sira, string MetaKeyword, string MetaDescription, string MetaTitle, string SeoYazisi)
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
        OleDbCommand komut = new OleDbCommand("usp_hizmetInsert");
        komut.CommandType = CommandType.StoredProcedure;

        OleDbParameter[] parametreler = new OleDbParameter[]
		{

			//new OleDbParameter("pId", Id)
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

        OleDbCommand komutIdentity = new OleDbCommand("SELECT @@Identity FROM hizmet");
        return ClassDAL.ExecuteReturnIdentity(komut, komutIdentity);
    }

    public Result<int> Update()
{
OleDbCommand komut = new OleDbCommand("usp_hizmetUpdate");
komut.CommandType = CommandType.StoredProcedure;

OleDbParameter[] parametreler = new OleDbParameter[]
		{

			new OleDbParameter("pId", Id)
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
        OleDbCommand komut = new OleDbCommand("usp_hizmetDelete");
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

    public static hizmet Select(int Id)
    {
        OleDbCommand komut = new OleDbCommand("usp_hizmetSelect");
        komut.CommandType = CommandType.StoredProcedure;

        OleDbParameter[] parametreler = new OleDbParameter[]
		{

			new OleDbParameter("@pId", Id)
		};

        komut.Parameters.AddRange(parametreler);

        return ClassDAL.Selecthizmet(komut);
    }

    public static List<hizmet> SelectAll()
    {
        OleDbCommand komut = new OleDbCommand("usp_hizmetSelectAll");
        komut.CommandType = CommandType.StoredProcedure;
        return ClassDAL.SelectAllhizmet(komut);
    }


    #endregion VeriTabani İşlemleri

}
