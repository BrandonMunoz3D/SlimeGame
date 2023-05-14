using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HatObtained_NPC_SCRIPT : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    private int index;
    public string[] hatDialogue;

    public TextMeshProUGUI npcName;
    public Image npcPic;
    public string nametext;

    public GameObject hat;
    public bool hashat;

    public float wordSpeed;
    public bool proximityNpc;

    public GameObject Slime;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && proximityNpc && hashat)
        {
            if (!dialoguePanel.activeInHierarchy)
            {
                dialoguePanel.SetActive(true);
                npcPic.gameObject.SetActive(true);
                npcName.text = nametext;
                //enumerator typing effect
                StartCoroutine(Typing());
            }
            else if (dialogueText.text == hatDialogue[index])
            {
                NextLine();
            }
        }
    }
    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
        npcPic.gameObject.SetActive(false);
    }

    //Typing effect
    IEnumerator Typing()
    {
        foreach (char letter in hatDialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {
        if (index < hatDialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
        }
    }

    //if close or not close to npc
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            proximityNpc = true;
        }
        if (collision.CompareTag("CowboyHat"))
        {
            hashat = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            proximityNpc = false;
            zeroText();
        }

        if (collision.CompareTag("CowboyHat"))
        {
            hashat = false;
        }
    }

    //private void Ascend()
    //{
    //    Slime.transform.vertical?
    //}

}
