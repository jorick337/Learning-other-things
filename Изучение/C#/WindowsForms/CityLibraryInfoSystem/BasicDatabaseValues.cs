namespace CityLibraryInfoSystem
{
    internal class BasicDatabaseValues
    {
        public static ActiveDatabase? ActiveDatabase { get; set; }

        public BasicDatabaseValues()
        {
            ActiveDatabase = new ActiveDatabase();
        }

        public static void LoadDatabase(string link)
        {
            ActiveDatabase = new ActiveDatabase(link);
        }
    }
}
