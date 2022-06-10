﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Schronisko.Areas.Identity.Data;

// Add profile data for application users by adding properties to the SchroniskoUser class
public class SchroniskoUsers : IdentityUser
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public bool IsAdmin { get; set; }
   
}

