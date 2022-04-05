using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ArrangeHelper
{
    internal static U SetField<T, U>(this U @this, string name, T valueToSet) where U:MonoBehaviour
    {
        @this.GetType()
            .GetField(name, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(@this, valueToSet);
        return @this;
    }
    
    static T DynamicCallGeneric<T>(T @this, string methodName, object[] param) where T:MonoBehaviour
    {
        @this.GetType()
            .GetMethod(methodName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .Invoke(@this, param);
        return @this;
    }

    internal static T CallAwake<T>(this T @this) where T : MonoBehaviour
        => DynamicCallGeneric(@this, "Awake", null);

    internal static T DynamicCall<T>(this T @this, string methodName) where T : MonoBehaviour 
        => DynamicCallGeneric(@this, methodName, null);

    internal static T DynamicCall<T,U>(this T @this, string methodName, U param1) where T : MonoBehaviour
        => DynamicCallGeneric(@this, methodName, new object[] { param1 });
    
    internal static T DynamicCall<T, U, V>(this T @this, string methodName, U param1, V param2) where T : MonoBehaviour
        => DynamicCallGeneric(@this, methodName, new object[] { param1, param2 });

    internal static T DynamicCall<T, U, V, W>(this T @this, string methodName, U param1, V param2, W param3) where T : MonoBehaviour
        => DynamicCallGeneric(@this, methodName, new object[] { param1, param2, param3 });

}
