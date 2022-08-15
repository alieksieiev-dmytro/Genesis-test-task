using System.Collections;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class UIPanelSliding : MonoBehaviour
{
    [SerializeField] private float animationDuration;
    [SerializeField] private bool isShownByDefault;
    [SerializeField] private bool isHiddenOnLeftSide;
    
    private RectTransform m_RectTransform;
    
    void Start()
    {
        m_RectTransform = GetComponent<RectTransform>();
        
        float endValue = isShownByDefault ? 0 : m_RectTransform.rect.width * 1;
        m_RectTransform.DOAnchorPosX(endValue, 0);
    }

    public void Show()
    {
        m_RectTransform.DOAnchorPosX(0, animationDuration);
    }

    public void Hide()
    {
        int side = isHiddenOnLeftSide ? -1 : 1;
        
        m_RectTransform.DOAnchorPosX(m_RectTransform.rect.width * side, animationDuration);
    }
}