using System.Collections;
using UnityEngine;

public class Util : MonoBehaviour
{
    public CardAnimation animationPrefab;
    public static Util instance {  get; private set; }

    private void Start()
    {
        instance = this;
    }

    public static string ConvertComplexity(int i){
        switch(i){
            case 0:
                return "1";

            case 1:
                return "log N";

            case 2:
                return "N";

            case 3:
                return "N log N";

            case 4:
                return "n²";

            case 5:
                return "2ᴺ";
        }
        return "unknown";
    }

    public static void RunAfter(float delay, System.Action action)
    {
        IEnumerator ThrowDelay()
        {
            yield return new WaitForSeconds(delay);
            action();
        }

        instance.StartCoroutine(ThrowDelay());
    }
}
