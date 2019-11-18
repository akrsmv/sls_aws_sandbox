using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Xunit;
using Amazon.Lambda.Core;
using Amazon.Lambda.TestUtilities;

using AWSServerless1;
using System.IO;
using System.Text;

namespace AWSServerless1.Tests
{
    public class FunctionTest
    {
        public FunctionTest()
        {
        }

        [Fact]
        public void TestHello()
        {
            TestLambdaContext context = new TestLambdaContext();

            StepFunctionTasks functions = new StepFunctionTasks();

            var state = new State
            {
                Name = "MyStepFunctions"
            };


            state = functions.Hello(state, context);

            Assert.Equal(5, state.WaitInSeconds);
            Assert.Equal("Hello MyStepFunctions", state.Message);
        }

        [Fact]
        public void TestByeBye()
        {
            TestLambdaContext context = new TestLambdaContext();

            StepFunctionTasks functions = new StepFunctionTasks();

            var state = new State
            {
                Name = "MyStepFunctions"
            };


            state = functions.ByeBye(state, context);

            Assert.Equal(", Goodbye1 MyStepFunctions", state.Message);
        }

        [Fact]
        public void TestRecordVisit()
        {
            TestLambdaContext context = new TestLambdaContext();

            StepFunctionTasks functions = new StepFunctionTasks();

            var state = new State
            {
                Name = "MyStepFunctions"
            };

            var content = new StringBuilder();
            var writer = new StringWriter(content);
            Console.SetOut(writer);

            state = functions.RecordVisit(state, context).GetAwaiter().GetResult();

            Assert.Equal("MyStepFunctions visited us", content.ToString());
        }
    }
}
