﻿using System;
using System.Text.Json.Serialization;

namespace TrelloDotNet.Model
{
    /// <summary>
    /// Represent a sticker on a Card
    /// </summary>
    public class Sticker
    {
        /// <summary>
        /// Id of the Sticker
        /// </summary>
        [JsonPropertyName("id")]
        [JsonInclude]
        public string Id { get; private set; }

        /// <summary>
        /// The top position of the sticker, from -60 to 100
        /// </summary>
        [JsonPropertyName("top")]
        [QueryParameter]
        public decimal Top { get; set; }

        /// <summary>
        /// Id of the Sticker Image (real Id for custom stickers and string-identifier for default stickers)
        /// </summary>
        [JsonPropertyName("image")]
        [JsonInclude]
        public string ImageId { get; private set; }

        /// <summary>
        /// Id of the Sticker Image as Enum
        /// </summary>
        [JsonIgnore]
        public StickerDefaultImageId ImageIdAsDefaultEnum => StringToDefaultImageId(ImageId);


        /// <summary>
        /// URL of the Sticker Image
        /// </summary>
        [JsonPropertyName("imageUrl")]
        [JsonInclude]
        public string ImageUrl { get; private set; }

        /// <summary>
        /// The left position of the sticker, from -60 to 100
        /// </summary>
        [JsonPropertyName("left")]
        [QueryParameter]
        public decimal Left { get; set; }

        /// <summary>
        /// The z-index of the sticker
        /// </summary>
        [JsonPropertyName("zIndex")]
        [QueryParameter]
        public decimal ZIndex { get; set; }

        /// <summary>
        /// The Rotation of the sticker, from -60 to 100
        /// </summary>
        [JsonPropertyName("rotate")]
        [QueryParameter]
        public decimal Rotation { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Sticker()
        {
            //Serialization
        }

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="imageId">The Default Sticker Type</param>
        /// <param name="top">The top position of the sticker, from -60 to 100</param>
        /// <param name="left">The left position of the sticker, from -60 to 100</param>
        /// <param name="zIndex">The z-index of the sticker</param>
        /// <param name="rotation">The Rotation of the sticker, from -60 to 100</param>
        public Sticker(StickerDefaultImageId imageId, decimal top = 0, decimal left = 0, decimal zIndex = 0, decimal rotation = 0) : this(null, top, left, zIndex, rotation)
        {
            ImageId = DefaultImageToString(imageId);
        }

        private string DefaultImageToString(StickerDefaultImageId imageId)
        {
            switch (imageId)
            {
                case StickerDefaultImageId.Check:
                    return "check";
                case StickerDefaultImageId.Heart:
                    return "heart";
                case StickerDefaultImageId.Warning:
                    return "warning";
                case StickerDefaultImageId.Clock:
                    return "clock";
                case StickerDefaultImageId.Smile:
                    return "smile";
                case StickerDefaultImageId.Laugh:
                    return "laugh";
                case StickerDefaultImageId.Huh:
                    return "huh";
                case StickerDefaultImageId.Frown:
                    return "frown";
                case StickerDefaultImageId.ThumbsUp:
                    return "thumbsup";
                case StickerDefaultImageId.ThumbsDown:
                    return "thumbsdown";
                case StickerDefaultImageId.Star:
                    return "star";
                case StickerDefaultImageId.RocketShip:
                    return "rocketship";
                default:
                    throw new ArgumentOutOfRangeException(nameof(imageId), imageId, null);
            }
        }

        private StickerDefaultImageId StringToDefaultImageId(string imageId)
        {
            switch (imageId)
            {
                case "check":
                    return StickerDefaultImageId.Check;
                case "heart":
                    return StickerDefaultImageId.Heart;
                case "warning":
                    return StickerDefaultImageId.Warning;
                case "clock":
                    return StickerDefaultImageId.Clock;
                case "smile":
                    return StickerDefaultImageId.Smile;
                case "laugh":
                    return StickerDefaultImageId.Laugh;
                case "huh":
                    return StickerDefaultImageId.Huh;
                case "frown":
                    return StickerDefaultImageId.Frown;
                case "thumbsup":
                    return StickerDefaultImageId.ThumbsUp;
                case "thumbsdown":
                    return StickerDefaultImageId.ThumbsDown;
                case "star":
                    return StickerDefaultImageId.Star;
                case "rocketship":
                    return StickerDefaultImageId.RocketShip;
                default:
                    return StickerDefaultImageId.NotADefault;
            }
        }

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="imageId">Id of the Sticker Image (real Id for custom stickers and string-identifier for default stickers)</param>
        /// <param name="top">The top position of the sticker, from -60 to 100</param>
        /// <param name="left">The left position of the sticker, from -60 to 100</param>
        /// <param name="zIndex">The z-index of the sticker</param>
        /// <param name="rotation">The Rotation of the sticker, from -60 to 100</param>
        public Sticker(string imageId, decimal top = 0, decimal left = 0, decimal zIndex = 0, decimal rotation = 0)
        {
            Top = top;
            ImageId = imageId;
            Left = left;
            ZIndex = zIndex;
            Rotation = rotation;
        }


    }
}