using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DependingDialogController : BasicDialogContoller
{
    [SerializeField] private EndingSceneLoad endingSceneLoad;

    private void Reset()
    {
        currentAnswer = Answer.Neutral;
        numOfText = 0;
    }

    public void StartDependingDialog(DependingDialog dependingDialog)
    {
        Reset();
        BasicDialogContoller.SetTexts(dialogText, npcName, dependingDialog.texts, dependingDialog.npcName, numOfText);
    }
    
    public void DependingNextText(DependingDialog dependingDialog)
    {

        numOfText++;

        SetAnswersState(dependingDialog, numOfText);

        string[] currentTexts;
        currentTexts = SetDependingOnAnswerTexts(dependingDialog, currentAnswer);

        CheckTextExist(currentTexts.Length, numOfText);

        if (existText)
        {
            BasicDialogContoller.SetTexts(dialogText, npcName, currentTexts, dependingDialog.npcName, numOfText);
        }

        if (numOfText == dependingDialog.hideBox)
        {
            viewDialogButtons.SetDialogBoxDisabled();
            endingSceneLoad.EndSceneLoad();
        }
    }

    public void SetYesAnswer(DependingDialog dependingDialog)
    {
        currentAnswer = Answer.Yes;
        ChangeOpinions(dependingDialog);
        DependingNextText(dependingDialog);
    }

    public void SetNoAnswer(DependingDialog dependingDialog)
    {
        currentAnswer = Answer.No;
        ChangeOpinions(dependingDialog);
        DependingNextText(dependingDialog);
    }

    private void ChangeOpinions(DependingDialog dependingDialog) {
        for (int i = 0; i < dependingDialog.dependingTexts.Length; i++) {
            if (numOfText == dependingDialog.dependingTexts[i]) {
                if (currentAnswer == dependingDialog.gentlemanAnswer[i])
                {
                    DependingDialog.gentlemanOpinion++;
                    DependingDialog.villagerOpinion--;
                }
                else {
                    DependingDialog.gentlemanOpinion--;
                    DependingDialog.villagerOpinion++;
                }
                DebugStats();
            }
        }
    }

    private void DebugStats() {
        Debug.Log("Мнение дворян: " + DependingDialog.gentlemanOpinion);
        Debug.Log("Мнение крестьян: " + DependingDialog.villagerOpinion);
    }
}