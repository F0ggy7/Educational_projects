using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1
{
    public class  Client
    {
        public int IDClient { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PASS { get; set; }
        public string DateOfBirth { get; set; }

        public Client() { }

        public Client(int IDClient, string FirstName, string LastName, string PASS, string DateOfBirth)
        {
            this.IDClient = IDClient;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.PASS = PASS;
            this.DateOfBirth = DateOfBirth;
        }
    }

    

    public class CurdsNum
    {
        public int IDCard { get; set; }
        public string CardsNum { get; set; }

        public CurdsNum() { }

        public CurdsNum(int IDCard, string CardsNum)
        {
            this.IDCard = IDCard;
            this.CardsNum = CardsNum;
        }
    }


    public class Operation
    {
        public string DataOperation { get; set; }
        public string TypeOperation { get; set; }
        public string Sum { get; set; }

        public Operation() { }

        public Operation(string DataOperation, string TypeOperation, string Sum)
        {
            this.DataOperation = DataOperation;
            this.TypeOperation = TypeOperation;
            this.Sum = Sum;
        }
    }

    public class Allinf
    {
        public string IDClient { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PASS { get; set; }
        public string DataOfBirth { get; set; }
        public string CardNum { get; set; }
        public string DataOperation { get; set; }
        public string TypeOperation { get; set; }
        public string Sum { get; set; }

        public Allinf() { }

        public Allinf(string IDClient, string FirstName, string LastName, string PASS, string DataOfBirth, string CardNum, string DataOperation, string TypeOperation, string Sum)
        {
            this.IDClient = IDClient;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.PASS = PASS;
            this.DataOfBirth = DataOfBirth;
            this.CardNum = CardNum;
            this.DataOperation = DataOperation;
            this.TypeOperation = TypeOperation;
            this.Sum = Sum;
        }
    }
    public class InfXml
    {
        public string number { get; set; }
        public string name { get; set; }
        public string type { get; set; }

        public InfXml() { }

        public InfXml(string number, string name, string type)
        {
            this.number = number;
            this.name = name;
            this.type = type;
        }
    }

    public class FillingTable
    {
        public string number { get; set; }
        public string valuenumber { get; set; }
        public string valuestring { get; set; }
        public string valuedate { get; set; }

        public FillingTable() { }

        public FillingTable( string valuenumber, string valuestring, string valuedate, string number)
        {
            this.number = number;
            this.valuenumber = valuenumber;
            this.valuestring = valuestring;
            this.valuedate = valuedate;
        }
    }
}
