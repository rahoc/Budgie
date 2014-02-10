using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLib;
using CommonLib.DeviceComponentModel;
using System.Xml;

namespace Budgie
{
    class GenericDeviceModel
    {
        private DeviceModel devicemodel;
        public System.Xml.XmlDocument XmlRepresentation;

        public DeviceModel Devicemodel
        {
            get { return devicemodel; }
            set { devicemodel = value; }
        }

        public GenericDeviceModel()
        {

            // TODO: Idee - Erzeuge Bestimmte Anzahl von Devices und OutputComponents generisch -> Wähle generisch aus vorhandenem Set
            /*
             * Beispieldevices überlegen
             * Set erzeugen und daraus zufällig auswählen
             * Abhängig von Ergebnis mit 5 Geräten weiteres Vorgehen
             */

            //int rndInt = Randomizer.GenerateRandomNumber(0, 10);

            //if (rndInt > 5)
            //{
                
                // Hinzufügen eines OutputComponents zum DeviceModel
            //    OutputComponentModel outComp = new OutputComponentModel("Speech", OutputEncoderMedium.tts, InputDecoderMedium.speech);
                
            //    this.Devicemodel.AddOutputComponent(new OutputComponentModel("Touchscreen", OutputEncoderMedium.gui, InputDecoderMedium.touch));
            //    this.Devicemodel.AddOutputComponent(new OutputComponentModel("Speech", OutputEncoderMedium.tts, InputDecoderMedium.speech));
            //    this.Devicemodel.AddOutputComponent(new OutputComponentModel("Mobile", OutputEncoderMedium.vibration, InputDecoderMedium.gesture));
            ////}
            //else
            //{
            //    this.Devicemodel = new DeviceModel("Scratchy", "Scratchy", Language.de, InputMessageType.InteractionInput);
            //    // Hinzufügen eines OutputComponents zum DeviceModel
            //    this.Devicemodel.AddOutputComponent(new OutputComponentModel("TTS", OutputEncoderMedium.tts, InputDecoderMedium.none));
            //}

            XmlDocument doc = new XmlDocument();
            doc.Load("XML\\DeviceModel.xml");
            this.Devicemodel = DeviceModel.Load(doc);
            XmlRepresentation = this.Devicemodel.XmlRepresentation;
        }
    }
}
