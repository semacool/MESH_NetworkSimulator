using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MESHNETWORK.Classes
{
    /// <summary>
    /// Базовый класс для сообщения
    /// </summary>
    public abstract class Message
    {
        static uint NextId = 0; // Изменение Id
        public uint Id { get; set; } // Уникальный код
        public uint IdSource { get; set; } // Код узла-источника
        public uint IdTarget { get; set; } // Код узла-цели
        public int TTL { get; set; } // Время жизни сообщения
        public uint IdLastNode { get; set; } // Код последнего узла.


        /// <summary>
        /// Создание нового сообщения
        /// </summary>
        /// <param name="IdSource"></param>
        /// <param name="IdTarget"></param>
        public Message(uint IdSource, uint IdTarget) 
        {
            Id = NextId++;
            TTL = 10;
            this.IdSource= IdSource;
            this.IdTarget= IdTarget;
            this.IdLastNode = IdSource;
        }

        /// <summary>
        /// Ретрансляция уже существующего сообщения
        /// </summary>
        /// <param name="ms"></param>
        public Message(Message ms)
        {
            Id = ms.Id;
            TTL = ms.TTL;
            this.IdSource = ms.IdSource;
            this.IdTarget = ms.IdTarget;
            this.IdLastNode = ms.IdSource;
        }
    }
}
