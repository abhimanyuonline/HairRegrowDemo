using UnityEngine;
public class ActivitySelectionManager : MonoBehaviour
{
    public static ActivitySelectionManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(this.gameObject);
    }

    public int _selectedActivity { get; private set; }

    private void SetPlayerActivity(int index)
    {


        _selectedActivity = index;
    }

    public void OnClick_CutHair()
    {
        SetPlayerActivity(0);
    }
    public void OnClick_TrimHair()
    {
        SetPlayerActivity(1);
    }
    public void OnClick_RegrowHair()
    {
        SetPlayerActivity(2);
    }


}
