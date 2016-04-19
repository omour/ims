using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ImsForPresentation.Models
{
    public class AcceptedRouteForRole : IdentityUsed
    {
        public int Id { get; set; }
        public string RoleId { get; set; }
        public int RoutePrivilegeId { get; set; }

        [ForeignKey("RoleId")]
        public IdentityRole IdentityRole { get; set; }

        [ForeignKey("RoutePrivilegeId")]
        public PrivilegedRoute PrivilegedRoute { get; set; }
    }
}