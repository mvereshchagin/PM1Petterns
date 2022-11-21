namespace PM1Petterns.Data;

internal abstract class Gadget
{
    public string Producer { get; init; } = null!;

    public string Model { get; init; } = null!;

    public string? Chipset { get; init; }

    public string? Firmware { get; set; }

    public string Color { get; init; } = null!;

    public int Price { get; set; }

    public int Weight { get; init; } 

    public int BatteryCapacity { get; set; }

    public string? Description { get; set; }

    public virtual string Type { get; } = "unknown";

    public override string ToString()
    {
        return $"{Type} {Producer} {Model}";
    }

    public void Deconstruct(out string producer, out string model, out string color, out string type)
    {
        producer = Producer;
        model = Model;
        color = Color;
        type = Type;
    }
}
