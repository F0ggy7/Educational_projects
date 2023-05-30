using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace test1
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            LoadTable();
        }

        private void ButtonGrid_Click(object sender, EventArgs e)       
        {
                string script = ScriptTB.Text;
                DataBaseConnect DBconnect = new DataBaseConnect();
                DBconnect.OpenCon();
                MySqlDataAdapter ms_data = new MySqlDataAdapter(script, DBconnect.GetConnection());
                DataTable table = new DataTable();
                ms_data.Fill(table);
                dataGridView.DataSource = table;
                DBconnect.CloseCon();
        }

        //Трушная кнопка, как я задолбался это пилить Не правильно лол 

        List<Client> client = new List<Client>();
        List<CurdsNum> Curdnum = new List<CurdsNum>();
        List<Operation> operation = new List<Operation>();

        private void button1_Click(object sender, EventArgs e)
        {
            //Запрос и чтение клиентов из Бд
            DataBaseConnect DBconnect = new DataBaseConnect();
            DBconnect.OpenCon();
            MySqlCommand command = new MySqlCommand("select ID_Customer, FirstName, LastName, PASS, DATE_FORMAT(Data_of_Birth , '%d-%m-%Y') as Data_of_Birth  from customers" , DBconnect.GetConnection());
            MySqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    client.Add(new Client(Convert.ToInt32(reader[0]), Convert.ToString(reader[1]), Convert.ToString(reader[2]), Convert.ToString(reader[3]), Convert.ToString(reader[4])));
                }
            }
            DBconnect.CloseCon();

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(@"C:\Users\xxlen\Desktop\praktika\UsersTest.xml");
            XmlElement Users = xmlDocument.DocumentElement;

            for (int i = 0; i < client.Count; i++)
                
            {
                XmlElement userElem = xmlDocument.CreateElement("User");
                XmlAttribute UserAttr = xmlDocument.CreateAttribute("ID");
                XmlElement FirstNameElem = xmlDocument.CreateElement("FirstName");
                XmlElement LastNameElem = xmlDocument.CreateElement("LastName");
                XmlElement PASSElem = xmlDocument.CreateElement("Passport");
                XmlElement DataOfBirthElem = xmlDocument.CreateElement("DataOfBirth");
                XmlElement CardListElem = xmlDocument.CreateElement("CardList");

                XmlText IDText = xmlDocument.CreateTextNode(Convert.ToString(client[i].IDClient));
                XmlText FirstNameText = xmlDocument.CreateTextNode(client[i].FirstName);
                XmlText LastNameText = xmlDocument.CreateTextNode(client[i].LastName);
                XmlText PASSText = xmlDocument.CreateTextNode(client[i].PASS);
                XmlText DataOfBirthText = xmlDocument.CreateTextNode(client[i].DateOfBirth);
                XmlText CardListText = xmlDocument.CreateTextNode("");

                UserAttr.AppendChild(IDText);
                FirstNameElem.AppendChild(FirstNameText);
                LastNameElem.AppendChild(LastNameText);
                PASSElem.AppendChild(PASSText);
                DataOfBirthElem.AppendChild(DataOfBirthText);
                CardListElem.AppendChild(CardListText);

                userElem.Attributes.Append(UserAttr);
                userElem.AppendChild(FirstNameElem);
                userElem.AppendChild(LastNameElem);
                userElem.AppendChild(PASSElem);
                userElem.AppendChild(DataOfBirthElem);
                userElem.AppendChild(CardListElem);

                //Запрос и чтение Номеров Карта Бд клиентов из Бд
                DBconnect.OpenCon();
                MySqlCommand commandCards = new MySqlCommand("select ID_Card, CardNum from Client_cards where ID_Client ='" + client[i].IDClient + "'", DBconnect.GetConnection());
                MySqlDataReader readerCards = commandCards.ExecuteReader();

                Curdnum.Clear();

                if (readerCards.HasRows)
                {
                    while (readerCards.Read())
                    {
                        Curdnum.Add(new CurdsNum(Convert.ToInt32(readerCards[0]), Convert.ToString(readerCards[1])));
                    }
                }
                DBconnect.CloseCon();

                for (int k = 0; k < Curdnum.Count; k++)
                {
                    XmlElement CardElem = xmlDocument.CreateElement("Card");
                    XmlAttribute IDCardAttr = xmlDocument.CreateAttribute("IDCard");
                    XmlElement CardNumElem = xmlDocument.CreateElement("CardNum");
                    XmlElement OeprationListElem = xmlDocument.CreateElement("OperationList");

                    XmlText IDCardText = xmlDocument.CreateTextNode(Convert.ToString(Curdnum[k].IDCard));
                    XmlText CardNumText = xmlDocument.CreateTextNode(Curdnum[k].CardsNum);
                    XmlText OeprationListText = xmlDocument.CreateTextNode("");

                    IDCardAttr.AppendChild(IDCardText);
                    CardNumElem.AppendChild(CardNumText);
                    OeprationListElem.AppendChild(OeprationListText);

                    CardListElem.AppendChild(CardElem);
                    CardElem.Attributes.Append(IDCardAttr);
                    CardListElem.AppendChild(CardNumElem);
                    CardListElem.AppendChild(OeprationListElem);

                    // Запрос и чтение Операций клиентов по карте
                    DBconnect.OpenCon();
                    MySqlCommand commandOperations = new MySqlCommand("select Operations.Data_Operation, OperationID.Type_Operation, Operations.Summ from Operations, OperationID where ID_Card = '" + Curdnum[k].IDCard + "' and Operations.Operation_ID = OperationID.Operation_ID ", DBconnect.GetConnection());
                    MySqlDataReader readerOperations = commandOperations.ExecuteReader();

                    //MessageBox.Show(Convert.ToString(operation.Count));

                    operation.Clear();

                    if (readerOperations.HasRows)
                    {
                        while (readerOperations.Read())
                        {
                            operation.Add(new Operation(Convert.ToString(readerOperations[0]), Convert.ToString(readerOperations[1]), Convert.ToString(readerOperations[2])));
                        }
                    }

                    //MessageBox.Show(Convert.ToString(operation.Count));

                    DBconnect.CloseCon();

                    for (int u = 0; u < operation.Count; u++)
                    {
                        XmlElement OeprationElem = xmlDocument.CreateElement("Operation");
                        XmlElement DaraOperationElem = xmlDocument.CreateElement("DataOperation");
                        XmlElement TypeOperationElem = xmlDocument.CreateElement("TypeOperation");
                        XmlElement SumElem = xmlDocument.CreateElement("Sum");

                        XmlText OeprationText = xmlDocument.CreateTextNode("");
                        XmlText DaraOperationText = xmlDocument.CreateTextNode(operation[u].DataOperation);
                        XmlText TypeOperationText = xmlDocument.CreateTextNode(operation[u].TypeOperation);
                        XmlText SumText = xmlDocument.CreateTextNode(operation[u].Sum);

                        OeprationElem.AppendChild(OeprationText);
                        DaraOperationElem.AppendChild(DaraOperationText);
                        TypeOperationElem.AppendChild(TypeOperationText);
                        SumElem.AppendChild(SumText);

                        OeprationListElem.AppendChild(OeprationElem);
                        OeprationElem.AppendChild(DaraOperationElem);
                        OeprationElem.AppendChild(TypeOperationElem);
                        OeprationElem.AppendChild(SumElem);
                        
                        Users.AppendChild(userElem);//?
                    }
                }
                Users.AppendChild(userElem);
            }
            xmlDocument.Save(@"C:\Users\xxlen\Desktop\praktika\Users1.xml");
            MessageBox.Show("Данные успешно загружены в xml файл");
            Process.Start(@"C:\Users\xxlen\Desktop\praktika\Users1.xml");
        }

        //Очистка поля ТекстБокса при клике
        private void ScriptTB_Enter(object sender, EventArgs e)
        {
            if (ScriptTB.Text == "Введите Sql запрос")
            {
                ScriptTB.Text = "";
            }
        }

        //Ввод при пустом 
        private void ScriptTB_Leave(object sender, EventArgs e)
        {
            if (ScriptTB.Text == "")
            {
                ScriptTB.Text = "Введите Sql запрос";
            }
        }

        //Список таблиц
        public class Tables
        {
            public string NameTable { get; set; }

            public Tables() { }

            public Tables( string NameTable)
            {
                this.NameTable = NameTable;
            }
        }
        List<Tables> nametable = new List<Tables>();

        private void LoadTable()
        {
            TableslistView.Clear();
            nametable.Clear();

            DataBaseConnect DBconnect = new DataBaseConnect();
            DBconnect.OpenCon();
            MySqlCommand command = new MySqlCommand("SHOW TABLES", DBconnect.GetConnection());
            MySqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    nametable.Add(new Tables(Convert.ToString(reader[0])));
                }
            }

            for (int i = 0; i < nametable.Count; i++)
            {
                ListViewItem LVI = new ListViewItem(nametable[i].NameTable);
                LVI.Tag = nametable;
                TableslistView.Items.Add(LVI);
            }
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void TableslistView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TableslistView.SelectedItems.Count == 0)
            {
                return;
            }
            DataBaseConnect DBconnect = new DataBaseConnect();
            DBconnect.OpenCon();
            MySqlDataAdapter ms_data = new MySqlDataAdapter(" select * from " + TableslistView.SelectedItems[0].Text, DBconnect.GetConnection());

            DataTable table = new DataTable();
            ms_data.Fill(table);
            dataGridView.DataSource = table;

            DBconnect.CloseCon();
        }

        //Закрытие программы при закрытии окна
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        //Отключение кнопки при стандартном значение ТекстБокса
        private void ScriptTB_TextChanged(object sender, EventArgs e)
        {
            if (ScriptTB.Text != "Введите Sql запрос")
            {
                ButtonGrid.Enabled = true;
            }
            else
            {
                ButtonGrid.Enabled = false;
            }
        }

        //Обновление списка Таблиц БД
        private void Refresh_Click(object sender, EventArgs e)
        {
            LoadTable();
        }

        List<Allinf> AllInfo = new List<Allinf>();

        string atrrib;
        string FName;
        string LName;
        string Pas;
        string DoB;
        string CN;

        //Чтение XML файла. Вроде правильное...
        private void ReadBT_Click(object sender, EventArgs e)
        {

            XmlDocument xml = new XmlDocument();
            xml.Load(@"C:\Users\xxlen\Desktop\praktika\Users1.xml");
            XmlElement element = xml.DocumentElement;

            foreach (XmlNode xnode in element)
            {
                if (xnode.Attributes.Count > 0)
                {
                    XmlNode attr = xnode.Attributes.GetNamedItem("ID");
                    if (attr != null)
                    {
                        Console.WriteLine(attr.Value);
                        atrrib = attr.InnerText;
                    }
                }
                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    if (childnode.Name == "FirstName")
                    {
                        Console.WriteLine(childnode.InnerText);
                        FName = childnode.InnerText;
                    }
                    if (childnode.Name == "LastName")
                    {
                        Console.WriteLine(childnode.InnerText);
                        LName = childnode.InnerText;
                    }
                    if (childnode.Name == "Passport")
                    {
                        Console.WriteLine(childnode.InnerText);
                        Pas = childnode.InnerText;
                    }
                    if (childnode.Name == "DataOfBirth")
                    {
                        Console.WriteLine(childnode.InnerText);
                        DoB = childnode.InnerText;
                    }

                    if (childnode.Name == "CardList")
                    {
                        foreach (XmlNode childnodeCardList in childnode.ChildNodes)
                        {
                            if (childnodeCardList.Name == "CardNum")
                            {
                                Console.WriteLine(childnodeCardList.InnerText);
                                CN = childnodeCardList.InnerText;
                            }
                            if (childnodeCardList.Name == "OperationList")
                            {
                                foreach (XmlNode childnodeOperations in childnodeCardList.ChildNodes)
                                {
                                    Allinf allinfo = new Allinf();
                                    allinfo.IDClient = atrrib;
                                    allinfo.FirstName = FName;
                                    allinfo.LastName = LName;
                                    allinfo.PASS = Pas;
                                    allinfo.DataOfBirth = DoB;
                                    allinfo.CardNum = CN;
                                    if (childnodeOperations.Name == "Operation")
                                    {
                                        foreach (XmlNode childnodeOperation in childnodeOperations.ChildNodes)
                                        {
                                            if (childnodeOperation.Name == "DataOperation")
                                            {
                                                Console.WriteLine(childnodeOperation.InnerText);
                                                allinfo.DataOperation = childnodeOperation.InnerText;
                                            }

                                            if (childnodeOperation.Name == "TypeOperation")
                                            {
                                                Console.WriteLine(childnodeOperation.InnerText);
                                                allinfo.TypeOperation = childnodeOperation.InnerText;
                                            }

                                            if (childnodeOperation.Name == "Sum")
                                            {
                                                Console.WriteLine(childnodeOperation.InnerText);
                                                allinfo.Sum = childnodeOperation.InnerText;
                                            } 
                                        }
                                        AllInfo.Add(allinfo);
                                        AllInfo = AllInfo.OrderBy(i => i.DataOperation).ToList();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            MessageBox.Show(Convert.ToString(AllInfo.Count));
            dataGridView.DataSource = AllInfo;
        }

        // Чтение типо универсальной структуры в  xml файле  

        List<InfXml> InformationsTable = new List<InfXml>();
        List<FillingTable> Fillingtable = new List<FillingTable>();

        int valuenumber;
        string valuestring;
        string valuedate;


        private void ReadUni_Click(object sender, EventArgs e)
        {
            string Table;
            XmlDocument xml = new XmlDocument();
            xml.Load(@"C:\Users\xxlen\Desktop\praktika\example.xml");
            XmlElement element = xml.DocumentElement;
            foreach (XmlNode xnode in element)
            {
                if (element.FirstChild.Name == "tablename")
                {
                  Table = element.FirstChild.InnerText;

                    foreach (XmlNode childnodeTypefields in xnode.ChildNodes)
                    {
                        InfXml inform = new InfXml();

                        FillingTable fillingtable = new FillingTable();
                        foreach (XmlNode childnodeTypefield in childnodeTypefields)
                        {
                            if (childnodeTypefield.Name == "number")
                            {
                                Console.WriteLine(childnodeTypefield.InnerText);
                                inform.number = childnodeTypefield.InnerText;
                            }
                            if (childnodeTypefield.Name == "name")
                            {
                                Console.WriteLine(childnodeTypefield.InnerText);
                                inform.name = childnodeTypefield.InnerText;
                            }
                            if (childnodeTypefield.Name == "type")
                            {
                                Console.WriteLine(childnodeTypefield.InnerText);
                                 inform.type = childnodeTypefield.InnerText;
                            }

                            if (childnodeTypefield.Name == "cell")
                            {
                                foreach (XmlNode childnodeCell in childnodeTypefield)
                                {
                                    if (childnodeCell.Name == "valuenumber" && childnodeCell.InnerText != "")
                                    {
                                        valuenumber = Convert.ToInt32(childnodeCell.InnerText);
                                    }
                                    if (childnodeCell.Name == "valuestring" && childnodeCell.InnerText != "")
                                    {
                                        valuestring = childnodeCell.InnerText;

                                    }
                                    if (childnodeCell.Name == "valuedate" && childnodeCell.InnerText != "")
                                    {
                                        valuedate = childnodeCell.InnerText;

                                    }
                                }

                                DataBaseConnect DBconnect = new DataBaseConnect();
                                DBconnect.OpenCon();
                                MySqlCommand command = new MySqlCommand("insert into CARDS (ID, DATEOPEN, PAN) VALUE('" + valuenumber +"', '" +valuedate+"' , '" +valuestring +"')", DBconnect.GetConnection());
                                    
                            }
                        }

                        Fillingtable.Add(fillingtable);
                        InformationsTable.Add(inform);
                    }
                }
            } 

            dataGridView.DataSource = InformationsTable;
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
