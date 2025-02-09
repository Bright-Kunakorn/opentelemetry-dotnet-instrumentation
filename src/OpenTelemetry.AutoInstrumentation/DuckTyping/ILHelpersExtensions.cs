// <copyright file="ILHelpersExtensions.cs" company="OpenTelemetry Authors">
// Copyright The OpenTelemetry Authors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>

using System.Reflection;
using System.Reflection.Emit;

namespace OpenTelemetry.AutoInstrumentation.DuckTyping;

/// <summary>
/// Internal IL Helpers
/// </summary>
// ReSharper disable once InconsistentNaming
internal static class ILHelpersExtensions
{
    private static readonly List<DynamicMethod> DynamicMethods = new();

    internal static DynamicMethod GetDynamicMethodForIndex(int index)
    {
        lock (DynamicMethods)
        {
            return DynamicMethods[index];
        }
    }

    internal static void CreateDelegateTypeFor(TypeBuilder proxyType, DynamicMethod dynamicMethod, out Type delType, out MethodInfo invokeMethod)
    {
        ModuleBuilder modBuilder = (ModuleBuilder)proxyType.Module;
        TypeBuilder delegateType = modBuilder.DefineType($"{dynamicMethod.Name}Delegate_" + Guid.NewGuid().ToString("N"), TypeAttributes.Class | TypeAttributes.Public | TypeAttributes.Sealed | TypeAttributes.AnsiClass | TypeAttributes.AutoClass, typeof(MulticastDelegate));

        // Delegate .ctor
        ConstructorBuilder constructorBuilder = delegateType.DefineConstructor(MethodAttributes.RTSpecialName | MethodAttributes.HideBySig | MethodAttributes.Public, CallingConventions.Standard, new Type[] { typeof(object), typeof(IntPtr) });
        constructorBuilder.SetImplementationFlags(MethodImplAttributes.Runtime | MethodImplAttributes.Managed);

        // Define the Invoke method for the delegate
        ParameterInfo[] parameters = dynamicMethod.GetParameters();
        Type[] paramTypes = new Type[parameters.Length];
        for (int i = 0; i < parameters.Length; i++)
        {
            paramTypes[i] = parameters[i].ParameterType;
        }

        MethodBuilder methodBuilder = delegateType.DefineMethod("Invoke", MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual, dynamicMethod.ReturnType, paramTypes);
        for (int i = 0; i < parameters.Length; i++)
        {
            methodBuilder.DefineParameter(i + 1, parameters[i].Attributes, parameters[i].Name);
        }

        methodBuilder.SetImplementationFlags(MethodImplAttributes.Runtime | MethodImplAttributes.Managed);

        var delegateTypeInfo = delegateType.CreateTypeInfo();
        if (delegateTypeInfo is null)
        {
            DuckTypeException.Throw($"Error creating the delegate type info for {delegateType.FullName}");
        }

        delType = delegateTypeInfo.AsType();
        invokeMethod = delType.GetMethod("Invoke")!;
    }

    /// <summary>
    /// Load instance argument
    /// </summary>
    /// <param name="il">LazyILGenerator instance</param>
    /// <param name="actualType">Actual type</param>
    /// <param name="expectedType">Expected type</param>
    internal static void LoadInstanceArgument(this LazyILGenerator il, Type actualType, Type expectedType)
    {
        il.Emit(OpCodes.Ldarg_0);
        if (actualType == expectedType)
        {
            return;
        }

        if (expectedType.IsValueType)
        {
            il.DeclareLocal(expectedType);
            il.Emit(OpCodes.Unbox_Any, expectedType);
            il.Emit(OpCodes.Stloc_0);
            il.Emit(OpCodes.Ldloca_S, 0);
        }
        else
        {
            il.Emit(OpCodes.Castclass, expectedType);
        }
    }

    /// <summary>
    /// Write load arguments
    /// </summary>
    /// <param name="il">LazyILGenerator instance</param>
    /// <param name="index">Argument index</param>
    /// <param name="isStatic">Define if we need to take into account the instance argument</param>
    internal static void WriteLoadArgument(this LazyILGenerator il, int index, bool isStatic)
    {
        if (!isStatic)
        {
            index += 1;
        }

        switch (index)
        {
            case 0:
                il.Emit(OpCodes.Ldarg_0);
                break;
            case 1:
                il.Emit(OpCodes.Ldarg_1);
                break;
            case 2:
                il.Emit(OpCodes.Ldarg_2);
                break;
            case 3:
                il.Emit(OpCodes.Ldarg_3);
                break;
            default:
                il.Emit(OpCodes.Ldarg_S, index);
                break;
        }
    }

    /// <summary>
    /// Write load local
    /// </summary>
    /// <param name="il">LazyILGenerator instance</param>
    /// <param name="index">Local index</param>
    internal static void WriteLoadLocal(this LazyILGenerator il, int index)
    {
        switch (index)
        {
            case 0:
                il.Emit(OpCodes.Ldloc_0);
                break;
            case 1:
                il.Emit(OpCodes.Ldloc_1);
                break;
            case 2:
                il.Emit(OpCodes.Ldloc_2);
                break;
            case 3:
                il.Emit(OpCodes.Ldloc_3);
                break;
            default:
                il.Emit(OpCodes.Ldloc_S, index);
                break;
        }
    }

