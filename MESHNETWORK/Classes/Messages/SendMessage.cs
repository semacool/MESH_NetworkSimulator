using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MESHNETWORK.Classes
{
    class SendMessage : Message
    {
        public string Text { get; set; }

        public SendMessage(string Text, uint IdSource, uint IdTarget) : base(IdSource, IdTarget)
        {
            this.Text = Text.Substring(Text.LastIndexOf(' '));
        }

        public SendMessage(SendMessage sm) : base(sm)
        {
            this.Text = sm.Text;
        }

        public override string ToString()
        {
            return $"{Text}\t| from: {base.IdSource}\tvia: {base.IdLastNode}, TTL: {base.TTL}";
        }
        
    }
}
