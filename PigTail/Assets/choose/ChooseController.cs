using System.Collections;
using System.Collections.Generic;
using choose;
using UnityEngine;

public class ChooseController : MonoBehaviour
{
    public ChoosedPig choosedPig;
    
    public void ChoosePig1()
    {
        choosedPig.pigType = PigType.Pig1;
    }
    
    public void ChoosePig2()
    {
        choosedPig.pigType = PigType.Pig2;
    }
    
    public void ChoosePig3()
    {
        choosedPig.pigType = PigType.Pig3;
    }
    
}
