using Jitter2;


World world = new(numBodies: 1, numContacts: 1, numConstraints: 1);


world.Step(1f/100f, false);
world.Step(1f/100f, false);
world.Step(1f/100f, false);

Console.WriteLine("Foo");