using CommandPattern.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Infrastructures.Commands;

public sealed class DisplayCommand : Command
{
    private string key { get; set; }
    private string value { get; set; }
    public DisplayCommand(DataReceiver dataReceiver) : base(dataReceiver) { }

    public override void Execute()
    {
        _dataReceiver.Display();
    }
}
