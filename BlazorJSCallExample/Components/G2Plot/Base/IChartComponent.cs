using System.Text.Json;
using System.Threading.Tasks;

namespace G2Plot.Base
{
    public interface IChartComponent
    {
        public Task Render();

        public Task Update(object option);

        public Task ChangeData(object data);

        public Task ChangeSize(double width, double height);

        public Task<string> SetEvent(string eventName, string invokableFunctionName);

        public Task<string> SetEventOnce(string eventName, string invokableFunctionName);

        public Task RemoveEvent(string eventName, string callbackId);

        public Task SetState(object state);

        public Task<JsonElement> GetState(object state);
    }
}