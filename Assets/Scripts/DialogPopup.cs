using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogPopup : MonoBehaviour
{
    [SerializeField]
    private string[] dialogLines;
    [SerializeField]
    private float barkDuration = 3f;
    [SerializeField]
    private Vector3 barkOffset;

    private bool isBarking;
    private int currentDialogIndex = -1;
    private TMPro.TextMeshProUGUI m_TextMeshPro;

    private void Awake()
    {
        m_TextMeshPro = GetComponentInChildren<TMPro.TextMeshProUGUI>(true);
        m_TextMeshPro.transform.parent.gameObject.SetActive(true);
    }
    private void Update()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(this.gameObject.transform.position + barkOffset);
        m_TextMeshPro.rectTransform.position = pos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            isBarking = true;
            if(barkCo == null) { barkCo = StartCoroutine(Bark()); }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isBarking = false;
        }
    }

    private Coroutine barkCo;
    private IEnumerator Bark()
    {
        while (isBarking)
        {
            currentDialogIndex += 1;
            if (currentDialogIndex >= dialogLines.Length) { currentDialogIndex = 0; }
            m_TextMeshPro.text = dialogLines[currentDialogIndex];
            yield return new WaitForSeconds(barkDuration);
        }
        m_TextMeshPro.text = "";
        barkCo = null;
        yield break;
    }
}
