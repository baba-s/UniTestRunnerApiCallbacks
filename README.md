# UniTestRunnerApiCallbacks

Unity Test Runner の開始終了時に呼び出されるコールバックを設定できるようにするクラス

## 使用例

```cs
using Kogane;
using UnityEditor;
using UnityEditor.TestTools.TestRunner.Api;
using UnityEngine;

public class Example
{
    [MenuItem( "Tools/Hoge" )]
    private static void Hoge()
    {
        // Test Runner の開始終了時に呼び出されるコールバックを設定する
        var callback = new TestRunnerApiCallbacks
        {
            OnRunStarted   = testsToRun => Debug.Log( testsToRun.Name ),
            OnTestStarted  = test => Debug.Log( test.Name ),
            OnTestFinished = result => Debug.Log( result.TestStatus ),
            OnRunFinished  = result => Debug.Log( result.TestStatus ),
        };

        var testRunnerApi = ScriptableObject.CreateInstance<TestRunnerApi>();

        testRunnerApi.RegisterCallbacks( callback );

        var filter = new Filter
        {
            testMode = TestMode.EditMode,
        };

        testRunnerApi.Execute( new ExecutionSettings( filter ) );

        testRunnerApi.UnregisterCallbacks( callback );
    }
}
```
