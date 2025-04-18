namespace Dictionary.ConsoleMenu
{
    public static class TitelsAndOptions
    {
        public static string MainMenuPromt()
        {
            return "Добро пожаловать в словарь!\nИспользуйте стрелочки, чтобы выбрать опцию и нажмите ENTER, чтобы подтвердить выбор.\n";
        }

        public static string[] MainMenuOptions()
        {
            return new string[] { "Словарь", "Описание", "Выход" };
        }

        public static string DictionaryMenuPromt()
        {
            return "";
        }

        public static string[] DictionaryMenuOptions()
        {
            return new string[] { "Ввести еще одно слово", "Главное меню" };
        }

        public static string[] DictionaryNoWordMenuOptions()
        {
            return new string[] { "Ввести еще одно слово", "Главное меню", "Добавить слово в словарь" };
        }

        public static string AboutMenuPromt()
        {
            return "Это словарь, созданый Святом, специально для практики в TL)\n";
        }

        public static string[] AboutMenuOptions()
        {
            return new string[] { "Главное меню" };
        }

        public static string AddWordMenuPromt()
        {
            return "Спасибо за новое слово!)\nЖелаете воспользоваться словарем еще раз?\n";
        }

        public static string[] AddWordMenuOptions()
        {
            return new string[] { "Ввести еще одно слово", "Главное меню" };
        }
    }
}
