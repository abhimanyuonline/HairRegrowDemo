using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ActivitySelectionManager : MonoBehaviour
{
    public static ActivitySelectionManager Instance;

    [SerializeField]
    private List<Button> activitySelectionButtonList = new List<Button>();

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

    private void Start()
    {
        OnClick_CutHair();
    }

    private void SetPlayerActivity(int index)
    {
        _selectedActivity = index;
        UpdateSelectedActivityButtonColor(index);
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

    [SerializeField]
    private Color selectedColor;
    [SerializeField]
    Color unSelectedColor;
    
    public void UpdateSelectedActivityButtonColor(int activityId)
    {

        for (int i = 0; i < activitySelectionButtonList.Count; i++)
        {
            if (i == activityId)
            {
                activitySelectionButtonList[i].GetComponent<Image>().color = selectedColor;
            }
            else
            {
                activitySelectionButtonList[i].GetComponent<Image>().color = unSelectedColor;
            }
        }
    }
}
