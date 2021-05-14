using System.Threading.Tasks;

namespace Boozewasher.Web.Abstractions
{
    public interface IViewRenderService
    {
        Task<string> RenderViewToStringAsync<TModel>(string viewName, TModel model);
    }
}