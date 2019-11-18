using Amazon.Lambda.Core;

namespace AWSServerless1
{
    public partial class StepFunctionTasks
    {
        public State ByeBye(State state, ILambdaContext context)
        {
            state.Message += ", Goodbye1";

            if (!string.IsNullOrEmpty(state.Name))
            {
                state.Message += " " + state.Name;
            }

            return state;
        }
    }
}
