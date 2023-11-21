using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

//[ExecuteInEditMode()]
public class Tooltip : MonoBehaviour
{
    public TextMeshProUGUI headerField;

    public TextMeshProUGUI contentField;

    public LayoutElement layoutElement;

    public int characterWrapLimit;

    public RectTransform rectTransform;

    float pivotX = 0;

    public float startPosX = -215;
    float posX;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        //startPosX = rectTransform.position.x;
        posX = startPosX;
    }

    public void SetText(string content, bool pivotLeft, string header = "")
    {
        if (string.IsNullOrEmpty(header))
        {
            headerField.gameObject.SetActive(false);
        }
        else
        {
            headerField.gameObject.SetActive(true);
            headerField.text = header;
        }

        if (pivotLeft)
        {
            //pivotX = 0;
            posX = startPosX;
        }
        else
        {
           //pivotX = 1;
            posX = -startPosX;
        }
            contentField.text = content;

        int headerLength = headerField.text.Length;
        int contentLength = contentField.text.Length;

        layoutElement.enabled = (headerLength > characterWrapLimit || contentLength > characterWrapLimit) ? true : false;
    }
    private void Update()
    {
        if(!Application.isPlaying)
        {
            int headerLength = headerField.text.Length;
            int contentLength = contentField.text.Length;

            layoutElement.enabled = (headerLength > characterWrapLimit || contentLength > characterWrapLimit) ? true : false;
        }

        float positionY = Input.mousePosition.y;
       
        float pivotY = positionY / Screen.height;

        rectTransform.pivot = new Vector2(pivotX, pivotY);
        transform.position = new Vector2(215, positionY);
        //print(rectTransform.pivot);
    }
}
