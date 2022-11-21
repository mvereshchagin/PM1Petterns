namespace PM1Petterns.Data;

internal class Tablet : Gadget
{
    public bool HasSim { get; set; }

    public bool HasStilus { get; set; }

    public override string Type => "Tablet";
}
