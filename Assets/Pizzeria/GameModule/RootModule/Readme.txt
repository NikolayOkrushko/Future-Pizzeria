������� ������������� Root ������:
1) � ������ ����� ������ ������ ������ RootModule
2) ������������ Root ������ ��� ������ �� ����:
		- ������� ������ ��������� ��� ����� ����� �� ������� GameSceneCreator.cs � ����������� ��������� IControllerCreator
		- ������ ������ � ����� ����� � ������ RootConroller.cs � ����� CreateModulesForScene(string currentSceneName)
3) ��������� � ������� ��� ������ ������������ ���� ��������� � ���������� ������ � RootController.cs �� ���������� �������:
		IARController ARController = RootConroller.GetControllerByType<IARController>();
