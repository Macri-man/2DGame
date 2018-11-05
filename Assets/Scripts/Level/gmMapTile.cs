using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class gmMapTile : TileBase {

	public GameObject prefabObject;

	// Update is called once per frame
	public override void GetTileData (Vector3Int location, ITilemap tilemap, ref TileData tileData) {
		tileData.gameObject = prefabObject;
		tileData.sprite = prefabObject.GetComponent<SpriteRenderer>().sprite;
	}
}
