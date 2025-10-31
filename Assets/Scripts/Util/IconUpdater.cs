using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconUpdater : MonoBehaviour
{
    public Image iconImage;
    public List<Sprite> iconSprites;

    public void UpdateSprite(int slotValue)
    {
        iconImage.sprite = iconSprites[slotValue];
    }
}