    /// <summary>
    /// Write load local
    /// </summary>
    /// <param name="il">ILGenerator instance</param>
    /// <param name="index">Local index</param>
    internal static void WriteLoadLocal(this ILGenerator il, int index)
    {
        switch (index)
        {
            case 0:
                il.Emit(OpCodes.Ldloc_0);
                break;
            case 1:
                il.Emit(OpCodes.Ldloc_1);
                break;
            case 2:
                il.Emit(OpCodes.Ldloc_2);
                break;
            case 3:
                il.Emit(OpCodes.Ldloc_3);
                break;
            default:
                il.Emit(OpCodes.Ldloc_S, index);
                break;
        }
    }

    /// <summary>
    /// Write store local
    /// </summary>
    /// <param name="il">LazyILGenerator instance</param>
    /// <param name="index">Local index</param>
    internal static void WriteStoreLocal(this LazyILGenerator il, int index)
    {
        switch (index)
        {
            case 0:
                il.Emit(OpCodes.Stloc_0);
                break;
            case 1:
                il.Emit(OpCodes.Stloc_1);
                break;
            case 2:
                il.Emit(OpCodes.Stloc_2);
                break;
            case 3:
                il.Emit(OpCodes.Stloc_3);
                break;
            default:
                il.Emit(OpCodes.Stloc_S, index);
                break;
        }
    }

    /// <summary>
    /// Write constant int value
    /// </summary>
    /// <param name="il">LazyILGenerator instance</param>
    /// <param name="value">int value</param>
    internal static void WriteInt(this LazyILGenerator il, int value)
    {
        if (value >= -1 && value <= 8)
        {
            switch (value)
            {
                case -1:
                    il.Emit(OpCodes.Ldc_I4_M1);
                    break;
                case 0:
                    il.Emit(OpCodes.Ldc_I4_0);
                    break;
                case 1:
                    il.Emit(OpCodes.Ldc_I4_1);
                    break;
                case 2:
                    il.Emit(OpCodes.Ldc_I4_2);
                    break;
                case 3:
                    il.Emit(OpCodes.Ldc_I4_3);
                    break;
                case 4:
                    il.Emit(OpCodes.Ldc_I4_4);
                    break;
                case 5:
                    il.Emit(OpCodes.Ldc_I4_5);
                    break;
                case 6:
                    il.Emit(OpCodes.Ldc_I4_6);
                    break;
                case 7:
                    il.Emit(OpCodes.Ldc_I4_7);
                    break;
                default:
                    il.Emit(OpCodes.Ldc_I4_8);
                    break;
            }
        }
        else if (value >= -128 && value <= 127)
        {
            il.Emit(OpCodes.Ldc_I4_S, value);
        }
        else
        {
            il.Emit(OpCodes.Ldc_I4, value);
        }
    }

    /// <summary>
    /// Convert a current type to an expected type
    /// </summary>
    /// <param name="il">LazyILGenerator instance</param>
    /// <param name="actualType">Actual type</param>
    /// <param name="expectedType">Expected type</param>
    internal static void WriteTypeConversion(this LazyILGenerator il, Type actualType, Type expectedType)
    {
        var actualUnderlyingType = actualType.IsEnum ? Enum.GetUnderlyingType(actualType) : actualType;
        var expectedUnderlyingType = expectedType.IsEnum ? Enum.GetUnderlyingType(expectedType) : expectedType;

        if (actualUnderlyingType == expectedUnderlyingType)
        {
            return;
        }

        if (actualUnderlyingType.IsValueType)
        {
            if (expectedUnderlyingType.IsValueType)
            {
                // If both underlying types are value types then both must be of the same type.
                DuckTypeInvalidTypeConversionException.Throw(actualType, expectedType);
            }
            else
            {
                // An underlying type can be boxed and converted to an object or interface type if the actual type support this
                // if not we should throw.
                if (expectedUnderlyingType == typeof(object))
                {
                    // If the expected type is object we just need to box the value
                    il.Emit(OpCodes.Box, actualType);
                }
                else if (expectedUnderlyingType.IsAssignableFrom(actualUnderlyingType))
                {
                    // If the expected type can be assigned from the value type (ex: struct implementing an interface)
                    il.Emit(OpCodes.Box, actualType);
                    il.Emit(OpCodes.Castclass, expectedType);
                }
                else
                {
                    // If the expected type can't be assigned from the actual value type.
                    // Means if the expected type is an interface the actual type doesn't implement it.
                    // So no possible conversion or casting can be made here.
                    DuckTypeInvalidTypeConversionException.Throw(actualType, expectedType);
                }
            }
        }
        else
        {
            if (expectedUnderlyingType.IsValueType)
            {
                // We only allow conversions from objects or interface type if the actual type support this
                // if not we should throw.
                if (actualUnderlyingType == typeof(object) || actualUnderlyingType.IsAssignableFrom(expectedUnderlyingType))
                {
                    // WARNING: The actual type instance can't be detected at this point, we have to check it at runtime.
                    /*
                     * In this case we emit something like:
                     * {
                     *      if (!(value is [expectedType])) {
                     *          throw new InvalidCastException();
                     *      }
                     *
                     *      return ([expectedType])value;
                     * }
                     */
                    Label lblIsExpected = il.DefineLabel();

                    il.Emit(OpCodes.Dup);
                    il.Emit(OpCodes.Isinst, expectedType);
                    il.Emit(OpCodes.Brtrue_S, lblIsExpected);

                    il.Emit(OpCodes.Pop);
                    il.ThrowException(typeof(InvalidCastException));

                    il.MarkLabel(lblIsExpected);
                    il.Emit(OpCodes.Unbox_Any, expectedType);
                }
                else
                {
                    DuckTypeInvalidTypeConversionException.Throw(actualType, expectedType);
                }
            }
            else if (expectedUnderlyingType != typeof(object))
            {
                // WARNING: If the actual type cannot be cast to expectedUnderlyingType,
                // this will throw an exception at runtime when accessing the member
                il.Emit(OpCodes.Castclass, expectedUnderlyingType);
            }
        }
    }

