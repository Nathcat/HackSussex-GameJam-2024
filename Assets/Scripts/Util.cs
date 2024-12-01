using System.Collections;
using UnityEngine;

public static class TranslateComplexityScript
{
    public static string ConvertComplexity(int i){
        switch(i){
            case 0:
                return "1";

            case 1:
                return "log n";

            case 2:
                return "n";

            case 3:
                return "n log n";

            case 4:
                return "n²";

            case 5:
                return "2ⁿ";
        }
        return "unknown";
    }

    public static void RunAfter(this MonoBehaviour mono, float delay, System.Action action)
    {
        IEnumerator ThrowDelay()
        {
            yield return new WaitForSeconds(delay);
            action();
        }

        mono.StartCoroutine(ThrowDelay());
    }
}
