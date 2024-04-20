using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Dialogue[] dialogs;
    public Text[] dialogTextboxes;
    public float updateInterval = 2f;

    void Start()
    {
        StartCoroutine(UpdateDialogs());
    }

    IEnumerator UpdateDialogs()
    {
        while (true)
        {
            DisplayRandomDialogs();
            yield return new WaitForSeconds(updateInterval);
        }
    }

    void DisplayRandomDialogs()
    {
        for (int i = 0; i < dialogTextboxes.Length; i++)
        {
            int randomIndex1 = Random.Range(0, dialogs.Length);
            int randomIndex2;
            do
            {
                randomIndex2 = Random.Range(0, dialogs.Length);
            } while (randomIndex2 == randomIndex1);// Ensure indexes are different

            dialogTextboxes[0].text = dialogs[randomIndex1].dialogText;
            dialogTextboxes[1].text = dialogs[randomIndex2].dialogText;
        }
    }
}