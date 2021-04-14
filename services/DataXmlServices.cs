using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace doviz_xml.services
{
    public class DataXmlServices
    {
        string serviceUrl = "https://www.tcmb.gov.tr/kurlar/today.xml";

        public XDocument getAllDocument() 
        {
            return XDocument.Load(serviceUrl);
        }


        public List<object> convertToList(XDocument doc)
        {
            XElement root = doc.Root;
            List<object> listData = new List<object>();
            
            foreach (var item in root.Elements())
            {
                DataModel data = new DataModel();
                data.currencyName = item.Element("Isim").Value;
                data.forexBuying = item.Element("ForexBuying").Value;
                data.forexSelling = item.Element("ForexSelling").Value;
                data.currencyCode = item.Attribute("CurrencyCode").Value;
                data.banknoteBuying = item.Element("BanknoteBuying").Value;
                data.banknoteSelling = item.Element("BanknoteSelling").Value;
                listData.Add(data);
            }
            return listData;
            
        }

        public void listWriteTextFile(List<object> list)
        {
            string dataFilePath = "dataFile.txt";

            FileStream fileStream = new FileStream(dataFilePath, FileMode.OpenOrCreate, FileAccess.Write);

            StreamWriter streamReader = new StreamWriter(fileStream, Encoding.UTF8);

            foreach (DataModel item in list)
            {
                streamReader.Write(item.currencyCode + "-");
                streamReader.Write(item.currencyName + "-");
                streamReader.Write(item.forexBuying + "-");
                streamReader.Write(item.forexSelling + "-");
                streamReader.Write(item.banknoteBuying + "-");
                streamReader.WriteLine(item.banknoteSelling);
            }
            streamReader.Close();
            fileStream.Close();


        }




    }
}
