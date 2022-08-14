using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntercationBlockerUI : MonoBehaviour
{
    [SerializeField] private RectTransform interactionBlocker;
    
    public void ActivateBlocker(float duration)
    {
        StartCoroutine(ActivateBlocker_coroutine(duration));
    }

    private IEnumerator ActivateBlocker_coroutine(float duration)
    {
        interactionBlocker.gameObject.SetActive(true);
        yield return new WaitForSeconds(duration);
        interactionBlocker.gameObject.SetActive(false);
    }
}
