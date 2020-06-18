using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace MESHNETWORK.Classes
{
    /// <summary>
    /// Класс для взаимодействия с сервером
    /// </summary>
    class ServerS
    {  
        Socket Socket { get; set; }
        
        DispatcherTimer timer { get; set; }

        Thread thread { get; set; }

        /// <summary>
        /// Список с ответами сервера
        /// </summary>
        List<string> Buffer { get; set; }

        public ServerS() 
        {
            Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Buffer = new List<string>();
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0,0,15);
            timer.Tick += Timer_Tick;
        }

        /// <summary>
        /// Таймер для пингов на сервер
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Timer_Tick(object sender, EventArgs e)
        {
            await Dispatcher.CurrentDispatcher.BeginInvoke((Action)(() => 
            {
                SendRequest("ping");
            })
                );
        }

        #region Получение данных с сервера
        public List<Net> ListNets()
        {
            string request = "list-nets";
            SendRequest(request);
            List<Net> Nets = new List<Net>();
            for (int i = 1; i < Buffer.Count - 1; i++)
            {
                string[] NetInfo = Buffer[i].Split(' ');
                Net net = new Net(NetInfo[1], int.Parse(NetInfo[2]), NetInfo[3], NetInfo[4]);
                Nets.Add(net);
            }
            return Nets;
        }

        public List<string> ListUsers()
        {
            string request = "list-users";
            SendRequest(request);
            List<string> Users = new List<string>();
            for (int i = 1; i < Buffer.Count - 1; i++)
            {
                string[] UserInfo = Buffer[i].Split(' ');
                string NameUser = "NULL";
                if (UserInfo.Length == 2)
                {
                    NameUser = UserInfo[1];
                }
                Users.Add(NameUser);
            }
            return Users;
        }

        public List<string> ListShares(Net Net)
        {
            string Request = $"list-shares {Net.name}";
            SendRequest(Request);
            List<string> ShareList = new List<string>();
            for (int i = 1; i < Buffer.Count - 1; i++)
            {
                string[] ShareInfo = Buffer[i].Split(' ');
                string Share = $"{ShareInfo[2]} ({ShareInfo[3]})";
                ShareList.Add(Share);
            }

            return ShareList;
        }

        public List<KnotSave> ListNodes(Net Net)
        {
            string Request = "list-nodes " + Net.name;
            SendRequest(Request);
            List<KnotSave> Nodes = new List<KnotSave>();
            if (!Buffer.Last().StartsWith("list-node-fail"))
            {
                for (int i = 1; i < Buffer.Count - 1; i++)
                {
                    string[] NodeInfo = Buffer[i].Split(' ');
                    KnotSave Node = new KnotSave(
                        uint.Parse(NodeInfo[1]), NodeInfo[5], double.Parse(NodeInfo[2]),
                        double.Parse(NodeInfo[3]), double.Parse(NodeInfo[4])
                        );
                    Nodes.Add(Node);
                }
            }
            return Nodes;

        }
        #endregion

        #region Получение ответов с сервера (True/False)
        public bool Authorization(string Login, string Password)
        {
            if (!Socket.Connected)
            {
                Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                Socket.Connect("nodejs.ddns.net", 7510);
            }

            string request = $"auth {Login} {Password}";

            SendRequest(request);

            if (Buffer.Last().StartsWith("auth-ok"))
            {
                timer.Start();
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool AddNet(Net Net)
        {
            string Request = "create-net " + Net.name;
            SendRequest(Request);
            if (Buffer.Last().StartsWith("create-net-ok"))
            {
                if (AddNodes(Net))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool RemoveNet(Net Net)
        {
            string Request = "remove-net " + Net.name;
            SendRequest(Request);
            if (Buffer.Last().StartsWith("remove-net-ok"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool AddNodes(Net Net)
        {
            foreach (KnotSave knot in Net.knotSaves)
            {
                string Request = $"add-node {Net.name} {knot.CordX} {knot.CordY} {knot.Radius} {knot.Name}";
                SendRequest(Request);
            }


            if (!Buffer.Contains("add-node-fail"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ShareNet(Net Net, string UserName, string Access)
        {
            string Request = $"share {Net.name} {UserName} {Access}";
            SendRequest(Request);
            if (Buffer.Last().StartsWith("share-ok"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Revoke(Net Net, string UserName)
        {
            string Request = $"revoke {Net.name} {UserName}";
            SendRequest(Request);

            if (Buffer.Last().StartsWith("revoke-ok"))
            {
                return true;
            }
            else
            {
                return false;
            }
        } 
        #endregion

        /// <summary>
        /// Отправка запроса на сервер
        /// </summary>
        /// <param name="Request"></param>
        private void SendRequest(string Request) 
        {
            Request = Request + Environment.NewLine;
            Console.WriteLine("send: " +Request);
            byte[] authB = Encoding.ASCII.GetBytes(Request);
            Socket.Send(authB);
            Buffer.Clear();
            GetAnswers();
        }

        /// <summary>
        /// Получение ответа с сервера
        /// </summary>
        private void GetAnswers()
        {
            Thread.Sleep(100);
            try 
            {
                byte[] answer = new byte[512];
                do
                {
                    int bytes = Socket.Receive(answer, answer.Length, 0);
                    string command = Encoding.ASCII.GetString(answer, 0, bytes);
                    Console.WriteLine("receive: " + command);

                    int endcommand;
                    while(true)
                    {
                        endcommand = command.IndexOf(Environment.NewLine);
                        if (endcommand < 0) break;
                        Buffer.Add(command.Substring(0, endcommand));
                        Console.WriteLine("Buffer: " + Buffer.Last());

                        command = command.Substring(endcommand + 2);
                    } 
                
                }
                while (Socket.Available > 0);
            }
            catch 
            {
                MessageBox.Show("Что-то пошло не так, перезайдите на сервер");
            }
        }

        /// <summary>
        /// Закрывает соединение
        /// </summary>
        public void CloseConnection() 
        {
            timer.Stop();
            Socket.Close();
        }

    }
}
