using LinqToExcel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Text;
using System.Threading.Tasks;

namespace Security_Threats
{
    public class Data
    {
        public List<Threat> Source { get; set; } = new List<Threat>();

        public Data(string filename)
        {
            var excel = new ExcelQueryFactory();
            excel.FileName = filename;

            try
            {
                Source = (from row in excel.Worksheet("Sheet")
                          let item = new Threat
                          {
                              Id = row[0].Cast<string>(),
                              Name = row[1].Cast<string>(),
                              Description = row[2].Cast<string>(),
                              Source = row[3].Cast<string>(),
                              Impact = row[4].Cast<string>(),
                              Confidentiality = row[5].Cast<string>(),
                              Integrity = row[6].Cast<string>(),
                              Accessibility = row[7].Cast<string>(),
                          }

                          select item).ToList();
            }
            catch (System.Data.OleDb.OleDbException)
            {
                MessageBox.Show("Ошибка: " + filename + " не может быть открыт\nПроверьте, что файл не используется кем-то другим");
                Application.Current.MainWindow.Close();
            }
            
            Source.RemoveAt(0);

            foreach (var item in Source)
            {
                if (item.Confidentiality == "1")
                {
                    item.Confidentiality = "да";
                }
                else
                {
                    item.Confidentiality = "нет";
                }
                if (item.Integrity == "1")
                {
                    item.Integrity = "да";
                }
                else
                {
                    item.Integrity = "нет";
                }
                if (item.Accessibility == "1")
                {
                    item.Accessibility = "да";
                }
                else
                {
                    item.Accessibility = "нет";
                }

            }
        }
        public static List<Threat> Shrink(List<Threat> threats)
        {
            var shrinkedThreats = new List<Threat>();

            foreach (var item in threats)
            {
                shrinkedThreats.Add(new Threat { Id = "УБИ." + item.Id, Name = item.Name });
            }
            
            return shrinkedThreats;
        }

        public static void Compare(Data newData, Data oldData)
        {
            int countChanges = 0;
            
            int threatsAmount = newData.Source.Count;
            if (newData.Source.Count != oldData.Source.Count)
            {
                countChanges += Math.Abs(newData.Source.Count - oldData.Source.Count);
                if (oldData.Source.Count < newData.Source.Count)
                {
                    threatsAmount = oldData.Source.Count;
                }
            }

            List<Change> changes = new List<Change>();
            for (int i = 0; i < threatsAmount; i++)
            {
                Threat threat1 = oldData.Source[i];
                Threat threat2 = newData.Source[i];
                if (threat1.Name != threat2.Name || threat1.Description != threat2.Description || threat1.Source != threat2.Source || threat1.Impact != threat2.Impact || threat1.Confidentiality != threat2.Confidentiality || threat1.Integrity != threat2.Integrity || threat1.Accessibility != threat2.Accessibility)
                {
                    countChanges++;
                    if (threat1.Name != threat2.Name)
                    {
                        changes.Add(new Change() { Id = threat1.Id, Before = threat1.Name, After = threat2.Name });
                    }
                    if (threat1.Description != threat2.Description)
                    {
                        changes.Add(new Change() { Id = threat1.Id, Before = threat1.Description, After = threat2.Description });
                    }
                    if (threat1.Source != threat2.Source)
                    {
                        changes.Add(new Change() { Id = threat1.Id, Before = threat1.Source, After = threat2.Source });
                    }
                    if (threat1.Impact != threat2.Impact)
                    {
                        changes.Add(new Change() { Id = threat1.Id, Before = threat1.Impact, After = threat2.Impact });
                    }
                    if (threat1.Confidentiality != threat2.Confidentiality)
                    {
                        changes.Add(new Change() { Id = threat1.Id, Before = threat1.Confidentiality, After = threat2.Confidentiality });
                    }
                    if (threat1.Integrity != threat2.Integrity)
                    {
                        changes.Add(new Change() { Id = threat1.Id, Before = threat1.Integrity, After = threat2.Integrity });
                    }
                    if (threat1.Accessibility != threat2.Accessibility)
                    {
                        changes.Add(new Change() { Id = threat1.Id, Before = threat1.Accessibility, After = threat2.Accessibility });
                    }
                }
            }
            new UpdateSuccess(countChanges, changes).Show();
        }
        public static string ToText(List<Threat> threats)
        {
            string result = "";
            foreach (var item in threats)
            {
                result += "=================================================================================================================================================\n";
                result += "Идентификатор  угрозы: " + item.Id + "\n";
                result += "Наименование УБИ:" + item.Name + "\n";
                result += "Описание: " + item.Description + "\n";
                result += "Источник угрозы (характеристика и потенциал нарушителя): " + item.Source + "\n";
                result += "Объект воздействия: " + item.Impact + "\n";
                result += "Нарушение конфиденциальности: " + item.Confidentiality + "\n";
                result += "Нарушение целостности: " + item.Integrity + "\n";
                result += "Нарушение доступности: " + item.Accessibility + "\n";
                result += "=================================================================================================================================================\n";
            }
            return result;
        }
    }
}
