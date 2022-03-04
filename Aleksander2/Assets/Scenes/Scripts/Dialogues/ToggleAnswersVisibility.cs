using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BasicDialogContoller))]

public class ToggleAnswersVisibility : MonoBehaviour
{
    [SerializeField] private GameObject nextButton;
    [SerializeField] private GameObject noButton;
    [SerializeField] private GameObject yesButton;

    [SerializeField] private NpcDetect npcDetect;
    

    private void Start()
    {
        HideAnswers();
    }

    public void HideAnswers()
    {
        nextButton.SetActive(true);
        yesButton.SetActive(false);
        noButton.SetActive(false);
    }
    public void ViewAnswers()
    {
        nextButton.SetActive(false);
        yesButton.SetActive(true);
        noButton.SetActive(true);
    }
    public void ViewOnlyYes()
    {
        nextButton.SetActive(false);
        yesButton.SetActive(true);
        noButton.SetActive(false);
    }
}
