using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode
{
    class Uroven
    {
        private const int MaxSymbol = 10;
        private PasportTextbox _passportTextbox;

        public MessageBox MessageBox;
        public CellRow textResult;

        private void checkButton_Click(object sender, EventArgs e)
        {
            string text = _passportTextbox.Text;

            if (text.Trim() == "")
            {
                int number = (int)MessageBox.Show("Введите серию и номер паспорта");
            }
            else
            {
                string rawData = FormatText(text);

                if (rawData.Length < MaxSymbol)
                {
                    textResult.Text = "Неверный формат серии или номера паспорта";
                }
                else
                {
                    PushInDataBase();
                }
            }
        }

        private void PushInDataBase()
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            object resultHash = (object)Form1.ComputeSha256Hash(rawData);

            string commandText = string.Format("select * from passports where num='{0}' limit 1;", resultHash);
            string connectionString = string.Format("Data Source=" + path + "\\db.sqlite");

            try
            {
                string providedText = "По паспорту «" + this._passportTextbox.Text +
                    "» доступ к бюллетеню на дистанционном электронном голосовании ПРЕДОСТАВЛЕН";
                string notProvidedText = "По паспорту «" + this._passportTextbox.Text +
                            "» доступ к бюллетеню на дистанционном электронном голосовании НЕ ПРЕДОСТАВЛЯЛСЯ";
                string notFoundText = "Паспорт «" + this._passportTextbox.Text +
                        "» в списке участников дистанционного голосования НЕ НАЙДЕН";

                SQLiteConnection connection = new SQLiteConnection(connectionString);

                connection.Open();

                SQLiteDataAdapter sqLiteDataAdapter = new SQLiteDataAdapter(new SQLiteCommand(commandText, connection));

                DataTable Table = new DataTable();
                DataRowCollection rows = Table.Rows;
                DataTable rowsTable = new DataTable();

                sqLiteDataAdapter.Fill(Table);

                if (rows.Count > 0)
                {
                    PassVerification(rowsTable, providedText, notProvidedText);
                }
                else
                {
                    textResult.Text = notFoundText;
                }

                connection.Close();
            }
            catch (SQLiteException erorException)
            {
                if (erorException.ErrorCode != 1)
                    return;

                int number = (int)MessageBox.Show("Файл db.sqlite не найден. Положите файл в папку вместе с exe.");
            }
        }

        private void PassVerification(DataTable rowsTable, string providedText, string notProvidedText)
        {
            if (Convert.ToBoolean(rowsTable[0].ItemArray[1]))
                textResult.Text = providedText;
            else
                textResult.Text = notProvidedText;
        }

        private string FormatText(string text)
        {
            return text.Trim().Replace(" ", string.Empty);
        }
    }

    class MessageBox
    {
        public int Show(string text)
        {
            throw new NotImplementedException();
        }
    }

    class CellRow
    {
        public string Text;
    }

    class PasportTextbox
    {
        public string Text;
    }
}

