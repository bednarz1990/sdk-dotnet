using APIdaze.SDK.ScriptsBuilders;
using APIdaze.SDK.ScriptsBuilders.POCO;
using HttpMock;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;

namespace IvrExample
{
    class Program
    {
        static readonly string INTRO = "/";
        static readonly string STEP_1_PATH = "/step1";
        static readonly string STEP_2_PATH = "/step2";
        static readonly string STEP_3_PATH = "/step3";
        static readonly string PLAYBACK_PATH = "/apidazeintro.wav";
        static readonly string LOCAL_URL = "http://localhost:9191";


        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;


            var stubHttp = HttpMockRepository.At(LOCAL_URL);
            stubHttp.Start();
            Console.WriteLine("Server is running at " + LOCAL_URL);

            var script = ApidazeScript.Build();

            var intro = script.AddNode(Ringback.FromFile(LOCAL_URL + PLAYBACK_PATH)).AddNode(Wait.SetDuration(5))
                .AddNode(new Answer()).AddNode(new Record { Name = "example_recording" }).AddNode(Wait.SetDuration(2))
                .AddNode(Playback.FromFile(LOCAL_URL + PLAYBACK_PATH))
                .AddNode(Speak.WithText("This example script will show you some things you can do with our API"))
                .AddNode(Wait.SetDuration(2)).AddNode(
                    new Speak
                    {
                        Binds = new List<object>
                        {

                            new Bind {Action = LOCAL_URL + STEP_1_PATH, Value = "1"},
                            new Bind {Action = LOCAL_URL + STEP_2_PATH, Value = "2"},
                            new Bind {Action = LOCAL_URL + STEP_3_PATH, Value = "3"}
                        }
                    }.AddTextAfterBinds("Press 1 for an example of text to speech, press 2 to enter an echo line to check voice latency or press 3 to enter a conference."))
                .ToXml();


            stubHttp.Stub(x => x.Get(INTRO))
                .AsContentType("text/xml")
                .Return(intro)
                .OK();

            var step1 = ApidazeScript.Build()
                .AddNode(Speak.WithText(
                    "Our text to speech leverages Google's cloud APIs to offer the best possible solution"))
                .AddNode(Wait.SetDuration(1))
                .AddNode(new Speak()
                {
                    LangEnum = LangEnum.ENGLISH_AUSTRALIA,
                    Voice = VoiceEnum.MALE_A,
                    Text = "A wide variety of voices and languages are available.Here are just a few"
                }).AddNode(Wait.SetDuration(1))
                .AddNode(new Speak() {LangEnum = LangEnum.FRENCH_FRANCE, Text = "Je peux parler français"}).AddNode(
                    Wait.SetDuration(1)).AddNode(new Speak() {LangEnum = LangEnum.GERMAN, Text = "Auch deutsch"})
                .AddNode(Wait.SetDuration(1)).AddNode(new Speak()
                {
                    LangEnum = LangEnum.JAPANESE, Text = "そして日本人ですら"
                }).AddNode(Wait.SetDuration(1)).AddNode(new Speak()
                {
                    Text =
                        "You can see our documentation for a full list of supported languages and voices for them.  We'll take you back to the menu for now."
                }).AddNode(Wait.SetDuration(2))
                .ToXml();

            stubHttp.Stub(x => x.Get(STEP_1_PATH))
                .AsContentType("text/xml")
                .Return(step1)
                .OK();

            var step2 = ApidazeScript.Build()
                .AddNode(Speak.WithText("You will now be joined to an echo line."))
                .AddNode(Echo.SetDuration(500))
                .ToXml();

            stubHttp.Stub(x => x.Get(STEP_2_PATH))
                .AsContentType("text/xml")
                .Return(step2)
                .OK();

            var step3 = ApidazeScript.Build()
                .AddNode(Speak.WithText("You will be entered into a conference call now.  You can initiate more calls to join participants or hangup to leave"))
                .AddNode(new Conference() {Name = "SDKTestConference" })
                .ToXml();

            stubHttp.Stub(x => x.Get(STEP_3_PATH))
                .AsContentType("text/xml")
                .Return(step3)
                .OK();

            stubHttp.Stub(x => x.Get(PLAYBACK_PATH))
                .AsContentType("audio/wav")
                .Return(ExampleUtil.GetFileContents("apidazeintro.wav"))
                .OK();

            string resultIntro = new WebClient().DownloadString(LOCAL_URL + INTRO);
            string step1Result = new WebClient().DownloadString(LOCAL_URL + STEP_1_PATH);
            string step2Result = new WebClient().DownloadString(LOCAL_URL + STEP_2_PATH);
            string step3Result = new WebClient().DownloadString(LOCAL_URL + STEP_3_PATH);
            byte[] step4Result = new WebClient().DownloadData(LOCAL_URL + PLAYBACK_PATH);

            Console.WriteLine("RESPONSE intro:\n{0}", resultIntro);
            Console.WriteLine();
            Console.WriteLine("RESPONSE step 1 :\n{0}", step1Result);
            Console.WriteLine();
            Console.WriteLine("RESPONSE step 2 :\n{0}", step2Result);
            Console.WriteLine();
            Console.WriteLine("RESPONSE step 3 :\n{0}", step3Result);
            Console.WriteLine();
            if (step4Result != null)
            {
                Console.WriteLine("RESPONSE step 4 was received");
            }
        }
    }

    public static class ExampleUtil
    {
        public static byte [] GetFileContents(string sampleFile)
        {
            var asm = Assembly.GetExecutingAssembly();
            var resource = $"IvrExample.{sampleFile}";
            using var stream = asm.GetManifestResourceStream(resource);
            if (stream == null) return null;
            using var reader = new StreamReader(stream);
            return reader.BaseStream.ToByteArray();
        }

        private static byte[] ToByteArray(this Stream stream)
        {
            using var ms = new MemoryStream();
            stream.CopyTo(ms);
            return ms.ToArray();
        }
    }
}