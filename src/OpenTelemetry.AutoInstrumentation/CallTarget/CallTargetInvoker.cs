// <copyright file="CallTargetInvoker.cs" company="OpenTelemetry Authors">
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

using System.ComponentModel;
using System.Runtime.CompilerServices;
using OpenTelemetry.AutoInstrumentation.CallTarget.Handlers;

namespace OpenTelemetry.AutoInstrumentation.CallTarget;

/// <summary>
/// CallTarget Invoker
/// </summary>
[Browsable(false)]
[EditorBrowsable(EditorBrowsableState.Never)]
public static class CallTargetInvoker
{
    /// <summary>
    /// Begin Method Invoker
    /// </summary>
    /// <typeparam name="TIntegration">Integration type</typeparam>
    /// <typeparam name="TTarget">Target type</typeparam>
    /// <param name="instance">Instance value</param>
    /// <returns>Call target state</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static CallTargetState BeginMethod<TIntegration, TTarget>(TTarget instance)
    {
        if (IntegrationOptions<TIntegration, TTarget>.IsIntegrationEnabled)
        {
            return BeginMethodHandler<TIntegration, TTarget>.Invoke(instance);
        }

        return CallTargetState.GetDefault();
    }

    /// <summary>
    /// Begin Method Invoker
    /// </summary>
    /// <typeparam name="TIntegration">Integration type</typeparam>
    /// <typeparam name="TTarget">Target type</typeparam>
    /// <typeparam name="TArg1">First argument type</typeparam>
    /// <param name="instance">Instance value</param>
    /// <param name="arg1">First argument value</param>
    /// <returns>Call target state</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static CallTargetState BeginMethod<TIntegration, TTarget, TArg1>(TTarget instance, ref TArg1 arg1)
    {
        if (IntegrationOptions<TIntegration, TTarget>.IsIntegrationEnabled)
        {
            return BeginMethodHandler<TIntegration, TTarget, TArg1>.Invoke(instance, ref arg1);
        }

        return CallTargetState.GetDefault();
    }

    /// <summary>
    /// Begin Method Invoker
    /// </summary>
    /// <typeparam name="TIntegration">Integration type</typeparam>
    /// <typeparam name="TTarget">Target type</typeparam>
    /// <typeparam name="TArg1">First argument type</typeparam>
    /// <typeparam name="TArg2">Second argument type</typeparam>
    /// <param name="instance">Instance value</param>
    /// <param name="arg1">First argument value</param>
    /// <param name="arg2">Second argument value</param>
    /// <returns>Call target state</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static CallTargetState BeginMethod<TIntegration, TTarget, TArg1, TArg2>(TTarget instance, ref TArg1 arg1, ref TArg2 arg2)
    {
        if (IntegrationOptions<TIntegration, TTarget>.IsIntegrationEnabled)
        {
            return BeginMethodHandler<TIntegration, TTarget, TArg1, TArg2>.Invoke(instance, ref arg1, ref arg2);
        }

        return CallTargetState.GetDefault();
    }

    /// <summary>
    /// Begin Method Invoker
    /// </summary>
    /// <typeparam name="TIntegration">Integration type</typeparam>
    /// <typeparam name="TTarget">Target type</typeparam>
    /// <typeparam name="TArg1">First argument type</typeparam>
    /// <typeparam name="TArg2">Second argument type</typeparam>
    /// <typeparam name="TArg3">Third argument type</typeparam>
    /// <param name="instance">Instance value</param>
    /// <param name="arg1">First argument value</param>
    /// <param name="arg2">Second argument value</param>
    /// <param name="arg3">Third argument value</param>
    /// <returns>Call target state</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static CallTargetState BeginMethod<TIntegration, TTarget, TArg1, TArg2, TArg3>(TTarget instance, ref TArg1 arg1, ref TArg2 arg2, ref TArg3 arg3)
    {
        if (IntegrationOptions<TIntegration, TTarget>.IsIntegrationEnabled)
        {
            return BeginMethodHandler<TIntegration, TTarget, TArg1, TArg2, TArg3>.Invoke(instance, ref arg1, ref arg2, ref arg3);
        }

        return CallTargetState.GetDefault();
    }

