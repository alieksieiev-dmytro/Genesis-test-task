using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class FadeUIAnimation : MonoBehaviour
{
    [SerializeField] private float frames = 1f;
    
    private CanvasGroup m_CanvasGroup;
    
    private void Start()
    {
        m_CanvasGroup = GetComponent<CanvasGroup>();
    }

    public void FadeOut()
    {
        StartCoroutine(FadeOut(frames));
    }
    
    private IEnumerator FadeOut(float framesAnimation)
    {
        while (m_CanvasGroup.alpha != 0)
        {
            m_CanvasGroup.alpha -= 1f / framesAnimation;
            yield return null;
        }
    }
}
