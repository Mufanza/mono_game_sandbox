#if OPENGL
#define PS_SHADERMODEL ps_3_0
#else
#define PS_SHADERMODEL ps_4_0_level_9_1
#endif

Texture2D MyTexture;
sampler2D MyTextureSampler = sampler_state
{
    Texture = <MyTexture>;
};

float4 DisplayMyShader(float2 texCoord : TEXCOORD0) : COLOR0
{
    // uncomment this to test that shader does work
    //if (texCoord.y > 0.5)
    //{
    //    return float4(0, 1, 0, 1);
    //}
    
    float4 nos = tex2D(MyTextureSampler, texCoord);
    return nos;
}

technique Technique1
{
    pass Pass1
    {
        PixelShader = compile PS_SHADERMODEL DisplayMyShader();
    }
}