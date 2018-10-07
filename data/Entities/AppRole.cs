using Microsoft.AspNetCore.Identity;

namespace be_master_with_core2.Data.Entities
{
    public class AppRole : IdentityRole<int>
    {
        public AppRole() { }

        public AppRole(string name)
        {
            Name = name;
        }
    }
}