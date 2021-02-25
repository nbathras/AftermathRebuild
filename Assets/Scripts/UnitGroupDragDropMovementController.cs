using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(UnitGroup))]
public class UnitGroupDragDropMovementController : MonoBehaviour {

    [SerializeField] private Tilemap highlightTilemap;
    [SerializeField] private TileBase highlightTile;
    private List<Vector3Int> previousHighlightPositions;

    private UnitGroup unitGroup;

    private Vector2 initialPosition;
    private Vector2 delta;
    private Vector2 mousePosition;

    private void Awake() {
        previousHighlightPositions = new List<Vector3Int>();
        unitGroup = GetComponent<UnitGroup>();
    }

    private void Start() {
        initialPosition = transform.position;
    }

    private void OnMouseDown() {
        if (unitGroup.canMove) {
            initialPosition = transform.position;
            delta = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            GenerateMovePositions();
        }
    }

    private void OnMouseDrag() {
        if (unitGroup.canMove) {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePosition - delta;
        }
    }

    private void OnMouseUp() {
        if (unitGroup.canMove) {
            AttemptToMove();
            ClearMovePositions();
        }
    }

    private void AttemptToMove() {
        if (previousHighlightPositions.Contains(highlightTilemap.WorldToCell(transform.position))) {
            transform.position = highlightTilemap.CellToWorld(highlightTilemap.WorldToCell(transform.position));
            unitGroup.canMove = false;
        } else {
            transform.position = initialPosition;
        }
    }

    private void GenerateMovePositions() {
        ClearMovePositions();

        Vector3Int currentPlayerTile = highlightTilemap.WorldToCell(transform.position);

        Vector3Int[] neighborsEven = new Vector3Int[] {
            new Vector3Int(-1, -1, 0),
            new Vector3Int(-1, 0, 0),
            new Vector3Int(-1, 1, 0),
            new Vector3Int(0, -1, 0),
            new Vector3Int(1, 0, 0),
            new Vector3Int(0, 1, 0),
        };
        Vector3Int[] neighborsOdd = new Vector3Int[] {
            new Vector3Int(0, -1, 0),
            new Vector3Int(-1, 0, 0),
            new Vector3Int(0, 1, 0),
            new Vector3Int(1, -1, 0),
            new Vector3Int(1, 0, 0),
            new Vector3Int(1, 1, 0),
        };

        Vector3Int[] neighborsToUse;
        if (Mathf.Abs(currentPlayerTile.y) % 2 == 0) {
            neighborsToUse = neighborsEven;
        } else {
            neighborsToUse = neighborsOdd;
        }

        foreach (Vector3Int n in neighborsToUse) {
            if (GameTileManager.instance.IsTileMoveable(currentPlayerTile + n)) {
                highlightTilemap.SetTile(currentPlayerTile + n, highlightTile);
                previousHighlightPositions.Add(currentPlayerTile + n);
            }
        }
    }

    private void ClearMovePositions() {
        foreach (Vector3Int tilePosition in previousHighlightPositions) {
            highlightTilemap.SetTile(tilePosition, null);
        }
        previousHighlightPositions = new List<Vector3Int>();
    }
}
