using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStateManager : MonoBehaviour
{
    [Space(15)]
    [Header("-----Props-----")]
    [Space(15)]
    public int WinCount;
    public int WinCounter;
    public bool Win;





    public void DidWin()
    {
        if (WinCounter != WinCount) return;
        Win = true;
        print("Level is Completed");
    }
    public void IncreaseWinCounter() => WinCounter++;
    public void DecreaseWinCount() => WinCounter--;
}
