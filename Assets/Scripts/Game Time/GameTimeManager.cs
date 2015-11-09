using UnityEngine;
using System.Collections;

public class GameTimeManager : MonoBehaviour {

    public int gameDayLengthMins;
    private int gameDayLengthSecs = 120000;
    private int currentGameTime;

    private bool isRunning = true;
    private bool isDayOver = false;
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                UnpauseGameClock();
            } else
            {
                PauseGameClock();
            }
        }
    }

    void OnDisable()
    {
        KillGameClock();
    }

    void OnEnable()
    {
        gameDayLengthSecs = gameDayLengthMins * 60;
        EnableGameClock();
    }

    private IEnumerator GameClock()
    {
        while (isRunning)
        {
            if (isPaused)
            {
                yield return null;
            } else
            {
                currentGameTime++;

                if (currentGameTime >= gameDayLengthSecs)
                {
                    isDayOver = true;
                    Debug.Log("Day is over!");
                    ResetGameClock();
                }

                yield return new WaitForSeconds(1f);
            }
        }

        yield return null;
    }

    private void PauseGameClock()
    {
        Debug.LogWarning("Game Clock Paused");
        isPaused = true;
    }

    private void UnpauseGameClock()
    {
        Debug.LogWarning("Game Clock Unpaused");
        isPaused = false;
    }

    private void ResetGameClock()
    {
        currentGameTime = 0;
        isDayOver = false;
    }

    private void KillGameClock()
    {
        Debug.LogWarning("Killed game clock");
        isRunning = false;
        isPaused = false;
    }

    private void EnableGameClock()
    {
        isRunning = true;
        isPaused = false;
        StartCoroutine(GameClock());
    }
}
