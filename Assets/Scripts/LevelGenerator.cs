using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

	public Texture2D map;
	public PrefabColors[] colors;

	void Start() {
		GenerateLevel();
	}

	void GenerateLevel(){
		Debug.Log(map.width);
		for (int i = 0; i < map.width; i++){
            for (int j = 0; j < map.height; j++)
            {
				GenerateTile(i,j);
            }
		}
	}

	void GenerateTile(int xCoord,int yCoord){
		Color pixelColor = map.GetPixel(xCoord,yCoord);
		if(pixelColor.a == 0){
			return;
		}

		foreach (PrefabColors mapping in colors)
		{
			if(mapping.color.Equals(pixelColor)){
				Debug.Log("Hello");
				Vector2 position = new Vector2(xCoord,yCoord);
				Instantiate(mapping.prefab,position,Quaternion.identity,transform);
			}
		}
	}
}
