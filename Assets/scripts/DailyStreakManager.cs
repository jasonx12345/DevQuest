using UnityEngine;
using UnityEngine.UI;
using System;

public class DailyStreakManager : MonoBehaviour
{
    public Text streakText; // Assign this in the inspector with your UI Text element

    private void Start()
    {
        UpdateStreak();
    }

    private void UpdateStreak()
    {
        // Get the current streak and last played date from PlayerPrefs
        int currentStreak = PlayerPrefs.GetInt("CurrentStreak", 0);
        DateTime lastPlayedDate = DateTime.FromBinary(Convert.ToInt64(PlayerPrefs.GetString("LastPlayedDate", DateTime.MinValue.ToBinary().ToString())));

        // Check if the last played date is before today
        if (lastPlayedDate < DateTime.Today)
        {
            // Check if the last played date was yesterday
            if (lastPlayedDate == DateTime.Today.AddDays(-1))
            {
                // Increment the streak if the player played yesterday
                currentStreak++;
            }
            else
            {
                // Reset the streak if the player missed more than one day
                currentStreak = 1;
            }

            // Update the last played date and current streak in PlayerPrefs
            PlayerPrefs.SetString("LastPlayedDate", DateTime.Today.ToBinary().ToString());
            PlayerPrefs.SetInt("CurrentStreak", currentStreak);
        }

        // Display the current streak in the UI
        streakText.text = $"Current Daily Streak: {currentStreak} ";
    }
}
