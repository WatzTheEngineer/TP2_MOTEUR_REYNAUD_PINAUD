using Godot;
using Godot.Collections;
using System.Collections.Generic;

public partial class LevelManager : Node
{
	[Export] int firstSceneIndex = 0;
	[Export] Array<PackedScene> editorScenes;
	
	private List<LoadableScene> loadableScenes = new List<LoadableScene>();
	private LevelManager()
	{
		
	}
	
	public override void _Ready()
	{
		//PopulateLoadableScenesList();
		
		LoadLevelScene(loadableScenes[firstSceneIndex]);
	}
	public void LoadLevelScene(LoadableScene sceneToLoad)
	{
		if(!sceneToLoad.scene.CanInstantiate()) return;
		
		Node newScene = sceneToLoad.scene.Instantiate();
		
		if(newScene == null) return;
		
		AddChild(newScene);
	}
	
	//public void PopulateLoadableScenesList()
	//{
		//for(int i = 0; i < editorScenes.Count; i++)
		//{
			//if(editorScenes[i]== null) continue;
			//
			//AddLevelToSceneList(editorScenes[i]);
		//}
	//}
	
	//public int AddLevelToSceneList(PackedScene scene)
	//{
		//if(scene == null) return -1;
		//
		//string name = scene._Bundled["name"].As<Godot.Collections.Array>();
		//
		//for (int i = 0; i < loadableScenes.Count; i++)
		//{
			//if(name == loadableScenes[i].sceneName)
			//{
				//GD.PrintErr("Duplicatie scenes with the name: " + name);
				//return -1;
			//}
		//}
		//
		//LoadableScene loadableScene = new LoadableScene(name, scene);
		//
		//loadableScene.Add(loadableScene);
		//
		//return loadableScenes.Count = -1;
	//}
	
	public class LoadableScene{
		public string sceneName;
		public PackedScene scene;
		
		public LoadableScene(string sceneName, PackedScene scene){
			
			this.sceneName = sceneName;
			this.scene = scene;
		}
	}
}
