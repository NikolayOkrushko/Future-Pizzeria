using UnityEngine;
using System;

namespace GameModule.GlobalModule.GlobalUpdate
{
    public class GlobalUpdate : MonoBehaviour, IGlobalUpdate
    {
        public event Action OnCustomUpdate;


        void Update()
        {
            if (OnCustomUpdate != null)
            {
                OnCustomUpdate();
            }
        }
    }
}
