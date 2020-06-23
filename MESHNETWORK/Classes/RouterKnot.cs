using MESHNETWORK.MyControls;
using MESHNETWORK.Windows;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MESHNETWORK.Classes
{
    public class RouterKnot
    {
        public KnotSave Knot { get; set; } /// Информация об узле
        public Queue<Message> MesIn { get; set; } // Сообщения на обработку
        public Stack<Message> MesOut { get; set; } // Сообщения на передачу
        public ObservableCollection<Message> MesConsole { get; set; } // Сообщения на вывод в консоль
        public List<uint> LastsIdMessage { get; set; } // Список уже полученных сообщений, для их дальнейшего игнорирования

        public CustomConsole Console { get; set; } // Консоль узла

        /// <summary>
        /// Создание Узла-Роутера
        /// </summary>
        /// <param name="Knot"></param>
        public RouterKnot(KnotSave Knot) 
        {
            this.Knot = Knot;
            LastsIdMessage = new List<uint>();
            MesIn = new Queue<Message>();
            MesOut = new Stack<Message>();
            MesConsole = new ObservableCollection<Message>();
        }


        /// <summary>
        /// Узел отравляет сообщения в его радиусе
        /// </summary>
        public void SentMessage()
        {
            //Поиск сообщений в радиусе
            List<RouterKnot> knots = Logic.Router.Knots.FindAll(k =>
                Math.Pow((k.Knot.CordX - Knot.CordX), 2) + Math.Pow((k.Knot.CordY - Knot.CordY), 2) 
                <= Math.Pow(Knot.Radius / 2, 2)
                &&
                k.Knot.id != Knot.id
                );

            //Ретрансляция всем узлам в радиусе
            foreach (RouterKnot knot in knots)
            {
                foreach (Message mess in MesOut)
                {
                    Message ms;

                    if (mess.GetType() == typeof(PingMessage))
                    {
                        ms = new PingMessage(mess as PingMessage);
                        ms.IdLastNode = Knot.id;
                    }
                    else if (mess.GetType() == typeof(SendMessage))
                    {
                        ms = new SendMessage(mess as SendMessage);
                        ms.IdLastNode = Knot.id;
                    }
                    else
                    {
                        ms = new ConsoleMessage(mess as ConsoleMessage);
                        ms.IdLastNode = Knot.id;
                    }

                    Logic.w.AddMessage(Knot, knot.Knot);

                    knot.MesIn.Enqueue(ms);
                }
            }

            //Очистка
            MesOut.Clear();
        }

        /// <summary>
        /// Узел обрабатывает сообщения
        /// </summary>
        public void ProcessIn()
        {
            foreach (Message mess in MesIn)
            {
                // Если сообщение ещё не обрабатывалась этим узлом и его TTL > 0
                if(!LastsIdMessage.Contains(mess.Id) && mess.TTL > 0) 
                {
                    // Обработка сообщения, где проверяется его TTL и дошло ли оно до цели
                    // Если этот Узел-Роутер является целью сообщения, то оно попадает в консоль. 
                    // Но если сообщение Ping, то создаётся новое сообщение PingMessag, только уже
                    // с известным началом и концом пути. Которое отправляется источнику, где уже и выводится
                    ParseMessage(mess); 
                    mess.TTL--;
                    LastsIdMessage.Add(mess.Id);
                    MesOut.Push(mess);
                }     
            }

            MesIn.Clear();
        }

        #region Логика обработки сообщений

        private void ParseMessage(Message message)
        {
            if (message.GetType() == typeof(PingMessage))
            {
                ParseForPingMessage(message);
            }
            else if (message.GetType() == typeof(SendMessage))
            {
                ParseForSendMessage(message);
            }
            else
            {
                ParseForConsoleMessage(message);
            }
        }

        private void ParseForSendMessage(Message Message)
        {
            if (Message.IdTarget == Knot.id)
            {
                OutPutMesssage(Message);
            }
            else if (Message.TTL == 1)
            {
                CreateTTLMessage(Message);
            }
        }

        private void ParseForConsoleMessage(Message Message)
        {
            if (Message.IdTarget == Knot.id)
            {
                OutPutMesssage(Message);
            }
        }

        private void ParseForPingMessage(Message Message)
        {
            PingMessage message = (Message as PingMessage);

            if (message.IdTarget == Knot.id)
            {
                if (message.Wait == TimeSpan.Zero)
                {
                    CreateAnswerPong(message);
                }
                else
                {
                    OutPutMesssage(message);
                }
            }
            else if (message.TTL == 1)
            {
                CreateTTLMessage(Message);
            }
        }

        private void CreateAnswerPong(PingMessage message)
        {
            PingMessage Answer = new PingMessage(Knot.id, message.IdSource);
            Answer.DateStart = message.DateStart;
            Answer.DateEnd = DateTime.Now;
            MesOut.Push(Answer);
        }

        private void CreateTTLMessage(Message message)
        {
            ConsoleMessage Answer = new ConsoleMessage("Message cannot be delivered", Knot.id, message.IdSource);
            MesOut.Push(Answer);
        }

        private void OutPutMesssage(Message message)
        {
            MesConsole.Add(message);
        } 
        #endregion
    }
}


