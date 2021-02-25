using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameTileManager : MonoBehaviour {

    public static GameTileManager instance;

    [SerializeField] private Tilemap tilemap;

    private Dictionary<Vector3Int, GameTile> tiles;

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
        tiles = new Dictionary<Vector3Int, GameTile>();
        
        foreach (Vector3Int pos in tilemap.cellBounds.allPositionsWithin) {
            if (!tilemap.HasTile(pos)) { continue; }

            tiles.Add(
                pos,
                new GameTile(
                    pos,
                    tilemap.CellToWorld(pos),
                    tilemap.GetTile(pos),
                    pos.x + "," + pos.y
                )
            );
        }

        Debug.Log(tiles.Count);
    }

    public bool IsTileMoveable(Vector3Int cell) {
        return tiles.ContainsKey(cell);
    }
}
