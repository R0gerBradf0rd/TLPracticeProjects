namespace Dictionary.ConsoleMenu.MenuRunner
{
    public interface IDictionaryMenuRunner : IMenuRunner
    {
        /// <summary>
        /// Возвращает слово, введеное пользователем, если его нет в словаре
        /// </summary>
        public string TheWordOutOfDictionary();
    }
}
