using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipePlatform.Models.Entities.Enum
{
    public enum UserRole
    {
        Admin, // Full access to all features
        User, // Can view and create recipes, but not manage users or categories
        Guest // Limited access, can only view public recipes
    }
}
