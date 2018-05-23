
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Web;
using System.Linq;
public class iletisimmesaj
{
#region Fields

private int  _Id;
private string  _Isim;
private string  _Email;
private string  _Konu;
private string  _Mesaj;
private bool  _Durum;
private DateTime  _Tarih;
private string  _Telefon;

#endregion Fields

#region Public Properties

public int Id
{
get{ return _Id; }
set{ _Id = value; }
}
public string Isim
{
get{ return _Isim; }
set{ _Isim = value; }
}
public string Email
{
get{ return _Email; }
set{ _Email = value; }
}
public string Konu
{
get{ return _Konu; }
set{ _Konu = value; }
}
public string Mesaj
{
get{ return _Mesaj; }
set{ _Mesaj = value; }
}
public bool Durum
{
get{ return _Durum; }
set{ _Durum = value; }
}
public DateTime Tarih
{
get{ return _Tarih; }
set{ _Tarih = value; }
}
public string Telefon
{
get{ return _Telefon; }
set{ _Telefon = value; }
}

#endregion Public Properties

#region Constructors

public iletisimmesaj()
{}

public iletisimmesaj(int Id,string Isim,string Email,string Konu,string Mesaj,bool Durum,DateTime Tarih,string Telefon)
{
this._Id = Id;
this._Isim = Isim;
this._Email = Email;
this._Konu = Konu;
this._Mesaj = Mesaj;
this._Durum = Durum;
this._Tarih = Tarih;
this._Telefon = Telefon;
}

public iletisimmesaj(string Isim,string Email,string Konu,string Mesaj,bool Durum,DateTime Tarih,string Telefon)
{
this._Isim = Isim;
this._Email = Email;
this._Konu = Konu;
this._Mesaj = Mesaj;
this._Durum = Durum;
this._Tarih = Tarih;
this._Telefon = Telefon;
}

#endregion Constructors

#region VeriTabani İşlemleri


public Result<int> Insert()
{
OleDbCommand komut = new OleDbCommand("usp_iletisimmesajInsert");
komut.CommandType = CommandType.StoredProcedure;

OleDbParameter[] parametreler = new OleDbParameter[]
		{

			//new OleDbParameter("pId", Id)
			new OleDbParameter("pIsim", Isim)
			,new OleDbParameter("pEmail", Email)
			,new OleDbParameter("pKonu", Konu)
			,new OleDbParameter("pMesaj", Mesaj)
			,new OleDbParameter("pDurum", Durum)
			,new OleDbParameter("pTarih", Tarih.ToString())
			,new OleDbParameter("pTelefon", Telefon)
		};

komut.Parameters.AddRange(parametreler);

//OleDbParameter sonuc = new OleDbParameter("@pReturnValue", DbType.Int32);
//sonuc.Direction = ParameterDirection.Output;
//komut.Parameters.Add(sonuc);

OleDbCommand komutIdentity = new OleDbCommand("SELECT @@Identity FROM iletisimmesaj");
return ClassDAL.ExecuteReturnIdentity(komut, komutIdentity);
}

public Result<int> Update()
{
OleDbCommand komut = new OleDbCommand("usp_iletisimmesajUpdate");
komut.CommandType = CommandType.StoredProcedure;

OleDbParameter[] parametreler = new OleDbParameter[]
		{

			new OleDbParameter("pId", Id)
			,new OleDbParameter("pIsim", Isim)
			,new OleDbParameter("pEmail", Email)
			,new OleDbParameter("pKonu", Konu)
			,new OleDbParameter("pMesaj", Mesaj)
			,new OleDbParameter("pDurum", Durum)
			,new OleDbParameter("pTarih", Tarih.ToString())
			,new OleDbParameter("pTelefon", Telefon)
		};

komut.Parameters.AddRange(parametreler);

//OleDbParameter sonuc = new OleDbParameter("@pReturnValue", DbType.Int32);
//sonuc.Direction = ParameterDirection.Output;
//komut.Parameters.Add(sonuc);

return ClassDAL.ExecuteWithResult(komut);
}

public Result<int> Delete()
{
OleDbCommand komut = new OleDbCommand("usp_iletisimmesajDelete");
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

public static iletisimmesaj Select( int Id)
{
OleDbCommand komut = new OleDbCommand("usp_iletisimmesajSelect");
komut.CommandType = CommandType.StoredProcedure;

OleDbParameter[] parametreler = new OleDbParameter[]
		{

			new OleDbParameter("@pId", Id)
		};

komut.Parameters.AddRange(parametreler);

return ClassDAL.Selectiletisimmesaj(komut);
}

public static List<iletisimmesaj> SelectAll()
{
OleDbCommand komut = new OleDbCommand("usp_iletisimmesajSelectAll");
komut.CommandType = CommandType.StoredProcedure;
return ClassDAL.SelectAlliletisimmesaj(komut);
}


#endregion VeriTabani İşlemleri

}
