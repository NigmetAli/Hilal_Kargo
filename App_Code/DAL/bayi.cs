
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Web;
using System.Linq;
public class bayi
{
#region Fields

private int  _Id;
private string  _Bayi_adi;
private string  _Bayi_aciklama;
private string  _Resim;

#endregion Fields

#region Public Properties

public int Id
{
get{ return _Id; }
set{ _Id = value; }
}
public string Bayi_adi
{
get{ return _Bayi_adi; }
set{ _Bayi_adi = value; }
}
public string Bayi_aciklama
{
get{ return _Bayi_aciklama; }
set{ _Bayi_aciklama = value; }
}
public string Resim
{
get{ return _Resim; }
set{ _Resim = value; }
}

#endregion Public Properties

#region Constructors

public bayi()
{}

public bayi(int Id,string Bayi_adi,string Bayi_aciklama,string Resim)
{
this._Id = Id;
this._Bayi_adi = Bayi_adi;
this._Bayi_aciklama = Bayi_aciklama;
this._Resim = Resim;
}

public bayi(string Bayi_adi,string Bayi_aciklama,string Resim)
{
this._Bayi_adi = Bayi_adi;
this._Bayi_aciklama = Bayi_aciklama;
this._Resim = Resim;
}

#endregion Constructors

#region VeriTabani İşlemleri


public Result<int> Insert()
{
OleDbCommand komut = new OleDbCommand("usp_bayiInsert");
komut.CommandType = CommandType.StoredProcedure;

OleDbParameter[] parametreler = new OleDbParameter[]
		{

			//new OleDbParameter("pId", Id)
			new OleDbParameter("pBayi_adi", Bayi_adi)
			,new OleDbParameter("pBayi_aciklama", Bayi_aciklama)
			,new OleDbParameter("pResim", Resim)
		};

komut.Parameters.AddRange(parametreler);

//OleDbParameter sonuc = new OleDbParameter("@pReturnValue", DbType.Int32);
//sonuc.Direction = ParameterDirection.Output;
//komut.Parameters.Add(sonuc);

OleDbCommand komutIdentity = new OleDbCommand("SELECT @@Identity FROM bayi");
return ClassDAL.ExecuteReturnIdentity(komut, komutIdentity);
}

public Result<int> Update()
{
OleDbCommand komut = new OleDbCommand("usp_bayiUpdate");
komut.CommandType = CommandType.StoredProcedure;

OleDbParameter[] parametreler = new OleDbParameter[]
		{

			new OleDbParameter("pId", Id)
			,new OleDbParameter("pBayi_adi", Bayi_adi)
			,new OleDbParameter("pBayi_aciklama", Bayi_aciklama)
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
OleDbCommand komut = new OleDbCommand("usp_bayiDelete");
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

public static bayi Select( int Id)
{
OleDbCommand komut = new OleDbCommand("select * from bayi where Id="+ Id +"");
komut.CommandType = CommandType.Text;
return ClassDAL.Selectbayi(komut);
}

public static List<bayi> SelectAll()
{
OleDbCommand komut = new OleDbCommand("select * from bayi");
komut.CommandType = CommandType.Text;
return ClassDAL.SelectAllbayi(komut);
}


#endregion VeriTabani İşlemleri

}
