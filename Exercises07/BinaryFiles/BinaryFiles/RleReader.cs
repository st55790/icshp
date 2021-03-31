using System.IO;

namespace BinaryFiles
{
    public class RleReader
    {
        private int currentByte = 0;
        private int runLength = 0, runIndex = 0;
        private Stream stream;

        public RleReader(Stream stream) {
            this.stream = stream;
        }

        public int ReadByte()
        {
            if (runLength > 0)
            {
                runIndex++;
                if (runIndex == (runLength - 1))
                    runLength = 0;
            }
            else
            {
                currentByte = stream.ReadByte();
                if (currentByte > 191)
                {
                    runLength = currentByte - 192;
                    currentByte = stream.ReadByte();
                    if (runLength == 1)
                        runLength = 0;
                    runIndex = 0;
                }
            }
            return currentByte;
        }
    }
}