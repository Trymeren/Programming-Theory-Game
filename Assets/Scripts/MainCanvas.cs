using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainCanvas : MonoBehaviour
{
    public TMP_Text uiText;
    public static Vector3 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tempPos = Input.mousePosition - new Vector3(Screen.width / 2, Screen.height / 2, 0);
        mousePos = new Vector3(tempPos.x, tempPos.z, tempPos.y);
        uiText.text = "mouse: " + mousePos;
    }
}
