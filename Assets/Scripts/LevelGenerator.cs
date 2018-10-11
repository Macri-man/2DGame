using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

	public Texture2D map;

	void GenerateLevel(){
		for (int i = 0; i < map.width; i++){
            for (int j = 0; j < map.height; j++)
            {
				GenerateTile(i,j);
            }
		}
	}

	void GenerateTile(int xcoord,int ycoord){

	}
}
