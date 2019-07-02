Процесс использования Root модуля:
1) В каждой сцене должен висеть префаб RootModule
2) Кастомизация Root модуля для каждой из сцен:
		- создать скрипт создателя для своей сцены по образцу GameSceneCreator.cs и реализующий интерфейс IControllerCreator
		- внести данные о своей сцене в скрипт RootConroller.cs в метод CreateModulesForScene(string currentSceneName)
3) Обращение к нужному Вам модулю производится путём обращения к статичному методу в RootController.cs по следующему шаблону:
		IARController ARController = RootConroller.GetControllerByType<IARController>();
