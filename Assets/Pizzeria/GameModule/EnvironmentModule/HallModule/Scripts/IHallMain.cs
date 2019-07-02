using Pizzeria.GameModule.AdministratorModule;
using Pizzeria.GameModule.TableModule;
using System.Collections.Generic;

namespace Pizzeria.GameModule.Environment.HallModule
{
    public interface IHallMain
    {
        List<TableUniversal> GetTable();
    }
}
