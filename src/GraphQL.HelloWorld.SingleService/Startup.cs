
namespace GraphQL.HelloWorld.SingleService
{
    using GraphQL;
    using GraphQL.Http;
    using GraphQL.Types;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    
    public class Startup
    {
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var schema = new Schema { Query = new HelloWorldQuery() };

            app.Run(async (context) =>
            {
                var result = await new DocumentExecuter()
                    .ExecuteAsync(doc =>
                    {
                        doc.Schema = schema;
                        doc.Query = @"query {hello world}";
                    })
                    .ConfigureAwait(false);

                var json = new DocumentWriter(indent: true)
                    .Write(result);

                await context.Response.WriteAsync(json);
            });
        }
    }
}
