﻿using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UIElements;

namespace MoreMountains.FeedbacksForThirdParty
{
    /// <summary>
    /// This feedback will let you change the font size of an element on a target UI Document
    /// </summary>
    [AddComponentMenu("")]
    [FeedbackHelp("This feedback will let you change the font size of an element on a target UI Document")]
    [FeedbackPath("UI Toolkit/UITK Font Size")]
    [MovedFrom(false, null, "MoreMountains.Feedbacks.UIToolkit")]
    public class MMF_UIToolkitFontSize : MMF_UIToolkitFloatBase
    {
        protected override void SetValue(float newValue)
        {
            foreach (VisualElement element in _visualElements)
            {
                int newSize = Mathf.FloorToInt(newValue);
                element.style.fontSize = newSize;
                HandleMarkDirty(element);
            }
        }

        protected override float GetInitialValue()
        {
            return _visualElements[0].resolvedStyle.fontSize;
        }
    }
}