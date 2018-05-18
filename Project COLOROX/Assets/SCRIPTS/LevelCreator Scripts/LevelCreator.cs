using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour {

    private GameObject levelElement;

	void Update ()
    {
		if(Input.touchCount == 1)
        {
            levelElement = null;
            FindObjectOfType<LevelEditorManager>().PlaceObject();
        }
        if (Input.GetMouseButtonDown(0))
        {
            levelElement = null;
            FindObjectOfType<LevelEditorManager>().PlaceObject();
        }
    }

    public void CreateSelectedObject(GameObject _object)
    {
        levelElement = _object;
        FindObjectOfType<LevelEditorManager>().AddStuffToTheScene(levelElement, Input.mousePosition);
    }
}
