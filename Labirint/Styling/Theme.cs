using System;
using System.Collections.Generic;
using System.Drawing;

namespace Labirint {
    /*
     * Класс темы лабиринта
     */
    [Serializable]
    public class Theme {
        public static string path = "../../Resources/Theme";
        public static Dictionary<ThemeKind, string> Styles { get; } =
            new Dictionary<ThemeKind, string>()
            {
                { ThemeKind.SPACE , "Космос"},
                { ThemeKind.DESERT , "Пустыня"},
                { ThemeKind.FOREST , "Лес"},
                { ThemeKind.ARCTIC , "Антарктида"},
            };

        public string BackgroundImage { get; set; }
        public string TailImage { get; set; }
        public string HeroImage { get; set; }
        public Color WallColor { get; set; }

        public Theme(): this($"{path}/arctic.jpg", Color.LightBlue) {
        }

        public Theme(
            string backgroundImage,
            Color wallColor) {
            BackgroundImage = backgroundImage;
            WallColor = wallColor;
        }

        public Theme(ThemeKind themeKind) {
            switch (themeKind) {
                case ThemeKind.ARCTIC:
                    SetStyle(
                        $"{path}/arctic.jpg",
                        $"{path}/penguin.png",
                        $"{path}/footstep.png",
                        Color.White);
                    break;
                case ThemeKind.FOREST:
                    SetStyle(
                        $"{path}/forest.jpg",
                        $"{path}/hare.png",
                        $"{path}/paw.png",
                        Color.LightSeaGreen);
                    break;
                case ThemeKind.SPACE:
                    SetStyle(
                        $"{path}/space.jpg",
                        $"{path}/spaceship.png",
                        $"{path}/sparkles.png",
                        Color.LightSkyBlue);
                    break;
                case ThemeKind.DESERT:
                    SetStyle(
                        $"{path}/desert.jpg",
                        $"{path}/camel.png",
                        $"{path}/footstep.png",
                        Color.LightYellow);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(themeKind), themeKind, null);
            }
        }

        private void SetStyle(
            string backgroundImage,
            string heroImage,
            string tailImage,
            Color wallColor) {
            BackgroundImage = backgroundImage;
            WallColor = wallColor;
            HeroImage = heroImage;
            TailImage = tailImage;
        }
    }
}