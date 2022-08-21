using System;
using System.Collections.Generic;

public delegate void MovementDelegate(
    float xInput, float yInput, 
    bool isWalking, bool isRunning, bool isIdle, bool isCarrying, 
    ToolEffect toolEffect, 
    bool isUsingToolRight, bool isUsingToolLeft, bool isUsingToolUp, bool isUsingToolDown,
    bool isLiftingToolRight, bool isLiftingToolLeft, bool isLiftingToolUp, bool isLiftingToolDown,
    bool isSwingingToolRight, bool isSwingingToolLeft, bool isSwingingToolUp, bool isSwingingToolDown,
    bool isPickingRight, bool isPickingLeft, bool isPickingUp, bool isPickingDown,
    bool isIdleRight, bool isIdleLeft, bool isIdleUp, bool isIdleDown);

public static class EventHandler
{
    // Inventory Updated Event
    public static event Action<InventoryLocation, List<InventoryItem>> InventoryUpdatedEvent;

    public static void CallInventoryUpdatedEvent(InventoryLocation inventoryLocation, List<InventoryItem> inventoryList)
    {
        if(InventoryUpdatedEvent != null)
            InventoryUpdatedEvent(inventoryLocation, inventoryList);
    }

    // Movement Event
    public static event MovementDelegate MovementEvent;

    //Movement Event Call For Publishers;

    public static void CallMovementEvent(
    float xInput, float yInput, 
    bool isWalking, bool isRunning, bool isIdle, bool isCarrying, 
    ToolEffect toolEffect, 
    bool isUsingToolRight, bool isUsingToolLeft, bool isUsingToolUp, bool isUsingToolDown,
    bool isLiftingToolRight, bool isLiftingToolLeft, bool isLiftingToolUp, bool isLiftingToolDown,
    bool isSwingingToolRight, bool isSwingingToolLeft, bool isSwingingToolUp, bool isSwingingToolDown,
    bool isPickingRight, bool isPickingLeft, bool isPickingUp, bool isPickingDown,
    bool isIdleRight, bool isIdleLeft, bool isIdleUp, bool isIdleDown)
    {
        if(MovementEvent != null)
        {
            MovementEvent(xInput, yInput,
            isWalking, isRunning, isIdle, isCarrying,
            toolEffect,
            isUsingToolRight, isUsingToolLeft, isUsingToolUp, isUsingToolDown,
            isLiftingToolRight, isLiftingToolLeft, isLiftingToolUp, isLiftingToolDown,
            isSwingingToolRight, isSwingingToolLeft, isSwingingToolUp, isSwingingToolDown,
            isPickingRight, isPickingLeft, isPickingUp, isPickingDown,
            isIdleRight, isIdleLeft, isIdleUp, isIdleDown);
        }
    }
}