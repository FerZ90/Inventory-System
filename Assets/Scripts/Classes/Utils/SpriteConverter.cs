using UnityEngine;
using UnityEngine.U2D;

public class SpriteConverter : ISpriteConverter
{
    [SerializeField] SpriteAtlas _itemBackgroundAtlas;
    [SerializeField] SpriteAtlas _itemIconsAtlas;

    public Sprite ConvertItemBackground(int ID)
    {
        return null;
    }

    public Sprite ConvertItemIcon(int ID)
    {
        return null;
    }

    
}
