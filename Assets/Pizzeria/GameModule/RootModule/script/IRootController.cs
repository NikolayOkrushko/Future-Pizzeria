/*
    Skywell Software
    Andrii Danyliuk 
    10.06.2019
    andredaniluk@gmail.com

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