// Wireframe Shader <https://u3d.as/26T8>
// Copyright (c) Amazing Assets <https://amazingassets.world>

using UnityEditor;
using UnityEngine;


namespace AmazingAssets.WireframeShader.Editor
{
    static public class EditorResources
    {
        #region Textures
        private static Texture2D iconManual;
        static internal Texture2D IconManual
        {
            get
            {
                if (iconManual == null)
                    iconManual = EditorUtilities.LoadIcon("Manual");

                return iconManual;
            }
        }
        private static Texture2D iconForum;
        static internal Texture2D IconForum
        {
            get
            {
                if (iconForum == null)
                    iconForum = EditorUtilities.LoadIcon("Forum");


                return iconForum;
            }
        }
        private static Texture2D iconSupport;
        static internal Texture2D IconSupport
        {
            get
            {
                if (iconSupport == null)
                    iconSupport = EditorUtilities.LoadIcon("Support");

                return iconSupport;
            }
        }
        private static Texture2D iconRate;
        static internal Texture2D IconRate
        {
            get
            {
                if (iconRate == null)
                    iconRate = EditorUtilities.LoadIcon("Rate");

                return iconRate;
            }
        }
        private static Texture2D iconMore;
        static internal Texture2D IconMore
        {
            get
            {
                if (iconMore == null)
                    iconMore = EditorUtilities.LoadIcon("More");

                return iconMore;
            }
        }
        private static Texture2D iconNone;
        static internal Texture2D IconNone
        {
            get
            {
                if (iconNone == null)
                    iconNone = EditorUtilities.LoadIcon(UnityEditor.EditorGUIUtility.isProSkin ? "None_Pro" : "None_Light");

                return iconNone;
            }
        }
        private static Texture2D iconFolder;
        static internal Texture2D IconFolder
        {
            get
            {
                if (iconFolder == null)
                    iconFolder = EditorUtilities.LoadIcon(UnityEditor.EditorGUIUtility.isProSkin ? "Folder_Pro" : "Folder_Light");

                return iconFolder;
            }
        }
        private static Texture2D iconSelected;
        static internal Texture2D IconSelected
        {
            get
            {
                if (iconSelected == null)
                    iconSelected = EditorUtilities.LoadIcon("Selected");

                return iconSelected;
            }
        }
        private static Texture2D iconError;
        static internal Texture2D IconError
        {
            get
            {
                if (iconError == null)
                    iconError = EditorUtilities.LoadIcon("Error");

                return iconError;
            }
        }
        private static Texture2D iconYes;
        static internal Texture2D IconYes
        {
            get
            {
                if (iconYes == null)
                    iconYes = EditorUtilities.LoadIcon("Yes");

                return iconYes;
            }
        }
        private static Texture2D iconNo;
        static internal Texture2D IconNo
        {
            get
            {
                if (iconNo == null)
                    iconNo = EditorUtilities.LoadIcon("No");

                return iconNo;
            }
        }
        private static Texture2D iconYesDisabled;
        static internal Texture2D IconYesDisabled
        {
            get
            {
                if (iconYesDisabled == null)
                    iconYesDisabled = EditorUtilities.LoadIcon("YesDisabled");

                return iconYesDisabled;
            }
        }
        private static Texture2D iconWarning;
        static internal Texture2D IconWarning
        {
            get
            {
                if (iconWarning == null)
                    iconWarning = EditorUtilities.LoadIcon("Warning");

                return iconWarning;
            }
        }
        private static Texture2D iconHierarchy;
        static internal Texture2D IconHierarchy
        {
            get
            {
                if (iconHierarchy == null)
                    iconHierarchy = EditorUtilities.LoadIcon(UnityEditor.EditorGUIUtility.isProSkin ? "Hierarchy_Pro" : "Hierarchy_Light");

                return iconHierarchy;
            }
        }
        private static Texture2D iconSceneViewVisibilityOff;
        static internal Texture2D IconSceneViewVisibilityOff
        {
            get
            {
                if (iconSceneViewVisibilityOff == null)
                    iconSceneViewVisibilityOff = EditorUtilities.LoadIcon(UnityEditor.EditorGUIUtility.isProSkin ? "VisibilityOff_Pro" : "VisibilityOff_Light");

                return iconSceneViewVisibilityOff;
            }
        }
        private static Texture2D iconSceneViewVisibilityOn;
        static internal Texture2D IconSceneViewVisibilityOn
        {
            get
            {
                if (iconSceneViewVisibilityOn == null)
                    iconSceneViewVisibilityOn = EditorUtilities.LoadIcon(UnityEditor.EditorGUIUtility.isProSkin ? "VisibilityOn_Pro" : "VisibilityOn_Light");

                return iconSceneViewVisibilityOn;
            }
        }

