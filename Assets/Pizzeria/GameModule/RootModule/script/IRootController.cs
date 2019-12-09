/*
    RootModule controller interface.
*/

namespace Pizzeria.GameModule.RootModule
{
    public interface IRootController
    {
        /// <summary>
        /// returns the module controller of the corresponding type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T GetControllerByType<T>();
    }
}
