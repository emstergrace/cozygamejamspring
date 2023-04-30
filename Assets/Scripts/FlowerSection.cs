using System;
using TMPro;
using UnityEngine;

public class FlowerSection : MonoBehaviour
{
    [SerializeField] 
    private float speed;

    [SerializeField]
    private TextLine[] textLines;

    private bool writing;

    private int currentLine;
    private int currentLetter;

    private float nextUpdate;

    // Start is called before the first frame update
    void Start()
    {
        nextUpdate = 0; 
        currentLetter = 0; 
        currentLine = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!writing) { return; }
        if (Time.time >= nextUpdate)
        {
            nextUpdate = Time.time + speed;
            textLines[currentLine].line.text += textLines[currentLine].text[currentLetter];

            currentLetter++;

            if (currentLetter >= textLines[currentLine].text.Length)
            {
                currentLine++;
                currentLetter = 0;
                if (currentLine >= textLines.Length) writing = false;
            }
            
        }
    }

    public void StartWritingFlowerSection()
    {
        writing = true;
    }

    public void FinishWritingIfInProcess()
    {
        if (!writing) return;

        writing = false;

        foreach (TextLine textLine in textLines)
        {
            textLine.line.text = textLine.text;
        }
    }

    [Serializable]
    private struct TextLine
    {
        public string text;
        public TMP_Text line;

        public TextLine(string text, TMP_Text line)
        {
            this.text = text;
            this.line = line;
        }
    }
}
