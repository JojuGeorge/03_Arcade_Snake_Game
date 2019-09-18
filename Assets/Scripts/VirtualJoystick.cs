using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Image bkImage;
    private Image joystickImage;
    private Vector3 inputVector;


    void Start() {
        bkImage = GetComponent<Image>();
        joystickImage = transform.GetChild(0).GetComponent<Image>();
    }

    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(bkImage.rectTransform,
            ped.position, ped.pressEventCamera, out pos)) {

            //Debug.Log("clicked");
            pos.x = (pos.x / bkImage.rectTransform.sizeDelta.x);
            pos.y = (pos.y / bkImage.rectTransform.sizeDelta.y);

            inputVector = new Vector3(pos.x * 2 + 1,0, pos.y * 2 - 1);
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;
        //   Debug.Log(inputVector);

            //moving joystick image
            joystickImage.rectTransform.anchoredPosition = new Vector3(
                inputVector.x * (bkImage.rectTransform.sizeDelta.x / 3),
                inputVector.z * (bkImage.rectTransform.sizeDelta.y / 3));
        }
    }

    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        inputVector = Vector3.zero;
        joystickImage.rectTransform.anchoredPosition = Vector3.zero;
    }

   
    public float Horizontal() {
        if (inputVector.x != 0)
            return inputVector.x;
        else
            return Input.GetAxisRaw("Horizontal");
    }

    public float Vertical() {
        if (inputVector.z != 0)
            return inputVector.z;
        else
            return Input.GetAxisRaw("Vertical");
    }
}
