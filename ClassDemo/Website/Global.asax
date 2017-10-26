<%@ Application Language="C#" %>
<%@ Import Namespace="Website" %>
<%@ Import Namespace="System.Web.Optimization" %>
<%@ Import Namespace="System.Web.Routing" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        RouteConfig.RegisterRoutes(RouteTable.Routes);
        BundleConfig.RegisterBundles(BundleTable.Bundles);

        var RoleManager = new RoleManager();
        RoleManager.AddDefaultRoles();

        var UserManager = new UserManager();
        UserManager.AddWebMaster();
        UserManager.AddEmployees();
    }

</script>
