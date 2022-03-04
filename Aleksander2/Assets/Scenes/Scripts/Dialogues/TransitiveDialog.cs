using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitiveDialog : DialogInfo
{
    public int firstSceneId;
    public int secondSceneId;

    public string[] yesTexts;
    public string[] noTexts;

    public BasicDialogContoller.Answer answerToFirstScene;
}
