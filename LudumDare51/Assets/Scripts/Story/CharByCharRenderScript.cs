using System.Collections;
using TMPro;
using UnityEngine;

public class CharByCharRenderScript : MonoBehaviour
{
    public bool hasFinished = false;

    AudioSource audioSource;
    public AudioClip[] textBips;

    public string script;
    string[] scriptByWords;
    TextMeshProUGUI textMeshProUGUI;

    void Start()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        textMeshProUGUI.text = "";
        script.Replace("\\n", "<br><br>");
        scriptByWords = script.Split(' ');

        audioSource = GetComponent<AudioSource>();

        StartCoroutine(BuildText());
    }

    private IEnumerator BuildText()
    {
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < scriptByWords.Length; i++)
        {
            if (!hasFinished)
            {

                textMeshProUGUI.text = string.Concat(textMeshProUGUI.text, scriptByWords[i] + " ");

                int bipIndex = Random.Range(0, textBips.Length - 1);
                audioSource.PlayOneShot(textBips[bipIndex]);

                yield return new WaitForSeconds(0.1f);
            }
        }

        hasFinished = true;
    }

    public void showFullText()
    {
        textMeshProUGUI.text = script;

        int bipIndex = Random.Range(0, textBips.Length - 1);
        audioSource.PlayOneShot(textBips[bipIndex]);

        hasFinished = true;
    }
}
