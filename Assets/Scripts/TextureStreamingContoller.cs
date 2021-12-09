using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextureStreamingContoller : MonoBehaviour
{
    public Text label_ShowPanel;
    public Toggle toggle_ShowPanel;
    bool show = false;
    public GameObject panel = null;
    // Start is called before the first frame update
    void Start()
    {
        label_ShowPanel.text = show ? "Hide Texture Streaming Panel" : "Show Texture Streaming Panel";
    }

    public void ShowPanel()
    {
        show = toggle_ShowPanel.isOn;
        label_ShowPanel.text = show ? "Hide Texture Streaming Panel" : "Show Texture Streaming Panel";
        if (panel)
            panel.SetActive(show);
    }
}