    /// <summary>
    /// Begin Method Invoker
    /// </summary>
    /// <typeparam name="TIntegration">Integration type</typeparam>
    /// <typeparam name="TTarget">Target type</typeparam>
    /// <typeparam name="TArg1">First argument type</typeparam>
    /// <typeparam name="TArg2">Second argument type</typeparam>
    /// <typeparam name="TArg3">Third argument type</typeparam>
    /// <typeparam name="TArg4">Fourth argument type</typeparam>
    /// <param name="instance">Instance value</param>
    /// <param name="arg1">First argument value</param>
    /// <param name="arg2">Second argument value</param>
    /// <param name="arg3">Third argument value</param>
    /// <param name="arg4">Fourth argument value</param>
    /// <returns>Call target state</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static CallTargetState BeginMethod<TIntegration, TTarget, TArg1, TArg2, TArg3, TArg4>(TTarget instance, ref TArg1 arg1, ref TArg2 arg2, ref TArg3 arg3, ref TArg4 arg4)
    {
        if (IntegrationOptions<TIntegration, TTarget>.IsIntegrationEnabled)
        {
            return BeginMethodHandler<TIntegration, TTarget, TArg1, TArg2, TArg3, TArg4>.Invoke(instance, ref arg1, ref arg2, ref arg3, ref arg4);
        }

        return CallTargetState.GetDefault();
    }

    /// <summary>
    /// Begin Method Invoker
    /// </summary>
    /// <typeparam name="TIntegration">Integration type</typeparam>
    /// <typeparam name="TTarget">Target type</typeparam>
    /// <typeparam name="TArg1">First argument type</typeparam>
    /// <typeparam name="TArg2">Second argument type</typeparam>
    /// <typeparam name="TArg3">Third argument type</typeparam>
    /// <typeparam name="TArg4">Fourth argument type</typeparam>
    /// <typeparam name="TArg5">Fifth argument type</typeparam>
    /// <param name="instance">Instance value</param>
    /// <param name="arg1">First argument value</param>
    /// <param name="arg2">Second argument value</param>
    /// <param name="arg3">Third argument value</param>
    /// <param name="arg4">Fourth argument value</param>
    /// <param name="arg5">Fifth argument value</param>
    /// <returns>Call target state</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static CallTargetState BeginMethod<TIntegration, TTarget, TArg1, TArg2, TArg3, TArg4, TArg5>(TTarget instance, ref TArg1 arg1, ref TArg2 arg2, ref TArg3 arg3, ref TArg4 arg4, ref TArg5 arg5)
    {
        if (IntegrationOptions<TIntegration, TTarget>.IsIntegrationEnabled)
        {
            return BeginMethodHandler<TIntegration, TTarget, TArg1, TArg2, TArg3, TArg4, TArg5>.Invoke(instance, ref arg1, ref arg2, ref arg3, ref arg4, ref arg5);
        }

        return CallTargetState.GetDefault();
    }

