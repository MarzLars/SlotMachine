using UnityEngine;
using EventBus;
public class ButtonReelRoll : MonoBehaviour
{
    public int columnIndex = 0;
    public int rowIndex = 0;

    public void RaiseColumnRollEvent()
    {
        EventBus<ColumnRollEvent>.Raise(new ColumnRollEvent {ColumnIndex = columnIndex});
        
    }
    
    public void RaiseRowRollEvent()
    {
        EventBus<RowRollEvent>.Raise(new RowRollEvent {RowIndex = rowIndex});
    }
}