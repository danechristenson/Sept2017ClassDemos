using Microsoft.AspNet.Identity.EntityFramework;

#region Additional Namespaces
#endregion
namespace Chinook.Data.Entities.Security
{
    // You can add User data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        //we can add addition attributes that will be physically
        //include into the AspNetUsers security
        public int? EmployeeID { get; set; }
        public int? CustomerID { get; set; }
    }
}
