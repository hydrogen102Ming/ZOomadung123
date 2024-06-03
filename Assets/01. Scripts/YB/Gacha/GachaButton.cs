using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class GachaButton : MonoBehaviour
{
    public GameObject canvas;

    private void OnMouseDown()
    {
        if(canvas != null)
        {
            canvas.SetActive(true);
        }
    }
}
