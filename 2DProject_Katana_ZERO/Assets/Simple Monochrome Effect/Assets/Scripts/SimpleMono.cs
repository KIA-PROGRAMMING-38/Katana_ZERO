using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

namespace Dinosauria
{
    [Serializable]
    public class PatternOption
    {
        public string Name;
        public bool Activated;
    }
    
    [ExecuteInEditMode]
    [RequireComponent(typeof(Camera))]
    [HelpURL("")]
    [AddComponentMenu("SimpleMono")]
    public class SimpleMono : MonoBehaviour
    {

        private Shader _shader;
        private Material _material;

        public int ColorFilter;
        public int Channel;
        public Color GrayScaleColor = Color.white;
        public int Pattern;





        public PatternOption[] PatternOptions =
        {
            new PatternOption {Name = "H. Waves"},
            new PatternOption {Name = "V. Waves"},
            new PatternOption {Name = "P. Diagonal Waves"},
            new PatternOption {Name = "N. Diagonal Waves"},
        };
        
        
        
        public float Luminosity;
        public float RedBalance;
        public float GreenBalance;
        public float BlueBalance;
        public float Frequency;
        public float MinThreshold = 0.6f;
        
        public bool Negative;
        public bool StepEnabled;
        public float StepBlack = 0;
        public float StepWhite = 1;

        // Start is called before the first frame update
        private void Start()
        {
            _shader = Shader.Find("dinosauria/SimpleMonochrome");
            _material = CreateMaterial(_shader);
        }

        private void OnRenderImage(RenderTexture source, RenderTexture destination)
        {
            _material.SetInt("color_filter", ColorFilter);
            _material.SetInt("channel", Channel);
            _material.SetColor("grayscale_color", GrayScaleColor);
            _material.SetInt("pattern", Pattern);
            
            _material.SetInt("patternHWaveOption", Convert.ToInt32(PatternOptions[0].Activated));
            _material.SetInt("patternVWaveOption", Convert.ToInt32(PatternOptions[1].Activated));
            _material.SetInt("patternPDWaveOption", Convert.ToInt32(PatternOptions[2].Activated));
            _material.SetInt("patternPNWaveOption", Convert.ToInt32(PatternOptions[3].Activated));
            
            _material.SetFloat("luminosity", Luminosity);
            _material.SetFloat("red_balance", RedBalance);
            _material.SetFloat("green_balance", GreenBalance);
            _material.SetFloat("blue_balance", BlueBalance);
            
            _material.SetFloat("frequency", Frequency);
            _material.SetFloat("min_threshold", MinThreshold);
            
            _material.SetInt("negative_enabled", Convert.ToInt32(Negative));
            _material.SetInt("step_enabled", Convert.ToInt32(StepEnabled));
            _material.SetFloat("step_black", StepBlack);
            _material.SetFloat("step_white", StepWhite);
            
            Graphics.Blit(source, destination, _material, 0);
        }

        private static Material CreateMaterial(Shader shader)
        {
            return !shader ? null : new Material(shader) {hideFlags = HideFlags.HideAndDontSave};
        }

    }

    #if UNITY_EDITOR
    
    // custom gui for inspector
    [CustomEditor(typeof(SimpleMono))]
    public class BlackWhiteEditor : Editor
    {

        private readonly GUIContent[] colorFilterLabels =
        {
            new GUIContent("None"),
            new GUIContent("Black & White"),
            
            new GUIContent("Red Copper"),
            
            new GUIContent("Cemetery"),
            new GUIContent("Light Blue"),
            new GUIContent("Dust"),
            new GUIContent("Mars"),
            new GUIContent("Livid"),

            new GUIContent("Bones"),
            new GUIContent("Sweet Night"),
            new GUIContent("Sweet Dust"),
            new GUIContent("Jupiter"),
            new GUIContent("Zombie"),
            
        };
        
        // names appearing in the dropdown menu
        private readonly GUIContent[] channelLabels =
        {
            new GUIContent("RGB"),
            new GUIContent("Red"),
            new GUIContent("Green"),
            new GUIContent("Blue"),
            new GUIContent("Yellow"),
            new GUIContent("Cyan"),
            new GUIContent("Magenta")
        };
        