        private static Texture2D iconWireframe;
        static internal Texture2D IconWireframe
        {
            get
            {
                if (iconWireframe == null)
                    iconWireframe = EditorUtilities.LoadIcon("Wireframe");

                return iconWireframe;
            }
        }
        private static Texture2D iconDistanceFade;
        static internal Texture2D IconDistanceFade
        {
            get
            {
                if (iconDistanceFade == null)
                    iconDistanceFade = EditorUtilities.LoadIcon("Distance");

                return iconDistanceFade;
            }
        }
        private static Texture2D iconMaskPlane;
        static internal Texture2D IconMaskPlane
        {
            get
            {
                if (iconMaskPlane == null)
                    iconMaskPlane = EditorUtilities.LoadIcon("Plane");

                return iconMaskPlane;
            }
        }
        private static Texture2D iconMaskSphere;
        static internal Texture2D IconMaskSphere
        {
            get
            {
                if (iconMaskSphere == null)
                    iconMaskSphere = EditorUtilities.LoadIcon("Sphere");

                return iconMaskSphere;
            }
        }
        private static Texture2D iconMaskBox;
        static internal Texture2D IconMaskBox
        {
            get
            {
                if (iconMaskBox == null)
                    iconMaskBox = EditorUtilities.LoadIcon("Box");

                return iconMaskBox;
            }
        }
        #endregion

        #region Colors
        static public Color disabledRectColor = UnityEditor.EditorGUIUtility.isProSkin ? new Color(0.4f, 0.4f, 0.4f, 0.5f) : new Color(0.05f, 0.05f, 0.05f, 0.075f);
        static public Color projectRelatedPathColor = new(0.08f, 0.62f, 1, 0.59f);
        static public Color groupHighLightColor = UnityEditor.EditorGUIUtility.isProSkin ? (new Color(0, 0, 0, 0.3f)) : (Color.gray * 0.15f);
        #endregion

        #region GUIStyles
        private static GUIStyle guiStyleFoldoutBold;
        static internal GUIStyle GUIStyleFoldoutBold
        {
            get
            {
                if (guiStyleFoldoutBold == null)
                {
                    guiStyleFoldoutBold = new GUIStyle(EditorStyles.foldout);
                    guiStyleFoldoutBold.fontStyle = FontStyle.Bold;
                    guiStyleFoldoutBold.richText = true;
                }

                return guiStyleFoldoutBold;
            }
        }

        private static GUIStyle guiStyleSeparator;
        static internal GUIStyle GUIStyleSeparator
        {
            get
            {
                if (guiStyleSeparator == null)
                    guiStyleSeparator = new GUIStyle("sv_iconselector_sep");

                return guiStyleSeparator;
            }
        }

        private static GUIStyle guiStyleLockButton;
        static internal GUIStyle GUIStyleLockButton
        {
            get
            {
                if (guiStyleLockButton == null)
                    guiStyleLockButton = "IN LockButton";

                return guiStyleLockButton;
            }
        }

