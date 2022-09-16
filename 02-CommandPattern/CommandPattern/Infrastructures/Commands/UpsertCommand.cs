using CommandPattern.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Infrastructures.Commands;

public sealed class UpsertCommand : Command
{
    private string key { get; set; }
    private string value { get; set; }
    public UpsertCommand(string key, string value, DataReceiver dataReceiver) : base(dataReceiver)
    {
        this.key = key;
        this.value = value;
    }

    public override void Execute()
    {
        _dataReceiver.Upsert(key, value);
    }
}
