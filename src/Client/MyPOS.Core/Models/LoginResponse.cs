using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPOS.Core.Models
{
    public class LoginResponse
    {
        public bool IsFailure { get; set; }
        public string ErrorMessage { get; set; }
    }
}