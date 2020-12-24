using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class UI : MonoBehaviour
{

    public GameObject Popup;
    static float clicked = 0;
    static float clicktime = 0;
    static float clickdelay = 0.5f;


    public void ShowPopup()
    {
        if (!Popup.activeInHierarchy)
        {
            Popup.SetActive(true);
            Popup.transform.SetAsLastSibling();
            Popup.GetComponent<RectTransform>().sizeDelta = new Vector2(1000, 600); //new Vector2(Screen.width / 2, Screen.height / 2);       
        }
    }


    public void ClosePopup()
    {
        Popup.SetActive(false);
    }


    public static bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }


    public static bool DoubleClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clicked++;
            if (clicked == 1) clicktime = Time.time;
        }
        if (clicked > 1 && Time.time - clicktime < clickdelay)
        {
            clicked = 0;
            clicktime = 0;
            return true;
        }
        else if (clicked > 2 || Time.time - clicktime > 1)
        {
            clicked = 0;
        }
        return false;
    }

}
