
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Web;
using System.Linq;
public class SayacIp
{
#region Fields

private int  _IpId;
private string  _Ip;
private int  _Hit;
private DateTime  _Tarih;

#endregion Fields

#region Public Properties

public int IpId
{
get{ return _IpId; }
set{ _IpId = value; }
}
public string Ip
{
get{ return _Ip; }
set{ _Ip = value; }
}
public int Hit
{
get{ return _Hit; }
set{ _Hit = value; }
}
public DateTime Tarih
{
get{ return _Tarih; }
set{ _Tarih = value; }
}

#endregion Public Properties

#region Constructors

public SayacIp()
{}

public SayacIp(int IpId,string Ip,int Hit,DateTime Tarih)
{
this._IpId = IpId;
this._Ip = Ip;
this._Hit = Hit;
this._Tarih = Tarih;
}

public SayacIp(string Ip,DateTime Tarih)
{
this._Ip = Ip;
this._Tarih = Tarih;
}

#endregion Constructors

#region VeriTabani İşlemleri


public Result<int> Insert()
{
OleDbCommand komut = new OleDbCommand("usp_SayacIpInsert");
komut.CommandType = CommandType.StoredProcedure;

OleDbParameter[] parametreler = new OleDbParameter[]
		{

			//new OleDbParameter("pIpId", IpId)
			new OleDbParameter("pIp", Ip)
			,new OleDbParameter("pHit", Hit)
			,new OleDbParameter("pTarih", Tarih.ToString())
		};

komut.Parameters.AddRange(parametreler);

//OleDbParameter sonuc = new OleDbParameter("@pReturnValue", DbType.Int32);
//sonuc.Direction = ParameterDirection.Output;
//komut.Parameters.Add(sonuc);

OleDbCommand komutIdentity = new OleDbCommand("SELECT @@Identity FROM SayacIp");
return SistemDAL.ExecuteWithResult(komut);
}

public Result<int> Update()
{
OleDbCommand komut = new OleDbCommand("usp_SayacIpUpdate");
komut.CommandType = CommandType.StoredProcedure;

OleDbParameter[] parametreler = new OleDbParameter[]
		{

			new OleDbParameter("pIpId", IpId)
			,new OleDbParameter("pIp", Ip)
			,new OleDbParameter("pHit", Hit)
			,new OleDbParameter("pTarih", Tarih.ToString())
		};

komut.Parameters.AddRange(parametreler);

//OleDbParameter sonuc = new OleDbParameter("@pReturnValue", DbType.Int32);
//sonuc.Direction = ParameterDirection.Output;
//komut.Parameters.Add(sonuc);

return SistemDAL.ExecuteWithResult(komut);
}

public Result<int> Delete()
{
OleDbCommand komut = new OleDbCommand("usp_SayacIpDelete");
komut.CommandType = CommandType.StoredProcedure;

OleDbParameter[] parametreler = new OleDbParameter[]
		{

			new OleDbParameter("@pIpId", this.IpId)
		};

komut.Parameters.AddRange(parametreler);

//OleDbParameter sonuc = new OleDbParameter("@pReturnValue", DbType.Int32);
//sonuc.Direction = ParameterDirection.Output;
//komut.Parameters.Add(sonuc);

return SistemDAL.ExecuteWithResult(komut);
}

public static SayacIp Select( int IpId)
{
OleDbCommand komut = new OleDbCommand("usp_SayacIpSelect");
komut.CommandType = CommandType.StoredProcedure;

OleDbParameter[] parametreler = new OleDbParameter[]
		{

			new OleDbParameter("@pIpId", IpId)
		};

komut.Parameters.AddRange(parametreler);

return SistemDAL.SelectSayacIp(komut);
}

public static List<SayacIp> SelectAll()
{
OleDbCommand komut = new OleDbCommand("usp_SayacIpSelectAll");
komut.CommandType = CommandType.StoredProcedure;
return SistemDAL.SelectAllSayacIp(komut);
}


#endregion VeriTabani İşlemleri

}
