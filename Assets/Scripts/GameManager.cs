using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField] private List<UnitGroup> unitGroups;

    public void NextTurn() {
        Debug.Log("Next Turn");
        foreach (UnitGroup unitGroup in unitGroups) {
            unitGroup.canMove = true;
        }
    }
}
