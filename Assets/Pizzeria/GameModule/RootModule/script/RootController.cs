using GameModule.GlobalModule.GlobalUpdate;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Pizzeria.GameModule.RootModule.ControllerCreators;
using System;


namespace Pizzeria.GameModule.RootModule
{
    public class RootController : MonoBehaviour
    {
        public static event Action OnModuleAreReady;
        public static GlobalUpdate globalUpdate { get; private set; }

        private static Dictionary<System.Type, object> moduleControllers;


        #region Public
        public static T GetControllerByType<T>()
        {
            var typeOfController = typeof(T);
            object controller = null;

            if (moduleControllers.ContainsKey(typeOfController))
            {
                controller = moduleControllers[typeOfController];
            }

            return (T)controller;
        }
        #endregion Public


        #region MonoBehaviour
        void Awake()
        {
            CreateModulesForScene(SceneManager.GetActiveScene().name);
        }
        #endregion MonoBehaviour


        #region Private
        private void CreateModulesForScene(string currentSceneName)
        {
            ActivateGlobalServices();

            switch (currentSceneName)
            {
                case GameData.GAME_SCENE_NAME:
                    moduleControllers = new GameSceneCreator().Execute();
                    break;
                case GameData.MENU_SCENE_NAME:
                    moduleControllers = new CharacterSelectionSceneCreator().Execute();
                    //new ARModule.Test.TestARModule();
                    break;
                default:
                    Debug.Log($"<color=red>No root module created for this scene!</color>");
                    break;
            }
            FinishCheckingModules();
        }


        private void FinishCheckingModules()
        {
            if (OnModuleAreReady != null)
            {
                OnModuleAreReady();
            }
        }

        private void ActivateGlobalServices()
        {
            globalUpdate = new GameObject("GlobalUpdate").AddComponent<GlobalUpdate>();
        }
        #endregion Private

    }
}
