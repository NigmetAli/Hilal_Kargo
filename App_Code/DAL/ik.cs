
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Web;
using System.Linq;
public class ik
{
#region Fields

private int  _ID;
private string  _Adi;
private string  _Pozisyon;
private string  _Telefon;
private string  _Eposta;
private string  _Ek;
private string  _Tarih;

#endregion Fields

#region Public Properties

public int ID
{
get{ return _ID; }
set{ _ID = value; }
}
public string Adi
{
get{ return _Adi; }
set{ _Adi = value; }
}
public string Pozisyon
{
get{ return _Pozisyon; }
set{ _Pozisyon = value; }
}
public string Telefon
{
get{ return _Telefon; }
set{ _Telefon = value; }
}
public string Eposta
{
get{ return _Eposta; }
set{ _Eposta = value; }
}
public string Ek
{
get{ return _Ek; }
set{ _Ek = value; }
}
public string Tarih
{
get{ return _Tarih; }
set{ _Tarih = value; }
}

#endregion Public Properties

#region Constructors

public ik()
{}

public ik(int ID,string Adi,string Pozisyon,string Telefon,string Eposta,string Ek,string Tarih)
{
this._ID = ID;
this._Adi = Adi;
this._Pozisyon = Pozisyon;
this._Telefon = Telefon;
this._Eposta = Eposta;
this._Ek = Ek;
this._Tarih = Tarih;
}

public ik(string Adi,string Pozisyon,string Telefon,string Eposta,string Ek,string Tarih)
{
this._Adi = Adi;
this._Pozisyon = Pozisyon;
this._Telefon = Telefon;
this._Eposta = Eposta;
this._Ek = Ek;
this._Tarih = Tarih;
}

#endregion Constructors

#region VeriTabani İşlemleri


public Result<int> Insert()
{
OleDbCommand komut = new OleDbCommand("usp_ikInsert");
komut.CommandType = CommandType.StoredProcedure;

OleDbParameter[] parametreler = new OleDbParameter[]
		{

			//new OleDbParameter("pID", ID)
			new OleDbParameter("pAdi", Adi)
			,new OleDbParameter("pPozisyon", Pozisyon)
			,new OleDbParameter("pTelefon", Telefon)
			,new OleDbParameter("pEposta", Eposta)
			,new OleDbParameter("pEk", Ek)
			,new OleDbParameter("pTarih", Tarih)
		};

komut.Parameters.AddRange(parametreler);

//OleDbParameter sonuc = new OleDbParameter("@pReturnValue", DbType.Int32);
//sonuc.Direction = ParameterDirection.Output;
//komut.Parameters.Add(sonuc);

OleDbCommand komutIdentity = new OleDbCommand("SELECT @@Identity FROM ik");
return ClassDAL.ExecuteReturnIdentity(komut, komutIdentity);
}

public Result<int> Update()
{
OleDbCommand komut = new OleDbCommand("usp_ikUpdate");
komut.CommandType = CommandType.StoredProcedure;

OleDbParameter[] parametreler = new OleDbParameter[]
		{

			new OleDbParameter("pID", ID)
			,new OleDbParameter("pAdi", Adi)
			,new OleDbParameter("pPozisyon", Pozisyon)
			,new OleDbParameter("pTelefon", Telefon)
			,new OleDbParameter("pEposta", Eposta)
			,new OleDbParameter("pEk", Ek)
			,new OleDbParameter("pTarih", Tarih)
		};

komut.Parameters.AddRange(parametreler);

//OleDbParameter sonuc = new OleDbParameter("@pReturnValue", DbType.Int32);
//sonuc.Direction = ParameterDirection.Output;
//komut.Parameters.Add(sonuc);

return ClassDAL.ExecuteWithResult(komut);
}

public Result<int> Delete()
{
OleDbCommand komut = new OleDbCommand("usp_ikDelete");
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

public static ik Select( int ID)
{
OleDbCommand komut = new OleDbCommand("usp_ikSelect");
komut.CommandType = CommandType.StoredProcedure;

OleDbParameter[] parametreler = new OleDbParameter[]
		{

			new OleDbParameter("@pID", ID)
		};

komut.Parameters.AddRange(parametreler);

return ClassDAL.Selectik(komut);
}

public static List<ik> SelectAll()
{
OleDbCommand komut = new OleDbCommand("usp_ikSelectAll");
komut.CommandType = CommandType.StoredProcedure;
return ClassDAL.SelectAllik(komut);
}


#endregion VeriTabani İşlemleri

}