        private readonly GUIContent[] patternLabels =
        {
            new GUIContent("None"),
            new GUIContent("Squares"),
            new GUIContent("H. Waves"),
            new GUIContent("V. Waves"),
            new GUIContent("P. Diagonal Waves"),
            new GUIContent("N. Diagonal Waves"),
            new GUIContent("C"),
            new GUIContent("Cross Stitch"),
            new GUIContent("Diagonal Stitch")
        };

        // label and tooltip for the dropdown menu
        private readonly GUIContent colorFilterPopLabel = new GUIContent("Color filter", "Color filter");
        private readonly GUIContent channelPopLabel = new GUIContent("Channel", "Color grayscale channel");
        private readonly GUIContent patternPopLabel = new GUIContent("Pattern", "Pattern to apply on all view");


        private bool _showLuminosityAndBalances;
        private bool _showPatterns;
        private bool _showPostEffects;
        
        // this method contains the custom gui for editor
        public override void OnInspectorGUI()
        {
            
            var bwBehaviour = (SimpleMono) target;

            EditorGUILayout.Separator();

            
            // Color filter labels
            bwBehaviour.ColorFilter = EditorGUILayout.IntPopup(colorFilterPopLabel , bwBehaviour.ColorFilter, colorFilterLabels, Enumerable.Range(0, colorFilterLabels.Length).ToArray());

            if (bwBehaviour.ColorFilter == 1)
            {
                //Channels
                bwBehaviour.Channel = EditorGUILayout.IntPopup(channelPopLabel, bwBehaviour.Channel, channelLabels,
                    Enumerable.Range(0, channelLabels.Length).ToArray());

                bwBehaviour.GrayScaleColor = EditorGUILayout.ColorField("Color", bwBehaviour.GrayScaleColor);
            }


            _showLuminosityAndBalances = EditorGUILayout.Foldout(_showLuminosityAndBalances, "Luminosity & Balances", true);

            if (_showLuminosityAndBalances)
            {
                bwBehaviour.Luminosity = EditorGUILayout.Slider("Luminosity", bwBehaviour.Luminosity, -1f, 1f);
                bwBehaviour.RedBalance = EditorGUILayout.Slider("Red balance", bwBehaviour.RedBalance, -1f, 1f);
                bwBehaviour.GreenBalance = EditorGUILayout.Slider("Green balance", bwBehaviour.GreenBalance, -1f, 1f);
                bwBehaviour.BlueBalance = EditorGUILayout.Slider("Blue balance", bwBehaviour.BlueBalance, -1f, 1f);
            }

            EditorGUILayout.Separator();
            
            _showPatterns = EditorGUILayout.Foldout(_showPatterns, "Patterns", true);


            if (_showPatterns)
            {

                foreach (var patternOption in bwBehaviour.PatternOptions)
                    patternOption.Activated = EditorGUILayout.Toggle(patternOption.Name, patternOption.Activated);
                
//                //Pattern
//                bwBehaviour.Pattern = EditorGUILayout.IntPopup(patternPopLabel, bwBehaviour.Pattern, patternLabels,
//                    Enumerable.Range(0, patternLabels.Length).ToArray());

//                if (bwBehaviour.Pattern >= 1 && bwBehaviour.Pattern <= 8)
//                {
                    bwBehaviour.Frequency = EditorGUILayout.Slider("frequency", bwBehaviour.Frequency, 0.1f, 5f);
                    bwBehaviour.MinThreshold =
                        EditorGUILayout.Slider("min threshold", bwBehaviour.MinThreshold, 0f, 1f);
//                }
            }

            EditorGUILayout.Separator();

            _showPostEffects = EditorGUILayout.Foldout(_showPostEffects, "Post effects", true);

            if (_showPostEffects)
            {
                bwBehaviour.Negative = EditorGUILayout.Toggle("Negative", bwBehaviour.Negative);
                bwBehaviour.StepEnabled = EditorGUILayout.Toggle("Step", bwBehaviour.StepEnabled);
                
                if (bwBehaviour.StepEnabled)
                {
                    bwBehaviour.StepBlack = EditorGUILayout.Slider("Black", bwBehaviour.StepBlack, 0f, 1f);
                    bwBehaviour.StepWhite = EditorGUILayout.Slider("White", bwBehaviour.StepWhite, 0f, 1f);
                }
            }
            
            if (GUI.changed)
                EditorUtility.SetDirty(target);
        }
    }
    
    #endif
}