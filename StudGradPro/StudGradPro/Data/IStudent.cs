using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudGradPro.Data
{
    public interface IStudent
    {
        int Id { set; get; }
        string FirstName { set; get; }
        string LastName { set; get; }
        string EMail { set; get; }
        string Status { set; get; }
    }
}
