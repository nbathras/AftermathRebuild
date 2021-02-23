using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameTileManager : MonoBehaviour {

    public static GameTileManager instance;

    private Tilemap tilemap;
    private Dictionary<Vector2, GameTile> tiles;

    private void Awake() {
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }
    }

    private void Start() {
        GetGameTiles();
    }

    private void GetGameTiles() {
        tiles = new Dictionary<Vector2, GameTile>();
        
        foreach (Vector3Int pos in tilemap.cellBounds.allPositionsWithin) {

            if (!tilemap.HasTile(pos)) { continue; }
            tiles.Add(
                tilemap.CellToWorld(pos),
                new GameTile(
                    pos,
                    tilemap.CellToWorld(pos),
                    tilemap.GetTile(pos),
                    pos.x + "," + pos.y
                )
            );
        }
    }
}
