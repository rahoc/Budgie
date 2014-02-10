using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;


namespace Budgie.DialogIn
{
    class SelectionDialogInputItem : IDialogInputItem
    {
        private String selectionObjectID = String.Empty;
        private String selectionItemObjectID = String.Empty;

        /// <summary>
        /// the constructor.
        /// </summary>
        /// <param name="selectionObjectID">the selection's objectID</param>
        /// <param name="selectionItemObjectID">the selection item's objectID</param>
        public SelectionDialogInputItem(String selectionObjectID, String selectionItemObjectID)
        {
            this.selectionObjectID = selectionObjectID;
            this.selectionItemObjectID = selectionItemObjectID;
        }

        /// <summary>
        /// get the input item's x-representation
        /// </summary>
        public XElement XRepresentation
        {
            get 
            {
                XElement xSelection = new XElement("dialogAct",
                    new XElement("selection",
                        new XAttribute("objectID", selectionObjectID),
                        new XElement("abstractInformation",
                            new XAttribute("objectID", selectionItemObjectID))));

                return xSelection;
            }
        }
    }
}
