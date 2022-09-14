using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;


namespace Tests_Aufgabe1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [TestCategory("InOut")]
        [TestProperty("GSO-DevGroup", "Kander")]


        public void Test_InOut()
        {
            // Arrange
            var writer = new StringWriter();
            Console.SetOut(writer);

            // Act
            Aufgabe_1.Aufgabe1();

            // Assert

            var sb = writer.GetStringBuilder();
            var lines = sb.ToString().Split(Environment.NewLine, StringSplitOptions.None);

            List<string> lines_list = new List<string>();

            //Bedingung nötig da 'Enviroment.NewLine' in Git Actions nicht funktioniert.
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] != "")
                {
                    lines_list.Add(lines[i]);
                    Debug.WriteLine($"{lines[i]}");
                }
            }

            List<string> lines_list_check = new List<string> { $"{"Höhe",10}{"Breite",10}",$"{32.346,10:F1}{15.193,10:F1}" };


            lines_list = lines_list.Intersect(lines_list_check).ToList();


            for (int i = 0; i < lines_list_check.Count; i++)
            {

                try {
                    if (lines_list[i] != lines_list_check[i]) Trace.WriteLine($"\nFehler: '{lines_list_check[i]}' nicht gefunden");
                    Assert.AreEqual(lines_list[i], lines_list_check[i]);
                }
                catch {
                    Trace.WriteLine($"Fehler: Zeilen fehlen");
                    Assert.Fail(); ;

                }

            }

        }
    }
}
