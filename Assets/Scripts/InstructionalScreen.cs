/*==============================================================================
            Copyright (c) 2012 QUALCOMM Austria Research Center GmbH.
            All Rights Reserved.
            Qualcomm Confidential and Proprietary

This  Vuforia(TM) sample application in source code form ("Sample Code") for the
Vuforia Software Development Kit and/or Vuforia Extension for Unity
(collectively, the "Vuforia SDK") may in all cases only be used in conjunction
with use of the Vuforia SDK, and is subject in all respects to all of the terms
and conditions of the Vuforia SDK License Agreement, which may be found at
https://ar.qualcomm.at/legal/license.

By retaining or using the Sample Code in any manner, you confirm your agreement
to all the terms and conditions of the Vuforia SDK License Agreement.  If you do
not agree to all the terms and conditions of the Vuforia SDK License Agreement,
then you may not retain or use any of the Sample Code in any manner.
==============================================================================*/

using UnityEngine;
using System.Collections;

public class InstructionalScreen : MonoBehaviour
{
    #region PUBLIC_MEMBER_VARIABLES

    public Texture2D m_smallText;
    public Texture2D m_mediumText;
    public Texture2D m_largeText;

    public Texture2D m_smallStartLabel;
    public Texture2D m_mediumStartLabel;
    public Texture2D m_largeStartLabel;

    public Texture2D m_smallStartLabelPressed;
    public Texture2D m_mediumStartLabelPressed;
    public Texture2D m_largeStartLabelPressed;

    #endregion // PUBLIC_MEMBER_VARIABLES



    #region PRIVATE_MEMBER_VARIABLES

    private Texture2D mText;
    private Texture2D mStartLabel;

    private Rect mTextRect;
    private Rect mStartLabelRect;

    private GUIStyle mButtonStyle;

    private VideoPlaybackController mVideoPlaybackController;

    private bool mShowScreen = true;

    #endregion // PRIVATE_MEMBER_VARIABLES



    #region UNITY_MONOBEHAVIOUR_METHODS

    void Start()
    {
        // Disable the VideoPlaybackController to prevent touches through this screen
        mVideoPlaybackController = GetComponent<VideoPlaybackController>();
        if (mVideoPlaybackController != null) mVideoPlaybackController.enabled = false;

        mButtonStyle = new GUIStyle();

        if (Screen.width > Screen.height)
        {
            // Pick the best text/label size for the screen
            if (Screen.width <= m_smallText.width)
            {
                mText = m_smallText;
                mStartLabel = m_smallStartLabel;

                mButtonStyle.normal.background = m_smallStartLabel;
                mButtonStyle.active.background = m_smallStartLabelPressed;
            }
            else if (Screen.width <= m_mediumText.width)
            {
                mText = m_mediumText;
                mStartLabel = m_mediumStartLabel;

                mButtonStyle.normal.background = m_mediumStartLabel;
                mButtonStyle.active.background = m_mediumStartLabelPressed;
            }
            else
            {
                mText = m_largeText;
                mStartLabel = m_largeStartLabel;

                mButtonStyle.normal.background = m_largeStartLabel;
                mButtonStyle.active.background = m_largeStartLabelPressed;
            }
        }
        else
        {
            // Use the smallest text/label in portrait
            mText = m_smallText;
            mStartLabel = m_smallStartLabel;

            mButtonStyle.normal.background = m_smallStartLabel;
            mButtonStyle.active.background = m_smallStartLabelPressed;
        }

        // The text box should fill the width of the screen
        float textWidth = Screen.width;
        float textHeight = textWidth * (mText.height / (float) mText.width);
        float textMargin = (Screen.height - textHeight) / 2.0f;
        mTextRect = new Rect(0, textMargin, textWidth, textHeight);

        // The start label should fit in the lower right corner of the text box
        float labelMargin = textHeight * 0.05f;
        float labelHeight = textHeight * 0.07f;
        float labelWidth = labelHeight * (mStartLabel.width / (float) mStartLabel.height);
        float y = Screen.height - labelHeight - labelMargin - textMargin;
        float x = Screen.width - labelWidth - labelMargin;
        mStartLabelRect = new Rect(x, y, labelWidth, labelHeight);
    }


    void OnApplicationPause(bool pause)
    {
        if (!pause)
        {
            // Show this screen on resume, but not when returning from full screen playback
            if (mVideoPlaybackController != null && !mVideoPlaybackController.CheckWentToFullScreen())
            {
                // Disable the VideoPlaybackController to prevent touches through this screen
                mVideoPlaybackController.enabled = false;

                // Show this screen
                mShowScreen = true;
            }
        }
    }


    void OnGUI()
    {
        if (mShowScreen)
        {
            // Draw the text box
            GUI.DrawTexture(mTextRect, mText, ScaleMode.StretchToFill, true, 0);

            // Draw the start button
            if (GUI.Button(mStartLabelRect, "", mButtonStyle))
            {
                // Re-enable the VideoPlaybackController
                if (mVideoPlaybackController != null) mVideoPlaybackController.enabled = true;

                // Hide this screen
                mShowScreen = false;
            }
        }
    }

    #endregion // UNITY_MONOBEHAVIOUR_METHODS
}
