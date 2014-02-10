using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using CommonLib;
using Budgie.DialogIn;


namespace Budgie.DialogIn
{
    class TextInputDialogInputItem : IDialogInputItem
    {
        private String objectID = String.Empty;
        private string informationID = string.Empty;
        private string value = string.Empty;
        private double confidence = 0;

        /// <summary>
        /// the constructor.
        /// </summary>
        /// <param name="objectID">the item's objectID</param>
        /// <param name="informationID">the item's informationID</param>
        /// <param name="value">the new value</param>
        /// <param name="confidence">the confidence</param>
        public TextInputDialogInputItem(string objectID, string informationID, string value, double confidence)
        {
            this.objectID = objectID;
            this.informationID = informationID;
            this.value = value;
            this.confidence = confidence;
        }

        /// <summary>
        /// get the input item's x-representation
        /// </summary>
        public XElement XRepresentation
        {
            get
            {   
                return new XElement("dialogAct", 
                          new XElement("textinput",
                            new XAttribute("objectID", objectID),
                            new XAttribute("informationID", informationID),
                            new XAttribute("value", value),
                            new XAttribute("confidence", confidence)));
            }
        }

        /// <summary>
        /// the trigger type
        /// </summary>
        public TriggerType TriggerType
        {
            get { return TriggerType.Parameter; }
        }



        /// <summary>
        /// Bestimmt, ob das angegebene System.Object und das aktuelle System.Object gleich sind.
        /// </summary>
        /// <param name="obj">Das System.Object, das mit dem aktuellen System.Object verglichen werden soll.</param>
        /// <returns>true, wenn das angegebene System.Object gleich dem aktuellen System.Object ist, andernfalls false.</returns>
        public override bool Equals(object obj)
        {
            if (obj is TextInputDialogInputItem)
                if (((TextInputDialogInputItem)obj).objectID == this.objectID)
                    if (((TextInputDialogInputItem)obj).informationID == this.informationID)
                        if (((TextInputDialogInputItem)obj).value == this.value)
                            if (((TextInputDialogInputItem)obj).confidence == this.confidence)
                                return true;

            return false;
        }

        /// <summary>
        /// Bestimmt, ob die angegebenen System.Object-Instanzen als gleich betrachtet werden.
        /// </summary>
        /// <param name="objA">Das erste zu vergleichende System.Object.</param>
        /// <param name="objB">Das zweite zu vergleichende System.Object.</param>
        /// <returns>true, wenn die Objekte als gleich betrachtet werden, andernfalls false.</returns>
        public new bool Equals(object objA, object objB)
        {
            if (objA is TextInputDialogInputItem)
            {
                return ((TextInputDialogInputItem)objA).Equals(objB);
            }
            else
            {
                return objA.Equals(objB);
            }
        }

        /// <summary>
        /// get the object's hash code
        /// </summary>
        /// <returns>the object's hashcode</returns>
        public override int GetHashCode()
        {
            String temp = objectID + "." + informationID + "." + value + "." + confidence;
            return temp.GetHashCode();
        }
    }
}
