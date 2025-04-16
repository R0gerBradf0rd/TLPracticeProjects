/// <summary>
/// Определяет основные методы для отображения и управления консольным меню.
/// </summary>

namespace Dictionary.ConsoleMenu
{
    public interface IConsoleMenuDisplayer
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
        public void UpdatePromt( string newPromt );

        /// <summary>
        /// Обновляет опции меню
        /// </summary>
        /// <param name="newOptions">Массив новых опций</param>
        public void UpdateOptions( string[] newOptions );
    }
}
