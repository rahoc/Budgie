using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using CommonLib;
using SemaineApi.System;
using SemaineApi.Components;
using Budgie.SemaineComponents;


namespace Budgie
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        /// <summary>
        /// Semaine ComponentRunner
        /// </summary>
        public static ComponentRunner runner = new ComponentRunner("config\\sfb.config.xml");

        /// <summary>
        /// the semaine component representing this PC and its output components
        /// </summary>
        private DeviceModelSenderComponent semaineDeviceComponent;

        /// <summary>
        /// the semaine component representing the person model
        /// </summary>
        private PersonModelSender semainePersonModel;

        /// <summary>
        /// the semaine component representing the dialog input
        /// </summary>
        private DialogInputSender semaineDialogInput;

        /// <summary>
        /// the semaine component representing the surroundings model
        /// </summary>
        private SurroundingsModelSender surroundingsPersonModel;

        /// <summary>
        /// the semaine component representing the distance relations
        /// </summary>
        private DistanceRelationsSender distanceRelations;

        /// <summary>
        /// the device's config file
        /// </summary>
        private const String XML_CONFIG_FILE = "DeviceModel.xml";
        private const String DEVICE_MODEL_XSD_FILE = "DeviceModel.xsd";
        private const String COMPONENT_MODEL_XSD_FILE = "ComponentModel.xsd";

        /// <summary>
        /// the actual device name
        /// </summary>
        private String deviceName = "Budgie";
        
        
        
        

        public MainWindow()
        {
            InitializeComponent();
            
            // SEMAINE

            // this client's semaine component runner
            runner.Go();

            Component comp = runner.CreateComponent("Budgie:Budgie.SemaineComponents.DeviceModelSenderComponent(" + deviceName + ")");
            runner.AddComponent(comp);
            // type-cast the well-known component
            if (comp is DeviceModelSenderComponent)
            {
                semaineDeviceComponent = (DeviceModelSenderComponent)comp;
                
                semaineDeviceComponent.SetDeviceRuntime();
                // TODO: setMainWindow(this) - üis this needed?
                // semaineDeviceComponent.setMainWindow(this);
            }

            Component comp2 = runner.CreateComponent("Budgie:Budgie.SemaineComponents.PersonModelSender");
            runner.AddComponent(comp2);
            // type-cast the well-known component
            if (comp2 is PersonModelSender)
            {
                semainePersonModel = (PersonModelSender)comp2;
            }

            Component comp3 = runner.CreateComponent("Budgie:Budgie.SemaineComponents.DialogInputSender(" + deviceName + ")");
            runner.AddComponent(comp3);
            // type-cast the well-known component
            if (comp3 is DialogInputSender)
            {
                semaineDialogInput = (DialogInputSender)comp3;
            }

            Component comp4 = runner.CreateComponent("Budgie:Budgie.SemaineComponents.SurroundingsModelSender");
            runner.AddComponent(comp4);
            // type-cast the well-known component
            if (comp4 is SurroundingsModelSender)
            {
                surroundingsPersonModel = (SurroundingsModelSender)comp4;
            }

            Component comp5 = runner.CreateComponent("Budgie:Budgie.SemaineComponents.DistanceRelationsSender");
            runner.AddComponent(comp5);
            // type-cast the well-known component
            if (comp5 is DistanceRelationsSender)
            {
                distanceRelations = (DistanceRelationsSender)comp5;
            }


            // TEST
            while(true){
                GenericDialogInput diaIn = new GenericDialogInput();
                semaineDialogInput.sendDialogInput(diaIn);


                GenericPersonModel p = new GenericPersonModel("A");
                Console.WriteLine(p.Person.Name.First());
                Console.WriteLine(p.Person.Age.First());

                Console.WriteLine("Geschlecht");
                Console.WriteLine(p.Person.Gender[Gender.male]);
                Console.WriteLine(p.Person.Gender[Gender.female]);

                Console.WriteLine("IntegrationPattern");
                Console.WriteLine(p.Person.IntegrationPattern[IntegrationPattern.sequential]);
                Console.WriteLine(p.Person.IntegrationPattern[IntegrationPattern.simultaneous]);

                Console.WriteLine("Handicaps");
                Console.WriteLine(p.Person.HandicapHearing[true]);
                Console.WriteLine(p.Person.HandicapHearing[false]);
                Console.WriteLine(p.Person.HandicapMobility[true]);
                Console.WriteLine(p.Person.HandicapMobility[false]);
                Console.WriteLine(p.Person.HandicapSpeaking[true]);
                Console.WriteLine(p.Person.HandicapSpeaking[false]);
                Console.WriteLine(p.Person.HandicapVision[true]);
                Console.WriteLine(p.Person.HandicapVision[false]);

                Console.WriteLine("EmotionArousal");
                for (int i = 0; i < 11; i++)
                {
                    if (p.Person.EmotionArousal.ContainsKey(i))
                    {
                        Console.WriteLine(p.Person.EmotionArousal[i]);
                    }
                }

                // Surroundingsmodel
                Console.WriteLine("Surroundingsmodel");
                GenericSurroundingsModel s = new GenericSurroundingsModel("B");
                Console.WriteLine("Volume");
                Console.WriteLine(s.Surrounding.Volume[Level.low]);
                Console.WriteLine(s.Surrounding.Volume[Level.middle]);
                Console.WriteLine(s.Surrounding.Volume[Level.high]);
                Console.WriteLine((s.Surrounding.Volume[Level.high] + s.Surrounding.Volume[Level.middle] + s.Surrounding.Volume[Level.low]));
                Console.WriteLine("Illumination");
                Console.WriteLine(s.Surrounding.Illumination[Level.low]);
                Console.WriteLine(s.Surrounding.Illumination[Level.middle]);
                Console.WriteLine(s.Surrounding.Illumination[Level.high]);


                Console.WriteLine("DistanceRelations");
                GenericDistanceRelations relations = new GenericDistanceRelations();
                Console.WriteLine("1st Set");
                foreach (DeviceComponentDistance dist in relations.DistanceRelations.DeviceComponentDistanceSet)
                {
                    Console.WriteLine(dist.DeviceID + " " + dist.ComponentID + " " + dist.DistanceTo);
                    Console.WriteLine("IntimateSpaceProbability " + dist.IntimateSpaceProbability);
                    Console.WriteLine("OuterSpaceProbability " + dist.OuterSpaceProbability);
                    Console.WriteLine("PersonalSpaceProbability " + dist.PersonalSpaceProbability);
                    Console.WriteLine("PublicSpaceProbability " + dist.PublicSpaceProbability);
                    Console.WriteLine("SocialSpaceProbability " + dist.SocialSpaceProbability);
                }

                Thread.Sleep(1000);
            }

            //XElement xe = XElement.Load(@"XML\PersonModel.xml");

            //TextBox tbName = new TextBox();
            //XElement xName = xe.Element("name");
            //XElement xpString = xName.Element("pString");
            //XAttribute attr = xpString.Attribute("value");
            //tbName.Text = attr.Value;
            //MainPanel.Children.Add(tbName);

            //TextBox tbAge = new TextBox();
            //tbAge.Text = xe.Element("age").Element("pInt").Attribute("value").Value;
            //MainPanel.Children.Add(tbAge);


            //foreach(XElement x in xe.Elements())
            //{
            //    TextBox tb = new TextBox();
            //    tb.Name = x.Name.LocalName;
            //    foreach(XElement d in x.Elements()) {
            //        if (d.Attribute("value") != null)
            //        {
            //            tb.Text = tb.Text + d.Attribute("value").Value + "\n";
            //        }
            //        else
            //        {
            //            foreach (XElement d2 in d.Elements())
            //            {
            //                if (d2.Attribute("value") != null)
            //                {
            //                    tb.Text = tb.Text + d2.Attribute("value").Value + "\n";
            //                }
            //                else
            //                {
            //                    foreach (XElement d3 in d2.Elements())
            //                    {
            //                        if (d3.Attribute("value") != null)
            //                        {
            //                            tb.Text = tb.Text + d3.Attribute("value").Value + "\n";
            //                        }
            //                        else
            //                        {
            //                            tb.Text = tb.Text + "sth missing" + "\n";
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //    }
            //    MainPanel.Children.Add(tb);
            //}
        }
    }
}
