public enum AnimationName
{
    idleUp,
    idleRight,
    idleLeft,
    idleDown,
    walkUp,
    walkRight,
    walkLeft,
    walkDown,
    runUp,
    runLeft,
    runRight,
    runDown,
    useToolUp,
    useToolRight,
    useToolLeft,
    useToolDown,
    swingToolUp,
    swingToolRight,
    swingToolLeft,
    swingToolDown,
    liftToolUp,
    liftToolRight,
    liftToolLeft,
    liftToolDown,
    holdToolUp,
    holdToolRight,
    holdToolLeft,
    holdToolDown,
    pickUp,
    pickRight,
    pickLeft,
    pickDown,
    count
}

public enum CharacterPartAnimator
{
    body,
    arms,
    hair,
    tool,
    hat,
    count
}

public enum PartVariantColour
{
    none, 
    count
}

public enum PartVariantType
{
    none,
    carry,
    hoe,
    pickAxe,
    axe,
    scythe,
    wateringCan,
    count
}

public enum GridBoolProperty
{
    diggable,
    canDropItem,
    canPlaceFurniture,
    isPath,
    isNPCObstacle
}

public enum InventoryLocation
{
    player,
    chest,
    count
}
public enum SceneName
{
    Scene1_Farm,
    Scene2_Field,
    Scene3_Cabin,
}

public enum Season
{
    Spring,
    Summer,
    Autumn,
    Winter,
    none, 
    count
}

public enum ToolEffect
{
    none,
    watering
}

public enum HarvestActionEffect
{
    decidousLeavesFalling,
    pineConesFalling,
    choppingTreeTrunk,
    breakingStone,
    reaping,
    none
}

public enum Direction
{
    up,
    down,
    left,
    right,
    none
}

public enum ItemType
{
    Seed,
    Commodity,
    Watering_tool,
    Hoeing_tool,
    Chopping_tool,
    Breaking_tool,
    Reaping_tool,
    Collecting_tool,
    Reapable_scenary,
    Furniture,
    none,
    count
}