using APIdaze.SDK.Base;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;

namespace APIdaze.SDK.Recordings
{
    public class Recordings : BaseApiClient, IRecordings
    {
        private static readonly string TEMP_FILE_PREFIX = "apidaze-sdk-recordings-";

        protected override string Resource => "/recordings";

        public Recordings(IRestClient client, Credentials credentials) : base(client, credentials)
        {
        }

        public IEnumerable<string> GetRecordingsList()
        {
            throw new NotImplementedException();
        }

        public Stream DownloadRecording(string sourceFileName)
        {
            throw new NotImplementedException();
        }

        public void DownloadRecodingToFileAsync(string sourceFileName, string target)
        {
            throw new NotImplementedException();
        }

        public void DownloadRecodingToFileAsync(string sourceFileName, string target, bool replaceExisting)
        {
            throw new NotImplementedException();
        }

        public FileInfo DownloadRecodingToFile(string sourceFileName, string target)
        {
            throw new NotImplementedException();
        }

        public FileInfo DownloadRecodingToFile(string sourceFileName, string target, bool replaceExisting)
        {
            throw new NotImplementedException();
        }

        public void DeleteRecording(string fileName)
        {
            throw new NotImplementedException();
        }
    }
}