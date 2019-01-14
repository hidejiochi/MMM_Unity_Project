// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:3138,x:33609,y:31950,varname:node_3138,prsc:2|emission-2747-OUT;n:type:ShaderForge.SFN_Color,id:7241,x:32802,y:32276,ptovrint:False,ptlb:Color,ptin:_Color,varname:_Color,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0.4892647,c3:0.1544118,c4:1;n:type:ShaderForge.SFN_Tex2dAsset,id:5620,x:32202,y:32930,ptovrint:False,ptlb:magma Texture,ptin:_magmaTexture,varname:_magmaTexture,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:bf5691b5fdf83c547af07b110f76e840,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:2061,x:32521,y:32543,varname:_node_2061,prsc:2,tex:bf5691b5fdf83c547af07b110f76e840,ntxv:0,isnm:False|UVIN-6701-OUT,TEX-5620-TEX;n:type:ShaderForge.SFN_Tex2d,id:1159,x:32510,y:32722,varname:_node_1159,prsc:2,tex:bf5691b5fdf83c547af07b110f76e840,ntxv:0,isnm:False|UVIN-3608-OUT,TEX-5620-TEX;n:type:ShaderForge.SFN_Subtract,id:8793,x:32744,y:32775,varname:node_8793,prsc:2|A-2061-RGB,B-1159-RGB;n:type:ShaderForge.SFN_Multiply,id:1206,x:32254,y:32424,varname:node_1206,prsc:2|A-753-OUT,B-3931-OUT;n:type:ShaderForge.SFN_ValueProperty,id:3931,x:31909,y:32739,ptovrint:False,ptlb:size 1,ptin:_size1,varname:_size1,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:4880,x:32062,y:32725,varname:node_4880,prsc:2|A-9768-OUT,B-765-OUT;n:type:ShaderForge.SFN_Vector2,id:6580,x:31926,y:32586,varname:node_6580,prsc:2,v1:0.33,v2:0.33;n:type:ShaderForge.SFN_Add,id:9768,x:32090,y:32508,varname:node_9768,prsc:2|A-753-OUT,B-6580-OUT;n:type:ShaderForge.SFN_ValueProperty,id:765,x:31881,y:32880,ptovrint:False,ptlb:size 2,ptin:_size2,varname:_size2,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Time,id:8555,x:31902,y:32293,varname:node_8555,prsc:2;n:type:ShaderForge.SFN_Multiply,id:3026,x:32133,y:32177,varname:node_3026,prsc:2|A-1026-OUT,B-8555-TSL;n:type:ShaderForge.SFN_ValueProperty,id:1026,x:31902,y:32106,ptovrint:False,ptlb:speed 1,ptin:_speed1,varname:_speed1,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Add,id:6701,x:32402,y:32181,varname:node_6701,prsc:2|A-3026-OUT,B-1206-OUT;n:type:ShaderForge.SFN_ValueProperty,id:9293,x:31966,y:32170,ptovrint:False,ptlb:speed 2,ptin:_speed2,varname:_speed2,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:8168,x:32155,y:32304,varname:node_8168,prsc:2|A-9293-OUT,B-8555-TSL;n:type:ShaderForge.SFN_Add,id:3608,x:32254,y:32666,varname:node_3608,prsc:2|A-8168-OUT,B-4880-OUT;n:type:ShaderForge.SFN_Clamp01,id:8745,x:33107,y:32523,varname:node_8745,prsc:2|IN-9181-OUT;n:type:ShaderForge.SFN_Lerp,id:2747,x:33215,y:32256,varname:node_2747,prsc:2|A-74-OUT,B-8567-OUT,T-8745-OUT;n:type:ShaderForge.SFN_Color,id:1270,x:32802,y:32064,ptovrint:False,ptlb:Color 2,ptin:_Color2,varname:_Color2,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5367647,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Multiply,id:8567,x:33035,y:32262,varname:node_8567,prsc:2|A-7241-RGB,B-2370-OUT;n:type:ShaderForge.SFN_Multiply,id:74,x:33035,y:32048,varname:node_74,prsc:2|A-1270-RGB,B-3881-OUT;n:type:ShaderForge.SFN_ValueProperty,id:2370,x:32653,y:32320,ptovrint:False,ptlb:power 1,ptin:_power1,varname:_power1,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_ValueProperty,id:3881,x:32625,y:32155,ptovrint:False,ptlb:power 2,ptin:_power2,varname:_power2,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_FragmentPosition,id:1006,x:31477,y:32348,varname:node_1006,prsc:2;n:type:ShaderForge.SFN_Append,id:753,x:31729,y:32468,varname:node_753,prsc:2|A-1006-X,B-1006-Z;n:type:ShaderForge.SFN_Add,id:5433,x:32973,y:32692,varname:node_5433,prsc:2|A-3031-OUT,B-8793-OUT;n:type:ShaderForge.SFN_Blend,id:3031,x:32775,y:32532,varname:node_3031,prsc:2,blmd:15,clmp:True|SRC-2061-RGB,DST-1159-RGB;n:type:ShaderForge.SFN_Lerp,id:9181,x:33165,y:32692,varname:node_9181,prsc:2|A-5433-OUT,B-8793-OUT,T-8932-OUT;n:type:ShaderForge.SFN_Vector1,id:8932,x:33128,y:32865,varname:node_8932,prsc:2,v1:0.35;proporder:7241-5620-3931-765-1026-9293-1270-2370-3881;pass:END;sub:END;*/

Shader "cyberDie/magma" {
    Properties {
        _Color ("Color", Color) = (1,0.4892647,0.1544118,1)
        _magmaTexture ("magma Texture", 2D) = "white" {}
        _size1 ("size 1", Float ) = 1
        _size2 ("size 2", Float ) = 1
        _speed1 ("speed 1", Float ) = 1
        _speed2 ("speed 2", Float ) = 1
        _Color2 ("Color 2", Color) = (0.5367647,0,0,1)
        _power1 ("power 1", Float ) = 1
        _power2 ("power 2", Float ) = 1
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
            uniform float4 _TimeEditor;
            uniform float4 _Color;
            uniform sampler2D _magmaTexture; uniform float4 _magmaTexture_ST;
            uniform float _size1;
            uniform float _size2;
            uniform float _speed1;
            uniform float _speed2;
            uniform float4 _Color2;
            uniform float _power1;
            uniform float _power2;
            struct VertexInput {
                float4 vertex : POSITION;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos(v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float4 node_8555 = _Time + _TimeEditor;
                float2 node_753 = float2(i.posWorld.r,i.posWorld.b);
                float2 node_6701 = ((_speed1*node_8555.r)+(node_753*_size1));
                float4 _node_2061 = tex2D(_magmaTexture,TRANSFORM_TEX(node_6701, _magmaTexture));
                float2 node_3608 = ((_speed2*node_8555.r)+((node_753+float2(0.33,0.33))*_size2));
                float4 _node_1159 = tex2D(_magmaTexture,TRANSFORM_TEX(node_3608, _magmaTexture));
                float3 node_8793 = (_node_2061.rgb-_node_1159.rgb);
                float3 emissive = lerp((_Color2.rgb*_power2),(_Color.rgb*_power1),saturate(lerp((saturate(( _node_2061.rgb > 0.5 ? max(_node_1159.rgb,2.0*(_node_2061.rgb-0.5)) : min(_node_1159.rgb,2.0*_node_2061.rgb) ))+node_8793),node_8793,0.35)));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
