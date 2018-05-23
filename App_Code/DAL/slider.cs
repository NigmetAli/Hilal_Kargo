
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Web;
using System.Linq;
public class slider
{
#region Fields

private int  _Id;
private string  _Yazi;
private string  _Resim;

#endregion Fields

#region Public Properties

public int Id
{
get{ return _Id; }
set{ _Id = value; }
}
public string Yazi
{
get{ return _Yazi; }
set{ _Yazi = value; }
}
public string Resim
{
get{ return _Resim; }
set{ _Resim = value; }
}

#endregion Public Properties

#region Constructors

public slider()
{}

public slider(int Id,string Yazi,string Resim)
{
this._Id = Id;
this._Yazi = Yazi;
this._Resim = Resim;
}

public slider(string Yazi,string Resim)
{
this._Yazi = Yazi;
this._Resim = Resim;
}

#endregion Constructors

#region VeriTabani İşlemleri


public Result<int> Insert()
{
OleDbCommand komut = new OleDbCommand("usp_sliderInsert");
komut.CommandType = CommandType.StoredProcedure;

OleDbParameter[] parametreler = new OleDbParameter[]
		{

			//new OleDbParameter("pId", Id)
			new OleDbParameter("pYazi", Yazi)
			,new OleDbParameter("pResim", Resim)
		};

komut.Parameters.AddRange(parametreler);

//OleDbParameter sonuc = new OleDbParameter("@pReturnValue", DbType.Int32);
//sonuc.Direction = ParameterDirection.Output;
//komut.Parameters.Add(sonuc);

OleDbCommand komutIdentity = new OleDbCommand("SELECT @@Identity FROM slider");
return ClassDAL.ExecuteReturnIdentity(komut, komutIdentity);
}

public Result<int> Update()
{
OleDbCommand komut = new OleDbCommand("usp_sliderUpdate");
komut.CommandType = CommandType.StoredProcedure;

OleDbParameter[] parametreler = new OleDbParameter[]
		{

			new OleDbParameter("pId", Id)
			,new OleDbParameter("pYazi", Yazi)
			,new OleDbParameter("pResim", Resim)
		};

komut.Parameters.AddRange(parametreler);

//OleDbParameter sonuc = new OleDbParameter("@pReturnValue", DbType.Int32);
//sonuc.Direction = ParameterDirection.Output;
//komut.Parameters.Add(sonuc);

return ClassDAL.ExecuteWithResult(komut);
}

public Result<int> Delete()
{
OleDbCommand komut = new OleDbCommand("usp_sliderDelete");
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

public static slider Select( int Id)
{
OleDbCommand komut = new OleDbCommand("select * from slider where Id="+ Id +"");
komut.CommandType = CommandType.Text;
return ClassDAL.Selectslider(komut);
}

public static List<slider> SelectAll()
{
OleDbCommand komut = new OleDbCommand("select * from slider");
komut.CommandType = CommandType.Text;
return ClassDAL.SelectAllslider(komut);
}


#endregion VeriTabani İşlemleri

}
