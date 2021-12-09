using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MipMapStreamSetting : MonoBehaviour
{
    public Text label_Debug;
    public Toggle toogle_Debug;
    public Text label_Support;
    public Text label_Active;
    public Toggle toggle_Active;
    public Text label_RequestMipmapLevel;
    public Text label_DesiredMipmapLevel;
    public Text label_LoadingMipmapLevel;
    public Text label_LoadedMipmapLevel;
    public Text label_MemoryBudget;
    public Text label_RenderersPerFrame;
    public Text label_MaxLevelReduction;
    public Text label_MaxFileIORequests;
    public Text label_DiscardUnusedMips;
    public Toggle toggle_Discard;
    public Text label_MipmapBias;
    public StreamingController streamingController;
    public Text label_CurrentTextureMemory;
    public Text label_DesiredTextureMemory;
    public Text label_TargetTextureMemory;
    public Text label_NonStreamingTextureMemory;
    public Text label_TotalTextureMemory;
    public Text label_StreamingMipmapUploadCount;
    public Text label_NonStreamingTextureCount;
    public Text label_StreamingTextureCount;
    public Text label_StreamingRendererCount;
    public Text label_LoaddingCount;
    public Text label_PendingLoadingCount;
    float refreshTime = 1.0f;
    bool debug = false;
    public Material debugMaterial = null;
    public GameObject root = null;
    // Start is called before the first frame update
    void Start()
    {
        label_Debug.text = debug ? "Debug Mipmap Streaming : On" : "Debug Mipmap Streaming : Off";
        label_Support.text = SystemInfo.supportsMipStreaming ? "Support Mipmap Streaming : True" : "Support Mipmap Streaming : False";
        toggle_Active.SetIsOnWithoutNotify(QualitySettings.streamingMipmapsActive);
        label_Active.text = QualitySettings.streamingMipmapsActive ? "Texture Mipmap Streaming : Active" : "Texture Mipmap Streaming : Deactive";
        //label_RequestMipmapLevel.text = "Requested Mipmap Level : " + Texture2D.requestedMipmapLevel.ToString();
        label_MemoryBudget.text = "Streaming Mipmap Memory Budget : " + QualitySettings.streamingMipmapsMemoryBudget.ToString() + "M";
        label_RenderersPerFrame.text = "Streaming Mipmap Renderers PerFrame : " + QualitySettings.streamingMipmapsRenderersPerFrame.ToString();
        label_MaxLevelReduction.text = "Streaming Mipmap Max Level Reduction : " + QualitySettings.streamingMipmapsMaxLevelReduction.ToString();
        label_MaxFileIORequests.text = "Streaming Mipmap Max File IO Requests : " + QualitySettings.streamingMipmapsMaxFileIORequests.ToString();
        toggle_Discard.SetIsOnWithoutNotify(Texture2D.streamingTextureDiscardUnusedMips);
        label_DiscardUnusedMips.text = Texture2D.streamingTextureDiscardUnusedMips ? "Streaming Texture Discard Unused Mips : True" : "Streaming Texture Discard Unused Mips : False";
        label_MipmapBias.text = "Streaming Mipmap Bias : " + streamingController.streamingMipmapBias.ToString();
        label_CurrentTextureMemory.text = "Current Texture Memory : " + (Texture.currentTextureMemory / 1000000).ToString() + "M";
        label_DesiredTextureMemory.text = "Desired Texture Memory : " + (Texture.desiredTextureMemory / 1000000).ToString() + "M";
        label_TargetTextureMemory.text = "Target Texture Memory : " + (Texture.targetTextureMemory / 1000000).ToString() + "M";
        label_NonStreamingTextureMemory.text = "NonStreaming Texture Memory : " + (Texture.nonStreamingTextureMemory / 1000000).ToString() + "M";
        label_TotalTextureMemory.text = "Total Texture Memory : " + (Texture.totalTextureMemory / 1000000).ToString() + "M";
        label_StreamingMipmapUploadCount.text = "Streaming Mipmap Upload Count : " + Texture.streamingMipmapUploadCount.ToString();
        label_NonStreamingTextureCount.text = "NonStreaming Texture Count : " + Texture.nonStreamingTextureCount.ToString();
        label_StreamingTextureCount.text = "Streaming Texture Count : " + Texture.streamingTextureCount.ToString();
        label_StreamingRendererCount.text = "Streaming Renderer Count : " + Texture.streamingRendererCount.ToString();
        label_LoaddingCount.text = "Streaming Texture Loading Count : " + Texture.streamingTextureLoadingCount.ToString();
        label_PendingLoadingCount.text = "Streaming Texture Pending Loading Count : " + Texture.streamingTexturePendingLoadCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        refreshTime -= Time.deltaTime;
        if (refreshTime <= 0)
        {
            label_CurrentTextureMemory.text = "Current Texture Memory : " + (Texture.currentTextureMemory / 1000000).ToString() + "M";
            label_DesiredTextureMemory.text = "Desired Texture Memory : " + (Texture.desiredTextureMemory / 1000000).ToString() + "M";
            label_TargetTextureMemory.text = "Target Texture Memory : " + (Texture.targetTextureMemory / 1000000).ToString() + "M";
            label_NonStreamingTextureMemory.text = "NonStreaming Texture Memory : " + (Texture.nonStreamingTextureMemory / 1000000).ToString() + "M";
            label_TotalTextureMemory.text = "Total Texture Memory : " + (Texture.totalTextureMemory / 1000000).ToString() + "M";
            label_StreamingMipmapUploadCount.text = "Streaming Mipmap Upload Count : " + Texture.streamingMipmapUploadCount.ToString();
            label_NonStreamingTextureCount.text = "NonStreaming Texture Count : " + Texture.nonStreamingTextureCount.ToString();
            label_StreamingTextureCount.text = "Streaming Texture Count : " + Texture.streamingTextureCount.ToString();
            label_StreamingRendererCount.text = "Streaming Renderer Count : " + Texture.streamingRendererCount.ToString();
            label_LoaddingCount.text = "Streaming Texture Loading Count : " + Texture.streamingTextureLoadingCount.ToString();
            label_PendingLoadingCount.text = "Streaming Texture Pending Loading Count : " + Texture.streamingTexturePendingLoadCount.ToString();
            refreshTime = 1.0f;
        }
    }
    
    public void ToogleDebug()
    {
        debug = toogle_Debug.isOn;
        if (debug)
        {
            ReplaceMaterial(root, debugMaterial);
            label_Debug.text = "Debug Mipmap Streaming : On";
        }
        else
        {
            label_Debug.text = "Debug Mipmap Streaming : Off";
        }
    }
    public void ToggleActive()
    {
        QualitySettings.streamingMipmapsActive = toggle_Active.isOn;
        label_Active.text = QualitySettings.streamingMipmapsActive ? "Texture Mipmap Streaming : Active" : "Texture Mipmap Streaming : Deactive";
    }
    public void ToggleDiscard()
    {
        Texture2D.streamingTextureDiscardUnusedMips = toggle_Discard.isOn;
        label_DiscardUnusedMips.text = Texture2D.streamingTextureDiscardUnusedMips ? "Streaming Texture Discard Unused Mips : True" : "Streaming Texture Discard Unused Mips : False";
    }
    public void AddMemoryBudget16M()
    {
        QualitySettings.streamingMipmapsMemoryBudget += 4;
        if (QualitySettings.streamingMipmapsMemoryBudget >= 1024)
            QualitySettings.streamingMipmapsMemoryBudget = 1024;
        label_MemoryBudget.text = "Streaming Mipmap Memory Budget : " + QualitySettings.streamingMipmapsMemoryBudget.ToString() + "M";

    }
    public void SubMemoryBudget16M()
    {
        QualitySettings.streamingMipmapsMemoryBudget -= 4;
        if (QualitySettings.streamingMipmapsMemoryBudget <=16)
            QualitySettings.streamingMipmapsMemoryBudget = 16;
        label_MemoryBudget.text = "Streaming Mipmap Memory Budget : " + QualitySettings.streamingMipmapsMemoryBudget.ToString() + "M";
    }
    public void Add32RenderersPerFrame()
    {
        QualitySettings.streamingMipmapsRenderersPerFrame += 32;
        if (QualitySettings.streamingMipmapsRenderersPerFrame >= 512)
            QualitySettings.streamingMipmapsRenderersPerFrame = 512;
        label_RenderersPerFrame.text = "Streaming Mipmap Renderers PerFrame : " + QualitySettings.streamingMipmapsRenderersPerFrame.ToString();
    }
    public void Sub32RenderersPerFrame()
    {
        QualitySettings.streamingMipmapsRenderersPerFrame -= 32;
        if (QualitySettings.streamingMipmapsRenderersPerFrame <= 32)
            QualitySettings.streamingMipmapsRenderersPerFrame = 32;
        label_RenderersPerFrame.text = "Streaming Mipmap Renderers PerFrame : " + QualitySettings.streamingMipmapsRenderersPerFrame.ToString();
    }
    public void AddMaxLevelReduction()
    {
        QualitySettings.streamingMipmapsMaxLevelReduction++;
        label_MaxLevelReduction.text = "Streaming Mipmap Max Level Reduction : " + QualitySettings.streamingMipmapsMaxLevelReduction.ToString();
    }
    public void SubMaxLevelReduction()
    {
        QualitySettings.streamingMipmapsMaxLevelReduction--;
        label_MaxLevelReduction.text = "Streaming Mipmap Max Level Reduction : " + QualitySettings.streamingMipmapsMaxLevelReduction.ToString();
    }
    public void Add64MaxFileIORequests()
    {
        QualitySettings.streamingMipmapsMaxFileIORequests += 64;
        if (QualitySettings.streamingMipmapsMaxFileIORequests >= 1024)
            QualitySettings.streamingMipmapsMaxFileIORequests = 1024;
        label_MaxFileIORequests.text = "Streaming Mipmap Max File IO Requests : " + QualitySettings.streamingMipmapsMaxFileIORequests.ToString();
    }
    public void Sub64MaxFileIORequests()
    {
        QualitySettings.streamingMipmapsMaxFileIORequests -= 64;
        if (QualitySettings.streamingMipmapsMaxFileIORequests <= 64)
            QualitySettings.streamingMipmapsMaxFileIORequests = 64;
        label_MaxFileIORequests.text = "Streaming Mipmap Max File IO Requests : " + QualitySettings.streamingMipmapsMaxFileIORequests.ToString();
    }
    public void AddMipmapBias()
    {
        streamingController.streamingMipmapBias++;
        label_MipmapBias.text = "Streaming Mipmap Bias : " + streamingController.streamingMipmapBias.ToString();
    }
    public void SubMipmapBias()
    {
        streamingController.streamingMipmapBias--;
        if (QualitySettings.streamingMipmapsMaxFileIORequests <= 0)
            QualitySettings.streamingMipmapsMaxFileIORequests = 0;
        label_MipmapBias.text = "Streaming Mipmap Bias : " + streamingController.streamingMipmapBias.ToString();
    }
    private void ReplaceMaterial(GameObject go, Material mat)
    {
        if (go.GetComponent<MeshRenderer>() != null)
        {
            Material[] mats = go.GetComponent<MeshRenderer>().materials;
            for (int i = 0; i < mats.Length; i++)
                mats[i] = mat;
            go.GetComponent<MeshRenderer>().materials = mats;
        }

        foreach (Transform child in go.transform)
        {
            ReplaceMaterial(child.gameObject, mat);

            if (child.GetComponent<MeshRenderer>() != null)
            {
                Material[] mats = child.GetComponent<MeshRenderer>().materials;
                for (int i = 0; i < mats.Length; i++)
                    mats[i] = mat;
                child.GetComponent<MeshRenderer>().materials = mats;
            }
        }
    }
}
