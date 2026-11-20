# EasyClippers API examples

[EasyClippers](https://easyclippers.com) is an AI clipping tool for live streamers. It records a Twitch, Kick or
YouTube stream from the channel link, finds the moments worth sharing (speech, laughter, loudness, on-screen action and
chat) and turns them into captioned vertical shorts while the stream is still live. A moment you clip is ready in a
couple of minutes, and the AI keeps adding shorts as the stream goes on.

This repository has small, working examples for its API and its connector for Claude and ChatGPT.

| Example | What it does |
|---|---|
| [`streamerbot/ClipNow.cs`](streamerbot/ClipNow.cs) | A `!clip` chat command (or Stream Deck button) for [Streamer.bot](https://streamer.bot) that pins the last minute of your stream |
| [`curl/clip-now.sh`](curl/clip-now.sh) | Pin a moment of the stream that is recording now |
| [`curl/list-shorts.sh`](curl/list-shorts.sh) | List your approved shorts |
| [Connector setup](#use-it-from-claude-and-chatgpt) | Add EasyClippers to Claude, Claude Code or ChatGPT |

## Get a token

In EasyClippers, open **Settings, API and connectors, New token**. Name it, choose what it may do (see your work,
record and use the Ask bar, post) and how long it lasts. The token is shown once: copy it then, and keep it private.
Anyone with it can act on your account; revoke it in the same place if it leaks.

## The API

Base URL: `https://easyclippers.com/api/v1`, with the token in the `Authorization: Bearer <token>` header.

- `GET /me`, `/projects`, `/shorts` (filters: `status`, `project_id`, `q`, `since`, `until`), `/shorts/{id}`,
  `/shorts/{id}/video`, `/accounts`, `/usage`
- `POST /recordings` (a link), `/recordings/stop`, `/recordings/clip-now`, `/ask` (a message), `/ask/run` (a plan
  token and confirm), `/shorts/{id}/post` (accounts or networks, and confirm)

`clip-now` takes `seconds` from 10 to 120 (60 by default) and, when more than one stream records at once,
`project_id`. It needs a recording running. Each token can make up to 30 changes (clips, recordings, posts) in
10 minutes.

## Use it from Claude and ChatGPT

EasyClippers is also an MCP server at `https://easyclippers.com/mcp` (listed in the official MCP Registry as
`com.easyclippers/easyclippers`). Once connected, you can ask: "record my stream", "clip that", "what are my best
shorts from last night", "post that one to TikTok".

- **Claude:** Customize, Connectors, Add, Add custom connector. Name it EasyClippers, paste
  `https://easyclippers.com/mcp`, press Add, then Connect and Allow on the EasyClippers page.
- **Claude Code:** `claude mcp add --transport http easyclippers https://easyclippers.com/mcp`, then `/mcp` to sign in.
- **ChatGPT:** Settings, Apps and Connectors, turn on Developer mode under Advanced settings, then Create. Name it
  EasyClippers, paste `https://easyclippers.com/mcp` and choose OAuth.

Full steps: [connect EasyClippers to Claude and ChatGPT](https://easyclippers.com/guides/connect-claude-and-chatgpt).

## Guides

- [How to clip a stream while you are still live](https://easyclippers.com/guides/how-to-clip-a-stream-while-live)
- [A !clip command with Streamer.bot](https://easyclippers.com/guides/streamerbot-clip-command)
- [The best AI clipping tools for streamers in 2026](https://easyclippers.com/guides/best-ai-clipping-tools)
- [The best clipping tools for Kick](https://easyclippers.com/guides/best-kick-clipping-tools)
- [The best YouTube live clipping tools](https://easyclippers.com/guides/best-youtube-live-clipping-tools)
- [How to turn YouTube live streams into Shorts](https://easyclippers.com/guides/youtube-live-to-shorts)
- [Live clipping: AI that makes shorts while you are still live](https://easyclippers.com/guides/live-clipping-ai)
- [How to clip your GTA 6 streams into Shorts](https://easyclippers.com/guides/gta-6-stream-clips)
- [Clip any live stream from an RTMP encoder](https://easyclippers.com/guides/clip-any-live-stream)
- Free tools, no account needed to start: [Twitch clip maker](https://easyclippers.com/tools/twitch-clip-maker),
  [Kick clip maker](https://easyclippers.com/tools/kick-clip-maker),
  [Twitch VOD moment finder](https://easyclippers.com/tools/twitch-moments)

## Pricing

Plans are priced by the stream hour and start at $9.99 a month; the first 30 minutes of streams or videos turned into
shorts are free, with no card. Shorts made through the API use credits like any other short.
See [pricing](https://easyclippers.com/pricing).

## License

The example code is MIT licensed (see [LICENSE](LICENSE)). EasyClippers is made by NEOTECH Inc.
Questions: support@easyclippers.com.
