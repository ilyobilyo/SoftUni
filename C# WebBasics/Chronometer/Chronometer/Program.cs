using ChronometerTest;

var chronometer = new Chronometerr();

while (true)
{
    string line = Console.ReadLine();

    if (line == "exit")
    {
        break;
    }

    if (line == "start")
    {
        Task.Run(() =>
        {
            chronometer.Start();
        });
    }
    else if (line == "stop")
    {
        chronometer.Stop();
    }
    else if (line == "lap")
    {
        Console.WriteLine(chronometer.Lap());
    }
    else if (line == "laps")
    {
        if (chronometer.Laps.Count == 0)
        {
            Console.WriteLine("Laps: no laps");
            continue;
        }

        Console.WriteLine("Laps: ");

        for (int i = 0; i < chronometer.Laps.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {chronometer.Laps[i]}");
        }
    }
    else if (line == "reset")
    {
        chronometer.Reset();
    }
    else if (line == "time")
    {
        Console.WriteLine(chronometer.GetTime);
    }
}

chronometer.Stop();