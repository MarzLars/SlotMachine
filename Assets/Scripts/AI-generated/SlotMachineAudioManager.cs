using UnityEngine;
using EventBus;

[RequireComponent(typeof(AudioSource))]
public class SlotMachineAudioManager : MonoBehaviour
{
    [Header("Sound Effect References")]
    [SerializeField] private AudioClip reelRollSound;
    [SerializeField] private AudioClip reelRollCompleteSound;
    [SerializeField] private AudioClip winSound;
    [SerializeField] private AudioClip loseSound;
    
    [Header("Audio Settings")]
    [Range(0f, 1f)]
    [SerializeField] private float reelRollVolume = 0.7f;
    [Range(0f, 1f)]
    [SerializeField] private float reelCompleteVolume = 0.8f;
    [Range(0f, 1f)]
    [SerializeField] private float winVolume = 1f;
    [Range(0f, 1f)]
    [SerializeField] private float loseVolume = 0.6f;
    
    private AudioSource audioSource;
    
    EventBinding<ColumnRollEvent> _columnRollBinding;
    EventBinding<RowRollEvent> _rowRollBinding;
    EventBinding<RollCompleteEvent> _rollCompleteBinding;
    EventBinding<WinEvent> _winBinding;
    EventBinding<LoseEvent> _loseBinding;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
        // Subscribe to events
        _columnRollBinding = new EventBinding<ColumnRollEvent>(OnColumnRoll);
        EventBus<ColumnRollEvent>.Register(_columnRollBinding);
        
        _rowRollBinding = new EventBinding<RowRollEvent>(OnRowRoll);
        EventBus<RowRollEvent>.Register(_rowRollBinding);
        
        _rollCompleteBinding = new EventBinding<RollCompleteEvent>(OnRollComplete);
        EventBus<RollCompleteEvent>.Register(_rollCompleteBinding);
        
        _winBinding = new EventBinding<WinEvent>(OnWin);
        EventBus<WinEvent>.Register(_winBinding);
        
        _loseBinding = new EventBinding<LoseEvent>(OnLose);
        EventBus<LoseEvent>.Register(_loseBinding);
    }
    
    void OnDisable()
    {
        // Unsubscribe from events
        EventBus<ColumnRollEvent>.Deregister(_columnRollBinding);
        EventBus<RowRollEvent>.Deregister(_rowRollBinding);
        EventBus<RollCompleteEvent>.Deregister(_rollCompleteBinding);
        EventBus<WinEvent>.Deregister(_winBinding);
        EventBus<LoseEvent>.Deregister(_loseBinding);
    }
    
    void OnColumnRoll(ColumnRollEvent evt)
    {
        PlayReelRollSound();
    }
    
    void OnRowRoll(RowRollEvent evt)
    {
        PlayReelRollSound();
    }
    
    void OnRollComplete(RollCompleteEvent evt)
    {
        PlayReelRollCompleteSound();
    }
    
    void OnWin(WinEvent evt)
    {
        PlayWinSound();
    }
    
    void OnLose(LoseEvent evt)
    {
        PlayLoseSound();
    }
    
    void PlayReelRollSound()
    {
        if (reelRollSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(reelRollSound, reelRollVolume);
        }
    }
    
    void PlayReelRollCompleteSound()
    {
        if (reelRollCompleteSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(reelRollCompleteSound, reelCompleteVolume);
        }
    }
    
    void PlayWinSound()
    {
        if (winSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(winSound, winVolume);
        }
    }
    
    void PlayLoseSound()
    {
        if (loseSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(loseSound, loseVolume);
        }
    }
}

