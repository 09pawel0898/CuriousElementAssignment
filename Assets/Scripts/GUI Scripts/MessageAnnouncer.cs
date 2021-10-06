using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageAnnouncer : MonoBehaviour
{
    public static MessageAnnouncer Instance { get; private set; }
    private Text m_Text;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        m_Text = gameObject.GetComponent<Text>();
    }

    public void ShowMessage(string message, bool dissapear)
    {
        m_Text.text = message;
        if(dissapear)
            StartCoroutine(DeleteMessageAfterFewSeconds());
    }

    private IEnumerator DeleteMessageAfterFewSeconds()
    {
        yield return new WaitForSeconds(4);
        m_Text.text = "";
    }
}
