using UnityEngine;

public class DialogInfo : MonoBehaviour
{
    public ToggleAnswersVisibility toggleAnswersVisibility;

    public string npcName;
    public string[] texts;

    [HideInInspector] public enum TypeOfDialog {Neutral, Transitive, Depending}
    public static TypeOfDialog typeOfDialog;

    public int[] viewAnswers; // На каком тексте будут переключаться ответы
    public int[] hideAnswers;
    public int hideBox;
    public int[] viewOnlyYes;
}
