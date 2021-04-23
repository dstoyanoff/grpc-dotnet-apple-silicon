using System.Threading.Tasks;
using Grpc.Core;

namespace grpc_dotnet
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly AppDbContext _dbContext;

        public GreeterService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            _dbContext.Hellos.Add(new Hello
            {
                Name = request.Name
            });

            await _dbContext.SaveChangesAsync();

            return new HelloReply
            {
                Message = "Hello " + request.Name
            };
        }
    }
}