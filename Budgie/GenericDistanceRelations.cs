using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLib;
using CommonLib.DeviceComponentModel;

namespace Budgie
{
    class GenericDistanceRelations
    {
        private DistanceRelations distanceRelations;

        public DistanceRelations DistanceRelations
        {
            get { return distanceRelations; }
            set { distanceRelations = value; }
        }


        public GenericDistanceRelations()
        {
            // Randomizer für Zufallszahlenerstellung
            Random rnd = new Random();

            // Erzeuge neues Model mit DistanceRelations
            this.DistanceRelations = new DistanceRelations();


            //Erzeuge neue, zufällige DeviceComponentDistance
            // TODO: Erzeuge Distanzen für alle DeviceModel Permutationen
            GenericDeviceModelList devices = new GenericDeviceModelList();
            foreach (GenericDeviceModel device in devices.DeviceModelList)
            {
                foreach (OutputComponentModel outComponent in device.Devicemodel.OutputComponents)
                {
                    DeviceComponentDistance devCompDist = new DeviceComponentDistance(device.Devicemodel.DeviceName, outComponent.ComponentID, DistanceReference.user);

                    // Generiere Distanzen
                    int spaces = Randomizer.GenerateRandomNumber(1, 5); // #spaces die verwendet werden sollen
                    List<double> distanceValues = Randomizer.RandomDistribution(rnd, 1.0, spaces);
                    if (distanceValues.Count() > 0)
                    {
                        devCompDist.IntimateSpaceProbability = distanceValues[0];
                    }
                    if (distanceValues.Count() > 1)
                    {
                        devCompDist.OuterSpaceProbability = distanceValues[1];
                    }
                    if (distanceValues.Count() > 2)
                    {
                        devCompDist.PersonalSpaceProbability = distanceValues[2];
                    }
                    if (distanceValues.Count() > 3)
                    {
                        devCompDist.PublicSpaceProbability = distanceValues[3];
                    }
                    if (distanceValues.Count() > 4)
                    {
                        devCompDist.SocialSpaceProbability = distanceValues[4];
                    }

                    // Zu den DistanceRelations hinzufügen
                    this.DistanceRelations.DeviceComponentDistanceSet.Add(devCompDist);

                } // end foreach OutputComponentModel
            } // end foreach DeviceModel

        }
    }
}
