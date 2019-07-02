using System;

namespace GameModule.GlobalModule.GlobalUpdate
{
    public interface IGlobalUpdate
    {
        event Action OnCustomUpdate;
    }
}