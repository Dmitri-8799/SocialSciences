using System.Reflection;
using SocialSciencesDecember2023.RadioButtons3;
namespace SocialSciencesDecember2023;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}

    //подключился к БД
    public const string DATABASE_NAME = "Обществознание задания БД.db";


    //не знаю, какой класс надо исопльзовать, потому что в оригинале идет сочетание с репозиторием ( в данном случае это - Logic_TableRB3). Можно ли исопльзовать класс SQLiteAsyncConnection??

   // public static SQLiteAsyncConnection database; и так далее. Короче, нужен универсальный класс, чтоб каждая таблица могла обращаться к этому классу подключения к БД.

    public static Logic_TableRB3  database;
    public static Logic_TableRB3 Database
    {
        get
        {
            if (database == null)
            {
                // путь, по которому будет находиться база данных
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME);
                // если база данных не существует (еще не скопирована)
                if (!File.Exists(dbPath))
                {
                    // получаем текущую сборку
                    var assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
                    // берем из нее ресурс базы данных и создаем из него поток
                    using (Stream stream = assembly.GetManifestResourceStream($"SocialSciencesDecember2023.{DATABASE_NAME}"))
                    {
                        using (FileStream fs = new FileStream(dbPath, FileMode.OpenOrCreate))
                        {
                            stream.CopyTo(fs);  // копируем файл базы данных в нужное нам место
                            fs.Flush();
                        }
                    }
                }
                // database = new SQLiteAsyncConnection (dbPath); - аналогично сделал на всякий случай с классом SQLiteAsyncConnection
                database = new Logic_TableRB3 (dbPath);
            }
            return database;
        }
    }





}
