/// <summary>
/// Связывает опции меню между собой
/// </summary>
namespace Dictionary.DictionaryMenuMediator
{
    public interface IMenuMediator
    {
        /// <summary>
        /// Взовращает пункт выбраной опции
        /// </summary>
        public int RunMenu();
    }
}
