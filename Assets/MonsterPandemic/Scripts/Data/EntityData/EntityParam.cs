
public class EntityParam
{
    public int level;
    public string name;
    public Range range;
}

public enum MoveType
{
    Straight,
    Curved,
    Bouncing,
    Homing,
    Spiral,
    Split,
    Blink,
}
public enum Usage
{
    Automation,
    Single,
    Instant,
    TapToFire
}

public enum Range
{
    WholeLaneToTheRight,
    WholeLaneToTheLeft,
    Lobbed,
    ThreeLaneToTheLeft,
    ThreeLaneToTheRight,
    FrontAndBack,
    OnContact,
    Close,
    OwnTile
}

public enum SpeedRate
{
    None,
    TurtleSpeed,
    SlowPace,
    ModerateSpeed,
    SwiftRate,
    RapidVelocity,
    TurboBoost,
    AgileFlow,
    LightningSprint
}

public enum AttackRate
{
    Fragile,
    Average,
    Solid,
    Protected,
    Dense,
    Hardened,
    Machined,
    Great,
    Undying,
    UltraUndying
}

public enum Area
{
    Single,
    FullBoard,
    ThreeByThree,
    TwoByThree,
    OneByOne
        
}

public enum Effect
{
    None,
    Stune,
    Freeze,
    Knockback,
    Poison,
    Stall
}