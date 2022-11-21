using PM1Petterns.Data;

var gadgets = new Gadget[]
{
    new Phone()
    {
        Producer = "Apple",
        Model = "IPhone 11",
        Color = "light pink",
        BatteryCapacity = 3500,
        Weight = 200,
        Description = "Only for girls",
        Price = 30000,
    },
    new Phone()
    {
        Producer = "Nokia",
        Model = "3310",
        Color = "black",
        BatteryCapacity = 1000,
        Weight = 500,
        Description = "Only for true guys",
        Price = 200000,
    },
    new Phone()
    {
        Producer = "SonyEricsson",
        Model = "u3452",
        Color = "light blue",
        BatteryCapacity = 3500,
        Weight = 150,
        Description = "For everybody",
        Price = 40000,
    },
    new Phone()
    {
        Producer = "Apple",
        Model = "IPhone 13",
        Color = "gray",
        BatteryCapacity = 5000,
        Weight = 180,
        Description = "For rich people",
        Price = 60000,
    },
    new Phone()
    {
        Producer = "Apple",
        Model = "IPhone 12",
        Color = "green",
        BatteryCapacity =4000,
        Weight = 200,
        Description = "For those, who does not have enough money for iPhone 12, but wants it very much",
        Price = 50000,
    },
    new Phone()
    {
        Producer = "BlackBerry",
        Model = "g1243",
        Color = "black",
        BatteryCapacity = 10000,
        Weight = 1000,
        Description = "For business guys and girls",
        Price = 7000,
    },
    new Phone()
    {
        Producer = "Siemens",
        Model = "a35",
        Color = "white",
        BatteryCapacity = 2000,
        Weight =150,
        Description = "",
        Price = 3000,
    },
    new Phone()
    {
        Producer = "LG",
        Model = "g53u",
        Color = "blue",
        BatteryCapacity = 1000,
        Weight = 500,
        Description = "For those who does not wmet to be like others",
        Price = 5000,
    },
    new Tablet()
    {
        Producer = "Apple",
        Model = "iPad 13",
        Color = "white",
        HasStilus = true,
        Price = 120000
    },
    new Tablet()
    {
        Producer = "Apple",
        Model = "iPad 12",
        Color = "white",
        HasStilus = true,
        Price = 35000
    }
};

PatternTyping();
PatternProperties();
PatternTuples();
PatternPropertiesThroughTuples();
PatternWithComplictedCondition();
PatternList();
PatternList2();

#region PatternTyping

void PatternTyping()
{
    DoPrint("Type matching IF", () =>
    {
        foreach (var gadget in gadgets)
        {
            if (gadget is Phone)
                Console.WriteLine(gadget);
        }
    });


    DoPrint("Type mathing SWITCH", () =>
    {
        foreach (var gadget in gadgets)
        {
            var desc = GetGadgetDesc(gadget);
            Console.WriteLine(desc);
        }
    });

    DoPrint("Type mathing NEW SWITCH", () =>
    {
        foreach (var gadget in gadgets)
        {
            var desc = GetGadgetDesc2(gadget);
            Console.WriteLine(desc);
        }
    });
}

string GetGadgetDesc(Gadget gadget)
{
    switch(gadget)
    {
        case Phone:
            return $"Телефон {gadget}";
        case Tablet:
            return $"Планшет {gadget}";
        default:
            return gadget.ToString();
    }
}

string GetGadgetDesc2(Gadget gadget) => gadget switch
{
    Phone => $"Телефон {gadget}",
    Tablet => $"Планшет {gadget}",
    _ => gadget.ToString()
};



#endregion

#region PatternProperties
void PatternProperties()
{
    DoPrint("Pattern Properties", () =>
    {
        foreach (var gadget in gadgets)
        {
            var desc = GetBaseOnProperties(gadget);
            Console.WriteLine($"{gadget} - {desc}");
        }
    });
}

string GetBaseOnProperties(Gadget gadget) => gadget switch
{
    Gadget { Producer: "Apple" } => "Это яблоко",
    Phone { Producer: "Nokia", Color: "black" } => "Это телефон фирмы Nokia",
    Phone { Color: "white" } => "Телефон белого цвета",
    Tablet { HasStilus: true } => "Планшет со стилусом",
    _ => "Фиг знает что",
};

