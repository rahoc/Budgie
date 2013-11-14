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


namespace Budgie
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            while(true){
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
