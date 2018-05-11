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

            TestContacts();
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

        private void TestContacts()
        {
            List<Contact> contacts = new List<Contact>();
            for (int i = 0; i < 15; i++)
            {
                ContactInfoData data = new ContactInfoData();
                data._NickName = "Ahoj" + i;
                data._ID = i;
                contacts.Add(new Contact(data));
            }

            _Chat.User.AddContacts(contacts);
        }
    }
}
