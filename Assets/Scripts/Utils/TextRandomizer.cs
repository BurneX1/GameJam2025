using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextRandomizer : MonoBehaviour
{
    public Text txt;
    public string[] texts;
    // Start is called before the first frame update
    private void OnEnable()
    {
        if(txt!=null && texts.Length>0)txt.text = texts[Random.Range(0,texts.Length)];
    }

}
