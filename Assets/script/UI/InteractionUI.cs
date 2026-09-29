using UnityEngine;
using TMPro;
using System.Collections;

public class InteractionMessageUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI messageText;

    [SerializeField] private float messageDuration = 2f;

    private Coroutine hideCoroutine;

    private void OnEnable()
    {
        EventManager.Instance.OnInteractionMessage += ShowMessage;
    }

    private void OnDisable()
    {
        if (EventManager.Instance == null)
            return;

        EventManager.Instance.OnInteractionMessage -= ShowMessage;
    }

    private void ShowMessage(string message)
    {
        // Display message
        messageText.text = message;
        messageText.gameObject.SetActive(true);

        // Reset previous timer
        if (hideCoroutine != null)
        {
            StopCoroutine(hideCoroutine);
        }

        // Start new timer
        hideCoroutine = StartCoroutine(HideMessage());
    }

    private IEnumerator HideMessage()
    {
        // Wait for duration
        yield return new WaitForSeconds(messageDuration);

        // Hide message
        messageText.gameObject.SetActive(false);

        hideCoroutine = null;
    }
}