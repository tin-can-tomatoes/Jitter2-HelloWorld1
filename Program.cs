using Jitter2;


World world = new();


world.Step(1f/100f, false);
world.Step(1f/100f, false);
world.Step(1f/100f, false);

Console.WriteLine("Foo");