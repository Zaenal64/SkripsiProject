using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class XPManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI currentXPtext, targetXPtext, levelText;
    public int currentXP, targetXP, level;

    public static XPManager instance;

    private void Awake() {
        if(instance == null){
            instance = this;
        }else{
            Destroy(gameObject);
        }
    }
    private void Start() {
        currentXPtext.text = currentXP.ToString();
        targetXPtext.text = targetXP.ToString();
        levelText.text = level.ToString();
    }

    public void AddXP(int xp){
        level += 1;
        currentXP += xp;
        //naik level
        while(currentXP >= targetXP){
            currentXP = currentXP - targetXP;
            level++;
            targetXP += targetXP/20;
            levelText.text = level.ToString();
            targetXPtext.text = targetXP.ToString();
        }
        currentXPtext.text = currentXP.ToString();

    }

    public int GetLevel(){
        return level;
    }
}
