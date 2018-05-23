
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Web;
using System.Linq;
public class urunkat
{
#region Fields

private int  _Id;
private int  _FkUstKategori;
private string  _Adi;
private string  _Resim;
private bool  _Aktif;

#endregion Fields

#region Public Properties

public int Id
{
get{ return _Id; }
set{ _Id = value; }
}
public int FkUstKategori
{
get{ return _FkUstKategori; }
set{ _FkUstKategori = value; }
}
public string Adi
{
get{ return _Adi; }
set{ _Adi = value; }
}
public string Resim
{
get{ return _Resim; }
set{ _Resim = value; }
}
public bool Aktif
{
get{ return _Aktif; }
set{ _Aktif = value; }
}

#endregion Public Properties

#region Constructors

public urunkat()
{}

public urunkat(int Id,int FkUstKategori,string Adi,string Resim,bool Aktif)
{
this._Id = Id;
this._FkUstKategori = FkUstKategori;
this._Adi = Adi;
this._Resim = Resim;
this._Aktif = Aktif;
}

public urunkat(int FkUstKategori,string Adi,string Resim,bool Aktif)
{
this._FkUstKategori = FkUstKategori;
this._Adi = Adi;
this._Resim = Resim;
this._Aktif = Aktif;
}

#endregion Constructors

#region VeriTabani İşlemleri


public Result<int> Insert()
{
OleDbCommand komut = new OleDbCommand("usp_urunkatInsert");
komut.CommandType = CommandType.StoredProcedure;

OleDbParameter[] parametreler = new OleDbParameter[]
		{

			//new OleDbParameter("pId", Id)
			new OleDbParameter("pFkUstKategori", FkUstKategori)
			,new OleDbParameter("pAdi", Adi)
			,new OleDbParameter("pResim", Resim)
			,new OleDbParameter("pAktif", Aktif)
		};

komut.Parameters.AddRange(parametreler);

//OleDbParameter sonuc = new OleDbParameter("@pReturnValue", DbType.Int32);
//sonuc.Direction = ParameterDirection.Output;
//komut.Parameters.Add(sonuc);

OleDbCommand komutIdentity = new OleDbCommand("SELECT @@Identity FROM urunkat");
return ClassDAL.ExecuteReturnIdentity(komut, komutIdentity);
}

public Result<int> Update()
{
OleDbCommand komut = new OleDbCommand("usp_urunkatUpdate");
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
OleDbCommand komut = new OleDbCommand("usp_urunkatDelete");
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

public static urunkat Select( int Id)
{
OleDbCommand komut = new OleDbCommand("select * from urunkat where Id="+ Id +"");
komut.CommandType = CommandType.Text;
return ClassDAL.Selecturunkat(komut);
}

public static List<urunkat> SelectAll()
{
OleDbCommand komut = new OleDbCommand("select * from urunkat");
komut.CommandType = CommandType.Text;
return ClassDAL.SelectAllurunkat(komut);
}


#endregion VeriTabani İşlemleri

}
