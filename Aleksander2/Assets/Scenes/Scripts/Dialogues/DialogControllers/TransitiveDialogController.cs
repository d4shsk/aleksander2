using UnityEngine;

[RequireComponent(typeof(ToggleAnswersVisibility))]

public class TransitiveDialogController : BasicDialogContoller
{
    [SerializeField] private SceneChanger sceneChanger;

    private void Reset()
    {
        currentAnswer = Answer.Neutral;
        numOfText = 0;
    }

    public void StartTransitiveDialog(TransitiveDialog transitiveDialog)
    {
        Reset();
        BasicDialogContoller.SetTexts(dialogText, npcName, transitiveDialog.texts, transitiveDialog.npcName, numOfText);
    }

    public void TransitiveNextText(TransitiveDialog transitiveDialog)
    {
        
        numOfText++;

        SetAnswersState(transitiveDialog, numOfText);

        string[] currentTexts;
        currentTexts = SetDependingOnAnswerTexts(transitiveDialog, currentAnswer);

        CheckTextExist(currentTexts.Length, numOfText);

        if (existText)
        {
            BasicDialogContoller.SetTexts(dialogText, npcName, currentTexts, transitiveDialog.npcName, numOfText);
        }

        if (numOfText == transitiveDialog.hideBox)
        { // переход всегда в конце диалога
            TransitToScene(transitiveDialog);
        }
    }

    private void TransitToScene(TransitiveDialog transitiveDialog) {
        if (currentAnswer == transitiveDialog.answerToFirstScene)
        {
            sceneChanger.ChangeScene(transitiveDialog.firstSceneId);
        }
        else
        {
            sceneChanger.ChangeScene(transitiveDialog.secondSceneId);
        }
    }

    public void SetYesAnswer(TransitiveDialog transitiveDialog)
    {
        currentAnswer = Answer.Yes;
        TransitiveNextText(transitiveDialog);
    }

    public void SetNoAnswer(TransitiveDialog transitiveDialog)
    {
        currentAnswer = Answer.No;
        TransitiveNextText(transitiveDialog);
    } 
}
