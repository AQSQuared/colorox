using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelEditorManager : MonoBehaviour {

    GameObject GO;
    Button editorElement;
    Button lastEditorElement;

    public List<Slider> sliders = new List<Slider>();

    private void Update()
    {
        if(GO != null)
        {
            GO.transform.position = Input.mousePosition;
        }
    }

    public void BackToLevelZero ()
    {
        SceneManager.LoadScene("LevelZero");
    }

    public void TriggerConclusionAnimation()
    {
        GetComponent<Animator>().SetTrigger("Conclusion");
    }

    public void LoadYoutube ()
    {
        Application.OpenURL("https://www.youtube.com/channel/UCdqSRiv3jrEtQ-QG1fBJESQ?view_as=subscriber");
    }

    public void LoadTwitter()
    {
        Application.OpenURL("https://twitter.com/CRIXINUS");
    }

    #region sound_credit

    public void LoadSound()
    {
        Application.OpenURL("https://freesound.org/people/waveplay/sounds/219288/");
    }

    public void LoadArtist()
    {
        Application.OpenURL("https://freesound.org/people/waveplay/");
    }

    public void LoadLicense()
    {
        Application.OpenURL("https://creativecommons.org/licenses/by/3.0/");
    }

    #endregion

    public void AddStuffToTheScene(GameObject _levelElement, Vector3 point)
    {
        if (_levelElement != null)
        {
            GO = Instantiate(_levelElement.gameObject, point, Quaternion.identity, GameObject.Find("Creator").transform);
            editorElement = Instantiate(Resources.Load("editorElement", typeof(Button)), GO.transform.position, Quaternion.identity, GO.transform) as Button;

            if (GO.GetComponent<Button>())
            {
                GO.GetComponent<Button>().enabled = false;
            }

            if (editorElement.transform.parent.GetComponent<Slider>())
            {
                sliders.Add(editorElement.transform.parent.GetComponent<Slider>());
            }
        }

    }

    public void PlaceObject ()
    {
        GO = null;
        if(editorElement != null)
        {
            editorElement.onClick.AddListener(ElementProperties);
        }
        if(lastEditorElement != null)
            lastEditorElement.transform.GetChild(0).gameObject.SetActive(false);

        if(editorElement != null)
            editorElement.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void SetObjectAsElement (Button _element)
    {
        lastEditorElement = editorElement;
        editorElement = _element;
        lastEditorElement.transform.GetChild(0).gameObject.SetActive(false);
        editorElement.transform.GetChild(0).gameObject.SetActive(false);
        lastEditorElement = editorElement;
    }

    private void ElementProperties ()
    {
        string elementName;
        elementName = editorElement.transform.parent.name;

        lastEditorElement.transform.GetChild(0).gameObject.SetActive(false);
        editorElement.transform.GetChild(0).gameObject.SetActive(true);

        editorElement.onClick.RemoveAllListeners();
    }

    public void MoveButton ()
    {
        GO = editorElement.transform.parent.gameObject;
    }

    public void RemoveButton()
    {
        Destroy(editorElement.transform.parent.gameObject);
    }
}
