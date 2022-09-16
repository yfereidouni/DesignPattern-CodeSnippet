using CommandPattern.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Infrastructures.Commands
{
    public sealed class DeleteCommand : Command
    {
        private string key { get; set; }
        public DeleteCommand(string key, DataReceiver dataReceiver) : base(dataReceiver)
        {
            this.key = key;
        }

        public override void Execute()
        {
            _dataReceiver.Delete(key);
        }
    }
}