    // WARNING: This method is a slim version of the WriteTypeConversion method without IL
    // Checks in both method must match! if you change either, you need to change both
    internal static void CheckTypeConversion(Type actualType, Type expectedType)
    {
        var actualUnderlyingType = actualType.IsEnum ? Enum.GetUnderlyingType(actualType) : actualType;
        var expectedUnderlyingType = expectedType.IsEnum ? Enum.GetUnderlyingType(expectedType) : expectedType;

        if (actualUnderlyingType == expectedUnderlyingType)
        {
            return;
        }

        if (actualUnderlyingType.IsValueType)
        {
            if (expectedUnderlyingType.IsValueType)
            {
                // If both underlying types are value types then both must be of the same type.
                DuckTypeInvalidTypeConversionException.Throw(actualType, expectedType);
            }
            else if (expectedUnderlyingType != typeof(object) && !expectedUnderlyingType.IsAssignableFrom(actualUnderlyingType))
            {
                // If the expected type can't be assigned from the actual value type.
                // Means if the expected type is an interface the actual type doesn't implement it.
                // So no possible conversion or casting can be made here.
                DuckTypeInvalidTypeConversionException.Throw(actualType, expectedType);
            }
        }
        else if (expectedUnderlyingType.IsValueType)
        {
            if (actualUnderlyingType != typeof(object) && !actualUnderlyingType.IsAssignableFrom(expectedUnderlyingType))
            {
                DuckTypeInvalidTypeConversionException.Throw(actualType, expectedType);
            }
        }
    }

    /// <summary>
    /// Write a Call to a method using Calli
    /// </summary>
    /// <param name="il">LazyILGenerator instance</param>
    /// <param name="method">Method to get called</param>
    internal static void WriteMethodCalli(this LazyILGenerator il, MethodInfo method)
    {
        il.Emit(OpCodes.Ldc_I8, (long)method.MethodHandle.GetFunctionPointer());
        il.Emit(OpCodes.Conv_I);
        il.EmitCalli(
            OpCodes.Calli,
            method.CallingConvention,
            method.ReturnType,
            method.GetParameters().Select(p => p.ParameterType).ToArray(),
            null!);
    }

    /// <summary>
    /// Write a DynamicMethod call by creating and injecting a custom delegate in the proxyType
    /// </summary>
    /// <param name="il">LazyILGenerator instance</param>
    /// <param name="dynamicMethod">Dynamic method to get called</param>
    /// <param name="proxyType">ProxyType builder</param>
    internal static void WriteDynamicMethodCall(this LazyILGenerator il, DynamicMethod dynamicMethod, TypeBuilder proxyType)
    {
        if (proxyType is null)
        {
            return;
        }

        // We create a custom delegate inside the module builder
        CreateDelegateTypeFor(proxyType, dynamicMethod, out Type delegateType, out MethodInfo invokeMethod);
        int index;
        lock (DynamicMethods)
        {
            DynamicMethods.Add(dynamicMethod);
            index = DynamicMethods.Count - 1;
        }

        // We fill the DelegateCache<> for that custom type with the delegate instance
        var delegateCacheType = typeof(DuckType.DelegateCache<>).MakeGenericType(delegateType);
        MethodInfo fillDelegateMethodInfo = delegateCacheType.GetMethod("FillDelegate", BindingFlags.NonPublic | BindingFlags.Static)!;
        fillDelegateMethodInfo?.Invoke(null, new object[] { index });

        // We get the delegate instance and load it in to the stack before the parameters (at the begining of the IL body)
        il.SetOffset(0);
        il.EmitCall(OpCodes.Call, delegateCacheType.GetMethod("GetDelegate")!, null!);
        il.ResetOffset();

        // We emit the call to the delegate invoke method.
        il.EmitCall(OpCodes.Callvirt, invokeMethod, null!);
    }
}
