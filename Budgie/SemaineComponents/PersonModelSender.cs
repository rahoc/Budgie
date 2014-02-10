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
    class PersonModelSender: Component
    {
        // Die Sender und Receiver
        private XMLSender _personModelSender;
        private Receiver _requestReceiver;
        
        //private string _assemblyPath;
        // Konstruktor
        public PersonModelSender()
            : base("B3.Budgie.PersonModelSender")
        {
            // _assemblyPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            //Person Model request Receiver
            _requestReceiver = new Receiver("semaine.data.user.request");
            _receivers.AddLast(_requestReceiver);
            // Person Model Sender
            _personModelSender = new XMLSender("semaine.data.user", "XML", this.GetType().Name);
            _senders.AddLast(_personModelSender);
        }

        // Reagiere auf Requests
        protected override void React(SEMAINEMessage message)
        {
            if (message.Text.Equals("UPDATE", StringComparison.OrdinalIgnoreCase)) {
                GenericPersonModel person = new GenericPersonModel("person_id");
                XmlDocument doc = person.Person.XmlRepresentation;
                _personModelSender.SendXML(doc, _meta.CurrentTime);
            }
        }
    
    }
}
