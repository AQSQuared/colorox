using UnityEngine;
using UnityEngine.UI;

public class WallBehaviour : MonoBehaviour {

    public string colorIdentityOfWall;

    private void Start()
    {
        SetWallColor();
    }

    private void Update()
    {
        GetComponent<BoxCollider2D>().size = GetComponent<RectTransform>().sizeDelta;
    }

    public void SetWallColor ()
    {
        ColorIdentity.SetColor(colorIdentityOfWall, this.GetComponent<Image>());
    }
}
