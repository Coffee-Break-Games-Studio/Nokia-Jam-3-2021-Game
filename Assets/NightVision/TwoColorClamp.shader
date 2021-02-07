// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Hidden/TwoColorClamp" {
Properties 
{
  _MainTex ("Texture", 2D) = "white" { }
  _LightColor ("Light Color", Color) = (1,1,1,1)
  _DarkColor ("Dark Color", Color) = (1,1,1,1)
}

  SubShader 
  {
    Tags { "Queue"="Transparent" }

    GrabPass
    {
        "_BackgroundTexture"
    }

		// Pass
		// {
		//    ZWrite On
		//    ColorMask 0
		// }
        //Blend OneMinusDstColor OneMinusSrcAlpha //invert blending, so long as FG color is 1,1,1,1
        //BlendOp Add
        
    Pass
    { 
      CGPROGRAM
      #pragma vertex vert
      #pragma fragment frag 
      #include "UnityCG.cginc"

      uniform float4 _LightColor;
      uniform float4 _DarkColor;

      struct vertexInput
      {
        float4 vertex: POSITION;
        float4 color : COLOR;	
      };

      struct fragmentInput
      {
        float4 pos : SV_POSITION;
        float4 grabPos : TEXCOORD0;
      };

      fragmentInput vert( vertexInput i )
      {
        fragmentInput o;
        o.pos = UnityObjectToClipPos(i.vertex);
        o.grabPos = ComputeGrabScreenPos(o.pos);
        return o;
      }

      sampler2D _BackgroundTexture;

      half4 frag( fragmentInput i ) : SV_Target
      {
        half4 bgColor = tex2Dproj(_BackgroundTexture, i.grabPos);
        half3 lightDelta = abs(bgColor.rgb - _LightColor.rgb);
        half3 darkDelta = abs(bgColor.rgb - _DarkColor.rgb);
        half3 color = length(lightDelta) < length(darkDelta) ? _LightColor.rgb : _DarkColor.rgb;
        return half4(color, bgColor.a);
        // if (bgColor == _LightColor) {
        //   return _DarkColor;
        // }
        // if (bgColor == _DarkColor) {
        //   return _LightColor;
        // }
        // return bgColor;
      }

      ENDCG
    }
  }
}

