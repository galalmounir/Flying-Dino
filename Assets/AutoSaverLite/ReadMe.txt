
--------------------------------------------------------------------------------------------
Version: 1.1
--------------------------------------------------------------------------------------------

--------------------------------------------------------------------------------------------
Auto Save Overview and Setup
--------------------------------------------------------------------------------------------

This script will allow you to create static variables and be able to save them automatically
vs. having the write a save function per project. All you need to call is Save and Load and 
you get auto save.

1) Open the Variables.cs file
	- Put all your variables you want to save in here
	- Make sure you make your variable public and static so you can access it
	- To access them just call Variables.variableName
2) Every variable in here will be saved when you call SavedVariables.Save();
	- The only types that can be auto saved are the following
		- float
		- double
		- int
		- bool
		- string
		- Vector2
		- Vector3
		- List<int>
		- List<float>
		- List<double>
		- List<string>
		- List<bool>
		- List<Vector2>
		- List<Vector3>

3) Now you can save your variables quickly
	- The variables get stored locally using PlayerPrefs
	- Database saving isn't avaiable yet or maybe ever
4) You can also have multiple saved files using SavedVariables.Save(int index)
	- index is where you want to store your current saved files
5) Loading from an index is just the same SavedVariables.Load(int index)
	- index is where you want to load from

Variable Window Editor
1) To see your saved variables click "Save Editor/Saved Variable Editor"
	- Here you can see all the variables you have saved
	- You can enter multiple slots to see all the index's you have saved to as well
	- You can also choose to rewrite/delete variables as well
2) If you add a variable to Variables.cs, click "Refresh Name" to see it in the inspector

You can change your values inside the editor window but you cannot be running the scene for the changes to take effect.


--------------------------------------
Known-Issues
--------------------------------------
1) You cannot view List<Vector2>, List<Vector3> in the editor window, because there is normally a lot of information in this, I have choosen to remove it from the editor


--------------------------------------
Roadmap
--------------------------------------
1) Database saving...Being able to call to a php script and pass all your information to and from
2) Include more data types like Quaternion, Transforms and Dictionary
3) Option to save to a text or xml file instead of PlayerPrefs
4) Tutorial video
5) Saving custom classes
6) Single save/load functions to not have to save/load all your data each time