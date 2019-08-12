using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultMouseHandler : MonoBehaviour
{

    private void OnMouseDown()
    {
        FindObjectOfType<UIAudioLibrary>().playSpeech(0);
    }
}
