using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UISaveItem : MonoBehaviour
{
    public static UISaveItem CurrentSaveItem;
    
    private const int TEXTURE_SIZE = 256;
    
    [SerializeField] private RawImage m_picture;
    [SerializeField] private RectTransform m_addSection;
    [SerializeField] private Toggle m_selfToggle;

    public CharacterData CharacterData { get; private set; }
    
    public Toggle SelfToggle => m_selfToggle;
    
    private Texture m_pictureTexture;

    private void Awake()
    {
        GameManager.OnCharacterChanged += UpdatePicture;
    }
    
    private void UpdatePicture(CharacterData charData)
    {
        if (CurrentSaveItem == this && charData != null)
        {
            CharacterData = charData;
            
            StartCoroutine(UpdateWithDelay());
        }
    }

    private IEnumerator UpdateWithDelay()
    {
        yield return new WaitForSeconds(0.05f);
        
        m_pictureTexture = CaptureScreen(GameManager.Instance.PictureCamera);
        m_picture.texture = m_pictureTexture;
    
        m_picture.enabled = true;
    }

    private Texture2D CaptureScreen(Camera picCamera)
    {
        picCamera.enabled = true;
        
        RenderTexture renderTexture = new RenderTexture(TEXTURE_SIZE, TEXTURE_SIZE, 24);
        Rect rect = new Rect(0,0,TEXTURE_SIZE,TEXTURE_SIZE);
        Texture2D texture = new Texture2D(TEXTURE_SIZE, TEXTURE_SIZE, TextureFormat.RGBA32, false);

        picCamera.targetTexture = renderTexture;
        picCamera.Render();

        RenderTexture currentRenderTexture = RenderTexture.active;
        RenderTexture.active = renderTexture;
        texture.ReadPixels(rect, 0, 0);
        texture.Apply();

        picCamera.targetTexture = null;
        RenderTexture.active = currentRenderTexture;
        Destroy(renderTexture);

        picCamera.enabled = false;

        return texture;
    }
}