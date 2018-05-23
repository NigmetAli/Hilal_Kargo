
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Web;
using System.Linq;
public class ktlg
{
#region Fields

private int  _Id;
private string  _Adi;
private string  _Link;

#endregion Fields

#region Public Properties

public int Id
{
get{ return _Id; }
set{ _Id = value; }
}
public string Adi
{
get{ return _Adi; }
set{ _Adi = value; }
}
public string Link
{
get{ return _Link; }
set{ _Link = value; }
}

#endregion Public Properties

#region Constructors

public ktlg()
{}

public ktlg(int Id,string Adi,string Link)
{
this._Id = Id;
this._Adi = Adi;
this._Link = Link;
}

public ktlg(string Adi,string Link)
{
this._Adi = Adi;
this._Link = Link;
}

#endregion Constructors

#region VeriTabani İşlemleri


public Result<int> Insert()
{
OleDbCommand komut = new OleDbCommand("usp_ktlgInsert");
komut.CommandType = CommandType.StoredProcedure;

OleDbParameter[] parametreler = new OleDbParameter[]
		{

			//new OleDbParameter("pId", Id)
			new OleDbParameter("pAdi", Adi)
			,new OleDbParameter("pLink", Link)
		};

komut.Parameters.AddRange(parametreler);

//OleDbParameter sonuc = new OleDbParameter("@pReturnValue", DbType.Int32);
//sonuc.Direction = ParameterDirection.Output;
//komut.Parameters.Add(sonuc);

OleDbCommand komutIdentity = new OleDbCommand("SELECT @@Identity FROM ktlg");
return ClassDAL.ExecuteReturnIdentity(komut, komutIdentity);
}

public Result<int> Update()
{
OleDbCommand komut = new OleDbCommand("usp_ktlgUpdate");
komut.CommandType = CommandType.StoredProcedure;

OleDbParameter[] parametreler = new OleDbParameter[]
		{

			new OleDbParameter("pId", Id)
			,new OleDbParameter("pAdi", Adi)
			,new OleDbParameter("pLink", Link)
		};

komut.Parameters.AddRange(parametreler);

//OleDbParameter sonuc = new OleDbParameter("@pReturnValue", DbType.Int32);
//sonuc.Direction = ParameterDirection.Output;
//komut.Parameters.Add(sonuc);

return ClassDAL.ExecuteWithResult(komut);
}

public Result<int> Delete()
{
OleDbCommand komut = new OleDbCommand("usp_ktlgDelete");
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

public static ktlg Select( int Id)
{
OleDbCommand komut = new OleDbCommand("select * from ktlg where Id="+ Id +"");
komut.CommandType = CommandType.Text;
return ClassDAL.Selectktlg(komut);
}

public static List<ktlg> SelectAll()
{
OleDbCommand komut = new OleDbCommand("select * from ktlg");
komut.CommandType = CommandType.Text;
return ClassDAL.SelectAllktlg(komut);
}


#endregion VeriTabani İşlemleri

}
