
namespace P01.Stream_Progress
{
    public class StreamProgressInfo
    {
        private IStreamer file;

        public StreamProgressInfo(IStreamer file)
        {
            this.file = file;
        }

        public int CalculateCurrentPercent()
        {
            return (this.file.BytesSent * 100) / this.file.Length;
        }
    }
}
