using System;
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class StageManager : MonoBehaviour
{
	public int[,] levelData0 = {
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
		{2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
		{3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3},
		{4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4},
		{5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
	};
	public int[,] levelData1 = {
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
	};
	public int[,] levelData2 = {
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,3,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
	};

	public GameObject[] background1Tiles;
	public GameObject[] background2Tiles;
	public GameObject[] background3Tiles;
	public GameObject[] foreground1Tiles;

	private Transform stageHolder;
	private GameObject tileMapContainerGrid;
	private Tilemap tileMap_Background1;

	void stageSetup()
	{
		stageHolder = new GameObject("Stage").transform;
		tileMapContainerGrid = GameObject.Find("TileMapContainerGrid");
		tileMap_Background1 = GameObject.Find("TileMap_Background1").GetComponent<Tilemap>();//

		gmMapTile[] gmMapTileArray = new gmMapTile[background1Tiles.Length];
		for(int iG = 0; iG < background1Tiles.Length; iG++)
		{
			gmMapTile newTile = (gmMapTile)ScriptableObject.CreateInstance("gmMapTile");
			newTile.prefabObject = background1Tiles[iG];
			gmMapTileArray[iG] = newTile;
		}

		for(int iY = 0; iY < 8; iY++)
		{
			for(int iX = 0; iX < 8; iX++)
			{
				GameObject tempObject0 = background1Tiles[(levelData0[iY,iX])];

				gmMapTile tempTile = gmMapTileArray[(levelData0[iY,iX])];
				if(tempTile == null) Debug.LogError("Wha?");
				if(tileMap_Background1 == null) Debug.LogError("Uh?");
				tileMap_Background1.SetTile(new Vector3Int(iX,8-iY,0),tempTile);
				/*
				GameObject instance = Instantiate(tempObject0, new Vector3(iX,8f-iY,0f), Quaternion.identity) as GameObject;
				instance.transform.SetParent(stageHolder);
				*/
			}
		}
	}

	public void SetupScene(int level)
	{
		stageSetup();
	}



	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}
