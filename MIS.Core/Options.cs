namespace MIS.Core
{
    public class Options
    {
        // инициируем Connection string
        public static string ConnectionString
        {
            get
            {
                // Получаем данные Connection string из "переменной среды"
                string name = "ConnectionStringMISblazor";
                string? cs = Environment.GetEnvironmentVariable(name);

                if (cs == null)
                {
                    throw new InvalidOperationException($"Переменная среды {name} не задана или пуста");
                }

                return cs;
            }
        }
    }
}

