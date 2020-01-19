using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using Contacts.Models;

namespace Contacts.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() 
        {
            XmlDocument XmlDocObj = new XmlDocument();
            XmlDocObj.Load(Server.MapPath("../contacts.xml"));
            XmlNode RootNode = XmlDocObj.SelectSingleNode("contacts");
            XmlNodeList contact = RootNode.ChildNodes; 

            //XmlNode selectedBook = books[0];

            /*foreach (XmlNode book in books)
            {
                if (book["Id"].InnerText == id)
                {
                    selectedBook = book;
                }
            }*/

            return View(contact);

        }
        public ActionResult Add(Contact contact)
        {
            XmlDocument XmlDoc = new XmlDocument();
            XmlDoc.Load(Server.MapPath("../contacts.xml"));
            XmlNode RootNode = XmlDoc.SelectSingleNode("contacts");

            int contactsNumber = RootNode.ChildNodes.Count;
            XmlNode contactNode = RootNode.AppendChild(XmlDoc.CreateNode(XmlNodeType.Element, "contact", ""));

            contactNode.AppendChild(XmlDoc.CreateNode(XmlNodeType.Element, "Id", "")).InnerText = contactsNumber.ToString();
            contactNode.AppendChild(XmlDoc.CreateNode(XmlNodeType.Element, "Name", "")).InnerText = contact.name;
            contactNode.AppendChild(XmlDoc.CreateNode(XmlNodeType.Element, "PhoneNo", "")).InnerText = contact.phoneno;
            contactNode.AppendChild(XmlDoc.CreateNode(XmlNodeType.Element, "Email", "")).InnerText = contact.email;
            contactNode.AppendChild(XmlDoc.CreateNode(XmlNodeType.Element, "HouseNo", "")).InnerText = contact.houseno;

            XmlDoc.Save(Server.MapPath("../contacts.xml"));


            return RedirectToAction("Index");

        }
        public ActionResult Edit(String id) 
        {
            XmlDocument XmlDoc = new XmlDocument();
            XmlDoc.Load(Server.MapPath("../../contacts.xml"));
            XmlNode RootNode = XmlDoc.SelectSingleNode("contacts");
            XmlNodeList contacts = RootNode.ChildNodes;

            XmlNode c = contacts[0];

            foreach (XmlNode cs in contacts) 
            {
                if (cs["Id"].InnerText == id)
                {
                    c = cs;
                }
            }

            return View(c);

        }
        public ActionResult Details(String id) 
        {
            XmlDocument XmlDoc = new XmlDocument();
            XmlDoc.Load(Server.MapPath("../../contacts.xml"));
            XmlNode RootNode = XmlDoc.SelectSingleNode("contacts");
            XmlNodeList contacts = RootNode.ChildNodes;

            XmlNode c = contacts[0];

            foreach (XmlNode cs in contacts)
            {
                if (cs["Id"].InnerText == id)
                {
                    c = cs;
                }
            }

            return View(c);

        }
        public ActionResult Update(Contact c) 
          {
            XmlDocument XmlDocObj = new XmlDocument();
            XmlDocObj.Load(Server.MapPath("../contacts.xml"));
            XmlNode RootNode = XmlDocObj.SelectSingleNode("contacts");
            XmlNodeList contacts = RootNode.ChildNodes;

            XmlNode contact = contacts[0]; 

            foreach (XmlNode item in contacts)
            {
                if (item["Id"].InnerText == c.id.ToString())
                {
                    contact = item;
                }
            }

            contact["Name"].InnerText = c.name;
            contact["PhoneNo"].InnerText = c.phoneno;
            contact["Email"].InnerText = c.email;
            contact["HouseNo"].InnerText = c.houseno;


            XmlDocObj.Save(Server.MapPath("../contacts.xml"));

            return RedirectToAction("Contact");

        }

        public ActionResult Delete(String id)
        {
            XmlDocument XmlDocObj = new XmlDocument();
            XmlDocObj.Load(Server.MapPath("../../contacts.xml"));
            XmlNode RootNode = XmlDocObj.SelectSingleNode("contacts");
            XmlNodeList cs = RootNode.ChildNodes;

            XmlNode c = cs[0]; 

            foreach (XmlNode contact in cs)
            {
                if (contact["Id"].InnerText == id)
                {
                    c = contact;
                }
            }

            RootNode.RemoveChild(c);

            XmlDocObj.Save(Server.MapPath("../../contacts.xml"));

            return RedirectToAction("Contact");
        }
    }
}