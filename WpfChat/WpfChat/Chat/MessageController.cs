using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfChat.ChatApp
{
    public class MessageController
    {
        private Chat _Chat;

        public MessageController(Chat pChat)
        {
            _Chat = pChat;
        }

        public void SendMessage(Message pMessage)
        {

        }

        public void ReceiveMessage(Message pMessage)
        {
            
        }

        public void DeleteMessage(Message pMessage)
        {

        }
    }
}
