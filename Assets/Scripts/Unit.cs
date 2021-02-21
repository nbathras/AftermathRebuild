public class Unit {
    public static Unit Create(UnitType inUnitType) {
        return new Unit(inUnitType);
    }

    public int Health { get; private set; }
    public UnitType UnitType { get; }

    private Unit(UnitType inUnitType) {
        UnitType = inUnitType;
        Health = inUnitType.Health;
    }

    /**
     * Damages unit and returns whether the unit is alive or not
     * 
     * @param   damage  amount of damage the unit takes
     * @return          after damage is taken, is unit alive
     */
    public bool Damage(int damage) {
        Health -= damage;
        return Health > 0;
    }
}
