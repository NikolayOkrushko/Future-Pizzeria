using Pizzeria.GameModule.TableModule;
using UnityEngine;

namespace Pizzeria.GameModule.AdministratorModule
{
    public class ReadyOrder
    {
        private TableUniversal visitorTable;
        private TableUniversal cookTable;
        // Нужно добавить пиццу

        #region Constructors

        public ReadyOrder(TableUniversal tableVisitor, TableUniversal tableCook)
        {
            visitorTable = tableVisitor;
            cookTable = tableCook;
        }
        #endregion

        public TableUniversal VisitorTable()
        {
            return visitorTable;
        }

        public TableUniversal CookTable()
        {
            return cookTable;
        }
    }
}