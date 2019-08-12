using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RandomText : MonoBehaviour
{
    [SerializeField] string[] messages;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().text = messages[Random.Range(0, messages.Length)];
    }

}
