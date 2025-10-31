using UnityEngine;
//Created with GitHub Copilot
//Model: ClaudeSonnet 4.5

/* PROMPT:
I have a 5x5 Grid, which is containing 25 children GameObjects with SlotState attached to them. 
I want RowAndColumnSetup.cs to go though all the children and set the correct values on their state. 
So: child 1 to 5 is in Row 1. 6 to 10 is in Row 2 etc.
same for columns.
Child 1, 6, 11, 16, 21 is Column 1 etc.

Context: SlotState.cs
*/

public class RowAndColumnStateSetup : MonoBehaviour
{
    private void Awake()
    {
        SetupRowsAndColumns();
    }

    private void SetupRowsAndColumns()
    {
        int childCount = transform.childCount;
        
        for (int i = 0; i < childCount; i++)
        {
            Transform child = transform.GetChild(i);
            SlotState slotState = child.GetComponent<SlotState>();
            
            if (slotState != null)
            {
                // Calculate row: child index divided by 5, plus 1
                slotState.row = (i / 5) + 1;
                
                // Calculate column: child index modulo 5, plus 1
                slotState.column = (i % 5) + 1;
            }
        }
    }
}