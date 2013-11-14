using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLib;

namespace Budgie
{
    class GenericSurroundingsModel
    {
        private SurroundingsModel surrounding;

        public SurroundingsModel Surrounding
        {
            get { return surrounding; }
            set { surrounding = value; }
        }

        public GenericSurroundingsModel(string id)
        {
            // Randomizer für Zufallszahlenerstellung
            Random rnd = new Random();

            // Erzeuge neues Surroundingsmodel
            this.Surrounding = new SurroundingsModel(id);

            // Volume
            List<double> volumeValues = Randomizer.RandomDistribution(rnd, 1.0, 3);
            this.Surrounding.Volume.Add(Level.low, volumeValues[0]);
            this.Surrounding.Volume.Add(Level.middle, volumeValues[1]);
            this.Surrounding.Volume.Add(Level.high, volumeValues[2]);

            // Illumination
            List<double> illuminationValues = Randomizer.RandomDistribution(rnd, 1.0, 3);
            this.Surrounding.Illumination.Add(Level.low, illuminationValues[0]);
            this.Surrounding.Illumination.Add(Level.middle, illuminationValues[1]);
            this.Surrounding.Illumination.Add(Level.high, illuminationValues[2]);

            // Szene
            List<double> sceneValues = Randomizer.RandomDistribution(rnd, 1.0, 3);
            this.Surrounding.Scene.Add(Scene.singleUserSinglePerson, sceneValues[0]);
            this.Surrounding.Scene.Add(Scene.singleUserMultiPerson, sceneValues[1]);
            this.Surrounding.Scene.Add(Scene.multiUserMultiPerson, sceneValues[2]);

            // Privacy
            List<double> privacyValues = Randomizer.RandomDistribution(rnd, 1.0, 2);
            this.Surrounding.PrivacyAspect.Add(PrivacyAspect.isPrivate, privacyValues[0]);
            this.Surrounding.PrivacyAspect.Add(PrivacyAspect.isPublic, privacyValues[1]);

            // DemandSilence
            List<double> silenceValues = Randomizer.RandomDistribution(rnd, 1.0, 2);
            this.Surrounding.DemandSilence.Add(true, silenceValues[0]);
            this.Surrounding.DemandSilence.Add(false, silenceValues[1]);

            // DemandDarkness
            List<double> darknessValues = Randomizer.RandomDistribution(rnd, 1.0, 2);
            this.Surrounding.DemandDarkness.Add(true, darknessValues[0]);
            this.Surrounding.DemandDarkness.Add(false, darknessValues[1]);

        }

        

    }
}
