using UnityEngine;
using UnityEngine.SceneManagement;

public class FunctionsButtons : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(2);
    }

    public void StartGameAfterFalledHero(GameObject barriers)
    {
        barriers.SetActive(false);
    }
    
    public void GoToShop()
    {
        SceneManager.LoadScene(1);
    }

    [SerializeField] private Animator _settingsPanelAnimation;
    [SerializeField] private Animator _buttonsAnimation;
    public void OpenCloseSettingsPanel()
    {
        if(!_buttonsAnimation.GetBool("ButtonsOnLeft") && !_settingsPanelAnimation.GetBool("SettingsPanelOnLeft")){
            _buttonsAnimation.SetBool("ButtonsOnLeft", true);
            _settingsPanelAnimation.SetBool("SettingsPanelOnLeft", true);
        }
        else{
            _buttonsAnimation.SetBool("ButtonsOnLeft", false);
            _settingsPanelAnimation.SetBool("SettingsPanelOnLeft", false);
        }
    }

    public void ExitFromGame()
    {
        Application.Quit();
    }
}
