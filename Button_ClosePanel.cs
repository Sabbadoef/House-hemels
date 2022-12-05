using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_ClosePanel : MonoBehaviour
{
    [SerializeField] GameObject panel;

   public void Close()
    {
        panel.SetActive(false);

        if (Time.timeScale == 0f)
            Time.timeScale = 1f;
    }
}
