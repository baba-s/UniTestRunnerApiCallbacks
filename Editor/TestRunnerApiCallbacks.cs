using System;
using UnityEditor.TestTools.TestRunner.Api;

namespace Kogane
{
	public sealed class TestRunnerApiCallbacks : ICallbacks
	{
		public Action<ITestAdaptor>       OnRunStarted   { get; set; }
		public Action<ITestResultAdaptor> OnRunFinished  { get; set; }
		public Action<ITestAdaptor>       OnTestStarted  { get; set; }
		public Action<ITestResultAdaptor> OnTestFinished { get; set; }

		void ICallbacks.RunStarted( ITestAdaptor testsToRun )
		{
			OnRunStarted?.Invoke( testsToRun );
		}

		void ICallbacks.RunFinished( ITestResultAdaptor result )
		{
			OnRunFinished?.Invoke( result );
		}

		void ICallbacks.TestStarted( ITestAdaptor test )
		{
			OnTestStarted?.Invoke( test );
		}

		void ICallbacks.TestFinished( ITestResultAdaptor result )
		{
			OnTestFinished?.Invoke( result );
		}
	}
}