
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Web;
using System.Linq;
public class epostaList
{
#region Fields

private int  _Id;
private string  _Eposta;
private DateTime  _Tarih;
private string  _Telefon;

#endregion Fields

#region Public Properties

public int Id
{
get{ return _Id; }
set{ _Id = value; }
}
public string Eposta
{
get{ return _Eposta; }
set{ _Eposta = value; }
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

public epostaList()
{}

public epostaList(int Id,string Eposta,DateTime Tarih,string Telefon)
{
this._Id = Id;
this._Eposta = Eposta;
this._Tarih = Tarih;
this._Telefon = Telefon;
}

public epostaList(string Eposta,DateTime Tarih,string Telefon)
{
this._Eposta = Eposta;
this._Tarih = Tarih;
this._Telefon = Telefon;
}

#endregion Constructors

#region VeriTabani İşlemleri


public Result<int> Insert()
{
OleDbCommand komut = new OleDbCommand("usp_epostaListInsert");
komut.CommandType = CommandType.StoredProcedure;

OleDbParameter[] parametreler = new OleDbParameter[]
		{

			//new OleDbParameter("pId", Id)
			new OleDbParameter("pEposta", Eposta)
			,new OleDbParameter("pTarih", Tarih.ToString())
			,new OleDbParameter("pTelefon", Telefon)
		};

komut.Parameters.AddRange(parametreler);

//OleDbParameter sonuc = new OleDbParameter("@pReturnValue", DbType.Int32);
//sonuc.Direction = ParameterDirection.Output;
//komut.Parameters.Add(sonuc);

OleDbCommand komutIdentity = new OleDbCommand("SELECT @@Identity FROM epostaList");
return ClassDAL.ExecuteReturnIdentity(komut, komutIdentity);
}

public Result<int> Update()
{
OleDbCommand komut = new OleDbCommand("usp_epostaListUpdate");
komut.CommandType = CommandType.StoredProcedure;

OleDbParameter[] parametreler = new OleDbParameter[]
		{

			new OleDbParameter("pId", Id)
			,new OleDbParameter("pEposta", Eposta)
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
OleDbCommand komut = new OleDbCommand("usp_epostaListDelete");
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

public static epostaList Select( int Id)
{
OleDbCommand komut = new OleDbCommand("usp_epostaListSelect");
komut.CommandType = CommandType.StoredProcedure;

OleDbParameter[] parametreler = new OleDbParameter[]
		{

			new OleDbParameter("@pId", Id)
		};

komut.Parameters.AddRange(parametreler);

return ClassDAL.SelectepostaList(komut);
}

public static List<epostaList> SelectAll()
{
OleDbCommand komut = new OleDbCommand("usp_epostaListSelectAll");
komut.CommandType = CommandType.StoredProcedure;
return ClassDAL.SelectAllepostaList(komut);
}


#endregion VeriTabani İşlemleri

}
