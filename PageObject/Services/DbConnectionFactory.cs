
namespace PageObject.Services
{
    public static class DbConnectionFactory
    {
        public static void CreateTransient(string tableName)
        {
            SqlService.OpenConnection();
            SqlService.DropTable($"{tableName}");
            SqlService.CreateModelTable($"{tableName}");
        }
    }
}