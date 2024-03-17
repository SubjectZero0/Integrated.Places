using Hangfire;

namespace Infrastructure.Jobs
{
    public static class Jobs
    {
        public static void StartMessageBus()
        {
            var jobClient = new BackgroundJobClient();
            jobClient.Enqueue(() => Console.WriteLine("Hello, world!"));

            using (var server = new BackgroundJobServer())
            {
                Console.ReadLine();
            }

            // Todo: Complete MessageBus Job on startup
        }
    }
}