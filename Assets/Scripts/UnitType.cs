using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/UnitType", order = 1)]
public class UnitType : ScriptableObject {
    [SerializeField] public string Name { get; }

    [SerializeField] public int Health { get; }
    [SerializeField] public int Attack { get; }
    [SerializeField] public int Noise { get; }
}
