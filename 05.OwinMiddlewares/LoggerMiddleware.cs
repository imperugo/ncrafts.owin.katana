namespace OwinMiddlewares
{
	using System.Threading.Tasks;

	using Microsoft.Owin;

	public class LoggerMiddleware : OwinMiddleware
	{
	    public LoggerMiddleware(OwinMiddleware next) : base(next)
	    {
	        
	    }
	    
	    public override async Task Invoke(IOwinContext context)
	    {
	        await context.Response.WriteAsync("Before (middleware with Katana middleware base class)\r\n");
	        await this.Next.Invoke(context);
	        await context.Response.WriteAsync("After (middleware with Katana middleware base class)\r\n");
	    }
    }
}
