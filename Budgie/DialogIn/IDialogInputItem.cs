using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Budgie.DialogIn
{
    /// <summary>
    /// an interface for all types of dialog input
    /// </summary>
    public interface IDialogInputItem
    {
        /// <summary>
        /// get the input item's x-representation
        /// </summary>
        XElement XRepresentation { get; }
    }
}
