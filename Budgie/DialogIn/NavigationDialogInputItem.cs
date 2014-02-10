using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;


namespace Budgie.DialogIn
{
    class NavigationDialogInputItem : IDialogInputItem
    {
        private String objectID = String.Empty;

        /// <summary>
        /// the constructor.
        /// </summary>
        /// <param name="objectID">the navigation item's objectID</param>
        public NavigationDialogInputItem(String objectID)
        {
            this.objectID = objectID;
        }

        /// <summary>
        /// get the input item's x-representation
        /// </summary>
        public XElement XRepresentation
        {
            get 
            {
                XElement xNavigation = new XElement("navigation", 
                    new XElement("abstractInformation",
                        new XAttribute("objectID", objectID)));
                
                return xNavigation;
            }
        }
    }
}
