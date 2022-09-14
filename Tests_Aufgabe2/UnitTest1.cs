using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;


namespace Tests_Aufgabe2
{
    [TestClass]
    public class UnitTest2
    {
        #region Initialize

        #endregion

        #region TestMethod1
        [TestMethod]
        [TestCategory("InOut")]
        [TestProperty("GSO-DevGroup", "Akinci")]

        public void TestMethod1()
        {
            // Arrange
            var writer = new StringWriter();
            Console.SetOut(writer);

            // Act
            Aufgabe_2.Aufgabe2();

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


            List<string> lines_list_check = new List<string> { $"{"Vorname",-10}| = |{"Fred",-10}|", $"{"Nachname",-10}| = |{"Opals",-10}|", $"{"Gehalt",-10}| = |{2456 + " EUR",-10}|", $"{"Vorname",-10}| = |{"Betül",-10}|", $"{"Nachname",-10}| = |{"Rötger",-10}|", $"{"Gehalt",-10}| = |{2781 + " EUR",-10}|" };



            lines_list = lines_list.Intersect(lines_list_check).ToList();


            for (int i = 0; i < lines_list_check.Count; i++)
            {

                try
                {
                    if (lines_list[i] != lines_list_check[i]) Trace.WriteLine($"\nFehler: '{lines_list_check[i]}' nicht gefunden");
                    Assert.AreEqual(lines_list[i], lines_list_check[i]);
                }
                catch
                {
                    Trace.WriteLine($"Fehler: Zeilen fehlen");
                    Assert.Fail(); 
                }

            }

        }


        #endregion

    }
}
