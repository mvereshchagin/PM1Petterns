namespace PM1Petterns.Data;

internal class Phone : Gadget
{
    public int AmountOfSims { get; set; }

    public bool HasFlashSlot { get; set; }

    public override string Type => "Phone";
}
