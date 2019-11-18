using Amazon.Lambda.Core;

namespace AWSServerless1
{
    public partial class StepFunctionTasks
    {
        public State Hello(State state, ILambdaContext context)
        {
            state.Message = "Hello";

            if (!string.IsNullOrEmpty(state.Name))
            {
                state.Message += " " + state.Name;
            }

            // Tell Step Function to wait 5 seconds before calling 
            state.WaitInSeconds = 5;

            return state;
        }
    }
}
