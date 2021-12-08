using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace GraphicsApp.ShapeDefinitions
{
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

            XmlShape = XElement.Load(@path);
            Debug.WriteLine(XmlShape);

            //XNamespace ns = "http://tempuri.org/Polygon.xsd";
            //XName test = XmlShape.Name.Namespace + "polygonName";
            

            //Debug.WriteLine(XmlShape.Element(ns + "polygonName"));

            //foreach (XElement el in XmlShape.Elements())
            //{
            //    Debug.WriteLine(el);
            //}
        }

    }
}
