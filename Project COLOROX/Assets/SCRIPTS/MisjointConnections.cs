using UnityEngine;
using UnityEngine.UI;

public class MisjointConnections : MonoBehaviour {

    public Slider element01;
    public Slider element02;
    public Scrollbar element02Scrollbar;

    private void FixedUpdate()
    {
        if(element02 != null)
            element02.value = element01.value;

        if (element02Scrollbar != null)
            element02Scrollbar.value = element01.value;
    }
}
