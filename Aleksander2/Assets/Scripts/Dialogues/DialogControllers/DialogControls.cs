using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BasicDialogContoller))]

public class DialogControls : MonoBehaviour
{
    [SerializeField] private NpcDetect npcDetect;

    private NeutralDialogController neutralDialogController;
    private TransitiveDialogController transitiveDialogController;
    private DependingDialogController dependingDialogController;

    private void Start()
    {
        neutralDialogController = GetComponent<NeutralDialogController>();
        transitiveDialogController = GetComponent<TransitiveDialogController>();
        dependingDialogController = GetComponent<DependingDialogController>();
    }

    public void SetDialogScript()
    {
        switch (DialogInfo.typeOfDialog)
        {
            case DialogInfo.TypeOfDialog.Neutral:
                neutralDialogController.StartNeutralDialog(npcDetect.neutralDialog);
                break;
            case DialogInfo.TypeOfDialog.Transitive:
                transitiveDialogController.StartTransitiveDialog(npcDetect.transitiveDialog);
                break;
            case DialogInfo.TypeOfDialog.Depending:
                dependingDialogController.StartDependingDialog(npcDetect.dependingDialog);
                break;
        }
    }

    public void ViewNextText() {
        switch (DialogInfo.typeOfDialog)
        {
            case DialogInfo.TypeOfDialog.Neutral:
                neutralDialogController.NeutralNextText(npcDetect.neutralDialog);
                break;
            case DialogInfo.TypeOfDialog.Transitive:
                transitiveDialogController.TransitiveNextText(npcDetect.transitiveDialog);
                break;
            case DialogInfo.TypeOfDialog.Depending:

                break;
        }
    }

    public void SetNextText() {
        switch (DialogInfo.typeOfDialog)
        {
            case DialogInfo.TypeOfDialog.Neutral:
                neutralDialogController.NeutralNextText(npcDetect.neutralDialog);
                break;
            case DialogInfo.TypeOfDialog.Transitive:
                transitiveDialogController.TransitiveNextText(npcDetect.transitiveDialog);
                break;
            case DialogInfo.TypeOfDialog.Depending:
                dependingDialogController.DependingNextText(npcDetect.dependingDialog);
                break;
        }
    }

    public void onYesButtonClick() {
        switch (DialogInfo.typeOfDialog)
        {
            case DialogInfo.TypeOfDialog.Neutral:
                neutralDialogController.NeutralNextText(npcDetect.neutralDialog);
                break;
            case DialogInfo.TypeOfDialog.Transitive:
                transitiveDialogController.SetYesAnswer(npcDetect.transitiveDialog);
                break;
            case DialogInfo.TypeOfDialog.Depending:
                dependingDialogController.SetYesAnswer(npcDetect.dependingDialog);
                break;
        }
    }

    public void onNoButtonClick() {
        switch (DialogInfo.typeOfDialog)
        {
            case DialogInfo.TypeOfDialog.Neutral:
                neutralDialogController.NeutralNextText(npcDetect.neutralDialog);
                break;
            case DialogInfo.TypeOfDialog.Transitive:
                transitiveDialogController.SetNoAnswer(npcDetect.transitiveDialog);
                break;
            case DialogInfo.TypeOfDialog.Depending:
                dependingDialogController.SetNoAnswer(npcDetect.dependingDialog);
                break;
        }
    }
}
