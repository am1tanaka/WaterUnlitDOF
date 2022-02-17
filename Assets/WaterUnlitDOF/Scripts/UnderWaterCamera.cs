using UnityEngine;
using UnityEngine.Rendering;

[ExecuteInEditMode]
public class UnderWaterCamera : MonoBehaviour
{
    /// <summary>
    /// RenderTextureのサイズ
    /// </summary>
    static int renderTextureSize => 512;

    /// <summary>
    /// ビット数
    /// </summary>
    static int renderTextureDepth => 24;

    Camera sourceCamera;
    Camera underWaterCamera;
    RenderTexture underWaterTex;
    float currentAspect;

    private void Awake()
    {
        sourceCamera = transform.parent.GetComponent<Camera>();
        underWaterCamera = GetComponent<Camera>();
        underWaterCamera.CopyFrom(sourceCamera);
        underWaterCamera.cullingMask = underWaterCamera.cullingMask & (-1 ^ LayerMask.GetMask("Water"));
        underWaterCamera.clearFlags = CameraClearFlags.Depth;
        underWaterCamera.depth = -100;
        underWaterCamera.depthTextureMode = DepthTextureMode.Depth;
        underWaterCamera.targetTexture = null;
        UpdateRenderTex();
    }

    private void LateUpdate()
    {
        UpdateRenderTex();
        Shader.SetGlobalTexture("_WaterDepthTex", underWaterTex);
    }

    private void OnDestroy()
    {
        DestroyTexture();
    }

    void DestroyTexture()
    {
        if (underWaterCamera.targetTexture != null)
        {
            underWaterCamera.targetTexture = null;
        }
        if (underWaterTex != null)
        {
            DestroyImmediate(underWaterTex);
            underWaterTex = null;
        }
    }

    /// <summary>
    /// RenderTextureを生成
    /// </summary>
    void UpdateRenderTex()
    {
        if ((sourceCamera == null) || (underWaterCamera == null)) return;

        if (underWaterTex != null)
        {
            if (currentAspect != sourceCamera.aspect)
            {
                currentAspect = sourceCamera.aspect;
                DestroyTexture();
            }
            else
            {
                return;
            }
        }
        underWaterTex = new RenderTexture(
            renderTextureSize, renderTextureSize,
            renderTextureDepth,
            RenderTextureFormat.Depth,
            RenderTextureReadWrite.Linear);
        underWaterTex.dimension = TextureDimension.Tex2D;
        underWaterTex.autoGenerateMips = false;
        underWaterTex.anisoLevel = 1;
        underWaterTex.filterMode = FilterMode.Point;
        underWaterTex.wrapMode = TextureWrapMode.Clamp;
        underWaterCamera.aspect = sourceCamera.aspect;
        underWaterCamera.targetTexture = underWaterTex;
        currentAspect = sourceCamera.aspect;
    }
}
