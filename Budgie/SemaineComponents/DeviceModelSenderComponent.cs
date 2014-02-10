using SemaineApi.Components;
using SemaineApi.NMS.Sender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Budgie.SemaineComponents
{

    class DeviceModelSenderComponent : Component
    {
        
        static int id = 0;

        private XMLSender _sender;
        private long _lastMSG = 0;
        private int _delay = 5000;

        public DeviceModelSenderComponent(String deviceName)
            : base("B3." + deviceName + ".Device")
        {
            _sender = new XMLSender("semaine.data." + deviceName, "XML", this.GetType().Name);
            _senders.AddLast(_sender);
        }


        /// <summary>
        /// set the provider for the device model
        /// </summary>
        /// <param name="clientRuntime">the device model providing class</param>
        internal void SetDeviceRuntime(/*IClientRuntime clientRuntime*/)
        {
            //this.clientRuntime = clientRuntime;

            // we need this break for the semaine :-(
            Thread.Sleep(300);
            sendDeviceModel();
        }

        /// <summary>
        /// send the actual device model as bytes message
        /// </summary>
        internal void sendDeviceModel()
        {
           // if (clientRuntime != null)
            //{
            GenericDeviceModel dModel = new GenericDeviceModel();
            _sender.SendXML(dModel.XmlRepresentation, _meta.CurrentTime);
           // }
        }


        protected override void Act()
        {
            if (_meta.CurrentTime - _lastMSG > _delay)
            {
                /* is Act needed??
                foreach (SenderDataXml data in webService.senderData.OfType<SenderDataXml>())
                {
                    if (_sender.TopicName == data.Topic)
                    {
                        _sender.SendXML(data.XmlDoc.ToXmlDocument(), _meta.CurrentTime);
                        _lastMSG = _meta.CurrentTime;
                    }
                }*/
            }
        }
    }
    
}
