using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfChat.ChatApp;
using Newtonsoft.Json;

namespace WpfChat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<User_Controls.UsersContact> contacts = new List<User_Controls.UsersContact>();
        private List<UserControls.OutcomingMessage> messages = new List<UserControls.OutcomingMessage>();

        private Chat chat;

        public MainWindow()
        {
            InitializeComponent();

            chat = new Chat();
            chat.OnUserLogin += OnUserLogin;

            RefreshData();

            //JSONExample();
        }

        private void RefreshData()
        {
            UsersContacts.Children.Clear();
            contacts.Clear();

            List<Contact> contactList = chat.GetContacts();

            for (int i = 0; i < contactList.Count; i++)
            {
                User_Controls.UsersContact control = new WpfChat.User_Controls.UsersContact();
                control.UpdateContact(contactList[i]);
                UsersContacts.Children.Add(control);
                contacts.Add(control);
                control.OnContactClicked += OnContactClicked;
            }
        }

        private void OnContactClicked(int pID)
        {
            RefreshData(pID);
        }

        private void RefreshData(int pID)
        {
            Messages.Children.Clear();
            messages.Clear();

            List<Message> messageList = chat.GetContactMessages(pID);

            for (int i = 0; i < messageList.Count; i++)
            {
                UserControls.OutcomingMessage control = new WpfChat.UserControls.OutcomingMessage();

                Messages.Children.Add(control);
                messages.Add(control);
            }
        }

        private void OnUserLogin(User pUser)
        {
            
        }

        private void JSONExample()
        {
            UserInfoData data = new UserInfoData()
            {
                _ID = 0,
                _Email = "ahoj",
            };

            //Tento radek prevede UserInfoData na typ string
            string s = JsonConvert.SerializeObject(data);

            Console.WriteLine(s);

            //Tento radek prevede string na typ UserInfoData
            UserInfoData newUserData = JsonConvert.DeserializeObject<UserInfoData>(s);

            Console.WriteLine(newUserData._ID.ToString());
            Console.WriteLine(newUserData._Email.ToString());
        }
    }
}
