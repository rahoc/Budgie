using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLib;
using System.Security.Cryptography;

namespace Budgie
{
    class TestPerson
    {
        PersonModel person;

        public PersonModel Person
        {
            get { return person; }
            set { person = value; }
        }

        public TestPerson(string id)
        {
            // Variablendeklaration
            float random1;
            float random2;

            // Erzeuge neues PersonModel
            this.Person = new PersonModel(id);
            
            // Name
            DeutscheNamen names = new DeutscheNamen();
            this.Person.Name.Add(names.Names[GenerateRandomNumber(0,names.Names.Length)], 1);

            // Alter
            this.Person.Age.Add(GenerateRandomNumber(1,99), 1);
            
            // Geschlecht
            GenerateRandomDistribution(out random1, out random2);
            // TODO: Muss/Sollte hier gerundet werden?
            this.Person.Gender.Add(Gender.male, random1);
            this.Person.Gender.Add(Gender.female, random2);

            // Integration Pattern
            GenerateRandomDistribution(out random1, out random2);
            this.Person.IntegrationPattern.Add(IntegrationPattern.sequential, random1);
            this.Person.IntegrationPattern.Add(IntegrationPattern.simultaneous, random2);

            // Emotion
            // TODO: Wie genau funktionert padValue? 1-10 Werte oder auch max zwei?

            // Handicaps
            GenerateRandomDistribution(out random1, out random2);
            this.Person.HandicapHearing.Add(true, random1);
            this.Person.HandicapHearing.Add(false, random2);
            GenerateRandomDistribution(out random1, out random2);
            this.Person.HandicapMobility.Add(true, random1);
            this.Person.HandicapMobility.Add(false, random2);
            GenerateRandomDistribution(out random1, out random2);
            this.Person.HandicapSpeaking.Add(true, random1);
            this.Person.HandicapSpeaking.Add(false, random2);
            GenerateRandomDistribution(out random1, out random2);
            this.Person.HandicapVision.Add(true, random1);
            this.Person.HandicapVision.Add(false, random2);


        }

        

        /// <summary>
        ///  Gute Zufallszahlen erzeugen
        ///  Quelle: http://www.hofmann-robert.info/?p=360
        /// </summary>
        protected static int GenerateRandomNumber(int min, int max)
        {
            RNGCryptoServiceProvider c = new RNGCryptoServiceProvider();
            // Integer benötigt 4 Byte
            byte[] randomNumber = new byte[4];
            // Array mit zufälligen Bytes befüllen
            c.GetBytes(randomNumber);
            // Byte-Array in einen Integer umwandeln
            int result = Math.Abs(BitConverter.ToInt32(randomNumber, 0));
            // Begrenzung durch Modulo Rechnung
            return result % max + min;
        }

        /// <summary>
        /// Erzeuge eine zufällige Wahrscheinlichkeitsverteilung auf zwei Werte
        /// </summary>
        /// <param name="randomDist1">Erster Zufälliger wert zwischen 0 und 1.0, Summe aus beiden Werten ergibt 1.0</param>
        /// <param name="randomDist2">Zweiter Zufälliger wert zwischen 0 und 1.0, Summe aus beiden Werten ergibt 1.0</param>
        protected static void GenerateRandomDistribution(out float randomDist1, out float randomDist2)
        {
            // TODO: wenn Funktion schnell hintereinander aufgerufen wird erzeugt NextDouble() selben Zufallswert (TimeStamp!)
            Random rnd = new Random();
            randomDist1 = (float)rnd.NextDouble();
            randomDist2 = (float)1.0 - randomDist1;
        }

    }
}
