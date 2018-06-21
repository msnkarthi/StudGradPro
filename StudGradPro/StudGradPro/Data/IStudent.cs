using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudGradPro.Data
{
    /// <summary>
    /// The Student Interface.
    /// </summary>
    public interface IStudent
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        int Id { set; get; }
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        string FirstName { set; get; }
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        string LastName { set; get; }
        /// <summary>
        /// Gets or sets the e mail.
        /// </summary>
        /// <value>
        /// The e mail.
        /// </value>
        string EMail { set; get; }
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        string Status { set; get; }
    }
}
