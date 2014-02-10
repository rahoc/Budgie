using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;


namespace Budgie.DialogIn
{
    class ListenDialogInputItem : IDialogInputItem
    {
        private String objectID = String.Empty;

        /// <summary>
        /// the constructor.
        /// </summary>
        /// <param name="objectID">the listen item's objectID</param>
        public ListenDialogInputItem(String objectID)
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
                XElement xListen = new XElement("listen", 
                    new XElement("abstractInformation",
                        new XAttribute("objectID", objectID)));

                return xListen;
            }
        }
    }
}
