using UnityEngine;
using EventBus;

public class SlotState : MonoBehaviour
{
    public int column;
    public int row;
    
    public int slotValue;
    
    [Tooltip("Maximum number of possible slot values (should match number of icon sprites)")]
    [Min(1)]
    public int maxSlotValue = 3;

    EventBinding<ColumnRollEvent> _columnRollBinding;
    EventBinding<RowRollEvent> _rowRollBinding;
    
    IconUpdater _iconUpdater;
    
    void Start()
    {
        _iconUpdater = GetComponent<IconUpdater>();
        
        //Subscribe to Events
        _columnRollBinding = new EventBinding<ColumnRollEvent>(columnRollEvent =>
        {
            if (columnRollEvent.ColumnIndex == column)
            {
                UpdateSlotState();
            }
        });
        EventBus<ColumnRollEvent>.Register(_columnRollBinding);
        
        _rowRollBinding = new EventBinding<RowRollEvent>(rowRollEvent =>
        {
            if (rowRollEvent.RowIndex == row)
            {
                UpdateSlotState();
            }
        });
        EventBus<RowRollEvent>.Register(_rowRollBinding);
    }

    void OnDisable()
    {
        //Unsubscribe from Events
        EventBus<ColumnRollEvent>.Deregister(_columnRollBinding);
        EventBus<RowRollEvent>.Deregister(_rowRollBinding);
    }

    void UpdateSlotState()
    {
        // Temporary random value for testing
        slotValue = Random.Range(0, maxSlotValue);

        _iconUpdater.UpdateSprite(slotValue);
    } 
}