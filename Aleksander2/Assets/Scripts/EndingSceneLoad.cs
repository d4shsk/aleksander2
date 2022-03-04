using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingSceneLoad : MonoBehaviour
{
    [SerializeField] private SceneChanger sceneChanger;
    [SerializeField] private int villagerScene;
    [SerializeField] private int gentlemanScene;

    public void EndSceneLoad() {
        if (DependingDialog.gentlemanOpinion > DependingDialog.villagerOpinion) {
            sceneChanger.ChangeScene(gentlemanScene);
        }
        else if (DependingDialog.villagerOpinion >= DependingDialog.gentlemanOpinion) {
            sceneChanger.ChangeScene(villagerScene);
        }
    }
}
