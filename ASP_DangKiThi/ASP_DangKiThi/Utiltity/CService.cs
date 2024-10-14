using ASP_DangKiThi.Controllers;
using ASP_DangKiThi.Models;

namespace ASP_DangKiThi.Utiltity
{
    public class CService
    {
        public db_ASP_ProjectContext DbContext { get; }
        public IHttpContextAccessor HttpContextAccessor { get; }
        public ILogger<BaseController> Logger { get; }
        public IConfiguration Configuration { get; }

        public CService(
            db_ASP_ProjectContext objDBContext,
            IHttpContextAccessor objHttpContext,
            ILogger<BaseController> objLogger,
            IConfiguration objConfig)
        {
            this.DbContext = objDBContext;
            this.HttpContextAccessor = objHttpContext;
            this.Logger = objLogger;
            this.Configuration = objConfig;
        }
    }
}
