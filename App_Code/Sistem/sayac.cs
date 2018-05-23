
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Web;
using System.Linq;
public class sayac
{
#region Fields

private string  _Tarih;
private int  _Gunluk;
private int  _Aylik;
private int  _Yillik;
private int  _Toplam;

#endregion Fields

#region Public Properties

public string Tarih
{
get{ return _Tarih; }
set{ _Tarih = value; }
}
public int Gunluk
{
get{ return _Gunluk; }
set{ _Gunluk = value; }
}
public int Aylik
{
get{ return _Aylik; }
set{ _Aylik = value; }
}
public int Yillik
{
get{ return _Yillik; }
set{ _Yillik = value; }
}
public int Toplam
{
get{ return _Toplam; }
set{ _Toplam = value; }
}

#endregion Public Properties

#region Constructors

public sayac()
{}

public sayac(string Tarih,int Gunluk,int Aylik,int Yillik,int Toplam)
{
this._Tarih = Tarih;
this._Gunluk = Gunluk;
this._Aylik = Aylik;
this._Yillik = Yillik;
this._Toplam = Toplam;
}

public sayac(string Tarih,int Yillik,int Toplam)
{
this._Tarih = Tarih;
this._Yillik = Yillik;
this._Toplam = Toplam;
}

#endregion Constructors

#region VeriTabani İşlemleri


public Result<int> Insert()
{
OleDbCommand komut = new OleDbCommand("usp_sayacInsert");
komut.CommandType = CommandType.StoredProcedure;

OleDbParameter[] parametreler = new OleDbParameter[]
		{

			new OleDbParameter("pTarih", Tarih)
			//,new OleDbParameter("pGunluk", Gunluk)
			//,new OleDbParameter("pAylik", Aylik)
			,new OleDbParameter("pYillik", Yillik)
			,new OleDbParameter("pToplam", Toplam)
		};

komut.Parameters.AddRange(parametreler);

//OleDbParameter sonuc = new OleDbParameter("@pReturnValue", DbType.Int32);
//sonuc.Direction = ParameterDirection.Output;
//komut.Parameters.Add(sonuc);

return ClassDAL.ExecuteWithResult(komut);
}

public Result<int> Update()
{
OleDbCommand komut = new OleDbCommand("usp_sayacUpdate");
komut.CommandType = CommandType.StoredProcedure;

OleDbParameter[] parametreler = new OleDbParameter[]
		{

			new OleDbParameter("pTarih", Tarih)
			//,new OleDbParameter("pGunluk", Gunluk)
			//,new OleDbParameter("pAylik", Aylik)
			,new OleDbParameter("pYillik", Yillik)
			,new OleDbParameter("pToplam", Toplam)
		};

komut.Parameters.AddRange(parametreler);

//OleDbParameter sonuc = new OleDbParameter("@pReturnValue", DbType.Int32);
//sonuc.Direction = ParameterDirection.Output;
//komut.Parameters.Add(sonuc);

return ClassDAL.ExecuteWithResult(komut);
}

public Result<int> Delete()
{
OleDbCommand komut = new OleDbCommand("usp_sayacDelete");
komut.CommandType = CommandType.StoredProcedure;

OleDbParameter[] parametreler = new OleDbParameter[]
		{

			new OleDbParameter("@pTarih", this.Tarih)
			,new OleDbParameter("@pGunluk", this.Gunluk)
			,new OleDbParameter("@pAylik", this.Aylik)
			,new OleDbParameter("@pYillik", this.Yillik)
			,new OleDbParameter("@pToplam", this.Toplam)
		};

komut.Parameters.AddRange(parametreler);

//OleDbParameter sonuc = new OleDbParameter("@pReturnValue", DbType.Int32);
//sonuc.Direction = ParameterDirection.Output;
//komut.Parameters.Add(sonuc);

return ClassDAL.ExecuteWithResult(komut);
}

public static sayac Select(string Tarih,int Gunluk,int Aylik,int Yillik,int Toplam)
{
OleDbCommand komut = new OleDbCommand("usp_sayacSelect");
komut.CommandType = CommandType.StoredProcedure;

OleDbParameter[] parametreler = new OleDbParameter[]
		{

			new OleDbParameter("@pTarih", Tarih)
			,new OleDbParameter("@pGunluk", Gunluk)
			,new OleDbParameter("@pAylik", Aylik)
			,new OleDbParameter("@pYillik", Yillik)
			,new OleDbParameter("@pToplam", Toplam)
		};

komut.Parameters.AddRange(parametreler);

return SistemDAL.Selectsayac(komut);
}

public static List<sayac> SelectAll()
{
OleDbCommand komut = new OleDbCommand("usp_sayacSelectAll");
komut.CommandType = CommandType.StoredProcedure;
return SistemDAL.SelectAllsayac(komut);
}


#endregion VeriTabani İşlemleri

}
