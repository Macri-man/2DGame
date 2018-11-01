using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class gmMapTile : TileBase {

	public GameObject prefabObject;

	public override void RefreshTile (Vector3Int location, ITilemap tilemap) {
	}

	// Update is called once per frame
	public override void GetTileData (Vector3Int location, ITilemap tilemap, ref TileData tileData) {
		tileData.gameObject = prefabObject;
	}
}
