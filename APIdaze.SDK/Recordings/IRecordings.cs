using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace APIdaze.SDK.Recordings
{
    public interface IRecordings
    {
        IEnumerable<string> GetRecordingsList();

        Stream DownloadRecording(string sourceFileName);

        Task DownloadRecodingToFileAsync(string sourceFileName, string target);

        FileInfo DownloadRecodingToFile(string sourceFileName, string target);

        void DeleteRecording(string fileName);
    }
}