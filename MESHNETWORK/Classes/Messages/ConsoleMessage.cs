using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MESHNETWORK.Classes
{
    class ConsoleMessage : Message
    {

        public string Text { get; set; }
        public ConsoleMessage(string Text,uint IdSource, uint IdTarget) : base(IdSource,IdTarget)
        {
            this.Text = Text;
        }

        public ConsoleMessage(ConsoleMessage message) : base(message)
        {
            this.Text = message.Text;
        }
        public override string ToString()
        {
            return Text;
        }
    }
}
