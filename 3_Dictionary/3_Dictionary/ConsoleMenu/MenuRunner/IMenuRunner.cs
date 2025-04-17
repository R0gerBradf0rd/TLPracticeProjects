/// <summary>
/// Связывает опции меню между собой
/// </summary>
namespace Dictionary.ConsoleMenu.MenuRunner
{
    public interface IMenuRunner
    {
        /// <summary>
        /// Взовращает пункт выбраной опции
        /// </summary>
        public int GetSelectedIndex();
    }
}
