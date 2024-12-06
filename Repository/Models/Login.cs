using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Config.Repository.Models
{
    public class Login
    {
        public string Log { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}