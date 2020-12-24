using UnityEngine;
using UnityEngine.UI;

public class UiDrag : MonoBehaviour
{

    public GameObject Popup;
    private float offsetX;
    private float offsetY;
    

    public void BeginDrag()
    {
        offsetX = transform.position.x - Input.mousePosition.x;
        offsetY = transform.position.y - Input.mousePosition.y;
        Popup.transform.SetAsLastSibling();
    }


    public void OnDrag()
    {
        transform.position = new Vector3(offsetX + Input.mousePosition.x, offsetY + Input.mousePosition.y);

        if (Input.mousePosition.x < 1 || Input.mousePosition.y < 1 
            || Input.mousePosition.x > Screen.width - 10 || Input.mousePosition.y > Screen.height - 10)
        {
            Popup.SetActive(false);
        }
    }


    private void OnMouseDown()
    {
        if (UI.DoubleClick())
        {
            ShowPopup();
        }
    }


    public void ShowPopup()
    {
        Popup.SetActive(true);
        Popup.transform.SetAsLastSibling();
    }

}