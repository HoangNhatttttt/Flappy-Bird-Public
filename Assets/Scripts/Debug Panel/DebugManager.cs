using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DebugManager : MonoBehaviour
{
    public GameObject debugUI; //* GameObject cho DebugUI, dùng để lấy tên và SetActive cho DebugPanelText
    private IDebugPanel[] debugPanels; //* array chứa các script cho DebugPanel, lấy hết các script có sử dụng Class Interface IDebugPanel, gọi hàm Update() từ các scipt
    private Dictionary<string, bool> panelStates = new(); //* Lưu trạng thái bật/tắt cho từng DebugPanel

    void Awake()
    {
        debugPanels = GetComponents<IDebugPanel>();
    }

    void Start()
    {
        foreach (Transform child in debugUI.transform) {
            child.gameObject.SetActive(false);
            panelStates[child.name] = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            TogglePanel("PipesSpawnerDebugPanel"); //* Sử dụng tên của panel Text
        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            TogglePanel("BirdRotationDebugPanel");
        }

        if (Input.GetKeyDown(KeyCode.F3))
        {
            TogglePanel("BirdVelocityDebugPanel");
        }

        foreach (var panel in debugPanels)
        {
            panel.UpdatePanel();
        }
        
    }

    public void TogglePanel(string panelName)
    {
        foreach (Transform child in debugUI.transform)
        {

            if (child.name == panelName && panelStates[panelName] == false)
            {
                child.gameObject.SetActive(true);
                panelStates[child.name] = true;
                break;
            }

            else if (child.name == panelName && panelStates[panelName] == true)
            {
                child.gameObject.SetActive(false);
                panelStates[child.name] = false;
                break;
            }
        }
    }
}
