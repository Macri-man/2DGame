using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

	public Texture2D[] maps;
	public GameObject[] prefabs;
	private PrefabColors[] colors;// = new PrefabColors[2];

	public GameObject[] background1Tiles;
	public GameObject[] background2Tiles;
	public GameObject[] background3Tiles;
	public GameObject[] foreground1Tiles;

	public GameObject[][] backgroundTileSets;


	public void GenerateColors()
	{
		backgroundTileSets = new GameObject[][] {
			background1Tiles,
			background2Tiles,
			background3Tiles,
			foreground1Tiles
		};
		colors = new PrefabColors[prefabs.Length];
		int iPFC = 0;
		foreach(GameObject tempPF in prefabs)
		{
			PrefabColors tempPFC = new PrefabColors();
			tempPFC.prefab = tempPF;
			tempPFC.color = tempPFC.prefab.GetComponent<SpriteRenderer>().color;
			tempPFC.tileArrayIndex = iPFC;
			colors[iPFC] = tempPFC;
			Debug.LogError("color="+tempPFC.color.r+","+tempPFC.color.g+","+tempPFC.color.b);
			iPFC++;
		}
	}

	public bool CompareColours(Color c1, Color c2)
	{
		return ((c1.r == c2.r) && (c1.g == c2.g) &&
						(c1.b == c2.b) && (c1.a == c2.a));
	}

	public void GenerateLevel()
	{
		GenerateColors();
		//Debug.LogError("MW="+map.width+",MH="+map.height);
		for (int iLevel = 0; iLevel < backgroundTileSets.Length; iLevel++){

			for (int i = 0; i < maps[iLevel].width; i++){
	            for (int j = 0; j < maps[iLevel].height; j++)
	            {
									GenerateTile(i,j,iLevel);
	            }
			}
		}
	}

	void GenerateTile(int xCoord,int yCoord, int tileLayer){
		Color pixelColor = maps[tileLayer].GetPixel(xCoord,yCoord);
		Debug.LogError("pixelColor="+pixelColor.r+","+pixelColor.g+","+pixelColor.b+","+pixelColor.a);
		if(pixelColor.a == 0)
		{
			Debug.LogError("Ignore this pixel");
			return;
		}

//else Debug.LogError("colors.Length="+colors.Length);
		foreach (PrefabColors mapping in colors)
		{
			if(CompareColours(mapping.color, pixelColor)){
				Debug.LogError("pixelColor="+pixelColor.r+","+pixelColor.g+","+pixelColor.b);
			//if(mapping.color.Equals(pixelColor)){
				Vector2 position = new Vector2(xCoord,yCoord);
				Instantiate(mapping.prefab,position,Quaternion.identity,transform);
				GameObject tempObject0 = backgroundTileSets[tileLayer][mapping.tileArrayIndex];
				Instantiate(tempObject0, position, Quaternion.identity,transform);
			}
		}
	}
}
