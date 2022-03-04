using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BasicDialogContoller : MonoBehaviour
{
    public ViewDialogButtons viewDialogButtons;

    public Text dialogText;

    public static Answer currentAnswer = Answer.Neutral;

    public bool existText;

    public Text npcName;

    [HideInInspector] public int numOfText;
    [HideInInspector] public enum Answer { Yes, No, Neutral }


    public static void SetTexts(Text dialogText, Text npcName, string[] texts, string npcNameString, int numOfText) {
        dialogText.text = texts[numOfText];
        npcName.text = npcNameString;
    }

    public void CheckTextExist(int textsLenth, int currentNumOfText)
    {
        if (textsLenth > currentNumOfText)
        {
            existText = true;
        }
        else
        {
            existText = false;
        }
    }

    public void SetAnswersState(TransitiveDialog transitiveDialog, int numOfText)
    {
        for (int i = 0; i < transitiveDialog.viewAnswers.Length; i++) {
            if (numOfText == transitiveDialog.viewAnswers[i]) // на определенном ид текста появляются вопросы
            {
                transitiveDialog.toggleAnswersVisibility.ViewAnswers();
            }
        }

        for (int i = 0; i < transitiveDialog.hideAnswers.Length; i++) {
            if (numOfText == transitiveDialog.hideAnswers[i])
            {
                transitiveDialog.toggleAnswersVisibility.HideAnswers();
            }
        }

        for (int i = 0; i < transitiveDialog.viewOnlyYes.Length; i++) {
            if (numOfText == transitiveDialog.viewOnlyYes[i])
            {
                transitiveDialog.toggleAnswersVisibility.ViewOnlyYes();
            }
        }
    }

    public void SetAnswersState(DependingDialog dependingDialog, int numOfText)
    {
        for (int i = 0; i < dependingDialog.viewAnswers.Length; i++)
        {
            if (numOfText == dependingDialog.viewAnswers[i]) // на определенном ид текста появляются вопросы
            {
                dependingDialog.toggleAnswersVisibility.ViewAnswers();
            }
        }

        for (int i = 0; i < dependingDialog.hideAnswers.Length; i++)
        {
            if (numOfText == dependingDialog.hideAnswers[i])
            {
                dependingDialog.toggleAnswersVisibility.HideAnswers();
            }
        }

        for (int i = 0; i < dependingDialog.viewOnlyYes.Length; i++)
        {
            if (numOfText == dependingDialog.viewOnlyYes[i])
            {
                dependingDialog.toggleAnswersVisibility.ViewOnlyYes();
            }
        }
    }

    public void SetAnswersState(NeutralDialog neutralDialog, int numOfText)
    {
        for (int i = 0; i < neutralDialog.viewAnswers.Length; i++)
        {
            if (numOfText == neutralDialog.viewAnswers[i]) // на определенном ид текста появляются вопросы
            {
                neutralDialog.toggleAnswersVisibility.ViewAnswers();
            }
        }

        for (int i = 0; i < neutralDialog.hideAnswers.Length; i++)
        {
            if (numOfText == neutralDialog.hideAnswers[i])
            {
                neutralDialog.toggleAnswersVisibility.HideAnswers();
            }
        }

        for (int i = 0; i < neutralDialog.viewOnlyYes.Length; i++)
        {
            if (numOfText == neutralDialog.viewOnlyYes[i])
            {
                neutralDialog.toggleAnswersVisibility.ViewOnlyYes();
            }
        }
    }

    public string[] SetDependingOnAnswerTexts(TransitiveDialog transitiveDialog, Answer currentAnswer)
    {
        string[] currentTexts;

        if (currentAnswer == Answer.Neutral)
        {
            currentTexts = transitiveDialog.texts;
        }

        else if (currentAnswer == Answer.Yes)
        {
            currentTexts = transitiveDialog.yesTexts;
        }
        else
        {
            currentTexts = transitiveDialog.noTexts;
        }

        return (currentTexts);
    }
    public string[] SetDependingOnAnswerTexts(DependingDialog dependingDialog, Answer currentAnswer)
    {
        string[] currentTexts;

        currentTexts = dependingDialog.texts;

        return (currentTexts);
    }
}
