
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Web;
using System.Linq;
public class Toplam
{
#region Fields

private int  _Id;
private int  _Total;

#endregion Fields

#region Public Properties

public int Id
{
get{ return _Id; }
set{ _Id = value; }
}
public int Total
{
get{ return _Total; }
set{ _Total = value; }
}

#endregion Public Properties

#region Constructors

public Toplam()
{}

public Toplam(int Id,int Total)
{
this._Id = Id;
this._Total = Total;
}

public Toplam(int Total)
{
this._Total = Total;
}

#endregion Constructors

#region VeriTabani İşlemleri


public Result<int> Insert()
{
OleDbCommand komut = new OleDbCommand("usp_ToplamInsert");
komut.CommandType = CommandType.StoredProcedure;

OleDbParameter[] parametreler = new OleDbParameter[]
		{

			//new OleDbParameter("pId", Id)
			new OleDbParameter("pTotal", Total)
		};

komut.Parameters.AddRange(parametreler);

//OleDbParameter sonuc = new OleDbParameter("@pReturnValue", DbType.Int32);
//sonuc.Direction = ParameterDirection.Output;
//komut.Parameters.Add(sonuc);

OleDbCommand komutIdentity = new OleDbCommand("SELECT @@Identity FROM Toplam");
return SistemDAL.ExecuteReturnIdentity(komut, komutIdentity);
}

public Result<int> Update()
{
OleDbCommand komut = new OleDbCommand("usp_ToplamUpdate");
komut.CommandType = CommandType.StoredProcedure;

OleDbParameter[] parametreler = new OleDbParameter[]
		{

			new OleDbParameter("pId", Id)
			,new OleDbParameter("pTotal", Total)
		};

komut.Parameters.AddRange(parametreler);

//OleDbParameter sonuc = new OleDbParameter("@pReturnValue", DbType.Int32);
//sonuc.Direction = ParameterDirection.Output;
//komut.Parameters.Add(sonuc);

return SistemDAL.ExecuteWithResult(komut);
}

public Result<int> Delete()
{
OleDbCommand komut = new OleDbCommand("usp_ToplamDelete");
komut.CommandType = CommandType.StoredProcedure;

OleDbParameter[] parametreler = new OleDbParameter[]
		{

			new OleDbParameter("@pId", this.Id)
		};

komut.Parameters.AddRange(parametreler);

//OleDbParameter sonuc = new OleDbParameter("@pReturnValue", DbType.Int32);
//sonuc.Direction = ParameterDirection.Output;
//komut.Parameters.Add(sonuc);

return SistemDAL.ExecuteWithResult(komut);
}

public static Toplam Select( int Id)
{
OleDbCommand komut = new OleDbCommand("usp_ToplamSelect");
komut.CommandType = CommandType.StoredProcedure;

OleDbParameter[] parametreler = new OleDbParameter[]
		{

			new OleDbParameter("@pId", Id)
		};

komut.Parameters.AddRange(parametreler);

return SistemDAL.SelectToplam(komut);
}

public static List<Toplam> SelectAll()
{
OleDbCommand komut = new OleDbCommand("usp_ToplamSelectAll");
komut.CommandType = CommandType.StoredProcedure;
return SistemDAL.SelectAllToplam(komut);
}


#endregion VeriTabani İşlemleri

}
