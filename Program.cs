using BISTest;

Singleton singleton = Singleton.GetInstance();

(new Thread(() =>
{
    List<Task<int>> tasks = new();
    var task1 = Task.Run(() => singleton.DoCalculation(2));
    tasks.Add(task1);
    var task2 = Task.Run(() => singleton.DoCalculation(3));
    tasks.Add(task2);
    foreach (var task in tasks)
    {
        Console.WriteLine(task.Status);
    }
    foreach (var task in tasks)
    {
        try
        {
            Console.WriteLine(task.Result);
        }
        catch (AggregateException ae)
        {
            foreach (var ex in ae.InnerExceptions)
            {
                if (ex is ArgumentException)
                    Console.WriteLine(ex.Message);
                else
                    throw ex;
            }
        }
    }
})).Start();

(new Thread(() =>
{
    List<Task<int>> tasks = new();
    var task1 = Task.Run(() => singleton.DoCalculation(46340));
    tasks.Add(task1);
    var task2 = Task.Run(() => singleton.DoCalculation(46341));
    tasks.Add(task2);
    foreach (var task in tasks)
    {
        Console.WriteLine(task.Status);
    }
    foreach (var task in tasks)
    {
        try
        {
            Console.WriteLine(task.Result);
        }
        catch (AggregateException ae)
        {
            foreach (var ex in ae.InnerExceptions)
            {
                if (ex is ArgumentException)
                    Console.WriteLine(ex.Message);
                else
                    throw ex;
            }
        }
    }
})).Start();
