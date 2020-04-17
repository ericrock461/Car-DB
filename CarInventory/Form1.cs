using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace CarInventory
{
   
    public partial class Form1 : Form
    {
        List<Car> Inventory = new List<Car>();

        //Open the XML file and place it in writer 
        XmlWriter writer = XmlWriter.Create("Resources/XMLFile1.xml");

        public Form1()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string year, make, colour, mileage;

            year = yearInput.Text;
            make = makeInput.Text;
            colour = colourInput.Text;
            mileage = mileageInput.Text;


            Car car = new Car(year, make, colour, mileage);

            Inventory.Add(car);


            //Write the root element 
            writer.WriteStartElement("Inventory");

            foreach (Car c in Inventory)
            {
                //Start an element 
                writer.WriteStartElement("Car");

                //Write sub-elements 
                writer.WriteElementString("year", c.year);
                writer.WriteElementString("make", c.make);
                writer.WriteElementString("colour", c.colour);
                writer.WriteElementString("mileage", c.mileage);

                // end the element 
                writer.WriteEndElement();
            }

            // end the root element
            writer.WriteEndElement();

            outputLabel.Text = "";

            foreach(Car c in Inventory)
            {
                outputLabel.Text += c.year + " "
                    + c.make + " "
                    + c.colour + " "
                    + c.mileage + "\n";
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            //Write the XML to file and close the writer 
            writer.Close();

            this.Close();
        }
    }
}
