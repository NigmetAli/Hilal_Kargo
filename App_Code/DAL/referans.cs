
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Web;
using System.Linq;
public class referans
{
#region Fields

private int  _Id;
private string  _Adi;
private string  _Aciklama;
private string  _Resim;

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
public string Aciklama
{
get{ return _Aciklama; }
set{ _Aciklama = value; }
}
public string Resim
{
get{ return _Resim; }
set{ _Resim = value; }
}

#endregion Public Properties

#region Constructors

public referans()
{}

public referans(int Id,string Adi,string Aciklama,string Resim)
{
this._Id = Id;
this._Adi = Adi;
this._Aciklama = Aciklama;
this._Resim = Resim;
}

public referans(string Adi,string Aciklama,string Resim)
{
this._Adi = Adi;
this._Aciklama = Aciklama;
this._Resim = Resim;
}

#endregion Constructors

#region VeriTabani İşlemleri


public Result<int> Insert()
{
OleDbCommand komut = new OleDbCommand("usp_referansInsert");
komut.CommandType = CommandType.StoredProcedure;

OleDbParameter[] parametreler = new OleDbParameter[]
		{

			//new OleDbParameter("pId", Id)
			new OleDbParameter("pAdi", Adi)
			,new OleDbParameter("pAciklama", Aciklama)
			,new OleDbParameter("pResim", Resim)
		};

komut.Parameters.AddRange(parametreler);

//OleDbParameter sonuc = new OleDbParameter("@pReturnValue", DbType.Int32);
//sonuc.Direction = ParameterDirection.Output;
//komut.Parameters.Add(sonuc);

OleDbCommand komutIdentity = new OleDbCommand("SELECT @@Identity FROM referans");
return ClassDAL.ExecuteReturnIdentity(komut, komutIdentity);
}

public Result<int> Update()
{
OleDbCommand komut = new OleDbCommand("usp_referansUpdate");
komut.CommandType = CommandType.StoredProcedure;

OleDbParameter[] parametreler = new OleDbParameter[]
		{

			new OleDbParameter("pId", Id)
			,new OleDbParameter("pAdi", Adi)
			,new OleDbParameter("pAciklama", Aciklama)
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
OleDbCommand komut = new OleDbCommand("usp_referansDelete");
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

public static referans Select( int Id)
{
OleDbCommand komut = new OleDbCommand("select * from referans where Id="+ Id +"");
komut.CommandType = CommandType.Text;
return ClassDAL.Selectreferans(komut);
}

public static List<referans> SelectAll()
{
OleDbCommand komut = new OleDbCommand("select * from referans");
komut.CommandType = CommandType.Text;
return ClassDAL.SelectAllreferans(komut);
}


#endregion VeriTabani İşlemleri

}