string GetDescBaseOnProducer(Gadget gadget) => gadget.Producer switch
{
    "Apple" => "Яблоко",
    "Nokia" => "Нокия",
    _ => gadget.Producer,
};
#endregion

#region PatternTuples

void PatternTuples()
{
    DoPrint2("Pattern Tuples", GetDescByProducerAndModeAndColor);
}

string GetDescByProducerAndModeAndColor(Gadget gadget) => (gadget.Producer, gadget.Model, gadget.Color) switch
{
    ("Apple", "iPhone 13", "black") => "Черный iPhone 13",
    ("Apple", _, "black") => "Черный телефон от Apple любой модели",
    ("Apple", var model, _) => $"Любой гаджет фирмы Apple: {model}",
    (_, var model, "white") => $"Любой белый гаджет модели: {model}",
    _ => "Незаномо что"
};

#endregion

#region PatternPropertiesThroughTuples
void PatternPropertiesThroughTuples()
{
    DoPrint2("Pattern Properties using tuples", GetDescByClassWithTuples);
}

string GetDescByClassWithTuples(Gadget gadget) => gadget switch
{
    (_, _, _, "tablet") => "Какой-то планшет",
    (_, _, "white", _) => "Что угодно белого цвета",
    ("Apple", _, _, _) => "Что угодно от Apple",
    (_, _, var color, _) => $"Что угодно с известным цветом: {color}",
};
#endregion

#region PatternWithComplictedCondition
void PatternWithComplictedCondition()
{
    DoPrint2("Pattern with complicated condition", GetDescComplictated);
}

string GetDescComplictated(Gadget gadget) => gadget switch
{
    Gadget { Producer: "Apple" } when gadget.Price >= 70000 => "Дорогой Apple",
    Phone { Producer: "Apple" } => "Дешевый Apple телефон",
    Tablet { Price: > 30000 and < 40000 } => "Дорогой Apple в цене 30000 - 40000",
    _ => gadget.ToString(),
};

#endregion

#region PatternList
void PatternList()
{
    int[] numbers = { 1, 23, 12, 11, 16, 3, 12, 45 };
    var res = GetDescOfList(numbers);
    Console.WriteLine(res);

    if (numbers is [var first, _, var third, _, _, _])
        Console.WriteLine($"Шаблон списка из 6 элементов, причем первый = {first}, а третий {third}");
    
    if (numbers is [1, _, _, _, _, _])
        Console.WriteLine($"Шаблон списка из 6 элементов, у которого первый элемент = 1");

    if (numbers is [1, ..])
        Console.WriteLine($"Шаблон списка, у которого первый элемент = 1");

    if(numbers is [1, > 20, > 10 and <=12, .., > 0,  > 0])
    {

    }

    Console.WriteLine("==================================");
    if(numbers is [_, _, .. var subNumbers, _, _])
    {
        Console.Write(String.Join(", ", subNumbers));
    }
    Console.WriteLine("");
}

string GetDescOfList(int[] list) => list switch
{
    [1, 2, 3] => "Список из чисел [1, 2, 3]",
    [1, 2, 3, 4] => "Список из чисел [1, 2, 3, 4]",
    [1, 2, 3, 4, 5, 6] => "Список из чисел [1, 2, 3, 4, 5, 6]",
    _ => "нет такого паттерна",
};

void PatternList2()
{
    DoPrint("Pattern List with strings", () =>
    {
        string[] names = { "Маша", "Саша", "Аркаша", "Паша", "Даша", "Глаша", "Акакий" };
        foreach (var name in names)
        {
            var modifiedName = MakeFirstLetterLowerWhenNameEndWith_ша(name);
            Console.WriteLine(modifiedName);
        }
    });
}

string MakeFirstLetterLowerWhenNameEndWith_ша(string name)
{
    if (name is [var cFirst, .. var s, 'ш', 'а'])
        return $"{cFirst.ToString().ToLower()}{s}ша";
    return name;
}
#endregion

#region auxiliary functions

void DoPrint(string caption, Action action)
{
    Console.WriteLine(caption);
    Console.WriteLine("===================================");
    action();
    Console.WriteLine("===================================");
    Console.WriteLine("");
}

void DoPrint2(string caption, Func<Gadget, string> f)
{
    DoPrint(caption, () =>
    {
        foreach (var gadget in gadgets)
        {
            var desc = f(gadget);
            Console.WriteLine($"{gadget} - {desc}");
        }
    });
}

#endregion