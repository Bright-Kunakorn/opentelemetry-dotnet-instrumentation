// <copyright file="BeginMethodHandler`4.cs" company="OpenTelemetry Authors">
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

using System.Diagnostics;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;

#pragma warning disable SA1649 // File name must match first type name

namespace OpenTelemetry.AutoInstrumentation.CallTarget.Handlers;

internal static class BeginMethodHandler<TIntegration, TTarget, TArg1, TArg2, TArg3, TArg4>
{
    private static readonly InvokeDelegate _invokeDelegate;

    static BeginMethodHandler()
    {
        try
        {
            Type tArg1ByRef = typeof(TArg1).IsByRef ? typeof(TArg1) : typeof(TArg1).MakeByRefType();
            Type tArg2ByRef = typeof(TArg2).IsByRef ? typeof(TArg2) : typeof(TArg2).MakeByRefType();
            Type tArg3ByRef = typeof(TArg3).IsByRef ? typeof(TArg3) : typeof(TArg3).MakeByRefType();
            Type tArg4ByRef = typeof(TArg4).IsByRef ? typeof(TArg4) : typeof(TArg4).MakeByRefType();
            DynamicMethod? dynMethod = IntegrationMapper.CreateBeginMethodDelegate(typeof(TIntegration), typeof(TTarget), new[] { tArg1ByRef, tArg2ByRef, tArg3ByRef, tArg4ByRef });
            if (dynMethod != null)
            {
                _invokeDelegate = (InvokeDelegate)dynMethod.CreateDelegate(typeof(InvokeDelegate));
            }
        }
        catch (Exception ex)
        {
            throw new CallTargetInvokerException(ex);
        }
        finally
        {
            if (_invokeDelegate is null)
            {
                _invokeDelegate = (TTarget instance, ref TArg1 arg1, ref TArg2 arg2, ref TArg3 arg3, ref TArg4 arg4) => CallTargetState.GetDefault();
            }
        }
    }

    internal delegate CallTargetState InvokeDelegate(TTarget instance, ref TArg1 arg1, ref TArg2 arg2, ref TArg3 arg3, ref TArg4 arg4);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static CallTargetState Invoke(TTarget instance, ref TArg1 arg1, ref TArg2 arg2, ref TArg3 arg3, ref TArg4 arg4)
    {
        return new CallTargetState(Activity.Current, _invokeDelegate(instance, ref arg1, ref arg2, ref arg3, ref arg4));
    }
}
