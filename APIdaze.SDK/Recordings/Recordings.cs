using APIdaze.SDK.Base;
using RestSharp;
using RestSharp.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace APIdaze.SDK.Recordings
{
    public class Recordings : BaseApiClient, IRecordings
    {
        protected override string Resource => "/recordings";

        public Recordings(IRestClient client, Credentials credentials) : base(client, credentials) { }

        public IEnumerable<string> GetRecordingsList()
        {
            return FindAll<string>();
        }

        public Stream DownloadRecording(string sourceFileName)
        {
            var restRequest = DownloadRequest(sourceFileName);
            var response = Client.DownloadData(restRequest);
            return new MemoryStream(response);
        }

        public async Task DownloadRecodingToFileAsync(string sourceFileName, string target)
        {
            var restRequest = DownloadRequest(sourceFileName);
            var response = await Client.ExecuteTaskAsync(restRequest);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new InvalidOperationException(response.ErrorMessage);
            }

            var completeFilePath = Path.Combine(target, sourceFileName);
            SaveFileToFolder(sourceFileName, target, completeFilePath, response);
        }

        public FileInfo DownloadRecodingToFile(string sourceFileName, string target)
        {
            var restRequest = DownloadRequest(sourceFileName);
            var response = Client.Execute(restRequest);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new InvalidOperationException(response.ErrorMessage);
            }

            var completeFilePath = Path.Combine(target, sourceFileName);
            completeFilePath = SaveFileToFolder(sourceFileName, target, completeFilePath, response);
            return new FileInfo(completeFilePath);
        }

        public void DeleteRecording(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) throw new ArgumentException("file name must not be null or empty");
            Delete(fileName);
        }

        private RestRequest DownloadRequest(string sourceFileName)
        {
            var restRequest = AuthenticateRequest();
            restRequest.Resource += "/{file_name}";
            restRequest.AddUrlSegment("file_name", sourceFileName);
            return restRequest;
        }

        private static string SaveFileToFolder(string sourceFileName, string target, string completeFilePath,
            IRestResponse response)
        {
            if (Directory.Exists(target))
            {
                var counter = 0;

                while (File.Exists(completeFilePath))
                {
                    counter++;

                    completeFilePath = Path.Combine(target,
                        $"{Path.GetFileNameWithoutExtension(sourceFileName)} ({counter}){Path.GetExtension(sourceFileName)}");
                }

                response.RawBytes.SaveAs(completeFilePath);
            }
            else
            {
                response.RawBytes.SaveAs(completeFilePath);
            }

            return completeFilePath;
        }
    }
}