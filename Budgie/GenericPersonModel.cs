using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLib;
using System.Security.Cryptography;

namespace Budgie
{
    class GenericPersonModel
    {
        private PersonModel person;

        public PersonModel Person
        {
            get { return person; }
            set { person = value; }
        }

        public GenericPersonModel(string id)
        {
            // Variablendeklaration
            float random1;
            float random2;
            Random rnd = new Random();

            // Erzeuge neues PersonModel
            this.Person = new PersonModel(id);
            
            // Name
            DeutscheNamen names = new DeutscheNamen();
            this.Person.Name.Add(names.Names[Randomizer.GenerateRandomNumber(0,names.Names.Length)], 1);

            // Alter
            this.Person.Age.Add(Randomizer.GenerateRandomNumber(1, 99), 1);
            
            // Geschlecht
            GenerateRandomBoolDistribution(rnd, out random1, out random2);
            this.Person.Gender.Add(Gender.male, random1);
            this.Person.Gender.Add(Gender.female, random2);

            // Integration Pattern
            GenerateRandomBoolDistribution(rnd, out random1, out random2);
            this.Person.IntegrationPattern.Add(IntegrationPattern.sequential, random1);
            this.Person.IntegrationPattern.Add(IntegrationPattern.simultaneous, random2);

            // Emotion
            // TODO: Wie genau funktionert padValue? 1-10 Werte oder auch max zwei?

            List<int> padValues = new List<int>();
            // Erzeuge eine bestimmt Anzahl an Werten
            int countPadValues = Randomizer.GenerateRandomNumber(0,10);
            for (int i = 0; i<countPadValues; i++)
            {
                int newPadValue;
                do {
                    newPadValue = Randomizer.GenerateRandomNumber(0, 10);
                }
                while (padValues.Contains(newPadValue));
                // Füge einigartige Zahl hinzu
                padValues.Add(newPadValue);
            }
            // Erzeuge Wahrscheinlichkeiten
            List<double> padValueProbabilities = Randomizer.RandomDistribution(rnd, 1.0, countPadValues);
            // Füge Werte in Model ein
            for (int i = 0; i < countPadValues; i++)
            {
                this.Person.EmotionArousal.Add(padValues[i], padValueProbabilities[i]);
            }


            

            // Handicaps
            GenerateRandomBoolDistribution(rnd, out random1, out random2);
            this.Person.HandicapHearing.Add(true, random1);
            this.Person.HandicapHearing.Add(false, random2);
            GenerateRandomBoolDistribution(rnd, out random1, out random2);
            this.Person.HandicapMobility.Add(true, random1);
            this.Person.HandicapMobility.Add(false, random2);
            GenerateRandomBoolDistribution(rnd, out random1, out random2);
            this.Person.HandicapSpeaking.Add(true, random1);
            this.Person.HandicapSpeaking.Add(false, random2);
            GenerateRandomBoolDistribution(rnd, out random1, out random2);
            this.Person.HandicapVision.Add(true, random1);
            this.Person.HandicapVision.Add(false, random2);

            // Preferences channel
            GenerateRandomBoolDistribution(rnd, out random1, out random2);
            this.Person.PreferenceChannelAural.Add(true, random1);
            this.Person.PreferenceChannelAural.Add(false, random2);
            GenerateRandomBoolDistribution(rnd, out random1, out random2);
            this.Person.PreferenceChannelTactile.Add(true, random1);
            this.Person.PreferenceChannelTactile.Add(false, random2);
            GenerateRandomBoolDistribution(rnd, out random1, out random2);
            this.Person.PreferenceChannelVisual.Add(true, random1);
            this.Person.PreferenceChannelVisual.Add(false, random2);


        }

        

        

        /// <summary>
        /// Erzeuge eine zufällige Wahrscheinlichkeitsverteilung auf zwei Werte
        /// </summary>
        /// <param name="randomDist1">Erster Zufälliger wert zwischen 0 und 1.0, Summe aus beiden Werten ergibt 1.0</param>
        /// <param name="randomDist2">Zweiter Zufälliger wert zwischen 0 und 1.0, Summe aus beiden Werten ergibt 1.0</param>
        protected static void GenerateRandomBoolDistribution(Random rnd, out float randomDist1, out float randomDist2)
        {
            randomDist1 = (float)rnd.NextDouble();
            randomDist2 = (float)1.0 - randomDist1;
        }

    }
}
