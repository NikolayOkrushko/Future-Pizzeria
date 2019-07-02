using Pizzeria.GameModule.AdministratorModule;
using Pizzeria.GameModule.TableModule;
using System.Collections.Generic;

namespace Pizzeria.GameModule.EnvironmentModule
{
    public interface IEnvironmentController
    {
        void Init();
        List<TableUniversal> GetTables();
    }
}