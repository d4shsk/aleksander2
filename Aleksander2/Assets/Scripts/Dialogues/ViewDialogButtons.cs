using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(DialogControls))]

public class ViewDialogButtons : MonoBehaviour
{
    [SerializeField] private Animator dialogBoxAnimator;
    [SerializeField] private Animator dialogStartAnimator;
    [SerializeField] private Button startButton;

    private DialogControls dialogControls;

    private void Start()
    {
        dialogControls = GetComponent<DialogControls>();
    }

    public void SetDialogStartEnabled() {
        startButton.interactable = true;
        dialogStartAnimator.SetBool("StartView", true);
    }
    
    public void SetDialogBoxEnabled() {
        SetDialogStartDisabled();
        dialogControls.SetDialogScript();
        dialogBoxAnimator.SetBool("BoxView", true);
    }

    public void SetDialogStartDisabled()
    {
        startButton.interactable = false;
        dialogStartAnimator.SetBool("StartView", false);
    }

    public void SetDialogBoxDisabled()
    {
        dialogBoxAnimator.SetBool("BoxView", false);
    }
}
