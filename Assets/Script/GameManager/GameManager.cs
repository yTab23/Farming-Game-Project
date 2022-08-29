using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        //ToDo: Need a resolution settings options screen
        Screen.SetResolution(1920, 1080, FullScreenMode.FullScreenWindow, 0);
    }
}
