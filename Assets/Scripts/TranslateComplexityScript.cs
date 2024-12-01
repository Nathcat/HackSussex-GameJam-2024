using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateComplexityScript : MonoBehaviour
{
    public string ConvertComplexity(int i){
        switch(i){
            case 1:
                return "Constant";

            case 2:
                return "Logarithmic";

            case 3:
                return "Linear";

            case 4:
                return "Loglinear";

            case 5:
                return "quadratic";





        }
        return "either not implemented or just completely fucked up";
    }
}
