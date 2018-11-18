using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;

[CreateAssetMenu(fileName = "New Climbable Tile", menuName = "2DGame/ClimbableTile")]
public class Climbable : TileBase
{

  public GameObject checkTarget;

	private Sprite DisplaySprite;

	// Use this for initialization
	void Awake ()
	{
	}

	public override void RefreshTile(Vector3Int location, ITilemap tilemap)
	{
	}

	public override void GetTileData(Vector3Int location, ITilemap tilemap, ref TileData tileData)
	{
		if(DisplaySprite != null)
		{
			tileData.sprite = DisplaySprite;
		}
	}
}
