using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BestScore : MonoBehaviour
{
    public Text BestScoreText;
    // Start is called before the first frame update
    void Start()
    {
        UIHundler.hundler.Load();
        BestScoreText.text = $"Best Score :{UIHundler.hundler.OldName}: {UIHundler.hundler.OldScore}";
    }


}
