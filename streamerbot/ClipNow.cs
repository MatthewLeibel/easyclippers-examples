// EasyClippers: a !clip command for Streamer.bot (https://streamer.bot)
//
// 1. In EasyClippers, make a token: Settings, API and connectors, New token, with "Record streams, stop them,
//    clip moments and use the Ask bar" ticked. Copy it (it is shown once).
// 2. In Streamer.bot, add an action "EasyClippers clip", add the sub-action Core, C#, Execute C# Code,
//    paste this file, put your token in place of PASTE_YOUR_TOKEN and click Compile.
// 3. Add a command such as !clip linked to the action, limited to you and your moderators (or run the action
//    from a Stream Deck button or a channel point reward).
//
// It pins the last 60 seconds of the stream EasyClippers is recording now (10 to 120 allowed); that stretch is
// made into a captioned vertical short. With nothing recording, the call returns an error and nothing is clipped.
// Guide: https://easyclippers.com/guides/streamerbot-clip-command

using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

public class CPHInline
{
    private static readonly HttpClient client = new HttpClient { Timeout = TimeSpan.FromSeconds(20) };
    private const string Token = "PASTE_YOUR_TOKEN";

    public bool Execute()
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "https://easyclippers.com/api/v1/recordings/clip-now");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Token);
        request.Content = new StringContent("{\"seconds\": 60}", Encoding.UTF8, "application/json");
        try
        {
            HttpResponseMessage response = client.SendAsync(request).GetAwaiter().GetResult();
            if (!response.IsSuccessStatusCode)
            {
                CPH.LogError("EasyClippers clip failed: " + (int)response.StatusCode);
                return false;
            }
            return true;
        }
        catch (Exception e)
        {
            CPH.LogError("EasyClippers clip error: " + e.Message);
            return false;
        }
    }
}
