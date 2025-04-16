namespace Dictionary.DictionaryMenuMediator
{
    public interface IDictionaryMenuMediator : IMenuMediator
    {
        /// <summary>
        /// Возвращает слово, введеное пользователем, если его нет в словаре
        /// </summary>
        public string TheWordOutOfDictionary();
    }
}
