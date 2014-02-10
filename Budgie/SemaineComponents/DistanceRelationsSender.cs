using SemaineApi.Components;
using SemaineApi.NMS.Message;
using SemaineApi.NMS.Receiver;
using SemaineApi.NMS.Sender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Budgie.SemaineComponents
{
    class DistanceRelationsSender : Component
    {
        private XMLSender _surroundingsModelSender;
        private Receiver _requestReceiver;
        
        private string _assemblyPath;

        public DistanceRelationsSender()
            : base("B3.Budgie.DistanceRelationsSender")
        {
            _assemblyPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);

            _requestReceiver = new Receiver("semaine.data.relations.distance");
            _receivers.AddLast(_requestReceiver);

            _surroundingsModelSender = new XMLSender("semaine.data.relations.distance", "XML", this.GetType().Name);
            _senders.AddLast(_surroundingsModelSender);
        }


        //--------------------------------------------------------

        protected override void React(SEMAINEMessage message)
        {
            if (message.Text.Equals("UPDATE", StringComparison.OrdinalIgnoreCase)) {
                GenericDistanceRelations distances = new GenericDistanceRelations();
                XmlDocument doc = distances.DistanceRelations.XmlRepresentation;
                _surroundingsModelSender.SendXML(doc, _meta.CurrentTime);

            }
        }

    }
}
