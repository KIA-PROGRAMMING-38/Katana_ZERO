Shader "dinosauria/SimpleMonochrome" {

	Properties
	{
	    // Camera input texture
		_MainTex("Texture", 2D) = "white" {}
		
	}
    SubShader {
        Pass {

            CGPROGRAM

            #pragma target 3.0
            
			sampler2D _MainTex;

            // Define vertex and fragment funcs
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            //Input parameters
			uniform int color_filter;
			uniform int channel;
			uniform float3 grayscale_color;
			uniform int pattern;
			
			uniform int patternHWaveOption;
			uniform int patternVWaveOption;
			uniform int patternPDWaveOption;
			uniform int patternPNWaveOption;
			
			uniform float luminosity;
			uniform float red_balance;
			uniform float green_balance;
			uniform float blue_balance;
			uniform float frequency;
			uniform float min_threshold;
			uniform int negative_enabled;
			uniform int step_enabled;
			uniform float step_black;
			uniform float step_white;

            // Vertex to fragment structure
            struct v2f {
                half3 worldNormal : TEXCOORD1;
                float4 pos : SV_POSITION;
				float2 uv : TEXCOORD0;
            };

			// Vertex shader
			v2f vert(appdata_base v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.uv = MultiplyUV(UNITY_MATRIX_TEXTURE0, v.texcoord);
				
				o.worldNormal = UnityObjectToWorldNormal(v.normal);
				
				return o;
			}
            
            // Matrix filters
            static float3x3 filters[18] = {
                //B&W RGB - 0
                float3x3(
                    0.333,0.333,0.333,
                    0.333,0.333,0.333,
                    0.333,0.333,0.333),
                //B&W Red - 1
                float3x3(
                    1.0,0.0,0.0,
                    1.0,0.0,0.0,
                    1.0,0.0,0.0),
                //B&W Green - 2
                float3x3(
                    0.0,1.0,0.0,
                    0.0,1.0,0.0,
                    0.0,1.0,0.0),
                //B&W Blue - 3
                float3x3(
                    0.0,0.0,1.0,
                    0.0,0.0,1.0,
                    0.0,0.0,1.0),
                //B&W Yellow - 4
                float3x3(
                    0.5,0.5,0.0,
                    0.5,0.5,0.0,
                    0.5,0.5,0.0),
                //B&W Cyan - 5
                float3x3(
                    0.0,0.5,0.5,
                    0.0,0.5,0.5,
                    0.0,0.5,0.5),
                //B&W Magenta - 6
                float3x3(
                    0.5,0.0,0.5,
                    0.5,0.0,0.5,
                    0.5,0.0,0.5),
                    
                // Red Copper      
                float3x3(
                    1.0,0.0,0.0,
                    0.2,0.0,0.0,
                    0.0,0.0,0.0),
                    
                // Cemetery - 7
                float3x3(
                    0.0,0.2,0.82,
                    0.02,0.16,0.83,
                    0.13,0.10,0.83),
                // Light blue - 8
                float3x3(
                    0.0,0.80,0.0,
                    0.13,0.80,0.03,
                    0.03,0.80,0.23),
                // Dust - 9
                float3x3(
                    0.80,0.2,0.12,
                    0.80,0.23,0.03,
                    0.80,0.00,0.0),
                // Mars - 10
                float3x3(
                    0.80,0.16,0.18,
                    0.80,0.13,0.03,
                    0.80,0.00,0.0),
                // Livid - 11
                float3x3(
                    0.80,0.1,0.12,
                    0.80,0.23,0.03,
                    0.80,0.00,0.0),
                // Bones             
                float3x3(
                    0.0,0.23,0.82,
                    0.0,0.18,0.83,
                    0.0,0.1,0.83),
                // Sweet Night - 12               
                float3x3(
                    0.80,0.1,0.12,
                    0.80,0.23,0.03,
                    0.80,0.18,0.23),
                // Sweet Dust - 12               
                float3x3(
                    0.80,0.23,0.23,
                    0.80,0.18,0.03,
                    0.80,0.1,0.12),
                // Jupiter           
                float3x3(
                    0.80,0.18,0.23,
                    0.80,0.1,0.03,
                    0.80,0.23,0.12),
                // Zombie - 12              
                float3x3(
                    0.0,0.1,0.82,
                    0.0,0.23,0.83,
                    0.0,0.18,0.83),

            };

            
            float3 app(float3 rgb, float screenPos)
            {
                //float s = (sin(mul(screenPos, frequency)) + 1) * 0.5;
                float s = (sin(mul(screenPos, frequency)) + 1) * 0.5;
                float s_clamp = clamp(s, min_threshold, 1);
                return mul(rgb, s_clamp);
            }
            
            float3 app(float3 rgb, float2 screenPos)
            {
//                float2 s = (sin(mul(screenPos, frequency)) + 1) * 0.5;
                float2 s = (sin(mul(screenPos.x + screenPos.y * 10, frequency)) + 1) * 0.5;

                float2 s_clamp = clamp(s, min_threshold, 1);
                return mul(rgb, s_clamp);
            }
            

            // Fragment shader
            half4 frag (v2f i, UNITY_VPOS_TYPE screenPos : SV_POSITION) : SV_Target
            {
                // Read colors from texture
				half4 color = tex2D(_MainTex, i.uv);
								
                float3 x;
                
                float3x3 cur_filter;
                
                // B&W
                if (color_filter == 1)
                {
                    x = mul(filters[channel], color.rgb);
                    x *= grayscale_color;
                }
                // Monochrome specials matrix
                else if (color_filter >= 2)
                    x = x = mul(filters[color_filter + 5], color.rgb);
                // Color
                else
                    x = color.rgb;
                                
                if (patternHWaveOption)
                {
                    x = app(x, screenPos.x);
                }
                
                if (patternVWaveOption)
                {
                    x = app(x, screenPos.y);
                }
                
                if (patternPDWaveOption)
                {
                    x = app(x, screenPos.x + screenPos.y);
                }
                
                if (patternPNWaveOption)
                {
                    x = app(x, screenPos.x - screenPos.y);
                }
				    	
				// Luminosity & Color settings
                x = x + luminosity;
                x = x + float3(red_balance, green_balance, blue_balance);
                
                // Negative value    
				if (negative_enabled)
				    x = 1.0f - x;
				    
                // Smoothstep
				if (step_enabled)
				    x = smoothstep(step_black, step_white, x);
                
                return half4(x, 1.0f);
            }
            
            ENDCG

        }
    }
}