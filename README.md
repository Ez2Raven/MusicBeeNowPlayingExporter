# MusicBee Now Playing OBS Exporter
> based on MusicBee API v3.1

Plugin to export track information to an easily consumable format for OBS to display during streaming.

## Installing / Getting started

Follow the (tutorial)[https://musicbee.fandom.com/wiki/Tutorial:_Creating_A_Simple_Plugin] on 
Setting up your IDE and getting started with developing a simple MusicBee Plugin

### Initial Configuration

Add your copy of MusicBee.exe as a project reference to this solution.

While you may have installed MusicBee on your operating system, I would strong recommend using 
the portable version to avoid messing things up on your day-to-day MusicBee installation.


## Developing

Start developing by cloning this repository

```shell
git clone https://github.com/demandous/MusicBeeNowPlayingExporter.git
cd MusicBeeNowPlayingExporter
nuget restore MusicBeeNowPlayingOBS.sln
```


### Building

As per documented on https://www.getmusicbee.com/help/api/, 
* All dlls need to be named MB_*.dll and placed in the Plugins folder where the portable version of MusicBee is stored.
* You need to target .NET 4.0 client profile.
* All MusicBee interfaces runs in 32-bit mode on 64-bit machines.


### Deploying / Publishing

TBD

## Features

What's all the bells and whistles this project can perform?
* Export track information such as Music Artist, Track Title, Album Name and Cover Artwork with configurable default values.

## Outstanding Features
* Directory selection dialog to prompt user the location for generated output. (Currently, user has to provide path as string value)

## Contributing

If you'd like to contribute, please fork the repository and use a feature
branch. Pull requests are warmly welcome.

This solution uses the default coding style that comes with Resharper + Visual Studio 2019
All C# code with the exception of MusicBeeInterface.cs, should be cleaned up using Resharper's built-in Full Cleanup options

## Links
- Project homepage: https://github.com/demandous/MusicBeeNowPlayingExporter
- Repository: https://github.com/demandous/MusicBeeNowPlayingExporter
- Issue tracker: https://github.com/demandous/MusicBeeNowPlayingExporter/issues
  - In case of sensitive bugs like security vulnerabilities, please contact
    ng_shi_jie@live.com directly instead of using issue tracker. Your inputs are highly valued
    to improve the security and privacy of this project!
- Resources:
   - MusicBee Plugin Tutorial: https://musicbee.fandom.com/wiki/Tutorial:_Creating_A_Simple_Plugin
   - MusicBee Developer Forum: https://getmusicbee.com/forum/index.php?board=26.0

## Licensing
The code in this project is licensed under Apache-2.0 License.
