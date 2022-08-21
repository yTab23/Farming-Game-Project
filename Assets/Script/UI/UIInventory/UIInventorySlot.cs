using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIInventorySlot : MonoBehaviour, IBeginDragHandler, IDragHandler,  IEndDragHandler
{
    private Camera mainCamera;
    private Transform parentItem;
    private GameObject draggedItem;

    public Image inventorySlotHighlight;
    public Image inventorySlotImage;
    public TextMeshProUGUI textMeshProUGUI;

    [SerializeField] private UIInventoryBar inventoryBar = null;
    [HideInInspector] public ItemDetails itemDetails;
    [SerializeField] private GameObject itemPrefab = null;
    [HideInInspector] public int itemQuantity;
    [SerializeField] private int slotNumber = 0;

    private void Start() 
    {
        mainCamera = Camera.main;
        parentItem = GameObject.FindGameObjectWithTag(Tags.ItemsParentTransform).transform;
    }


    /// <summary>
    /// Drops the item (if selected) at the current mouse position. Called by the DropItem event.
    /// </summary>
    private void DropSelectedItemAtMousePosition()
    {
        if (itemDetails != null)
        {
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -mainCamera.transform.position.z));

            //Create item from prefab at mouse position
            GameObject itemGameObject = Instantiate(itemPrefab, worldPosition, Quaternion.identity, parentItem);
            Item item = itemGameObject.GetComponent<Item>();
            item.ItemCode = itemDetails.ItemCode;

            // Remove item from player's inventory
            InventoryManager.Instance.RemoveItem(InventoryLocation.player, item.ItemCode);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(itemDetails != null)
        {
            //Disable keyboard input
            Player.Instance.DisablePlayerInputAndResetMovement();

            //Instantiate gameObject as dragged item
            draggedItem = Instantiate(inventoryBar.inventoryBarDraggedItem, inventoryBar.transform);
            draggedItem.transform.localScale = new Vector3(1f, 1f, 1f);

            // Get image for dragged item
            Image draggedItemImage = draggedItem.GetComponentInChildren<Image>();
            draggedItemImage.sprite = inventorySlotImage.sprite;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        // move game object as dragged item
        if(draggedItem != null)
        {
            draggedItem.transform.position = Input.mousePosition;
        }
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        // Destroy gameObject as dragged item
        if(draggedItem != null)
        {
            Destroy(draggedItem);
     
            // If drag ends over inventory bar, get item dragis over and swap items
            if(eventData.pointerCurrentRaycast.gameObject !=null && eventData.pointerCurrentRaycast.gameObject.GetComponent<UIInventorySlot>() != null)
            {
                // Get the slot number where the drag ended
                int toSlotNumber = eventData.pointerCurrentRaycast.gameObject.GetComponent<UIInventorySlot>().slotNumber;

                // Swap inventory items in inventory list
                InventoryManager.Instance.SwapInventoryItems(InventoryLocation.player, slotNumber, toSlotNumber);
            }
            // else attempt to drop the item if it can bedropped
            else
            {
                if (itemDetails.canBeDropped)
                {
                    // Drop a full stack of items
                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        // Store a temporary stackSize variable
                        int stackSize = itemQuantity;
     
                        for(int i = 0; i < stackSize; i++)
                        {
                            DropSelectedItemAtMousePosition();
                        }
                    }
                    // Drop a single item
                    else
                    {
                        DropSelectedItemAtMousePosition();
                    }
                    
                }
            }
     
            // Enable player input
            Player.Instance.EnablePlayerInput();
        }
    }

}
