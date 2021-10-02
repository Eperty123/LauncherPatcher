# LauncherPatcher
A universal X-Legend launcher patcher that allows downloading from your own custom server.

# Note
This only patches the launcher to allow patch files to be downloaded from your server and does not include tools to create said patch files.

There is also a bug in the launcher implementation where it doesn't escape url strings with a hastag (`#`) in them, and will fail to download them. This is of course out of my control and is entirely on X-Legend's end.

## Limitations
Without the actual source code of their launcher it is impossible to exceed certain limititations like the length of urls and log name.

## Launcher Support
The base code and release support the latest TW and HK launchers of Aura Kingdom/Fantasy Frontier as of October 2 2021, and you can add support for more launchers down the line using the json files inside the **[Config](LauncherPatcher/Config)** folder as template. If unsure, check the source code for the implementation.

I am in no way affiliated with X-Legend.
