using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace GraphicsApp.ShapeDefinitions
{
    /*
     * unfamiliar with xml, offloaded general loading behaviour to utility class, handling reading in and parsing specific elements to shapebuilders
     */
    public class XMLLoader
    {
        private XElement _xmlShape;
        public XElement XmlShape
        {
            get { return _xmlShape; }
            set { _xmlShape = value; }
        }

        private XDocument _xDocument;
        public XDocument XDocument
        {
            get { return _xDocument; }
            set { _xDocument = value; }
        }


        public XMLLoader()
        {

        }

        public void LoadShapeFromXML(string name)
        {
            string path = String.Format("ShapeDefinitions/{0}.xml", name);

            try
            {
                XmlShape = XElement.Load(@path);
                //Debug.WriteLine(XmlShape);
            }
            catch(Exception e)
            {
                Debug.WriteLine(String.Format("No xml definition for {0}", name));
            }


            //XNamespace ns = "http://tempuri.org/Polygon.xsd";
            //XName test = XmlShape.Name.Namespace + "polygonName";
            

            //Debug.WriteLine(XmlShape.Element(ns + "polygonName"));

            //foreach (XElement el in XmlShape.Elements())
            //{
            //    Debug.WriteLine(el);
            //}
        }

        public string GetShapeType()
        {
            string s = null;

            try
            {
                s = XmlShape.FirstAttribute.Name.LocalName;
                Debug.WriteLine(s);
            }
            catch (Exception e)
            {
                Debug.WriteLine(String.Format("Invalid name for loading shape"));
            }

            return s;
        }

    }
}
