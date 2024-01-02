using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TMP_Text text;
    public float timeBetweenChar = .01f;
    public float timeBetweenLine = 1f;
    private List<string> messageQueue = new List<string>();
    private bool isRenderingMessages = false;

    public void Start()
    {
        QueueMessage("Shoot its 8:25 im gonna miss work");
        QueueMessage("FUCK FUCK FUCK FUCK FUCK FUCK FUCK");
    }

    public void QueueMessage(string message)
    {
        messageQueue.Add(message);

        if (!isRenderingMessages)
        {
            isRenderingMessages = true;
            StartCoroutine(RenderMessages());
        }
    }

    private IEnumerator RenderMessages()
    {
        while (messageQueue.Count != 0)
        {
            for (int i = 0; i < messageQueue[0].Length; i++)
            {
                text.text += messageQueue[0][i];
                yield return new WaitForSeconds(timeBetweenChar);
            }

            yield return new WaitForSeconds(timeBetweenLine);
            text.text = "";

            messageQueue.RemoveAt(0);
        }

        isRenderingMessages = false;
    }
}
