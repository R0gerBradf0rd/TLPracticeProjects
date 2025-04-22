/// <summary>
/// Определяет основные методы для отображения и управления консольным меню.
/// </summary>
namespace Dictionary.DictionaryMenuMediator
{
    public interface IConsoleMenuMediator
    {
        /// <summary>
        /// Отображает доступные опции меню в консоли
        /// </summary>
        public void DisplayOptions();

        /// <summary>
        /// Получает индекс выбранной пользователем опции
        /// </summary>
        /// <returns>Индекс выбранной опции</returns>
        public int GetSelectedIndex();

        /// <summary>
        /// Обновляет текст заголовка меню
        /// </summary>
        /// <param name="newPromt">Новый текст меню</param>
        public void SetTittle( string newPromt );

        /// <summary>
        /// Обновляет опции меню
        /// </summary>
        /// <param name="newOptions">Массив новых опций</param>
        public void SetOptions( string[] newOptions );

        /// <summary>
        /// Выводит сообщеение в строку
        /// </summary>
        /// <param name="message">Сообщение, которое нужно вывести</param>
        public void WriteMessage( string message );

        /// <summary>
        /// Выводит сообщение, с переводом на новую строку
        /// </summary>
        /// <param name="message">Сообщение, которое нужно вывести</param>
        public void WriteMessageInNewLine( string message );

        /// <summary>
        /// Очищает экран
        /// </summary>
        public void ClearScreen();
    }
}
