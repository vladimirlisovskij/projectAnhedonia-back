using System.IO;

namespace projectAnhedonia_back.Data.Common
{
    public static class Constants
    {
        public static string MainDatabasePath => "Data/Common/Database/MainDatabase.db";
        public static string EmptyMainDatabasePath => "Data/Common/Database/MainDatabase_empty.db";

        // public static string MainDatabaseAbsolutePath => Path.GetFullPath(MainDatabasePath);
        // public static string EmptyMainDatabaseAbsolutePath => Path.GetFullPath(EmptyMainDatabasePath);
    }
}