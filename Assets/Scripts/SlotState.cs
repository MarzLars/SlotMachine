using UnityEngine;
using EventBus;

public class SlotState : MonoBehaviour
{
    public int column;
    public int row;

    EventBinding<ColumnRollEvent> _columnRollBinding;
    EventBinding<RowRollEvent> _rowRollBinding;
    
    void Start()
    {
        //Subscribe to Events
        EventBus<ColumnRollEvent>.Register(_columnRollBinding);
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
    
    } 
}