    /// <summary>
    /// Begin Method Invoker
    /// </summary>
    /// <typeparam name="TIntegration">Integration type</typeparam>
    /// <typeparam name="TTarget">Target type</typeparam>
    /// <typeparam name="TArg1">First argument type</typeparam>
    /// <typeparam name="TArg2">Second argument type</typeparam>
    /// <typeparam name="TArg3">Third argument type</typeparam>
    /// <typeparam name="TArg4">Fourth argument type</typeparam>
    /// <typeparam name="TArg5">Fifth argument type</typeparam>
    /// <typeparam name="TArg6">Sixth argument type</typeparam>
    /// <param name="instance">Instance value</param>
    /// <param name="arg1">First argument value</param>
    /// <param name="arg2">Second argument value</param>
    /// <param name="arg3">Third argument value</param>
    /// <param name="arg4">Fourth argument value</param>
    /// <param name="arg5">Fifth argument value</param>
    /// <param name="arg6">Sixth argument value</param>
    /// <returns>Call target state</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static CallTargetState BeginMethod<TIntegration, TTarget, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(TTarget instance, ref TArg1 arg1, ref TArg2 arg2, ref TArg3 arg3, ref TArg4 arg4, ref TArg5 arg5, ref TArg6 arg6)
    {
        if (IntegrationOptions<TIntegration, TTarget>.IsIntegrationEnabled)
        {
            return BeginMethodHandler<TIntegration, TTarget, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>.Invoke(instance, ref arg1, ref arg2, ref arg3, ref arg4, ref arg5, ref arg6);
        }

        return CallTargetState.GetDefault();
    }

    /// <summary>
    /// Begin Method Invoker
    /// </summary>
    /// <typeparam name="TIntegration">Integration type</typeparam>
    /// <typeparam name="TTarget">Target type</typeparam>
    /// <typeparam name="TArg1">First argument type</typeparam>
    /// <typeparam name="TArg2">Second argument type</typeparam>
    /// <typeparam name="TArg3">Third argument type</typeparam>
    /// <typeparam name="TArg4">Fourth argument type</typeparam>
    /// <typeparam name="TArg5">Fifth argument type</typeparam>
    /// <typeparam name="TArg6">Sixth argument type</typeparam>
    /// <typeparam name="TArg7">Seventh argument type</typeparam>
    /// <param name="instance">Instance value</param>
    /// <param name="arg1">First argument value</param>
    /// <param name="arg2">Second argument value</param>
    /// <param name="arg3">Third argument value</param>
    /// <param name="arg4">Fourth argument value</param>
    /// <param name="arg5">Fifth argument value</param>
    /// <param name="arg6">Sixth argument value</param>
    /// <param name="arg7">Seventh argument value</param>
    /// <returns>Call target state</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static CallTargetState BeginMethod<TIntegration, TTarget, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(TTarget instance, ref TArg1 arg1, ref TArg2 arg2, ref TArg3 arg3, ref TArg4 arg4, ref TArg5 arg5, ref TArg6 arg6, ref TArg7 arg7)
    {
        if (IntegrationOptions<TIntegration, TTarget>.IsIntegrationEnabled)
        {
            return BeginMethodHandler<TIntegration, TTarget, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>.Invoke(instance, ref arg1, ref arg2, ref arg3, ref arg4, ref arg5, ref arg6, ref arg7);
        }

        return CallTargetState.GetDefault();
    }

    /// <summary>
    /// Begin Method Invoker
    /// </summary>
    /// <typeparam name="TIntegration">Integration type</typeparam>
    /// <typeparam name="TTarget">Target type</typeparam>
    /// <typeparam name="TArg1">First argument type</typeparam>
    /// <typeparam name="TArg2">Second argument type</typeparam>
    /// <typeparam name="TArg3">Third argument type</typeparam>
    /// <typeparam name="TArg4">Fourth argument type</typeparam>
    /// <typeparam name="TArg5">Fifth argument type</typeparam>
    /// <typeparam name="TArg6">Sixth argument type</typeparam>
    /// <typeparam name="TArg7">Seventh argument type</typeparam>
    /// <typeparam name="TArg8">Eighth argument type</typeparam>
    /// <param name="instance">Instance value</param>
    /// <param name="arg1">First argument value</param>
    /// <param name="arg2">Second argument value</param>
    /// <param name="arg3">Third argument value</param>
    /// <param name="arg4">Fourth argument value</param>
    /// <param name="arg5">Fifth argument value</param>
    /// <param name="arg6">Sixth argument value</param>
    /// <param name="arg7">Seventh argument value</param>
    /// <param name="arg8">Eighth argument value</param>
    /// <returns>Call target state</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static CallTargetState BeginMethod<TIntegration, TTarget, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(TTarget instance, ref TArg1 arg1, ref TArg2 arg2, ref TArg3 arg3, ref TArg4 arg4, ref TArg5 arg5, ref TArg6 arg6, ref TArg7 arg7, ref TArg8 arg8)
    {
        if (IntegrationOptions<TIntegration, TTarget>.IsIntegrationEnabled)
        {
            return BeginMethodHandler<TIntegration, TTarget, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>.Invoke(instance, ref arg1, ref arg2, ref arg3, ref arg4, ref arg5, ref arg6, ref arg7, ref arg8);
        }

        return CallTargetState.GetDefault();
    }

