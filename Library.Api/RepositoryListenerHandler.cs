using Microsoft.Extensions.Logging;


namespace Library.DAL
{
    public static class RepositoryListenerHandler
    {

        public static void OnEntityModified(string action, object entity)
        {
            // log some action
            System.Console.WriteLine($"Action: {action}, Entity: {entity}");
        }
    }
}
