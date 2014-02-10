using SemaineApi.Components;
using SemaineApi.NMS.Message;
using SemaineApi.NMS.Receiver;
using SemaineApi.NMS.Sender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Budgie.SemaineComponents
{
    class SurroundingsModelSender : Component
    {
        private XMLSender _surroundingsModelSender;
        private Receiver _requestReceiver;
        
        private string _assemblyPath;

        public SurroundingsModelSender()
            : base("B3.Budgie.SurroundingsModelSender")
        {
            _assemblyPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);

            _requestReceiver = new Receiver("semaine.data.surroundings.request");
            _receivers.AddLast(_requestReceiver);

            _surroundingsModelSender = new XMLSender("semaine.data.surroundings", "XML", this.GetType().Name);
            _senders.AddLast(_surroundingsModelSender);
        }


        //--------------------------------------------------------

        protected override void React(SEMAINEMessage message)
        {
            if (message.Text.Equals("UPDATE", StringComparison.OrdinalIgnoreCase)) {
                GenericSurroundingsModel surrounding = new GenericSurroundingsModel("surrounding_id");
                XmlDocument doc = surrounding.Surrounding.XmlRepresentation;
                _surroundingsModelSender.SendXML(doc, _meta.CurrentTime);

            }
        }
    }
}
