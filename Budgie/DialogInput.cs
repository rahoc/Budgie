using Budgie.DialogIn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Budgie
{
    class DialogInput
    {
        private DateTime timeStamp;

        private String dialogID;
        private String deviceID;
        private String componentID;

        private IDialogInputItem dialogInputItem;

        /// <summary>
        /// the constructor.
        /// </summary>
        /// <param name="dialogID">this dialog's id</param>
        /// <param name="deviceID">the deviceID on which the input occured</param>
        /// <param name="componentID">the componentID on which the input occured</param>
        /// <param name="dialogInputItem">the input's item</param>
        public DialogInput(String dialogID, String deviceID, String componentID, IDialogInputItem dialogInputItem)
        {
            timeStamp = DateTime.Now;
            this.dialogID = dialogID;
            this.deviceID = deviceID;
            this.componentID = componentID;
            this.dialogInputItem = dialogInputItem;
        }

        /// <summary>
        /// get the xml representation of this dialog input
        /// </summary>
        public XmlDocument XmlRepresentation
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                sb.Append("<dialogInput xmlns=\"http://sfb-trr-62.de/b3/DialogInput.xsd\" ");
                sb.Append("dialogID=\"" + dialogID + "\" ");
                sb.Append("dateTime = \"" + XmlConvert.ToString(timeStamp, XmlDateTimeSerializationMode.Local) + "\" ");
                sb.Append("deviceID=\"" + deviceID + "\" ");
                sb.Append("componentID=\"" + componentID + "\" ");
                //sb.Append("interactionType=\"normal user input\"");
                sb.Append(">");

                sb.Append(dialogInputItem.XRepresentation);

                sb.Append("</dialogInput>");

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(sb.ToString());

                return xmlDoc;
            }
        }
    }
}
