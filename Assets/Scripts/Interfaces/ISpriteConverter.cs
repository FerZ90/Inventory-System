using UnityEngine;

public interface ISpriteConverter
{
    public Sprite ConvertItemBackground(int ID);
    public Sprite ConvertItemIcon(int ID);
}
