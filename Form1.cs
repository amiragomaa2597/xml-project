using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace XML_Project
{
    public partial class Form1 : Form
    {
        public XmlDocument document;
        public XmlNode Employee;
        public XmlNode empName;
        public XmlNode St_Address;
        public XmlNode Street;
        public XmlNode Region;
        public XmlNode City;
        public XmlNode Country;
        public XmlNode CellPhoneNumber ;
        public XmlNode E_mail;
        public int index=0;
        public Form1()
        {
            InitializeComponent();
            document = new XmlDocument();
            document.Load("Untitled1.xml");
            SetEmployee();
        }
        private void SetEmployee()
        {
            Employee = document.GetElementsByTagName("Employee")[index];
            empName = Employee.SelectSingleNode("./Name");
            St_Address = Employee.SelectSingleNode("./Addresses/Address");
            Street = St_Address.SelectSingleNode("./Street");
            Region = St_Address.SelectSingleNode("./Region");
            City = St_Address.SelectSingleNode("./City");
            Country = St_Address.SelectSingleNode("./Country");
            E_mail = Employee.SelectSingleNode("E_mail");
            CellPhoneNumber = Employee.SelectSingleNode("./Phones/Phone");
            textBox1.Text = empName.InnerText;
            textBox3.Text = CellPhoneNumber.InnerText;
            textBox5.Text= Street.InnerText;
            textBox7.Text = Region.InnerText;
            textBox6.Text = City.InnerText;
            textBox8.Text = Country.InnerText;
            textBox4.Text = E_mail.InnerText;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (index >= 1)
            {
                index -= 1;
                SetEmployee();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (index < document.GetElementsByTagName("Employee").Count - 1) {
                index += 1;
                SetEmployee();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            XmlNodeList Employees = document.GetElementsByTagName("Employee");
            int count = 0;
            foreach (XmlNode Employee in Employees)
            {
                
                if (Employee.SelectSingleNode("E_mail").InnerText == textBox4.Text)
                {
                    index = count;
                    SetEmployee();
                }
                else { count++; }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            XmlElement root = document.DocumentElement;
            // creating elements
            XmlElement employee = document.CreateElement("Employee");

            XmlElement name = document.CreateElement("Name");
            name.InnerText = textBox1.Text;

            XmlElement phones = document.CreateElement("Phones");
            XmlElement phone = document.CreateElement("Phone");
            phone.InnerText = textBox3.Text;
            XmlElement addresses = document.CreateElement("Addresses");
            XmlElement address = document.CreateElement("Address");
            XmlElement street = document.CreateElement("Street");
            XmlElement region = document.CreateElement("Region");
            XmlElement city = document.CreateElement("City");
            XmlElement country = document.CreateElement("Country");
            street.InnerText = textBox5.Text;
            region.InnerText = textBox7.Text;
            city.InnerText = textBox6.Text;
            country.InnerText = textBox8.Text ;

            XmlElement email = document.CreateElement("E_mail");
            email.InnerText = textBox4.Text;

            root.AppendChild(employee);
            employee.AppendChild(name);
            employee.AppendChild(phones);
            phones.AppendChild(phone);
            employee.AppendChild(addresses);
            addresses.AppendChild(address);
            address.AppendChild(street);
            address.AppendChild(region);
            address.AppendChild(city);
            address.AppendChild(country);
            employee.AppendChild(email);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            empName.InnerText = textBox1.Text;
            CellPhoneNumber.InnerText = textBox3.Text ;
            Street.InnerText = textBox5.Text;
            Region.InnerText = textBox7.Text;
            City.InnerText = textBox6.Text ;
            Country.InnerText = textBox8.Text ;
            E_mail.InnerText = textBox4.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            XmlNodeList Employees = document.GetElementsByTagName("Employee");
            int count = 0;
            foreach (XmlNode Employee in Employees)
            {

                if (Employee.SelectSingleNode("E_mail").InnerText == textBox4.Text)
                {
                    XmlNode parent = Employee.ParentNode;
                    parent.RemoveChild(Employee);
                    if (count != 0) index = count-1;
                    SetEmployee();
                    break;
                }
                else { count++; }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            document.Save("Untitled1.xml");
        }
    }

}


