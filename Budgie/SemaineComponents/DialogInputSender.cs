using SemaineApi.Components;
using SemaineApi.NMS.Sender;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budgie.SemaineComponents
{
    
    class DialogInputSender : Component
    {
        /// <summary>
        /// the sender to broadcast the user input
        /// </summary>
        private XMLSender dialogInputSender;


        public DialogInputSender(String deviceName)
            : base("B3." + deviceName + ".DialogInputSender")
        {
            dialogInputSender = new XMLSender("semaine.data.dialog.input", "XML", this.GetType().Name);
            _waitingTime = 1000;
            _senders.AddLast(dialogInputSender);
        }

        /// <summary>
        /// send the dialog input
        /// </summary>
        /// <param name="dialogInput">the dialog input to be sent</param>
        internal void sendDialogInput(GenericDialogInput dialogInput)
        {
            if (dialogInput.DialogInput.XmlRepresentation == null)
            {
                Console.WriteLine("tried to send an invalide dialog input");
                return;
            }
            dialogInputSender.SendXML(dialogInput.DialogInput.XmlRepresentation, _meta.CurrentTime);


        }
    }
}
