namespace G2Plot.Base
{
    public class ChartEvent
    {
        public ChartEvent(IChartComponent sender, System.Text.Json.JsonElement data)
        {
            Sender = sender;
            Data = data;
        }

        public IChartComponent Sender { get; set; }

        public System.Text.Json.JsonElement Data { get; set; }
    }
}
