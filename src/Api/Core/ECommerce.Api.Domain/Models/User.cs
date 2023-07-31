using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Api.Domain.Models;

public class User : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string EmailAddress { get; set; }
    public int PhoneNumer { get; set; }
    public int IdentityNumber { get; set; }
    public string Password { get; set; }
    public bool EmailConfirmed { get; set; } = false;
    public string Address { get; set; }

    public virtual ICollection<Category> Categories { get; set; }

}

