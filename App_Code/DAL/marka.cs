
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Web;
using System.Linq;
public class marka
{
#region Fields

private int  _Id;
private string  _Resim;
private string  _Adi;

#endregion Fields

#region Public Properties

public int Id
{
get{ return _Id; }
set{ _Id = value; }
}
public string Resim
{
get{ return _Resim; }
set{ _Resim = value; }
}
public string Adi
{
get{ return _Adi; }
set{ _Adi = value; }
}

#endregion Public Properties

#region Constructors

public marka()
{}

public marka(int Id,string Resim,string Adi)
{
this._Id = Id;
this._Resim = Resim;
this._Adi = Adi;
}

public marka(string Resim,string Adi)
{
this._Resim = Resim;
this._Adi = Adi;
}

#endregion Constructors

#region VeriTabani İşlemleri


public Result<int> Insert()
{
OleDbCommand komut = new OleDbCommand("usp_markaInsert");
komut.CommandType = CommandType.StoredProcedure;

OleDbParameter[] parametreler = new OleDbParameter[]
		{

			//new OleDbParameter("pId", Id)
			new OleDbParameter("pResim", Resim)
			,new OleDbParameter("pAdi", Adi)
		};

komut.Parameters.AddRange(parametreler);

//OleDbParameter sonuc = new OleDbParameter("@pReturnValue", DbType.Int32);
//sonuc.Direction = ParameterDirection.Output;
//komut.Parameters.Add(sonuc);

OleDbCommand komutIdentity = new OleDbCommand("SELECT @@Identity FROM marka");
return ClassDAL.ExecuteReturnIdentity(komut, komutIdentity);
}

public Result<int> Update()
{
OleDbCommand komut = new OleDbCommand("usp_markaUpdate");
komut.CommandType = CommandType.StoredProcedure;

OleDbParameter[] parametreler = new OleDbParameter[]
		{

			new OleDbParameter("pId", Id)
			,new OleDbParameter("pResim", Resim)
			,new OleDbParameter("pAdi", Adi)
		};

komut.Parameters.AddRange(parametreler);

//OleDbParameter sonuc = new OleDbParameter("@pReturnValue", DbType.Int32);
//sonuc.Direction = ParameterDirection.Output;
//komut.Parameters.Add(sonuc);

return ClassDAL.ExecuteWithResult(komut);
}

public Result<int> Delete()
{
OleDbCommand komut = new OleDbCommand("usp_markaDelete");
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

public static marka Select( int Id)
{
OleDbCommand komut = new OleDbCommand("select * from marka where Id="+ Id +"");
komut.CommandType = CommandType.Text;
return ClassDAL.Selectmarka(komut);
}

public static List<marka> SelectAll()
{
OleDbCommand komut = new OleDbCommand("select * from marka");
komut.CommandType = CommandType.Text;
return ClassDAL.SelectAllmarka(komut);
}


#endregion VeriTabani İşlemleri

}
