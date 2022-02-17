Shader "Unlit/ZBufferShader"
{
    SubShader
    {
        Tags { "Queue"="AlphaTest+1"}
        LOD 100

        Pass
        {
            Tags { "LightMode"="ShadowCaster"}

            ZWrite On
            ColorMask 0
        }
    }
}