    /// <summary>
    /// Begin Method Invoker Slow Path
    /// </summary>
    /// <typeparam name="TIntegration">Integration type</typeparam>
    /// <typeparam name="TTarget">Target type</typeparam>
    /// <param name="instance">Instance value</param>
    /// <param name="arguments">Object arguments array</param>
    /// <returns>Call target state</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static CallTargetState BeginMethod<TIntegration, TTarget>(TTarget instance, object[] arguments)
    {
        if (IntegrationOptions<TIntegration, TTarget>.IsIntegrationEnabled)
        {
            return BeginMethodSlowHandler<TIntegration, TTarget>.Invoke(instance, arguments);
        }

        return CallTargetState.GetDefault();
    }

    /// <summary>
    /// End Method with Void return value invoker
    /// </summary>
    /// <typeparam name="TIntegration">Integration type</typeparam>
    /// <typeparam name="TTarget">Target type</typeparam>
    /// <param name="instance">Instance value</param>
    /// <param name="exception">Exception value</param>
    /// <param name="state">CallTarget state</param>
    /// <returns>CallTarget return structure</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static CallTargetReturn EndMethod<TIntegration, TTarget>(TTarget instance, Exception exception, in CallTargetState state)
    {
        if (IntegrationOptions<TIntegration, TTarget>.IsIntegrationEnabled)
        {
            return EndMethodHandler<TIntegration, TTarget>.Invoke(instance, exception, in state);
        }

        return CallTargetReturn.GetDefault();
    }

    /// <summary>
    /// End Method with Return value invoker
    /// </summary>
    /// <typeparam name="TIntegration">Integration type</typeparam>
    /// <typeparam name="TTarget">Target type</typeparam>
    /// <typeparam name="TReturn">Return type</typeparam>
    /// <param name="instance">Instance value</param>
    /// <param name="returnValue">Return value</param>
    /// <param name="exception">Exception value</param>
    /// <param name="state">CallTarget state</param>
    /// <returns>CallTarget return structure</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static CallTargetReturn<TReturn?> EndMethod<TIntegration, TTarget, TReturn>(TTarget instance, TReturn returnValue, Exception exception, in CallTargetState state)
    {
        if (IntegrationOptions<TIntegration, TTarget>.IsIntegrationEnabled)
        {
            return EndMethodHandler<TIntegration, TTarget, TReturn>.Invoke(instance, returnValue, exception, in state);
        }

        return new CallTargetReturn<TReturn?>(returnValue);
    }

    /// <summary>
    /// Log integration exception
    /// </summary>
    /// <typeparam name="TIntegration">Integration type</typeparam>
    /// <typeparam name="TTarget">Target type</typeparam>
    /// <param name="exception">Integration exception instance</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void LogException<TIntegration, TTarget>(Exception exception)
    {
        IntegrationOptions<TIntegration, TTarget>.LogException(exception);
    }

    /// <summary>
    /// Gets the default value of a type
    /// </summary>
    /// <typeparam name="T">Type to get the default value</typeparam>
    /// <returns>Default value of T</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T? GetDefaultValue<T>() => default;
}
