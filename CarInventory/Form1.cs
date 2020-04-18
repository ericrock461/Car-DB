using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
/// <summary>
/// Erich Rock
/// Mr. T
/// Reading and writing objects XML test
/// April 17, 2020
/// </summary>

namespace CarInventory
{
   
    public partial class Form1 : Form
    {
        List<Car> Inventory = new List<Car>();

        //Open the XML file and place it in writer 
        

        public Form1()
        {
            InitializeComponent();


            string newYear, newMake, newColour, newMileage;

            //Open the XML file and place it in reader 
            XmlReader reader = XmlReader.Create("Resources/studentInfo.xml");

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Text)
                {
                    newYear = reader.ReadString();

                    reader.ReadToNextSibling("Make");
                    newMake = reader.ReadString();

                    reader.ReadToNextSibling("Colour");
                    newColour = reader.ReadString();

                    reader.ReadToNextSibling("Mileage");
                    newMileage = reader.ReadString();
                    

                    Car c = new Car(newYear, newMake, newColour, newMileage);
                    Inventory.Add(c);

                    reader.Close();
                }

            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            XmlWriter writer = XmlWriter.Create("Resources/XMLFile1.xml");

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

            //Write the XML to file and close the writer 
            writer.Close();

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
            ///note: I had previously the "XMLwriter.create" as public, but decided
            ///that might be bad, since the XML reader would then be created within the writer(?)
            ///When things were like that, I was getting an error on line 79 saying something
            ///that I can't start with the endRoot? Not sure
            ///Anyway, I'm very close with this...I hope, but something isn't right.
            ///I don't think anything is actually being written to the XML file.

            
            /*Write the XML to file and close the writer 
            writer.Close();*/

            this.Close();
        }
    }
}
