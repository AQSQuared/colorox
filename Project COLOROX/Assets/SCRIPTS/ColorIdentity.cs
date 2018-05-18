using UnityEngine;
using UnityEngine.UI;

public class ColorIdentity {

    public static void SetColor (string _colorId, Image _imageToColor)
    {
        if (_colorId == "a")
        {
            _imageToColor.color = new Color(1f, 0.3f, 0.3f);
        }

        if (_colorId == "b")
        {
            _imageToColor.color = new Color(0f, 0.66f, 1f);
        }

        if (_colorId == "c")
        {
            _imageToColor.color = new Color(1f, 1f, 0.4f);
        }

        if (_colorId == "ab")
        {
            _imageToColor.color = new Color(0.8f, 0f, 1f);
        }

        if (_colorId == "bc")
        {
            _imageToColor.color = new Color(0f, 1f, 0.44f);
        }

        if (_colorId == "ca")
        {
            _imageToColor.color = new Color(1f, 0.6f, 0.2f);
        }

        if (_colorId == "")
        {
            _imageToColor.color = Color.white;
        }
    }
}
