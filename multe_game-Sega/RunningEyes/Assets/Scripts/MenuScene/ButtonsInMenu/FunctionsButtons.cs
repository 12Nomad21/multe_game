using UnityEngine;
using UnityEngine.SceneManagement;

public class FunctionsButtons : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(2);
    }
    
    public void GoToShop()
    {
        SceneManager.LoadScene(1);
    }

    [SerializeField] Animator _settingsPanelAnimation;
    [SerializeField] Animator _buttonsAnimation;
    public void OpenCloseSettingsPanel()
    {
        if(_buttonsAnimation.GetBool("ButtonsOnLeft") == false && _settingsPanelAnimation.GetBool("SettingsPanelOnLeft") == false){
            _buttonsAnimation.SetBool("ButtonsOnLeft", true);
            _settingsPanelAnimation.SetBool("SettingsPanelOnLeft", true);
        }
        else{
            _buttonsAnimation.SetBool("ButtonsOnLeft", false);
            _settingsPanelAnimation.SetBool("SettingsPanelOnLeft", false);
        }
    }
}
