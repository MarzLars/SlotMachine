using EventBus;
using TMPro;
using UnityEngine;

public class PlayerCredit : MonoBehaviour
{
    public int credits = 10000;
    public int betAmount = 100;
    public int minBetAmount = 10;
    
    public TMP_Text creditDisplay;
    
    
    EventBinding<ColumnRollEvent> _columnRollBinding;
    EventBinding<RowRollEvent> _rowRollBinding;
    
    void Start()
    {
        // Initialize credit display
        UpdateCreditDisplay();
        
        //Subscribe to Events
        _columnRollBinding = new EventBinding<ColumnRollEvent>(columnRollEvent =>
        {
            SubtractBetAmountFromCredits();
        });
        EventBus<ColumnRollEvent>.Register(_columnRollBinding);

        _rowRollBinding = new EventBinding<RowRollEvent>(rowRollEvent =>
        {
            SubtractBetAmountFromCredits();
        });
        EventBus<RowRollEvent>.Register(_rowRollBinding);
    }
    void OnDisable()
    {
        //Unsubscribe from Events
        EventBus<ColumnRollEvent>.Deregister(_columnRollBinding);
        EventBus<RowRollEvent>.Deregister(_rowRollBinding);
    }

    void SubtractBetAmountFromCredits()
    {
        credits -= betAmount;
        UpdateCreditDisplay();
    }
    void UpdateCreditDisplay()
    {
        creditDisplay.text = $"<color=#32bbff>{betAmount}</color> / {credits}";
    }
    
    public void IncreaseBetAmount(int amount)
    {
        // Special case: if at minimum bet (10), jump to 100
        if (betAmount == minBetAmount)
        {
            betAmount = 100;
        }
        else
        {
            betAmount += amount;
        }
        
        // Ensure bet doesn't exceed available credits
        if (betAmount > credits)
        {
            betAmount = credits;
        }
        UpdateCreditDisplay();
    }
    public void DecreaseBetAmount(int amount)
    {
        betAmount -= amount;
        // Ensure bet doesn't go below minimum
        if (betAmount < minBetAmount)
        {
            betAmount = minBetAmount;
        }
        UpdateCreditDisplay();
    }
}