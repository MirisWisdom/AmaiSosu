# HCE Profile Settings

| Property                     | Type           | Offset | Length | Constraints                         |
| ---------------------------- | -------------- | ------ | ------ | ----------------------------------- |
| Name                         | UTF-16 string  | 0x0002 | 22     | Max. 0xB chars                      |
| Colour                       | Unsigned byte  | 0x011A | 1      | Range 0x00 - 0x12 (white is 0xFF)   |
| Mouse.Sensitivity.Horizontal | Unsigned byte  | 0x0954 | 1      | Range 0x00 - 0x0A                   |
| Mouse.Sensitivity.Vertical   | Unsigned byte  | 0x0955 | 1      | Range 0x00 - 0x0A                   |
| Mouse.InvertVerticalAxis     | Boolean        | 0x0955 | 1      | 1/0                                 |
| Audio.Volume.Master          | Unsigned byte  | 0x0B78 | 1      | Range 0x00 - 0x0A                   |
| Audio.Volume.Effects         | Unsigned byte  | 0x0B79 | 1      | Range 0x00 - 0x0A                   |
| Audio.Volume.Music           | Unsigned byte  | 0x0B7A | 1      | Range 0x00 - 0x0A                   |
| Audio.Quality                | Unsigned byte  | 0x0B7D | 1      | Range 0x00 - 0x02                   |
| Audio.Variety                | Unsigned byte  | 0x0B7F | 1      | Range 0x00 - 0x02                   |
| Video.Resolution.Width       | Unsigned short | 0x0A68 | 2      | Library imposes range 0x1 - 0x7FFF  |
| Video.Resolution.Height      | Unsigned short | 0x0A6A | 2      | Library imposes range 0x1 - 0x7FFF  |
| Video.FrameRate              | Unsigned short | 0x0A6F | 1      | Range 0x00 - 0x02                   |
| Video.Effects.Specular       | Boolean        | 0x0A70 | 1      | 1/0                                 |
| Video.Effects.Shadows        | Boolean        | 0x0A71 | 1      | 1/0                                 |
| Video.Effects.Decals         | Boolean        | 0x0A72 | 1      | 1/0                                 |
| Video.Particles              | Unsigned byte  | 0x0A73 | 1      | Range 0x00 - 0x02                   |
| Video.Quality                | Unsigned byte  | 0x0A74 | 1      | Range 0x00 - 0x02                   |
| Network.Connection           | Unsigned byte  | 0x0FC0 | 1      | Range 0x00 - 0x04                   |
| Network.Port.Server          | Unsigned short | 0x1002 | 1      | Library imposes range 0x1 - 0x10000 |
| Network.Port.Client          | Unsigned short | 0x1004 | 1      | Library imposes range 0x1 - 0x10000 |