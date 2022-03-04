using UnityEngine;

public class NeutralDialogController : BasicDialogContoller
{
    private void Reset()
    {
        currentAnswer = Answer.Neutral;
        numOfText = 0;
    }

    public void StartNeutralDialog(NeutralDialog neutralDialog) {
        Reset();
        BasicDialogContoller.SetTexts(dialogText, npcName, neutralDialog.texts, neutralDialog.npcName, numOfText);
    }

    public void NeutralNextText(NeutralDialog neutralDialog)
    {
        numOfText++;
        
        SetAnswersState(neutralDialog, numOfText);

        CheckTextExist(neutralDialog.texts.Length, numOfText);
        if (existText)
        {
            BasicDialogContoller.SetTexts(dialogText, npcName, neutralDialog.texts, neutralDialog.npcName, numOfText);
        }

        if (numOfText == neutralDialog.hideBox) {
            viewDialogButtons.SetDialogBoxDisabled();
        }
    }
}
