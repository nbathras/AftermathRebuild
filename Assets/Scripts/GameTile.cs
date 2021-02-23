using UnityEngine;
using UnityEngine.Tilemaps;

public class GameTile {
    public Vector3Int LocalPos { get; private set; }
    public Vector2 WorldPos { get; private set; }
    public TileBase TileBase { get; private set; }
    public string Name { get; private set; }

    public GameTile(Vector3Int localPos, Vector2 worldPos, TileBase tilebase, string name) {
        LocalPos = localPos;
        WorldPos = worldPos;
        Name = name;
    }
}
