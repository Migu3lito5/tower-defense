using TMPro;
using UnityEngine;

public class LivesUi : MonoBehaviour
{
    public TextMeshProUGUI livesText;


   

    private void Update()
    {
        livesText.text = $"Lives: {PlayerStats.Lives.ToString()}";
    }
}
