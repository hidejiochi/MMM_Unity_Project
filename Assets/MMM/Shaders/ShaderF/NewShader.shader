// Shader created with Shader Forge v1.30 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.30;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:3138,x:32814,y:32669,varname:node_3138,prsc:2|emission-8151-OUT;n:type:ShaderForge.SFN_Blend,id:8151,x:32577,y:32724,varname:node_8151,prsc:2,blmd:6,clmp:True|SRC-2989-RGB,DST-4335-RGB;n:type:ShaderForge.SFN_Tex2d,id:2989,x:32359,y:32613,ptovrint:False,ptlb:node_2989,ptin:_node_2989,varname:node_2989,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:cc6f529e71b2a334c8a399a9b23478cf,ntxv:0,isnm:False|UVIN-6294-OUT;n:type:ShaderForge.SFN_Tex2d,id:4335,x:32366,y:32930,ptovrint:False,ptlb:node_4335,ptin:_node_4335,varname:node_4335,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:8cb691146899eb047a0e60d31bb34721,ntxv:0,isnm:False|UVIN-9687-OUT;n:type:ShaderForge.SFN_Vector2,id:2808,x:31927,y:32805,varname:node_2808,prsc:2,v1:1,v2:1;n:type:ShaderForge.SFN_TexCoord,id:6398,x:31927,y:32639,varname:node_6398,prsc:2,uv:0;n:type:ShaderForge.SFN_Multiply,id:6294,x:32129,y:32690,varname:node_6294,prsc:2|A-6398-UVOUT,B-2808-OUT;n:type:ShaderForge.SFN_Multiply,id:9687,x:32184,y:32969,varname:node_9687,prsc:2|A-242-UVOUT,B-2574-OUT;n:type:ShaderForge.SFN_TexCoord,id:242,x:31927,y:32917,varname:node_242,prsc:2,uv:0;n:type:ShaderForge.SFN_Vector2,id:2574,x:31912,y:33101,varname:node_2574,prsc:2,v1:1,v2:1;proporder:2989-4335;pass:END;sub:END;*/

Shader "Shader Forge/NewShader" {
    Properties {
        _node_2989 ("node_2989", 2D) = "white" {}
        _node_4335 ("node_4335", 2D) = "white" {}
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _node_2989; uniform float4 _node_2989_ST;
            uniform sampler2D _node_4335; uniform float4 _node_4335_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float2 node_6294 = (i.uv0*float2(1,1));
                float4 _node_2989_var = tex2D(_node_2989,TRANSFORM_TEX(node_6294, _node_2989));
                float2 node_9687 = (i.uv0*float2(1,1));
                float4 _node_4335_var = tex2D(_node_4335,TRANSFORM_TEX(node_9687, _node_4335));
                float3 emissive = saturate((1.0-(1.0-_node_2989_var.rgb)*(1.0-_node_4335_var.rgb)));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
