using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NpcDetect : MonoBehaviour
{
    public NeutralDialog neutralDialog;
    public DependingDialog dependingDialog;
    public TransitiveDialog transitiveDialog;

    [SerializeField] private ViewDialogButtons viewDialog;
    [SerializeField] private BasicDialogContoller viewTexts;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent(typeof(DialogInfo)))
        {
            if (collision.GetComponent<NeutralDialog>()) {
                DialogInfo.typeOfDialog = DialogInfo.TypeOfDialog.Neutral;
                neutralDialog = collision.GetComponent<NeutralDialog>();
            }

            else if (collision.GetComponent<TransitiveDialog>()) {
                DialogInfo.typeOfDialog = DialogInfo.TypeOfDialog.Transitive;
                transitiveDialog = collision.GetComponent<TransitiveDialog>();
            }

            else if (collision.GetComponent<DependingDialog>())
            {
                DialogInfo.typeOfDialog = DialogInfo.TypeOfDialog.Depending;
                dependingDialog = collision.GetComponent<DependingDialog>();
            }
            viewDialog.SetDialogStartEnabled();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent(typeof(DialogInfo))) {
            viewDialog.SetDialogStartDisabled();
            viewDialog.SetDialogBoxDisabled();
        }
    }
}
