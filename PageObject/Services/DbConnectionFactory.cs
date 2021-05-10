
namespace PageObject.Services
{
    public class DbConnectionFactory
    {
        public static void CreateTransient(string tableName)
        {
            SqlService.OpenConnection();
            SqlService.DropTable($"{tableName}");
            SqlService.CreateModelTable($"{tableName}");
        }
    }
}