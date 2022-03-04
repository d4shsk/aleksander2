using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DependingDialog : DialogInfo
{
    public static int gentlemanOpinion;
    public static int villagerOpinion;

    public int[] dependingTexts;
    public BasicDialogContoller.Answer[] gentlemanAnswer;
}
