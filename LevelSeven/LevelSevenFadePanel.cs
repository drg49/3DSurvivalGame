using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSevenFadePanel : MonoBehaviour
{
    private void GoToLastLevel()
    {
        SceneContext.CurrentLevelMode = LevelMode.LastLevel;
        SceneManager.LoadScene("FirstLevel_Apartment");
    }
}
