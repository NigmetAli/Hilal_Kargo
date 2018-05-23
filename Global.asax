<%@ Application Language="C#" %>

<script RunAt="server">

    void Application_Start(object sender, EventArgs e)
    {
        Application["online"] = 0;
        Application.Add("toplamziyaretci", 0);
        RegisterCustomRoutes(System.Web.Routing.RouteTable.Routes);
		// Toplam yeni = new Toplam();
       // yeni.Total = 1;
       // yeni.Insert();
    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs

    }
    void RegisterCustomRoutes(System.Web.Routing.RouteCollection routes)
    {
        routes.MapPageRoute(
            "Hizmetler",
            "{HizmetAdi}",
            "~/hizmetler.aspx",
            false
        );
        
    }
    void Session_Start(object sender, EventArgs e)
    {
         
        Session.Timeout = 20; //5 dk veriyoruz.
    }

    void Session_End(object sender, EventArgs e)
    {
        Application["online"] = (int)Application["online"] - 1;
		Session.Abandon();

    }
       
</script>
