

namespace Pizzeria.GameModule.RootModule.ControllerCreators
{
    public interface IControllerCreator
    {
        /// <summary>
        /// contains a collection of pairs <module controller type, module controller> For example : <typeof(ARModule.IARController), ARController>
        /// </summary>
        /// <returns></returns>
        System.Collections.Generic.Dictionary<System.Type, object> Execute();
    }
}