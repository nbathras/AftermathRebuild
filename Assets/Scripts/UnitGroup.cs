using System.Collections.Generic;
using UnityEngine;

public class UnitGroup : MonoBehaviour {
    [SerializeField] private TMPro.TextMeshPro healthText;

    private Dictionary<UnitType, List<Unit>> unitGroup;

    private void Awake() {
        unitGroup = new Dictionary<UnitType, List<Unit>>();
    }

    private void Start() {
        healthText.SetText(GetHealth().ToString());
    }

    private void AddUnit(Unit unit) {
        if (!unitGroup.ContainsKey(unit.UnitType)) {
            unitGroup[unit.UnitType] = new List<Unit>();
        }
        unitGroup[unit.UnitType].Add(unit);
    }

    private void CreateUnit(UnitType unitType) {
        AddUnit(Unit.Create(unitType));
    }

    public int GetHealth() {
        int health = 0;
        foreach (List<Unit> units in unitGroup.Values) {
            foreach (Unit unit in units) {
                health += unit.Health;
            }
        }
        return health;
    }

    public int GetAttack() {
        int attack = 0;
        foreach (var entry in unitGroup) {
            attack += entry.Value.Count * entry.Key.Attack;
        }
        return attack;
    }

    public int GetNoise() {
        int noise = 0;
        foreach (var entry in unitGroup) {
            noise += entry.Value.Count * entry.Key.Noise;
        }
        return noise;
    }
}
