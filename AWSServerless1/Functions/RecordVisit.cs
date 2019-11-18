using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Amazon.Lambda.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AWSServerless1
{
    public partial class StepFunctionTasks
    {
        public async Task<State> RecordVisit(State state, ILambdaContext context)
        {
            Console.Write($"{state.Name} visited us");

            AmazonDynamoDBClient client = new AmazonDynamoDBClient();
            var table = Environment.GetEnvironmentVariable("DB");

            //var table = "vs-serverless-app-incommingCompansationsDynamoDBTable-1WZ2X0RBEFB2X";

            var request = new PutItemRequest
            {
                TableName = table,
                Item = new Dictionary<string, AttributeValue>()
                {
                    { "compensation", new AttributeValue { S = Guid.NewGuid().ToString() }},
                    { "Title", new AttributeValue { S = state.Name }},
                    { "DateReceived", new AttributeValue { S = DateTime.Now.ToString() }},
                    { "Amount", new AttributeValue { N = "20.00" }},
                    { "Code", new AttributeValue { S = "GHR-12-UIS" }},
                    {
                    "Assets",
                    new AttributeValue
                    { 
                        SS = new List<string>{"Car", "House"}   }
                    }
                }
            };

            await client.PutItemAsync(request);

            return state;
        }
    }
}
