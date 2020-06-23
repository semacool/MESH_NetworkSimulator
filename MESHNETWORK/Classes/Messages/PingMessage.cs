using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MESHNETWORK.Classes
{
    class PingMessage : Message
    {
        public DateTime DateStart { get; set; } // Время отправки сообщения
        public DateTime DateEnd { get; set; } // Время получения сообщения
        public TimeSpan Wait // Время доставления сообщения
        {
            get 
            {
                if (DateEnd == DateTime.MinValue)
                    return TimeSpan.Zero;
                else
                    return DateEnd.Subtract(DateStart); 
            }
        }


        /// <summary>
        /// Создание нового сообщения
        /// </summary>
        /// <param name="IdSource"></param>
        /// <param name="IdTarget"></param>
        public PingMessage(uint IdSource, uint IdTarget) : base(IdSource, IdTarget)
        {
            DateStart = DateTime.Now;
        }

        /// <summary>
        /// Ретрансляция существующего сообщения
        /// </summary>
        /// <param name="pm"></param>
        public PingMessage(PingMessage pm) : base(pm)
        {
            DateStart = pm.DateStart;
            DateEnd = pm.DateEnd;
        }

        /// <summary>
        /// Перегрузка для вывода в Коносоль
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"pong: {Wait.TotalSeconds} s.\t| via: {base.IdLastNode}, TTL: {base.TTL}";
        }
    }

}
