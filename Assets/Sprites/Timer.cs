using UnityEngine;
using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class UITimer : Item
{	
  public Text TimerText; 
  public bool playing;
  private float Timer;

  void Update () {

    if(playing == true){

      Timer += Time.deltaTime;
      int minutes = Mathf.FloorToInt(Timer / 60f);
      int seconds = Mathf.FloorToInt(Timer % 60f);
      int milliseconds = Mathf.FloorToInt((Timer * 100f) % 100f);
      TimerText.text = minutes.ToString ("00") + ":" + seconds.ToString ("00") + ":" + milliseconds.ToString("00");
    }
  }

}