        private static GUIStyle guiStyleMeshIndex;
        static internal GUIStyle GUIStyleMeshIndex
        {
            get
            {
                if (guiStyleMeshIndex == null)
                {
                    guiStyleMeshIndex = new GUIStyle(EditorStyles.centeredGreyMiniLabel);

                    if (UnityEditor.EditorGUIUtility.isProSkin)
                        guiStyleMeshIndex.normal.textColor = Color.black;
                }
                if (guiStyleMeshIndex.normal.background == null)
                {
                    guiStyleMeshIndex.normal.background = new Texture2D(1, 1);
                    guiStyleMeshIndex.normal.background.SetPixels(new Color[] { Color.yellow * (UnityEditor.EditorGUIUtility.isProSkin ? 0.85f : 1) });
                    guiStyleMeshIndex.normal.background.Apply();
                }

                return guiStyleMeshIndex;
            }
        }
        private static GUIStyle guiStyleCenteredGreyMiniLabel;
        static internal GUIStyle GUIStyleCenteredGreyMiniLabel
        {
            get
            {
                if (guiStyleCenteredGreyMiniLabel == null)
                {
                    guiStyleCenteredGreyMiniLabel = new GUIStyle(EditorStyles.centeredGreyMiniLabel);

                    if (UnityEditor.EditorGUIUtility.isProSkin)
                        guiStyleCenteredGreyMiniLabel.normal.textColor = new Color(1, 1, 1, 0.6f);
                    else
                        guiStyleCenteredGreyMiniLabel.normal.textColor = new Color(0, 0, 0, 0.6f);
                }

                return guiStyleCenteredGreyMiniLabel;
            }
        }
        private static GUIStyle guiStyleToolbarButtonMiddleCenter;
        static internal GUIStyle GUIStyleToolbarButtonMiddleCenter
        {
            get
            {
                if (guiStyleToolbarButtonMiddleCenter == null)
                {
                    guiStyleToolbarButtonMiddleCenter = new GUIStyle(EditorStyles.toolbarButton);
                    guiStyleToolbarButtonMiddleCenter.alignment = TextAnchor.MiddleCenter;
                    guiStyleToolbarButtonMiddleCenter.fontSize = 10;

                    if (UnityEditor.EditorGUIUtility.isProSkin)
                        guiStyleToolbarButtonMiddleCenter.normal.textColor = new Color(1, 1, 1, 0.6f);
                    else
                        guiStyleToolbarButtonMiddleCenter.normal.textColor = new Color(0, 0, 0, 0.6f);
                }

                return guiStyleToolbarButtonMiddleCenter;
            }
        }
        private static GUIStyle guiStyleToolbarButtonMiddleCenterBold;
        static internal GUIStyle GUIStyleToolbarButtonMiddleCenterBold
        {
            get
            {
                if (guiStyleToolbarButtonMiddleCenterBold == null)
                {
                    guiStyleToolbarButtonMiddleCenterBold = new GUIStyle(EditorStyles.toolbarButton);
                    guiStyleToolbarButtonMiddleCenterBold.alignment = TextAnchor.MiddleCenter;
                    guiStyleToolbarButtonMiddleCenterBold.fontStyle = FontStyle.Bold;
                    guiStyleToolbarButtonMiddleCenterBold.fontSize = 10;

                    if (UnityEditor.EditorGUIUtility.isProSkin)
                        guiStyleToolbarButtonMiddleCenterBold.normal.textColor = new Color(1, 1, 1, 0.6f);
                    else
                        guiStyleToolbarButtonMiddleCenterBold.normal.textColor = new Color(0, 0, 0, 0.6f);
                }

                return guiStyleToolbarButtonMiddleCenterBold;
            }
        }
        private static GUIStyle guiStyleBoldLabelMiddleCenterWhite;
        static internal GUIStyle GUIStyleBoldLabelMiddleCenterWhite
        {
            get
            {
                if (guiStyleBoldLabelMiddleCenterWhite == null)
                {
                    guiStyleBoldLabelMiddleCenterWhite = new GUIStyle(EditorStyles.boldLabel);
                    guiStyleBoldLabelMiddleCenterWhite.alignment = TextAnchor.MiddleCenter;
                    guiStyleBoldLabelMiddleCenterWhite.normal.textColor = Color.white * 0.9f;
                }

                return guiStyleBoldLabelMiddleCenterWhite;
            }
        }
        private static GUIStyle guiStyleMiniBoldLabelMiddleCenter;
        static internal GUIStyle GUIStyleMiniBoldLabelMiddleCenter
        {
            get
            {
                if (guiStyleMiniBoldLabelMiddleCenter == null)
                {
                    guiStyleMiniBoldLabelMiddleCenter = new GUIStyle(EditorStyles.miniBoldLabel);
                    guiStyleMiniBoldLabelMiddleCenter.alignment = TextAnchor.MiddleCenter;
                }

                return guiStyleMiniBoldLabelMiddleCenter;
            }
        }
        private static GUIStyle guiStyleCenteredMiniLabelWordWrapped;
        static internal GUIStyle GUIStyleCenteredMiniLabelWordWrapped
        {
            get
            {
                if (guiStyleCenteredMiniLabelWordWrapped == null)
                {
                    guiStyleCenteredMiniLabelWordWrapped = new GUIStyle(EditorStyles.wordWrappedMiniLabel);
                    guiStyleCenteredMiniLabelWordWrapped.alignment = TextAnchor.UpperCenter;
                }


                return guiStyleCenteredMiniLabelWordWrapped;
            }
        }
        #endregion

        #region GUIContent
        static internal GUIContent GUIContentRemoveButton = new("-", "Left click removes current element.\nRight click removes all elements except this one.\n\nCTRL + left click removes all elements above.\nCTRL + right click removes all elements below.");
        static internal GUIContent GUIContentFoldout = new(string.Empty, "ALT + click expands full hierarchy of this object.\nCTRL + click expands full hierarchies of all objects in the list.");
        private static GUIContent guiContentPrefabFlags;
        static internal GUIContent GUIContentPrefabFlags
        {
            get
            {
                if (guiContentPrefabFlags == null)
                    guiContentPrefabFlags = new GUIContent(IconHierarchy, "Replace flag for all children in hierarchy or only root object?");

                if (guiContentPrefabFlags.image == null)
                    guiContentPrefabFlags.image = IconHierarchy;

                return guiContentPrefabFlags;
            }
        }

        private static GUIContent guiContentVisibilityOn;
        static internal GUIContent GUIContentVisibilityOn
        {
            get
            {
                if (guiContentVisibilityOn == null)
                    guiContentVisibilityOn = new GUIContent(IconSceneViewVisibilityOn, "Activate/Deactivate object in the Scene and Hierarchy windows.\n\nALT + click affects all objects in the list.");

                if (guiContentVisibilityOn.image == null)
                    guiContentVisibilityOn.image = IconSceneViewVisibilityOn;

                return guiContentVisibilityOn;
            }
        }

        private static GUIContent guiContentVisibilityOff;
        static internal GUIContent GUIContentVisibilityOff
        {
            get
            {
                if (guiContentVisibilityOff == null)
                    guiContentVisibilityOff = new GUIContent(IconSceneViewVisibilityOff, "Activate/Deactivate object in the Scene and Hierarchy windows.\n\nALT + click affects all objects in the list.");

                if (guiContentVisibilityOff.image == null)
                    guiContentVisibilityOff.image = IconSceneViewVisibilityOff;

                return guiContentVisibilityOff;
            }
        }
        #endregion
    }
}