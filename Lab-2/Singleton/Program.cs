using Singleton;

class Program { 
    static void Main() 
    {  
        Authenticator auth1 = Authenticator.GetInstance();
        Console.WriteLine($"First object declaration: {auth1.GetHashCode()}");

        Authenticator auth2 = Authenticator.GetInstance();
        Console.WriteLine($"Second object declaration {auth2.GetHashCode()}");

        Console.WriteLine($"Is objects equal: {object.ReferenceEquals(auth1, auth2)}\n");

        List<Task> tasks = new List<Task>();

        for (int i = 0; i < 5; i++)
        {
            var task = Task.Run(() =>
            {
                int threadId = Thread.CurrentThread.ManagedThreadId;

                var instance = Authenticator.GetInstance();
                Console.WriteLine($"Thread {threadId} get object instance: {instance.GetHashCode()}");
            });

            tasks.Add(task);
        }

        Task.WaitAll(tasks.ToArray());
    }
}