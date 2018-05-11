using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfChat.ChatApp
{
    public class ContactController
    {
        private Chat _Chat;

        public ContactController(Chat pChat)
        {
            _Chat = pChat;

            List<Contact> contacts = new List<Contact>();
            ContactInfoData data = new ContactInfoData();
            data._NickName = "Ahoj";
            contacts.Add(new Contact(data));
            data._NickName = "Ahoj2";
            contacts.Add(new Contact(data));
            data._NickName = "Ahoj3";
            contacts.Add(new Contact(data));
            data._NickName = "Ahoj4";
            contacts.Add(new Contact(data));
            data._NickName = "Ahoj5";
            contacts.Add(new Contact(data));

            _Chat.User.AddContacts(contacts);
        }

        public void SearchContact(string pNickName)
        {

        }

        public void ChooseContact()
        {

        }

        public void AddContact(Contact pContact)
        {

        }

        public void DeleteContact(Contact pContact)
        {

        }

        public void BlockContact(Contact pContact)
        {

        }

        public void ReportContact(Contact pContact)
        {

        }

        public List<Contact> GetContacts()
        {
            return _Chat.User.GetContactList();
        }
    }
}
