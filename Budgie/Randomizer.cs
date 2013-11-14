using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Budgie
{
    class Randomizer
    {
        /// <summary>
        /// Summe erstellt eine spezifische Anzahl Zufallszahlen, die zusammen eine bestimmte Summe ergeben
        /// Quelle: http://www.matheboard.de/archive/501805/thread.html, 14.11.2013
        /// </summary>
        /// <param name="rnd">Randomizer damit nicht immer ein neuer erzeugt wird, dadurch erhält man bessere Zufallszahlen</param>
        /// <param name="sum">Gewünschte Summe der erzeugten Zufallszahlen</param>
        /// <param name="count">Anzahl der zu erzeugenden Zufallszahlen</param>
        /// <returns>Liste mit der gewünschten Anzahl Zufallszahlen</returns>
        public static List<Double> RandomDistribution(Random rnd, Double sum, Int32 count)
        {
            // Liste für die erstellten Werte
            List<Double> randomValues = new List<Double>();
            // Summe der Zufallszahlen
            Double sumZ = 0;

            for (Int32 i = 0; i < count; i++)
            {
                Double randomValue = rnd.NextDouble();
                // Erzeuge die gewünschte Anzahl Zufallswärte
                randomValues.Add(randomValue);
                // Berechne Summe z der erzeugten Zufallswerte
                sumZ += randomValue;
            }

            // Sei sum = x. Teile x/z = m.
            if (sumZ <= 0)
            {
                // Nicht durch 0 teilen, Wert sollte positiv sein!
                return null;
            }
            Double multiply = sum / sumZ;

            // Multipliziere alle Zufallszahlen mit m.
            for (Int32 i = 0; i < count; i++)
            {
                randomValues[i] = randomValues[i] * multiply;
            }

            return randomValues;
        }


        /// <summary>
        ///  Gute Integer Zufallszahlen erzeugen
        ///  Quelle: http://www.hofmann-robert.info/?p=360
        /// </summary>
        public static int GenerateRandomNumber(int min, int max)
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


        // TODO: Teste diese funktion und ersetze Emotion
        /// <summary>
        /// Erzeuge ein Dictionary mit zufällig vielen, wiederum zufälligen Integer Werten zwischen min und max, deren zufällige Wahrscheinlichkeitswerte zusammen eine bestimmte Summe ergeben.
        /// </summary>
        /// <param name="rnd">Randomizer damit nicht immer ein neuer erzeugt wird, dadurch erhält man bessere Zufallszahlen</param>
        /// <param name="min">Kleinster Integerwert</param>
        /// <param name="max">Größter Integerwert</param>
        /// <param name="sum">Gewünschte Summe der erzeugten Zufallszahlen</param>
        /// <returns></returns>
        public static Dictionary<int, double> IntAndProbabilityDistribuion(Random rnd, int min, int max, double sum) {

            Dictionary<int, double> distribution = new Dictionary<int, double>();

            List<int> values = new List<int>();
            // Erzeuge eine bestimmt Anzahl an Werten
            int countValues = Randomizer.GenerateRandomNumber(min, max);
            for (int i = 0; i<countValues; i++)
            {
                int newValue;
                do {
                    newValue = Randomizer.GenerateRandomNumber(min, max);
                }
                while (values.Contains(newValue));
                // Füge einigartige Zahl hinzu
                values.Add(newValue);
            }
            // Erzeuge Wahrscheinlichkeiten
            List<double> valueProbabilities = Randomizer.RandomDistribution(rnd, sum, countValues);
            // Füge Werte in Model ein
            for (int i = 0; i < countValues; i++)
            {
                distribution.Add(values[i], valueProbabilities[i]);
            }

            return distribution;
        }
    }
}
